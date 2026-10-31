"""Verify actual imported DE content counts, fingerprints and row counts without starting Unity."""
import argparse
import hashlib
import json
from pathlib import Path


def digest(path):
    value = hashlib.sha256()
    with path.open('rb') as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b''):
            value.update(chunk)
    return value.hexdigest()


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', required=True, type=Path)
    parser.add_argument('--project', required=True, type=Path)
    parser.add_argument('--output', required=True, type=Path)
    args = parser.parse_args()
    root = args.project / 'Assets/AssetBundle/DE/Data'
    catalog = json.loads((root / 'catalog.json').read_text(encoding='utf-8-sig'))
    errors = []
    if catalog.get('format') != 1 or catalog.get('source') != 'DeadEmpire-DEV':
        errors.append('Invalid source identity/format')
    for field, name in [('gameDataSha256', 'gameData.pack'), ('localizationSha256', 'loc.pack')]:
        path = args.source / 'Assets/StreamingAssets/GameData' / name
        if digest(path) != catalog.get(field):
            errors.append('Authoritative pack fingerprint differs: ' + name)
    total = 0
    duplicates = []
    for group, directory, expected in [('tables', 'Tables', 374), ('languages', 'Languages', 19)]:
        entries = catalog[group]
        if len(entries) != expected or len({entry['name'] for entry in entries}) != expected:
            errors.append('Wrong or duplicate entry count: ' + group)
        for entry in entries:
            name = entry['name']
            if Path(name).name != name or '/' in name or '\\' in name:
                errors.append('Invalid asset name: ' + name)
                continue
            path = root / directory / (name + '.json')
            if not path.is_file():
                errors.append('Missing asset: ' + str(path)); continue
            if digest(path) != entry['sha256']:
                errors.append('Imported asset fingerprint mismatch: ' + name)
            text = path.read_text(encoding='utf-8-sig')
            data = json.loads(text)
            raw_pairs = json.loads(text, object_pairs_hook=lambda pairs: pairs)
            if not isinstance(data, dict) or len(raw_pairs) != entry['count']:
                errors.append('Imported row/key count mismatch: ' + name)
            if isinstance(data, dict) and len(data) != len(raw_pairs):
                duplicates.append(dict(name=name, raw_property_count=len(raw_pairs), unique_key_count=len(data),
                                       duplicate_policy='Original Newtonsoft Dictionary and new JObject: last value wins'))
            if group == 'tables' and (entry.get('rawEntryCount') != len(raw_pairs) or
                                      entry.get('uniqueKeyCount') != len(data) or
                                      entry.get('duplicatePolicy') != 'last-value-wins'):
                errors.append('Missing or inconsistent explicit duplicate-key metadata: ' + name)
            total += 1
    result = dict(source=str(args.source), project=str(args.project), tables=len(catalog['tables']),
                  languages=len(catalog['languages']), assets_checked=total, duplicate_root_keys=duplicates, errors=errors,
                  scope='Original pack identities plus per-import JSON hash/key count. Not a second independent AES decoder, framework resource-load test, localization runtime test or live-server acceptance.')
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding='utf-8')
    print(json.dumps(result, ensure_ascii=False, indent=2))
    raise SystemExit(1 if errors else 0)


if __name__ == '__main__':
    main()
