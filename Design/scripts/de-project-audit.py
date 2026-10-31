"""Read-only Unity Assets audit; Python 3, no Unity process or third-party packages."""
import argparse
from collections import defaultdict
import json
from pathlib import Path
import re


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--project', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    args = parser.parse_args()
    project = args.project.resolve()
    assets = project / 'Assets'
    if not assets.is_dir():
        parser.error('Project Assets directory does not exist.')
    guids = defaultdict(list)
    invalid_meta = []
    for path in assets.rglob('*.meta'):
        text = path.read_text(encoding='utf-8-sig', errors='replace')
        found = re.search(r'^guid:\s*([0-9a-f]{32})\s*$', text, re.M)
        if found:
            guids[found.group(1)].append(path.relative_to(project).as_posix())
        else:
            invalid_meta.append(path.relative_to(project).as_posix())
    duplicates = {key: value for key, value in guids.items() if len(value) > 1}
    definitions, references, invalid_json = {}, {}, []
    for path in assets.rglob('*.asmdef'):
        try:
            data = json.loads(path.read_text(encoding='utf-8-sig'))
        except (ValueError, UnicodeError) as error:
            invalid_json.append(dict(path=str(path), error=str(error)))
            continue
        definitions[path.parent] = data
        references[data['name']] = data.get('references', [])
    unowned, ownership, missing_meta = [], defaultdict(list), []
    for path in assets.rglob('*.cs'):
        cursor = path.parent
        while cursor not in definitions and cursor != assets and not list(cursor.glob('*.asmref')):
            cursor = cursor.parent
        if cursor in definitions:
            ownership[definitions[cursor]['name']].append(path.relative_to(project).as_posix())
        elif list(cursor.glob('*.asmref')):
            ownership['asmref:' + str(cursor.relative_to(project))].append(path.relative_to(project).as_posix())
        else:
            unowned.append(path.relative_to(project).as_posix())
        if not path.with_name(path.name + '.meta').exists():
            missing_meta.append(path.relative_to(project).as_posix())
    names = defaultdict(list)
    for directory, data in definitions.items():
        names[data['name']].append(str(directory.relative_to(project)))
    name_duplicates = {key: value for key, value in names.items() if len(value) > 1}
    cycles, visited = [], set()
    def visit(name, stack):
        if name in stack:
            cycles.append(stack[stack.index(name):] + [name]); return
        if name in visited:
            return
        for reference in references.get(name, []):
            if reference in references:
                visit(reference, stack + [name])
        visited.add(name)
    for name in references:
        visit(name, [])
    result = dict(project=str(project), meta_count=sum(map(len, guids.values())),
                  duplicate_guids=duplicates, invalid_meta=invalid_meta,
                  duplicate_assembly_names=name_duplicates, invalid_asmdef_json=invalid_json,
                  project_assembly_cycles=cycles, unowned_scripts=unowned,
                  scripts_missing_meta=missing_meta, assembly_script_counts={key: len(value) for key, value in ownership.items()},
                  scope='Static Assets ownership/GUID audit only; package graph, compilation and runtime are separate checks.')
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding='utf-8')
    print(json.dumps(result, ensure_ascii=False))
    raise SystemExit(1 if duplicates or invalid_meta or name_duplicates or invalid_json or cycles or unowned else 0)


if __name__ == '__main__':
    main()
