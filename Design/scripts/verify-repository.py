"""Read-only repository/index checks. Run from any directory with Python 3.9+."""
from pathlib import Path
import json
import re
import subprocess
import sys

ROOT = Path(__file__).resolve().parents[2]


def git(*args, input_data=None):
    result = subprocess.run(
        ['git', '-C', str(ROOT), *args], input=input_data,
        stdout=subprocess.PIPE, stderr=subprocess.PIPE,
    )
    if result.returncode not in (0, 1):
        raise RuntimeError(result.stderr.decode('utf-8', errors='replace'))
    return result.stdout


def main():
    tracked = set(git('ls-files', '-z').decode('utf-8').strip('\0').split('\0')) - {''}
    errors = []
    if not tracked:
        errors.append('No files in the Git index. Stage the intended source files first.')

    ignored_examples = [
        '.vscode/settings.json', 'Design/local/backup.zip',
        'Design/scripts/mcp-session.txt', 'Design/reports/new-run.json',
        'Design/reports/new-report.md', 'Design/reports/screenshot.png',
        'Design/reports/TEngineNi-audits/example/inventory.json',
        'Design/reports/README.md', 'Design/reports/imported-source-manifest.json',
        'Design/reports/resource-cleanup-manifest.json',
        'Design/reports/TEngineNi-change-inventory.json',
        'Design/reports/TEngineNi-diff/example.diff',
        'Design/reports/baseline-20261012/startup-error-test-results.json',
        'UnityProject1/Library/ArtifactDB', 'UnityProject1/Temp/example',
        'UnityProject1/obj/example', 'UnityProject1/Logs/Editor.log',
        'UnityProject1/UserSettings/EditorUserSettings.asset',
        'UnityProject1/Bundles/example', 'UnityProject1/Builds/example',
        'UnityProject1/HybridCLRData/example', 'UnityProject1/Assembly-CSharp.csproj',
        'UnityProject1/UnityProject1.sln', 'UnityProject1/Assets/StreamingAssets/yoo/example',
        'UnityProject1/Assets/InitTestScene123.unity',
        'UnityProject1/Assets/InitTestScene123.unity.meta',
    ]
    source_examples = [
        'README.md', 'AGENTS.md', 'Doc/当前框架整体功能说明.md',
        'Design/notes/当前工程与DeadEmpire核心功能差异.md',
        'Design/scripts/audit-tengine-changes.ps1',
        'UnityProject1/Assets/Scripts/Launcher/GameEntry.cs',
        'UnityProject1/Assets/Scripts/Launcher/GameEntry.cs.meta',
        'UnityProject1/Assets/Plugins/Roslyn/Microsoft.CodeAnalysis.CSharp.dll',
        'UnityProject1/Packages/manifest.json', 'UnityProject1/Packages/packages-lock.json',
        'UnityProject1/Packages/UniTask/package.json',
        'UnityProject1/Packages/YooAsset/package.json',
        'UnityProject1/Packages/com.code-philosophy.hybridclr/package.json',
        'UnityProject1/ProjectSettings/ProjectVersion.txt',
    ]
    query = ignored_examples + source_examples + list(tracked)
    ignored = set(git(
        'check-ignore', '--no-index', '--stdin', '-z',
        input_data=('\0'.join(query) + '\0').encode('utf-8'),
    ).decode('utf-8').strip('\0').split('\0')) - {''}
    errors.extend('Should be ignored: ' + p for p in ignored_examples if p not in ignored)
    errors.extend('Source/evidence unexpectedly ignored: ' + p for p in source_examples if p in ignored)
    errors.extend('Required input is not staged: ' + p for p in source_examples if p not in tracked)
    errors.extend('Ignored output is staged: ' + p for p in sorted(tracked & ignored))
    ignore_owners = git(
        'check-ignore', '--no-index', '-v', '--stdin',
        input_data=('\n'.join(p for p in ignored_examples if p.startswith('UnityProject1/')) + '\n').encode('utf-8'),
    ).decode('utf-8').splitlines()
    errors.extend('Unity rule belongs in UnityProject1/.gitignore: ' + line for line in ignore_owners if not line.startswith('UnityProject1/.gitignore:'))
    root_rules = (ROOT/'.gitignore').read_text(encoding='utf-8-sig').splitlines()
    errors.extend('Root ignore contains Unity-specific path: ' + line for line in root_rules if line.strip() and not line.lstrip().startswith('#') and 'UnityProject1/' in line)

    assets = ROOT/'UnityProject1/Assets'
    for path in sorted(assets.rglob('*')):
        rel = path.relative_to(ROOT).as_posix()
        if path.name.startswith('.'):
            continue
        if path.suffix == '.meta':
            if rel in tracked and not path.with_suffix('').exists():
                errors.append('Orphan meta: ' + rel)
        elif path.is_file() and rel in tracked:
            if rel + '.meta' not in tracked:
                errors.append('Asset meta is not staged: ' + rel + '.meta')
        elif path.is_dir() and any(p.startswith(rel + '/') for p in tracked):
            if rel + '.meta' not in tracked:
                errors.append('Folder meta is not staged: ' + rel + '.meta')

    allowed_unity_roots = {'Assets', 'Packages', 'ProjectSettings', 'Tools', '.gitignore'}
    for rel in sorted(tracked):
        if rel.startswith('UnityProject1/') and rel.split('/')[1] not in allowed_unity_roots:
            errors.append('Unexpected Unity root input: ' + rel)
        if (ROOT/rel).stat().st_size >= 100 * 1024 * 1024:
            errors.append('File exceeds 100 MiB; review binary storage: ' + rel)

    manifest = json.loads((ROOT/'UnityProject1/Packages/manifest.json').read_text(encoding='utf-8-sig'))
    lock = json.loads((ROOT/'UnityProject1/Packages/packages-lock.json').read_text(encoding='utf-8-sig'))
    shared_packages = {}
    for package, value in manifest['dependencies'].items():
        if value.startswith('file:'):
            path = (ROOT/'UnityProject1/Packages'/value[5:]).resolve()
            if not (path/'package.json').is_file():
                errors.append('Local package is missing or outside repository: ' + package)
            elif package in ('com.ni.tengine', 'com.ni.gamecore'):
                metadata = json.loads((path/'package.json').read_text(encoding='utf-8-sig'))
                if metadata['name'] != package:
                    errors.append('Ni package identity mismatch: ' + package)
                shared_packages[package] = str(path)
            elif not path.is_relative_to(ROOT):
                errors.append('Unexpected external local package: ' + package)
        elif package in ('com.ni.tengine', 'com.ni.gamecore'):
            expected = 'https://github.com/gameboys84/TEngineNi_UPM.git?path=/' + package + '#'
            if not value.startswith(expected) or not re.fullmatch(r'[0-9a-f]{40}', value[len(expected):]):
                errors.append('Ni package must pin a full SHA in TEngineNi_UPM: ' + package)
            elif lock['dependencies'].get(package, {}).get('hash') != value.rsplit('#', 1)[1]:
                errors.append('Ni package lock hash mismatch: ' + package)
        if package not in lock['dependencies']:
            errors.append('Manifest package absent from lock: ' + package)
        elif value != lock['dependencies'][package]['version']:
            errors.append('Manifest/lock version mismatch: ' + package)
    for package in ('com.ni.tengine', 'com.ni.gamecore'):
        if package not in manifest['dependencies']:
            errors.append('Required shared Ni package dependency is absent: ' + package)
    ni_refs = [manifest['dependencies'].get(p, '') for p in ('com.ni.tengine', 'com.ni.gamecore')]
    if all('#' in ref for ref in ni_refs) and len({ref.rsplit('#', 1)[1] for ref in ni_refs}) != 1:
        errors.append('Ni packages must use the same repository commit')
    for obsolete in ['Assets/TEngine/Runtime', 'Assets/TEngine/Editor', 'Assets/Scripts/Hotfix/GameCore/Module', 'Assets/Scripts/Hotfix/GameCore/SingletonSystem']:
        if (ROOT/'UnityProject1'/obsolete).exists():
            errors.append('Duplicate shared framework source in project: ' + obsolete)

    errors.extend('Report output must not be staged: ' + p for p in sorted(tracked) if p.startswith('Design/reports/'))

    # Core navigation must be self-contained after consolidation.
    navigation = [ROOT/'README.md', ROOT/'Design/README.md'] + list((ROOT/'Doc').glob('*.md'))
    for path in navigation:
        text = path.read_text(encoding='utf-8-sig')
        for match in re.finditer(r'\[[^\]]+\]\((<[^>]+>|[^)]+)\)', text):
            target = match.group(1).strip('<>')
            if '://' in target or target.startswith('#'):
                continue
            target = target.split('#')[0]
            if not (path.parent/target).exists():
                errors.append('Broken document link: ' + str(path.relative_to(ROOT)) + ' -> ' + target)

    report = {
        'success': not errors,
        'indexedFiles': len(tracked),
        'indexedBytesOnDisk': sum((ROOT/p).stat().st_size for p in tracked),
        'coreDocuments': len(list((ROOT/'Doc').glob('*.md'))),
        'retainedAnalyses': len(list((ROOT/'Design/notes').glob('*.md'))),
        'indexedReportFiles': sum(p.startswith('Design/reports/') for p in tracked),
        'unityIgnoreRulesChecked': len(ignore_owners),
        'sharedLocalPackages': shared_packages,
        'ignoreExamplesChecked': len(ignored_examples) + len(source_examples),
        'errors': errors,
    }
    print(json.dumps(report, ensure_ascii=True, indent=2))
    return 0 if report['success'] else 1


if __name__ == '__main__':
    sys.exit(main())
