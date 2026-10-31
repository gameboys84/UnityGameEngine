#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Read-only serialized-GUID audit and fail-closed DE asset import. Python 2.7/3 compatible."""
from __future__ import print_function
import argparse
import collections
import hashlib
import io
import json
import os
import re
import shutil
import struct
import sys

GUID = re.compile(br'guid:\s*([0-9a-fA-F]{32})')
OWN_GUID = re.compile(br'(?m)^guid:\s*([0-9a-fA-F]{32})')
SCRIPT = re.compile(br'm_Script:\s*\{[^}]*guid:\s*([0-9a-fA-F]{32})[^}]*\}')
PPTR = re.compile(br'\{fileID:\s*(-?\d+),\s*guid:\s*([0-9a-fA-F]{32}),\s*type:\s*3\}')
LEGACY_UGUI_DLLS = set(['f70555f144d8491a825f0804e09c671c', 'f5f67c52d1564df4a8936ccd202a3bd8'])
TEXT_EXT = set('.unity .prefab .asset .mat .anim .controller .overridecontroller .spriteatlas .mask .playable .rendertexture .lighting .shadervariants .shadergraph .vfx'.split())
DEFAULT_GROUPS = {
    'boot': ['Assets/FPS/Content/UI_Scene/Boot.unity'],
    'splash': ['Assets/Scenes/Splash.unity', 'Assets/Resources/UI/LoadingBG/LoadingScreenSplash.prefab'],
    'loading': ['Assets/Resources/UI/LoadingBG/LoadingScreenSplash.prefab'],
    'login': ['Assets/ResourcesExtra/UINew/canvas/Account_Login.prefab', 'Assets/ResourcesExtra/UINew/canvas/Account_character_Maintaince.prefab', 'Assets/Resources/UINew/canvas/MsgBox_Login.prefab'],
    'hud': ['Assets/ResourcesExtra/UINew/canvas/UICanvas.prefab', 'Assets/ResourcesExtra/UINew/canvas/UICanvasKVK.prefab', 'Assets/ResourcesExtra/UINew/canvas/PunishmentCanvas.prefab'],
    'city': ['Assets/Art/scene_main_city/main_city.unity']
}

def read(path):
    with open(path, 'rb') as stream:
        return stream.read()

def sha(path):
    digest = hashlib.sha256()
    with open(path, 'rb') as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b''):
            digest.update(chunk)
    return digest.hexdigest()

def slash(path):
    return path.replace('\\', '/')

def dump(path, data):
    directory = os.path.dirname(os.path.abspath(path))
    if not os.path.isdir(directory): os.makedirs(directory)
    with io.open(path, 'w', encoding='utf-8') as stream:
        value = json.dumps(data, ensure_ascii=False, indent=2)
        if not isinstance(value, type(u'')): value = value.decode('utf-8')
        stream.write(value)

def md4(data):
    """RFC 1320, used only for the legacy Unity MonoScript DLL local identifier."""
    try: return hashlib.new('md4', data).digest()
    except ValueError: pass
    size = len(data) * 8
    data += b'\x80' + b'\0' * ((55 - len(data)) % 64) + struct.pack('<Q', size)
    h = [0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476]
    def rotate(value, bits):
        value &= 0xffffffff
        return ((value << bits) | (value >> (32 - bits))) & 0xffffffff
    for offset in range(0, len(data), 64):
        words = struct.unpack('<16I', data[offset:offset + 64]); v = h[:]
        for round_index in range(3):
            for i in range(16):
                a = (-i) % 4; b = (a + 1) % 4; c = (a + 2) % 4; d = (a + 3) % 4
                if round_index == 0:
                    fun = (v[b] & v[c]) | (~v[b] & v[d]); k = i; shift = [3, 7, 11, 19][i % 4]; constant = 0
                elif round_index == 1:
                    fun = (v[b] & v[c]) | (v[b] & v[d]) | (v[c] & v[d]); k = (i % 4) * 4 + i // 4; shift = [3, 5, 9, 13][i % 4]; constant = 0x5a827999
                else:
                    fun = v[b] ^ v[c] ^ v[d]; k = [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15][i]; shift = [3, 9, 11, 15][i % 4]; constant = 0x6ed9eba1
                v[a] = rotate(v[a] + fun + words[k] + constant, shift)
        h = [(a + b) & 0xffffffff for a, b in zip(h, v)]
    return struct.pack('<4I', *h)

