using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class RealPos : NetworkMessage {
        public static int[] Id = { 1,1 };
        public static Ctrl VC;
        public Int32 m_x;
        public Int32 m_y;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            sp.EnEnd();
        }
        public void CopyFrom(RealPos source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class ServerInfo : NetworkMessage {
        public static int[] Id = { 7,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_stat;
        public Int64 m_open_time;
        public Int16 m_population;
        public TilePos m_min;
        public TilePos m_max;
        public SByte m_flag;
        public SByte m_map_stat;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_stat = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_population = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                m_min = new TilePos();
                m_min.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_max = new TilePos();
                m_max.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_flag = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_map_stat = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_stat);}
            if (sp.TryWrite(2)) {sp.Write(m_open_time);}
            if (sp.TryWrite(3)) {sp.Write(m_population);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_min.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_max.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_flag);}
            if (sp.TryWrite(7)) {sp.Write(m_map_stat);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerInfo source) {
            m_id = source.m_id;
            m_stat = source.m_stat;
            m_open_time = source.m_open_time;
            m_population = source.m_population;
            m_min = source.m_min;
            m_max = source.m_max;
            m_flag = source.m_flag;
            m_map_stat = source.m_map_stat;
        }
    }
    
    [Serializable]
    public partial class BuildingUpgradeInfo : NetworkMessage {
        public static int[] Id = { 13,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Boolean m_instant;
        public Boolean m_use_instant_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_instant = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_use_instant_item = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_instant);}
            if (sp.TryWrite(2)) {sp.Write(m_use_instant_item);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingUpgradeInfo source) {
            m_id = source.m_id;
            m_instant = source.m_instant;
            m_use_instant_item = source.m_use_instant_item;
        }
    }
    
    [Serializable]
    public partial class BuildingNtfInfo : NetworkMessage {
        public static int[] Id = { 19,1 };
        public static Ctrl VC;
        public List<BuildingProgInfo> m_progs = new List<BuildingProgInfo>();
        public List<BuildingInfo> m_buildings = new List<BuildingInfo>();
        public List<BuildingWaitInfo> m_waitings = new List<BuildingWaitInfo>();
        public List<Int64> m_queue_start_time = new List<Int64>();
        public List<Int64> m_queue_end_time = new List<Int64>();
        public Int16 m_queue_cnt;
        public SByte m_chest_cnt;
        public List<Int16> m_force_unlock_building_types = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuildingProgInfo tmp = new BuildingProgInfo();
                    tmp.Decode(sp);
                    m_progs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buildings.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuildingInfo tmp = new BuildingInfo();
                    tmp.Decode(sp);
                    m_buildings.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_waitings.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuildingWaitInfo tmp = new BuildingWaitInfo();
                    tmp.Decode(sp);
                    m_waitings.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_queue_start_time.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_queue_start_time.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_queue_end_time.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_queue_end_time.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {m_queue_cnt = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_chest_cnt = sp.ReadSByte();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_force_unlock_building_types.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_force_unlock_building_types.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_progs.Count);
                for (int i = 0; i != m_progs.Count; ++i) {
                    m_progs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buildings.Count);
                for (int i = 0; i != m_buildings.Count; ++i) {
                    m_buildings[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_waitings.Count);
                for (int i = 0; i != m_waitings.Count; ++i) {
                    m_waitings[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_queue_start_time.Count);
                for (int i = 0; i != m_queue_start_time.Count; ++i) {
                    sp.Write(m_queue_start_time[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_queue_end_time.Count);
                for (int i = 0; i != m_queue_end_time.Count; ++i) {
                    sp.Write(m_queue_end_time[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {sp.Write(m_queue_cnt);}
            if (sp.TryWrite(6)) {sp.Write(m_chest_cnt);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_force_unlock_building_types.Count);
                for (int i = 0; i != m_force_unlock_building_types.Count; ++i) {
                    sp.Write(m_force_unlock_building_types[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BuildingNtfInfo source) {
            m_progs = source.m_progs;
            m_buildings = source.m_buildings;
            m_waitings = source.m_waitings;
            m_queue_start_time = source.m_queue_start_time;
            m_queue_end_time = source.m_queue_end_time;
            m_queue_cnt = source.m_queue_cnt;
            m_chest_cnt = source.m_chest_cnt;
            m_force_unlock_building_types = source.m_force_unlock_building_types;
        }
    }
    
    [Serializable]
    public partial class TroopTrainCancelInfo : NetworkMessage {
        public static int[] Id = { 25,1 };
        public static Ctrl VC;
        public Int32 m_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopTrainCancelInfo source) {
            m_index = source.m_index;
        }
    }
    
    [Serializable]
    public partial class FightStatistic : NetworkMessage {
        public static int[] Id = { 31,1 };
        public static Ctrl VC;
        public Int64 m_power_lost;
        public Int64 m_troop_cnt;
        public Int64 m_troop_lost_cnt;
        public Int64 m_troop_repair_cnt;
        public Int64 m_trap_cnt;
        public Int64 m_trap_lost_cnt;
        public Int16 m_loseatk_cnt;
        public Int16 m_reduatk_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_power_lost = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_troop_cnt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_troop_lost_cnt = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_troop_repair_cnt = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_trap_cnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_trap_lost_cnt = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_loseatk_cnt = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_reduatk_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_power_lost);}
            if (sp.TryWrite(1)) {sp.Write(m_troop_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_troop_lost_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_troop_repair_cnt);}
            if (sp.TryWrite(4)) {sp.Write(m_trap_cnt);}
            if (sp.TryWrite(5)) {sp.Write(m_trap_lost_cnt);}
            if (sp.TryWrite(6)) {sp.Write(m_loseatk_cnt);}
            if (sp.TryWrite(7)) {sp.Write(m_reduatk_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FightStatistic source) {
            m_power_lost = source.m_power_lost;
            m_troop_cnt = source.m_troop_cnt;
            m_troop_lost_cnt = source.m_troop_lost_cnt;
            m_troop_repair_cnt = source.m_troop_repair_cnt;
            m_trap_cnt = source.m_trap_cnt;
            m_trap_lost_cnt = source.m_trap_lost_cnt;
            m_loseatk_cnt = source.m_loseatk_cnt;
            m_reduatk_cnt = source.m_reduatk_cnt;
        }
    }
    
    [Serializable]
    public partial class FightAgentInfo : NetworkMessage {
        public static int[] Id = { 37,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_character_id;
        public Int32 m_star;
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_character_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_star = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_character_id);}
            if (sp.TryWrite(2)) {sp.Write(m_star);}
            if (sp.TryWrite(3)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(FightAgentInfo source) {
            m_id = source.m_id;
            m_character_id = source.m_character_id;
            m_star = source.m_star;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class FightReportGve : NetworkMessage {
        public static int[] Id = { 43,1 };
        public static Ctrl VC;
        public Int32 m_fight_id;
        public Int64 m_fight_time;
        public Int16 m_fight_type;
        public TilePos m_pos;
        public Int16 m_result;
        public List<CaptiveInfo> m_captive = new List<CaptiveInfo>();
        public List<FightWave> m_waves = new List<FightWave>();
        public TroopStatistic m_atker_stat;
        public TroopStatistic m_defer_stat;
        public Int16 m_rebel_level;
        public SByte m_rebel_stat;
        public Int16 m_cfg_id;
        public Int64 m_hp_killed;
        public Int64 m_cur_hp;
        public Int64 m_hp_max;
        public Int16 m_start_wave;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fight_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_fight_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_fight_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_result = sp.ReadInt16();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_captive.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptiveInfo tmp = new CaptiveInfo();
                    tmp.Decode(sp);
                    m_captive.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_waves.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightWave tmp = new FightWave();
                    tmp.Decode(sp);
                    m_waves.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                m_atker_stat = new TroopStatistic();
                m_atker_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                m_defer_stat = new TroopStatistic();
                m_defer_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_rebel_level = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_rebel_stat = sp.ReadSByte();}
            if (sp.TryRead(11)) {m_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_hp_killed = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_cur_hp = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_hp_max = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_start_wave = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fight_id);}
            if (sp.TryWrite(1)) {sp.Write(m_fight_time);}
            if (sp.TryWrite(2)) {sp.Write(m_fight_type);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_result);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_captive.Count);
                for (int i = 0; i != m_captive.Count; ++i) {
                    m_captive[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_waves.Count);
                for (int i = 0; i != m_waves.Count; ++i) {
                    m_waves[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_atker_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_defer_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {sp.Write(m_rebel_level);}
            if (sp.TryWrite(10)) {sp.Write(m_rebel_stat);}
            if (sp.TryWrite(11)) {sp.Write(m_cfg_id);}
            if (sp.TryWrite(12)) {sp.Write(m_hp_killed);}
            if (sp.TryWrite(13)) {sp.Write(m_cur_hp);}
            if (sp.TryWrite(14)) {sp.Write(m_hp_max);}
            if (sp.TryWrite(15)) {sp.Write(m_start_wave);}
            sp.EnEnd();
        }
        public void CopyFrom(FightReportGve source) {
            m_fight_id = source.m_fight_id;
            m_fight_time = source.m_fight_time;
            m_fight_type = source.m_fight_type;
            m_pos = source.m_pos;
            m_result = source.m_result;
            m_captive = source.m_captive;
            m_waves = source.m_waves;
            m_atker_stat = source.m_atker_stat;
            m_defer_stat = source.m_defer_stat;
            m_rebel_level = source.m_rebel_level;
            m_rebel_stat = source.m_rebel_stat;
            m_cfg_id = source.m_cfg_id;
            m_hp_killed = source.m_hp_killed;
            m_cur_hp = source.m_cur_hp;
            m_hp_max = source.m_hp_max;
            m_start_wave = source.m_start_wave;
        }
    }
    
    [Serializable]
    public partial class EffectAction : NetworkMessage {
        public static int[] Id = { 49,1 };
        public static Ctrl VC;
        public Int16 m_apply_type;
        public Boolean m_is_p1;
        public Int16 m_effect;
        public Int16 m_circle;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_apply_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_effect = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_circle = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_apply_type);}
            if (sp.TryWrite(1)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(2)) {sp.Write(m_effect);}
            if (sp.TryWrite(3)) {sp.Write(m_circle);}
            sp.EnEnd();
        }
        public void CopyFrom(EffectAction source) {
            m_apply_type = source.m_apply_type;
            m_is_p1 = source.m_is_p1;
            m_effect = source.m_effect;
            m_circle = source.m_circle;
        }
    }
    
    [Serializable]
    public partial class CityTile : NetworkMessage {
        public static int[] Id = { 55,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_level;
        public Int64 m_owner;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public FieldCaptivesInfo m_captives;
        public Int16 m_city_status;
        public Int64 m_fighting;
        public List<Int16> m_fighting_army = new List<Int16>();
        public Int16 m_fighting_type;
        public Int32 m_title_id;
        public Int16 m_home_server_id;
        public Int16 m_flag;
        public Int32 m_model;
        public AllianceSnapInfo m_landalliance;
        public Int16 m_faction;
        public Int16 m_city_skin;
        public Int64 m_fireworks_endtime;
        public Int64 m_mayor;
        public Int16 m_city_nameplate;
        public Int32 m_fireworks_id;
        public Int64 m_cage_end;
        public Int64 m_shame_source;
        public String m_shame_source_name = "";
        public List<Int32> m_aura_ids = new List<Int32>();
        public Int16 m_city_decoration_pendant;
        public Int16 m_city_decoration_hole;
        public List<SByte> m_city_skin_parts = new List<SByte>();
        public Int16 m_city_decoration_counterattack;
        public Int16 m_base_teleport_effect_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_name = sp.ReadString();}
            if (sp.TryRead(6)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                m_captives = new FieldCaptivesInfo();
                m_captives.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_city_status = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fighting_army.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_fighting_army.Add(tmp);
                }
            }
            if (sp.TryRead(11)) {m_fighting_type = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_title_id = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_flag = sp.ReadInt16();}
            if (sp.TryRead(15)) {m_model = sp.ReadInt32();}
            if (sp.TryRead(16)) {
                m_landalliance = new AllianceSnapInfo();
                m_landalliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_faction = sp.ReadInt16();}
            if (sp.TryRead(18)) {m_city_skin = sp.ReadInt16();}
            if (sp.TryRead(19)) {m_fireworks_endtime = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_mayor = sp.ReadInt64();}
            if (sp.TryRead(21)) {m_city_nameplate = sp.ReadInt16();}
            if (sp.TryRead(22)) {m_fireworks_id = sp.ReadInt32();}
            if (sp.TryRead(23)) {m_cage_end = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_shame_source = sp.ReadInt64();}
            if (sp.TryRead(25)) {m_shame_source_name = sp.ReadString();}
            if (sp.TryRead(26)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            if (sp.TryRead(27)) {m_city_decoration_pendant = sp.ReadInt16();}
            if (sp.TryRead(28)) {m_city_decoration_hole = sp.ReadInt16();}
            if (sp.TryRead(29)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_skin_parts.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_city_skin_parts.Add(tmp);
                }
            }
            if (sp.TryRead(30)) {m_city_decoration_counterattack = sp.ReadInt16();}
            if (sp.TryRead(31)) {m_base_teleport_effect_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_owner);}
            if (sp.TryWrite(5)) {sp.Write(m_name);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_captives.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_city_status);}
            if (sp.TryWrite(9)) {sp.Write(m_fighting);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fighting_army.Count);
                for (int i = 0; i != m_fighting_army.Count; ++i) {
                    sp.Write(m_fighting_army[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(11)) {sp.Write(m_fighting_type);}
            if (sp.TryWrite(12)) {sp.Write(m_title_id);}
            if (sp.TryWrite(13)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(14)) {sp.Write(m_flag);}
            if (sp.TryWrite(15)) {sp.Write(m_model);}
            if (sp.TryWrite(16)) {int pos = sp.GetPos();sp.Skip(2); m_landalliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(17)) {sp.Write(m_faction);}
            if (sp.TryWrite(18)) {sp.Write(m_city_skin);}
            if (sp.TryWrite(19)) {sp.Write(m_fireworks_endtime);}
            if (sp.TryWrite(20)) {sp.Write(m_mayor);}
            if (sp.TryWrite(21)) {sp.Write(m_city_nameplate);}
            if (sp.TryWrite(22)) {sp.Write(m_fireworks_id);}
            if (sp.TryWrite(23)) {sp.Write(m_cage_end);}
            if (sp.TryWrite(24)) {sp.Write(m_shame_source);}
            if (sp.TryWrite(25)) {sp.Write(m_shame_source_name);}
            if (sp.TryWrite(26)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(27)) {sp.Write(m_city_decoration_pendant);}
            if (sp.TryWrite(28)) {sp.Write(m_city_decoration_hole);}
            if (sp.TryWrite(29)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_skin_parts.Count);
                for (int i = 0; i != m_city_skin_parts.Count; ++i) {
                    sp.Write(m_city_skin_parts[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(30)) {sp.Write(m_city_decoration_counterattack);}
            if (sp.TryWrite(31)) {sp.Write(m_base_teleport_effect_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CityTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_level = source.m_level;
            m_owner = source.m_owner;
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_captives = source.m_captives;
            m_city_status = source.m_city_status;
            m_fighting = source.m_fighting;
            m_fighting_army = source.m_fighting_army;
            m_fighting_type = source.m_fighting_type;
            m_title_id = source.m_title_id;
            m_home_server_id = source.m_home_server_id;
            m_flag = source.m_flag;
            m_model = source.m_model;
            m_landalliance = source.m_landalliance;
            m_faction = source.m_faction;
            m_city_skin = source.m_city_skin;
            m_fireworks_endtime = source.m_fireworks_endtime;
            m_mayor = source.m_mayor;
            m_city_nameplate = source.m_city_nameplate;
            m_fireworks_id = source.m_fireworks_id;
            m_cage_end = source.m_cage_end;
            m_shame_source = source.m_shame_source;
            m_shame_source_name = source.m_shame_source_name;
            m_aura_ids = source.m_aura_ids;
            m_city_decoration_pendant = source.m_city_decoration_pendant;
            m_city_decoration_hole = source.m_city_decoration_hole;
            m_city_skin_parts = source.m_city_skin_parts;
            m_city_decoration_counterattack = source.m_city_decoration_counterattack;
            m_base_teleport_effect_id = source.m_base_teleport_effect_id;
        }
    }
    
    [Serializable]
    public partial class LandTileInfo : NetworkMessage {
        public static int[] Id = { 61,1 };
        public static Ctrl VC;
        public Boolean m_is_active;
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_active = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_active);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LandTileInfo source) {
            m_is_active = source.m_is_active;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class AllianceSnapInfo : NetworkMessage {
        public static int[] Id = { 67,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_color;
        public Int16 m_logo;
        public Int16 m_glory;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_glory = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_color);}
            if (sp.TryWrite(4)) {sp.Write(m_logo);}
            if (sp.TryWrite(5)) {sp.Write(m_glory);}
            if (sp.TryWrite(6)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSnapInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_glory = source.m_glory;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class CreateAllianceInfo : NetworkMessage {
        public static int[] Id = { 73,1 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_logo;
        public Int16 m_color;
        public String m_lang = "";
        public String m_desc = "";
        public String m_headline = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_lang = sp.ReadString();}
            if (sp.TryRead(5)) {m_desc = sp.ReadString();}
            if (sp.TryRead(6)) {m_headline = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_logo);}
            if (sp.TryWrite(3)) {sp.Write(m_color);}
            if (sp.TryWrite(4)) {sp.Write(m_lang);}
            if (sp.TryWrite(5)) {sp.Write(m_desc);}
            if (sp.TryWrite(6)) {sp.Write(m_headline);}
            sp.EnEnd();
        }
        public void CopyFrom(CreateAllianceInfo source) {
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_logo = source.m_logo;
            m_color = source.m_color;
            m_lang = source.m_lang;
            m_desc = source.m_desc;
            m_headline = source.m_headline;
        }
    }
    
    [Serializable]
    public partial class ReplayInfo : NetworkMessage {
        public static int[] Id = { 79,1 };
        public static Ctrl VC;
        public Int64 m_replay_id;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_replay_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_replay_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ReplayInfo source) {
            m_replay_id = source.m_replay_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class ContactInfo : NetworkMessage {
        public static int[] Id = { 85,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_alliance_name = "";
        public Int32 m_alliance_rank;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int32 m_user_icon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_user_icon = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_name);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_user_id);}
            if (sp.TryWrite(4)) {sp.Write(m_user_name);}
            if (sp.TryWrite(5)) {sp.Write(m_user_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(ContactInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_alliance_name = source.m_alliance_name;
            m_alliance_rank = source.m_alliance_rank;
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
        }
    }
    
    [Serializable]
    public partial class RecvResReportBaseInfo : NetworkMessage {
        public static int[] Id = { 91,1 };
        public static Ctrl VC;
        public String m_alliance_name = "";
        public String m_user_name = "";
        public Int64 m_send_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_send_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_name);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_send_time);}
            sp.EnEnd();
        }
        public void CopyFrom(RecvResReportBaseInfo source) {
            m_alliance_name = source.m_alliance_name;
            m_user_name = source.m_user_name;
            m_send_time = source.m_send_time;
        }
    }
    
    [Serializable]
    public partial class SystemReportBaseInfo : NetworkMessage {
        public static int[] Id = { 97,1 };
        public static Ctrl VC;
        public String m_user_name = "";
        public String m_alliance_abbr = "";
        public String m_alliance_name = "";
        public Boolean m_left_or_join;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_left_or_join = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_name);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_name);}
            if (sp.TryWrite(3)) {sp.Write(m_left_or_join);}
            sp.EnEnd();
        }
        public void CopyFrom(SystemReportBaseInfo source) {
            m_user_name = source.m_user_name;
            m_alliance_abbr = source.m_alliance_abbr;
            m_alliance_name = source.m_alliance_name;
            m_left_or_join = source.m_left_or_join;
        }
    }
    
    [Serializable]
    public partial class RebelRewardReportDetailInfo : NetworkMessage {
        public static int[] Id = { 103,1 };
        public static Ctrl VC;
        public RebelRewardReportBaseInfo m_base_info;
        public List<Item> m_items = new List<Item>();
        public Int64 m_hp_max;
        public Int64 m_hp_killed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelRewardReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_hp_max = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_hp_killed = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_hp_max);}
            if (sp.TryWrite(3)) {sp.Write(m_hp_killed);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelRewardReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
            m_hp_max = source.m_hp_max;
            m_hp_killed = source.m_hp_killed;
        }
    }
    
    [Serializable]
    public partial class ResApplyReportDetailInfo : NetworkMessage {
        public static int[] Id = { 109,1 };
        public static Ctrl VC;
        public Int64 m_apply_time;
        public ResApplyReportBaseInfo m_base_info;
        public List<FightResInfo> m_res_info = new List<FightResInfo>();
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_apply_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_base_info = new ResApplyReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightResInfo tmp = new FightResInfo();
                    tmp.Decode(sp);
                    m_res_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_apply_time);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_info.Count);
                for (int i = 0; i != m_res_info.Count; ++i) {
                    m_res_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(ResApplyReportDetailInfo source) {
            m_apply_time = source.m_apply_time;
            m_base_info = source.m_base_info;
            m_res_info = source.m_res_info;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class RebelScoutReportBaseInfo : NetworkMessage {
        public static int[] Id = { 115,1 };
        public static Ctrl VC;
        public ServerTilePos m_pos;
        public Int64 m_id;
        public Int16 m_level;
        public Boolean m_result;
        public SByte m_stat;
        public Int16 m_cfg_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_result = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_cfg_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_result);}
            if (sp.TryWrite(4)) {sp.Write(m_stat);}
            if (sp.TryWrite(5)) {sp.Write(m_cfg_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelScoutReportBaseInfo source) {
            m_pos = source.m_pos;
            m_id = source.m_id;
            m_level = source.m_level;
            m_result = source.m_result;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
        }
    }
    
    [Serializable]
    public partial class RecvGiftReportDetailInfo : NetworkMessage {
        public static int[] Id = { 121,1 };
        public static Ctrl VC;
        public RecvGiftReportBaseInfo m_base_info;
        public Int32 m_gift;
        public Int16 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RecvGiftReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_gift = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_gift);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(RecvGiftReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_gift = source.m_gift;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class OccupyReportDetailInfo : NetworkMessage {
        public static int[] Id = { 127,1 };
        public static Ctrl VC;
        public OccupyReportBaseInfo m_base_info;
        public String m_user_name = "";
        public UserAllianceBrief m_alliance;
        public TroopGroup m_group;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new OccupyReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_group = new TroopGroup();
                m_group.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_group.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(OccupyReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_user_name = source.m_user_name;
            m_alliance = source.m_alliance;
            m_group = source.m_group;
        }
    }
    
    [Serializable]
    public partial class GetResearchListReqInfo : NetworkMessage {
        public static int[] Id = { 133,1 };
        public static Ctrl VC;
        public Int16 m_start_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_type);}
            sp.EnEnd();
        }
        public void CopyFrom(GetResearchListReqInfo source) {
            m_start_type = source.m_start_type;
        }
    }
    
    [Serializable]
    public partial class ResearchProgInfo : NetworkMessage {
        public static int[] Id = { 139,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Boolean m_joined_as;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_joined_as = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(3)) {sp.Write(m_joined_as);}
            if (sp.TryWrite(4)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(ResearchProgInfo source) {
            m_type = source.m_type;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_joined_as = source.m_joined_as;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class GetDailyQuestListReqInfo : NetworkMessage {
        public static int[] Id = { 145,1 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(GetDailyQuestListReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class QuestBasicInfo : NetworkMessage {
        public static int[] Id = { 151,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_status = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestBasicInfo source) {
            m_id = source.m_id;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class QuestGetRewardAckInfo : NetworkMessage {
        public static int[] Id = { 157,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_result;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_result = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestGetRewardAckInfo source) {
            m_id = source.m_id;
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class ScoutTroopGroup : NetworkMessage {
        public static int[] Id = { 163,1 };
        public static Ctrl VC;
        public BeAtkHero m_hero;
        public Int64 m_owner;
        public String m_owner_name = "";
        public UserAllianceBrief m_alliance;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public List<DetailStyle> m_explain_style = new List<DetailStyle>();
        public StyleInfo m_atk_style;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_hero = new BeAtkHero();
                m_hero.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(3)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_explain_style.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DetailStyle tmp = new DetailStyle();
                    tmp.Decode(sp);
                    m_explain_style.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                m_atk_style = new StyleInfo();
                m_atk_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_hero.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_owner);}
            if (sp.TryWrite(2)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_explain_style.Count);
                for (int i = 0; i != m_explain_style.Count; ++i) {
                    m_explain_style[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_atk_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ScoutTroopGroup source) {
            m_hero = source.m_hero;
            m_owner = source.m_owner;
            m_owner_name = source.m_owner_name;
            m_alliance = source.m_alliance;
            m_troops = source.m_troops;
            m_explain_style = source.m_explain_style;
            m_atk_style = source.m_atk_style;
        }
    }
    
    [Serializable]
    public partial class RenameReqInfo : NetworkMessage {
        public static int[] Id = { 169,1 };
        public static Ctrl VC;
        public String m_new_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_name);}
            sp.EnEnd();
        }
        public void CopyFrom(RenameReqInfo source) {
            m_new_name = source.m_new_name;
        }
    }
    
    [Serializable]
    public partial class MarchRecallInfo : NetworkMessage {
        public static int[] Id = { 175,1 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MarchRecallInfo source) {
            m_march_id = source.m_march_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class CenterCmdReq : NetworkMessage {
        public static int[] Id = { 181,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_cmd = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cmd = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cmd);}
            sp.EnEnd();
        }
        public void CopyFrom(CenterCmdReq source) {
            m_user_id = source.m_user_id;
            m_cmd = source.m_cmd;
        }
    }
    
    [Serializable]
    public partial class AllianceUpdateHelpNtf : NetworkMessage {
        public static int[] Id = { 187,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_help_id;
        public Int16 m_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_help_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_times = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_help_id);}
            if (sp.TryWrite(2)) {sp.Write(m_times);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceUpdateHelpNtf source) {
            m_user_id = source.m_user_id;
            m_help_id = source.m_help_id;
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class AllianceRanklistInfo : NetworkMessage {
        public static int[] Id = { 193,1 };
        public static Ctrl VC;
        public List<Ranklist> m_ranks = new List<Ranklist>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ranks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Ranklist tmp = new Ranklist();
                    tmp.Decode(sp);
                    m_ranks.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ranks.Count);
                for (int i = 0; i != m_ranks.Count; ++i) {
                    m_ranks[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRanklistInfo source) {
            m_ranks = source.m_ranks;
        }
    }
    
    [Serializable]
    public partial class CreditInfo : NetworkMessage {
        public static int[] Id = { 199,1 };
        public static Ctrl VC;
        public Int64 m_credit;
        public Int64 m_max_credit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_credit = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_max_credit = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_credit);}
            if (sp.TryWrite(1)) {sp.Write(m_max_credit);}
            sp.EnEnd();
        }
        public void CopyFrom(CreditInfo source) {
            m_credit = source.m_credit;
            m_max_credit = source.m_max_credit;
        }
    }
    
    [Serializable]
    public partial class BeAtkInfo : NetworkMessage {
        public static int[] Id = { 205,1 };
        public static Ctrl VC;
        public Int16 m_radar_levle;
        public Int16 m_march_type;
        public SByte m_march_owner_type;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_atk_user_id;
        public String m_atk_user_name = "";
        public UserAllianceBrief m_atk_user_alliance;
        public TilePos m_atk_pos;
        public Int16 m_atk_icon;
        public String m_atk_avatar = "";
        public Int16 m_atk_avatar_frame;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public BeAtkHero m_hero;
        public List<BuffNtfInfo> m_item_buff = new List<BuffNtfInfo>();
        public MapUnitId m_unit_id;
        public Int64 m_atk_march_id;
        public String m_npc_icon = "";
        public String m_npc_name = "";
        public Int64 m_target_user_id;
        public String m_target_user_name = "";
        public Int16 m_target_icon;
        public String m_target_avatar = "";
        public Int16 m_target_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_radar_levle = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_march_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_march_owner_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_atk_user_id = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_atk_user_name = sp.ReadString();}
            if (sp.TryRead(7)) {
                m_atk_user_alliance = new UserAllianceBrief();
                m_atk_user_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_atk_icon = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_atk_avatar = sp.ReadString();}
            if (sp.TryRead(11)) {m_atk_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
                m_hero = new BeAtkHero();
                m_hero.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_buff.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_item_buff.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                m_unit_id = new MapUnitId();
                m_unit_id.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_atk_march_id = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_npc_icon = sp.ReadString();}
            if (sp.TryRead(18)) {m_npc_name = sp.ReadString();}
            if (sp.TryRead(19)) {m_target_user_id = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_target_user_name = sp.ReadString();}
            if (sp.TryRead(21)) {m_target_icon = sp.ReadInt16();}
            if (sp.TryRead(22)) {m_target_avatar = sp.ReadString();}
            if (sp.TryRead(23)) {m_target_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_radar_levle);}
            if (sp.TryWrite(1)) {sp.Write(m_march_type);}
            if (sp.TryWrite(2)) {sp.Write(m_march_owner_type);}
            if (sp.TryWrite(3)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(4)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(5)) {sp.Write(m_atk_user_id);}
            if (sp.TryWrite(6)) {sp.Write(m_atk_user_name);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_atk_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {sp.Write(m_atk_icon);}
            if (sp.TryWrite(10)) {sp.Write(m_atk_avatar);}
            if (sp.TryWrite(11)) {sp.Write(m_atk_avatar_frame);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {int pos = sp.GetPos();sp.Skip(2); m_hero.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_buff.Count);
                for (int i = 0; i != m_item_buff.Count; ++i) {
                    m_item_buff[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {int pos = sp.GetPos();sp.Skip(2); m_unit_id.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(16)) {sp.Write(m_atk_march_id);}
            if (sp.TryWrite(17)) {sp.Write(m_npc_icon);}
            if (sp.TryWrite(18)) {sp.Write(m_npc_name);}
            if (sp.TryWrite(19)) {sp.Write(m_target_user_id);}
            if (sp.TryWrite(20)) {sp.Write(m_target_user_name);}
            if (sp.TryWrite(21)) {sp.Write(m_target_icon);}
            if (sp.TryWrite(22)) {sp.Write(m_target_avatar);}
            if (sp.TryWrite(23)) {sp.Write(m_target_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(BeAtkInfo source) {
            m_radar_levle = source.m_radar_levle;
            m_march_type = source.m_march_type;
            m_march_owner_type = source.m_march_owner_type;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_atk_user_id = source.m_atk_user_id;
            m_atk_user_name = source.m_atk_user_name;
            m_atk_user_alliance = source.m_atk_user_alliance;
            m_atk_pos = source.m_atk_pos;
            m_atk_icon = source.m_atk_icon;
            m_atk_avatar = source.m_atk_avatar;
            m_atk_avatar_frame = source.m_atk_avatar_frame;
            m_troops = source.m_troops;
            m_hero = source.m_hero;
            m_item_buff = source.m_item_buff;
            m_unit_id = source.m_unit_id;
            m_atk_march_id = source.m_atk_march_id;
            m_npc_icon = source.m_npc_icon;
            m_npc_name = source.m_npc_name;
            m_target_user_id = source.m_target_user_id;
            m_target_user_name = source.m_target_user_name;
            m_target_icon = source.m_target_icon;
            m_target_avatar = source.m_target_avatar;
            m_target_avatar_frame = source.m_target_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class BeReinforceListInfo : NetworkMessage {
        public static int[] Id = { 211,1 };
        public static Ctrl VC;
        public List<BeReinforceInfo> m_infos = new List<BeReinforceInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BeReinforceInfo tmp = new BeReinforceInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_infos.Count);
                for (int i = 0; i != m_infos.Count; ++i) {
                    m_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(BeReinforceListInfo source) {
            m_infos = source.m_infos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ServerGridPos : NetworkMessage {
        public static int[] Id = { 217,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_user_id;
        public GridPos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                m_pos = new GridPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerGridPos source) {
            m_server_id = source.m_server_id;
            m_user_id = source.m_user_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class ChangeAllianceInfoReqInfo : NetworkMessage {
        public static int[] Id = { 223,1 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_abbr = "";
        public String m_lang = "";
        public String m_desc = "";
        public Int16 m_logo;
        public Int16 m_color;
        public String m_headline = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_lang = sp.ReadString();}
            if (sp.TryRead(3)) {m_desc = sp.ReadString();}
            if (sp.TryRead(4)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_headline = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_lang);}
            if (sp.TryWrite(3)) {sp.Write(m_desc);}
            if (sp.TryWrite(4)) {sp.Write(m_logo);}
            if (sp.TryWrite(5)) {sp.Write(m_color);}
            if (sp.TryWrite(6)) {sp.Write(m_headline);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeAllianceInfoReqInfo source) {
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_lang = source.m_lang;
            m_desc = source.m_desc;
            m_logo = source.m_logo;
            m_color = source.m_color;
            m_headline = source.m_headline;
        }
    }
    
    [Serializable]
    public partial class InviteInfo : NetworkMessage {
        public static int[] Id = { 229,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int64 m_invite_time;
        public Int64 m_power;
        public Int64 m_killcnt;
        public Int16 m_icon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_invite_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_killcnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_invite_time);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_killcnt);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(InviteInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_invite_time = source.m_invite_time;
            m_power = source.m_power;
            m_killcnt = source.m_killcnt;
            m_icon = source.m_icon;
        }
    }
    
    [Serializable]
    public partial class AllianceResDispatchInfo : NetworkMessage {
        public static int[] Id = { 235,1 };
        public static Ctrl VC;
        public Int32 m_target_id;
        public List<ResTypeInfo> m_res_info = new List<ResTypeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_res_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_info.Count);
                for (int i = 0; i != m_res_info.Count; ++i) {
                    m_res_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResDispatchInfo source) {
            m_target_id = source.m_target_id;
            m_res_info = source.m_res_info;
        }
    }
    
    [Serializable]
    public partial class ManageAllianceResApplyInfo : NetworkMessage {
        public static int[] Id = { 241,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Boolean m_approved;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_approved = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_approved);}
            sp.EnEnd();
        }
        public void CopyFrom(ManageAllianceResApplyInfo source) {
            m_user_id = source.m_user_id;
            m_approved = source.m_approved;
        }
    }
    
    [Serializable]
    public partial class DominionMapReq : NetworkMessage {
        public static int[] Id = { 247,1 };
        public static Ctrl VC;
        public Int32 m_min;
        public Int32 m_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_min = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_max = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_min);}
            if (sp.TryWrite(1)) {sp.Write(m_max);}
            sp.EnEnd();
        }
        public void CopyFrom(DominionMapReq source) {
            m_min = source.m_min;
            m_max = source.m_max;
        }
    }
    
    [Serializable]
    public partial class ItemInfo : NetworkMessage {
        public static int[] Id = { 253,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(ItemInfo source) {
            m_id = source.m_id;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class SearchAllianceInfo : NetworkMessage {
        public static int[] Id = { 259,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public List<AllianceBriefInfo> m_list = new List<AllianceBriefInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBriefInfo tmp = new AllianceBriefInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SearchAllianceInfo source) {
            m_type = source.m_type;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class SessionTokenInfo : NetworkMessage {
        public static int[] Id = { 265,1 };
        public static Ctrl VC;
        public UInt32 m_key1;
        public UInt32 m_key2;
        public Int32 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key1 = sp.ReadUInt32();}
            if (sp.TryRead(1)) {m_key2 = sp.ReadUInt32();}
            if (sp.TryRead(2)) {m_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key1);}
            if (sp.TryWrite(1)) {sp.Write(m_key2);}
            if (sp.TryWrite(2)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SessionTokenInfo source) {
            m_key1 = source.m_key1;
            m_key2 = source.m_key2;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class ManageAllianceJoinApplyInfo : NetworkMessage {
        public static int[] Id = { 271,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_op_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_op_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_op_type);}
            sp.EnEnd();
        }
        public void CopyFrom(ManageAllianceJoinApplyInfo source) {
            m_user_id = source.m_user_id;
            m_op_type = source.m_op_type;
        }
    }
    
    [Serializable]
    public partial class UpdateAllianceAuthorityInfo : NetworkMessage {
        public static int[] Id = { 277,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public List<Int16> m_permissions = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_permissions.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_permissions.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_permissions.Count);
                for (int i = 0; i != m_permissions.Count; ++i) {
                    sp.Write(m_permissions[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UpdateAllianceAuthorityInfo source) {
            m_user_id = source.m_user_id;
            m_permissions = source.m_permissions;
        }
    }
    
    [Serializable]
    public partial class AwesomeRelocateInfo : NetworkMessage {
        public static int[] Id = { 283,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public ServerTilePos m_dst;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_dst = new ServerTilePos();
                m_dst.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_dst.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AwesomeRelocateInfo source) {
            m_user_id = source.m_user_id;
            m_dst = source.m_dst;
        }
    }
    
    [Serializable]
    public partial class OpenAllianceGiftInfo : NetworkMessage {
        public static int[] Id = { 289,1 };
        public static Ctrl VC;
        public List<Int64> m_id = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_id.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_id.Count);
                for (int i = 0; i != m_id.Count; ++i) {
                    sp.Write(m_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OpenAllianceGiftInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class IapPackageInfo : NetworkMessage {
        public static int[] Id = { 295,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_type;
        public Int32 m_kind;
        public Int16 m_tag;
        public String m_theme = "";
        public String m_product_id = "";
        public Int64 m_diamonds;
        public String m_title = "";
        public String m_title_d = "";
        public String m_sub_title1 = "";
        public String m_sub_title2 = "";
        public Int64 m_end_time;
        public List<IapItemInfo> m_item_list = new List<IapItemInfo>();
        public Int64 m_daily_diamonds;
        public List<IapItemInfo> m_daily_items = new List<IapItemInfo>();
        public Int32 m_bag_limit;
        public Int32 m_limit;
        public Int32 m_once_limit;
        public Int64 m_start_time;
        public Int32 m_pkg_price;
        public Int16 m_discount;
        public Boolean m_is_roi;
        public List<IapItemInfo> m_roi_items = new List<IapItemInfo>();
        public Int32 m_bonus_id;
        public String m_banner = "";
        public Int32 m_order;
        public Int64 m_timer_iap_end_time;
        public String m_hud_icon = "";
        public Int32 m_pkg_id;
        public List<IapActivationInfo> m_activation = new List<IapActivationInfo>();
        public String m_pr_type = "";
        public Int32 m_weekend;
        public Int16 m_vip_level;
        public Int16 m_popup_max;
        public Int64 m_popup_interval;
        public Int64 m_subscription_duration;
        public String m_color = "";
        public Int64 m_final_end_time;
        public String m_origin_product_id = "";
        public String m_discount_title = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_kind = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_tag = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_theme = sp.ReadString();}
            if (sp.TryRead(5)) {m_product_id = sp.ReadString();}
            if (sp.TryRead(6)) {m_diamonds = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_title = sp.ReadString();}
            if (sp.TryRead(8)) {m_title_d = sp.ReadString();}
            if (sp.TryRead(9)) {m_sub_title1 = sp.ReadString();}
            if (sp.TryRead(10)) {m_sub_title2 = sp.ReadString();}
            if (sp.TryRead(11)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapItemInfo tmp = new IapItemInfo();
                    tmp.Decode(sp);
                    m_item_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_daily_diamonds = sp.ReadInt64();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_daily_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapItemInfo tmp = new IapItemInfo();
                    tmp.Decode(sp);
                    m_daily_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_bag_limit = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_limit = sp.ReadInt32();}
            if (sp.TryRead(17)) {m_once_limit = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(19)) {m_pkg_price = sp.ReadInt32();}
            if (sp.TryRead(20)) {m_discount = sp.ReadInt16();}
            if (sp.TryRead(21)) {m_is_roi = sp.ReadBoolean();}
            if (sp.TryRead(22)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_roi_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapItemInfo tmp = new IapItemInfo();
                    tmp.Decode(sp);
                    m_roi_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(23)) {m_bonus_id = sp.ReadInt32();}
            if (sp.TryRead(24)) {m_banner = sp.ReadString();}
            if (sp.TryRead(25)) {m_order = sp.ReadInt32();}
            if (sp.TryRead(26)) {m_timer_iap_end_time = sp.ReadInt64();}
            if (sp.TryRead(27)) {m_hud_icon = sp.ReadString();}
            if (sp.TryRead(28)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(29)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_activation.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapActivationInfo tmp = new IapActivationInfo();
                    tmp.Decode(sp);
                    m_activation.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(30)) {m_pr_type = sp.ReadString();}
            if (sp.TryRead(31)) {m_weekend = sp.ReadInt32();}
            if (sp.TryRead(32)) {m_vip_level = sp.ReadInt16();}
            if (sp.TryRead(33)) {m_popup_max = sp.ReadInt16();}
            if (sp.TryRead(34)) {m_popup_interval = sp.ReadInt64();}
            if (sp.TryRead(35)) {m_subscription_duration = sp.ReadInt64();}
            if (sp.TryRead(36)) {m_color = sp.ReadString();}
            if (sp.TryRead(37)) {m_final_end_time = sp.ReadInt64();}
            if (sp.TryRead(38)) {m_origin_product_id = sp.ReadString();}
            if (sp.TryRead(39)) {m_discount_title = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_kind);}
            if (sp.TryWrite(3)) {sp.Write(m_tag);}
            if (sp.TryWrite(4)) {sp.Write(m_theme);}
            if (sp.TryWrite(5)) {sp.Write(m_product_id);}
            if (sp.TryWrite(6)) {sp.Write(m_diamonds);}
            if (sp.TryWrite(7)) {sp.Write(m_title);}
            if (sp.TryWrite(8)) {sp.Write(m_title_d);}
            if (sp.TryWrite(9)) {sp.Write(m_sub_title1);}
            if (sp.TryWrite(10)) {sp.Write(m_sub_title2);}
            if (sp.TryWrite(11)) {sp.Write(m_end_time);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_list.Count);
                for (int i = 0; i != m_item_list.Count; ++i) {
                    m_item_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {sp.Write(m_daily_diamonds);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_daily_items.Count);
                for (int i = 0; i != m_daily_items.Count; ++i) {
                    m_daily_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_bag_limit);}
            if (sp.TryWrite(16)) {sp.Write(m_limit);}
            if (sp.TryWrite(17)) {sp.Write(m_once_limit);}
            if (sp.TryWrite(18)) {sp.Write(m_start_time);}
            if (sp.TryWrite(19)) {sp.Write(m_pkg_price);}
            if (sp.TryWrite(20)) {sp.Write(m_discount);}
            if (sp.TryWrite(21)) {sp.Write(m_is_roi);}
            if (sp.TryWrite(22)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_roi_items.Count);
                for (int i = 0; i != m_roi_items.Count; ++i) {
                    m_roi_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(23)) {sp.Write(m_bonus_id);}
            if (sp.TryWrite(24)) {sp.Write(m_banner);}
            if (sp.TryWrite(25)) {sp.Write(m_order);}
            if (sp.TryWrite(26)) {sp.Write(m_timer_iap_end_time);}
            if (sp.TryWrite(27)) {sp.Write(m_hud_icon);}
            if (sp.TryWrite(28)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(29)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_activation.Count);
                for (int i = 0; i != m_activation.Count; ++i) {
                    m_activation[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(30)) {sp.Write(m_pr_type);}
            if (sp.TryWrite(31)) {sp.Write(m_weekend);}
            if (sp.TryWrite(32)) {sp.Write(m_vip_level);}
            if (sp.TryWrite(33)) {sp.Write(m_popup_max);}
            if (sp.TryWrite(34)) {sp.Write(m_popup_interval);}
            if (sp.TryWrite(35)) {sp.Write(m_subscription_duration);}
            if (sp.TryWrite(36)) {sp.Write(m_color);}
            if (sp.TryWrite(37)) {sp.Write(m_final_end_time);}
            if (sp.TryWrite(38)) {sp.Write(m_origin_product_id);}
            if (sp.TryWrite(39)) {sp.Write(m_discount_title);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPackageInfo source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_kind = source.m_kind;
            m_tag = source.m_tag;
            m_theme = source.m_theme;
            m_product_id = source.m_product_id;
            m_diamonds = source.m_diamonds;
            m_title = source.m_title;
            m_title_d = source.m_title_d;
            m_sub_title1 = source.m_sub_title1;
            m_sub_title2 = source.m_sub_title2;
            m_end_time = source.m_end_time;
            m_item_list = source.m_item_list;
            m_daily_diamonds = source.m_daily_diamonds;
            m_daily_items = source.m_daily_items;
            m_bag_limit = source.m_bag_limit;
            m_limit = source.m_limit;
            m_once_limit = source.m_once_limit;
            m_start_time = source.m_start_time;
            m_pkg_price = source.m_pkg_price;
            m_discount = source.m_discount;
            m_is_roi = source.m_is_roi;
            m_roi_items = source.m_roi_items;
            m_bonus_id = source.m_bonus_id;
            m_banner = source.m_banner;
            m_order = source.m_order;
            m_timer_iap_end_time = source.m_timer_iap_end_time;
            m_hud_icon = source.m_hud_icon;
            m_pkg_id = source.m_pkg_id;
            m_activation = source.m_activation;
            m_pr_type = source.m_pr_type;
            m_weekend = source.m_weekend;
            m_vip_level = source.m_vip_level;
            m_popup_max = source.m_popup_max;
            m_popup_interval = source.m_popup_interval;
            m_subscription_duration = source.m_subscription_duration;
            m_color = source.m_color;
            m_final_end_time = source.m_final_end_time;
            m_origin_product_id = source.m_origin_product_id;
            m_discount_title = source.m_discount_title;
        }
    }
    
    [Serializable]
    public partial class IapFinishRsp : NetworkMessage {
        public static int[] Id = { 301,1 };
        public static Ctrl VC;
        public String m_receipt = "";
        public IapPackageInfo m_pkg;
        public SByte m_package_count;
        public Boolean m_verify_suc;
        public IapListInfo m_iap_list;
        public Int64 m_total_pay_price;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_receipt = sp.ReadString();}
            if (sp.TryRead(1)) {
                m_pkg = new IapPackageInfo();
                m_pkg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_package_count = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_verify_suc = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                m_iap_list = new IapListInfo();
                m_iap_list.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_total_pay_price = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_receipt);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pkg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_package_count);}
            if (sp.TryWrite(3)) {sp.Write(m_verify_suc);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_iap_list.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_total_pay_price);}
            sp.EnEnd();
        }
        public void CopyFrom(IapFinishRsp source) {
            m_receipt = source.m_receipt;
            m_pkg = source.m_pkg;
            m_package_count = source.m_package_count;
            m_verify_suc = source.m_verify_suc;
            m_iap_list = source.m_iap_list;
            m_total_pay_price = source.m_total_pay_price;
        }
    }
    
    [Serializable]
    public partial class CancelPushInfo : NetworkMessage {
        public static int[] Id = { 307,1 };
        public static Ctrl VC;
        public String m_access_token = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            sp.EnEnd();
        }
        public void CopyFrom(CancelPushInfo source) {
            m_access_token = source.m_access_token;
        }
    }
    
    [Serializable]
    public partial class MapmarkInfo : NetworkMessage {
        public static int[] Id = { 313,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public KtilePos m_pos;
        public String m_comments = "";
        public Int16 m_type;
        public Int64 m_create_time;
        public SByte m_catalog;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new KtilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_comments = sp.ReadString();}
            if (sp.TryRead(3)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_create_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_catalog = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_comments);}
            if (sp.TryWrite(3)) {sp.Write(m_type);}
            if (sp.TryWrite(4)) {sp.Write(m_create_time);}
            if (sp.TryWrite(5)) {sp.Write(m_catalog);}
            if (sp.TryWrite(6)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MapmarkInfo source) {
            m_id = source.m_id;
            m_pos = source.m_pos;
            m_comments = source.m_comments;
            m_type = source.m_type;
            m_create_time = source.m_create_time;
            m_catalog = source.m_catalog;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class SettingInfo : NetworkMessage {
        public static int[] Id = { 319,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public List<SettingNode> m_keys = new List<SettingNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_keys.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SettingNode tmp = new SettingNode();
                    tmp.Decode(sp);
                    m_keys.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_keys.Count);
                for (int i = 0; i != m_keys.Count; ++i) {
                    m_keys[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SettingInfo source) {
            m_access_token = source.m_access_token;
            m_keys = source.m_keys;
        }
    }
    
    [Serializable]
    public partial class MonumentDetailInfo : NetworkMessage {
        public static int[] Id = { 325,1 };
        public static Ctrl VC;
        public MonumentSnapInfo m_snap;
        public MonumentStatus m_status;
        public String m_note = "";
        public SByte m_flag;
        public Int16 m_map_title;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_snap = new MonumentSnapInfo();
                m_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_status = new MonumentStatus();
                m_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_note = sp.ReadString();}
            if (sp.TryRead(3)) {m_flag = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_map_title = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_note);}
            if (sp.TryWrite(3)) {sp.Write(m_flag);}
            if (sp.TryWrite(4)) {sp.Write(m_map_title);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentDetailInfo source) {
            m_snap = source.m_snap;
            m_status = source.m_status;
            m_note = source.m_note;
            m_flag = source.m_flag;
            m_map_title = source.m_map_title;
        }
    }
    
    [Serializable]
    public partial class WeeklyActivityInfo : NetworkMessage {
        public static int[] Id = { 331,1 };
        public static Ctrl VC;
        public Int32 m_cur_weekly_activity_points;
        public Int64 m_next_week_fresh_time;
        public List<WeeklyActivityReward> m_rewards_detail = new List<WeeklyActivityReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_weekly_activity_points = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_next_week_fresh_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WeeklyActivityReward tmp = new WeeklyActivityReward();
                    tmp.Decode(sp);
                    m_rewards_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_weekly_activity_points);}
            if (sp.TryWrite(1)) {sp.Write(m_next_week_fresh_time);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards_detail.Count);
                for (int i = 0; i != m_rewards_detail.Count; ++i) {
                    m_rewards_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeeklyActivityInfo source) {
            m_cur_weekly_activity_points = source.m_cur_weekly_activity_points;
            m_next_week_fresh_time = source.m_next_week_fresh_time;
            m_rewards_detail = source.m_rewards_detail;
        }
    }
    
    [Serializable]
    public partial class GetInvitationAckInfo : NetworkMessage {
        public static int[] Id = { 337,1 };
        public static Ctrl VC;
        public String m_cdkey = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cdkey = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cdkey);}
            sp.EnEnd();
        }
        public void CopyFrom(GetInvitationAckInfo source) {
            m_cdkey = source.m_cdkey;
        }
    }
    
    [Serializable]
    public partial class TaxResInfo : NetworkMessage {
        public static int[] Id = { 343,1 };
        public static Ctrl VC;
        public SByte m_type;
        public Int64 m_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(TaxResInfo source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class PayPresidentTaxDetailInfo : NetworkMessage {
        public static int[] Id = { 349,1 };
        public static Ctrl VC;
        public PayPresidentTaxBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new PayPresidentTaxBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(PayPresidentTaxDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class GetPrizeListReqInfo : NetworkMessage {
        public static int[] Id = { 355,1 };
        public static Ctrl VC;
        public Int64 m_start_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GetPrizeListReqInfo source) {
            m_start_id = source.m_start_id;
        }
    }
    
    [Serializable]
    public partial class DiamondMineFriendReq : NetworkMessage {
        public static int[] Id = { 361,1 };
        public static Ctrl VC;
        public List<String> m_list = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    sp.Write(m_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DiamondMineFriendReq source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class BaseCaptiveInfo : NetworkMessage {
        public static int[] Id = { 367,1 };
        public static Ctrl VC;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public Int16 m_hero_level;
        public Int16 m_home_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_hero_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_home_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_hero_level);}
            if (sp.TryWrite(3)) {sp.Write(m_home_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseCaptiveInfo source) {
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_hero_level = source.m_hero_level;
            m_home_server_id = source.m_home_server_id;
        }
    }
    
    [Serializable]
    public partial class BundleUserAckInfo : NetworkMessage {
        public static int[] Id = { 373,1 };
        public static Ctrl VC;
        public List<BundleUserInfo> m_infos = new List<BundleUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BundleUserInfo tmp = new BundleUserInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_infos.Count);
                for (int i = 0; i != m_infos.Count; ++i) {
                    m_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BundleUserAckInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class AllianceLandCnt : NetworkMessage {
        public static int[] Id = { 379,1 };
        public static Ctrl VC;
        public Int32 m_as;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_as = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_as);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceLandCnt source) {
            m_as = source.m_as;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class AllianceSetSalaryInfo : NetworkMessage {
        public static int[] Id = { 385,1 };
        public static Ctrl VC;
        public Int16 m_rank;
        public Int64 m_user_id;
        public Int64 m_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_amount = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSetSalaryInfo source) {
            m_rank = source.m_rank;
            m_user_id = source.m_user_id;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class AccountFindPasswordInfo : NetworkMessage {
        public static int[] Id = { 391,1 };
        public static Ctrl VC;
        public SByte m_type;
        public String m_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            sp.EnEnd();
        }
        public void CopyFrom(AccountFindPasswordInfo source) {
            m_type = source.m_type;
            m_name = source.m_name;
        }
    }
    
    [Serializable]
    public partial class IapUnfinishOrderListReq : NetworkMessage {
        public static int[] Id = { 397,1 };
        public static Ctrl VC;
        public Int32 m_iap_type;
        public String m_id = "";
        public String m_payload = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_id = sp.ReadString();}
            if (sp.TryRead(2)) {m_payload = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_payload);}
            sp.EnEnd();
        }
        public void CopyFrom(IapUnfinishOrderListReq source) {
            m_iap_type = source.m_iap_type;
            m_id = source.m_id;
            m_payload = source.m_payload;
        }
    }
    
    [Serializable]
    public partial class GetRoleListReqInfo : NetworkMessage {
        public static int[] Id = { 403,1 };
        public static Ctrl VC;
        public String m_token = "";
        public Int64 m_role_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_role_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_token);}
            if (sp.TryWrite(1)) {sp.Write(m_role_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GetRoleListReqInfo source) {
            m_token = source.m_token;
            m_role_id = source.m_role_id;
        }
    }
    
    [Serializable]
    public partial class BiddingAllianceRecruitReqInfo : NetworkMessage {
        public static int[] Id = { 409,1 };
        public static Ctrl VC;
        public Int32 m_founds;
        public Int16 m_expiry;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_founds = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_expiry = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_founds);}
            if (sp.TryWrite(1)) {sp.Write(m_expiry);}
            if (sp.TryWrite(2)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(BiddingAllianceRecruitReqInfo source) {
            m_founds = source.m_founds;
            m_expiry = source.m_expiry;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class RecruitWallReqInfo : NetworkMessage {
        public static int[] Id = { 415,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public String m_lang = "";
        public SByte m_open;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_lang = sp.ReadString();}
            if (sp.TryRead(2)) {m_open = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_lang);}
            if (sp.TryWrite(2)) {sp.Write(m_open);}
            sp.EnEnd();
        }
        public void CopyFrom(RecruitWallReqInfo source) {
            m_server_id = source.m_server_id;
            m_lang = source.m_lang;
            m_open = source.m_open;
        }
    }
    
    [Serializable]
    public partial class OpenMaterialboxInfo : NetworkMessage {
        public static int[] Id = { 421,1 };
        public static Ctrl VC;
        public Int32 m_box_id;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_box_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_box_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OpenMaterialboxInfo source) {
            m_box_id = source.m_box_id;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class ListUserDominionReqInfo : NetworkMessage {
        public static int[] Id = { 427,1 };
        public static Ctrl VC;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ListUserDominionReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class LikeReqInfo : NetworkMessage {
        public static int[] Id = { 433,1 };
        public static Ctrl VC;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(LikeReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class CreateAllianceResInfo : NetworkMessage {
        public static int[] Id = { 439,1 };
        public static Ctrl VC;
        public List<SendResInfo> m_res = new List<SendResInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SendResInfo tmp = new SendResInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CreateAllianceResInfo source) {
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class ExpiredItemCompBaseInfo : NetworkMessage {
        public static int[] Id = { 445,1 };
        public static Ctrl VC;
        public List<Item> m_del_items = new List<Item>();
        public List<Item> m_comp_items = new List<Item>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_del_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_del_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_comp_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_comp_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_del_items.Count);
                for (int i = 0; i != m_del_items.Count; ++i) {
                    m_del_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_comp_items.Count);
                for (int i = 0; i != m_comp_items.Count; ++i) {
                    m_comp_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ExpiredItemCompBaseInfo source) {
            m_del_items = source.m_del_items;
            m_comp_items = source.m_comp_items;
        }
    }
    
    [Serializable]
    public partial class ModuleInfo : NetworkMessage {
        public static int[] Id = { 451,1 };
        public static Ctrl VC;
        public String m_name = "";
        public Int32 m_order;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_order = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_order);}
            sp.EnEnd();
        }
        public void CopyFrom(ModuleInfo source) {
            m_name = source.m_name;
            m_order = source.m_order;
        }
    }
    
    [Serializable]
    public partial class SuperResDestroyReportBaseInfo : NetworkMessage {
        public static int[] Id = { 457,1 };
        public static Ctrl VC;
        public ServerTilePos m_pos;
        public SByte m_tile_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_tile_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_tile_type);}
            sp.EnEnd();
        }
        public void CopyFrom(SuperResDestroyReportBaseInfo source) {
            m_pos = source.m_pos;
            m_tile_type = source.m_tile_type;
        }
    }
    
    [Serializable]
    public partial class PlayerMailBaseInfoV1 : NetworkMessage {
        public static int[] Id = { 463,1 };
        public static Ctrl VC;
        public ContactInfoV1 m_sender;
        public ReceiversV1 m_receiver;
        public String m_title = "";
        public String m_content = "";
        public List<String> m_attachment = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_sender = new ContactInfoV1();
                m_sender.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_receiver = new ReceiversV1();
                m_receiver.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_content = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attachment.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_attachment.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_sender.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_receiver.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_title);}
            if (sp.TryWrite(3)) {sp.Write(m_content);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attachment.Count);
                for (int i = 0; i != m_attachment.Count; ++i) {
                    sp.Write(m_attachment[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PlayerMailBaseInfoV1 source) {
            m_sender = source.m_sender;
            m_receiver = source.m_receiver;
            m_title = source.m_title;
            m_content = source.m_content;
            m_attachment = source.m_attachment;
        }
    }
    
    [Serializable]
    public partial class LikeList : NetworkMessage {
        public static int[] Id = { 469,1 };
        public static Ctrl VC;
        public List<LikeUserInfo> m_like_users = new List<LikeUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_like_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LikeUserInfo tmp = new LikeUserInfo();
                    tmp.Decode(sp);
                    m_like_users.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_like_users.Count);
                for (int i = 0; i != m_like_users.Count; ++i) {
                    m_like_users[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LikeList source) {
            m_like_users = source.m_like_users;
        }
    }
    
    [Serializable]
    public partial class DonateSectionInfo : NetworkMessage {
        public static int[] Id = { 475,1 };
        public static Ctrl VC;
        public SByte m_section_id;
        public Int64 m_exp;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_section_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_exp = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_section_id);}
            if (sp.TryWrite(1)) {sp.Write(m_exp);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DonateSectionInfo source) {
            m_section_id = source.m_section_id;
            m_exp = source.m_exp;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class ScrollAlliancePower : NetworkMessage {
        public static int[] Id = { 481,1 };
        public static Ctrl VC;
        public AllianceBriefInfo m_brief;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_brief = new AllianceBriefInfo();
                m_brief.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_brief.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollAlliancePower source) {
            m_brief = source.m_brief;
        }
    }
    
    [Serializable]
    public partial class ScrollMonsterReborn : NetworkMessage {
        public static int[] Id = { 487,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollMonsterReborn source) {
            m_server_id = source.m_server_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class AllianceExchangeInfo : NetworkMessage {
        public static int[] Id = { 493,1 };
        public static Ctrl VC;
        public Int64 m_update_time;
        public Int16 m_point;
        public Int32 m_common_count;
        public Int32 m_special_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_update_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_point = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_common_count = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_special_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_update_time);}
            if (sp.TryWrite(1)) {sp.Write(m_point);}
            if (sp.TryWrite(2)) {sp.Write(m_common_count);}
            if (sp.TryWrite(3)) {sp.Write(m_special_count);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceExchangeInfo source) {
            m_update_time = source.m_update_time;
            m_point = source.m_point;
            m_common_count = source.m_common_count;
            m_special_count = source.m_special_count;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchCostInfo : NetworkMessage {
        public static int[] Id = { 499,1 };
        public static Ctrl VC;
        public Int32 m_common_donate_food;
        public Int32 m_common_donate_energy;
        public Int32 m_common_donate_oil;
        public Int32 m_common_donate_steel;
        public Int32 m_common_donate_cash;
        public Int32 m_special_donate_diamond;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_common_donate_food = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_common_donate_energy = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_common_donate_oil = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_common_donate_steel = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_common_donate_cash = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_special_donate_diamond = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_common_donate_food);}
            if (sp.TryWrite(1)) {sp.Write(m_common_donate_energy);}
            if (sp.TryWrite(2)) {sp.Write(m_common_donate_oil);}
            if (sp.TryWrite(3)) {sp.Write(m_common_donate_steel);}
            if (sp.TryWrite(4)) {sp.Write(m_common_donate_cash);}
            if (sp.TryWrite(5)) {sp.Write(m_special_donate_diamond);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchCostInfo source) {
            m_common_donate_food = source.m_common_donate_food;
            m_common_donate_energy = source.m_common_donate_energy;
            m_common_donate_oil = source.m_common_donate_oil;
            m_common_donate_steel = source.m_common_donate_steel;
            m_common_donate_cash = source.m_common_donate_cash;
            m_special_donate_diamond = source.m_special_donate_diamond;
        }
    }
    
    [Serializable]
    public partial class UpgradeAllianceResearchReqInfo : NetworkMessage {
        public static int[] Id = { 505,1 };
        public static Ctrl VC;
        public Int16 m_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            sp.EnEnd();
        }
        public void CopyFrom(UpgradeAllianceResearchReqInfo source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class FbShowInviteSignInfo : NetworkMessage {
        public static int[] Id = { 511,1 };
        public static Ctrl VC;
        public SByte m_fb_invite_sign;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fb_invite_sign = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fb_invite_sign);}
            sp.EnEnd();
        }
        public void CopyFrom(FbShowInviteSignInfo source) {
            m_fb_invite_sign = source.m_fb_invite_sign;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDonateRankMailInfo : NetworkMessage {
        public static int[] Id = { 517,1 };
        public static Ctrl VC;
        public AllianceResearchDonateRankList m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceResearchDonateRankList();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchDonateRankMailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class RecordVerifyFakeInfo : NetworkMessage {
        public static int[] Id = { 523,1 };
        public static Ctrl VC;
        public List<Int32> m_code_arr = new List<Int32>();
        public List<Int32> m_choose_arr = new List<Int32>();
        public String m_ok_type = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_code_arr.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_code_arr.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_choose_arr.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_choose_arr.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_ok_type = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_code_arr.Count);
                for (int i = 0; i != m_code_arr.Count; ++i) {
                    sp.Write(m_code_arr[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_choose_arr.Count);
                for (int i = 0; i != m_choose_arr.Count; ++i) {
                    sp.Write(m_choose_arr[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_ok_type);}
            sp.EnEnd();
        }
        public void CopyFrom(RecordVerifyFakeInfo source) {
            m_code_arr = source.m_code_arr;
            m_choose_arr = source.m_choose_arr;
            m_ok_type = source.m_ok_type;
        }
    }
    
    [Serializable]
    public partial class PayRewardInfo : NetworkMessage {
        public static int[] Id = { 529,1 };
        public static Ctrl VC;
        public SByte m_show;
        public Int32 m_id;
        public Int32 m_cnt;
        public String m_title = "";
        public String m_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_show = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_show);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(PayRewardInfo source) {
            m_show = source.m_show;
            m_id = source.m_id;
            m_cnt = source.m_cnt;
            m_title = source.m_title;
            m_desc = source.m_desc;
        }
    }
    
    [Serializable]
    public partial class AllianceModTitleNtf : NetworkMessage {
        public static int[] Id = { 535,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_new_title;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_new_title = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_new_title);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceModTitleNtf source) {
            m_user_id = source.m_user_id;
            m_new_title = source.m_new_title;
        }
    }
    
    [Serializable]
    public partial class ComeBackRewardsInfo : NetworkMessage {
        public static int[] Id = { 541,1 };
        public static Ctrl VC;
        public Int32 m_before_sale_items_cost;
        public Int32 m_for_sale_items_cost;
        public List<ComeBackItemInfo> m_for_sale_items = new List<ComeBackItemInfo>();
        public List<LoginComeBackItemInfo> m_login_rewards_items = new List<LoginComeBackItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_before_sale_items_cost = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_for_sale_items_cost = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_for_sale_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ComeBackItemInfo tmp = new ComeBackItemInfo();
                    tmp.Decode(sp);
                    m_for_sale_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_login_rewards_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LoginComeBackItemInfo tmp = new LoginComeBackItemInfo();
                    tmp.Decode(sp);
                    m_login_rewards_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_before_sale_items_cost);}
            if (sp.TryWrite(1)) {sp.Write(m_for_sale_items_cost);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_for_sale_items.Count);
                for (int i = 0; i != m_for_sale_items.Count; ++i) {
                    m_for_sale_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_login_rewards_items.Count);
                for (int i = 0; i != m_login_rewards_items.Count; ++i) {
                    m_login_rewards_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ComeBackRewardsInfo source) {
            m_before_sale_items_cost = source.m_before_sale_items_cost;
            m_for_sale_items_cost = source.m_for_sale_items_cost;
            m_for_sale_items = source.m_for_sale_items;
            m_login_rewards_items = source.m_login_rewards_items;
        }
    }
    
    [Serializable]
    public partial class UserNationalFlagInfo : NetworkMessage {
        public static int[] Id = { 547,1 };
        public static Ctrl VC;
        public Int16 m_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_flag = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(UserNationalFlagInfo source) {
            m_flag = source.m_flag;
        }
    }
    
    [Serializable]
    public partial class ConnectKickInfo : NetworkMessage {
        public static int[] Id = { 553,1 };
        public static Ctrl VC;
        public Int16 m_action;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action);}
            sp.EnEnd();
        }
        public void CopyFrom(ConnectKickInfo source) {
            m_action = source.m_action;
        }
    }
    
    [Serializable]
    public partial class AchievementReqInfo : NetworkMessage {
        public static int[] Id = { 559,1 };
        public static Ctrl VC;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AchievementReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class AllianceOwnerInfo : NetworkMessage {
        public static int[] Id = { 565,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int16 m_icon;
        public UserAllianceBrief m_brief;
        public String m_avatar = "";
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_brief = new UserAllianceBrief();
                m_brief.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(5)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_brief.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_avatar);}
            if (sp.TryWrite(5)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceOwnerInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_brief = source.m_brief;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class IstanaWarDetailInfo : NetworkMessage {
        public static int[] Id = { 571,1 };
        public static Ctrl VC;
        public IstanaWarBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new IstanaWarBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaWarDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class YybSyncUserBalanceInfo : NetworkMessage {
        public static int[] Id = { 577,1 };
        public static Ctrl VC;
        public String m_payload = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_payload = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_payload);}
            sp.EnEnd();
        }
        public void CopyFrom(YybSyncUserBalanceInfo source) {
            m_payload = source.m_payload;
        }
    }
    
    [Serializable]
    public partial class IstanaBaseAckInfo : NetworkMessage {
        public static int[] Id = { 583,1 };
        public static Ctrl VC;
        public List<IstanaServerInfo> m_server_info_list = new List<IstanaServerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IstanaServerInfo tmp = new IstanaServerInfo();
                    tmp.Decode(sp);
                    m_server_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_info_list.Count);
                for (int i = 0; i != m_server_info_list.Count; ++i) {
                    m_server_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(IstanaBaseAckInfo source) {
            m_server_info_list = source.m_server_info_list;
        }
    }
    
    [Serializable]
    public partial class GuestGetIstanaNationReqInfo : NetworkMessage {
        public static int[] Id = { 589,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_region_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_region_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_region_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GuestGetIstanaNationReqInfo source) {
            m_server_id = source.m_server_id;
            m_region_user_id = source.m_region_user_id;
        }
    }
    
    [Serializable]
    public partial class MonthlyBookStatus : NetworkMessage {
        public static int[] Id = { 595,1 };
        public static Ctrl VC;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(MonthlyBookStatus source) {
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class CommanderSkillPointInfo : NetworkMessage {
        public static int[] Id = { 601,1 };
        public static Ctrl VC;
        public Int32 m_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_point);}
            sp.EnEnd();
        }
        public void CopyFrom(CommanderSkillPointInfo source) {
            m_point = source.m_point;
        }
    }
    
    [Serializable]
    public partial class CrowdInvestPaybackReportInfo : NetworkMessage {
        public static int[] Id = { 607,1 };
        public static Ctrl VC;
        public CrowdInvestPaybackReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new CrowdInvestPaybackReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CrowdInvestPaybackReportInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class RewardDetailStatus : NetworkMessage {
        public static int[] Id = { 613,1 };
        public static Ctrl VC;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(RewardDetailStatus source) {
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class GrowRebelReqInfo : NetworkMessage {
        public static int[] Id = { 619,1 };
        public static Ctrl VC;
        public Int16 m_grow_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_grow_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_grow_level);}
            sp.EnEnd();
        }
        public void CopyFrom(GrowRebelReqInfo source) {
            m_grow_level = source.m_grow_level;
        }
    }
    
    [Serializable]
    public partial class FpsStatus : NetworkMessage {
        public static int[] Id = { 625,1 };
        public static Ctrl VC;
        public SByte m_status;
        public Int16 m_fps_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_fps_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_fps_level);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsStatus source) {
            m_status = source.m_status;
            m_fps_level = source.m_fps_level;
        }
    }
    
    [Serializable]
    public partial class AntiAdictionRule : NetworkMessage {
        public static int[] Id = { 631,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_dur_low;
        public Int64 m_dur_high;
        public Int64 m_tip_interval;
        public Int32 m_revenue_rate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_dur_low = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_dur_high = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_tip_interval = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_revenue_rate = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_dur_low);}
            if (sp.TryWrite(2)) {sp.Write(m_dur_high);}
            if (sp.TryWrite(3)) {sp.Write(m_tip_interval);}
            if (sp.TryWrite(4)) {sp.Write(m_revenue_rate);}
            sp.EnEnd();
        }
        public void CopyFrom(AntiAdictionRule source) {
            m_id = source.m_id;
            m_dur_low = source.m_dur_low;
            m_dur_high = source.m_dur_high;
            m_tip_interval = source.m_tip_interval;
            m_revenue_rate = source.m_revenue_rate;
        }
    }
    
    [Serializable]
    public partial class DiamondMineShareAckInfo : NetworkMessage {
        public static int[] Id = { 637,1 };
        public static Ctrl VC;
        public Boolean m_has_award;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_has_award = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_has_award);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondMineShareAckInfo source) {
            m_has_award = source.m_has_award;
        }
    }
    
    [Serializable]
    public partial class SpecialGrowRebelReward : NetworkMessage {
        public static int[] Id = { 643,1 };
        public static Ctrl VC;
        public Int16 m_level;
        public Int16 m_reward_status;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_reward_status = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_status);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SpecialGrowRebelReward source) {
            m_level = source.m_level;
            m_reward_status = source.m_reward_status;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class WeeklyRewardInfo : NetworkMessage {
        public static int[] Id = { 649,1 };
        public static Ctrl VC;
        public Int16 m_stage;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stage = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_stage);}
            sp.EnEnd();
        }
        public void CopyFrom(WeeklyRewardInfo source) {
            m_stage = source.m_stage;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedKnockoutList : NetworkMessage {
        public static int[] Id = { 655,1 };
        public static Ctrl VC;
        public List<ZvzUnitedCycle> m_cycles = new List<ZvzUnitedCycle>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cycles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ZvzUnitedCycle tmp = new ZvzUnitedCycle();
                    tmp.Decode(sp);
                    m_cycles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cycles.Count);
                for (int i = 0; i != m_cycles.Count; ++i) {
                    m_cycles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedKnockoutList source) {
            m_cycles = source.m_cycles;
        }
    }
    
    [Serializable]
    public partial class CaptchaReqInfo : NetworkMessage {
        public static int[] Id = { 661,1 };
        public static Ctrl VC;
        public String m_access_token = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptchaReqInfo source) {
            m_access_token = source.m_access_token;
        }
    }
    
    [Serializable]
    public partial class FileUploadInfo : NetworkMessage {
        public static int[] Id = { 667,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public String m_file_name = "";
        public String m_file_length = "";
        public String m_hash = "";
        public String m_region = "";
        public String m_over_write = "";
        public String m_expire_time = "";
        public String m_env = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_file_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_file_length = sp.ReadString();}
            if (sp.TryRead(3)) {m_hash = sp.ReadString();}
            if (sp.TryRead(4)) {m_region = sp.ReadString();}
            if (sp.TryRead(5)) {m_over_write = sp.ReadString();}
            if (sp.TryRead(6)) {m_expire_time = sp.ReadString();}
            if (sp.TryRead(7)) {m_env = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {sp.Write(m_file_name);}
            if (sp.TryWrite(2)) {sp.Write(m_file_length);}
            if (sp.TryWrite(3)) {sp.Write(m_hash);}
            if (sp.TryWrite(4)) {sp.Write(m_region);}
            if (sp.TryWrite(5)) {sp.Write(m_over_write);}
            if (sp.TryWrite(6)) {sp.Write(m_expire_time);}
            if (sp.TryWrite(7)) {sp.Write(m_env);}
            sp.EnEnd();
        }
        public void CopyFrom(FileUploadInfo source) {
            m_access_token = source.m_access_token;
            m_file_name = source.m_file_name;
            m_file_length = source.m_file_length;
            m_hash = source.m_hash;
            m_region = source.m_region;
            m_over_write = source.m_over_write;
            m_expire_time = source.m_expire_time;
            m_env = source.m_env;
        }
    }
    
    [Serializable]
    public partial class PenddingQuestDetailInfo : NetworkMessage {
        public static int[] Id = { 673,1 };
        public static Ctrl VC;
        public List<PenddingQuest> m_all_detail = new List<PenddingQuest>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_all_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PenddingQuest tmp = new PenddingQuest();
                    tmp.Decode(sp);
                    m_all_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_all_detail.Count);
                for (int i = 0; i != m_all_detail.Count; ++i) {
                    m_all_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PenddingQuestDetailInfo source) {
            m_all_detail = source.m_all_detail;
        }
    }
    
    [Serializable]
    public partial class QuestIdInfo : NetworkMessage {
        public static int[] Id = { 679,1 };
        public static Ctrl VC;
        public Int16 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestIdInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class ScrollHonorEventRank : NetworkMessage {
        public static int[] Id = { 685,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_user_alliance;
        public Int32 m_event_id;
        public Int32 m_event_type;
        public Int32 m_rank;
        public Int64 m_endtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_user_alliance = new UserAllianceBrief();
                m_user_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_event_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_event_type = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_endtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_event_id);}
            if (sp.TryWrite(5)) {sp.Write(m_event_type);}
            if (sp.TryWrite(6)) {sp.Write(m_rank);}
            if (sp.TryWrite(7)) {sp.Write(m_endtime);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollHonorEventRank source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_user_alliance = source.m_user_alliance;
            m_event_id = source.m_event_id;
            m_event_type = source.m_event_type;
            m_rank = source.m_rank;
            m_endtime = source.m_endtime;
        }
    }
    
    [Serializable]
    public partial class FpsSweepInfo : NetworkMessage {
        public static int[] Id = { 691,1 };
        public static Ctrl VC;
        public Int16 m_fps_level;
        public Int16 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fps_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fps_level);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSweepInfo source) {
            m_fps_level = source.m_fps_level;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class FpsChangeGunInfo : NetworkMessage {
        public static int[] Id = { 697,1 };
        public static Ctrl VC;
        public Int16 m_gun_id;
        public Int16 m_agent_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_gun_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_agent_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_gun_id);}
            if (sp.TryWrite(1)) {sp.Write(m_agent_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsChangeGunInfo source) {
            m_gun_id = source.m_gun_id;
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class ResListReqInfo : NetworkMessage {
        public static int[] Id = { 703,1 };
        public static Ctrl VC;
        public Int16 m_level;
        public SByte m_tile_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_tile_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_tile_type);}
            sp.EnEnd();
        }
        public void CopyFrom(ResListReqInfo source) {
            m_level = source.m_level;
            m_tile_type = source.m_tile_type;
        }
    }
    
    [Serializable]
    public partial class UserTaskWctTracking : NetworkMessage {
        public static int[] Id = { 709,1 };
        public static Ctrl VC;
        public Int64 m_event_id;
        public String m_task_id = "";
        public String m_task_sub_id = "";
        public Int32 m_task_type;
        public Int64 m_task_score;
        public Int32 m_status;
        public Int64 m_client_time;
        public Int32 m_serial_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadString();}
            if (sp.TryRead(2)) {m_task_sub_id = sp.ReadString();}
            if (sp.TryRead(3)) {m_task_type = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_task_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_status = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_client_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_serial_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            if (sp.TryWrite(2)) {sp.Write(m_task_sub_id);}
            if (sp.TryWrite(3)) {sp.Write(m_task_type);}
            if (sp.TryWrite(4)) {sp.Write(m_task_score);}
            if (sp.TryWrite(5)) {sp.Write(m_status);}
            if (sp.TryWrite(6)) {sp.Write(m_client_time);}
            if (sp.TryWrite(7)) {sp.Write(m_serial_num);}
            sp.EnEnd();
        }
        public void CopyFrom(UserTaskWctTracking source) {
            m_event_id = source.m_event_id;
            m_task_id = source.m_task_id;
            m_task_sub_id = source.m_task_sub_id;
            m_task_type = source.m_task_type;
            m_task_score = source.m_task_score;
            m_status = source.m_status;
            m_client_time = source.m_client_time;
            m_serial_num = source.m_serial_num;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelEndReqInfo : NetworkMessage {
        public static int[] Id = { 715,1 };
        public static Ctrl VC;
        public Int16 m_level_id;
        public Int64 m_level_time;
        public Int32 m_score;
        public List<Int32> m_score_list = new List<Int32>();
        public Int32 m_kill_num;
        public Int32 m_head_kill_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_score_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_score_list.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {m_kill_num = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_head_kill_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level_time);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_score_list.Count);
                for (int i = 0; i != m_score_list.Count; ++i) {
                    sp.Write(m_score_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {sp.Write(m_kill_num);}
            if (sp.TryWrite(5)) {sp.Write(m_head_kill_num);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSpecialLevelEndReqInfo source) {
            m_level_id = source.m_level_id;
            m_level_time = source.m_level_time;
            m_score = source.m_score;
            m_score_list = source.m_score_list;
            m_kill_num = source.m_kill_num;
            m_head_kill_num = source.m_head_kill_num;
        }
    }
    
    [Serializable]
    public partial class CampaignInfo : NetworkMessage {
        public static int[] Id = { 721,1 };
        public static Ctrl VC;
        public List<TaskCampaignInfo> m_task_campaign = new List<TaskCampaignInfo>();
        public List<ExchangeCampaignInfo> m_exchange_campaign = new List<ExchangeCampaignInfo>();
        public List<DropCampaignInfo> m_drop_campaign = new List<DropCampaignInfo>();
        public List<BaseCampaignInfo> m_entry_campaign = new List<BaseCampaignInfo>();
        public List<BaseCampaignInfo> m_calendar_campaign = new List<BaseCampaignInfo>();
        public List<ProgressCampaignInfo> m_progress_campaign = new List<ProgressCampaignInfo>();
        public List<StepTaskCampaignInfo> m_step_task_campaign = new List<StepTaskCampaignInfo>();
        public List<MapExploreCampaignInfo> m_map_explore_campaign = new List<MapExploreCampaignInfo>();
        public List<FpsCampaignInfo> m_fps_campaign = new List<FpsCampaignInfo>();
        public List<TaskCampaignInfo> m_alliance_campaign = new List<TaskCampaignInfo>();
        public List<RebelCampaignInfo> m_alliance_rebel = new List<RebelCampaignInfo>();
        public List<WheelCampaignInfo> m_wheel_campaign = new List<WheelCampaignInfo>();
        public List<RechargeCampaignInfo> m_recharge_campaign = new List<RechargeCampaignInfo>();
        public List<UserCostCampaignInfo> m_user_cost_campaign = new List<UserCostCampaignInfo>();
        public List<ProgressiveTaskCampaignInfo> m_progressive_task_campaign = new List<ProgressiveTaskCampaignInfo>();
        public List<NonstopKillingCampaignInfo> m_nonstop_killing_campaign = new List<NonstopKillingCampaignInfo>();
        public List<GuideCampaignInfo> m_new_entry_campaign = new List<GuideCampaignInfo>();
        public List<TaskCampaignInfo> m_time_limit_task_campaign = new List<TaskCampaignInfo>();
        public List<LadderCampaignInfo> m_ladder_campaign = new List<LadderCampaignInfo>();
        public List<AllianceGuideCampaign> m_alliance_guide = new List<AllianceGuideCampaign>();
        public List<AtkCityGuideCampaignInfo> m_city_guide = new List<AtkCityGuideCampaignInfo>();
        public List<AllianceMobilizeCampaign> m_alliance_mobilize = new List<AllianceMobilizeCampaign>();
        public List<GuideCampaignInfo> m_server_switch_guide = new List<GuideCampaignInfo>();
        public List<TaskCampaignInfo> m_server_switch_reward = new List<TaskCampaignInfo>();
        public List<BaseCampaignInfo> m_gvg_campaign = new List<BaseCampaignInfo>();
        public List<RouletteCampaignInfo> m_roulette_campaign = new List<RouletteCampaignInfo>();
        public List<KvkCampaignInfo> m_kvk_campaign = new List<KvkCampaignInfo>();
        public List<BossCampaignInfo> m_boss_campaign = new List<BossCampaignInfo>();
        public List<KvkPrepareCampaign> m_kvk_pre_campaign = new List<KvkPrepareCampaign>();
        public List<CampaignKvkFortInfo> m_kvk_fort_campaign = new List<CampaignKvkFortInfo>();
        public List<TaskCampaignInfo> m_kvk_task_campaign = new List<TaskCampaignInfo>();
        public List<SlotMachineCampaignInfo> m_slot_machine_campaign = new List<SlotMachineCampaignInfo>();
        public List<ExchangeCampaignInfo> m_hero_skin_campaign = new List<ExchangeCampaignInfo>();
        public List<AllianceBoardCampaignInfo> m_alliance_board_campaign = new List<AllianceBoardCampaignInfo>();
        public List<GuideCampaignInfo> m_socail_camp = new List<GuideCampaignInfo>();
        public List<CumulativeRechargeCampaignInfo> m_cumulative_recharge_campaign = new List<CumulativeRechargeCampaignInfo>();
        public List<SendGiftCampaignInfo> m_send_gift_campaign = new List<SendGiftCampaignInfo>();
        public List<NbpCampaignInfo> m_normal_battle_passport_campaign = new List<NbpCampaignInfo>();
        public List<MonopolyCampaignInfo> m_monopoly_campaign = new List<MonopolyCampaignInfo>();
        public List<WarshipWarmUpCampaignInfo> m_warship_warm_up_campaign = new List<WarshipWarmUpCampaignInfo>();
        public List<PrivateCustomCampaignInfo> m_private_custom_campaign = new List<PrivateCustomCampaignInfo>();
        public List<PurchaseRebateCampaignInfo> m_purchase_rebate_campaign = new List<PurchaseRebateCampaignInfo>();
        public List<LimitedExchangeCampaignInfo> m_limited_exchange_campaign = new List<LimitedExchangeCampaignInfo>();
        public List<AbandonedArsenalCampaignInfo> m_abandoned_arsenal_campaign = new List<AbandonedArsenalCampaignInfo>();
        public List<StrangeCubeCampaignInfo> m_strange_cube_campaign = new List<StrangeCubeCampaignInfo>();
        public List<WarMarketExchangeCampaignInfo> m_war_market_exchange_campaign = new List<WarMarketExchangeCampaignInfo>();
        public List<LineTaskCampaignInfo> m_line_task_campaign = new List<LineTaskCampaignInfo>();
        public List<VoteCampaignInfo> m_vote_campaign = new List<VoteCampaignInfo>();
        public List<RecycleCampaignInfo> m_recycle_campaign = new List<RecycleCampaignInfo>();
        public List<AllianceTreasureCampaignInfo> m_alliance_treasure_campaign = new List<AllianceTreasureCampaignInfo>();
        public List<QuestionAnswerCampaignInfo> m_question_answer_campaign = new List<QuestionAnswerCampaignInfo>();
        public List<FlipCardCampaignInfo> m_flip_card_campaign = new List<FlipCardCampaignInfo>();
        public List<RaidCampaignInfo> m_raid_campaign = new List<RaidCampaignInfo>();
        public List<OverturnCampaignInfo> m_overturn_campaign = new List<OverturnCampaignInfo>();
        public List<RebuildingCampaignInfo> m_rebuilding_campaign = new List<RebuildingCampaignInfo>();
        public List<IapDiscountCampaignInfo> m_iap_discount_campaign = new List<IapDiscountCampaignInfo>();
        public List<MonsterCampaignInfo> m_monster_campaign = new List<MonsterCampaignInfo>();
        public List<ChainGiftsCampaignInfo> m_chain_gifts_campaign = new List<ChainGiftsCampaignInfo>();
        public List<PuzzleCampaignInfo> m_puzzle_campaign = new List<PuzzleCampaignInfo>();
        public List<SignInCampaignInfo> m_sign_in_campaign = new List<SignInCampaignInfo>();
        public List<VideoChannelCampaignInfo> m_video_channel_campaign = new List<VideoChannelCampaignInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskCampaignInfo tmp = new TaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExchangeCampaignInfo tmp = new ExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drop_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DropCampaignInfo tmp = new DropCampaignInfo();
                    tmp.Decode(sp);
                    m_drop_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_entry_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseCampaignInfo tmp = new BaseCampaignInfo();
                    tmp.Decode(sp);
                    m_entry_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_calendar_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseCampaignInfo tmp = new BaseCampaignInfo();
                    tmp.Decode(sp);
                    m_calendar_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progress_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ProgressCampaignInfo tmp = new ProgressCampaignInfo();
                    tmp.Decode(sp);
                    m_progress_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_step_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StepTaskCampaignInfo tmp = new StepTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_step_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_map_explore_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapExploreCampaignInfo tmp = new MapExploreCampaignInfo();
                    tmp.Decode(sp);
                    m_map_explore_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fps_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FpsCampaignInfo tmp = new FpsCampaignInfo();
                    tmp.Decode(sp);
                    m_fps_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskCampaignInfo tmp = new TaskCampaignInfo();
                    tmp.Decode(sp);
                    m_alliance_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_rebel.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RebelCampaignInfo tmp = new RebelCampaignInfo();
                    tmp.Decode(sp);
                    m_alliance_rebel.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_wheel_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignInfo tmp = new WheelCampaignInfo();
                    tmp.Decode(sp);
                    m_wheel_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_recharge_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RechargeCampaignInfo tmp = new RechargeCampaignInfo();
                    tmp.Decode(sp);
                    m_recharge_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_user_cost_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserCostCampaignInfo tmp = new UserCostCampaignInfo();
                    tmp.Decode(sp);
                    m_user_cost_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progressive_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ProgressiveTaskCampaignInfo tmp = new ProgressiveTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_progressive_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_nonstop_killing_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NonstopKillingCampaignInfo tmp = new NonstopKillingCampaignInfo();
                    tmp.Decode(sp);
                    m_nonstop_killing_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_new_entry_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GuideCampaignInfo tmp = new GuideCampaignInfo();
                    tmp.Decode(sp);
                    m_new_entry_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_time_limit_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskCampaignInfo tmp = new TaskCampaignInfo();
                    tmp.Decode(sp);
                    m_time_limit_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(18)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ladder_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderCampaignInfo tmp = new LadderCampaignInfo();
                    tmp.Decode(sp);
                    m_ladder_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_guide.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceGuideCampaign tmp = new AllianceGuideCampaign();
                    tmp.Decode(sp);
                    m_alliance_guide.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(20)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_guide.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AtkCityGuideCampaignInfo tmp = new AtkCityGuideCampaignInfo();
                    tmp.Decode(sp);
                    m_city_guide.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(21)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_mobilize.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMobilizeCampaign tmp = new AllianceMobilizeCampaign();
                    tmp.Decode(sp);
                    m_alliance_mobilize.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(22)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_switch_guide.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GuideCampaignInfo tmp = new GuideCampaignInfo();
                    tmp.Decode(sp);
                    m_server_switch_guide.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(23)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_switch_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskCampaignInfo tmp = new TaskCampaignInfo();
                    tmp.Decode(sp);
                    m_server_switch_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(24)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gvg_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseCampaignInfo tmp = new BaseCampaignInfo();
                    tmp.Decode(sp);
                    m_gvg_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(25)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_roulette_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RouletteCampaignInfo tmp = new RouletteCampaignInfo();
                    tmp.Decode(sp);
                    m_roulette_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(26)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkCampaignInfo tmp = new KvkCampaignInfo();
                    tmp.Decode(sp);
                    m_kvk_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(27)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_boss_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BossCampaignInfo tmp = new BossCampaignInfo();
                    tmp.Decode(sp);
                    m_boss_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(28)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_pre_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkPrepareCampaign tmp = new KvkPrepareCampaign();
                    tmp.Decode(sp);
                    m_kvk_pre_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(29)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_fort_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignKvkFortInfo tmp = new CampaignKvkFortInfo();
                    tmp.Decode(sp);
                    m_kvk_fort_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(30)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskCampaignInfo tmp = new TaskCampaignInfo();
                    tmp.Decode(sp);
                    m_kvk_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(31)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_slot_machine_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SlotMachineCampaignInfo tmp = new SlotMachineCampaignInfo();
                    tmp.Decode(sp);
                    m_slot_machine_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(32)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_hero_skin_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExchangeCampaignInfo tmp = new ExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_hero_skin_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(33)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_board_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardCampaignInfo tmp = new AllianceBoardCampaignInfo();
                    tmp.Decode(sp);
                    m_alliance_board_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(34)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_socail_camp.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GuideCampaignInfo tmp = new GuideCampaignInfo();
                    tmp.Decode(sp);
                    m_socail_camp.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(35)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cumulative_recharge_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CumulativeRechargeCampaignInfo tmp = new CumulativeRechargeCampaignInfo();
                    tmp.Decode(sp);
                    m_cumulative_recharge_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(36)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_send_gift_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SendGiftCampaignInfo tmp = new SendGiftCampaignInfo();
                    tmp.Decode(sp);
                    m_send_gift_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(37)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_battle_passport_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NbpCampaignInfo tmp = new NbpCampaignInfo();
                    tmp.Decode(sp);
                    m_normal_battle_passport_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(38)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_monopoly_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonopolyCampaignInfo tmp = new MonopolyCampaignInfo();
                    tmp.Decode(sp);
                    m_monopoly_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(39)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_warship_warm_up_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarshipWarmUpCampaignInfo tmp = new WarshipWarmUpCampaignInfo();
                    tmp.Decode(sp);
                    m_warship_warm_up_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(40)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_private_custom_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PrivateCustomCampaignInfo tmp = new PrivateCustomCampaignInfo();
                    tmp.Decode(sp);
                    m_private_custom_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(41)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_purchase_rebate_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PurchaseRebateCampaignInfo tmp = new PurchaseRebateCampaignInfo();
                    tmp.Decode(sp);
                    m_purchase_rebate_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(42)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_limited_exchange_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LimitedExchangeCampaignInfo tmp = new LimitedExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_limited_exchange_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(43)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_abandoned_arsenal_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AbandonedArsenalCampaignInfo tmp = new AbandonedArsenalCampaignInfo();
                    tmp.Decode(sp);
                    m_abandoned_arsenal_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(44)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_strange_cube_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StrangeCubeCampaignInfo tmp = new StrangeCubeCampaignInfo();
                    tmp.Decode(sp);
                    m_strange_cube_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(45)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_war_market_exchange_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarMarketExchangeCampaignInfo tmp = new WarMarketExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_war_market_exchange_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(46)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_line_task_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LineTaskCampaignInfo tmp = new LineTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_line_task_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(47)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_vote_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VoteCampaignInfo tmp = new VoteCampaignInfo();
                    tmp.Decode(sp);
                    m_vote_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(48)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_recycle_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RecycleCampaignInfo tmp = new RecycleCampaignInfo();
                    tmp.Decode(sp);
                    m_recycle_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(49)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_treasure_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceTreasureCampaignInfo tmp = new AllianceTreasureCampaignInfo();
                    tmp.Decode(sp);
                    m_alliance_treasure_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(50)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_question_answer_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestionAnswerCampaignInfo tmp = new QuestionAnswerCampaignInfo();
                    tmp.Decode(sp);
                    m_question_answer_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(51)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_flip_card_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlipCardCampaignInfo tmp = new FlipCardCampaignInfo();
                    tmp.Decode(sp);
                    m_flip_card_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(52)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_raid_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidCampaignInfo tmp = new RaidCampaignInfo();
                    tmp.Decode(sp);
                    m_raid_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(53)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_overturn_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OverturnCampaignInfo tmp = new OverturnCampaignInfo();
                    tmp.Decode(sp);
                    m_overturn_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(54)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rebuilding_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RebuildingCampaignInfo tmp = new RebuildingCampaignInfo();
                    tmp.Decode(sp);
                    m_rebuilding_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(55)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_iap_discount_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapDiscountCampaignInfo tmp = new IapDiscountCampaignInfo();
                    tmp.Decode(sp);
                    m_iap_discount_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(56)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_monster_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonsterCampaignInfo tmp = new MonsterCampaignInfo();
                    tmp.Decode(sp);
                    m_monster_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(57)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_chain_gifts_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ChainGiftsCampaignInfo tmp = new ChainGiftsCampaignInfo();
                    tmp.Decode(sp);
                    m_chain_gifts_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(58)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_puzzle_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PuzzleCampaignInfo tmp = new PuzzleCampaignInfo();
                    tmp.Decode(sp);
                    m_puzzle_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(59)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sign_in_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SignInCampaignInfo tmp = new SignInCampaignInfo();
                    tmp.Decode(sp);
                    m_sign_in_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(60)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_video_channel_campaign.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoChannelCampaignInfo tmp = new VideoChannelCampaignInfo();
                    tmp.Decode(sp);
                    m_video_channel_campaign.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_campaign.Count);
                for (int i = 0; i != m_task_campaign.Count; ++i) {
                    m_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_campaign.Count);
                for (int i = 0; i != m_exchange_campaign.Count; ++i) {
                    m_exchange_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drop_campaign.Count);
                for (int i = 0; i != m_drop_campaign.Count; ++i) {
                    m_drop_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_entry_campaign.Count);
                for (int i = 0; i != m_entry_campaign.Count; ++i) {
                    m_entry_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_calendar_campaign.Count);
                for (int i = 0; i != m_calendar_campaign.Count; ++i) {
                    m_calendar_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_progress_campaign.Count);
                for (int i = 0; i != m_progress_campaign.Count; ++i) {
                    m_progress_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_step_task_campaign.Count);
                for (int i = 0; i != m_step_task_campaign.Count; ++i) {
                    m_step_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_map_explore_campaign.Count);
                for (int i = 0; i != m_map_explore_campaign.Count; ++i) {
                    m_map_explore_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fps_campaign.Count);
                for (int i = 0; i != m_fps_campaign.Count; ++i) {
                    m_fps_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_campaign.Count);
                for (int i = 0; i != m_alliance_campaign.Count; ++i) {
                    m_alliance_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_rebel.Count);
                for (int i = 0; i != m_alliance_rebel.Count; ++i) {
                    m_alliance_rebel[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_wheel_campaign.Count);
                for (int i = 0; i != m_wheel_campaign.Count; ++i) {
                    m_wheel_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_recharge_campaign.Count);
                for (int i = 0; i != m_recharge_campaign.Count; ++i) {
                    m_recharge_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_user_cost_campaign.Count);
                for (int i = 0; i != m_user_cost_campaign.Count; ++i) {
                    m_user_cost_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_progressive_task_campaign.Count);
                for (int i = 0; i != m_progressive_task_campaign.Count; ++i) {
                    m_progressive_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_nonstop_killing_campaign.Count);
                for (int i = 0; i != m_nonstop_killing_campaign.Count; ++i) {
                    m_nonstop_killing_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_new_entry_campaign.Count);
                for (int i = 0; i != m_new_entry_campaign.Count; ++i) {
                    m_new_entry_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_time_limit_task_campaign.Count);
                for (int i = 0; i != m_time_limit_task_campaign.Count; ++i) {
                    m_time_limit_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(18)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ladder_campaign.Count);
                for (int i = 0; i != m_ladder_campaign.Count; ++i) {
                    m_ladder_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(19)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_guide.Count);
                for (int i = 0; i != m_alliance_guide.Count; ++i) {
                    m_alliance_guide[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(20)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_guide.Count);
                for (int i = 0; i != m_city_guide.Count; ++i) {
                    m_city_guide[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(21)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_mobilize.Count);
                for (int i = 0; i != m_alliance_mobilize.Count; ++i) {
                    m_alliance_mobilize[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(22)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_switch_guide.Count);
                for (int i = 0; i != m_server_switch_guide.Count; ++i) {
                    m_server_switch_guide[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(23)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_switch_reward.Count);
                for (int i = 0; i != m_server_switch_reward.Count; ++i) {
                    m_server_switch_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(24)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_gvg_campaign.Count);
                for (int i = 0; i != m_gvg_campaign.Count; ++i) {
                    m_gvg_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(25)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_roulette_campaign.Count);
                for (int i = 0; i != m_roulette_campaign.Count; ++i) {
                    m_roulette_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(26)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_campaign.Count);
                for (int i = 0; i != m_kvk_campaign.Count; ++i) {
                    m_kvk_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(27)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_boss_campaign.Count);
                for (int i = 0; i != m_boss_campaign.Count; ++i) {
                    m_boss_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(28)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_pre_campaign.Count);
                for (int i = 0; i != m_kvk_pre_campaign.Count; ++i) {
                    m_kvk_pre_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(29)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_fort_campaign.Count);
                for (int i = 0; i != m_kvk_fort_campaign.Count; ++i) {
                    m_kvk_fort_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(30)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_task_campaign.Count);
                for (int i = 0; i != m_kvk_task_campaign.Count; ++i) {
                    m_kvk_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(31)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_slot_machine_campaign.Count);
                for (int i = 0; i != m_slot_machine_campaign.Count; ++i) {
                    m_slot_machine_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(32)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_hero_skin_campaign.Count);
                for (int i = 0; i != m_hero_skin_campaign.Count; ++i) {
                    m_hero_skin_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(33)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_board_campaign.Count);
                for (int i = 0; i != m_alliance_board_campaign.Count; ++i) {
                    m_alliance_board_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(34)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_socail_camp.Count);
                for (int i = 0; i != m_socail_camp.Count; ++i) {
                    m_socail_camp[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(35)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cumulative_recharge_campaign.Count);
                for (int i = 0; i != m_cumulative_recharge_campaign.Count; ++i) {
                    m_cumulative_recharge_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(36)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_send_gift_campaign.Count);
                for (int i = 0; i != m_send_gift_campaign.Count; ++i) {
                    m_send_gift_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(37)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_battle_passport_campaign.Count);
                for (int i = 0; i != m_normal_battle_passport_campaign.Count; ++i) {
                    m_normal_battle_passport_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(38)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_monopoly_campaign.Count);
                for (int i = 0; i != m_monopoly_campaign.Count; ++i) {
                    m_monopoly_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(39)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_warship_warm_up_campaign.Count);
                for (int i = 0; i != m_warship_warm_up_campaign.Count; ++i) {
                    m_warship_warm_up_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(40)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_private_custom_campaign.Count);
                for (int i = 0; i != m_private_custom_campaign.Count; ++i) {
                    m_private_custom_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(41)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_purchase_rebate_campaign.Count);
                for (int i = 0; i != m_purchase_rebate_campaign.Count; ++i) {
                    m_purchase_rebate_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(42)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_limited_exchange_campaign.Count);
                for (int i = 0; i != m_limited_exchange_campaign.Count; ++i) {
                    m_limited_exchange_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(43)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_abandoned_arsenal_campaign.Count);
                for (int i = 0; i != m_abandoned_arsenal_campaign.Count; ++i) {
                    m_abandoned_arsenal_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(44)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_strange_cube_campaign.Count);
                for (int i = 0; i != m_strange_cube_campaign.Count; ++i) {
                    m_strange_cube_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(45)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_war_market_exchange_campaign.Count);
                for (int i = 0; i != m_war_market_exchange_campaign.Count; ++i) {
                    m_war_market_exchange_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(46)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_line_task_campaign.Count);
                for (int i = 0; i != m_line_task_campaign.Count; ++i) {
                    m_line_task_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(47)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_vote_campaign.Count);
                for (int i = 0; i != m_vote_campaign.Count; ++i) {
                    m_vote_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(48)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_recycle_campaign.Count);
                for (int i = 0; i != m_recycle_campaign.Count; ++i) {
                    m_recycle_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(49)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_treasure_campaign.Count);
                for (int i = 0; i != m_alliance_treasure_campaign.Count; ++i) {
                    m_alliance_treasure_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(50)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_question_answer_campaign.Count);
                for (int i = 0; i != m_question_answer_campaign.Count; ++i) {
                    m_question_answer_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(51)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_flip_card_campaign.Count);
                for (int i = 0; i != m_flip_card_campaign.Count; ++i) {
                    m_flip_card_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(52)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_raid_campaign.Count);
                for (int i = 0; i != m_raid_campaign.Count; ++i) {
                    m_raid_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(53)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_overturn_campaign.Count);
                for (int i = 0; i != m_overturn_campaign.Count; ++i) {
                    m_overturn_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(54)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rebuilding_campaign.Count);
                for (int i = 0; i != m_rebuilding_campaign.Count; ++i) {
                    m_rebuilding_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(55)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_iap_discount_campaign.Count);
                for (int i = 0; i != m_iap_discount_campaign.Count; ++i) {
                    m_iap_discount_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(56)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_monster_campaign.Count);
                for (int i = 0; i != m_monster_campaign.Count; ++i) {
                    m_monster_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(57)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_chain_gifts_campaign.Count);
                for (int i = 0; i != m_chain_gifts_campaign.Count; ++i) {
                    m_chain_gifts_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(58)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_puzzle_campaign.Count);
                for (int i = 0; i != m_puzzle_campaign.Count; ++i) {
                    m_puzzle_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(59)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sign_in_campaign.Count);
                for (int i = 0; i != m_sign_in_campaign.Count; ++i) {
                    m_sign_in_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(60)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_video_channel_campaign.Count);
                for (int i = 0; i != m_video_channel_campaign.Count; ++i) {
                    m_video_channel_campaign[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CampaignInfo source) {
            m_task_campaign = source.m_task_campaign;
            m_exchange_campaign = source.m_exchange_campaign;
            m_drop_campaign = source.m_drop_campaign;
            m_entry_campaign = source.m_entry_campaign;
            m_calendar_campaign = source.m_calendar_campaign;
            m_progress_campaign = source.m_progress_campaign;
            m_step_task_campaign = source.m_step_task_campaign;
            m_map_explore_campaign = source.m_map_explore_campaign;
            m_fps_campaign = source.m_fps_campaign;
            m_alliance_campaign = source.m_alliance_campaign;
            m_alliance_rebel = source.m_alliance_rebel;
            m_wheel_campaign = source.m_wheel_campaign;
            m_recharge_campaign = source.m_recharge_campaign;
            m_user_cost_campaign = source.m_user_cost_campaign;
            m_progressive_task_campaign = source.m_progressive_task_campaign;
            m_nonstop_killing_campaign = source.m_nonstop_killing_campaign;
            m_new_entry_campaign = source.m_new_entry_campaign;
            m_time_limit_task_campaign = source.m_time_limit_task_campaign;
            m_ladder_campaign = source.m_ladder_campaign;
            m_alliance_guide = source.m_alliance_guide;
            m_city_guide = source.m_city_guide;
            m_alliance_mobilize = source.m_alliance_mobilize;
            m_server_switch_guide = source.m_server_switch_guide;
            m_server_switch_reward = source.m_server_switch_reward;
            m_gvg_campaign = source.m_gvg_campaign;
            m_roulette_campaign = source.m_roulette_campaign;
            m_kvk_campaign = source.m_kvk_campaign;
            m_boss_campaign = source.m_boss_campaign;
            m_kvk_pre_campaign = source.m_kvk_pre_campaign;
            m_kvk_fort_campaign = source.m_kvk_fort_campaign;
            m_kvk_task_campaign = source.m_kvk_task_campaign;
            m_slot_machine_campaign = source.m_slot_machine_campaign;
            m_hero_skin_campaign = source.m_hero_skin_campaign;
            m_alliance_board_campaign = source.m_alliance_board_campaign;
            m_socail_camp = source.m_socail_camp;
            m_cumulative_recharge_campaign = source.m_cumulative_recharge_campaign;
            m_send_gift_campaign = source.m_send_gift_campaign;
            m_normal_battle_passport_campaign = source.m_normal_battle_passport_campaign;
            m_monopoly_campaign = source.m_monopoly_campaign;
            m_warship_warm_up_campaign = source.m_warship_warm_up_campaign;
            m_private_custom_campaign = source.m_private_custom_campaign;
            m_purchase_rebate_campaign = source.m_purchase_rebate_campaign;
            m_limited_exchange_campaign = source.m_limited_exchange_campaign;
            m_abandoned_arsenal_campaign = source.m_abandoned_arsenal_campaign;
            m_strange_cube_campaign = source.m_strange_cube_campaign;
            m_war_market_exchange_campaign = source.m_war_market_exchange_campaign;
            m_line_task_campaign = source.m_line_task_campaign;
            m_vote_campaign = source.m_vote_campaign;
            m_recycle_campaign = source.m_recycle_campaign;
            m_alliance_treasure_campaign = source.m_alliance_treasure_campaign;
            m_question_answer_campaign = source.m_question_answer_campaign;
            m_flip_card_campaign = source.m_flip_card_campaign;
            m_raid_campaign = source.m_raid_campaign;
            m_overturn_campaign = source.m_overturn_campaign;
            m_rebuilding_campaign = source.m_rebuilding_campaign;
            m_iap_discount_campaign = source.m_iap_discount_campaign;
            m_monster_campaign = source.m_monster_campaign;
            m_chain_gifts_campaign = source.m_chain_gifts_campaign;
            m_puzzle_campaign = source.m_puzzle_campaign;
            m_sign_in_campaign = source.m_sign_in_campaign;
            m_video_channel_campaign = source.m_video_channel_campaign;
        }
    }
    
    [Serializable]
    public partial class DropCampaignInfo : NetworkMessage {
        public static int[] Id = { 727,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<DropCampaignRuleInfo> m_drop_rule = new List<DropCampaignRuleInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drop_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DropCampaignRuleInfo tmp = new DropCampaignRuleInfo();
                    tmp.Decode(sp);
                    m_drop_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drop_rule.Count);
                for (int i = 0; i != m_drop_rule.Count; ++i) {
                    m_drop_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DropCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_drop_rule = source.m_drop_rule;
        }
    }
    
    [Serializable]
    public partial class RankCampaignFixedRewardInfo : NetworkMessage {
        public static int[] Id = { 733,1 };
        public static Ctrl VC;
        public Int64 m_points;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_points);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RankCampaignFixedRewardInfo source) {
            m_points = source.m_points;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class InstantBuyInfo : NetworkMessage {
        public static int[] Id = { 739,1 };
        public static Ctrl VC;
        public List<InstantBuyItemInfo> m_info = new List<InstantBuyItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    InstantBuyItemInfo tmp = new InstantBuyItemInfo();
                    tmp.Decode(sp);
                    m_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_info.Count);
                for (int i = 0; i != m_info.Count; ++i) {
                    m_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(InstantBuyInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class ResizeableTileInfo : NetworkMessage {
        public static int[] Id = { 745,1 };
        public static Ctrl VC;
        public SByte m_tile_type;
        public List<TilePos> m_tiles = new List<TilePos>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_tile_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tiles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_tiles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_tile_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tiles.Count);
                for (int i = 0; i != m_tiles.Count; ++i) {
                    m_tiles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ResizeableTileInfo source) {
            m_tile_type = source.m_tile_type;
            m_tiles = source.m_tiles;
        }
    }
    
    [Serializable]
    public partial class SevendayFinalRewardItem : NetworkMessage {
        public static int[] Id = { 751,1 };
        public static Ctrl VC;
        public SByte m_id;
        public Int64 m_time;
        public Int64 m_points;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public String m_rule = "";
        public Int64 m_current_points;
        public Boolean m_get;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_rule = sp.ReadString();}
            if (sp.TryRead(5)) {m_current_points = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_get = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_time);}
            if (sp.TryWrite(2)) {sp.Write(m_points);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_rule);}
            if (sp.TryWrite(5)) {sp.Write(m_current_points);}
            if (sp.TryWrite(6)) {sp.Write(m_get);}
            sp.EnEnd();
        }
        public void CopyFrom(SevendayFinalRewardItem source) {
            m_id = source.m_id;
            m_time = source.m_time;
            m_points = source.m_points;
            m_items = source.m_items;
            m_rule = source.m_rule;
            m_current_points = source.m_current_points;
            m_get = source.m_get;
        }
    }
    
    [Serializable]
    public partial class BigRebelTile : NetworkMessage {
        public static int[] Id = { 757,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int16 m_cfg_id;
        public CreepInfo m_creep_data;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {
                m_creep_data = new CreepInfo();
                m_creep_data.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_stat);}
            if (sp.TryWrite(4)) {sp.Write(m_cfg_id);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_creep_data.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(BigRebelTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
            m_creep_data = source.m_creep_data;
        }
    }
    
    [Serializable]
    public partial class DefaultAgentNtfInfo : NetworkMessage {
        public static int[] Id = { 763,1 };
        public static Ctrl VC;
        public Boolean m_has_agent;
        public Int16 m_current_agent;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_has_agent = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_current_agent = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_has_agent);}
            if (sp.TryWrite(1)) {sp.Write(m_current_agent);}
            sp.EnEnd();
        }
        public void CopyFrom(DefaultAgentNtfInfo source) {
            m_has_agent = source.m_has_agent;
            m_current_agent = source.m_current_agent;
        }
    }
    
    [Serializable]
    public partial class UserIconListNtfInfo : NetworkMessage {
        public static int[] Id = { 769,1 };
        public static Ctrl VC;
        public List<Int16> m_icon_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_icon_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_icon_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_icon_list.Count);
                for (int i = 0; i != m_icon_list.Count; ++i) {
                    sp.Write(m_icon_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserIconListNtfInfo source) {
            m_icon_list = source.m_icon_list;
        }
    }
    
    [Serializable]
    public partial class DynamicClientDataPair : NetworkMessage {
        public static int[] Id = { 775,1 };
        public static Ctrl VC;
        public String m_key = "";
        public String m_value = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key = sp.ReadString();}
            if (sp.TryRead(1)) {m_value = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            sp.EnEnd();
        }
        public void CopyFrom(DynamicClientDataPair source) {
            m_key = source.m_key;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class BindNtfData : NetworkMessage {
        public static int[] Id = { 781,1 };
        public static Ctrl VC;
        public String m_login_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_login_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_login_name);}
            sp.EnEnd();
        }
        public void CopyFrom(BindNtfData source) {
            m_login_name = source.m_login_name;
        }
    }
    
    [Serializable]
    public partial class CreateMarchReqInfo : NetworkMessage {
        public static int[] Id = { 787,1 };
        public static Ctrl VC;
        public MapUnitId m_target;
        public MapUnitId m_source;
        public Int16 m_march_type;
        public Int16 m_subtype;
        public Int64 m_group;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Int16 m_hero_id;
        public List<Int16> m_agent = new List<Int16>();
        public Boolean m_encamp;
        public Int64 m_map_guid;
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;
        public String m_target_extra_data = "";
        public Int16 m_troop_skin_id;
        public Boolean m_building_and_reinforce;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_target = new MapUnitId();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_source = new MapUnitId();
                m_source.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_march_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_group = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_encamp = sp.ReadBoolean();}
            if (sp.TryRead(9)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_target_extra_data = sp.ReadString();}
            if (sp.TryRead(13)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_building_and_reinforce = sp.ReadBoolean();}
            if (sp.TryRead(15)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_source.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_march_type);}
            if (sp.TryWrite(3)) {sp.Write(m_subtype);}
            if (sp.TryWrite(4)) {sp.Write(m_group);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_encamp);}
            if (sp.TryWrite(9)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(10)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(11)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(12)) {sp.Write(m_target_extra_data);}
            if (sp.TryWrite(13)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(14)) {sp.Write(m_building_and_reinforce);}
            if (sp.TryWrite(15)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CreateMarchReqInfo source) {
            m_target = source.m_target;
            m_source = source.m_source;
            m_march_type = source.m_march_type;
            m_subtype = source.m_subtype;
            m_group = source.m_group;
            m_troops = source.m_troops;
            m_hero_id = source.m_hero_id;
            m_agent = source.m_agent;
            m_encamp = source.m_encamp;
            m_map_guid = source.m_map_guid;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
            m_target_extra_data = source.m_target_extra_data;
            m_troop_skin_id = source.m_troop_skin_id;
            m_building_and_reinforce = source.m_building_and_reinforce;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class RoundFighterInfo : NetworkMessage {
        public static int[] Id = { 793,1 };
        public static Ctrl VC;
        public MapUnitId m_id;
        public Boolean m_is_active;
        public Int32 m_energy;
        public Int32 m_attack_lost;
        public Int32 m_skill_lost;
        public Int32 m_cure_cnt;
        public Int64 m_init_troop;
        public List<Int16> m_heroes = new List<Int16>();
        public List<ArmyInfo> m_armies = new List<ArmyInfo>();
        public List<EffectCastInfo> m_effect_cast = new List<EffectCastInfo>();
        public List<EffectCastInfo> m_warship_effect_cast = new List<EffectCastInfo>();
        public Int32 m_warship_energy;
        public Int32 m_warship_energy_max;
        public Int32 m_attacker_num;
        public List<Int32> m_aura_ids = new List<Int32>();
        public List<SuperpositionEffectInfo> m_superposition_effect_infos = new List<SuperpositionEffectInfo>();
        public Int16 m_battle_banner_id;
        public Boolean m_is_pvp;
        public Int32 m_consecutive_win_num;
        public Int64 m_new_attack_lost;
        public Int64 m_new_skill_lost;
        public Int64 m_new_cure_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_id = new MapUnitId();
                m_id.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_is_active = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_energy = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_attack_lost = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_skill_lost = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_cure_cnt = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_init_troop = sp.ReadInt64();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_heroes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_heroes.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_armies.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_armies.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_effect_cast.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EffectCastInfo tmp = new EffectCastInfo();
                    tmp.Decode(sp);
                    m_effect_cast.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_warship_effect_cast.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EffectCastInfo tmp = new EffectCastInfo();
                    tmp.Decode(sp);
                    m_warship_effect_cast.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_warship_energy = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_warship_energy_max = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_attacker_num = sp.ReadInt32();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_superposition_effect_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SuperpositionEffectInfo tmp = new SuperpositionEffectInfo();
                    tmp.Decode(sp);
                    m_superposition_effect_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_battle_banner_id = sp.ReadInt16();}
            if (sp.TryRead(17)) {m_is_pvp = sp.ReadBoolean();}
            if (sp.TryRead(18)) {m_consecutive_win_num = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_new_attack_lost = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_new_skill_lost = sp.ReadInt64();}
            if (sp.TryRead(21)) {m_new_cure_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_id.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_is_active);}
            if (sp.TryWrite(2)) {sp.Write(m_energy);}
            if (sp.TryWrite(3)) {sp.Write(m_attack_lost);}
            if (sp.TryWrite(4)) {sp.Write(m_skill_lost);}
            if (sp.TryWrite(5)) {sp.Write(m_cure_cnt);}
            if (sp.TryWrite(6)) {sp.Write(m_init_troop);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_heroes.Count);
                for (int i = 0; i != m_heroes.Count; ++i) {
                    sp.Write(m_heroes[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_armies.Count);
                for (int i = 0; i != m_armies.Count; ++i) {
                    m_armies[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_effect_cast.Count);
                for (int i = 0; i != m_effect_cast.Count; ++i) {
                    m_effect_cast[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_warship_effect_cast.Count);
                for (int i = 0; i != m_warship_effect_cast.Count; ++i) {
                    m_warship_effect_cast[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_warship_energy);}
            if (sp.TryWrite(12)) {sp.Write(m_warship_energy_max);}
            if (sp.TryWrite(13)) {sp.Write(m_attacker_num);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_superposition_effect_infos.Count);
                for (int i = 0; i != m_superposition_effect_infos.Count; ++i) {
                    m_superposition_effect_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(16)) {sp.Write(m_battle_banner_id);}
            if (sp.TryWrite(17)) {sp.Write(m_is_pvp);}
            if (sp.TryWrite(18)) {sp.Write(m_consecutive_win_num);}
            if (sp.TryWrite(19)) {sp.Write(m_new_attack_lost);}
            if (sp.TryWrite(20)) {sp.Write(m_new_skill_lost);}
            if (sp.TryWrite(21)) {sp.Write(m_new_cure_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(RoundFighterInfo source) {
            m_id = source.m_id;
            m_is_active = source.m_is_active;
            m_energy = source.m_energy;
            m_attack_lost = source.m_attack_lost;
            m_skill_lost = source.m_skill_lost;
            m_cure_cnt = source.m_cure_cnt;
            m_init_troop = source.m_init_troop;
            m_heroes = source.m_heroes;
            m_armies = source.m_armies;
            m_effect_cast = source.m_effect_cast;
            m_warship_effect_cast = source.m_warship_effect_cast;
            m_warship_energy = source.m_warship_energy;
            m_warship_energy_max = source.m_warship_energy_max;
            m_attacker_num = source.m_attacker_num;
            m_aura_ids = source.m_aura_ids;
            m_superposition_effect_infos = source.m_superposition_effect_infos;
            m_battle_banner_id = source.m_battle_banner_id;
            m_is_pvp = source.m_is_pvp;
            m_consecutive_win_num = source.m_consecutive_win_num;
            m_new_attack_lost = source.m_new_attack_lost;
            m_new_skill_lost = source.m_new_skill_lost;
            m_new_cure_cnt = source.m_new_cure_cnt;
        }
    }
    
    [Serializable]
    public partial class CultureAgentSkillInfo : NetworkMessage {
        public static int[] Id = { 799,1 };
        public static Ctrl VC;
        public SByte m_index;
        public Int16 m_skill_id;
        public Int16 m_skill_level;
        public Int32 m_replaced;
        public Int16 m_effect_add_skill_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_skill_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_skill_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_replaced = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_effect_add_skill_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(2)) {sp.Write(m_skill_level);}
            if (sp.TryWrite(3)) {sp.Write(m_replaced);}
            if (sp.TryWrite(4)) {sp.Write(m_effect_add_skill_level);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentSkillInfo source) {
            m_index = source.m_index;
            m_skill_id = source.m_skill_id;
            m_skill_level = source.m_skill_level;
            m_replaced = source.m_replaced;
            m_effect_add_skill_level = source.m_effect_add_skill_level;
        }
    }
    
    [Serializable]
    public partial class AgentTalentInfoReqInfo : NetworkMessage {
        public static int[] Id = { 805,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentTalentInfoReqInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTableList : NetworkMessage {
        public static int[] Id = { 811,1 };
        public static Ctrl VC;
        public List<CultureAgentStarTable> m_star_table = new List<CultureAgentStarTable>();
        public List<CultureAgentLevelTable> m_level_table = new List<CultureAgentLevelTable>();
        public List<CultureAgentTalentTable> m_talent_table = new List<CultureAgentTalentTable>();
        public List<CultureAgentRankTable> m_rank_table = new List<CultureAgentRankTable>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_star_table.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentStarTable tmp = new CultureAgentStarTable();
                    tmp.Decode(sp);
                    m_star_table.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_table.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentLevelTable tmp = new CultureAgentLevelTable();
                    tmp.Decode(sp);
                    m_level_table.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_talent_table.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalentTable tmp = new CultureAgentTalentTable();
                    tmp.Decode(sp);
                    m_talent_table.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_table.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentRankTable tmp = new CultureAgentRankTable();
                    tmp.Decode(sp);
                    m_rank_table.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_star_table.Count);
                for (int i = 0; i != m_star_table.Count; ++i) {
                    m_star_table[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_table.Count);
                for (int i = 0; i != m_level_table.Count; ++i) {
                    m_level_table[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_talent_table.Count);
                for (int i = 0; i != m_talent_table.Count; ++i) {
                    m_talent_table[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_table.Count);
                for (int i = 0; i != m_rank_table.Count; ++i) {
                    m_rank_table[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTableList source) {
            m_star_table = source.m_star_table;
            m_level_table = source.m_level_table;
            m_talent_table = source.m_talent_table;
            m_rank_table = source.m_rank_table;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalentList : NetworkMessage {
        public static int[] Id = { 817,1 };
        public static Ctrl VC;
        public List<CultureAgentTalentInfo> m_list = new List<CultureAgentTalentInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalentInfo tmp = new CultureAgentTalentInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalentList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AllianceBuildingStateList : NetworkMessage {
        public static int[] Id = { 823,1 };
        public static Ctrl VC;
        public List<AllianceBuildingState> m_list = new List<AllianceBuildingState>();
        public Int32 m_max_tower;
        public List<ServerAllianceBuildingStateList> m_server_building_state = new List<ServerAllianceBuildingStateList>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBuildingState tmp = new AllianceBuildingState();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_max_tower = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_building_state.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ServerAllianceBuildingStateList tmp = new ServerAllianceBuildingStateList();
                    tmp.Decode(sp);
                    m_server_building_state.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_max_tower);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_building_state.Count);
                for (int i = 0; i != m_server_building_state.Count; ++i) {
                    m_server_building_state[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBuildingStateList source) {
            m_list = source.m_list;
            m_max_tower = source.m_max_tower;
            m_server_building_state = source.m_server_building_state;
        }
    }
    
    [Serializable]
    public partial class PutOutFireReqInfo : NetworkMessage {
        public static int[] Id = { 829,1 };
        public static Ctrl VC;
        public Int64 m_building_id;
        public SByte m_type;
        public Int64 m_cost;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_cost = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(PutOutFireReqInfo source) {
            m_building_id = source.m_building_id;
            m_type = source.m_type;
            m_cost = source.m_cost;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class UserMapMarch : NetworkMessage {
        public static int[] Id = { 835,1 };
        public static Ctrl VC;
        public MarchInfo m_march;
        public List<MarchInfo> m_target_march = new List<MarchInfo>();
        public MapBuildingInfo m_target_building;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_march = new MarchInfo();
                m_march.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_target_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_target_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_target_building = new MapBuildingInfo();
                m_target_building.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_march.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_target_march.Count);
                for (int i = 0; i != m_target_march.Count; ++i) {
                    m_target_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_target_building.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(UserMapMarch source) {
            m_march = source.m_march;
            m_target_march = source.m_target_march;
            m_target_building = source.m_target_building;
        }
    }
    
    [Serializable]
    public partial class UnreadRtfMailCountNtfInfo : NetworkMessage {
        public static int[] Id = { 841,1 };
        public static Ctrl VC;
        public List<UnreadRtfMailCountInfo> m_list = new List<UnreadRtfMailCountInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UnreadRtfMailCountInfo tmp = new UnreadRtfMailCountInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UnreadRtfMailCountNtfInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class RtfMailBasicInfo : NetworkMessage {
        public static int[] Id = { 847,1 };
        public static Ctrl VC;
        public String m_mail_id = "";
        public Int16 m_mail_type;
        public Int16 m_mail_ex_type;
        public Byte[] m_mail_header;
        public Boolean m_read;
        public Boolean m_collect;
        public SByte m_award_sign;
        public Int64 m_create_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_mail_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_mail_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_mail_ex_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_mail_header = sp.ReadBytes2();}
            if (sp.TryRead(4)) {m_read = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_collect = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_award_sign = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_create_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_mail_id);}
            if (sp.TryWrite(1)) {sp.Write(m_mail_type);}
            if (sp.TryWrite(2)) {sp.Write(m_mail_ex_type);}
            if (sp.TryWrite(3)) {sp.WriteBytes2(m_mail_header);}
            if (sp.TryWrite(4)) {sp.Write(m_read);}
            if (sp.TryWrite(5)) {sp.Write(m_collect);}
            if (sp.TryWrite(6)) {sp.Write(m_award_sign);}
            if (sp.TryWrite(7)) {sp.Write(m_create_time);}
            sp.EnEnd();
        }
        public void CopyFrom(RtfMailBasicInfo source) {
            m_mail_id = source.m_mail_id;
            m_mail_type = source.m_mail_type;
            m_mail_ex_type = source.m_mail_ex_type;
            m_mail_header = source.m_mail_header;
            m_read = source.m_read;
            m_collect = source.m_collect;
            m_award_sign = source.m_award_sign;
            m_create_time = source.m_create_time;
        }
    }
    
    [Serializable]
    public partial class GetGatherReportListReqInfo : NetworkMessage {
        public static int[] Id = { 853,1 };
        public static Ctrl VC;
        public String m_start_id = "";
        public Boolean m_direction;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_direction = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_id);}
            if (sp.TryWrite(1)) {sp.Write(m_direction);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GetGatherReportListReqInfo source) {
            m_start_id = source.m_start_id;
            m_direction = source.m_direction;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class TavernBoxInfo : NetworkMessage {
        public static int[] Id = { 859,1 };
        public static Ctrl VC;
        public Int16 m_silver_free_open_cnt;
        public Int64 m_silver_next_free_time;
        public Int64 m_gold_next_free_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_silver_free_open_cnt = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_silver_next_free_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_gold_next_free_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_silver_free_open_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_silver_next_free_time);}
            if (sp.TryWrite(2)) {sp.Write(m_gold_next_free_time);}
            sp.EnEnd();
        }
        public void CopyFrom(TavernBoxInfo source) {
            m_silver_free_open_cnt = source.m_silver_free_open_cnt;
            m_silver_next_free_time = source.m_silver_next_free_time;
            m_gold_next_free_time = source.m_gold_next_free_time;
        }
    }
    
    [Serializable]
    public partial class MapMilestoneQuestRecord : NetworkMessage {
        public static int[] Id = { 865,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_end_time;
        public Int64 m_finish_time;
        public Boolean m_awarded;
        public List<AllianceRankInfo> m_rank = new List<AllianceRankInfo>();
        public Int64 m_prog;
        public Boolean m_out_date;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_finish_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_awarded = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceRankInfo tmp = new AllianceRankInfo();
                    tmp.Decode(sp);
                    m_rank.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_prog = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_out_date = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_finish_time);}
            if (sp.TryWrite(3)) {sp.Write(m_awarded);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank.Count);
                for (int i = 0; i != m_rank.Count; ++i) {
                    m_rank[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_prog);}
            if (sp.TryWrite(6)) {sp.Write(m_out_date);}
            sp.EnEnd();
        }
        public void CopyFrom(MapMilestoneQuestRecord source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
            m_finish_time = source.m_finish_time;
            m_awarded = source.m_awarded;
            m_rank = source.m_rank;
            m_prog = source.m_prog;
            m_out_date = source.m_out_date;
        }
    }
    
    [Serializable]
    public partial class CumulativeChargeInfo : NetworkMessage {
        public static int[] Id = { 871,1 };
        public static Ctrl VC;
        public Int64 m_cur_score;
        public Int64 m_score_limit;
        public List<ItemInfo> m_awd = new List<ItemInfo>();
        public Int64 m_value;
        public String m_pic = "";
        public String m_desc = "";
        public Int16 m_pic_box;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_score = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_score_limit = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_awd.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_awd.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_value = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_pic = sp.ReadString();}
            if (sp.TryRead(5)) {m_desc = sp.ReadString();}
            if (sp.TryRead(6)) {m_pic_box = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_score);}
            if (sp.TryWrite(1)) {sp.Write(m_score_limit);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_awd.Count);
                for (int i = 0; i != m_awd.Count; ++i) {
                    m_awd[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_value);}
            if (sp.TryWrite(4)) {sp.Write(m_pic);}
            if (sp.TryWrite(5)) {sp.Write(m_desc);}
            if (sp.TryWrite(6)) {sp.Write(m_pic_box);}
            sp.EnEnd();
        }
        public void CopyFrom(CumulativeChargeInfo source) {
            m_cur_score = source.m_cur_score;
            m_score_limit = source.m_score_limit;
            m_awd = source.m_awd;
            m_value = source.m_value;
            m_pic = source.m_pic;
            m_desc = source.m_desc;
            m_pic_box = source.m_pic_box;
        }
    }
    
    [Serializable]
    public partial class AllianceFortuneGiftAckInfo : NetworkMessage {
        public static int[] Id = { 877,1 };
        public static Ctrl VC;
        public Int16 m_count;
        public Int64 m_expire_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_count = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_expire_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_count);}
            if (sp.TryWrite(1)) {sp.Write(m_expire_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceFortuneGiftAckInfo source) {
            m_count = source.m_count;
            m_expire_dt = source.m_expire_dt;
        }
    }
    
    [Serializable]
    public partial class ProgressCampaignInfo : NetworkMessage {
        public static int[] Id = { 883,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseProgressCampaignInfo> m_task_info = new List<BaseProgressCampaignInfo>();
        public Int64 m_current_points;
        public Int16 m_count_method;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseProgressCampaignInfo tmp = new BaseProgressCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_current_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_count_method = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_info.Count);
                for (int i = 0; i != m_task_info.Count; ++i) {
                    m_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_current_points);}
            if (sp.TryWrite(3)) {sp.Write(m_count_method);}
            sp.EnEnd();
        }
        public void CopyFrom(ProgressCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
            m_current_points = source.m_current_points;
            m_count_method = source.m_count_method;
        }
    }
    
    [Serializable]
    public partial class StartExpeditionAckInfo : NetworkMessage {
        public static int[] Id = { 889,1 };
        public static Ctrl VC;
        public Int64 m_room_id;
        public List<UserMapMarch> m_player_march = new List<UserMapMarch>();
        public List<UserMapMarch> m_enemy_march = new List<UserMapMarch>();
        public Int32 m_client_custom_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_room_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_player_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMapMarch tmp = new UserMapMarch();
                    tmp.Decode(sp);
                    m_player_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_enemy_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMapMarch tmp = new UserMapMarch();
                    tmp.Decode(sp);
                    m_enemy_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_client_custom_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_room_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_player_march.Count);
                for (int i = 0; i != m_player_march.Count; ++i) {
                    m_player_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_enemy_march.Count);
                for (int i = 0; i != m_enemy_march.Count; ++i) {
                    m_enemy_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_client_custom_id);}
            sp.EnEnd();
        }
        public void CopyFrom(StartExpeditionAckInfo source) {
            m_room_id = source.m_room_id;
            m_player_march = source.m_player_march;
            m_enemy_march = source.m_enemy_march;
            m_client_custom_id = source.m_client_custom_id;
        }
    }
    
    [Serializable]
    public partial class AllMonumentInfo : NetworkMessage {
        public static int[] Id = { 895,1 };
        public static Ctrl VC;
        public List<MbMonumentSnapInfo> m_list = new List<MbMonumentSnapInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MbMonumentSnapInfo tmp = new MbMonumentSnapInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllMonumentInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ExpeditionCheckpointEndNtfInfo : NetworkMessage {
        public static int[] Id = { 901,1 };
        public static Ctrl VC;
        public SByte m_result;
        public ExpeditionCheckpointStateInfo m_state;
        public Boolean m_star1;
        public Boolean m_star2;
        public Boolean m_star3;
        public Boolean m_star1_reward;
        public Boolean m_star2_reward;
        public Boolean m_star3_reward;
        public Boolean m_first_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_result = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_state = new ExpeditionCheckpointStateInfo();
                m_state.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_star1 = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_star2 = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_star3 = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_star1_reward = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_star2_reward = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_star3_reward = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_first_reward = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_result);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_state.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_star1);}
            if (sp.TryWrite(3)) {sp.Write(m_star2);}
            if (sp.TryWrite(4)) {sp.Write(m_star3);}
            if (sp.TryWrite(5)) {sp.Write(m_star1_reward);}
            if (sp.TryWrite(6)) {sp.Write(m_star2_reward);}
            if (sp.TryWrite(7)) {sp.Write(m_star3_reward);}
            if (sp.TryWrite(8)) {sp.Write(m_first_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionCheckpointEndNtfInfo source) {
            m_result = source.m_result;
            m_state = source.m_state;
            m_star1 = source.m_star1;
            m_star2 = source.m_star2;
            m_star3 = source.m_star3;
            m_star1_reward = source.m_star1_reward;
            m_star2_reward = source.m_star2_reward;
            m_star3_reward = source.m_star3_reward;
            m_first_reward = source.m_first_reward;
        }
    }
    
    [Serializable]
    public partial class MapExploreStatusInfo : NetworkMessage {
        public static int[] Id = { 907,1 };
        public static Ctrl VC;
        public Int16 m_aty_level;
        public Int32 m_fuel_point;
        public Int32 m_fuel_coin;
        public Int64 m_last_fuel_update_time;
        public Int64 m_explore_start_time;
        public Int64 m_explore_end_time;
        public Int32 m_daily_explore_times;
        public Int32 m_daily_fuel_count;
        public List<MapExploreVirtualPoint> m_points = new List<MapExploreVirtualPoint>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_aty_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_fuel_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_fuel_coin = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_last_fuel_update_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_explore_start_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_explore_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_daily_explore_times = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_daily_fuel_count = sp.ReadInt32();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_points.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapExploreVirtualPoint tmp = new MapExploreVirtualPoint();
                    tmp.Decode(sp);
                    m_points.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_aty_level);}
            if (sp.TryWrite(1)) {sp.Write(m_fuel_point);}
            if (sp.TryWrite(2)) {sp.Write(m_fuel_coin);}
            if (sp.TryWrite(3)) {sp.Write(m_last_fuel_update_time);}
            if (sp.TryWrite(4)) {sp.Write(m_explore_start_time);}
            if (sp.TryWrite(5)) {sp.Write(m_explore_end_time);}
            if (sp.TryWrite(6)) {sp.Write(m_daily_explore_times);}
            if (sp.TryWrite(7)) {sp.Write(m_daily_fuel_count);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_points.Count);
                for (int i = 0; i != m_points.Count; ++i) {
                    m_points[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreStatusInfo source) {
            m_aty_level = source.m_aty_level;
            m_fuel_point = source.m_fuel_point;
            m_fuel_coin = source.m_fuel_coin;
            m_last_fuel_update_time = source.m_last_fuel_update_time;
            m_explore_start_time = source.m_explore_start_time;
            m_explore_end_time = source.m_explore_end_time;
            m_daily_explore_times = source.m_daily_explore_times;
            m_daily_fuel_count = source.m_daily_fuel_count;
            m_points = source.m_points;
        }
    }
    
    [Serializable]
    public partial class MapExploreRelocatePointReqInfo : NetworkMessage {
        public static int[] Id = { 913,1 };
        public static Ctrl VC;
        public SByte m_point_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_point_index = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_point_index);}
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreRelocatePointReqInfo source) {
            m_point_index = source.m_point_index;
        }
    }
    
    [Serializable]
    public partial class ExpeditionStoreItem : NetworkMessage {
        public static int[] Id = { 919,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int32 m_purchased;
        public Int32 m_limit;
        public Int64 m_coin_req;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_purchased = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_limit = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_coin_req = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_purchased);}
            if (sp.TryWrite(3)) {sp.Write(m_limit);}
            if (sp.TryWrite(4)) {sp.Write(m_coin_req);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionStoreItem source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_purchased = source.m_purchased;
            m_limit = source.m_limit;
            m_coin_req = source.m_coin_req;
        }
    }
    
    [Serializable]
    public partial class AssignAgentReqInfo : NetworkMessage {
        public static int[] Id = { 925,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AssignAgentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class UnfinishedLandRect : NetworkMessage {
        public static int[] Id = { 931,1 };
        public static Ctrl VC;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_w;
        public Int16 m_h;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_w = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_h = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            if (sp.TryWrite(2)) {sp.Write(m_w);}
            if (sp.TryWrite(3)) {sp.Write(m_h);}
            sp.EnEnd();
        }
        public void CopyFrom(UnfinishedLandRect source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_w = source.m_w;
            m_h = source.m_h;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelCampaignHistoryList : NetworkMessage {
        public static int[] Id = { 937,1 };
        public static Ctrl VC;
        public List<AllianceRebelCampaignHistory> m_list = new List<AllianceRebelCampaignHistory>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceRebelCampaignHistory tmp = new AllianceRebelCampaignHistory();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelCampaignHistoryList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AsRebelMarchInfoAckInfo : NetworkMessage {
        public static int[] Id = { 943,1 };
        public static Ctrl VC;
        public Int16 m_round;
        public SByte m_type;
        public String m_abbr = "";
        public String m_name = "";
        public Int64 m_from_building_id;
        public Int16 m_from_x;
        public Int16 m_from_y;
        public Int16 m_to_x;
        public Int16 m_to_y;
        public Int64 m_to_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_round = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_from_building_id = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_from_x = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_from_y = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_to_x = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_to_y = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_to_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_round);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_name);}
            if (sp.TryWrite(4)) {sp.Write(m_from_building_id);}
            if (sp.TryWrite(5)) {sp.Write(m_from_x);}
            if (sp.TryWrite(6)) {sp.Write(m_from_y);}
            if (sp.TryWrite(7)) {sp.Write(m_to_x);}
            if (sp.TryWrite(8)) {sp.Write(m_to_y);}
            if (sp.TryWrite(9)) {sp.Write(m_to_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AsRebelMarchInfoAckInfo source) {
            m_round = source.m_round;
            m_type = source.m_type;
            m_abbr = source.m_abbr;
            m_name = source.m_name;
            m_from_building_id = source.m_from_building_id;
            m_from_x = source.m_from_x;
            m_from_y = source.m_from_y;
            m_to_x = source.m_to_x;
            m_to_y = source.m_to_y;
            m_to_user_id = source.m_to_user_id;
        }
    }
    
    [Serializable]
    public partial class RailwayShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 949,1 };
        public static Ctrl VC;
        public Int32 m_goods_id;
        public Int16 m_goods_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_goods_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_goods_index = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_goods_id);}
            if (sp.TryWrite(1)) {sp.Write(m_goods_index);}
            sp.EnEnd();
        }
        public void CopyFrom(RailwayShopBuyReqInfo source) {
            m_goods_id = source.m_goods_id;
            m_goods_index = source.m_goods_index;
        }
    }
    
    [Serializable]
    public partial class GovInfo : NetworkMessage {
        public static int[] Id = { 955,1 };
        public static Ctrl VC;
        public List<GovTitle> m_officer = new List<GovTitle>();
        public Int64 m_buff_cd;
        public List<GovBuff> m_buff_list = new List<GovBuff>();
        public List<GovLoot> m_loot = new List<GovLoot>();
        public List<GovLootCfg> m_loot_cfg = new List<GovLootCfg>();
        public List<GovSkill> m_skill_list = new List<GovSkill>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_officer.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovTitle tmp = new GovTitle();
                    tmp.Decode(sp);
                    m_officer.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_buff_cd = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buff_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovBuff tmp = new GovBuff();
                    tmp.Decode(sp);
                    m_buff_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_loot.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovLoot tmp = new GovLoot();
                    tmp.Decode(sp);
                    m_loot.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_loot_cfg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovLootCfg tmp = new GovLootCfg();
                    tmp.Decode(sp);
                    m_loot_cfg.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skill_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovSkill tmp = new GovSkill();
                    tmp.Decode(sp);
                    m_skill_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_officer.Count);
                for (int i = 0; i != m_officer.Count; ++i) {
                    m_officer[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_buff_cd);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_list.Count);
                for (int i = 0; i != m_buff_list.Count; ++i) {
                    m_buff_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_loot.Count);
                for (int i = 0; i != m_loot.Count; ++i) {
                    m_loot[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_loot_cfg.Count);
                for (int i = 0; i != m_loot_cfg.Count; ++i) {
                    m_loot_cfg[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skill_list.Count);
                for (int i = 0; i != m_skill_list.Count; ++i) {
                    m_skill_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GovInfo source) {
            m_officer = source.m_officer;
            m_buff_cd = source.m_buff_cd;
            m_buff_list = source.m_buff_list;
            m_loot = source.m_loot;
            m_loot_cfg = source.m_loot_cfg;
            m_skill_list = source.m_skill_list;
        }
    }
    
    [Serializable]
    public partial class SetGovTitleReqInfo : NetworkMessage {
        public static int[] Id = { 961,1 };
        public static Ctrl VC;
        public Int32 m_title_id;
        public Int64 m_player_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetGovTitleReqInfo source) {
            m_title_id = source.m_title_id;
            m_player_id = source.m_player_id;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignRollReqInfo : NetworkMessage {
        public static int[] Id = { 967,1 };
        public static Ctrl VC;
        public CampaignReqItemInfo m_aty_item;
        public SByte m_roll_method;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_aty_item = new CampaignReqItemInfo();
                m_aty_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_roll_method = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_aty_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_roll_method);}
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignRollReqInfo source) {
            m_aty_item = source.m_aty_item;
            m_roll_method = source.m_roll_method;
        }
    }
    
    [Serializable]
    public partial class DailySubscriptionInfo : NetworkMessage {
        public static int[] Id = { 973,1 };
        public static Ctrl VC;
        public Int32 m_pkg_id;
        public Int64 m_endtime;
        public Boolean m_claimed;
        public Int64 m_claim_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_claimed = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_claim_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(1)) {sp.Write(m_endtime);}
            if (sp.TryWrite(2)) {sp.Write(m_claimed);}
            if (sp.TryWrite(3)) {sp.Write(m_claim_time);}
            sp.EnEnd();
        }
        public void CopyFrom(DailySubscriptionInfo source) {
            m_pkg_id = source.m_pkg_id;
            m_endtime = source.m_endtime;
            m_claimed = source.m_claimed;
            m_claim_time = source.m_claim_time;
        }
    }
    
    [Serializable]
    public partial class RebatePackageInfo : NetworkMessage {
        public static int[] Id = { 979,1 };
        public static Ctrl VC;
        public List<Int32> m_active_pkg = new List<Int32>();
        public List<Int16> m_claimed_reward = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_active_pkg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_active_pkg.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_claimed_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_claimed_reward.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_active_pkg.Count);
                for (int i = 0; i != m_active_pkg.Count; ++i) {
                    sp.Write(m_active_pkg[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_claimed_reward.Count);
                for (int i = 0; i != m_claimed_reward.Count; ++i) {
                    sp.Write(m_claimed_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RebatePackageInfo source) {
            m_active_pkg = source.m_active_pkg;
            m_claimed_reward = source.m_claimed_reward;
        }
    }
    
    [Serializable]
    public partial class RechargeCampaignCfg : NetworkMessage {
        public static int[] Id = { 985,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_unlock;
        public Int64 m_diamond_req;
        public String m_key = "";
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Boolean m_is_claimed;
        public String m_close_pic = "";
        public String m_open_pic = "";
        public Boolean m_rewards_review;
        public List<String> m_super_pkg_titles = new List<String>();
        public Int32 m_super_pkg_multiple;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_unlock = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_diamond_req = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_key = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_is_claimed = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_close_pic = sp.ReadString();}
            if (sp.TryRead(7)) {m_open_pic = sp.ReadString();}
            if (sp.TryRead(8)) {m_rewards_review = sp.ReadBoolean();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_super_pkg_titles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_super_pkg_titles.Add(tmp);
                }
            }
            if (sp.TryRead(10)) {m_super_pkg_multiple = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_unlock);}
            if (sp.TryWrite(2)) {sp.Write(m_diamond_req);}
            if (sp.TryWrite(3)) {sp.Write(m_key);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_is_claimed);}
            if (sp.TryWrite(6)) {sp.Write(m_close_pic);}
            if (sp.TryWrite(7)) {sp.Write(m_open_pic);}
            if (sp.TryWrite(8)) {sp.Write(m_rewards_review);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_super_pkg_titles.Count);
                for (int i = 0; i != m_super_pkg_titles.Count; ++i) {
                    sp.Write(m_super_pkg_titles[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(10)) {sp.Write(m_super_pkg_multiple);}
            sp.EnEnd();
        }
        public void CopyFrom(RechargeCampaignCfg source) {
            m_id = source.m_id;
            m_unlock = source.m_unlock;
            m_diamond_req = source.m_diamond_req;
            m_key = source.m_key;
            m_items = source.m_items;
            m_is_claimed = source.m_is_claimed;
            m_close_pic = source.m_close_pic;
            m_open_pic = source.m_open_pic;
            m_rewards_review = source.m_rewards_review;
            m_super_pkg_titles = source.m_super_pkg_titles;
            m_super_pkg_multiple = source.m_super_pkg_multiple;
        }
    }
    
    [Serializable]
    public partial class CampaignPopupInfo : NetworkMessage {
        public static int[] Id = { 991,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public String m_act_name = "";
        public Int16 m_daily_popup_max;
        public Int64 m_daily_popup_interval;
        public Int32 m_popup_order;
        public String m_popup_banner = "";
        public String m_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_act_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_daily_popup_max = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_daily_popup_interval = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_popup_order = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_popup_banner = sp.ReadString();}
            if (sp.TryRead(6)) {m_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_act_name);}
            if (sp.TryWrite(2)) {sp.Write(m_daily_popup_max);}
            if (sp.TryWrite(3)) {sp.Write(m_daily_popup_interval);}
            if (sp.TryWrite(4)) {sp.Write(m_popup_order);}
            if (sp.TryWrite(5)) {sp.Write(m_popup_banner);}
            if (sp.TryWrite(6)) {sp.Write(m_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignPopupInfo source) {
            m_act_id = source.m_act_id;
            m_act_name = source.m_act_name;
            m_daily_popup_max = source.m_daily_popup_max;
            m_daily_popup_interval = source.m_daily_popup_interval;
            m_popup_order = source.m_popup_order;
            m_popup_banner = source.m_popup_banner;
            m_desc = source.m_desc;
        }
    }
    
    [Serializable]
    public partial class UserCostCampaignDiamondRule : NetworkMessage {
        public static int[] Id = { 997,1 };
        public static Ctrl VC;
        public Int32 m_cost_id;
        public Int64 m_src_cnt;
        public Int64 m_base_score;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public String m_src_pic = "";
        public String m_dst_pic = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cost_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_src_cnt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_base_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_src_pic = sp.ReadString();}
            if (sp.TryRead(5)) {m_dst_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_id);}
            if (sp.TryWrite(1)) {sp.Write(m_src_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_base_score);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_src_pic);}
            if (sp.TryWrite(5)) {sp.Write(m_dst_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCostCampaignDiamondRule source) {
            m_cost_id = source.m_cost_id;
            m_src_cnt = source.m_src_cnt;
            m_base_score = source.m_base_score;
            m_reward = source.m_reward;
            m_src_pic = source.m_src_pic;
            m_dst_pic = source.m_dst_pic;
        }
    }
    
    [Serializable]
    public partial class CostActivityCostOnce : NetworkMessage {
        public static int[] Id = { 1003,1 };
        public static Ctrl VC;
        public Boolean m_exchange;
        public Int64 m_add_score;
        public SByte m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exchange = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_add_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_time = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exchange);}
            if (sp.TryWrite(1)) {sp.Write(m_add_score);}
            if (sp.TryWrite(2)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(CostActivityCostOnce source) {
            m_exchange = source.m_exchange;
            m_add_score = source.m_add_score;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class ProgressiveTaskFinalRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1009,1 };
        public static Ctrl VC;
        public Int64 m_act_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ProgressiveTaskFinalRewardReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class ChangeFactionReqInfo : NetworkMessage {
        public static int[] Id = { 1015,1 };
        public static Ctrl VC;
        public Int16 m_faction;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_faction = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_faction);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeFactionReqInfo source) {
            m_faction = source.m_faction;
        }
    }
    
    [Serializable]
    public partial class AllianceShopRestockReqInfo : NetworkMessage {
        public static int[] Id = { 1021,1 };
        public static Ctrl VC;
        public List<Int32> m_stock = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_stock.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_stock.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_stock.Count);
                for (int i = 0; i != m_stock.Count; ++i) {
                    sp.Write(m_stock[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopRestockReqInfo source) {
            m_stock = source.m_stock;
        }
    }
    
    [Serializable]
    public partial class SetCitySkinReqInfo : NetworkMessage {
        public static int[] Id = { 1027,1 };
        public static Ctrl VC;
        public Int16 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetCitySkinReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class FogData2 : NetworkMessage {
        public static int[] Id = { 1033,2 };
        public static Ctrl VC;
        public SByte m_pos;
        public UInt64 m_data;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pos = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_data = sp.ReadUInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pos);}
            if (sp.TryWrite(1)) {sp.Write(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(FogData2 source) {
            m_pos = source.m_pos;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class OpenFogNtfInfo : NetworkMessage {
        public static int[] Id = { 1039,2 };
        public static Ctrl VC;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_w;
        public Int16 m_h;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_w = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_h = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            if (sp.TryWrite(2)) {sp.Write(m_w);}
            if (sp.TryWrite(3)) {sp.Write(m_h);}
            sp.EnEnd();
        }
        public void CopyFrom(OpenFogNtfInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_w = source.m_w;
            m_h = source.m_h;
        }
    }
    
    [Serializable]
    public partial class LadderCampaignInfo : NetworkMessage {
        public static int[] Id = { 1045,3 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<LadderDifficultyInfo> m_difficulty_info = new List<LadderDifficultyInfo>();
        public LadderStatusInfo m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_difficulty_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderDifficultyInfo tmp = new LadderDifficultyInfo();
                    tmp.Decode(sp);
                    m_difficulty_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_status = new LadderStatusInfo();
                m_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_difficulty_info.Count);
                for (int i = 0; i != m_difficulty_info.Count; ++i) {
                    m_difficulty_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_difficulty_info = source.m_difficulty_info;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBossShow : NetworkMessage {
        public static int[] Id = { 1051,3 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_icon = "";
        public String m_desc = "";
        public List<LadderAllianceBossCond> m_cond = new List<LadderAllianceBossCond>();
        public Int32 m_drop_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_desc = sp.ReadString();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cond.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderAllianceBossCond tmp = new LadderAllianceBossCond();
                    tmp.Decode(sp);
                    m_cond.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_drop_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_desc);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cond.Count);
                for (int i = 0; i != m_cond.Count; ++i) {
                    m_cond[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_drop_id);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBossShow source) {
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_desc = source.m_desc;
            m_cond = source.m_cond;
            m_drop_id = source.m_drop_id;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBoardUser : NetworkMessage {
        public static int[] Id = { 1057,3 };
        public static Ctrl VC;
        public LadderUserBrief m_user_info;
        public SByte m_difficulty_level;
        public Int16 m_cur_step;
        public Boolean m_need_help;
        public RealPos m_target_pos;
        public Int64 m_target_march_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_user_info = new LadderUserBrief();
                m_user_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_difficulty_level = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_cur_step = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_need_help = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                m_target_pos = new RealPos();
                m_target_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_target_march_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_user_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_difficulty_level);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(3)) {sp.Write(m_need_help);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_target_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_target_march_id);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBoardUser source) {
            m_user_info = source.m_user_info;
            m_difficulty_level = source.m_difficulty_level;
            m_cur_step = source.m_cur_step;
            m_need_help = source.m_need_help;
            m_target_pos = source.m_target_pos;
            m_target_march_id = source.m_target_march_id;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBossListInfo : NetworkMessage {
        public static int[] Id = { 1063,3 };
        public static Ctrl VC;
        public List<LadderAllianceBossInfo> m_boss_list = new List<LadderAllianceBossInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_boss_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderAllianceBossInfo tmp = new LadderAllianceBossInfo();
                    tmp.Decode(sp);
                    m_boss_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_boss_list.Count);
                for (int i = 0; i != m_boss_list.Count; ++i) {
                    m_boss_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBossListInfo source) {
            m_boss_list = source.m_boss_list;
        }
    }
    
    [Serializable]
    public partial class AllianceGuideCampaign : NetworkMessage {
        public static int[] Id = { 1069,3 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseTaskCampaignInfo> m_score_task_info = new List<BaseTaskCampaignInfo>();
        public List<BaseProgressCampaignInfo> m_reward_task_info = new List<BaseProgressCampaignInfo>();
        public Int64 m_current_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_score_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_score_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseProgressCampaignInfo tmp = new BaseProgressCampaignInfo();
                    tmp.Decode(sp);
                    m_reward_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_current_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_score_task_info.Count);
                for (int i = 0; i != m_score_task_info.Count; ++i) {
                    m_score_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_task_info.Count);
                for (int i = 0; i != m_reward_task_info.Count; ++i) {
                    m_reward_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_current_points);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceGuideCampaign source) {
            m_basic_info = source.m_basic_info;
            m_score_task_info = source.m_score_task_info;
            m_reward_task_info = source.m_reward_task_info;
            m_current_points = source.m_current_points;
        }
    }
    
    [Serializable]
    public partial class TimelimitQuestAwdReq : NetworkMessage {
        public static int[] Id = { 1075,4 };
        public static Ctrl VC;
        public Int16 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(TimelimitQuestAwdReq source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class ArenaPlayerStatInfo : NetworkMessage {
        public static int[] Id = { 1081,4 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_bot_id;
        public String m_user_name = "";
        public Boolean m_win;
        public Int64 m_score;
        public Int64 m_score_old;
        public Int32 m_rank;
        public Int32 m_rank_old;
        public Int16 m_icon;
        public String m_avatar = "";
        public String m_as_name = "";
        public String m_as_abbr = "";
        public Int16 m_as_logo;
        public Int16 m_as_color;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public List<ArenaTroopStatInfo> m_troop_stat = new List<ArenaTroopStatInfo>();
        public Int16 m_server_id;
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_bot_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_win = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_score_old = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_rank_old = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(10)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(11)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(12)) {m_as_logo = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_as_color = sp.ReadInt16();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop_stat.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopStatInfo tmp = new ArenaTroopStatInfo();
                    tmp.Decode(sp);
                    m_troop_stat.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(17)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_bot_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_name);}
            if (sp.TryWrite(3)) {sp.Write(m_win);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {sp.Write(m_score_old);}
            if (sp.TryWrite(6)) {sp.Write(m_rank);}
            if (sp.TryWrite(7)) {sp.Write(m_rank_old);}
            if (sp.TryWrite(8)) {sp.Write(m_icon);}
            if (sp.TryWrite(9)) {sp.Write(m_avatar);}
            if (sp.TryWrite(10)) {sp.Write(m_as_name);}
            if (sp.TryWrite(11)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(12)) {sp.Write(m_as_logo);}
            if (sp.TryWrite(13)) {sp.Write(m_as_color);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop_stat.Count);
                for (int i = 0; i != m_troop_stat.Count; ++i) {
                    m_troop_stat[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(16)) {sp.Write(m_server_id);}
            if (sp.TryWrite(17)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaPlayerStatInfo source) {
            m_user_id = source.m_user_id;
            m_bot_id = source.m_bot_id;
            m_user_name = source.m_user_name;
            m_win = source.m_win;
            m_score = source.m_score;
            m_score_old = source.m_score_old;
            m_rank = source.m_rank;
            m_rank_old = source.m_rank_old;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_as_name = source.m_as_name;
            m_as_abbr = source.m_as_abbr;
            m_as_logo = source.m_as_logo;
            m_as_color = source.m_as_color;
            m_rewards = source.m_rewards;
            m_troop_stat = source.m_troop_stat;
            m_server_id = source.m_server_id;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ArenaFightReqInfo : NetworkMessage {
        public static int[] Id = { 1087,4 };
        public static Ctrl VC;
        public Int64 m_target;
        public Int32 m_bot_id;
        public List<ArenaTroopInfo> m_attack_array = new List<ArenaTroopInfo>();
        public List<ArenaTroopInfo> m_defend_array = new List<ArenaTroopInfo>();
        public Int32 m_tgt_rank;
        public Int64 m_tgt_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_bot_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attack_array.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopInfo tmp = new ArenaTroopInfo();
                    tmp.Decode(sp);
                    m_attack_array.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defend_array.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopInfo tmp = new ArenaTroopInfo();
                    tmp.Decode(sp);
                    m_defend_array.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_tgt_rank = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_tgt_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target);}
            if (sp.TryWrite(1)) {sp.Write(m_bot_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attack_array.Count);
                for (int i = 0; i != m_attack_array.Count; ++i) {
                    m_attack_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defend_array.Count);
                for (int i = 0; i != m_defend_array.Count; ++i) {
                    m_defend_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_tgt_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_tgt_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaFightReqInfo source) {
            m_target = source.m_target;
            m_bot_id = source.m_bot_id;
            m_attack_array = source.m_attack_array;
            m_defend_array = source.m_defend_array;
            m_tgt_rank = source.m_tgt_rank;
            m_tgt_score = source.m_tgt_score;
        }
    }
    
    [Serializable]
    public partial class BattlePassportTask : NetworkMessage {
        public static int[] Id = { 1093,4 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_cur_points;
        public Int64 m_max_points;
        public Boolean m_is_finished;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_max_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_is_finished = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_points);}
            if (sp.TryWrite(2)) {sp.Write(m_max_points);}
            if (sp.TryWrite(3)) {sp.Write(m_is_finished);}
            sp.EnEnd();
        }
        public void CopyFrom(BattlePassportTask source) {
            m_id = source.m_id;
            m_cur_points = source.m_cur_points;
            m_max_points = source.m_max_points;
            m_is_finished = source.m_is_finished;
        }
    }
    
    [Serializable]
    public partial class GatherBuffNtf : NetworkMessage {
        public static int[] Id = { 1099,5 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public Int64 m_end_time;
        public Int32 m_buff_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_buff_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_buff_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GatherBuffNtf source) {
            m_march_id = source.m_march_id;
            m_end_time = source.m_end_time;
            m_buff_id = source.m_buff_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeStatus : NetworkMessage {
        public static int[] Id = { 1105,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public AllianceMobilizeUserTaskStatus m_task_status;
        public AllianceMobilizeProgressInfo m_progress_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_task_status = new AllianceMobilizeUserTaskStatus();
                m_task_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_progress_status = new AllianceMobilizeProgressInfo();
                m_progress_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_task_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_progress_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeStatus source) {
            m_act_id = source.m_act_id;
            m_task_status = source.m_task_status;
            m_progress_status = source.m_progress_status;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeFlushTaskAckInfo : NetworkMessage {
        public static int[] Id = { 1111,5 };
        public static Ctrl VC;
        public Int64 m_cost_diamond;
        public AllianceMobilizeUserTaskStatus m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cost_diamond = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_status = new AllianceMobilizeUserTaskStatus();
                m_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_diamond);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeFlushTaskAckInfo source) {
            m_cost_diamond = source.m_cost_diamond;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskSelectReqInfo : NetworkMessage {
        public static int[] Id = { 1117,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeTaskSelectReqInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskOverdueNtfInfo : NetworkMessage {
        public static int[] Id = { 1123,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeTaskOverdueNtfInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class CastMonumentSkillReqInfo : NetworkMessage {
        public static int[] Id = { 1130,7 };
        public static Ctrl VC;
        public Int64 m_monument_id;
        public Int32 m_skill_id;
        public List<Int32> m_params = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_monument_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_params.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_monument_id);}
            if (sp.TryWrite(1)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_params.Count);
                for (int i = 0; i != m_params.Count; ++i) {
                    sp.Write(m_params[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CastMonumentSkillReqInfo source) {
            m_monument_id = source.m_monument_id;
            m_skill_id = source.m_skill_id;
            m_params = source.m_params;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerCheckoutReq : NetworkMessage {
        public static int[] Id = { 1136,8 };
        public static Ctrl VC;
        public Int32 m_target_server;
        public Int16 m_trans_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_server = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_trans_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_server);}
            if (sp.TryWrite(1)) {sp.Write(m_trans_type);}
            sp.EnEnd();
        }
        public void CopyFrom(B2TransferServerCheckoutReq source) {
            m_target_server = source.m_target_server;
            m_trans_type = source.m_trans_type;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerDisInfoAck : NetworkMessage {
        public static int[] Id = { 1142,8 };
        public static Ctrl VC;
        public Int32 m_target_server;
        public String m_king_name = "";
        public Int64 m_open_time;
        public Int64 m_dis_open_time;
        public Int32 m_item_cost;
        public Int64 m_max_power_limit;
        public Int64 m_default_max_power_limit;
        public Int16 m_default_server_days_limit;
        public Int16 m_trans_stat;
        public Int16 m_notive_trans_hq_limit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_server = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_king_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_dis_open_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_item_cost = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_max_power_limit = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_default_max_power_limit = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_default_server_days_limit = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_trans_stat = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_notive_trans_hq_limit = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_server);}
            if (sp.TryWrite(1)) {sp.Write(m_king_name);}
            if (sp.TryWrite(2)) {sp.Write(m_open_time);}
            if (sp.TryWrite(3)) {sp.Write(m_dis_open_time);}
            if (sp.TryWrite(4)) {sp.Write(m_item_cost);}
            if (sp.TryWrite(5)) {sp.Write(m_max_power_limit);}
            if (sp.TryWrite(6)) {sp.Write(m_default_max_power_limit);}
            if (sp.TryWrite(7)) {sp.Write(m_default_server_days_limit);}
            if (sp.TryWrite(8)) {sp.Write(m_trans_stat);}
            if (sp.TryWrite(9)) {sp.Write(m_notive_trans_hq_limit);}
            sp.EnEnd();
        }
        public void CopyFrom(B2TransferServerDisInfoAck source) {
            m_target_server = source.m_target_server;
            m_king_name = source.m_king_name;
            m_open_time = source.m_open_time;
            m_dis_open_time = source.m_dis_open_time;
            m_item_cost = source.m_item_cost;
            m_max_power_limit = source.m_max_power_limit;
            m_default_max_power_limit = source.m_default_max_power_limit;
            m_default_server_days_limit = source.m_default_server_days_limit;
            m_trans_stat = source.m_trans_stat;
            m_notive_trans_hq_limit = source.m_notive_trans_hq_limit;
        }
    }
    
    [Serializable]
    public partial class LimitedBuffNtfInfo : NetworkMessage {
        public static int[] Id = { 1148,8 };
        public static Ctrl VC;
        public List<LimitedBuffInfo> m_list = new List<LimitedBuffInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LimitedBuffInfo tmp = new LimitedBuffInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LimitedBuffNtfInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class CampaignFinalReward : NetworkMessage {
        public static int[] Id = { 1154,12 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int32 m_score_per;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_score_per = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_num);}
            if (sp.TryWrite(2)) {sp.Write(m_score_per);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignFinalReward source) {
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_score_per = source.m_score_per;
        }
    }
    
    [Serializable]
    public partial class GvgMatchGuildInfo : NetworkMessage {
        public static int[] Id = { 1160,12 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_logo;
        public Int64 m_score;
        public Int64 m_attend_power;
        public Int16 m_attend_num;
        public Int32 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_attend_power = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_attend_num = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_logo);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {sp.Write(m_attend_power);}
            if (sp.TryWrite(6)) {sp.Write(m_attend_num);}
            if (sp.TryWrite(7)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgMatchGuildInfo source) {
            m_server_id = source.m_server_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_logo = source.m_logo;
            m_score = source.m_score;
            m_attend_power = source.m_attend_power;
            m_attend_num = source.m_attend_num;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class GvgApplyManageReqInfo : NetworkMessage {
        public static int[] Id = { 1166,12 };
        public static Ctrl VC;
        public SByte m_status;
        public List<Int64> m_members = new List<Int64>();
        public Int64 m_camp_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_members.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_members.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_camp_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_members.Count);
                for (int i = 0; i != m_members.Count; ++i) {
                    sp.Write(m_members[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_camp_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyManageReqInfo source) {
            m_status = source.m_status;
            m_members = source.m_members;
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class GoodsInfo : NetworkMessage {
        public static int[] Id = { 1172,12 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(GoodsInfo source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class ArtworkNtfInfo : NetworkMessage {
        public static int[] Id = { 1178,12 };
        public static Ctrl VC;
        public Int32 m_status;
        public Int64 m_next_refresh_time;
        public Int32 m_alliance_id;
        public Int16 m_goods_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_next_refresh_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_goods_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_next_refresh_time);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(3)) {sp.Write(m_goods_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ArtworkNtfInfo source) {
            m_status = source.m_status;
            m_next_refresh_time = source.m_next_refresh_time;
            m_alliance_id = source.m_alliance_id;
            m_goods_id = source.m_goods_id;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldStatusNtfInfo : NetworkMessage {
        public static int[] Id = { 1184,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int64 m_open_time;
        public Int64 m_end_time;
        public Int64 m_map_guid;
        public GvgBattlefieldAllianceStatusInfo m_team_a;
        public GvgBattlefieldAllianceStatusInfo m_team_b;
        public Int16 m_status;
        public Int16 m_result;
        public Int16 m_max_user;
        public Int64 m_last_quit_time;
        public Int16 m_mapid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                m_team_a = new GvgBattlefieldAllianceStatusInfo();
                m_team_a.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_team_b = new GvgBattlefieldAllianceStatusInfo();
                m_team_b.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_result = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_max_user = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_last_quit_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_mapid = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_open_time);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_team_a.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_team_b.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_status);}
            if (sp.TryWrite(7)) {sp.Write(m_result);}
            if (sp.TryWrite(8)) {sp.Write(m_max_user);}
            if (sp.TryWrite(9)) {sp.Write(m_last_quit_time);}
            if (sp.TryWrite(10)) {sp.Write(m_mapid);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldStatusNtfInfo source) {
            m_id = source.m_id;
            m_open_time = source.m_open_time;
            m_end_time = source.m_end_time;
            m_map_guid = source.m_map_guid;
            m_team_a = source.m_team_a;
            m_team_b = source.m_team_b;
            m_status = source.m_status;
            m_result = source.m_result;
            m_max_user = source.m_max_user;
            m_last_quit_time = source.m_last_quit_time;
            m_mapid = source.m_mapid;
        }
    }
    
    [Serializable]
    public partial class ClaimArchiveRewardInfo : NetworkMessage {
        public static int[] Id = { 1190,12 };
        public static Ctrl VC;
        public Int16 m_archive_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_archive_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_archive_level);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimArchiveRewardInfo source) {
            m_archive_level = source.m_archive_level;
        }
    }
    
    [Serializable]
    public partial class RouletteCircleInfo : NetworkMessage {
        public static int[] Id = { 1214,14 };
        public static Ctrl VC;
        public Int32 m_circle_id;
        public SByte m_circle_order;
        public ItemInfo m_roll_cost;
        public List<RouletteCell> m_cells = new List<RouletteCell>();
        public RouletteCircleStatus m_circle_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_circle_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_circle_order = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                m_roll_cost = new ItemInfo();
                m_roll_cost.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cells.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RouletteCell tmp = new RouletteCell();
                    tmp.Decode(sp);
                    m_cells.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_circle_status = new RouletteCircleStatus();
                m_circle_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_circle_id);}
            if (sp.TryWrite(1)) {sp.Write(m_circle_order);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_roll_cost.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cells.Count);
                for (int i = 0; i != m_cells.Count; ++i) {
                    m_cells[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_circle_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteCircleInfo source) {
            m_circle_id = source.m_circle_id;
            m_circle_order = source.m_circle_order;
            m_roll_cost = source.m_roll_cost;
            m_cells = source.m_cells;
            m_circle_status = source.m_circle_status;
        }
    }
    
    [Serializable]
    public partial class RouletteDiamondExchReqInfo : NetworkMessage {
        public static int[] Id = { 1220,14 };
        public static Ctrl VC;
        public Int32 m_num;
        public Int64 m_act_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_num = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_act_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_num);}
            if (sp.TryWrite(1)) {sp.Write(m_act_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteDiamondExchReqInfo source) {
            m_num = source.m_num;
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class UserGetNewCityNameplateInfo : NetworkMessage {
        public static int[] Id = { 1226,18 };
        public static Ctrl VC;
        public Int16 m_new_nameplate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_nameplate = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_nameplate);}
            sp.EnEnd();
        }
        public void CopyFrom(UserGetNewCityNameplateInfo source) {
            m_new_nameplate = source.m_new_nameplate;
        }
    }
    
    [Serializable]
    public partial class UserSetCurrentCityNameplateAckInfo : NetworkMessage {
        public static int[] Id = { 1232,18 };
        public static Ctrl VC;
        public Int16 m_error_code;
        public Int16 m_current_nameplate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_error_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_current_nameplate = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_error_code);}
            if (sp.TryWrite(1)) {sp.Write(m_current_nameplate);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSetCurrentCityNameplateAckInfo source) {
            m_error_code = source.m_error_code;
            m_current_nameplate = source.m_current_nameplate;
        }
    }
    
    [Serializable]
    public partial class CrossArenaBuyCntAckInfo : NetworkMessage {
        public static int[] Id = { 1238,19 };
        public static Ctrl VC;
        public Int32 m_cnt_max;
        public Int32 m_cnt;
        public Int32 m_can_buy_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cnt_max = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_can_buy_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cnt_max);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_can_buy_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(CrossArenaBuyCntAckInfo source) {
            m_cnt_max = source.m_cnt_max;
            m_cnt = source.m_cnt;
            m_can_buy_cnt = source.m_can_buy_cnt;
        }
    }
    
    [Serializable]
    public partial class UserVerifCodeInfo : NetworkMessage {
        public static int[] Id = { 1244,19 };
        public static Ctrl VC;
        public Boolean m_verif_switch;
        public Int64 m_verif_time;
        public Int64 m_verif_cd;
        public Boolean m_is_force;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_verif_switch = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_verif_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_verif_cd = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_is_force = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_verif_switch);}
            if (sp.TryWrite(1)) {sp.Write(m_verif_time);}
            if (sp.TryWrite(2)) {sp.Write(m_verif_cd);}
            if (sp.TryWrite(3)) {sp.Write(m_is_force);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserVerifCodeInfo source) {
            m_verif_switch = source.m_verif_switch;
            m_verif_time = source.m_verif_time;
            m_verif_cd = source.m_verif_cd;
            m_is_force = source.m_is_force;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class MailConfirmQueryReqInfo : NetworkMessage {
        public static int[] Id = { 1250,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmQueryReqInfo source) {
            m_confirm_id = source.m_confirm_id;
        }
    }
    
    [Serializable]
    public partial class CreateGuildConfirmMailAckInfo : NetworkMessage {
        public static int[] Id = { 1256,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CreateGuildConfirmMailAckInfo source) {
            m_confirm_id = source.m_confirm_id;
        }
    }
    
    [Serializable]
    public partial class BossCampaignInfo : NetworkMessage {
        public static int[] Id = { 1262,19 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BossCampaignBossInfo> m_boss_list = new List<BossCampaignBossInfo>();
        public List<BossCampaignScoreRule> m_score_rule = new List<BossCampaignScoreRule>();
        public Int16 m_cur_boss_level;
        public Int64 m_cur_boss_hp;
        public Int64 m_cur_boss_march_id;
        public TilePos m_cur_boss_pos;
        public List<Int16> m_user_reward_got = new List<Int16>();
        public SByte m_user_reset_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_boss_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BossCampaignBossInfo tmp = new BossCampaignBossInfo();
                    tmp.Decode(sp);
                    m_boss_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_score_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BossCampaignScoreRule tmp = new BossCampaignScoreRule();
                    tmp.Decode(sp);
                    m_score_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_cur_boss_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_cur_boss_hp = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_cur_boss_march_id = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                m_cur_boss_pos = new TilePos();
                m_cur_boss_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_user_reward_got.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_user_reward_got.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_user_reset_cnt = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_boss_list.Count);
                for (int i = 0; i != m_boss_list.Count; ++i) {
                    m_boss_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_score_rule.Count);
                for (int i = 0; i != m_score_rule.Count; ++i) {
                    m_score_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_cur_boss_level);}
            if (sp.TryWrite(4)) {sp.Write(m_cur_boss_hp);}
            if (sp.TryWrite(5)) {sp.Write(m_cur_boss_march_id);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_cur_boss_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_user_reward_got.Count);
                for (int i = 0; i != m_user_reward_got.Count; ++i) {
                    sp.Write(m_user_reward_got[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_user_reset_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_boss_list = source.m_boss_list;
            m_score_rule = source.m_score_rule;
            m_cur_boss_level = source.m_cur_boss_level;
            m_cur_boss_hp = source.m_cur_boss_hp;
            m_cur_boss_march_id = source.m_cur_boss_march_id;
            m_cur_boss_pos = source.m_cur_boss_pos;
            m_user_reward_got = source.m_user_reward_got;
            m_user_reset_cnt = source.m_user_reset_cnt;
        }
    }
    
    [Serializable]
    public partial class BossCampaignSlotArmy : NetworkMessage {
        public static int[] Id = { 1268,19 };
        public static Ctrl VC;
        public Int16 m_main_agent;
        public Int16 m_aide_agent;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public List<ArmyInfo> m_battled_troops = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_main_agent = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_aide_agent = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_battled_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_battled_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_main_agent);}
            if (sp.TryWrite(1)) {sp.Write(m_aide_agent);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_battled_troops.Count);
                for (int i = 0; i != m_battled_troops.Count; ++i) {
                    m_battled_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignSlotArmy source) {
            m_main_agent = source.m_main_agent;
            m_aide_agent = source.m_aide_agent;
            m_troops = source.m_troops;
            m_battled_troops = source.m_battled_troops;
        }
    }
    
    [Serializable]
    public partial class BossCampaignFightScoreNtfInfo : NetworkMessage {
        public static int[] Id = { 1274,19 };
        public static Ctrl VC;
        public SByte m_boss_level;
        public SByte m_slot;
        public Int64 m_damage;
        public SByte m_score_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_boss_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_slot = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_score_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_boss_level);}
            if (sp.TryWrite(1)) {sp.Write(m_slot);}
            if (sp.TryWrite(2)) {sp.Write(m_damage);}
            if (sp.TryWrite(3)) {sp.Write(m_score_level);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignFightScoreNtfInfo source) {
            m_boss_level = source.m_boss_level;
            m_slot = source.m_slot;
            m_damage = source.m_damage;
            m_score_level = source.m_score_level;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRecordAckInfo : NetworkMessage {
        public static int[] Id = { 1280,19 };
        public static Ctrl VC;
        public Int64 m_ack_id;
        public List<BossCampaignRecordInfo> m_infos = new List<BossCampaignRecordInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ack_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BossCampaignRecordInfo tmp = new BossCampaignRecordInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_ack_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_infos.Count);
                for (int i = 0; i != m_infos.Count; ++i) {
                    m_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignRecordAckInfo source) {
            m_ack_id = source.m_ack_id;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class DropCampaignDropNtfInfo : NetworkMessage {
        public static int[] Id = { 1286,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<ItemInfo> m_item = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_item.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item.Count);
                for (int i = 0; i != m_item.Count; ++i) {
                    m_item[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DropCampaignDropNtfInfo source) {
            m_act_id = source.m_act_id;
            m_item = source.m_item;
        }
    }
    
    [Serializable]
    public partial class KvkQuestInfo : NetworkMessage {
        public static int[] Id = { 1292,19 };
        public static Ctrl VC;
        public Int32 m_quest_id;
        public Int64 m_status1;
        public Int64 m_status2;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_quest_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_status1 = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_status2 = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_quest_id);}
            if (sp.TryWrite(1)) {sp.Write(m_status1);}
            if (sp.TryWrite(2)) {sp.Write(m_status2);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkQuestInfo source) {
            m_quest_id = source.m_quest_id;
            m_status1 = source.m_status1;
            m_status2 = source.m_status2;
        }
    }
    
    [Serializable]
    public partial class KvkSetLandColorReqInfo : NetworkMessage {
        public static int[] Id = { 1298,19 };
        public static Ctrl VC;
        public Int32 m_color;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_color = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_color);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkSetLandColorReqInfo source) {
            m_color = source.m_color;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortItemDonateInfo : NetworkMessage {
        public static int[] Id = { 1304,19 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Int32 m_kvk_honour;
        public Int32 m_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_kvk_honour = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_pt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_kvk_honour);}
            if (sp.TryWrite(3)) {sp.Write(m_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortItemDonateInfo source) {
            m_item_id = source.m_item_id;
            m_reward = source.m_reward;
            m_kvk_honour = source.m_kvk_honour;
            m_pt = source.m_pt;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortExchangeDonateAckInfo : NetworkMessage {
        public static int[] Id = { 1310,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_item_id;
        public Int32 m_donate_pt;
        public Int64 m_gs_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_donate_pt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_gs_pt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_donate_pt);}
            if (sp.TryWrite(3)) {sp.Write(m_gs_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortExchangeDonateAckInfo source) {
            m_act_id = source.m_act_id;
            m_item_id = source.m_item_id;
            m_donate_pt = source.m_donate_pt;
            m_gs_pt = source.m_gs_pt;
        }
    }
    
    [Serializable]
    public partial class ClaimSevenDailyLoginInfo : NetworkMessage {
        public static int[] Id = { 1316,20 };
        public static Ctrl VC;
        public SByte m_day;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_day = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_day);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimSevenDailyLoginInfo source) {
            m_day = source.m_day;
        }
    }
    
    [Serializable]
    public partial class SlotMachineCampaignInfo : NetworkMessage {
        public static int[] Id = { 1336,22 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int32 m_once_diamond_cost;
        public Int32 m_five_diamond_cost;
        public Int16 m_once_dis_per;
        public Int16 m_five_dis_per;
        public Int16 m_free_time;
        public Boolean m_is_free_daily;
        public Int16 m_once_dis_time;
        public Int16 m_five_dis_time;
        public Boolean m_is_discount_daily;
        public Int32 m_max_time;
        public Boolean m_is_max_time_daily;
        public Int32 m_daily_roll_time;
        public Int32 m_total_roll_time;
        public List<SlotMachineAdditionReward> m_extra_reward = new List<SlotMachineAdditionReward>();
        public List<Int32> m_extra_reward_got = new List<Int32>();
        public List<Int32> m_wheel_id = new List<Int32>();
        public List<SlotMachineBigRewardRule> m_big_reward_rule = new List<SlotMachineBigRewardRule>();
        public List<ItemInfo> m_normal_reward_list = new List<ItemInfo>();
        public Int32 m_stage_up_limit;
        public Int32 m_extra_reward_score;
        public Int32 m_cost_type;
        public Int32 m_cost_param;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_once_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_five_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_once_dis_per = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_five_dis_per = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_free_time = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_is_free_daily = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_once_dis_time = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_five_dis_time = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_is_discount_daily = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_max_time = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_is_max_time_daily = sp.ReadBoolean();}
            if (sp.TryRead(12)) {m_daily_roll_time = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_total_roll_time = sp.ReadInt32();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SlotMachineAdditionReward tmp = new SlotMachineAdditionReward();
                    tmp.Decode(sp);
                    m_extra_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_got.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_extra_reward_got.Add(tmp);
                }
            }
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_wheel_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_wheel_id.Add(tmp);
                }
            }
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_big_reward_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SlotMachineBigRewardRule tmp = new SlotMachineBigRewardRule();
                    tmp.Decode(sp);
                    m_big_reward_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(18)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_reward_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_normal_reward_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {m_stage_up_limit = sp.ReadInt32();}
            if (sp.TryRead(20)) {m_extra_reward_score = sp.ReadInt32();}
            if (sp.TryRead(21)) {m_cost_type = sp.ReadInt32();}
            if (sp.TryRead(22)) {m_cost_param = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_once_diamond_cost);}
            if (sp.TryWrite(2)) {sp.Write(m_five_diamond_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_once_dis_per);}
            if (sp.TryWrite(4)) {sp.Write(m_five_dis_per);}
            if (sp.TryWrite(5)) {sp.Write(m_free_time);}
            if (sp.TryWrite(6)) {sp.Write(m_is_free_daily);}
            if (sp.TryWrite(7)) {sp.Write(m_once_dis_time);}
            if (sp.TryWrite(8)) {sp.Write(m_five_dis_time);}
            if (sp.TryWrite(9)) {sp.Write(m_is_discount_daily);}
            if (sp.TryWrite(10)) {sp.Write(m_max_time);}
            if (sp.TryWrite(11)) {sp.Write(m_is_max_time_daily);}
            if (sp.TryWrite(12)) {sp.Write(m_daily_roll_time);}
            if (sp.TryWrite(13)) {sp.Write(m_total_roll_time);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward.Count);
                for (int i = 0; i != m_extra_reward.Count; ++i) {
                    m_extra_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_got.Count);
                for (int i = 0; i != m_extra_reward_got.Count; ++i) {
                    sp.Write(m_extra_reward_got[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_wheel_id.Count);
                for (int i = 0; i != m_wheel_id.Count; ++i) {
                    sp.Write(m_wheel_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_big_reward_rule.Count);
                for (int i = 0; i != m_big_reward_rule.Count; ++i) {
                    m_big_reward_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(18)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_reward_list.Count);
                for (int i = 0; i != m_normal_reward_list.Count; ++i) {
                    m_normal_reward_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(19)) {sp.Write(m_stage_up_limit);}
            if (sp.TryWrite(20)) {sp.Write(m_extra_reward_score);}
            if (sp.TryWrite(21)) {sp.Write(m_cost_type);}
            if (sp.TryWrite(22)) {sp.Write(m_cost_param);}
            sp.EnEnd();
        }
        public void CopyFrom(SlotMachineCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_once_diamond_cost = source.m_once_diamond_cost;
            m_five_diamond_cost = source.m_five_diamond_cost;
            m_once_dis_per = source.m_once_dis_per;
            m_five_dis_per = source.m_five_dis_per;
            m_free_time = source.m_free_time;
            m_is_free_daily = source.m_is_free_daily;
            m_once_dis_time = source.m_once_dis_time;
            m_five_dis_time = source.m_five_dis_time;
            m_is_discount_daily = source.m_is_discount_daily;
            m_max_time = source.m_max_time;
            m_is_max_time_daily = source.m_is_max_time_daily;
            m_daily_roll_time = source.m_daily_roll_time;
            m_total_roll_time = source.m_total_roll_time;
            m_extra_reward = source.m_extra_reward;
            m_extra_reward_got = source.m_extra_reward_got;
            m_wheel_id = source.m_wheel_id;
            m_big_reward_rule = source.m_big_reward_rule;
            m_normal_reward_list = source.m_normal_reward_list;
            m_stage_up_limit = source.m_stage_up_limit;
            m_extra_reward_score = source.m_extra_reward_score;
            m_cost_type = source.m_cost_type;
            m_cost_param = source.m_cost_param;
        }
    }
    
    [Serializable]
    public partial class SlotMachineExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1342,22 };
        public static Ctrl VC;
        public CampaignReqItemInfo m_aty_item;
        public Int16 m_reward_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_aty_item = new CampaignReqItemInfo();
                m_aty_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_reward_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_aty_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SlotMachineExtraRewardReqInfo source) {
            m_aty_item = source.m_aty_item;
            m_reward_id = source.m_reward_id;
        }
    }
    
    [Serializable]
    public partial class KvkBattlePassportInfo : NetworkMessage {
        public static int[] Id = { 1348,23 };
        public static Ctrl VC;
        public Int32 m_period;
        public Int32 m_exp;
        public Int32 m_level;
        public Int64 m_endtime;
        public Boolean m_is_premium;
        public List<Int16> m_reward_record = new List<Int16>();
        public List<Int16> m_premium_reward_record = new List<Int16>();
        public List<BattlePassportTask> m_task = new List<BattlePassportTask>();
        public Int16 m_box_score;
        public Boolean m_box_reward;
        public Int16 m_exp_ratio;
        public Int32 m_extra_rwd;
        public Int16 m_stage;
        public Int64 m_start_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_period = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_is_premium = sp.ReadBoolean();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_reward_record.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_premium_reward_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_premium_reward_record.Add(tmp);
                }
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BattlePassportTask tmp = new BattlePassportTask();
                    tmp.Decode(sp);
                    m_task.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_box_score = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_box_reward = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_exp_ratio = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_extra_rwd = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_stage = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_start_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_period);}
            if (sp.TryWrite(1)) {sp.Write(m_exp);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_endtime);}
            if (sp.TryWrite(4)) {sp.Write(m_is_premium);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_record.Count);
                for (int i = 0; i != m_reward_record.Count; ++i) {
                    sp.Write(m_reward_record[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_premium_reward_record.Count);
                for (int i = 0; i != m_premium_reward_record.Count; ++i) {
                    sp.Write(m_premium_reward_record[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task.Count);
                for (int i = 0; i != m_task.Count; ++i) {
                    m_task[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {sp.Write(m_box_score);}
            if (sp.TryWrite(9)) {sp.Write(m_box_reward);}
            if (sp.TryWrite(10)) {sp.Write(m_exp_ratio);}
            if (sp.TryWrite(11)) {sp.Write(m_extra_rwd);}
            if (sp.TryWrite(12)) {sp.Write(m_stage);}
            if (sp.TryWrite(13)) {sp.Write(m_start_time);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBattlePassportInfo source) {
            m_period = source.m_period;
            m_exp = source.m_exp;
            m_level = source.m_level;
            m_endtime = source.m_endtime;
            m_is_premium = source.m_is_premium;
            m_reward_record = source.m_reward_record;
            m_premium_reward_record = source.m_premium_reward_record;
            m_task = source.m_task;
            m_box_score = source.m_box_score;
            m_box_reward = source.m_box_reward;
            m_exp_ratio = source.m_exp_ratio;
            m_extra_rwd = source.m_extra_rwd;
            m_stage = source.m_stage;
            m_start_time = source.m_start_time;
        }
    }
    
    [Serializable]
    public partial class SelfAllianceRankReqInfo : NetworkMessage {
        public static int[] Id = { 1354,23 };
        public static Ctrl VC;
        public SByte m_scope;
        public Int16 m_rank_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_scope = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_rank_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_scope);}
            if (sp.TryWrite(1)) {sp.Write(m_rank_type);}
            sp.EnEnd();
        }
        public void CopyFrom(SelfAllianceRankReqInfo source) {
            m_scope = source.m_scope;
            m_rank_type = source.m_rank_type;
        }
    }
    
    [Serializable]
    public partial class PlayerBlackListModifyReqInfo : NetworkMessage {
        public static int[] Id = { 1360,23 };
        public static Ctrl VC;
        public List<PlayerBlackListItem> m_black_list = new List<PlayerBlackListItem>();
        public SByte m_action_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_black_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PlayerBlackListItem tmp = new PlayerBlackListItem();
                    tmp.Decode(sp);
                    m_black_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_action_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_black_list.Count);
                for (int i = 0; i != m_black_list.Count; ++i) {
                    m_black_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_action_type);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerBlackListModifyReqInfo source) {
            m_black_list = source.m_black_list;
            m_action_type = source.m_action_type;
        }
    }
    
    [Serializable]
    public partial class UserWarshipUpgradeResearchInfo : NetworkMessage {
        public static int[] Id = { 1366,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int32 m_research_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_research_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_research_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipUpgradeResearchInfo source) {
            m_warship_id = source.m_warship_id;
            m_research_id = source.m_research_id;
        }
    }
    
    [Serializable]
    public partial class UserWarshipCancelResearchInfo : NetworkMessage {
        public static int[] Id = { 1372,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int32 m_research_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_research_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_research_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipCancelResearchInfo source) {
            m_warship_id = source.m_warship_id;
            m_research_id = source.m_research_id;
        }
    }
    
    [Serializable]
    public partial class KvkPreClaimTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1378,23 };
        public static Ctrl VC;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreClaimTaskRewardReqInfo source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class KvkCounterNtfInfo : NetworkMessage {
        public static int[] Id = { 1384,23 };
        public static Ctrl VC;
        public Int32 m_kvk_counter;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_kvk_counter = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_kvk_counter);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkCounterNtfInfo source) {
            m_kvk_counter = source.m_kvk_counter;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardLevelInfo : NetworkMessage {
        public static int[] Id = { 1390,23 };
        public static Ctrl VC;
        public Int16 m_level;
        public List<ItemInfo> m_basic_reward = new List<ItemInfo>();
        public List<ItemInfo> m_ex_reward = new List<ItemInfo>();
        public Int32 m_ex_limit_score;
        public Int32 m_level_up_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_basic_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_basic_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ex_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_ex_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_ex_limit_score = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_level_up_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_basic_reward.Count);
                for (int i = 0; i != m_basic_reward.Count; ++i) {
                    m_basic_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ex_reward.Count);
                for (int i = 0; i != m_ex_reward.Count; ++i) {
                    m_ex_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_ex_limit_score);}
            if (sp.TryWrite(4)) {sp.Write(m_level_up_point);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardLevelInfo source) {
            m_level = source.m_level;
            m_basic_reward = source.m_basic_reward;
            m_ex_reward = source.m_ex_reward;
            m_ex_limit_score = source.m_ex_limit_score;
            m_level_up_point = source.m_level_up_point;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardReqInfo : NetworkMessage {
        public static int[] Id = { 1396,23 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardFlushTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1402,23 };
        public static Ctrl VC;
        public SByte m_slot_id;
        public List<SByte> m_slot_id_list = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_slot_id_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_slot_id_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_slot_id_list.Count);
                for (int i = 0; i != m_slot_id_list.Count; ++i) {
                    sp.Write(m_slot_id_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardFlushTaskReqInfo source) {
            m_slot_id = source.m_slot_id;
            m_slot_id_list = source.m_slot_id_list;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardAddAvailableTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1408,23 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardAddAvailableTaskReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class KvkRanklistReqInfo : NetworkMessage {
        public static int[] Id = { 1414,23 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int32 m_start;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_start = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_start);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkRanklistReqInfo source) {
            m_type = source.m_type;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class BatchGetRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 1420,23 };
        public static Ctrl VC;
        public List<String> m_mail_id = new List<String>();
        public Boolean m_read;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_mail_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_mail_id.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_read = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_mail_id.Count);
                for (int i = 0; i != m_mail_id.Count; ++i) {
                    sp.Write(m_mail_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_read);}
            sp.EnEnd();
        }
        public void CopyFrom(BatchGetRtfMailReqInfo source) {
            m_mail_id = source.m_mail_id;
            m_read = source.m_read;
        }
    }
    
    [Serializable]
    public partial class AsTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1426,23 };
        public static Ctrl VC;
        public Int32 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class KvkAvailableMapAreaAckInfo : NetworkMessage {
        public static int[] Id = { 1432,23 };
        public static Ctrl VC;
        public List<SByte> m_area_list = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_area_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_area_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_area_list.Count);
                for (int i = 0; i != m_area_list.Count; ++i) {
                    sp.Write(m_area_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkAvailableMapAreaAckInfo source) {
            m_area_list = source.m_area_list;
        }
    }
    
    [Serializable]
    public partial class ClaimRtfMailRewardNtfInfo : NetworkMessage {
        public static int[] Id = { 1438,23 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<ResTypeInfo> m_res = new List<ResTypeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ClaimRtfMailRewardNtfInfo source) {
            m_items = source.m_items;
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class UserShameDetailSetReqInfo : NetworkMessage {
        public static int[] Id = { 1444,25 };
        public static Ctrl VC;
        public Int64 m_target_id;
        public Int16 m_shame_agent;
        public Int32 m_shame_item;
        public Int32 m_shame_lc;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_shame_agent = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_shame_item = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_shame_lc = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_id);}
            if (sp.TryWrite(1)) {sp.Write(m_shame_agent);}
            if (sp.TryWrite(2)) {sp.Write(m_shame_item);}
            if (sp.TryWrite(3)) {sp.Write(m_shame_lc);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShameDetailSetReqInfo source) {
            m_target_id = source.m_target_id;
            m_shame_agent = source.m_shame_agent;
            m_shame_item = source.m_shame_item;
            m_shame_lc = source.m_shame_lc;
        }
    }
    
    [Serializable]
    public partial class WeaponListNtfInfo : NetworkMessage {
        public static int[] Id = { 1450,25 };
        public static Ctrl VC;
        public List<WeaponInfo> m_weapon_list = new List<WeaponInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapon_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WeaponInfo tmp = new WeaponInfo();
                    tmp.Decode(sp);
                    m_weapon_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_list.Count);
                for (int i = 0; i != m_weapon_list.Count; ++i) {
                    m_weapon_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeaponListNtfInfo source) {
            m_weapon_list = source.m_weapon_list;
        }
    }
    
    [Serializable]
    public partial class WeaponEquipReqInfo : NetworkMessage {
        public static int[] Id = { 1456,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_agent_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_agent_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_agent_id);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponEquipReqInfo source) {
            m_id = source.m_id;
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class TroopPowerDetailAckInfo : NetworkMessage {
        public static int[] Id = { 1462,25 };
        public static Ctrl VC;
        public List<TroopPowerDetail> m_normal = new List<TroopPowerDetail>();
        public List<TroopPowerDetail> m_kvk = new List<TroopPowerDetail>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopPowerDetail tmp = new TroopPowerDetail();
                    tmp.Decode(sp);
                    m_normal.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopPowerDetail tmp = new TroopPowerDetail();
                    tmp.Decode(sp);
                    m_kvk.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal.Count);
                for (int i = 0; i != m_normal.Count; ++i) {
                    m_normal[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk.Count);
                for (int i = 0; i != m_kvk.Count; ++i) {
                    m_kvk[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TroopPowerDetailAckInfo source) {
            m_normal = source.m_normal;
            m_kvk = source.m_kvk;
        }
    }
    
    [Serializable]
    public partial class UserRefundNtfInfo : NetworkMessage {
        public static int[] Id = { 1468,25 };
        public static Ctrl VC;
        public Int64 m_total_cost;
        public List<UserRefundInfo> m_refunds = new List<UserRefundInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total_cost = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_refunds.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserRefundInfo tmp = new UserRefundInfo();
                    tmp.Decode(sp);
                    m_refunds.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total_cost);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_refunds.Count);
                for (int i = 0; i != m_refunds.Count; ++i) {
                    m_refunds[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserRefundNtfInfo source) {
            m_total_cost = source.m_total_cost;
            m_refunds = source.m_refunds;
        }
    }
    
    [Serializable]
    public partial class CaptainFurnitureOpInfo : NetworkMessage {
        public static int[] Id = { 1474,25 };
        public static Ctrl VC;
        public Int32 m_r_id;
        public Int32 m_f_id;
        public SByte m_f_type;
        public SByte m_buy_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_r_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_f_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_f_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_buy_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_r_id);}
            if (sp.TryWrite(1)) {sp.Write(m_f_id);}
            if (sp.TryWrite(2)) {sp.Write(m_f_type);}
            if (sp.TryWrite(3)) {sp.Write(m_buy_type);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainFurnitureOpInfo source) {
            m_r_id = source.m_r_id;
            m_f_id = source.m_f_id;
            m_f_type = source.m_f_type;
            m_buy_type = source.m_buy_type;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomStoryLineInfo : NetworkMessage {
        public static int[] Id = { 1480,25 };
        public static Ctrl VC;
        public Int16 m_l_id;
        public Int16 m_s_id;
        public SByte m_s_stat;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_l_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_s_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_s_stat = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_l_id);}
            if (sp.TryWrite(1)) {sp.Write(m_s_id);}
            if (sp.TryWrite(2)) {sp.Write(m_s_stat);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomStoryLineInfo source) {
            m_l_id = source.m_l_id;
            m_s_id = source.m_s_id;
            m_s_stat = source.m_s_stat;
        }
    }
    
    [Serializable]
    public partial class GlobalRanklistReqInfo : NetworkMessage {
        public static int[] Id = { 1486,27 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int32 m_start;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_start = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_start);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GlobalRanklistReqInfo source) {
            m_type = source.m_type;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardFinishTaskCounter : NetworkMessage {
        public static int[] Id = { 1492,27 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardFinishTaskCounter source) {
            m_task_id = source.m_task_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class RankingRewardCfg : NetworkMessage {
        public static int[] Id = { 1498,27 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_type;
        public Int32 m_rank_d;
        public Int32 m_rank_u;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Int64 m_next_reward_time;
        public String m_lc_title = "";
        public String m_lc_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_rank_d = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_rank_u = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_next_reward_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_lc_title = sp.ReadString();}
            if (sp.TryRead(7)) {m_lc_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_rank_d);}
            if (sp.TryWrite(3)) {sp.Write(m_rank_u);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_next_reward_time);}
            if (sp.TryWrite(6)) {sp.Write(m_lc_title);}
            if (sp.TryWrite(7)) {sp.Write(m_lc_content);}
            sp.EnEnd();
        }
        public void CopyFrom(RankingRewardCfg source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_rank_d = source.m_rank_d;
            m_rank_u = source.m_rank_u;
            m_rewards = source.m_rewards;
            m_next_reward_time = source.m_next_reward_time;
            m_lc_title = source.m_lc_title;
            m_lc_content = source.m_lc_content;
        }
    }
    
    [Serializable]
    public partial class UserAllArmyBannersInfo : NetworkMessage {
        public static int[] Id = { 1511,29 };
        public static Ctrl VC;
        public List<UserArmyBannerInfo> m_banners = new List<UserArmyBannerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_banners.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserArmyBannerInfo tmp = new UserArmyBannerInfo();
                    tmp.Decode(sp);
                    m_banners.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_banners.Count);
                for (int i = 0; i != m_banners.Count; ++i) {
                    m_banners[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserAllArmyBannersInfo source) {
            m_banners = source.m_banners;
        }
    }
    
    [Serializable]
    public partial class KvkBountyServerRankInfo : NetworkMessage {
        public static int[] Id = { 1534,32 };
        public static Ctrl VC;
        public Int16 m_kvk_server_id;
        public List<Int16> m_gs_id_list = new List<Int16>();
        public Int16 m_bounty_server_id;
        public Int32 m_bounty_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_kvk_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gs_id_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_gs_id_list.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_bounty_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_bounty_amount = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_kvk_server_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_gs_id_list.Count);
                for (int i = 0; i != m_gs_id_list.Count; ++i) {
                    sp.Write(m_gs_id_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_bounty_server_id);}
            if (sp.TryWrite(3)) {sp.Write(m_bounty_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBountyServerRankInfo source) {
            m_kvk_server_id = source.m_kvk_server_id;
            m_gs_id_list = source.m_gs_id_list;
            m_bounty_server_id = source.m_bounty_server_id;
            m_bounty_amount = source.m_bounty_amount;
        }
    }
    
    [Serializable]
    public partial class AgentWgtBoxInfo : NetworkMessage {
        public static int[] Id = { 1583,33 };
        public static Ctrl VC;
        public Int16 m_box_id;
        public Boolean m_is_unlock_box;
        public Int16 m_talent_type;
        public Int16 m_box_grade;
        public Int32 m_box_exp;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_box_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_unlock_box = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_talent_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_box_grade = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_box_exp = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_box_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_unlock_box);}
            if (sp.TryWrite(2)) {sp.Write(m_talent_type);}
            if (sp.TryWrite(3)) {sp.Write(m_box_grade);}
            if (sp.TryWrite(4)) {sp.Write(m_box_exp);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentWgtBoxInfo source) {
            m_box_id = source.m_box_id;
            m_is_unlock_box = source.m_is_unlock_box;
            m_talent_type = source.m_talent_type;
            m_box_grade = source.m_box_grade;
            m_box_exp = source.m_box_exp;
        }
    }
    
    [Serializable]
    public partial class AgentWgtChangeTalentAckInfo : NetworkMessage {
        public static int[] Id = { 1599,33 };
        public static Ctrl VC;
        public Int16 m_new_talent_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_talent_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_talent_type);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentWgtChangeTalentAckInfo source) {
            m_new_talent_type = source.m_new_talent_type;
        }
    }
    
    [Serializable]
    public partial class NbpLevelCfg : NetworkMessage {
        public static int[] Id = { 1637,34 };
        public static Ctrl VC;
        public Int32 m_level;
        public List<ItemInfo> m_base_rewards = new List<ItemInfo>();
        public List<ItemInfo> m_premium_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_base_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_base_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_premium_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_premium_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_base_rewards.Count);
                for (int i = 0; i != m_base_rewards.Count; ++i) {
                    m_base_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_premium_rewards.Count);
                for (int i = 0; i != m_premium_rewards.Count; ++i) {
                    m_premium_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NbpLevelCfg source) {
            m_level = source.m_level;
            m_base_rewards = source.m_base_rewards;
            m_premium_rewards = source.m_premium_rewards;
        }
    }
    
    [Serializable]
    public partial class MonopolyCfg : NetworkMessage {
        public static int[] Id = { 1644,35 };
        public static Ctrl VC;
        public Int32 m_cost_item;
        public Int32 m_cost_num;
        public String m_pic = "";
        public Int32 m_extra_reward;
        public List<MonopolyRewardCfg> m_rewards = new List<MonopolyRewardCfg>();
        public List<MonopolyAdditionalCfg> m_additional_rewards = new List<MonopolyAdditionalCfg>();
        public List<MonopolyEventsCfg> m_events = new List<MonopolyEventsCfg>();
        public List<Int32> m_multi_reward = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cost_item = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cost_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_pic = sp.ReadString();}
            if (sp.TryRead(3)) {m_extra_reward = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonopolyRewardCfg tmp = new MonopolyRewardCfg();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_additional_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonopolyAdditionalCfg tmp = new MonopolyAdditionalCfg();
                    tmp.Decode(sp);
                    m_additional_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_events.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonopolyEventsCfg tmp = new MonopolyEventsCfg();
                    tmp.Decode(sp);
                    m_events.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_multi_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_multi_reward.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_item);}
            if (sp.TryWrite(1)) {sp.Write(m_cost_num);}
            if (sp.TryWrite(2)) {sp.Write(m_pic);}
            if (sp.TryWrite(3)) {sp.Write(m_extra_reward);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_additional_rewards.Count);
                for (int i = 0; i != m_additional_rewards.Count; ++i) {
                    m_additional_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_events.Count);
                for (int i = 0; i != m_events.Count; ++i) {
                    m_events[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_multi_reward.Count);
                for (int i = 0; i != m_multi_reward.Count; ++i) {
                    sp.Write(m_multi_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyCfg source) {
            m_cost_item = source.m_cost_item;
            m_cost_num = source.m_cost_num;
            m_pic = source.m_pic;
            m_extra_reward = source.m_extra_reward;
            m_rewards = source.m_rewards;
            m_additional_rewards = source.m_additional_rewards;
            m_events = source.m_events;
            m_multi_reward = source.m_multi_reward;
        }
    }
    
    [Serializable]
    public partial class MonopolyGetExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1651,35 };
        public static Ctrl VC;
        public Int32 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyGetExtraRewardReqInfo source) {
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class KvkShopInfo : NetworkMessage {
        public static int[] Id = { 1667,36 };
        public static Ctrl VC;
        public List<KvkShopItemInfo> m_items = new List<KvkShopItemInfo>();
        public Int32 m_refresh_times;
        public Int32 m_max_refresh_times;
        public Int32 m_shop_lv;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkShopItemInfo tmp = new KvkShopItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_refresh_times = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_max_refresh_times = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_shop_lv = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_refresh_times);}
            if (sp.TryWrite(2)) {sp.Write(m_max_refresh_times);}
            if (sp.TryWrite(3)) {sp.Write(m_shop_lv);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkShopInfo source) {
            m_items = source.m_items;
            m_refresh_times = source.m_refresh_times;
            m_max_refresh_times = source.m_max_refresh_times;
            m_shop_lv = source.m_shop_lv;
        }
    }
    
    [Serializable]
    public partial class DeleteCharacterCheckAckInfo : NetworkMessage {
        public static int[] Id = { 1673,38 };
        public static Ctrl VC;
        public List<Boolean> m_check_result = new List<Boolean>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_check_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Boolean tmp = sp.ReadBoolean();
                    m_check_result.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_check_result.Count);
                for (int i = 0; i != m_check_result.Count; ++i) {
                    sp.Write(m_check_result[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DeleteCharacterCheckAckInfo source) {
            m_check_result = source.m_check_result;
        }
    }
    
    [Serializable]
    public partial class GetPrivateCustomRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1684,38 };
        public static Ctrl VC;
        public Int32 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GetPrivateCustomRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class EquipMakeAckInfo : NetworkMessage {
        public static int[] Id = { 1698,40 };
        public static Ctrl VC;
        public EquipInfo m_new_equip;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_new_equip = new EquipInfo();
                m_new_equip.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_new_equip.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(EquipMakeAckInfo source) {
            m_new_equip = source.m_new_equip;
        }
    }
    
    [Serializable]
    public partial class EquipNtfInfo : NetworkMessage {
        public static int[] Id = { 1704,40 };
        public static Ctrl VC;
        public Int32 m_change_type;
        public List<EquipInfo> m_equip = new List<EquipInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_change_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_equip.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EquipInfo tmp = new EquipInfo();
                    tmp.Decode(sp);
                    m_equip.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_change_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_equip.Count);
                for (int i = 0; i != m_equip.Count; ++i) {
                    m_equip[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(EquipNtfInfo source) {
            m_change_type = source.m_change_type;
            m_equip = source.m_equip;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeCfg : NetworkMessage {
        public static int[] Id = { 1713,41 };
        public static Ctrl VC;
        public Int32 m_order;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int32 m_pkg_id;
        public String m_exchange_item_icon = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_exchange_item_icon = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_num);}
            if (sp.TryWrite(3)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(4)) {sp.Write(m_exchange_item_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeCfg source) {
            m_order = source.m_order;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_pkg_id = source.m_pkg_id;
            m_exchange_item_icon = source.m_exchange_item_icon;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalGridInfo : NetworkMessage {
        public static int[] Id = { 1723,41 };
        public static Ctrl VC;
        public Int32 m_index;
        public Int32 m_award_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_award_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {sp.Write(m_award_index);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalGridInfo source) {
            m_index = source.m_index;
            m_award_index = source.m_award_index;
        }
    }
    
    [Serializable]
    public partial class ItemBuyCfg : NetworkMessage {
        public static int[] Id = { 1729,41 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_buy_num_limit;
        public SByte m_price_type;
        public Int64 m_price;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_buy_num_limit = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_price_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_price = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_buy_num_limit);}
            if (sp.TryWrite(2)) {sp.Write(m_price_type);}
            if (sp.TryWrite(3)) {sp.Write(m_price);}
            sp.EnEnd();
        }
        public void CopyFrom(ItemBuyCfg source) {
            m_item_id = source.m_item_id;
            m_buy_num_limit = source.m_buy_num_limit;
            m_price_type = source.m_price_type;
            m_price = source.m_price;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeCampaignAdditionalCfg : NetworkMessage {
        public static int[] Id = { 1736,42 };
        public static Ctrl VC;
        public Int32 m_score;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(StrangeCubeCampaignAdditionalCfg source) {
            m_score = source.m_score;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class WarMarketExchangeCampaignCfg : NetworkMessage {
        public static int[] Id = { 1742,42 };
        public static Ctrl VC;
        public List<WarMarketExchangeItemCfg> m_items = new List<WarMarketExchangeItemCfg>();
        public WarMarketExchangeDrawCfg m_draw_config;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarMarketExchangeItemCfg tmp = new WarMarketExchangeItemCfg();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_draw_config = new WarMarketExchangeDrawCfg();
                m_draw_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_draw_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketExchangeCampaignCfg source) {
            m_items = source.m_items;
            m_draw_config = source.m_draw_config;
        }
    }
    
    [Serializable]
    public partial class WarMarketExchangeDrawCfg : NetworkMessage {
        public static int[] Id = { 1748,42 };
        public static Ctrl VC;
        public ItemInfo m_buy_box_price;
        public ItemInfo m_buy_box_reward;
        public ItemInfo m_discount_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_buy_box_price = new ItemInfo();
                m_buy_box_price.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_buy_box_reward = new ItemInfo();
                m_buy_box_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_discount_reward = new ItemInfo();
                m_discount_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_buy_box_price.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_buy_box_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_discount_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketExchangeDrawCfg source) {
            m_buy_box_price = source.m_buy_box_price;
            m_buy_box_reward = source.m_buy_box_reward;
            m_discount_reward = source.m_discount_reward;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignPicCfg : NetworkMessage {
        public static int[] Id = { 1754,44 };
        public static Ctrl VC;
        public String m_task_icon = "";
        public String m_task_f_icon = "";
        public String m_extra_awards_icon = "";
        public String m_extra_awards_g_icon = "";
        public String m_final_awards_icon = "";
        public String m_final_awards_g_icon = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_icon = sp.ReadString();}
            if (sp.TryRead(1)) {m_task_f_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_extra_awards_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_extra_awards_g_icon = sp.ReadString();}
            if (sp.TryRead(4)) {m_final_awards_icon = sp.ReadString();}
            if (sp.TryRead(5)) {m_final_awards_g_icon = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_icon);}
            if (sp.TryWrite(1)) {sp.Write(m_task_f_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_extra_awards_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_extra_awards_g_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_final_awards_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_final_awards_g_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(LineTaskCampaignPicCfg source) {
            m_task_icon = source.m_task_icon;
            m_task_f_icon = source.m_task_f_icon;
            m_extra_awards_icon = source.m_extra_awards_icon;
            m_extra_awards_g_icon = source.m_extra_awards_g_icon;
            m_final_awards_icon = source.m_final_awards_icon;
            m_final_awards_g_icon = source.m_final_awards_g_icon;
        }
    }
    
    [Serializable]
    public partial class LegendOptionalAwardCfg : NetworkMessage {
        public static int[] Id = { 1769,44 };
        public static Ctrl VC;
        public List<LegendOptionalAwardItemCfg> m_optional_awards = new List<LegendOptionalAwardItemCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_optional_awards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LegendOptionalAwardItemCfg tmp = new LegendOptionalAwardItemCfg();
                    tmp.Decode(sp);
                    m_optional_awards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_optional_awards.Count);
                for (int i = 0; i != m_optional_awards.Count; ++i) {
                    m_optional_awards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LegendOptionalAwardCfg source) {
            m_optional_awards = source.m_optional_awards;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitItemInfo : NetworkMessage {
        public static int[] Id = { 1775,44 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public SByte m_hint;
        public Int32 m_new_item_id;
        public Int32 m_new_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_hint = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_new_item_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_new_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_num);}
            if (sp.TryWrite(2)) {sp.Write(m_hint);}
            if (sp.TryWrite(3)) {sp.Write(m_new_item_id);}
            if (sp.TryWrite(4)) {sp.Write(m_new_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitItemInfo source) {
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_hint = source.m_hint;
            m_new_item_id = source.m_new_item_id;
            m_new_item_num = source.m_new_item_num;
        }
    }
    
    [Serializable]
    public partial class SubmitReportReqInfo : NetworkMessage {
        public static int[] Id = { 1790,44 };
        public static Ctrl VC;
        public String m_been_reported_id = "";
        public String m_been_reported_name = "";
        public String m_text = "";
        public String m_reason = "";
        public String m_remark = "";
        public String m_place = "";
        public Int64 m_been_reported_talk_at;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_been_reported_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_been_reported_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_text = sp.ReadString();}
            if (sp.TryRead(3)) {m_reason = sp.ReadString();}
            if (sp.TryRead(4)) {m_remark = sp.ReadString();}
            if (sp.TryRead(5)) {m_place = sp.ReadString();}
            if (sp.TryRead(6)) {m_been_reported_talk_at = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_been_reported_id);}
            if (sp.TryWrite(1)) {sp.Write(m_been_reported_name);}
            if (sp.TryWrite(2)) {sp.Write(m_text);}
            if (sp.TryWrite(3)) {sp.Write(m_reason);}
            if (sp.TryWrite(4)) {sp.Write(m_remark);}
            if (sp.TryWrite(5)) {sp.Write(m_place);}
            if (sp.TryWrite(6)) {sp.Write(m_been_reported_talk_at);}
            sp.EnEnd();
        }
        public void CopyFrom(SubmitReportReqInfo source) {
            m_been_reported_id = source.m_been_reported_id;
            m_been_reported_name = source.m_been_reported_name;
            m_text = source.m_text;
            m_reason = source.m_reason;
            m_remark = source.m_remark;
            m_place = source.m_place;
            m_been_reported_talk_at = source.m_been_reported_talk_at;
        }
    }
    
    [Serializable]
    public partial class NbpCampaignWeekTaskInfo : NetworkMessage {
        public static int[] Id = { 1812,45 };
        public static Ctrl VC;
        public Int32 m_week;
        public List<NbpCampaignTaskInfo> m_week_tasks = new List<NbpCampaignTaskInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_week = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_week_tasks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NbpCampaignTaskInfo tmp = new NbpCampaignTaskInfo();
                    tmp.Decode(sp);
                    m_week_tasks.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_week);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_week_tasks.Count);
                for (int i = 0; i != m_week_tasks.Count; ++i) {
                    m_week_tasks[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NbpCampaignWeekTaskInfo source) {
            m_week = source.m_week;
            m_week_tasks = source.m_week_tasks;
        }
    }
    
    [Serializable]
    public partial class SetCityDecorationReqInfo : NetworkMessage {
        public static int[] Id = { 1886,46 };
        public static Ctrl VC;
        public Int16 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetCityDecorationReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class RecycleCampaignInfo : NetworkMessage {
        public static int[] Id = { 1892,46 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public RecycleCampaignCfg m_config;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new RecycleCampaignCfg();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RecycleCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
        }
    }
    
    [Serializable]
    public partial class AgentTalentSchemeUnlockReqInfo : NetworkMessage {
        public static int[] Id = { 1898,46 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public SByte m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentTalentSchemeUnlockReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignCfg : NetworkMessage {
        public static int[] Id = { 1904,46 };
        public static Ctrl VC;
        public List<AllianceTreasureCampaignAsCfg> m_as_config = new List<AllianceTreasureCampaignAsCfg>();
        public List<AllianceTreasureCampaignPlayerCfg> m_player_config = new List<AllianceTreasureCampaignPlayerCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_as_config.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceTreasureCampaignAsCfg tmp = new AllianceTreasureCampaignAsCfg();
                    tmp.Decode(sp);
                    m_as_config.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_player_config.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceTreasureCampaignPlayerCfg tmp = new AllianceTreasureCampaignPlayerCfg();
                    tmp.Decode(sp);
                    m_player_config.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_as_config.Count);
                for (int i = 0; i != m_as_config.Count; ++i) {
                    m_as_config[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_player_config.Count);
                for (int i = 0; i != m_player_config.Count; ++i) {
                    m_player_config[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureCampaignCfg source) {
            m_as_config = source.m_as_config;
            m_player_config = source.m_player_config;
        }
    }
    
    [Serializable]
    public partial class WarMarketRefreshDiscountAckInfo : NetworkMessage {
        public static int[] Id = { 1910,47 };
        public static Ctrl VC;
        public List<WarMarketExchangeItemCfg> m_discount_items = new List<WarMarketExchangeItemCfg>();
        public Boolean m_own_all_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_discount_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarMarketExchangeItemCfg tmp = new WarMarketExchangeItemCfg();
                    tmp.Decode(sp);
                    m_discount_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_own_all_item = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_discount_items.Count);
                for (int i = 0; i != m_discount_items.Count; ++i) {
                    m_discount_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_own_all_item);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketRefreshDiscountAckInfo source) {
            m_discount_items = source.m_discount_items;
            m_own_all_item = source.m_own_all_item;
        }
    }
    
    [Serializable]
    public partial class PlayerReturnEventLoginRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1919,47 };
        public static Ctrl VC;
        public Int32 m_login_day;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_login_day = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_login_day);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerReturnEventLoginRewardReqInfo source) {
            m_login_day = source.m_login_day;
        }
    }
    
    [Serializable]
    public partial class RecycleItemReqInfo : NetworkMessage {
        public static int[] Id = { 1930,48 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(RecycleItemReqInfo source) {
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStartReqInfo : NetworkMessage {
        public static int[] Id = { 1990,49 };
        public static Ctrl VC;
        public SByte m_step_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step_id);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerStartReqInfo source) {
            m_step_id = source.m_step_id;
        }
    }
    
    [Serializable]
    public partial class FlipCardCampaignInfo : NetworkMessage {
        public static int[] Id = { 1996,49 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public FlipCardConfig m_config;
        public FlipCardPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new FlipCardConfig();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new FlipCardPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class FlipCardLayerInfo : NetworkMessage {
        public static int[] Id = { 2002,49 };
        public static Ctrl VC;
        public Int32 m_layer;
        public List<FlipCardCellInfo> m_open_cells = new List<FlipCardCellInfo>();
        public List<FlipCardCellRewardInfo> m_rewards = new List<FlipCardCellRewardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_layer = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_open_cells.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlipCardCellInfo tmp = new FlipCardCellInfo();
                    tmp.Decode(sp);
                    m_open_cells.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlipCardCellRewardInfo tmp = new FlipCardCellRewardInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_layer);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_open_cells.Count);
                for (int i = 0; i != m_open_cells.Count; ++i) {
                    m_open_cells[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardLayerInfo source) {
            m_layer = source.m_layer;
            m_open_cells = source.m_open_cells;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class FlipCardNextLayerAckInfo : NetworkMessage {
        public static int[] Id = { 2008,49 };
        public static Ctrl VC;
        public FlipCardPlayerInfo m_player_info;
        public FlipCardLayerConfig m_layer_config;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_player_info = new FlipCardPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_layer_config = new FlipCardLayerConfig();
                m_layer_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_layer_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardNextLayerAckInfo source) {
            m_player_info = source.m_player_info;
            m_layer_config = source.m_layer_config;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponInfo : NetworkMessage {
        public static int[] Id = { 2040,50 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_template_id;
        public Int32 m_weapon_id;
        public SByte m_part_type;
        public SByte m_quality;
        public List<WarshipWeaponAttrInfo> m_attrs = new List<WarshipWeaponAttrInfo>();
        public List<WarshipWeaponAttrInfo> m_temp_attrs = new List<WarshipWeaponAttrInfo>();
        public List<Int32> m_skills = new List<Int32>();
        public Int16 m_warship_id;
        public Int64 m_expire_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_template_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_weapon_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_part_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_quality = sp.ReadSByte();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attrs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarshipWeaponAttrInfo tmp = new WarshipWeaponAttrInfo();
                    tmp.Decode(sp);
                    m_attrs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_temp_attrs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarshipWeaponAttrInfo tmp = new WarshipWeaponAttrInfo();
                    tmp.Decode(sp);
                    m_temp_attrs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skills.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_skills.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_expire_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_template_id);}
            if (sp.TryWrite(2)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(3)) {sp.Write(m_part_type);}
            if (sp.TryWrite(4)) {sp.Write(m_quality);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attrs.Count);
                for (int i = 0; i != m_attrs.Count; ++i) {
                    m_attrs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_temp_attrs.Count);
                for (int i = 0; i != m_temp_attrs.Count; ++i) {
                    m_temp_attrs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skills.Count);
                for (int i = 0; i != m_skills.Count; ++i) {
                    sp.Write(m_skills[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(9)) {sp.Write(m_expire_time);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponInfo source) {
            m_id = source.m_id;
            m_template_id = source.m_template_id;
            m_weapon_id = source.m_weapon_id;
            m_part_type = source.m_part_type;
            m_quality = source.m_quality;
            m_attrs = source.m_attrs;
            m_temp_attrs = source.m_temp_attrs;
            m_skills = source.m_skills;
            m_warship_id = source.m_warship_id;
            m_expire_time = source.m_expire_time;
        }
    }
    
    [Serializable]
    public partial class SubmarineOfficerExploreLog : NetworkMessage {
        public static int[] Id = { 2046,50 };
        public static Ctrl VC;
        public Int16 m_officer_id;
        public Int32 m_reward_id;
        public Int32 m_local_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_officer_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_reward_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_local_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_officer_id);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_id);}
            if (sp.TryWrite(2)) {sp.Write(m_local_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SubmarineOfficerExploreLog source) {
            m_officer_id = source.m_officer_id;
            m_reward_id = source.m_reward_id;
            m_local_id = source.m_local_id;
        }
    }
    
    [Serializable]
    public partial class CollectAgentReqInfo : NetworkMessage {
        public static int[] Id = { 2056,52 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Boolean m_is_collect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_collect = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(CollectAgentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_is_collect = source.m_is_collect;
        }
    }
    
    [Serializable]
    public partial class RaidLevelConfig : NetworkMessage {
        public static int[] Id = { 2114,54 };
        public static Ctrl VC;
        public Int32 m_level;
        public SByte m_level_type;
        public Int32 m_level_time;
        public SByte m_boss_type;
        public SByte m_player_type;
        public SByte m_troop_max_num;
        public Int64 m_member_max_num;
        public List<Int16> m_armory_ids = new List<Int16>();
        public List<ItemInfo> m_first_rewards = new List<ItemInfo>();
        public List<ItemInfo> m_repeat_rewards = new List<ItemInfo>();
        public Int32 m_level_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_level_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_level_time = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_boss_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_player_type = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_troop_max_num = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_member_max_num = sp.ReadInt64();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_armory_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_armory_ids.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_first_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_first_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_repeat_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_repeat_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {m_level_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_level_type);}
            if (sp.TryWrite(2)) {sp.Write(m_level_time);}
            if (sp.TryWrite(3)) {sp.Write(m_boss_type);}
            if (sp.TryWrite(4)) {sp.Write(m_player_type);}
            if (sp.TryWrite(5)) {sp.Write(m_troop_max_num);}
            if (sp.TryWrite(6)) {sp.Write(m_member_max_num);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_armory_ids.Count);
                for (int i = 0; i != m_armory_ids.Count; ++i) {
                    sp.Write(m_armory_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_first_rewards.Count);
                for (int i = 0; i != m_first_rewards.Count; ++i) {
                    m_first_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_repeat_rewards.Count);
                for (int i = 0; i != m_repeat_rewards.Count; ++i) {
                    m_repeat_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {sp.Write(m_level_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidLevelConfig source) {
            m_level = source.m_level;
            m_level_type = source.m_level_type;
            m_level_time = source.m_level_time;
            m_boss_type = source.m_boss_type;
            m_player_type = source.m_player_type;
            m_troop_max_num = source.m_troop_max_num;
            m_member_max_num = source.m_member_max_num;
            m_armory_ids = source.m_armory_ids;
            m_first_rewards = source.m_first_rewards;
            m_repeat_rewards = source.m_repeat_rewards;
            m_level_id = source.m_level_id;
        }
    }
    
    [Serializable]
    public partial class RaidGroupInfo : NetworkMessage {
        public static int[] Id = { 2120,54 };
        public static Ctrl VC;
        public SByte m_position;
        public List<RaidGroupAgentInfo> m_agents = new List<RaidGroupAgentInfo>();
        public List<ArmyInfo> m_troop = new List<ArmyInfo>();
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_position = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidGroupAgentInfo tmp = new RaidGroupAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troop.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_army_banner_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_position);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agents.Count);
                for (int i = 0; i != m_agents.Count; ++i) {
                    m_agents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop.Count);
                for (int i = 0; i != m_troop.Count; ++i) {
                    m_troop[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(4)) {sp.Write(m_army_banner_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidGroupInfo source) {
            m_position = source.m_position;
            m_agents = source.m_agents;
            m_troop = source.m_troop;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
        }
    }
    
    [Serializable]
    public partial class RaidHistoryAckInfo : NetworkMessage {
        public static int[] Id = { 2126,54 };
        public static Ctrl VC;
        public List<RaidHistoryEntryInfo> m_historys = new List<RaidHistoryEntryInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_historys.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidHistoryEntryInfo tmp = new RaidHistoryEntryInfo();
                    tmp.Decode(sp);
                    m_historys.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_historys.Count);
                for (int i = 0; i != m_historys.Count; ++i) {
                    m_historys[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RaidHistoryAckInfo source) {
            m_historys = source.m_historys;
        }
    }
    
    [Serializable]
    public partial class RaidHistoryReqInfo : NetworkMessage {
        public static int[] Id = { 2132,54 };
        public static Ctrl VC;
        public Int32 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidHistoryReqInfo source) {
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactLotteryReqInfo : NetworkMessage {
        public static int[] Id = { 2149,56 };
        public static Ctrl VC;
        public SByte m_lottery_type;
        public SByte m_open_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_lottery_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_open_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_lottery_type);}
            if (sp.TryWrite(1)) {sp.Write(m_open_type);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactLotteryReqInfo source) {
            m_lottery_type = source.m_lottery_type;
            m_open_type = source.m_open_type;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactLotteryItemInfo : NetworkMessage {
        public static int[] Id = { 2155,56 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_count;
        public Int32 m_new_item_id;
        public Int32 m_new_item_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_new_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_new_item_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_count);}
            if (sp.TryWrite(2)) {sp.Write(m_new_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_new_item_count);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactLotteryItemInfo source) {
            m_item_id = source.m_item_id;
            m_item_count = source.m_item_count;
            m_new_item_id = source.m_new_item_id;
            m_new_item_count = source.m_new_item_count;
        }
    }
    
    [Serializable]
    public partial class OverturnStartExploreAckInfo : NetworkMessage {
        public static int[] Id = { 2163,57 };
        public static Ctrl VC;
        public OverturnBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new OverturnBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnStartExploreAckInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class OverturnBattlePassportInfoItem : NetworkMessage {
        public static int[] Id = { 2170,57 };
        public static Ctrl VC;
        public Int32 m_times;
        public List<ItemInfo> m_normal_rewards = new List<ItemInfo>();
        public List<ItemInfo> m_senior_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_normal_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_senior_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_senior_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_times);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_rewards.Count);
                for (int i = 0; i != m_normal_rewards.Count; ++i) {
                    m_normal_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_senior_rewards.Count);
                for (int i = 0; i != m_senior_rewards.Count; ++i) {
                    m_senior_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OverturnBattlePassportInfoItem source) {
            m_times = source.m_times;
            m_normal_rewards = source.m_normal_rewards;
            m_senior_rewards = source.m_senior_rewards;
        }
    }
    
    [Serializable]
    public partial class ItemUpgradeReqInfo : NetworkMessage {
        public static int[] Id = { 2176,59 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_times;
        public Int64 m_main_item_id1;
        public Int64 m_main_item_id2;
        public Int64 m_main_item_id3;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_times = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_main_item_id1 = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_main_item_id2 = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_main_item_id3 = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_times);}
            if (sp.TryWrite(2)) {sp.Write(m_main_item_id1);}
            if (sp.TryWrite(3)) {sp.Write(m_main_item_id2);}
            if (sp.TryWrite(4)) {sp.Write(m_main_item_id3);}
            sp.EnEnd();
        }
        public void CopyFrom(ItemUpgradeReqInfo source) {
            m_id = source.m_id;
            m_times = source.m_times;
            m_main_item_id1 = source.m_main_item_id1;
            m_main_item_id2 = source.m_main_item_id2;
            m_main_item_id3 = source.m_main_item_id3;
        }
    }
    
    [Serializable]
    public partial class TroopSkinList : NetworkMessage {
        public static int[] Id = { 2188,59 };
        public static Ctrl VC;
        public List<TroopSkinInfo> m_list = new List<TroopSkinInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopSkinInfo tmp = new TroopSkinInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TroopSkinList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class MonsterCampaignInfo : NetworkMessage {
        public static int[] Id = { 2195,62 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MonsterCampaignInfo source) {
            m_basic_info = source.m_basic_info;
        }
    }
    
    [Serializable]
    public partial class FriendUserInfo : NetworkMessage {
        public static int[] Id = { 2256,63 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_server_id;
        public String m_alliance = "";
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int64 m_power;
        public Boolean m_is_online;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(3)) {m_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(6)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_is_online = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance);}
            if (sp.TryWrite(3)) {sp.Write(m_name);}
            if (sp.TryWrite(4)) {sp.Write(m_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_avatar);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(7)) {sp.Write(m_power);}
            if (sp.TryWrite(8)) {sp.Write(m_is_online);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendUserInfo source) {
            m_id = source.m_id;
            m_server_id = source.m_server_id;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_power = source.m_power;
            m_is_online = source.m_is_online;
        }
    }
    
    [Serializable]
    public partial class FriendApplyManageReqInfo : NetworkMessage {
        public static int[] Id = { 2262,63 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Boolean m_is_agree;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_is_agree = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_agree);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendApplyManageReqInfo source) {
            m_user_id = source.m_user_id;
            m_is_agree = source.m_is_agree;
        }
    }
    
    [Serializable]
    public partial class FriendShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 2268,63 };
        public static Ctrl VC;
        public Int32 m_goods_id;
        public Int32 m_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_goods_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_goods_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendShopBuyReqInfo source) {
            m_goods_id = source.m_goods_id;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class PuzzleCampaignGachaInfo : NetworkMessage {
        public static int[] Id = { 2274,63 };
        public static Ctrl VC;
        public SByte m_free_draw_times;
        public SByte m_max_free_draw_times;
        public Int32 m_cost_item_id;
        public Int32 m_cost_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_free_draw_times = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_max_free_draw_times = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_cost_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_cost_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_free_draw_times);}
            if (sp.TryWrite(1)) {sp.Write(m_max_free_draw_times);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_cost_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(PuzzleCampaignGachaInfo source) {
            m_free_draw_times = source.m_free_draw_times;
            m_max_free_draw_times = source.m_max_free_draw_times;
            m_cost_item_id = source.m_cost_item_id;
            m_cost_item_num = source.m_cost_item_num;
        }
    }
    
    [Serializable]
    public partial class AgentEquipResetEnhanceReqInfo : NetworkMessage {
        public static int[] Id = { 2286,64 };
        public static Ctrl VC;
        public Int64 m_equip_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_equip_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_equip_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentEquipResetEnhanceReqInfo source) {
            m_equip_id = source.m_equip_id;
        }
    }
    
    [Serializable]
    public partial class HomeBackgroundList : NetworkMessage {
        public static int[] Id = { 2292,64 };
        public static Ctrl VC;
        public List<HomeBackgroundInfo> m_list = new List<HomeBackgroundInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HomeBackgroundInfo tmp = new HomeBackgroundInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(HomeBackgroundList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class TroopTailSkinList : NetworkMessage {
        public static int[] Id = { 2298,64 };
        public static Ctrl VC;
        public List<TroopTailSkinInfo> m_list = new List<TroopTailSkinInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopTailSkinInfo tmp = new TroopTailSkinInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TroopTailSkinList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class SignInCampaignConfig : NetworkMessage {
        public static int[] Id = { 2315,65 };
        public static Ctrl VC;
        public Int32 m_max_day;
        public Int32 m_unlock_advance_iap;
        public Int32 m_re_sign_cost;
        public List<SignInCampaignRewardConfig> m_reward_config_list = new List<SignInCampaignRewardConfig>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_max_day = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_unlock_advance_iap = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_re_sign_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_config_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SignInCampaignRewardConfig tmp = new SignInCampaignRewardConfig();
                    tmp.Decode(sp);
                    m_reward_config_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_max_day);}
            if (sp.TryWrite(1)) {sp.Write(m_unlock_advance_iap);}
            if (sp.TryWrite(2)) {sp.Write(m_re_sign_cost);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_config_list.Count);
                for (int i = 0; i != m_reward_config_list.Count; ++i) {
                    m_reward_config_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SignInCampaignConfig source) {
            m_max_day = source.m_max_day;
            m_unlock_advance_iap = source.m_unlock_advance_iap;
            m_re_sign_cost = source.m_re_sign_cost;
            m_reward_config_list = source.m_reward_config_list;
        }
    }
    
    [Serializable]
    public partial class VideoCommentInfo : NetworkMessage {
        public static int[] Id = { 2321,66 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_content = "";
        public Int64 m_parent_id;
        public Int64 m_user_id;
        public Int16 m_server_id;
        public String m_alliance = "";
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int64 m_create_time_sec;
        public Int64 m_like_count;
        public Boolean m_self_like;
        public Int64 m_dislike_count;
        public Boolean m_self_dislike;
        public Int64 m_reply_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_content = sp.ReadString();}
            if (sp.TryRead(2)) {m_parent_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(6)) {m_name = sp.ReadString();}
            if (sp.TryRead(7)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(9)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_create_time_sec = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_like_count = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_self_like = sp.ReadBoolean();}
            if (sp.TryRead(13)) {m_dislike_count = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_self_dislike = sp.ReadBoolean();}
            if (sp.TryRead(15)) {m_reply_count = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_content);}
            if (sp.TryWrite(2)) {sp.Write(m_parent_id);}
            if (sp.TryWrite(3)) {sp.Write(m_user_id);}
            if (sp.TryWrite(4)) {sp.Write(m_server_id);}
            if (sp.TryWrite(5)) {sp.Write(m_alliance);}
            if (sp.TryWrite(6)) {sp.Write(m_name);}
            if (sp.TryWrite(7)) {sp.Write(m_icon);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar);}
            if (sp.TryWrite(9)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(10)) {sp.Write(m_create_time_sec);}
            if (sp.TryWrite(11)) {sp.Write(m_like_count);}
            if (sp.TryWrite(12)) {sp.Write(m_self_like);}
            if (sp.TryWrite(13)) {sp.Write(m_dislike_count);}
            if (sp.TryWrite(14)) {sp.Write(m_self_dislike);}
            if (sp.TryWrite(15)) {sp.Write(m_reply_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoCommentInfo source) {
            m_id = source.m_id;
            m_content = source.m_content;
            m_parent_id = source.m_parent_id;
            m_user_id = source.m_user_id;
            m_server_id = source.m_server_id;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_create_time_sec = source.m_create_time_sec;
            m_like_count = source.m_like_count;
            m_self_like = source.m_self_like;
            m_dislike_count = source.m_dislike_count;
            m_self_dislike = source.m_self_dislike;
            m_reply_count = source.m_reply_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDeleteVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2327,66 };
        public static Ctrl VC;
        public Int64 m_video_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelDeleteVideoReqInfo source) {
            m_video_id = source.m_video_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoCommentListReqInfo : NetworkMessage {
        public static int[] Id = { 2333,66 };
        public static Ctrl VC;
        public Int64 m_video_id;
        public Int64 m_comment_id;
        public Int32 m_start_index;
        public Int32 m_end_index;
        public String m_sort_type = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_comment_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_start_index = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_end_index = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_sort_type = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            if (sp.TryWrite(1)) {sp.Write(m_comment_id);}
            if (sp.TryWrite(2)) {sp.Write(m_start_index);}
            if (sp.TryWrite(3)) {sp.Write(m_end_index);}
            if (sp.TryWrite(4)) {sp.Write(m_sort_type);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoCommentListReqInfo source) {
            m_video_id = source.m_video_id;
            m_comment_id = source.m_comment_id;
            m_start_index = source.m_start_index;
            m_end_index = source.m_end_index;
            m_sort_type = source.m_sort_type;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDeleteVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2339,66 };
        public static Ctrl VC;
        public Int64 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelDeleteVideoCommentReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetRewardClaimHistoryReqInfo : NetworkMessage {
        public static int[] Id = { 2345,66 };
        public static Ctrl VC;
        public Int32 m_start_index;
        public Int32 m_end_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_index);}
            if (sp.TryWrite(1)) {sp.Write(m_end_index);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetRewardClaimHistoryReqInfo source) {
            m_start_index = source.m_start_index;
            m_end_index = source.m_end_index;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetPopularVideoListAckInfo : NetworkMessage {
        public static int[] Id = { 2351,66 };
        public static Ctrl VC;
        public List<VideoInfo> m_video_list = new List<VideoInfo>();
        public Int32 m_total_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_video_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoInfo tmp = new VideoInfo();
                    tmp.Decode(sp);
                    m_video_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_total_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_video_list.Count);
                for (int i = 0; i != m_video_list.Count; ++i) {
                    m_video_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_total_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetPopularVideoListAckInfo source) {
            m_video_list = source.m_video_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetUserVideoStatsAck : NetworkMessage {
        public static int[] Id = { 2357,66 };
        public static Ctrl VC;
        public Int32 m_submitted_video_count;
        public Int32 m_pending_reward_count;
        public Int64 m_platform_view_count;
        public Int64 m_product_view_count;
        public Int32 m_earning_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_submitted_video_count = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_pending_reward_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_platform_view_count = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_product_view_count = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_earning_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_submitted_video_count);}
            if (sp.TryWrite(1)) {sp.Write(m_pending_reward_count);}
            if (sp.TryWrite(2)) {sp.Write(m_platform_view_count);}
            if (sp.TryWrite(3)) {sp.Write(m_product_view_count);}
            if (sp.TryWrite(4)) {sp.Write(m_earning_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetUserVideoStatsAck source) {
            m_submitted_video_count = source.m_submitted_video_count;
            m_pending_reward_count = source.m_pending_reward_count;
            m_platform_view_count = source.m_platform_view_count;
            m_product_view_count = source.m_product_view_count;
            m_earning_count = source.m_earning_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetShopBuyLogReqInfo : NetworkMessage {
        public static int[] Id = { 2363,66 };
        public static Ctrl VC;
        public Int32 m_start_index;
        public Int32 m_end_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_index);}
            if (sp.TryWrite(1)) {sp.Write(m_end_index);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetShopBuyLogReqInfo source) {
            m_start_index = source.m_start_index;
            m_end_index = source.m_end_index;
        }
    }
    
    [Serializable]
    public partial class VideoChannelRefreshVideoAccessStatusAckInfo : NetworkMessage {
        public static int[] Id = { 2369,66 };
        public static Ctrl VC;
        public VideoInfo m_video;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_video = new VideoInfo();
                m_video.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_video.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelRefreshVideoAccessStatusAckInfo source) {
            m_video = source.m_video;
        }
    }
    
    [Serializable]
    public partial class UserMedalSimpleInfo : NetworkMessage {
        public static int[] Id = { 2394,68 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_star;
        public SByte m_slot;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_star = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_slot = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_star);}
            if (sp.TryWrite(2)) {sp.Write(m_slot);}
            sp.EnEnd();
        }
        public void CopyFrom(UserMedalSimpleInfo source) {
            m_id = source.m_id;
            m_star = source.m_star;
            m_slot = source.m_slot;
        }
    }
    
    [Serializable]
    public partial class KvkStrategyGroupInfo : NetworkMessage {
        public static int[] Id = { 2400,69 };
        public static Ctrl VC;
        public Int32 m_group_id;
        public Int32 m_current_strategy_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_current_strategy_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {sp.Write(m_current_strategy_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkStrategyGroupInfo source) {
            m_group_id = source.m_group_id;
            m_current_strategy_id = source.m_current_strategy_id;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventChangeBuildingInfo : NetworkMessage {
        public static int[] Id = { 2436,72 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_old_level;
        public Int16 m_new_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_old_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_new_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_old_level);}
            if (sp.TryWrite(2)) {sp.Write(m_new_level);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventChangeBuildingInfo source) {
            m_id = source.m_id;
            m_old_level = source.m_old_level;
            m_new_level = source.m_new_level;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetShopDataAckInfo : NetworkMessage {
        public static int[] Id = { 2442,72 };
        public static Ctrl VC;
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_current_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_current_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_info.Count);
                for (int i = 0; i != m_exchange_info.Count; ++i) {
                    m_exchange_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_current_items.Count);
                for (int i = 0; i != m_current_items.Count; ++i) {
                    m_current_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventGetShopDataAckInfo source) {
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventTutorialStepReqInfo : NetworkMessage {
        public static int[] Id = { 2448,72 };
        public static Ctrl VC;
        public Int32 m_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventTutorialStepReqInfo source) {
            m_step = source.m_step;
        }
    }
    
}
