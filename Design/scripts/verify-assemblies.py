"""Check explicit project assembly ownership and shared logic boundaries."""
from pathlib import Path
import json,re,sys

ROOT=Path(__file__).resolve().parents[2]
PROJECT=ROOT/'UnityProject1'
SHARED=ROOT.parent/'TEngineNi_UPM'

def main():
    errors=[];definitions={};locations={}
    roots=[PROJECT/'Assets',SHARED/'com.ni.tengine',SHARED/'com.ni.gamecore']
    for root in roots:
        for path in root.rglob('*.asmdef'):
            data=json.loads(path.read_text(encoding='utf-8-sig'))
            name=data['name']
            if name in definitions:errors.append('Duplicate assembly: '+name)
            definitions[name]=data;locations[path.parent.resolve()]=name
    for path in (PROJECT/'Assets').rglob('*.asmref'):
        ref=json.loads(path.read_text(encoding='utf-8-sig'))['reference']
        if ref.startswith('GUID:'):
            matches=[]
            for folder,name in locations.items():
                for definition in folder.glob('*.asmdef'):
                    meta=Path(str(definition)+'.meta')
                    if meta.exists() and ('guid: '+ref[5:]) in meta.read_text(encoding='utf-8-sig'):matches.append(name)
            if len(matches)!=1:errors.append('Unresolved assembly reference: '+str(path));continue
            ref=matches[0]
        if ref not in definitions:errors.append('Unknown assembly reference: '+ref)
        locations[path.parent.resolve()]=ref
    owners={}
    for path in (PROJECT/'Assets').rglob('*.cs'):
        owner=next((locations[p] for p in path.parents if p in locations),None)
        rel=path.relative_to(PROJECT).as_posix()
        if owner is None:errors.append('Default assembly source: '+rel);continue
        owners[owner]=owners.get(owner,0)+1
        if '/Editor/' in rel and definitions[owner].get('includePlatforms')!=['Editor']:
            errors.append('Editor source in runtime assembly: '+rel)
    visiting=set();done=set()
    def visit(name):
        if name in visiting:errors.append('Assembly dependency cycle: '+name);return
        if name in done:return
        visiting.add(name)
        for dep in definitions[name].get('references',[]):
            if dep in definitions:visit(dep)
        visiting.remove(name);done.add(name)
    for name in definitions:visit(name)
    for name in ['Ni.GameCore.Logic','GameRuntime.LogicTests']:
        data=definitions.get(name,{})
        if not data.get('noEngineReferences'):errors.append('Logic assembly must exclude engine references: '+name)
    if definitions.get('Ni.GameCore.Logic',{}).get('references'):errors.append('Shared logic must not depend on project assemblies')
    if definitions.get('GameRuntime.LogicTests',{}).get('references')!=['Ni.GameCore.Logic']:
        errors.append('Business test model must depend only on shared logic')
    for p in (SHARED/'com.ni.gamecore/Runtime/Logic').rglob('*.cs'):
        if re.search(r'\b(UnityEngine|UnityEditor|GameRuntime|TEngine)\b',p.read_text(encoding='utf-8-sig')):
            errors.append('Shared logic has an engine or business dependency: '+str(p))
    print(json.dumps({'success':not errors,'assemblies':len(definitions),'sourceOwners':owners,'errors':errors},indent=2))
    return bool(errors)

if __name__=='__main__':sys.exit(main())