def ugui_map(directory):
    if not directory: return {}
    result = {}
    for current, dirs, files in os.walk(directory):
        for filename in files:
            if not filename.endswith('.cs') or not os.path.isfile(os.path.join(current, filename + '.meta')): continue
            path = os.path.join(current, filename); content = read(path)
            namespace = re.search(br'\bnamespace\s+([\w.]+)', content)
            if not namespace: continue
            guid = OWN_GUID.search(read(path + '.meta'))
            if not guid: continue
            for cls in re.findall(br'\bclass\s+(\w+)', content):
                identifier = struct.unpack('<i', md4(b's\0\0\0' + namespace.group(1) + cls)[:4])[0]
                result[str(identifier)] = {'targetGuid': guid.group(1).decode('ascii'), 'targetFileId': 11500000,
                    'type': (namespace.group(1) + b'.' + cls).decode('ascii'), 'targetPath': path}
    # Empirical guard against an incorrect legacy-ID implementation or unexpected UGUI source.
    for identifier, name in [('708705254', 'UnityEngine.UI.Text'), ('1573420865', 'UnityEngine.UI.Shadow'), ('1980459831', 'UnityEngine.UI.CanvasScaler')]:
        if identifier not in result or result[identifier]['type'] != name: raise ValueError('UGUI legacy identifier validation failed: ' + name)
    return result

def index(root, subdirs):
    result = {}; duplicates = []
    for name in subdirs:
        directory = os.path.join(root, name)
        if not os.path.isdir(directory): continue
        for current, dirs, files in os.walk(directory):
            # Unity does not import hidden or trailing-tilde folders (notably package Samples~).
            dirs[:] = [v for v in dirs if not v.startswith('.') and not v.endswith('~') and v != 'node_modules']
            for filename in files:
                if not filename.endswith('.meta'): continue
                absolute = os.path.join(current, filename)
                match = OWN_GUID.search(read(absolute))
                if not match: continue
                guid = match.group(1).decode('ascii').lower()
                relative = slash(os.path.relpath(absolute[:-5], root))
                if guid in result and result[guid] != relative:
                    duplicates.append({'guid': guid, 'paths': [result[guid], relative]})
                else: result[guid] = relative
    return result, duplicates

def references(absolute):
    extension = os.path.splitext(absolute)[1].lower()
    binary = read(absolute) if extension in TEXT_EXT else b''
    serialized = extension in TEXT_EXT and (binary.startswith(b'%YAML') or binary.startswith(b'---'))
    asset_guids = set(v.decode('ascii').lower() for v in GUID.findall(binary)) if serialized else set()
    scripts = set(v.decode('ascii').lower() for v in SCRIPT.findall(binary)) if serialized else set()
    meta_guids = set(v.decode('ascii').lower() for v in GUID.findall(read(absolute + '.meta'))) if os.path.isfile(absolute + '.meta') else set()
    pointers = [{'guid': guid.decode('ascii').lower(), 'fileId': file_id.decode('ascii')} for file_id, guid in PPTR.findall(binary) if guid.decode('ascii').lower() in LEGACY_UGUI_DLLS]
    return asset_guids | meta_guids, scripts, serialized, pointers

