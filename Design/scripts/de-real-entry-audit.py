"""Read-only default-entry gate for the real DE rebuild; does not contact any server."""
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
    parser.add_argument('--project', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    args = parser.parse_args()
    project = args.project.resolve()
    settings = project / 'Assets/Launcher/Settings/StartupSettings.asset'
    text = settings.read_text(encoding='utf-8-sig')
    entries = dict(re.findall(r'^\s*(mainScene|gameEntryType):\s*(.*)$', text, re.M))
    findings = []
    entry = entries.get('gameEntryType', '')
    scene = entries.get('mainScene', '')
    if not entry:
        findings.append('StartupSettings.gameEntryType is missing.')
    if 'GameRuntime.GameApp' in entry:
        findings.append('Default entry still points at the framework demo GameRuntime.GameApp.')
    if 'Assets/AssetBundle/Scenes/Main.unity' == scene:
        findings.append('Default scene still points at the framework demo Main.unity.')
    inspected = []
    bootstrap = project / 'Assets/DE/Bootstrap'
    forbidden = re.compile(r'\b(?:CreateMock|MockDeSession|SnapshotReplaySession|FakeSlgState)\b')
    for path in sorted(bootstrap.rglob('*.cs')):
        if 'Tests' in path.relative_to(bootstrap).parts:
            continue
        cleaned = coverage.strip_comments(path.read_text(encoding='utf-8-sig'))
        inspected.append(path.relative_to(project).as_posix())
        for match in forbidden.finditer(cleaned):
            line = cleaned.count('\n', 0, match.start()) + 1
            findings.append('{}:{} contains forbidden default-bootstrap symbol {}'.format(path.relative_to(project).as_posix(), line, match.group()))
    status = 'failed' if findings else 'static_gate_passed'
    result = dict(status=status, settings=entries, inspected=inspected, findings=findings,
                  scope='Strict Bootstrap source gate. Unused legacy bootstrap files also require explicit isolation. Passing is not real network or visual acceptance.')
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding='utf-8')
    print(json.dumps(result, ensure_ascii=False, indent=2))
    raise SystemExit(1 if findings else 0)


if __name__ == '__main__':
    main()
