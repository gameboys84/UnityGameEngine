#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Export the real CommonMsgBox subtree, preserving local IDs, descendants, artwork and persistent events."""
from __future__ import print_function
import argparse
import collections
import hashlib
import imp
import json
import os
import re

HEADER = b'%YAML 1.1\n%TAG !u! tag:unity3d.com,2011:\n'
BLOCK = re.compile(br'(?m)^--- !u!(\d+) &(-?\d+)[^\r\n]*\r?\n')
LOCAL = re.compile(br'\{fileID:\s*(-?\d+)\}')
SOURCE = 'Assets/Resources/UINew/canvas/MsgBox_Login.prefab'
COMPONENT_GUID = '6e2d30f66d812e3408d57e8afe3be98c'
DESTINATION = 'Assets/AssetBundle/DE/Legacy/Loading/LoginFailureCommon.prefab'

def extract(data):
    matches = list(BLOCK.finditer(data)); blocks = {}; order = []
    for i, match in enumerate(matches):
        identifier = match.group(2).decode('ascii'); kind = int(match.group(1))
        blocks[identifier] = (kind, data[match.start():matches[i + 1].start() if i + 1 < len(matches) else len(data)])
        order.append(identifier)
    candidates = [identifier for identifier, (kind, block) in blocks.items() if kind == 114 and COMPONENT_GUID.encode('ascii') in block]
    if len(candidates) != 1: raise ValueError('Expected exactly one original common panel controller')
    controller = candidates[0]
    root_go = re.search(br'm_GameObject:\s*\{fileID:\s*(-?\d+)\}', blocks[controller][1]).group(1).decode('ascii')
    components = re.findall(br'component:\s*\{fileID:\s*(-?\d+)\}', blocks[root_go][1])
    roots = [identifier.decode('ascii') for identifier in components if blocks[identifier.decode('ascii')][0] in (4, 224)]
    if len(roots) != 1: raise ValueError('Expected one common panel transform')
    root_transform = roots[0]; selected = set(); pending = collections.deque([root_transform])
    while pending:
        transform = pending.popleft()
        if transform in selected: continue
        kind, body = blocks[transform]
        game_object = re.search(br'm_GameObject:\s*\{fileID:\s*(-?\d+)\}', body).group(1).decode('ascii')
        selected.add(game_object); selected.add(transform)
        for component in re.findall(br'component:\s*\{fileID:\s*(-?\d+)\}', blocks[game_object][1]): selected.add(component.decode('ascii'))
        children = re.search(br'm_Children:\s*\r?\n(.*?)\s+m_Father:', body, re.S)
        if children:
            pending.extend(value.decode('ascii') for value in re.findall(br'fileID:\s*(-?\d+)', children.group(1)))
    # Every non-external local reference must resolve within the subtree, except the detached root parent.
    dangling = []
    for identifier in selected:
        _, body = blocks[identifier]
        if identifier == root_transform:
            body = re.sub(br'm_Father:\s*\{fileID:\s*-?\d+\}', b'm_Father: {fileID: 0}', body)
            body = re.sub(br'm_RootOrder:\s*\d+', b'm_RootOrder: 0', body)
            blocks[identifier] = (blocks[identifier][0], body)
        for reference in LOCAL.findall(body):
            value = reference.decode('ascii')
            if value != '0' and value not in selected: dangling.append({'object': identifier, 'reference': value})
    if dangling: raise ValueError('Subtree has parent/sibling dependencies: ' + json.dumps(dangling))
    result = HEADER + b''.join(blocks[identifier][1] for identifier in order if identifier in selected)
    return result, {'rootGameObject': root_go, 'rootTransform': root_transform, 'controllerFileId': controller,
                    'objects': len(selected), 'gameObjects': len([v for v in selected if blocks[v][0] == 1]),
                    'persistentEvents': re.findall(br'm_MethodName:[ \t]*([^\r\n]*)', result)}

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', required=True); parser.add_argument('--project', required=True)
    parser.add_argument('--closure', required=True); parser.add_argument('--report', required=True)
    parser.add_argument('--asset-output', required=True); parser.add_argument('--builtin-ugui', required=True)
    args = parser.parse_args()
    helper = imp.load_source('legacy_ui_assets', os.path.join(os.path.dirname(os.path.abspath(__file__)), 'legacy_ui_assets.py'))
    source_path = os.path.join(args.source, SOURCE.replace('/', os.sep))
    binary, details = extract(helper.read(source_path))
    mappings = helper.ugui_map(args.builtin_ugui)
    def remap(match):
        guid = match.group(2).decode('ascii').lower()
        if guid not in helper.LEGACY_UGUI_DLLS: return match.group(0)
        identifier = match.group(1).decode('ascii')
        if identifier not in mappings: raise ValueError('Unknown legacy UGUI component ' + identifier)
        return ('{fileID: 11500000, guid: ' + mappings[identifier]['targetGuid'] + ', type: 3}').encode('ascii')
    binary = helper.PPTR.sub(remap, binary)
    with open(args.closure, 'rb') as stream: manifest = json.load(stream)
    records = dict((v['guid'], v) for v in manifest['assets'] if v['guid'])
    builtin_guids = set(v['targetGuid'] for v in mappings.values())
    root_refs = set(v.decode('ascii') for v in helper.GUID.findall(binary))
    pending = collections.deque(root_refs); selected = set(); unresolved = []
    while pending:
        guid = pending.popleft()
        if guid in selected or guid in builtin_guids or guid in helper.LEGACY_UGUI_DLLS or guid.startswith('0000000000000000'): continue
        record = records.get(guid)
        if record is None: unresolved.append(guid); continue
        selected.add(guid); pending.extend(record['dependencies'])
    if unresolved: raise ValueError('Missing exact source closure records: ' + ','.join(sorted(set(unresolved))))
    subset = dict(manifest)
    subset['roots'] = {'loginCommon': []}
    subset['rootClosures'] = {'loginCommon': sorted(records[guid]['path'] for guid in selected)}
    subset['assets'] = [records[guid] for guid in sorted(selected)]
    subset['unresolvedGuids'] = {}
    subset['componentScripts'] = [v for v in manifest['componentScripts'] if v['guid'] in selected]
    subset['targetRoot'] = args.project
    helper.dump(args.report + '.dependencies.json', subset)
    directory = os.path.dirname(os.path.abspath(args.asset_output))
    if not os.path.isdir(directory): os.makedirs(directory)
    with open(args.asset_output, 'wb') as stream: stream.write(binary)
    # Exported subtrees need their own identity; reusing the full MsgBox_Login GUID would collide later.
    guid = hashlib.md5((SOURCE + '#CommonMsgBox:' + details['rootGameObject']).encode('utf-8')).hexdigest()
    with open(args.asset_output + '.meta', 'wb') as stream:
        stream.write(('fileFormatVersion: 2\nguid: ' + guid + '\nPrefabImporter:\n  externalObjects: {}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n').encode('ascii'))
    details['persistentEvents'] = [value.decode('utf-8') for value in details['persistentEvents'] if value]
    details.update({'source': SOURCE, 'sourceSha256': helper.sha(source_path), 'output': DESTINATION,
                    'outputGuid': guid, 'outputSha256': hashlib.sha256(binary).hexdigest(), 'dependencies': len(selected),
                    'componentScripts': subset['componentScripts'], 'changes': ['Detach only subtree root parent and root order', 'Convert legacy UGUI DLL PPtrs to Unity 2022 script GUIDs', 'Assign a distinct GUID to the exported subtree asset'],
                    'boundary': 'Original account/maintenance sibling subtrees are not part of this export. All original common subtree components and events remain.'})
    helper.dump(args.report, details)
    print('Exported actual common panel: objects={0}, dependency files={1}, source scripts={2}'.format(details['objects'], len(selected), len(subset['componentScripts'])))
    for item in subset['componentScripts']: print(item['sourcePath'])

if __name__ == '__main__': main()
