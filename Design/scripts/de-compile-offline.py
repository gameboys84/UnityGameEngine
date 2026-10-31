"""Compile actual DE source per asmdef using installed Unity references; never starts Unity.

Baseline DLLs are explicit dependency inputs, so this does not prove clean package import.
"""
import argparse
import json
from pathlib import Path
import subprocess
import xml.etree.ElementTree as ET


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--project', required=True, type=Path)
    parser.add_argument('--baseline', required=True, type=Path)
    parser.add_argument('--csc', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    parser.add_argument('--assembly', action='append', help='Compile only these assemblies and their project-source dependencies.')
    args = parser.parse_args()
    args.output.mkdir(parents=True, exist_ok=True)
    ns = {'m': 'http://schemas.microsoft.com/developer/msbuild/2003'}
    root = ET.parse(args.baseline / 'GameRuntime.csproj').getroot()
    framework = []
    for element in root.findall('.//m:Reference/m:HintPath', ns):
        path = Path(element.text)
        if not path.is_absolute():
            path = args.baseline / path
        if path.is_file() and 'ScriptAssemblies' not in path.parts and 'Assets' not in path.parts:
            framework.append(path.resolve())
    nunit = list((args.baseline / 'Library/PackageCache').glob('com.unity.ext.nunit*/net35/unity-custom/nunit.framework.dll'))[0]
    engine_tests = args.baseline / 'Library/ScriptAssemblies/UnityEngine.TestRunner.dll'
    editor_tests = args.baseline / 'Library/ScriptAssemblies/UnityEditor.TestRunner.dll'
    defs = {}
    for path in (args.project / 'Assets/DE').rglob('*.asmdef'):
        data = json.loads(path.read_text(encoding='utf-8-sig'))
        data['_dir'] = path.parent
        defs[data['name']] = data
    if args.assembly:
        selected = set()
        def include(name):
            if name in selected:
                return
            if name not in defs:
                raise ValueError('Unknown project DE assembly: ' + name)
            selected.add(name)
            for reference in defs[name].get('references', []):
                if reference in defs:
                    include(reference)
        for name in args.assembly:
            include(name)
        defs = {name: data for name, data in defs.items() if name in selected}
    results, built, pending = [], {}, set(defs)
    while pending:
        ready = sorted(name for name in pending if not any(ref in pending for ref in defs[name].get('references', [])))
        if not ready:
            raise RuntimeError('Assembly cycle: ' + repr(pending))
        for name in ready:
            data = defs[name]
            sources = []
            for path in data['_dir'].rglob('*.cs'):
                cursor = path.parent
                while cursor != data['_dir'] and not list(cursor.glob('*.asmdef')) and not list(cursor.glob('*.asmref')):
                    cursor = cursor.parent
                if cursor == data['_dir']:
                    sources.append(path)
            references = list(framework)
            if 'TestAssemblies' in data.get('optionalUnityReferences', []) and 'Newtonsoft.Json.dll' not in data.get('precompiledReferences', []):
                references = [path for path in references if path.name != 'Newtonsoft.Json.dll']
            if data.get('overrideReferences'):
                allowed = set(data.get('precompiledReferences', []))
                references = [path for path in references if '/Editor/Data/' in str(path).replace('\\', '/') or path.name in allowed]
            aliases, missing = [], []
            for reference in data.get('references', []):
                if reference in built:
                    path = built[reference]
                else:
                    actual = reference
                    path = args.baseline / 'Library/ScriptAssemblies' / (actual + '.dll')
                if path.is_file():
                    references.append(path)
                else:
                    missing.append(reference)
            if 'TestAssemblies' in data.get('optionalUnityReferences', []):
                references.extend([nunit, engine_tests, editor_tests])
            dll = args.output / (name + '.dll')
            command = ['dotnet', str(args.csc), '/nologo', '/target:library', '/langversion:9.0', '/nostdlib+',
                       '/define:UNITY_EDITOR,UNITY_EDITOR_WIN,UNITY_2022_3,UNITY_INCLUDE_TESTS', '/out:' + str(dll)]
            command += ['/reference:' + str(path) for path in dict.fromkeys(references)]
            command += list(map(str, sources))
            if missing:
                result = dict(assembly=name, sources=len(sources), success=False, missing=missing)
            else:
                response = args.output / (name + '.rsp')
                response.write_text('\n'.join('"' + value.replace('"', '\\"') + '"' for value in command[2:]), encoding='utf-8')
                run = subprocess.run(command[:2] + ['@' + str(response)], capture_output=True)
                def decode(value):
                    try:
                        return value.decode('utf-8')
                    except UnicodeDecodeError:
                        return value.decode('gb18030', errors='replace')
                result = dict(assembly=name, sources=len(sources), success=run.returncode == 0,
                              exit_code=run.returncode, output=decode(run.stdout) + decode(run.stderr), aliases=aliases)
            results.append(result)
            if result['success']:
                built[name] = dll
            pending.remove(name)
    summary = dict(scope='Offline per-assembly actual source compile against cached foundation/package dependencies; not Unity import/build/runtime validation',
                   results=results, passed=sum(result['success'] for result in results), total=len(results))
    (args.output / 'compile-results.json').write_text(json.dumps(summary, ensure_ascii=False, indent=2), encoding='utf-8')
    print(json.dumps(summary, ensure_ascii=False, indent=2))
    raise SystemExit(0 if all(result['success'] for result in results) else 1)


if __name__ == '__main__':
    main()
