"""Inventory DE source coverage. Python 3, standard library only; source is read-only.

Usage: python de-source-coverage.py --source E:/TAP/DE/DeadEmpire-DEV
       --output E:/Git/MyUnityFramework/Design/reports/de-source-coverage
This inventories definitions, not runtime reachability or successful migration.
"""
import argparse
import csv
import hashlib
import json
import re
from collections import Counter
from datetime import datetime, timezone
from pathlib import Path


def strip_comments(text):
    """Preserve quoted strings, character literals and newlines while blanking comments."""
    pattern = re.compile(r'@"(?:""|[^"])*"|"(?:\\.|[^"\\])*"|\'(?:\\.|[^\'\\])*\'|//[^\r\n]*|/\*[\s\S]*?\*/')
    return pattern.sub(lambda m: re.sub(r'[^\r\n]', ' ', m.group())
                       if m.group().startswith(('//', '/*')) else m.group(), text)


def read(path):
    return path.read_text(encoding='utf-8-sig', errors='replace')


def inventory(source):
    rows = []

    def add(kind, identity, path, line=0, target='', note='', references=''):
        relative = path.relative_to(source).as_posix()
        key = kind + ':' + identity
        rows.append(dict(id=key, kind=kind, identity=identity, source=relative,
                         line=line, target=target, source_sha256=hashlib.sha256(path.read_bytes()).hexdigest(),
                         status='not_migrated', implementation='', evidence='', note=note, references=references))

    menus = source / 'Assets/Scripts/UINew/UMenusMgr.cs'
    clean = strip_comments(read(menus))
    for match in re.finditer(r'\{\s*GlobalConstLocal\.(EMENU_\w+)\s*,\s*"([^"]+)"\s*\}', clean):
        add('menu', match.group(1), menus, clean.count('\n', 0, match.start()) + 1,
            match.group(2), 'Comment-filtered registration; preprocessor branches and runtime reachability require verification.')
    activity = source / 'Assets/Scripts/UINew/Activity/Data'
    for path in sorted(activity.glob('*.cs')):
        clean = strip_comments(read(path))
        for match in re.finditer(r'\bclass\s+(ActivityData\w*)\b', clean):
            kind = 'activity_base_class' if match.group(1) == 'ActivityDataCommon' else 'activity_class'
            add(kind, match.group(1), path, clean.count('\n', 0, match.start()) + 1,
                note='Base class is tracked separately. Concrete/unknown declaration alone does not prove active gameplay.')
    roots = ('Assets/Scripts/FromLua', 'Assets/Scripts/UINew', 'Assets/Scripts/GVG',
             'Assets/Scripts/KVK', 'Assets/Scripts/Arena', 'Assets/Scripts/Expedition',
             'Assets/Scripts/Pop-ups', 'Assets/CityBuild/Script', 'Assets/WildMap/Script',
             'Assets/FPS/Scripts', 'Assets/VideoChannel')
    for relative in roots:
        root = source / relative
        if not root.is_dir():
            continue
        candidates = [root] + sorted(p for p in root.iterdir() if p.is_dir())
        for directory in candidates:
            files = sorted(directory.glob('*.cs'))
            if files:
                identity = directory.relative_to(source).as_posix()
                add('business_directory', identity, files[0], target=identity,
                    note='Directory group; {} direct C# files. Also inspect nested groups and root-level managers.'.format(len(files)))
    for path in sorted((source / 'Assets').rglob('*.prefab')):
        add('prefab', path.relative_to(source).as_posix(), path,
            note='Asset inventory; runtime use, dependencies and migration still unverified.')
    for path in sorted((source / 'Assets').rglob('*.unity')):
        add('scene', path.relative_to(source).as_posix(), path,
            note='Scene inventory; build inclusion and runtime use require separate verification.')
    protocol = {}
    generated = re.compile(r'^(?:ProtocolDefine\d*|ProtocolTypeEnum|ProtocolCreator|ProtocolMVC)\.cs$')
    for path in sorted((source / 'Assets').rglob('*.cs')):
        if generated.match(path.name):
            continue
        text = read(path)
        if 'MsgType.' not in text:
            continue
        clean = strip_comments(text)
        for match in re.finditer(r'\b(?:Protocol\.)?MsgType\s*\.\s*([A-Za-z_]\w*)', clean):
            line = clean.count('\n', 0, match.start()) + 1
            protocol.setdefault(match.group(1), []).append((path, line))
    for symbol, uses in sorted(protocol.items()):
        locations = sorted(set('{}:{}'.format(path.relative_to(source).as_posix(), line) for path, line in uses))
        add('protocol_client_symbol', symbol, uses[0][0], uses[0][1], symbol,
            'Comment-filtered client MsgType references; generated definitions excluded. Usage is not proof of a working send/handler branch.',
            '\n'.join(locations))
    return rows


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    args = parser.parse_args()
    source = args.source.resolve()
    output = args.output.resolve()
    if not (source / 'Assets/Scripts/UINew/UMenusMgr.cs').is_file():
        parser.error('Source must be an existing DE project with UMenusMgr.cs.')
    if output == source or source in output.parents:
        parser.error('Output must be outside the read-only DE source project.')
    rows = inventory(source)
    ids = [r['id'] for r in rows]
    duplicates = sorted(k for k, count in Counter(ids).items() if count > 1)
    counts = {kind: sum(r['kind'] == kind for r in rows) for kind in sorted({r['kind'] for r in rows})}
    result = dict(schema_version=1, generated_utc=datetime.now(timezone.utc).isoformat(),
                  source=str(source), scope='Source inventory, not implementation or acceptance evidence',
                  counts=counts, duplicate_ids=duplicates, items=rows)
    output.mkdir(parents=True, exist_ok=True)
    (output / 'source-coverage.json').write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding='utf-8')
    with (output / 'source-coverage.csv').open('w', encoding='utf-8-sig', newline='') as handle:
        writer = csv.DictWriter(handle, fieldnames=list(rows[0]))
        writer.writeheader()
        writer.writerows(rows)
    print(json.dumps(dict(counts=counts, total=len(rows), duplicate_ids=duplicates,
                          default_status='not_migrated', output=str(output)), ensure_ascii=False))
    if duplicates:
        raise SystemExit('Duplicate inventory identities need review; no acceptance result was produced.')


if __name__ == '__main__':
    main()