def audit(source, target, groups, builtin_ugui=None):
    source_index, duplicates = index(source, ['Assets', 'Packages', 'Library/PackageCache'])
    target_index, target_duplicates = index(target, ['Assets', 'Packages', 'Library/PackageCache'])
    reverse = dict((value, key) for key, value in source_index.items())
    visited = {}; unresolved = {}; package_refs = {}; script_users = collections.defaultdict(list); ugui = ugui_map(builtin_ugui)
    roots = {}; root_closures = {}
    for group, seeds in sorted(groups.items()):
        roots[group] = seeds
        pending = collections.deque(seeds); closure = set()
        while pending:
            relative = pending.popleft()
            if relative in closure: continue
            absolute = os.path.join(source, relative.replace('/', os.sep))
            if not os.path.isfile(absolute):
                unresolved.setdefault('missing-path:' + relative, set()).add(group)
                continue
            closure.add(relative)
            if relative not in visited:
                refs, scripts, serialized, pointers = references(absolute)
                guid = reverse.get(relative, '')
                refs.discard(guid)
                record = {'path': relative, 'guid': guid, 'bytes': os.path.getsize(absolute), 'metaBytes': os.path.getsize(absolute + '.meta') if os.path.isfile(absolute + '.meta') else 0,
                          'sha256': sha(absolute), 'dependencies': sorted(refs), 'scriptGuids': sorted(scripts), 'serializedYaml': serialized,
                          'legacyUguiPointers': pointers,
                          'targetPath': 'Assets/DE/LegacyAssets/' + relative[7:] if relative.startswith('Assets/') else None}
                visited[relative] = record
                for script in scripts: script_users[script].append(relative)
            record = visited[relative]
            for guid in record['dependencies']:
                if guid.startswith('0000000000000000'): continue
                if guid in LEGACY_UGUI_DLLS and ugui:
                    for pointer in record['legacyUguiPointers']:
                        if pointer['guid'] == guid and pointer['fileId'] not in ugui:
                            unresolved.setdefault(guid + ':' + pointer['fileId'], set()).add(relative)
                    continue
                dependency = source_index.get(guid)
                if dependency:
                    if dependency.startswith('Assets/'):
                        pending.append(dependency)
                    else:
                        package_refs[guid] = {'sourcePath': dependency, 'targetPath': target_index.get(guid)}
                elif guid in target_index:
                    package_refs[guid] = {'sourcePath': None, 'targetPath': target_index[guid]}
                else:
                    unresolved.setdefault(guid, set()).add(relative)
        root_closures[group] = sorted(closure)
    scripts = []
    for guid, users in sorted(script_users.items()):
        path = source_index.get(guid)
        absolute = os.path.join(source, path.replace('/', os.sep)) if path else None
        content = read(absolute) if absolute and os.path.isfile(absolute) and path.endswith('.cs') else b''
        scripts.append({'guid': guid, 'sourcePath': path, 'existingTargetPath': target_index.get(guid), 'users': sorted(set(users)),
                        'classes': [v.decode('utf-8', 'replace') for v in re.findall(br'\bclass\s+(\w+)', content)],
                        'usingNamespaces': [v.decode('utf-8', 'replace') for v in re.findall(br'(?m)^\s*using\s+([\w.]+)\s*;', content)],
                        'sha256': sha(absolute) if absolute and os.path.isfile(absolute) else None})
    summary = {}
    for group, closure in sorted(root_closures.items()):
        files = [visited[path] for path in closure]
        summary[group] = {'files': len(files), 'assetBytes': sum(v['bytes'] for v in files), 'metaBytes': sum(v['metaBytes'] for v in files),
                          'scriptFiles': len([v for v in files if v['path'].endswith('.cs')]),
                          'componentScriptGuids': len(set(g for v in files for g in v['scriptGuids']))}
    return {'schema': 1, 'sourceRoot': source, 'targetRoot': target, 'scope': 'Serialized GUID + importer GUID closure; runtime string loads, shader includes and C# type dependencies are NOT included.',
            'roots': roots, 'summary': summary, 'rootClosures': root_closures, 'assets': sorted(visited.values(), key=lambda v: v['path']),
            'componentScripts': scripts, 'externalPackageReferences': package_refs, 'legacyUguiMappings': ugui,
            'unresolvedGuids': dict((key, sorted(value)) for key, value in sorted(unresolved.items())),
            'duplicateSourceGuids': duplicates, 'duplicateTargetGuids': target_duplicates}

