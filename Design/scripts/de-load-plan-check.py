"""Validate concrete load plan order, protocol symbols and request types against read-only DE source."""
import argparse
import importlib.util
import json
from pathlib import Path
import re

spec = importlib.util.spec_from_file_location('coverage', Path(__file__).with_name('de-source-coverage.py'))
coverage = importlib.util.module_from_spec(spec)
spec.loader.exec_module(coverage)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', required=True, type=Path)
    parser.add_argument('--plan', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    args = parser.parse_args()
    plan = json.loads(args.plan.read_text(encoding='utf-8-sig'))
    source = args.source
    loading = coverage.strip_comments((source / 'Assets/Scripts/FromLua/GameLoadingMgr.cs').read_text(encoding='utf-8-sig'))
    match = re.search(r'TypeGameStart\s*=\s*new\s+LoadingStep\[\]\s*\{([\s\S]*?)\};', loading)
    actual_order = re.findall(r'LoadingStep\.(\w+)', match.group(1))
    planned_order = [step['name'] for step in plan['steps']]
    errors = []
    if actual_order != planned_order:
        errors.append(dict(kind='step_order_mismatch', source=actual_order, plan=planned_order))
    protocol = coverage.strip_comments((source / 'Assets/Scripts/Net/ProtocolTypeEnum.cs').read_text(encoding='utf-8-sig'))
    ids = {name: int(value) for name, value in re.findall(r'^\s*(\w+)\s*=\s*(\d+)\s*,', protocol, re.M)}
    classes = set()
    for path in (source / 'Assets/Scripts/Net').glob('ProtocolDefine*.cs'):
        classes.update(re.findall(r'\bclass\s+(\w+)\s*:', path.read_text(encoding='utf-8-sig')))
    used_symbols = set()
    for step in plan['steps']:
        used_symbols.update(step['responses'])
        for request in step['requests']:
            used_symbols.add(request['message'])
            if request['payloadType'] and request['payloadType'] not in classes:
                errors.append(dict(kind='unknown_payload_type', step=step['name'], value=request['payloadType']))
    for symbol in sorted(used_symbols):
        if symbol not in ids:
            errors.append(dict(kind='unknown_message_symbol', value=symbol))
    plan['messageIds'] = {symbol: ids.get(symbol) for symbol in sorted(used_symbols)}
    plan['sourceValidation'] = dict(stepCount=len(actual_order), protocolSymbolCount=len(used_symbols), errors=errors,
                                    scope='Static order, wire symbol and payload-type consistency; conditional semantic behavior reviewed separately, no network run.')
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(plan, ensure_ascii=False, indent=2), encoding='utf-8')
    print(json.dumps(plan['sourceValidation'], ensure_ascii=False, indent=2))
    raise SystemExit(1 if errors else 0)


if __name__ == '__main__':
    main()
