#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Check actual loading translations against the imported source font/fallback cmap tables. No OS font fallback."""
from __future__ import print_function
import argparse
import imp
import json
import os
import re
import struct

def ushort(data, offset): return struct.unpack_from('>H', data, offset)[0]
def uint(data, offset): return struct.unpack_from('>I', data, offset)[0]

def cmap_tables(data):
    tables = {}
    for i in range(ushort(data, 4)):
        offset = 12 + i * 16
        tag = data[offset:offset + 4]
        tables[tag] = (uint(data, offset + 8), uint(data, offset + 12))
    if b'cmap' not in tables: return []
    offset = tables[b'cmap'][0]
    result = []
    for i in range(ushort(data, offset + 2)):
        entry = offset + 4 + i * 8
        platform, encoding = ushort(data, entry), ushort(data, entry + 2)
        if platform == 0 or (platform == 3 and encoding in (1, 10)):
            result.append(offset + uint(data, entry + 4))
    return result

def has_glyph(data, tables, code):
    for offset in tables:
        kind = ushort(data, offset)
        if kind == 4 and code <= 0xffff:
            n = ushort(data, offset + 6) // 2
            end = offset + 14; start = end + n * 2 + 2; delta = start + n * 2; ranges = delta + n * 2
            for i in range(n):
                last = ushort(data, end + i * 2)
                if code > last: continue
                first = ushort(data, start + i * 2)
                if code < first: break
                change = ushort(data, delta + i * 2); distance = ushort(data, ranges + i * 2)
                if distance == 0: glyph = (code + change) & 0xffff
                else:
                    address = ranges + i * 2 + distance + (code - first) * 2
                    glyph = ushort(data, address)
                    if glyph: glyph = (glyph + change) & 0xffff
                if glyph: return True
                break
        elif kind in (12, 13):
            for i in range(uint(data, offset + 12)):
                group = offset + 16 + i * 12; first, last = uint(data, group), uint(data, group + 4)
                if code < first: break
                if code <= last:
                    glyph = uint(data, group + 8) + (code - first if kind == 12 else 0)
                    if glyph: return True
                    break
    return False

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--project', required=True); parser.add_argument('--report', required=True)
    args = parser.parse_args()
    helper = imp.load_source('legacy_ui_assets', os.path.join(os.path.dirname(os.path.abspath(__file__)), 'legacy_ui_assets.py'))
    index, duplicates = helper.index(args.project, ['Assets'])
    if duplicates: raise ValueError('Imported assets have duplicate GUIDs')
    prefab_paths = ['Assets/AssetBundle/DE/Legacy/Loading/LoadingScreenSplash.prefab']
    common_path = 'Assets/AssetBundle/DE/Legacy/Loading/LoginFailureCommon.prefab'
    if os.path.isfile(os.path.join(args.project, common_path.replace('/', os.sep))): prefab_paths.append(common_path)
    body = b'\n'.join(helper.read(os.path.join(args.project, value.replace('/', os.sep))) for value in prefab_paths)
    roots = set(v.decode('ascii') for v in re.findall(br'm_Font:\s*\{[^}]*guid:\s*([0-9a-f]{32})', body))
    pending = list(roots); fonts = {}; missing_fonts = []
    while pending:
        guid = pending.pop()
        if guid in fonts: continue
        relative = index.get(guid)
        if not relative: missing_fonts.append(guid); continue
        path = os.path.join(args.project, relative.replace('/', os.sep))
        data = helper.read(path)
        fonts[guid] = (relative, data, cmap_tables(data))
        meta = helper.read(path + '.meta')
        pending.extend(v.decode('ascii') for v in re.findall(br'fileID:\s*12800000,\s*guid:\s*([0-9a-f]{32})', meta))
    keys = set(v.strip().decode('utf-8') for v in re.findall(br'stringLocKey:[ \t]*([^\r\n]*)', body) if v.strip())
    if common_path in prefab_paths:
        keys.update(['LC_COMMON_splash_hint_2_title', 'LC_OTHER_FPS_Result_Retry', 'LC_COMMON_Cancel'])
    # The current original loading prefab has one nonempty localization key, Fps_ui_text_14.
    languages = ['cn', 'zh', 'jp', 'kr', 'en']
    rows = []
    for language in languages:
        path = os.path.join(args.project, 'Assets/AssetBundle/DE/Data/Languages/' + language + '.json')
        with open(path, 'rb') as stream: entries = json.load(stream)
        missing = set(); missing_keys = []; text = []
        for key in sorted(keys):
            if key + '_Zombies' in entries: value = entries[key + '_Zombies']
            elif key in entries: value = entries[key]
            else: missing_keys.append(key); continue
            text.append({'key': key, 'value': value})
            plain = re.sub(u'<[^>]+>', u'', value)
            for char in set(plain):
                if char.isspace(): continue
                code = ord(char)
                if not any(has_glyph(data, tables, code) for _, data, tables in fonts.values()): missing.add(code)
        rows.append({'language': language, 'translations': text, 'missingKeys': missing_keys, 'missingCodepoints': ['U+%04X' % code for code in sorted(missing)]})
    result = {'scope': 'Original loading screen keys plus actual source common failure dialog title/retry/cancel keys; imported font data plus original fallback graph only. No claim about arbitrary server text or target-device rendering.',
              'prefabs': prefab_paths,
              'rootFontGuids': sorted(roots), 'fonts': [{'guid': guid, 'path': path, 'sha256': helper.sha(os.path.join(args.project, path.replace('/', os.sep)))} for guid, (path, _, __) in sorted(fonts.items())],
              'missingFontGuids': missing_fonts, 'languages': rows}
    helper.dump(args.report, result)
    for row in rows: print(row['language'] + ': missing keys=' + str(len(row['missingKeys'])) + ', missing glyphs=' + str(len(row['missingCodepoints'])))
    if missing_fonts or any(row['missingKeys'] or row['missingCodepoints'] for row in rows): return 1
    return 0

if __name__ == '__main__':
    import sys
    sys.exit(main())