def import_assets(manifest, mappings, selected_groups):
    source = manifest['sourceRoot']; target = manifest['targetRoot']
    mapping = mappings.get('scripts', {})
    selected = set(path for group in selected_groups for path in manifest['rootClosures'][group])
    records = dict((v['path'], v) for v in manifest['assets'])
    target_index, duplicates = index(target, ['Assets', 'Packages', 'Library/PackageCache'])
    if duplicates: raise ValueError('Target has duplicate GUIDs; resolve before importing.')
    replacements = {}; blocked = []
    for item in manifest['componentScripts']:
        if not selected.intersection(item['users']) and item['sourcePath'] not in selected: continue
        guid = item['guid']
        if guid in LEGACY_UGUI_DLLS and manifest.get('legacyUguiMappings'): continue
        if guid in target_index and item['sourcePath'] and item['sourcePath'].endswith('.cs'):
            approved = mapping.get(guid)
            if not approved or approved.get('status') != 'ported-and-compiled':
                blocked.append({'guid': guid, 'script': item['sourcePath'], 'reason': 'Existing GUID alone does not prove compatible code'})
                continue
            if approved.get('sourceSha256') != item['sha256']:
                blocked.append({'guid': guid, 'reason': 'Source script changed since approval'})
            target_script = os.path.join(target, target_index[guid].replace('/', os.sep))
            if approved.get('targetSha256') != sha(target_script):
                blocked.append({'guid': guid, 'reason': 'Target component changed since offline compile approval'})
            continue
        approved = mapping.get(guid)
        if not approved or approved.get('status') != 'ported-and-compiled':
            blocked.append({'guid': guid, 'script': item['sourcePath'], 'reason': 'No validated target component mapping'})
            continue
        replacement = approved.get('targetGuid', '').lower()
        if replacement not in target_index:
            blocked.append({'guid': guid, 'reason': 'Mapped target GUID does not exist'})
            continue
        if approved.get('sourceSha256') != item['sha256']:
            blocked.append({'guid': guid, 'reason': 'Source script changed since approval'})
            continue
        target_script = os.path.join(target, target_index[replacement].replace('/', os.sep))
        if approved.get('targetSha256') != sha(target_script):
            blocked.append({'guid': guid, 'reason': 'Mapped target component changed since compilation'})
            continue
        replacements[guid] = replacement
    for key, users in manifest['unresolvedGuids'].items():
        if selected.intersection(users) or any(key == 'missing-path:' + seed for group in selected_groups for seed in manifest['roots'][group]): blocked.append({'guid': key, 'reason': 'Unresolved serialized dependency'})
    if blocked: raise ValueError('IMPORT BLOCKED: ' + json.dumps(blocked, ensure_ascii=True))
    def transformed(item, source_path):
        if not item['serializedYaml']: return None
        binary = read(source_path)
        for old, new in replacements.items(): binary = binary.replace(old.encode('ascii'), new.encode('ascii'))
        def remap(match):
            file_id, guid = match.group(1).decode('ascii'), match.group(2).decode('ascii').lower()
            if guid not in LEGACY_UGUI_DLLS: return match.group(0)
            replacement = manifest.get('legacyUguiMappings', {}).get(file_id)
            if not replacement: raise ValueError('Unknown legacy UGUI DLL reference ' + guid + ':' + file_id)
            return ('{fileID: 11500000, guid: ' + replacement['targetGuid'] + ', type: 3}').encode('ascii')
        return PPTR.sub(remap, binary)
    plan = []; reused = []
    for relative in sorted(selected):
        item = records[relative]
        if relative.endswith('.cs'): continue  # Ported runtime scripts must already exist in an explicit target assembly.
        source_path = os.path.join(source, relative.replace('/', os.sep))
        if sha(source_path) != item['sha256']: raise ValueError('Source asset changed: ' + relative)
        source_meta = source_path + '.meta'
        if not os.path.isfile(source_meta): raise ValueError('Source asset metadata missing: ' + relative)
        current_guid = OWN_GUID.search(read(source_meta))
        if not current_guid or current_guid.group(1).decode('ascii').lower() != item['guid']: raise ValueError('Source metadata GUID changed: ' + relative)
        binary = transformed(item, source_path)
        expected_hash = hashlib.sha256(binary).hexdigest() if binary is not None else item['sha256']
        if item['guid'] in target_index:
            existing = os.path.join(target, target_index[item['guid']].replace('/', os.sep))
            if not os.path.isfile(existing) or sha(existing) != expected_hash: raise ValueError('GUID content conflict: ' + relative)
            reused.append({'source': relative, 'destination': target_index[item['guid']], 'targetSha256': expected_hash})
            continue
        destination_relative = mappings.get('assetPaths', {}).get(relative, item['targetPath'].replace('/Resources/', '/SourceResources/'))
        destination = os.path.abspath(os.path.join(target, destination_relative.replace('/', os.sep)))
        allowed = [os.path.abspath(os.path.join(target, 'Assets', 'DE', 'LegacyAssets')) + os.sep,
                   os.path.abspath(os.path.join(target, 'Assets', 'AssetBundle', 'DE', 'Legacy')) + os.sep]
        if not any(destination.startswith(prefix) for prefix in allowed): raise ValueError('Unsafe destination')
        if os.path.exists(destination): raise ValueError('Destination exists with another GUID: ' + destination)
        item = dict(item); item['targetPath'] = destination_relative
        plan.append((source_path, destination, item, binary))
    # All checks precede writes. Copy original .meta; rewrite only approved GUID references in YAML.
    for source_path, destination, item, binary in plan:
        directory = os.path.dirname(destination)
        if not os.path.isdir(directory): os.makedirs(directory)
        if binary is None: shutil.copy2(source_path, destination)
        else:
            with open(destination, 'wb') as stream: stream.write(binary)
        if os.path.isfile(source_path + '.meta'): shutil.copy2(source_path + '.meta', destination + '.meta')
    return {'copied': len(plan), 'reused': reused, 'groups': selected_groups, 'componentGuidReplacements': replacements,
            'assets': [{'source': item['path'], 'destination': item['targetPath'], 'sourceSha256': item['sha256'], 'targetSha256': sha(destination)} for _, destination, item, _ in plan],
            'note': 'Import is source-preserving preparation, NOT Unity compilation, shader or functional acceptance.'}

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', required=True); parser.add_argument('--target', required=True); parser.add_argument('--report', required=True)
    parser.add_argument('--groups', default='boot,splash,login,hud,city')
    parser.add_argument('--import-assets', action='store_true'); parser.add_argument('--mappings')
    parser.add_argument('--builtin-ugui')
    args = parser.parse_args()
    groups = dict((key, DEFAULT_GROUPS[key]) for key in args.groups.split(','))
    manifest = audit(os.path.abspath(args.source), os.path.abspath(args.target), groups, args.builtin_ugui)
    dump(args.report, manifest)
    print(json.dumps(manifest['summary'], indent=2))
    print('Component scripts: {0}; unresolved GUIDs: {1}'.format(len(manifest['componentScripts']), len(manifest['unresolvedGuids'])))
    if args.import_assets:
        if not args.mappings: raise ValueError('--mappings required; no blind component copying')
        with io.open(args.mappings, encoding='utf-8') as stream: mappings = json.load(stream)
        dump(args.report + '.import.json', import_assets(manifest, mappings, list(groups)))

if __name__ == '__main__':
    try: main()
    except Exception as error:
        print(str(error), file=sys.stderr)
        sys.exit(1)
