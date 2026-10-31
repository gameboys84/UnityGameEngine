using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class AccountBindInfo : NetworkMessage {
        public static int[] Id = { 4,1 };
        public static Ctrl VC;
        public Int16 m_account_type;
        public String m_token = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_account_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_token = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_account_type);}
            if (sp.TryWrite(1)) {sp.Write(m_token);}
            sp.EnEnd();
        }
        public void CopyFrom(AccountBindInfo source) {
            m_account_type = source.m_account_type;
            m_token = source.m_token;
        }
    }
    
    [Serializable]
    public partial class CommonAckInfo : NetworkMessage {
        public static int[] Id = { 10,1 };
        public static Ctrl VC;
        public Int16 m_api;
        public Int16 m_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_api = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_api);}
            if (sp.TryWrite(1)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(CommonAckInfo source) {
            m_api = source.m_api;
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class BuildingWaitInfo : NetworkMessage {
        public static int[] Id = { 16,1 };
        public static Ctrl VC;
        public Boolean m_is_new;
        public Int16 m_pos;
        public Int16 m_build_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_new = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_pos = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_build_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_new);}
            if (sp.TryWrite(1)) {sp.Write(m_pos);}
            if (sp.TryWrite(2)) {sp.Write(m_build_type);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingWaitInfo source) {
            m_is_new = source.m_is_new;
            m_pos = source.m_pos;
            m_build_type = source.m_build_type;
        }
    }
    
    [Serializable]
    public partial class GmInfo : NetworkMessage {
        public static int[] Id = { 22,1 };
        public static Ctrl VC;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(GmInfo source) {
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class TroopInfo : NetworkMessage {
        public static int[] Id = { 28,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_total_troops = new List<ArmyInfo>();
        public List<ArmyInfo> m_city_troops = new List<ArmyInfo>();
        public List<TroopProgInfo> m_progs = new List<TroopProgInfo>();
        public List<TroopProgInfo> m_waitings = new List<TroopProgInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_total_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_total_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_city_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopProgInfo tmp = new TroopProgInfo();
                    tmp.Decode(sp);
                    m_progs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_waitings.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopProgInfo tmp = new TroopProgInfo();
                    tmp.Decode(sp);
                    m_waitings.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_total_troops.Count);
                for (int i = 0; i != m_total_troops.Count; ++i) {
                    m_total_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_troops.Count);
                for (int i = 0; i != m_city_troops.Count; ++i) {
                    m_city_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_progs.Count);
                for (int i = 0; i != m_progs.Count; ++i) {
                    m_progs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_waitings.Count);
                for (int i = 0; i != m_waitings.Count; ++i) {
                    m_waitings[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopInfo source) {
            m_total_troops = source.m_total_troops;
            m_city_troops = source.m_city_troops;
            m_progs = source.m_progs;
            m_waitings = source.m_waitings;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class FightArmyLost : NetworkMessage {
        public static int[] Id = { 34,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int16 m_army_type;
        public Int64 m_army_cnt;
        public Int64 m_killed_cnt;
        public Int64 m_repair_cnt;
        public Int64 m_recovery_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_army_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_army_cnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_killed_cnt = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_repair_cnt = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_recovery_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_army_type);}
            if (sp.TryWrite(4)) {sp.Write(m_army_cnt);}
            if (sp.TryWrite(5)) {sp.Write(m_killed_cnt);}
            if (sp.TryWrite(6)) {sp.Write(m_repair_cnt);}
            if (sp.TryWrite(7)) {sp.Write(m_recovery_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FightArmyLost source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_army_type = source.m_army_type;
            m_army_cnt = source.m_army_cnt;
            m_killed_cnt = source.m_killed_cnt;
            m_repair_cnt = source.m_repair_cnt;
            m_recovery_cnt = source.m_recovery_cnt;
        }
    }
    
    [Serializable]
    public partial class FightWave : NetworkMessage {
        public static int[] Id = { 40,1 };
        public static Ctrl VC;
        public Int16 m_wave;
        public FightUserV1 m_atker;
        public FightUserV1 m_defer;
        public List<FightRound> m_rounds = new List<FightRound>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_wave = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_atker = new FightUserV1();
                m_atker.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_defer = new FightUserV1();
                m_defer.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rounds.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightRound tmp = new FightRound();
                    tmp.Decode(sp);
                    m_rounds.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_wave);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_atker.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_defer.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rounds.Count);
                for (int i = 0; i != m_rounds.Count; ++i) {
                    m_rounds[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FightWave source) {
            m_wave = source.m_wave;
            m_atker = source.m_atker;
            m_defer = source.m_defer;
            m_rounds = source.m_rounds;
        }
    }
    
    [Serializable]
    public partial class CleanAction : NetworkMessage {
        public static int[] Id = { 46,1 };
        public static Ctrl VC;
        public Int16 m_apply_type;
        public Boolean m_is_p1;
        public Int16 m_effect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_apply_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_effect = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_apply_type);}
            if (sp.TryWrite(1)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(2)) {sp.Write(m_effect);}
            sp.EnEnd();
        }
        public void CopyFrom(CleanAction source) {
            m_apply_type = source.m_apply_type;
            m_is_p1 = source.m_is_p1;
            m_effect = source.m_effect;
        }
    }
    
    [Serializable]
    public partial class ResTile : NetworkMessage {
        public static int[] Id = { 52,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_level;
        public Int64 m_cnt;
        public SByte m_status;
        public SByte m_res_type;
        public SByte m_tile_type;
        public Int64 m_owner;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public FieldCaptivesInfo m_captives;
        public Int64 m_gather_speed;
        public Int64 m_gather_time;
        public Int64 m_capacity;
        public Int64 m_fighting;
        public AllianceSnapInfo m_landalliance;
        public Int16 m_land_home_server_id;
        public ItemTileInfo m_item_tile;
        public Int64 m_group_id;
        public LanderTile m_lander;
        public Int64 m_gather_cnt;
        public Boolean m_refresh_by_skill;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_cnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_res_type = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_tile_type = sp.ReadSByte();}
            if (sp.TryRead(8)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_name = sp.ReadString();}
            if (sp.TryRead(10)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                m_captives = new FieldCaptivesInfo();
                m_captives.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_gather_speed = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_gather_time = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_capacity = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(16)) {
                m_landalliance = new AllianceSnapInfo();
                m_landalliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_land_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(18)) {
                m_item_tile = new ItemTileInfo();
                m_item_tile.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(20)) {
                m_lander = new LanderTile();
                m_lander.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(21)) {m_gather_cnt = sp.ReadInt64();}
            if (sp.TryRead(22)) {m_refresh_by_skill = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_cnt);}
            if (sp.TryWrite(5)) {sp.Write(m_status);}
            if (sp.TryWrite(6)) {sp.Write(m_res_type);}
            if (sp.TryWrite(7)) {sp.Write(m_tile_type);}
            if (sp.TryWrite(8)) {sp.Write(m_owner);}
            if (sp.TryWrite(9)) {sp.Write(m_name);}
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {int pos = sp.GetPos();sp.Skip(2); m_captives.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(12)) {sp.Write(m_gather_speed);}
            if (sp.TryWrite(13)) {sp.Write(m_gather_time);}
            if (sp.TryWrite(14)) {sp.Write(m_capacity);}
            if (sp.TryWrite(15)) {sp.Write(m_fighting);}
            if (sp.TryWrite(16)) {int pos = sp.GetPos();sp.Skip(2); m_landalliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(17)) {sp.Write(m_land_home_server_id);}
            if (sp.TryWrite(18)) {int pos = sp.GetPos();sp.Skip(2); m_item_tile.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(19)) {sp.Write(m_group_id);}
            if (sp.TryWrite(20)) {int pos = sp.GetPos();sp.Skip(2); m_lander.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(21)) {sp.Write(m_gather_cnt);}
            if (sp.TryWrite(22)) {sp.Write(m_refresh_by_skill);}
            sp.EnEnd();
        }
        public void CopyFrom(ResTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_level = source.m_level;
            m_cnt = source.m_cnt;
            m_status = source.m_status;
            m_res_type = source.m_res_type;
            m_tile_type = source.m_tile_type;
            m_owner = source.m_owner;
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_captives = source.m_captives;
            m_gather_speed = source.m_gather_speed;
            m_gather_time = source.m_gather_time;
            m_capacity = source.m_capacity;
            m_fighting = source.m_fighting;
            m_landalliance = source.m_landalliance;
            m_land_home_server_id = source.m_land_home_server_id;
            m_item_tile = source.m_item_tile;
            m_group_id = source.m_group_id;
            m_lander = source.m_lander;
            m_gather_cnt = source.m_gather_cnt;
            m_refresh_by_skill = source.m_refresh_by_skill;
        }
    }
    
    [Serializable]
    public partial class CompressedLandData : NetworkMessage {
        public static int[] Id = { 58,1 };
        public static Ctrl VC;
        public Int16 m_chunk_x;
        public Int16 m_chunk_y;
        public Byte[] m_data;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_chunk_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_chunk_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_data = sp.ReadBytes2();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_chunk_x);}
            if (sp.TryWrite(1)) {sp.Write(m_chunk_y);}
            if (sp.TryWrite(2)) {sp.WriteBytes2(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(CompressedLandData source) {
            m_chunk_x = source.m_chunk_x;
            m_chunk_y = source.m_chunk_y;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class MarchReqInfo : NetworkMessage {
        public static int[] Id = { 64,1 };
        public static Ctrl VC;
        public Int16 m_src_x;
        public Int16 m_src_y;
        public Int16 m_dst_x;
        public Int16 m_dst_y;
        public Int16 m_march_type;
        public Int16 m_subtype;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Int16 m_hero_id;
        public Int64 m_param;
        public List<Int16> m_agent = new List<Int16>();
        public RealPos m_src;
        public RealPos m_dst;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_src_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_src_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_dst_x = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_dst_y = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_march_type = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_param = sp.ReadInt64();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(10)) {
                m_src = new RealPos();
                m_src.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                m_dst = new RealPos();
                m_dst.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_src_x);}
            if (sp.TryWrite(1)) {sp.Write(m_src_y);}
            if (sp.TryWrite(2)) {sp.Write(m_dst_x);}
            if (sp.TryWrite(3)) {sp.Write(m_dst_y);}
            if (sp.TryWrite(4)) {sp.Write(m_march_type);}
            if (sp.TryWrite(5)) {sp.Write(m_subtype);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(8)) {sp.Write(m_param);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_src.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {int pos = sp.GetPos();sp.Skip(2); m_dst.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(12)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MarchReqInfo source) {
            m_src_x = source.m_src_x;
            m_src_y = source.m_src_y;
            m_dst_x = source.m_dst_x;
            m_dst_y = source.m_dst_y;
            m_march_type = source.m_march_type;
            m_subtype = source.m_subtype;
            m_troops = source.m_troops;
            m_hero_id = source.m_hero_id;
            m_param = source.m_param;
            m_agent = source.m_agent;
            m_src = source.m_src;
            m_dst = source.m_dst;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceTaxInfo : NetworkMessage {
        public static int[] Id = { 70,1 };
        public static Ctrl VC;
        public Int64 m_land_score;
        public Int16 m_tax_level;
        public List<TaxLandCnt> m_land_cnt = new List<TaxLandCnt>();
        public Int32 m_total_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_land_score = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_tax_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_land_cnt.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaxLandCnt tmp = new TaxLandCnt();
                    tmp.Decode(sp);
                    m_land_cnt.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_total_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_land_score);}
            if (sp.TryWrite(1)) {sp.Write(m_tax_level);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_land_cnt.Count);
                for (int i = 0; i != m_land_cnt.Count; ++i) {
                    m_land_cnt[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_total_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTaxInfo source) {
            m_land_score = source.m_land_score;
            m_tax_level = source.m_tax_level;
            m_land_cnt = source.m_land_cnt;
            m_total_cnt = source.m_total_cnt;
        }
    }
    
    [Serializable]
    public partial class AllianceAckInfo : NetworkMessage {
        public static int[] Id = { 76,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Boolean m_apply;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_apply = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_apply);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceAckInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_apply = source.m_apply;
        }
    }
    
    [Serializable]
    public partial class PlayerMailBaseInfo : NetworkMessage {
        public static int[] Id = { 82,1 };
        public static Ctrl VC;
        public ContactInfo m_sender;
        public Receivers m_receiver;
        public String m_title = "";
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_sender = new ContactInfo();
                m_sender.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_receiver = new Receivers();
                m_receiver.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_sender.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_receiver.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_title);}
            if (sp.TryWrite(3)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerMailBaseInfo source) {
            m_sender = source.m_sender;
            m_receiver = source.m_receiver;
            m_title = source.m_title;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class CaptiveInfo : NetworkMessage {
        public static int[] Id = { 88,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_hero_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_hero_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_hero_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptiveInfo source) {
            m_user_id = source.m_user_id;
            m_hero_id = source.m_hero_id;
        }
    }
    
    [Serializable]
    public partial class ReforceReportBaseInfo : NetworkMessage {
        public static int[] Id = { 94,1 };
        public static Ctrl VC;
        public Int32 m_alliance_rank;
        public String m_alliance_name = "";
        public String m_user_name = "";
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_name);}
            if (sp.TryWrite(2)) {sp.Write(m_user_name);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ReforceReportBaseInfo source) {
            m_alliance_rank = source.m_alliance_rank;
            m_alliance_name = source.m_alliance_name;
            m_user_name = source.m_user_name;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class EventRewardReportDetailInfo : NetworkMessage {
        public static int[] Id = { 100,1 };
        public static Ctrl VC;
        public EventRewardReportBaseInfo m_base_info;
        public Int32 m_item_id;
        public Int32 m_item_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new EventRewardReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_amount = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(EventRewardReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_item_id = source.m_item_id;
            m_item_amount = source.m_item_amount;
        }
    }
    
    [Serializable]
    public partial class RebelSummaryReportDetailInfo : NetworkMessage {
        public static int[] Id = { 106,1 };
        public static Ctrl VC;
        public RebelSummaryReportBaseInfo m_base_info;
        public List<RebelSummaryReportMemberInfo> m_users = new List<RebelSummaryReportMemberInfo>();
        public FightReportGve m_fight_report;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelSummaryReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RebelSummaryReportMemberInfo tmp = new RebelSummaryReportMemberInfo();
                    tmp.Decode(sp);
                    m_users.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_fight_report = new FightReportGve();
                m_fight_report.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_users.Count);
                for (int i = 0; i != m_users.Count; ++i) {
                    m_users[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_fight_report.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelSummaryReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_users = source.m_users;
            m_fight_report = source.m_fight_report;
        }
    }
    
    [Serializable]
    public partial class NpcMailDetailInfo : NetworkMessage {
        public static int[] Id = { 112,1 };
        public static Ctrl VC;
        public NpcMailBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new NpcMailBaseInfo();
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
        public void CopyFrom(NpcMailDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class HeroFreeReportDetailInfo : NetworkMessage {
        public static int[] Id = { 118,1 };
        public static Ctrl VC;
        public HeroFreeReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new HeroFreeReportBaseInfo();
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
        public void CopyFrom(HeroFreeReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class EventReportDetailInfo : NetworkMessage {
        public static int[] Id = { 124,1 };
        public static Ctrl VC;
        public EventReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new EventReportBaseInfo();
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
        public void CopyFrom(EventReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class PrizeDetailInfo : NetworkMessage {
        public static int[] Id = { 130,1 };
        public static Ctrl VC;
        public Item m_item;
        public ResTypeInfo m_res;
        public Int32 m_param1;
        public Int32 m_param2;
        public Int32 m_param3;
        public String m_content = "";
        public Int64 m_delay;
        public Int64 m_i64_param1;
        public Int64 m_i64_param2;
        public String m_str_param1 = "";
        public List<String> m_content_params = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_item = new Item();
                m_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_res = new ResTypeInfo();
                m_res.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_param1 = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_param2 = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_param3 = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_content = sp.ReadString();}
            if (sp.TryRead(6)) {m_delay = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_i64_param1 = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_i64_param2 = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_str_param1 = sp.ReadString();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_content_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_content_params.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_res.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_param1);}
            if (sp.TryWrite(3)) {sp.Write(m_param2);}
            if (sp.TryWrite(4)) {sp.Write(m_param3);}
            if (sp.TryWrite(5)) {sp.Write(m_content);}
            if (sp.TryWrite(6)) {sp.Write(m_delay);}
            if (sp.TryWrite(7)) {sp.Write(m_i64_param1);}
            if (sp.TryWrite(8)) {sp.Write(m_i64_param2);}
            if (sp.TryWrite(9)) {sp.Write(m_str_param1);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_content_params.Count);
                for (int i = 0; i != m_content_params.Count; ++i) {
                    sp.Write(m_content_params[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PrizeDetailInfo source) {
            m_item = source.m_item;
            m_res = source.m_res;
            m_param1 = source.m_param1;
            m_param2 = source.m_param2;
            m_param3 = source.m_param3;
            m_content = source.m_content;
            m_delay = source.m_delay;
            m_i64_param1 = source.m_i64_param1;
            m_i64_param2 = source.m_i64_param2;
            m_str_param1 = source.m_str_param1;
            m_content_params = source.m_content_params;
        }
    }
    
    [Serializable]
    public partial class GetResearchAckInfo : NetworkMessage {
        public static int[] Id = { 136,1 };
        public static Ctrl VC;
        public ResearchDetailInfo m_detail_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_detail_info = new ResearchDetailInfo();
                m_detail_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_detail_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(GetResearchAckInfo source) {
            m_detail_info = source.m_detail_info;
        }
    }
    
    [Serializable]
    public partial class BuffNtfInfo : NetworkMessage {
        public static int[] Id = { 142,1 };
        public static Ctrl VC;
        public Int64 m_source;
        public Int16 m_effect_type;
        public Int64 m_effect_num;
        public Int64 m_duration;
        public Boolean m_open_or_close;
        public Int64 m_prog_start;
        public Int64 m_prog_end;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_source = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_effect_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_effect_num = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_duration = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_open_or_close = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_prog_end = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_source);}
            if (sp.TryWrite(1)) {sp.Write(m_effect_type);}
            if (sp.TryWrite(2)) {sp.Write(m_effect_num);}
            if (sp.TryWrite(3)) {sp.Write(m_duration);}
            if (sp.TryWrite(4)) {sp.Write(m_open_or_close);}
            if (sp.TryWrite(5)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(6)) {sp.Write(m_prog_end);}
            sp.EnEnd();
        }
        public void CopyFrom(BuffNtfInfo source) {
            m_source = source.m_source;
            m_effect_type = source.m_effect_type;
            m_effect_num = source.m_effect_num;
            m_duration = source.m_duration;
            m_open_or_close = source.m_open_or_close;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
        }
    }
    
    [Serializable]
    public partial class BeginDailyQuestAckInfo : NetworkMessage {
        public static int[] Id = { 148,1 };
        public static Ctrl VC;
        public DailyQuestInfo m_questinfo;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_questinfo = new DailyQuestInfo();
                m_questinfo.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_questinfo.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(BeginDailyQuestAckInfo source) {
            m_questinfo = source.m_questinfo;
        }
    }
    
    [Serializable]
    public partial class QuestListAckInfo : NetworkMessage {
        public static int[] Id = { 154,1 };
        public static Ctrl VC;
        public List<QuestBasicInfo> m_list_info = new List<QuestBasicInfo>();
        public List<QuestPendingInfo> m_pending_info = new List<QuestPendingInfo>();
        public ChapterMissionTable m_chapter_mission_table;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestBasicInfo tmp = new QuestBasicInfo();
                    tmp.Decode(sp);
                    m_list_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pending_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestPendingInfo tmp = new QuestPendingInfo();
                    tmp.Decode(sp);
                    m_pending_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_chapter_mission_table = new ChapterMissionTable();
                m_chapter_mission_table.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list_info.Count);
                for (int i = 0; i != m_list_info.Count; ++i) {
                    m_list_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pending_info.Count);
                for (int i = 0; i != m_pending_info.Count; ++i) {
                    m_pending_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_chapter_mission_table.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestListAckInfo source) {
            m_list_info = source.m_list_info;
            m_pending_info = source.m_pending_info;
            m_chapter_mission_table = source.m_chapter_mission_table;
        }
    }
    
    [Serializable]
    public partial class UserAllianceNtfInfo : NetworkMessage {
        public static int[] Id = { 160,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public UserAllianceBrief m_user;
        public AllianceBriefInfo m_brief;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_user = new UserAllianceBrief();
                m_user.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_brief = new AllianceBriefInfo();
                m_brief.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_user.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_brief.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(UserAllianceNtfInfo source) {
            m_user_id = source.m_user_id;
            m_user = source.m_user;
            m_brief = source.m_brief;
        }
    }
    
    [Serializable]
    public partial class RallyInfo : NetworkMessage {
        public static int[] Id = { 166,1 };
        public static Ctrl VC;
        public Int64 m_atk_user;
        public String m_atk_name = "";
        public Int16 m_atk_icon;
        public UserAllianceBrief m_atk_alliance;
        public TilePos m_atk_pos;
        public Int16 m_atk_server_id;
        public Int64 m_def_user;
        public String m_def_name = "";
        public Int16 m_def_icon;
        public UserAllianceBrief m_def_alliance;
        public TilePos m_def_pos;
        public Int16 m_def_server_id;
        public Int16 m_def_level;
        public Int16 m_stat;
        public Int16 m_type;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public List<TroopGroup> m_group_list = new List<TroopGroup>();
        public List<MarchInfo> m_march_list = new List<MarchInfo>();
        public Int64 m_max_cnt;
        public Int64 m_cur_cnt;
        public List<MarchInfo> m_rally_march = new List<MarchInfo>();
        public SByte m_rebel_stat;
        public Int16 m_rebel_cfg_id;
        public Int32 m_reinforce_ap;
        public MapUnitId m_target;
        public Int16 m_subtype;
        public Int32 m_building_type;
        public String m_atk_avatar = "";
        public String m_def_avatar = "";
        public Int64 m_map_guid;
        public String m_unique_id = "";
        public Int16 m_atk_avatar_frame;
        public Int16 m_def_avatar_frame;
        public Int16 m_rally_troop_type;
        public Boolean m_auto_depart;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_atk_user = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_atk_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_atk_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_atk_alliance = new UserAllianceBrief();
                m_atk_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_atk_server_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_def_user = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_def_name = sp.ReadString();}
            if (sp.TryRead(8)) {m_def_icon = sp.ReadInt16();}
            if (sp.TryRead(9)) {
                m_def_alliance = new UserAllianceBrief();
                m_def_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                m_def_pos = new TilePos();
                m_def_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_def_server_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_def_level = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_stat = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(15)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(16)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_group_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_group_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(18)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_march_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {m_max_cnt = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_cur_cnt = sp.ReadInt64();}
            if (sp.TryRead(21)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rally_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_rally_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(22)) {m_rebel_stat = sp.ReadSByte();}
            if (sp.TryRead(23)) {m_rebel_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(24)) {m_reinforce_ap = sp.ReadInt32();}
            if (sp.TryRead(25)) {
                m_target = new MapUnitId();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(26)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(27)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(28)) {m_atk_avatar = sp.ReadString();}
            if (sp.TryRead(29)) {m_def_avatar = sp.ReadString();}
            if (sp.TryRead(30)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(31)) {m_unique_id = sp.ReadString();}
            if (sp.TryRead(32)) {m_atk_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(33)) {m_def_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(34)) {m_rally_troop_type = sp.ReadInt16();}
            if (sp.TryRead(35)) {m_auto_depart = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_atk_user);}
            if (sp.TryWrite(1)) {sp.Write(m_atk_name);}
            if (sp.TryWrite(2)) {sp.Write(m_atk_icon);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_atk_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_atk_server_id);}
            if (sp.TryWrite(6)) {sp.Write(m_def_user);}
            if (sp.TryWrite(7)) {sp.Write(m_def_name);}
            if (sp.TryWrite(8)) {sp.Write(m_def_icon);}
            if (sp.TryWrite(9)) {int pos = sp.GetPos();sp.Skip(2); m_def_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_def_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {sp.Write(m_def_server_id);}
            if (sp.TryWrite(12)) {sp.Write(m_def_level);}
            if (sp.TryWrite(13)) {sp.Write(m_stat);}
            if (sp.TryWrite(14)) {sp.Write(m_type);}
            if (sp.TryWrite(15)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(16)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_group_list.Count);
                for (int i = 0; i != m_group_list.Count; ++i) {
                    m_group_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(18)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_march_list.Count);
                for (int i = 0; i != m_march_list.Count; ++i) {
                    m_march_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(19)) {sp.Write(m_max_cnt);}
            if (sp.TryWrite(20)) {sp.Write(m_cur_cnt);}
            if (sp.TryWrite(21)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rally_march.Count);
                for (int i = 0; i != m_rally_march.Count; ++i) {
                    m_rally_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(22)) {sp.Write(m_rebel_stat);}
            if (sp.TryWrite(23)) {sp.Write(m_rebel_cfg_id);}
            if (sp.TryWrite(24)) {sp.Write(m_reinforce_ap);}
            if (sp.TryWrite(25)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(26)) {sp.Write(m_subtype);}
            if (sp.TryWrite(27)) {sp.Write(m_building_type);}
            if (sp.TryWrite(28)) {sp.Write(m_atk_avatar);}
            if (sp.TryWrite(29)) {sp.Write(m_def_avatar);}
            if (sp.TryWrite(30)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(31)) {sp.Write(m_unique_id);}
            if (sp.TryWrite(32)) {sp.Write(m_atk_avatar_frame);}
            if (sp.TryWrite(33)) {sp.Write(m_def_avatar_frame);}
            if (sp.TryWrite(34)) {sp.Write(m_rally_troop_type);}
            if (sp.TryWrite(35)) {sp.Write(m_auto_depart);}
            sp.EnEnd();
        }
        public void CopyFrom(RallyInfo source) {
            m_atk_user = source.m_atk_user;
            m_atk_name = source.m_atk_name;
            m_atk_icon = source.m_atk_icon;
            m_atk_alliance = source.m_atk_alliance;
            m_atk_pos = source.m_atk_pos;
            m_atk_server_id = source.m_atk_server_id;
            m_def_user = source.m_def_user;
            m_def_name = source.m_def_name;
            m_def_icon = source.m_def_icon;
            m_def_alliance = source.m_def_alliance;
            m_def_pos = source.m_def_pos;
            m_def_server_id = source.m_def_server_id;
            m_def_level = source.m_def_level;
            m_stat = source.m_stat;
            m_type = source.m_type;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_group_list = source.m_group_list;
            m_march_list = source.m_march_list;
            m_max_cnt = source.m_max_cnt;
            m_cur_cnt = source.m_cur_cnt;
            m_rally_march = source.m_rally_march;
            m_rebel_stat = source.m_rebel_stat;
            m_rebel_cfg_id = source.m_rebel_cfg_id;
            m_reinforce_ap = source.m_reinforce_ap;
            m_target = source.m_target;
            m_subtype = source.m_subtype;
            m_building_type = source.m_building_type;
            m_atk_avatar = source.m_atk_avatar;
            m_def_avatar = source.m_def_avatar;
            m_map_guid = source.m_map_guid;
            m_unique_id = source.m_unique_id;
            m_atk_avatar_frame = source.m_atk_avatar_frame;
            m_def_avatar_frame = source.m_def_avatar_frame;
            m_rally_troop_type = source.m_rally_troop_type;
            m_auto_depart = source.m_auto_depart;
        }
    }
    
    [Serializable]
    public partial class BuyItemInfo : NetworkMessage {
        public static int[] Id = { 172,1 };
        public static Ctrl VC;
        public Int32 m_discount_id;
        public Int32 m_item_id;
        public Int32 m_use_id;
        public Int16 m_operation;
        public Int32 m_count;
        public Int32 m_shop_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_discount_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_use_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_operation = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_count = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_shop_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_discount_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_use_id);}
            if (sp.TryWrite(3)) {sp.Write(m_operation);}
            if (sp.TryWrite(4)) {sp.Write(m_count);}
            if (sp.TryWrite(5)) {sp.Write(m_shop_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BuyItemInfo source) {
            m_discount_id = source.m_discount_id;
            m_item_id = source.m_item_id;
            m_use_id = source.m_use_id;
            m_operation = source.m_operation;
            m_count = source.m_count;
            m_shop_id = source.m_shop_id;
        }
    }
    
    [Serializable]
    public partial class PowerUpdateInfo : NetworkMessage {
        public static int[] Id = { 178,1 };
        public static Ctrl VC;
        public Int64 m_power;
        public Int32 m_power_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_power_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_power);}
            if (sp.TryWrite(1)) {sp.Write(m_power_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(PowerUpdateInfo source) {
            m_power = source.m_power;
            m_power_rank = source.m_power_rank;
        }
    }
    
    [Serializable]
    public partial class AllianceOfferHelpInfo : NetworkMessage {
        public static int[] Id = { 184,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_help_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_help_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_help_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceOfferHelpInfo source) {
            m_user_id = source.m_user_id;
            m_help_id = source.m_help_id;
        }
    }
    
    [Serializable]
    public partial class Ranklist : NetworkMessage {
        public static int[] Id = { 190,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public List<Rankinfo> m_infos = new List<Rankinfo>();
        public Int32 m_user_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Rankinfo tmp = new Rankinfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_user_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_infos.Count);
                for (int i = 0; i != m_infos.Count; ++i) {
                    m_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_user_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(Ranklist source) {
            m_type = source.m_type;
            m_infos = source.m_infos;
            m_user_rank = source.m_user_rank;
        }
    }
    
    [Serializable]
    public partial class UserRankinfoNtf : NetworkMessage {
        public static int[] Id = { 196,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int32 m_rank;
        public List<Rankinfo> m_infos = new List<Rankinfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Rankinfo tmp = new Rankinfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_rank);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(UserRankinfoNtf source) {
            m_type = source.m_type;
            m_rank = source.m_rank;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class BuildingFreeReq : NetworkMessage {
        public static int[] Id = { 202,1 };
        public static Ctrl VC;
        public Int16 m_prog_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prog_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prog_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingFreeReq source) {
            m_prog_id = source.m_prog_id;
        }
    }
    
    [Serializable]
    public partial class BeScoutListInfo : NetworkMessage {
        public static int[] Id = { 208,1 };
        public static Ctrl VC;
        public List<BeScoutInfo> m_infos = new List<BeScoutInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BeScoutInfo tmp = new BeScoutInfo();
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
        public void CopyFrom(BeScoutListInfo source) {
            m_infos = source.m_infos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class RelocateNtfInfo : NetworkMessage {
        public static int[] Id = { 214,1 };
        public static Ctrl VC;
        public ServerTilePos m_src;
        public ServerTilePos m_dst;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_src = new ServerTilePos();
                m_src.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_dst = new ServerTilePos();
                m_dst.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_src.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_dst.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(RelocateNtfInfo source) {
            m_src = source.m_src;
            m_dst = source.m_dst;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceModRankInfo : NetworkMessage {
        public static int[] Id = { 220,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_new_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_new_rank = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_new_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceModRankInfo source) {
            m_user_id = source.m_user_id;
            m_new_rank = source.m_new_rank;
        }
    }
    
    [Serializable]
    public partial class AllianceInviteInfo : NetworkMessage {
        public static int[] Id = { 226,1 };
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
        public void CopyFrom(AllianceInviteInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class AllianceInviteConfirmInfo : NetworkMessage {
        public static int[] Id = { 232,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Boolean m_accept;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_accept = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_accept);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceInviteConfirmInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_accept = source.m_accept;
        }
    }
    
    [Serializable]
    public partial class AllianceResApplyReq : NetworkMessage {
        public static int[] Id = { 238,1 };
        public static Ctrl VC;
        public ResTypeInfo m_res;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_res = new ResTypeInfo();
                m_res.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_res.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResApplyReq source) {
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class DominionInfo : NetworkMessage {
        public static int[] Id = { 244,1 };
        public static Ctrl VC;
        public KtilePos m_pos;
        public Int16 m_status;
        public Int16 m_type;
        public SByte m_res_level;
        public Int64 m_left_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new KtilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_res_level = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_left_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_status);}
            if (sp.TryWrite(2)) {sp.Write(m_type);}
            if (sp.TryWrite(3)) {sp.Write(m_res_level);}
            if (sp.TryWrite(4)) {sp.Write(m_left_time);}
            sp.EnEnd();
        }
        public void CopyFrom(DominionInfo source) {
            m_pos = source.m_pos;
            m_status = source.m_status;
            m_type = source.m_type;
            m_res_level = source.m_res_level;
            m_left_time = source.m_left_time;
        }
    }
    
    [Serializable]
    public partial class ConstReq : NetworkMessage {
        public static int[] Id = { 250,1 };
        public static Ctrl VC;
        public String m_keyword = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_keyword = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_keyword);}
            sp.EnEnd();
        }
        public void CopyFrom(ConstReq source) {
            m_keyword = source.m_keyword;
        }
    }
    
    [Serializable]
    public partial class SearchNode : NetworkMessage {
        public static int[] Id = { 256,1 };
        public static Ctrl VC;
        public String m_name = "";
        public Int64 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SearchNode source) {
            m_name = source.m_name;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class OnlineUsersReq : NetworkMessage {
        public static int[] Id = { 262,1 };
        public static Ctrl VC;
        public Int32 m_type;
        public Int16 m_serverid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_serverid = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_serverid);}
            sp.EnEnd();
        }
        public void CopyFrom(OnlineUsersReq source) {
            m_type = source.m_type;
            m_serverid = source.m_serverid;
        }
    }
    
    [Serializable]
    public partial class ListAllianceCommentInfo : NetworkMessage {
        public static int[] Id = { 268,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public List<AllianceCommentInfo> m_comments = new List<AllianceCommentInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_comments.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceCommentInfo tmp = new AllianceCommentInfo();
                    tmp.Decode(sp);
                    m_comments.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_comments.Count);
                for (int i = 0; i != m_comments.Count; ++i) {
                    m_comments[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceCommentInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_comments = source.m_comments;
        }
    }
    
    [Serializable]
    public partial class AuthorityInfo : NetworkMessage {
        public static int[] Id = { 274,1 };
        public static Ctrl VC;
        public Int16 m_auth_type;
        public Boolean m_auth_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_auth_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_auth_flag = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_auth_type);}
            if (sp.TryWrite(1)) {sp.Write(m_auth_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(AuthorityInfo source) {
            m_auth_type = source.m_auth_type;
            m_auth_flag = source.m_auth_flag;
        }
    }
    
    [Serializable]
    public partial class SearchUsersReq : NetworkMessage {
        public static int[] Id = { 280,1 };
        public static Ctrl VC;
        public String m_prefix = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prefix = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prefix);}
            sp.EnEnd();
        }
        public void CopyFrom(SearchUsersReq source) {
            m_prefix = source.m_prefix;
        }
    }
    
    [Serializable]
    public partial class AllianceGiftInfo : NetworkMessage {
        public static int[] Id = { 286,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_gift_cfg_id;
        public SByte m_status;
        public ItemInfo m_item;
        public Int64 m_expire_time;
        public String m_from_player = "";
        public Int32 m_iap_id;
        public Int32 m_from_alliance;
        public String m_iap_title = "";
        public List<String> m_iap_title_params = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_gift_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(3)) {
                m_item = new ItemInfo();
                m_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_expire_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_from_player = sp.ReadString();}
            if (sp.TryRead(6)) {m_iap_id = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_from_alliance = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_iap_title = sp.ReadString();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_iap_title_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_iap_title_params.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_gift_cfg_id);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_expire_time);}
            if (sp.TryWrite(5)) {sp.Write(m_from_player);}
            if (sp.TryWrite(6)) {sp.Write(m_iap_id);}
            if (sp.TryWrite(7)) {sp.Write(m_from_alliance);}
            if (sp.TryWrite(8)) {sp.Write(m_iap_title);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_iap_title_params.Count);
                for (int i = 0; i != m_iap_title_params.Count; ++i) {
                    sp.Write(m_iap_title_params[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceGiftInfo source) {
            m_id = source.m_id;
            m_gift_cfg_id = source.m_gift_cfg_id;
            m_status = source.m_status;
            m_item = source.m_item;
            m_expire_time = source.m_expire_time;
            m_from_player = source.m_from_player;
            m_iap_id = source.m_iap_id;
            m_from_alliance = source.m_from_alliance;
            m_iap_title = source.m_iap_title;
            m_iap_title_params = source.m_iap_title_params;
        }
    }
    
    [Serializable]
    public partial class AllianceGiftLevelInfo : NetworkMessage {
        public static int[] Id = { 292,1 };
        public static Ctrl VC;
        public Int16 m_level;
        public Int64 m_points;
        public Int64 m_fortune_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_fortune_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {sp.Write(m_fortune_points);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceGiftLevelInfo source) {
            m_level = source.m_level;
            m_points = source.m_points;
            m_fortune_points = source.m_fortune_points;
        }
    }
    
    [Serializable]
    public partial class IapPrepareReq : NetworkMessage {
        public static int[] Id = { 298,1 };
        public static Ctrl VC;
        public Int32 m_iap_type;
        public String m_iap_sub_type = "";
        public String m_token = "";
        public String m_app_store = "";
        public Int32 m_package_id;
        public SByte m_package_count;
        public String m_product_id = "";
        public Int64 m_to_user_id;
        public String m_ext_data = "";
        public Int32 m_sub_id;
        public Boolean m_inner_flag;
        public Int32 m_discount_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_iap_sub_type = sp.ReadString();}
            if (sp.TryRead(2)) {m_token = sp.ReadString();}
            if (sp.TryRead(3)) {m_app_store = sp.ReadString();}
            if (sp.TryRead(4)) {m_package_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_package_count = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_product_id = sp.ReadString();}
            if (sp.TryRead(7)) {m_to_user_id = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_ext_data = sp.ReadString();}
            if (sp.TryRead(9)) {m_sub_id = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_inner_flag = sp.ReadBoolean();}
            if (sp.TryRead(11)) {m_discount_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(1)) {sp.Write(m_iap_sub_type);}
            if (sp.TryWrite(2)) {sp.Write(m_token);}
            if (sp.TryWrite(3)) {sp.Write(m_app_store);}
            if (sp.TryWrite(4)) {sp.Write(m_package_id);}
            if (sp.TryWrite(5)) {sp.Write(m_package_count);}
            if (sp.TryWrite(6)) {sp.Write(m_product_id);}
            if (sp.TryWrite(7)) {sp.Write(m_to_user_id);}
            if (sp.TryWrite(8)) {sp.Write(m_ext_data);}
            if (sp.TryWrite(9)) {sp.Write(m_sub_id);}
            if (sp.TryWrite(10)) {sp.Write(m_inner_flag);}
            if (sp.TryWrite(11)) {sp.Write(m_discount_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPrepareReq source) {
            m_iap_type = source.m_iap_type;
            m_iap_sub_type = source.m_iap_sub_type;
            m_token = source.m_token;
            m_app_store = source.m_app_store;
            m_package_id = source.m_package_id;
            m_package_count = source.m_package_count;
            m_product_id = source.m_product_id;
            m_to_user_id = source.m_to_user_id;
            m_ext_data = source.m_ext_data;
            m_sub_id = source.m_sub_id;
            m_inner_flag = source.m_inner_flag;
            m_discount_item_id = source.m_discount_item_id;
        }
    }
    
    [Serializable]
    public partial class GmCmdInfo : NetworkMessage {
        public static int[] Id = { 304,1 };
        public static Ctrl VC;
        public Int16 m_code;
        public String m_result = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_result = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(GmCmdInfo source) {
            m_code = source.m_code;
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class UserStatisticsInfo : NetworkMessage {
        public static int[] Id = { 310,1 };
        public static Ctrl VC;
        public Int16 m_typ;
        public Int64 m_val;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_typ = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_val = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_typ);}
            if (sp.TryWrite(1)) {sp.Write(m_val);}
            sp.EnEnd();
        }
        public void CopyFrom(UserStatisticsInfo source) {
            m_typ = source.m_typ;
            m_val = source.m_val;
        }
    }
    
    [Serializable]
    public partial class ClientDataKey : NetworkMessage {
        public static int[] Id = { 316,1 };
        public static Ctrl VC;
        public String m_key = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientDataKey source) {
            m_key = source.m_key;
        }
    }
    
    [Serializable]
    public partial class MonumentSnapInfo : NetworkMessage {
        public static int[] Id = { 322,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_pres;
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public AllianceSnapInfo m_alliance;
        public Int16 m_owner_home_server_id;
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_pres = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {
                m_alliance = new AllianceSnapInfo();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_owner_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_pres);}
            if (sp.TryWrite(4)) {sp.Write(m_name);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_owner_home_server_id);}
            if (sp.TryWrite(9)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentSnapInfo source) {
            m_server_id = source.m_server_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_pres = source.m_pres;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_alliance = source.m_alliance;
            m_owner_home_server_id = source.m_owner_home_server_id;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class DailyEventNode : NetworkMessage {
        public static int[] Id = { 328,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_type;
        public Int64 m_cur_points;
        public Int64 m_need_points;
        public Int16 m_score;
        public Int64 m_exp_add;
        public Int16 m_exp_get_status;
        public Boolean m_is_auto_finish;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cur_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_need_points = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_exp_add = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_exp_get_status = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_is_auto_finish = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_points);}
            if (sp.TryWrite(3)) {sp.Write(m_need_points);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {sp.Write(m_exp_add);}
            if (sp.TryWrite(6)) {sp.Write(m_exp_get_status);}
            if (sp.TryWrite(7)) {sp.Write(m_is_auto_finish);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyEventNode source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_cur_points = source.m_cur_points;
            m_need_points = source.m_need_points;
            m_score = source.m_score;
            m_exp_add = source.m_exp_add;
            m_exp_get_status = source.m_exp_get_status;
            m_is_auto_finish = source.m_is_auto_finish;
        }
    }
    
    [Serializable]
    public partial class DailyEventActionReq : NetworkMessage {
        public static int[] Id = { 334,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int64 m_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyEventActionReq source) {
            m_type = source.m_type;
            m_points = source.m_points;
        }
    }
    
    [Serializable]
    public partial class InvitationInfo : NetworkMessage {
        public static int[] Id = { 340,1 };
        public static Ctrl VC;
        public SByte m_vail_count;
        public Int16 m_total;
        public Int16 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_vail_count = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_total = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_vail_count);}
            if (sp.TryWrite(1)) {sp.Write(m_total);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(InvitationInfo source) {
            m_vail_count = source.m_vail_count;
            m_total = source.m_total;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class GovernmentInfo : NetworkMessage {
        public static int[] Id = { 346,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public List<TitleInfo> m_list = new List<TitleInfo>();
        public SByte m_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TitleInfo tmp = new TitleInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_flag = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(GovernmentInfo source) {
            m_server_id = source.m_server_id;
            m_list = source.m_list;
            m_flag = source.m_flag;
        }
    }
    
    [Serializable]
    public partial class NuclearStrileBaseInfo : NetworkMessage {
        public static int[] Id = { 352,1 };
        public static Ctrl VC;
        public MonumentSnapInfo m_snap;
        public ServerTilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_snap = new MonumentSnapInfo();
                m_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(NuclearStrileBaseInfo source) {
            m_snap = source.m_snap;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class GetPrizeInfo : NetworkMessage {
        public static int[] Id = { 358,1 };
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
        public void CopyFrom(GetPrizeInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class DonateDiamondInfo : NetworkMessage {
        public static int[] Id = { 364,1 };
        public static Ctrl VC;
        public List<Int64> m_to_user_id = new List<Int64>();
        public String m_from_fb_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_to_user_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_to_user_id.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_from_fb_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_to_user_id.Count);
                for (int i = 0; i != m_to_user_id.Count; ++i) {
                    sp.Write(m_to_user_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_from_fb_name);}
            sp.EnEnd();
        }
        public void CopyFrom(DonateDiamondInfo source) {
            m_to_user_id = source.m_to_user_id;
            m_from_fb_name = source.m_from_fb_name;
        }
    }
    
    [Serializable]
    public partial class TranslateInfo : NetworkMessage {
        public static int[] Id = { 370,1 };
        public static Ctrl VC;
        public Int32 m_origin;
        public String m_lang = "";
        public String m_context = "";
        public String m_context_id = "";
        public String m_origin_context = "";
        public String m_en_context = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_origin = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_lang = sp.ReadString();}
            if (sp.TryRead(2)) {m_context = sp.ReadString();}
            if (sp.TryRead(3)) {m_context_id = sp.ReadString();}
            if (sp.TryRead(4)) {m_origin_context = sp.ReadString();}
            if (sp.TryRead(5)) {m_en_context = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_origin);}
            if (sp.TryWrite(1)) {sp.Write(m_lang);}
            if (sp.TryWrite(2)) {sp.Write(m_context);}
            if (sp.TryWrite(3)) {sp.Write(m_context_id);}
            if (sp.TryWrite(4)) {sp.Write(m_origin_context);}
            if (sp.TryWrite(5)) {sp.Write(m_en_context);}
            sp.EnEnd();
        }
        public void CopyFrom(TranslateInfo source) {
            m_origin = source.m_origin;
            m_lang = source.m_lang;
            m_context = source.m_context;
            m_context_id = source.m_context_id;
            m_origin_context = source.m_origin_context;
            m_en_context = source.m_en_context;
        }
    }
    
    [Serializable]
    public partial class ResTileInfo : NetworkMessage {
        public static int[] Id = { 376,1 };
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
        public void CopyFrom(ResTileInfo source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryListInfo : NetworkMessage {
        public static int[] Id = { 382,1 };
        public static Ctrl VC;
        public Int64 m_amount;
        public List<AllianceSalaryInfo> m_infos = new List<AllianceSalaryInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceSalaryInfo tmp = new AllianceSalaryInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_amount);}
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
        public void CopyFrom(AllianceSalaryListInfo source) {
            m_amount = source.m_amount;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class OfflineDataInfo : NetworkMessage {
        public static int[] Id = { 388,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_repair_info = new List<ArmyInfo>();
        public List<ArmyInfo> m_train_info = new List<ArmyInfo>();
        public SByte m_fight_statu;
        public Boolean m_defence_center_teleport;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_repair_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_repair_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_train_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_train_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_fight_statu = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_defence_center_teleport = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_repair_info.Count);
                for (int i = 0; i != m_repair_info.Count; ++i) {
                    m_repair_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_train_info.Count);
                for (int i = 0; i != m_train_info.Count; ++i) {
                    m_train_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_fight_statu);}
            if (sp.TryWrite(3)) {sp.Write(m_defence_center_teleport);}
            sp.EnEnd();
        }
        public void CopyFrom(OfflineDataInfo source) {
            m_repair_info = source.m_repair_info;
            m_train_info = source.m_train_info;
            m_fight_statu = source.m_fight_statu;
            m_defence_center_teleport = source.m_defence_center_teleport;
        }
    }
    
    [Serializable]
    public partial class IapPriceNode : NetworkMessage {
        public static int[] Id = { 394,1 };
        public static Ctrl VC;
        public SByte m_currency_type;
        public Int32 m_pay_price;
        public String m_product_id = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_currency_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_pay_price = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_product_id = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_currency_type);}
            if (sp.TryWrite(1)) {sp.Write(m_pay_price);}
            if (sp.TryWrite(2)) {sp.Write(m_product_id);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPriceNode source) {
            m_currency_type = source.m_currency_type;
            m_pay_price = source.m_pay_price;
            m_product_id = source.m_product_id;
        }
    }
    
    [Serializable]
    public partial class EmbeditemsInfo : NetworkMessage {
        public static int[] Id = { 400,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_pos = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_pos);}
            sp.EnEnd();
        }
        public void CopyFrom(EmbeditemsInfo source) {
            m_id = source.m_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class GetRoleListInfo : NetworkMessage {
        public static int[] Id = { 406,1 };
        public static Ctrl VC;
        public List<RoleInfo> m_roles = new List<RoleInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_roles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RoleInfo tmp = new RoleInfo();
                    tmp.Decode(sp);
                    m_roles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_roles.Count);
                for (int i = 0; i != m_roles.Count; ++i) {
                    m_roles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GetRoleListInfo source) {
            m_roles = source.m_roles;
        }
    }
    
    [Serializable]
    public partial class RecruitInfo : NetworkMessage {
        public static int[] Id = { 412,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int16 m_logo;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_server_id;
        public String m_lang = "";
        public Boolean m_open;
        public Int64 m_power;
        public Int64 m_land_count;
        public Int16 m_member_cnt;
        public String m_owner_name = "";
        public Int16 m_gift_level;
        public Int16 m_color;
        public Int16 m_glory;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(4)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_lang = sp.ReadString();}
            if (sp.TryRead(6)) {m_open = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_land_count = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_member_cnt = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(11)) {m_gift_level = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_glory = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_logo);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_abbr);}
            if (sp.TryWrite(4)) {sp.Write(m_server_id);}
            if (sp.TryWrite(5)) {sp.Write(m_lang);}
            if (sp.TryWrite(6)) {sp.Write(m_open);}
            if (sp.TryWrite(7)) {sp.Write(m_power);}
            if (sp.TryWrite(8)) {sp.Write(m_land_count);}
            if (sp.TryWrite(9)) {sp.Write(m_member_cnt);}
            if (sp.TryWrite(10)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(11)) {sp.Write(m_gift_level);}
            if (sp.TryWrite(12)) {sp.Write(m_color);}
            if (sp.TryWrite(13)) {sp.Write(m_glory);}
            sp.EnEnd();
        }
        public void CopyFrom(RecruitInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_logo = source.m_logo;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_server_id = source.m_server_id;
            m_lang = source.m_lang;
            m_open = source.m_open;
            m_power = source.m_power;
            m_land_count = source.m_land_count;
            m_member_cnt = source.m_member_cnt;
            m_owner_name = source.m_owner_name;
            m_gift_level = source.m_gift_level;
            m_color = source.m_color;
            m_glory = source.m_glory;
        }
    }
    
    [Serializable]
    public partial class RegionMsgListReqInfo : NetworkMessage {
        public static int[] Id = { 418,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public SByte m_lang;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_lang = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_lang);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionMsgListReqInfo source) {
            m_server_id = source.m_server_id;
            m_lang = source.m_lang;
        }
    }
    
    [Serializable]
    public partial class ActiveRecordInfo : NetworkMessage {
        public static int[] Id = { 424,1 };
        public static Ctrl VC;
        public Int32 m_active_id;
        public String m_udid = "";
        public String m_data = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_active_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_udid = sp.ReadString();}
            if (sp.TryRead(2)) {m_data = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_active_id);}
            if (sp.TryWrite(1)) {sp.Write(m_udid);}
            if (sp.TryWrite(2)) {sp.Write(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(ActiveRecordInfo source) {
            m_active_id = source.m_active_id;
            m_udid = source.m_udid;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class AnnouceListInfo : NetworkMessage {
        public static int[] Id = { 430,1 };
        public static Ctrl VC;
        public List<AnnouceInfo> m_list = new List<AnnouceInfo>();
        public Boolean m_need_pop;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AnnouceInfo tmp = new AnnouceInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_need_pop = sp.ReadBoolean();}
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
            if (sp.TryWrite(1)) {sp.Write(m_need_pop);}
            sp.EnEnd();
        }
        public void CopyFrom(AnnouceListInfo source) {
            m_list = source.m_list;
            m_need_pop = source.m_need_pop;
        }
    }
    
    [Serializable]
    public partial class TranslateStandardFileInfo : NetworkMessage {
        public static int[] Id = { 436,1 };
        public static Ctrl VC;
        public String m_translate_file_name = "";
        public String m_cdn_path = "";
        public String m_translate_file_name_second = "";
        public String m_cdn_path_second = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_translate_file_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_cdn_path = sp.ReadString();}
            if (sp.TryRead(2)) {m_translate_file_name_second = sp.ReadString();}
            if (sp.TryRead(3)) {m_cdn_path_second = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_translate_file_name);}
            if (sp.TryWrite(1)) {sp.Write(m_cdn_path);}
            if (sp.TryWrite(2)) {sp.Write(m_translate_file_name_second);}
            if (sp.TryWrite(3)) {sp.Write(m_cdn_path_second);}
            sp.EnEnd();
        }
        public void CopyFrom(TranslateStandardFileInfo source) {
            m_translate_file_name = source.m_translate_file_name;
            m_cdn_path = source.m_cdn_path;
            m_translate_file_name_second = source.m_translate_file_name_second;
            m_cdn_path_second = source.m_cdn_path_second;
        }
    }
    
    [Serializable]
    public partial class PveLevelInfo : NetworkMessage {
        public static int[] Id = { 442,1 };
        public static Ctrl VC;
        public PveCost m_ap_default_cost;
        public List<PveCost> m_ap_level_cost = new List<PveCost>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_ap_default_cost = new PveCost();
                m_ap_default_cost.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ap_level_cost.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PveCost tmp = new PveCost();
                    tmp.Decode(sp);
                    m_ap_level_cost.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_ap_default_cost.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ap_level_cost.Count);
                for (int i = 0; i != m_ap_level_cost.Count; ++i) {
                    m_ap_level_cost[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PveLevelInfo source) {
            m_ap_default_cost = source.m_ap_default_cost;
            m_ap_level_cost = source.m_ap_level_cost;
        }
    }
    
    [Serializable]
    public partial class HuodongRankRewardInfo : NetworkMessage {
        public static int[] Id = { 448,1 };
        public static Ctrl VC;
        public Int32 m_rank_u;
        public Int32 m_rank_d;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank_u = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_rank_d = sp.ReadInt32();}
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
            if (sp.TryWrite(0)) {sp.Write(m_rank_u);}
            if (sp.TryWrite(1)) {sp.Write(m_rank_d);}
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
        public void CopyFrom(HuodongRankRewardInfo source) {
            m_rank_u = source.m_rank_u;
            m_rank_d = source.m_rank_d;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class HuodongRankInfo : NetworkMessage {
        public static int[] Id = { 454,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public String m_alliance = "";
        public String m_name = "";
        public Int64 m_score;
        public Int32 m_rank;
        public Int64 m_id;
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_color;
        public Int16 m_logo;
        public Int16 m_vip_level;
        public Int16 m_favor_agent;
        public Int32 m_skin;
        public List<Int64> m_extra_params = new List<Int64>();
        public Int64 m_last_update_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(8)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_vip_level = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_favor_agent = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_skin = sp.ReadInt32();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_extra_params.Add(tmp);
                }
            }
            if (sp.TryRead(15)) {m_last_update_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_id);}
            if (sp.TryWrite(6)) {sp.Write(m_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(9)) {sp.Write(m_color);}
            if (sp.TryWrite(10)) {sp.Write(m_logo);}
            if (sp.TryWrite(11)) {sp.Write(m_vip_level);}
            if (sp.TryWrite(12)) {sp.Write(m_favor_agent);}
            if (sp.TryWrite(13)) {sp.Write(m_skin);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_params.Count);
                for (int i = 0; i != m_extra_params.Count; ++i) {
                    sp.Write(m_extra_params[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(15)) {sp.Write(m_last_update_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(HuodongRankInfo source) {
            m_server_id = source.m_server_id;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_score = source.m_score;
            m_rank = source.m_rank;
            m_id = source.m_id;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_vip_level = source.m_vip_level;
            m_favor_agent = source.m_favor_agent;
            m_skin = source.m_skin;
            m_extra_params = source.m_extra_params;
            m_last_update_dt = source.m_last_update_dt;
        }
    }
    
    [Serializable]
    public partial class ItemFusionInfo : NetworkMessage {
        public static int[] Id = { 460,1 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(ItemFusionInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class SpecialQuestRewardReq : NetworkMessage {
        public static int[] Id = { 466,1 };
        public static Ctrl VC;
        public Int16 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SpecialQuestRewardReq source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AllianceDonateInfo : NetworkMessage {
        public static int[] Id = { 472,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public SendResInfo m_res;
        public Int64 m_time;
        public Int16 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {
                m_res = new SendResInfo();
                m_res.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_rank = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_res.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_time);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceDonateInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_res = source.m_res;
            m_time = source.m_time;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class VoteFounder : NetworkMessage {
        public static int[] Id = { 478,1 };
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
        public void CopyFrom(VoteFounder source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_brief = source.m_brief;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ScrollHqLevel : NetworkMessage {
        public static int[] Id = { 484,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int16 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollHqLevel source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class LangLikeRankMemberList : NetworkMessage {
        public static int[] Id = { 490,1 };
        public static Ctrl VC;
        public List<LangLikeRankMemberInfo> m_members = new List<LangLikeRankMemberInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_members.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LangLikeRankMemberInfo tmp = new LangLikeRankMemberInfo();
                    tmp.Decode(sp);
                    m_members.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_members.Count);
                for (int i = 0; i != m_members.Count; ++i) {
                    m_members[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LangLikeRankMemberList source) {
            m_members = source.m_members;
        }
    }
    
    [Serializable]
    public partial class AllianceSetSuggestedReqInfo : NetworkMessage {
        public static int[] Id = { 496,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_target_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_target_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_target_type);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSetSuggestedReqInfo source) {
            m_type = source.m_type;
            m_target_type = source.m_target_type;
        }
    }
    
    [Serializable]
    public partial class GetAllianceResearchReqInfo : NetworkMessage {
        public static int[] Id = { 502,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_target_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_target_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_target_type);}
            sp.EnEnd();
        }
        public void CopyFrom(GetAllianceResearchReqInfo source) {
            m_type = source.m_type;
            m_target_type = source.m_target_type;
        }
    }
    
    [Serializable]
    public partial class UpgradeAllianceResearchNtfInfo : NetworkMessage {
        public static int[] Id = { 508,1 };
        public static Ctrl VC;
        public List<AllianceResearchProgInfo> m_progs = new List<AllianceResearchProgInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceResearchProgInfo tmp = new AllianceResearchProgInfo();
                    tmp.Decode(sp);
                    m_progs.Add(tmp);
                }
                sp.BindCtrl(VC);
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
            sp.EnEnd();
        }
        public void CopyFrom(UpgradeAllianceResearchNtfInfo source) {
            m_progs = source.m_progs;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDonateRankInfo : NetworkMessage {
        public static int[] Id = { 514,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_alliance_rank;
        public Int64 m_score;
        public Int64 m_last_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_rank = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_last_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_last_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchDonateRankInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_alliance_rank = source.m_alliance_rank;
            m_score = source.m_score;
            m_last_time = source.m_last_time;
        }
    }
    
    [Serializable]
    public partial class RebelAttackRewardBaseInfo : NetworkMessage {
        public static int[] Id = { 520,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_id;
        public Int16 m_level;
        public SByte m_stat;
        public Int16 m_cfg_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_cfg_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_id);}
            if (sp.TryWrite(4)) {sp.Write(m_level);}
            if (sp.TryWrite(5)) {sp.Write(m_stat);}
            if (sp.TryWrite(6)) {sp.Write(m_cfg_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelAttackRewardBaseInfo source) {
            m_type = source.m_type;
            m_x = source.m_x;
            m_y = source.m_y;
            m_id = source.m_id;
            m_level = source.m_level;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
        }
    }
    
    [Serializable]
    public partial class CompressedInfo : NetworkMessage {
        public static int[] Id = { 526,1 };
        public static Ctrl VC;
        public Int32 m_orig_size;
        public String m_data = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_orig_size = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_data = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_orig_size);}
            if (sp.TryWrite(1)) {sp.Write(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(CompressedInfo source) {
            m_orig_size = source.m_orig_size;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class RegionMonumentReqInfo : NetworkMessage {
        public static int[] Id = { 532,1 };
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
        public void CopyFrom(RegionMonumentReqInfo source) {
            m_server_id = source.m_server_id;
            m_region_user_id = source.m_region_user_id;
        }
    }
    
    [Serializable]
    public partial class AllianceJoinApplyMailInfo : NetworkMessage {
        public static int[] Id = { 538,1 };
        public static Ctrl VC;
        public AllianceJoinApplyMail m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceJoinApplyMail();
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
        public void CopyFrom(AllianceJoinApplyMailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class DoComeBackRewardsDetail : NetworkMessage {
        public static int[] Id = { 544,1 };
        public static Ctrl VC;
        public SByte m_operate;
        public SByte m_dayth_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_operate = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_dayth_reward = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_operate);}
            if (sp.TryWrite(1)) {sp.Write(m_dayth_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(DoComeBackRewardsDetail source) {
            m_operate = source.m_operate;
            m_dayth_reward = source.m_dayth_reward;
        }
    }
    
    [Serializable]
    public partial class RegionViewHeroReqInfo : NetworkMessage {
        public static int[] Id = { 550,1 };
        public static Ctrl VC;
        public Int64 m_region_user_id;
        public Int16 m_user_server_id;
        public Int64 m_user_id;
        public Int16 m_hero_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_region_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_hero_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_region_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            if (sp.TryWrite(3)) {sp.Write(m_hero_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionViewHeroReqInfo source) {
            m_region_user_id = source.m_region_user_id;
            m_user_server_id = source.m_user_server_id;
            m_user_id = source.m_user_id;
            m_hero_id = source.m_hero_id;
        }
    }
    
    [Serializable]
    public partial class AsBossSummonDetailInfo : NetworkMessage {
        public static int[] Id = { 556,1 };
        public static Ctrl VC;
        public AsBossSummonBaseInfo m_base_info;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public String m_as_abbr = "";
        public List<AsBossFeedHisInfo> m_feed_history = new List<AsBossFeedHisInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AsBossSummonBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryRead(2)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_feed_history.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsBossFeedHisInfo tmp = new AsBossFeedHisInfo();
                    tmp.Decode(sp);
                    m_feed_history.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(2)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_feed_history.Count);
                for (int i = 0; i != m_feed_history.Count; ++i) {
                    m_feed_history[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AsBossSummonDetailInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
            m_as_abbr = source.m_as_abbr;
            m_feed_history = source.m_feed_history;
        }
    }
    
    [Serializable]
    public partial class GetAchievementRewardReqInfo : NetworkMessage {
        public static int[] Id = { 562,1 };
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
        public void CopyFrom(GetAchievementRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class IstanaTitleChangeInfo : NetworkMessage {
        public static int[] Id = { 568,1 };
        public static Ctrl VC;
        public Int16 m_title_id;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaTitleChangeInfo source) {
            m_title_id = source.m_title_id;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class FlagRankInfo : NetworkMessage {
        public static int[] Id = { 574,1 };
        public static Ctrl VC;
        public SByte m_flag;
        public Int16 m_num;
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_flag = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_flag);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(FlagRankInfo source) {
            m_flag = source.m_flag;
            m_num = source.m_num;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class HuodongClassInfo : NetworkMessage {
        public static int[] Id = { 580,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_seq;
        public String m_text = "";
        public String m_picture = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_seq = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_text = sp.ReadString();}
            if (sp.TryRead(3)) {m_picture = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_seq);}
            if (sp.TryWrite(2)) {sp.Write(m_text);}
            if (sp.TryWrite(3)) {sp.Write(m_picture);}
            sp.EnEnd();
        }
        public void CopyFrom(HuodongClassInfo source) {
            m_id = source.m_id;
            m_seq = source.m_seq;
            m_text = source.m_text;
            m_picture = source.m_picture;
        }
    }
    
    [Serializable]
    public partial class GuestIstanaRegionOwnerReqInfo : NetworkMessage {
        public static int[] Id = { 586,1 };
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
        public void CopyFrom(GuestIstanaRegionOwnerReqInfo source) {
            m_server_id = source.m_server_id;
            m_region_user_id = source.m_region_user_id;
        }
    }
    
    [Serializable]
    public partial class MarchListNtfInfo : NetworkMessage {
        public static int[] Id = { 592,1 };
        public static Ctrl VC;
        public List<MarchInfo> m_march_list = new List<MarchInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_march_list.Add(tmp);
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
                sp.Write((UInt16)m_march_list.Count);
                for (int i = 0; i != m_march_list.Count; ++i) {
                    m_march_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MarchListNtfInfo source) {
            m_march_list = source.m_march_list;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class RegionServerListInfo : NetworkMessage {
        public static int[] Id = { 598,1 };
        public static Ctrl VC;
        public List<RegionListInfo> m_region_list = new List<RegionListInfo>();
        public List<ServerInfo> m_list = new List<ServerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_region_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RegionListInfo tmp = new RegionListInfo();
                    tmp.Decode(sp);
                    m_region_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ServerInfo tmp = new ServerInfo();
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
                sp.Write((UInt16)m_region_list.Count);
                for (int i = 0; i != m_region_list.Count; ++i) {
                    m_region_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
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
        public void CopyFrom(RegionServerListInfo source) {
            m_region_list = source.m_region_list;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class CompressedReqInfo : NetworkMessage {
        public static int[] Id = { 604,1 };
        public static Ctrl VC;
        public String m_data = "";
        public Int32 m_orig_size;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_data = sp.ReadString();}
            if (sp.TryRead(1)) {m_orig_size = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_data);}
            if (sp.TryWrite(1)) {sp.Write(m_orig_size);}
            sp.EnEnd();
        }
        public void CopyFrom(CompressedReqInfo source) {
            m_data = source.m_data;
            m_orig_size = source.m_orig_size;
        }
    }
    
    [Serializable]
    public partial class DaythRewardInfo : NetworkMessage {
        public static int[] Id = { 610,1 };
        public static Ctrl VC;
        public List<LevelRewardDetail> m_levels_rewards_detail = new List<LevelRewardDetail>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_levels_rewards_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LevelRewardDetail tmp = new LevelRewardDetail();
                    tmp.Decode(sp);
                    m_levels_rewards_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_levels_rewards_detail.Count);
                for (int i = 0; i != m_levels_rewards_detail.Count; ++i) {
                    m_levels_rewards_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DaythRewardInfo source) {
            m_levels_rewards_detail = source.m_levels_rewards_detail;
        }
    }
    
    [Serializable]
    public partial class SevendayStatusInfo : NetworkMessage {
        public static int[] Id = { 616,1 };
        public static Ctrl VC;
        public Boolean m_is_open;
        public Int64 m_start_time;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_open = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_open);}
            if (sp.TryWrite(1)) {sp.Write(m_start_time);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(SevendayStatusInfo source) {
            m_is_open = source.m_is_open;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class FpsStartBattleAckInfo : NetworkMessage {
        public static int[] Id = { 622,1 };
        public static Ctrl VC;
        public Int16 m_fps_level;
        public FpsAgentInfo m_agent_info;
        public Int32 m_enemy_hp_param;
        public Int32 m_enemy_att_param;
        public Int32 m_ally_hp_param;
        public Int32 m_ally_att_param;
        public Int32 m_dmg_factor_head;
        public Int32 m_dmg_factor_chest;
        public Int32 m_dmg_factor_limbs;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fps_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_agent_info = new FpsAgentInfo();
                m_agent_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_enemy_hp_param = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_enemy_att_param = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_ally_hp_param = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_ally_att_param = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_dmg_factor_head = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_dmg_factor_chest = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_dmg_factor_limbs = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fps_level);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_agent_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_enemy_hp_param);}
            if (sp.TryWrite(3)) {sp.Write(m_enemy_att_param);}
            if (sp.TryWrite(4)) {sp.Write(m_ally_hp_param);}
            if (sp.TryWrite(5)) {sp.Write(m_ally_att_param);}
            if (sp.TryWrite(6)) {sp.Write(m_dmg_factor_head);}
            if (sp.TryWrite(7)) {sp.Write(m_dmg_factor_chest);}
            if (sp.TryWrite(8)) {sp.Write(m_dmg_factor_limbs);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsStartBattleAckInfo source) {
            m_fps_level = source.m_fps_level;
            m_agent_info = source.m_agent_info;
            m_enemy_hp_param = source.m_enemy_hp_param;
            m_enemy_att_param = source.m_enemy_att_param;
            m_ally_hp_param = source.m_ally_hp_param;
            m_ally_att_param = source.m_ally_att_param;
            m_dmg_factor_head = source.m_dmg_factor_head;
            m_dmg_factor_chest = source.m_dmg_factor_chest;
            m_dmg_factor_limbs = source.m_dmg_factor_limbs;
        }
    }
    
    [Serializable]
    public partial class FpsRewardInfo : NetworkMessage {
        public static int[] Id = { 628,1 };
        public static Ctrl VC;
        public Int64 m_exp;
        public Int64 m_cash;
        public Int64 m_head_kill_cash;
        public List<FpsRewardItem> m_reward_item_list = new List<FpsRewardItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exp = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cash = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_head_kill_cash = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_item_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FpsRewardItem tmp = new FpsRewardItem();
                    tmp.Decode(sp);
                    m_reward_item_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exp);}
            if (sp.TryWrite(1)) {sp.Write(m_cash);}
            if (sp.TryWrite(2)) {sp.Write(m_head_kill_cash);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_item_list.Count);
                for (int i = 0; i != m_reward_item_list.Count; ++i) {
                    m_reward_item_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FpsRewardInfo source) {
            m_exp = source.m_exp;
            m_cash = source.m_cash;
            m_head_kill_cash = source.m_head_kill_cash;
            m_reward_item_list = source.m_reward_item_list;
        }
    }
    
    [Serializable]
    public partial class GloryWallsDetail : NetworkMessage {
        public static int[] Id = { 634,1 };
        public static Ctrl VC;
        public SByte m_glory_type;
        public SByte m_rounds;
        public SByte m_rank;
        public Int16 m_server_id;
        public Int16 m_flag;
        public String m_as_name = "";
        public String m_as_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_glory_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_rounds = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_rank = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_flag = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_as_abbr = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_glory_type);}
            if (sp.TryWrite(1)) {sp.Write(m_rounds);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_server_id);}
            if (sp.TryWrite(4)) {sp.Write(m_flag);}
            if (sp.TryWrite(5)) {sp.Write(m_as_name);}
            if (sp.TryWrite(6)) {sp.Write(m_as_abbr);}
            sp.EnEnd();
        }
        public void CopyFrom(GloryWallsDetail source) {
            m_glory_type = source.m_glory_type;
            m_rounds = source.m_rounds;
            m_rank = source.m_rank;
            m_server_id = source.m_server_id;
            m_flag = source.m_flag;
            m_as_name = source.m_as_name;
            m_as_abbr = source.m_as_abbr;
        }
    }
    
    [Serializable]
    public partial class LinkPhoneAckInfo : NetworkMessage {
        public static int[] Id = { 640,1 };
        public static Ctrl VC;
        public String m_phone_number = "";
        public Int64 m_link_time;
        public Int64 m_reward_time;
        public Int16 m_level_limit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_phone_number = sp.ReadString();}
            if (sp.TryRead(1)) {m_link_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_reward_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_level_limit = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_phone_number);}
            if (sp.TryWrite(1)) {sp.Write(m_link_time);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_time);}
            if (sp.TryWrite(3)) {sp.Write(m_level_limit);}
            sp.EnEnd();
        }
        public void CopyFrom(LinkPhoneAckInfo source) {
            m_phone_number = source.m_phone_number;
            m_link_time = source.m_link_time;
            m_reward_time = source.m_reward_time;
            m_level_limit = source.m_level_limit;
        }
    }
    
    [Serializable]
    public partial class FirstChargeRewards : NetworkMessage {
        public static int[] Id = { 646,1 };
        public static Ctrl VC;
        public List<FirstChargeRewardItem> m_rewards = new List<FirstChargeRewardItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FirstChargeRewardItem tmp = new FirstChargeRewardItem();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(FirstChargeRewards source) {
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedGroup : NetworkMessage {
        public static int[] Id = { 652,1 };
        public static Ctrl VC;
        public Int32 m_group_id;
        public List<ZvzUnitedMember> m_members = new List<ZvzUnitedMember>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_members.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ZvzUnitedMember tmp = new ZvzUnitedMember();
                    tmp.Decode(sp);
                    m_members.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_members.Count);
                for (int i = 0; i != m_members.Count; ++i) {
                    m_members[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedGroup source) {
            m_group_id = source.m_group_id;
            m_members = source.m_members;
        }
    }
    
    [Serializable]
    public partial class SwitchConfigInfo : NetworkMessage {
        public static int[] Id = { 658,1 };
        public static Ctrl VC;
        public List<SwitchConfigNode> m_records = new List<SwitchConfigNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SwitchConfigNode tmp = new SwitchConfigNode();
                    tmp.Decode(sp);
                    m_records.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_records.Count);
                for (int i = 0; i != m_records.Count; ++i) {
                    m_records[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SwitchConfigInfo source) {
            m_records = source.m_records;
        }
    }
    
    [Serializable]
    public partial class CaptchaVerifyAckInfo : NetworkMessage {
        public static int[] Id = { 664,1 };
        public static Ctrl VC;
        public Boolean m_success;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_success = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_success);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptchaVerifyAckInfo source) {
            m_success = source.m_success;
        }
    }
    
    [Serializable]
    public partial class GdcfgReqInfo : NetworkMessage {
        public static int[] Id = { 670,1 };
        public static Ctrl VC;
        public String m_file_name = "";
        public Int64 m_line_number;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_file_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_line_number = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_file_name);}
            if (sp.TryWrite(1)) {sp.Write(m_line_number);}
            sp.EnEnd();
        }
        public void CopyFrom(GdcfgReqInfo source) {
            m_file_name = source.m_file_name;
            m_line_number = source.m_line_number;
        }
    }
    
    [Serializable]
    public partial class ScrollMedalLevel : NetworkMessage {
        public static int[] Id = { 676,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_id;
        public Int32 m_medal_id;
        public Int16 m_medal_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_medal_id = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_medal_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_id);}
            if (sp.TryWrite(5)) {sp.Write(m_medal_id);}
            if (sp.TryWrite(6)) {sp.Write(m_medal_level);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollMedalLevel source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_id = source.m_id;
            m_medal_id = source.m_medal_id;
            m_medal_level = source.m_medal_level;
        }
    }
    
    [Serializable]
    public partial class EventCalendarAckInfo : NetworkMessage {
        public static int[] Id = { 682,1 };
        public static Ctrl VC;
        public Int64 m_base_offset;
        public List<EventCalendarInfo> m_event_calendar = new List<EventCalendarInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_base_offset = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_event_calendar.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EventCalendarInfo tmp = new EventCalendarInfo();
                    tmp.Decode(sp);
                    m_event_calendar.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_base_offset);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_event_calendar.Count);
                for (int i = 0; i != m_event_calendar.Count; ++i) {
                    m_event_calendar[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(EventCalendarAckInfo source) {
            m_base_offset = source.m_base_offset;
            m_event_calendar = source.m_event_calendar;
        }
    }
    
    [Serializable]
    public partial class ScrollBestBattle : NetworkMessage {
        public static int[] Id = { 688,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_user_alliance;
        public Int32 m_rank;

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
            if (sp.TryRead(4)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollBestBattle source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_user_alliance = source.m_user_alliance;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class FpsAgentInfo : NetworkMessage {
        public static int[] Id = { 694,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_rank;
        public Int32 m_star;
        public List<Int32> m_equipment = new List<Int32>();
        public Int32 m_fragment;
        public Int32 m_max_fragment;
        public Int64 m_upgrade_rank_time;
        public Int64 m_upgrade_star_time;
        public Boolean m_has_agent;
        public Boolean m_coming_soon;
        public Int32 m_hp;
        public Int32 m_attack;
        public Int32 m_range;
        public Int32 m_zoom;
        public Int32 m_cap;
        public Int32 m_reload_speed;
        public Int32 m_stable;
        public Int16 m_state;
        public Int32 m_force;
        public Int64 m_troop_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_star = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_equipment.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_equipment.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {m_fragment = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_max_fragment = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_upgrade_rank_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_upgrade_star_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_has_agent = sp.ReadBoolean();}
            if (sp.TryRead(9)) {m_coming_soon = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_hp = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_attack = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_range = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_zoom = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_cap = sp.ReadInt32();}
            if (sp.TryRead(15)) {m_reload_speed = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_stable = sp.ReadInt32();}
            if (sp.TryRead(17)) {m_state = sp.ReadInt16();}
            if (sp.TryRead(18)) {m_force = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_troop_num = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_star);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_equipment.Count);
                for (int i = 0; i != m_equipment.Count; ++i) {
                    sp.Write(m_equipment[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {sp.Write(m_fragment);}
            if (sp.TryWrite(5)) {sp.Write(m_max_fragment);}
            if (sp.TryWrite(6)) {sp.Write(m_upgrade_rank_time);}
            if (sp.TryWrite(7)) {sp.Write(m_upgrade_star_time);}
            if (sp.TryWrite(8)) {sp.Write(m_has_agent);}
            if (sp.TryWrite(9)) {sp.Write(m_coming_soon);}
            if (sp.TryWrite(10)) {sp.Write(m_hp);}
            if (sp.TryWrite(11)) {sp.Write(m_attack);}
            if (sp.TryWrite(12)) {sp.Write(m_range);}
            if (sp.TryWrite(13)) {sp.Write(m_zoom);}
            if (sp.TryWrite(14)) {sp.Write(m_cap);}
            if (sp.TryWrite(15)) {sp.Write(m_reload_speed);}
            if (sp.TryWrite(16)) {sp.Write(m_stable);}
            if (sp.TryWrite(17)) {sp.Write(m_state);}
            if (sp.TryWrite(18)) {sp.Write(m_force);}
            if (sp.TryWrite(19)) {sp.Write(m_troop_num);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsAgentInfo source) {
            m_id = source.m_id;
            m_rank = source.m_rank;
            m_star = source.m_star;
            m_equipment = source.m_equipment;
            m_fragment = source.m_fragment;
            m_max_fragment = source.m_max_fragment;
            m_upgrade_rank_time = source.m_upgrade_rank_time;
            m_upgrade_star_time = source.m_upgrade_star_time;
            m_has_agent = source.m_has_agent;
            m_coming_soon = source.m_coming_soon;
            m_hp = source.m_hp;
            m_attack = source.m_attack;
            m_range = source.m_range;
            m_zoom = source.m_zoom;
            m_cap = source.m_cap;
            m_reload_speed = source.m_reload_speed;
            m_stable = source.m_stable;
            m_state = source.m_state;
            m_force = source.m_force;
            m_troop_num = source.m_troop_num;
        }
    }
    
    [Serializable]
    public partial class FpsSlotNtfInfo : NetworkMessage {
        public static int[] Id = { 700,1 };
        public static Ctrl VC;
        public List<FpsSlotInfo> m_slot_list = new List<FpsSlotInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_slot_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FpsSlotInfo tmp = new FpsSlotInfo();
                    tmp.Decode(sp);
                    m_slot_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_slot_list.Count);
                for (int i = 0; i != m_slot_list.Count; ++i) {
                    m_slot_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FpsSlotNtfInfo source) {
            m_slot_list = source.m_slot_list;
        }
    }
    
    [Serializable]
    public partial class UserFpsBattleTracking : NetworkMessage {
        public static int[] Id = { 706,1 };
        public static Ctrl VC;
        public Int64 m_event_id;
        public Int32 m_win;
        public Int64 m_battle_end_at;
        public String m_battle_period = "";
        public String m_chapter_id = "";
        public String m_agent_info = "";
        public String m_equip_info = "";
        public String m_reason = "";
        public Int64 m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_win = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_battle_end_at = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_battle_period = sp.ReadString();}
            if (sp.TryRead(4)) {m_chapter_id = sp.ReadString();}
            if (sp.TryRead(5)) {m_agent_info = sp.ReadString();}
            if (sp.TryRead(6)) {m_equip_info = sp.ReadString();}
            if (sp.TryRead(7)) {m_reason = sp.ReadString();}
            if (sp.TryRead(8)) {m_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_win);}
            if (sp.TryWrite(2)) {sp.Write(m_battle_end_at);}
            if (sp.TryWrite(3)) {sp.Write(m_battle_period);}
            if (sp.TryWrite(4)) {sp.Write(m_chapter_id);}
            if (sp.TryWrite(5)) {sp.Write(m_agent_info);}
            if (sp.TryWrite(6)) {sp.Write(m_equip_info);}
            if (sp.TryWrite(7)) {sp.Write(m_reason);}
            if (sp.TryWrite(8)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(UserFpsBattleTracking source) {
            m_event_id = source.m_event_id;
            m_win = source.m_win;
            m_battle_end_at = source.m_battle_end_at;
            m_battle_period = source.m_battle_period;
            m_chapter_id = source.m_chapter_id;
            m_agent_info = source.m_agent_info;
            m_equip_info = source.m_equip_info;
            m_reason = source.m_reason;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class FirstChargePackItem : NetworkMessage {
        public static int[] Id = { 712,1 };
        public static Ctrl VC;
        public SByte m_show;
        public Int32 m_id;
        public Int32 m_cnt;
        public Int64 m_value;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_show = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_value = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_show);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_value);}
            sp.EnEnd();
        }
        public void CopyFrom(FirstChargePackItem source) {
            m_show = source.m_show;
            m_id = source.m_id;
            m_cnt = source.m_cnt;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelDetailAckInfo : NetworkMessage {
        public static int[] Id = { 718,1 };
        public static Ctrl VC;
        public Int16 m_level_id;
        public Int32 m_score;
        public Int32 m_total_score;
        public Int32 m_best_score;
        public Int32 m_best_rank;
        public Int32 m_kill_num;
        public Int32 m_head_kill_num;
        public Int16 m_challenge_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_total_score = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_best_score = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_best_rank = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_kill_num = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_head_kill_num = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_challenge_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_total_score);}
            if (sp.TryWrite(3)) {sp.Write(m_best_score);}
            if (sp.TryWrite(4)) {sp.Write(m_best_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_kill_num);}
            if (sp.TryWrite(6)) {sp.Write(m_head_kill_num);}
            if (sp.TryWrite(7)) {sp.Write(m_challenge_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSpecialLevelDetailAckInfo source) {
            m_level_id = source.m_level_id;
            m_score = source.m_score;
            m_total_score = source.m_total_score;
            m_best_score = source.m_best_score;
            m_best_rank = source.m_best_rank;
            m_kill_num = source.m_kill_num;
            m_head_kill_num = source.m_head_kill_num;
            m_challenge_cnt = source.m_challenge_cnt;
        }
    }
    
    [Serializable]
    public partial class BaseRebelTaskInfo : NetworkMessage {
        public static int[] Id = { 724,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_max_p_points;
        public Int64 m_max_g_points;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Int16 m_reward_state;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_max_p_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_max_g_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_reward_state = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_max_p_points);}
            if (sp.TryWrite(2)) {sp.Write(m_max_g_points);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_reward_state);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseRebelTaskInfo source) {
            m_id = source.m_id;
            m_max_p_points = source.m_max_p_points;
            m_max_g_points = source.m_max_g_points;
            m_rewards = source.m_rewards;
            m_reward_state = source.m_reward_state;
        }
    }
    
    [Serializable]
    public partial class BaseTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 730,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_title = "";
        public Int64 m_max_points;
        public Int64 m_current_points;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Int16 m_reward_state;
        public Int64 m_timelimit;
        public Int64 m_endtime;
        public Int64 m_timelimit_task_current_points;
        public Int64 m_complete_score;
        public List<CampaignEvent> m_events = new List<CampaignEvent>();
        public String m_jump_str = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_max_points = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_current_points = sp.ReadInt64();}
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
            if (sp.TryRead(5)) {m_reward_state = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_timelimit = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_timelimit_task_current_points = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_complete_score = sp.ReadInt64();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_events.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignEvent tmp = new CampaignEvent();
                    tmp.Decode(sp);
                    m_events.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_jump_str = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_max_points);}
            if (sp.TryWrite(3)) {sp.Write(m_current_points);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_reward_state);}
            if (sp.TryWrite(6)) {sp.Write(m_timelimit);}
            if (sp.TryWrite(7)) {sp.Write(m_endtime);}
            if (sp.TryWrite(8)) {sp.Write(m_timelimit_task_current_points);}
            if (sp.TryWrite(9)) {sp.Write(m_complete_score);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_events.Count);
                for (int i = 0; i != m_events.Count; ++i) {
                    m_events[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_jump_str);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseTaskCampaignInfo source) {
            m_id = source.m_id;
            m_title = source.m_title;
            m_max_points = source.m_max_points;
            m_current_points = source.m_current_points;
            m_rewards = source.m_rewards;
            m_reward_state = source.m_reward_state;
            m_timelimit = source.m_timelimit;
            m_endtime = source.m_endtime;
            m_timelimit_task_current_points = source.m_timelimit_task_current_points;
            m_complete_score = source.m_complete_score;
            m_events = source.m_events;
            m_jump_str = source.m_jump_str;
        }
    }
    
    [Serializable]
    public partial class MapExploreCampaignInfo : NetworkMessage {
        public static int[] Id = { 736,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public BaseMapExploreCampaignInfo m_map_explore_rule;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_map_explore_rule = new BaseMapExploreCampaignInfo();
                m_map_explore_rule.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_map_explore_rule.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_map_explore_rule = source.m_map_explore_rule;
        }
    }
    
    [Serializable]
    public partial class CampaignRankInfo : NetworkMessage {
        public static int[] Id = { 742,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_sub_rank_id;
        public List<HuodongRankInfo> m_rank_info = new List<HuodongRankInfo>();
        public HuodongRankInfo m_self_rank_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_sub_rank_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongRankInfo tmp = new HuodongRankInfo();
                    tmp.Decode(sp);
                    m_rank_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_self_rank_info = new HuodongRankInfo();
                m_self_rank_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_sub_rank_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info.Count);
                for (int i = 0; i != m_rank_info.Count; ++i) {
                    m_rank_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_self_rank_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignRankInfo source) {
            m_id = source.m_id;
            m_sub_rank_id = source.m_sub_rank_id;
            m_rank_info = source.m_rank_info;
            m_self_rank_info = source.m_self_rank_info;
        }
    }
    
    [Serializable]
    public partial class BannerInfoList : NetworkMessage {
        public static int[] Id = { 748,1 };
        public static Ctrl VC;
        public List<BannerInfo> m_info = new List<BannerInfo>();
        public Int32 m_daily_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BannerInfo tmp = new BannerInfo();
                    tmp.Decode(sp);
                    m_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_daily_times = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_daily_times);}
            sp.EnEnd();
        }
        public void CopyFrom(BannerInfoList source) {
            m_info = source.m_info;
            m_daily_times = source.m_daily_times;
        }
    }
    
    [Serializable]
    public partial class ClientTextList : NetworkMessage {
        public static int[] Id = { 754,1 };
        public static Ctrl VC;
        public List<ClientText> m_list = new List<ClientText>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ClientText tmp = new ClientText();
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
        public void CopyFrom(ClientTextList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class DailyFreePack : NetworkMessage {
        public static int[] Id = { 760,1 };
        public static Ctrl VC;
        public List<DailyFreePackItem> m_items = new List<DailyFreePackItem>();
        public SByte m_is_available;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailyFreePackItem tmp = new DailyFreePackItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_is_available = sp.ReadSByte();}
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
            if (sp.TryWrite(1)) {sp.Write(m_is_available);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyFreePack source) {
            m_items = source.m_items;
            m_is_available = source.m_is_available;
        }
    }
    
    [Serializable]
    public partial class SecondPurchaseInfo : NetworkMessage {
        public static int[] Id = { 766,1 };
        public static Ctrl VC;
        public String m_title = "";
        public String m_pic = "";
        public String m_desc = "";
        public Int32 m_score;
        public Int64 m_end_time;
        public List<SecondPurchaseReward> m_rewards = new List<SecondPurchaseReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title = sp.ReadString();}
            if (sp.TryRead(1)) {m_pic = sp.ReadString();}
            if (sp.TryRead(2)) {m_desc = sp.ReadString();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SecondPurchaseReward tmp = new SecondPurchaseReward();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title);}
            if (sp.TryWrite(1)) {sp.Write(m_pic);}
            if (sp.TryWrite(2)) {sp.Write(m_desc);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            if (sp.TryWrite(5)) {
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
        public void CopyFrom(SecondPurchaseInfo source) {
            m_title = source.m_title;
            m_pic = source.m_pic;
            m_desc = source.m_desc;
            m_score = source.m_score;
            m_end_time = source.m_end_time;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class AgentStateInfo : NetworkMessage {
        public static int[] Id = { 772,1 };
        public static Ctrl VC;
        public List<Int16> m_city = new List<Int16>();
        public List<Int16> m_march = new List<Int16>();
        public Int64 m_map_guid;
        public List<Int16> m_city_bench_main = new List<Int16>();
        public List<Int16> m_city_bench_sub = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_city.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_march.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_bench_main.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_city_bench_main.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_bench_sub.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_city_bench_sub.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city.Count);
                for (int i = 0; i != m_city.Count; ++i) {
                    sp.Write(m_city[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_march.Count);
                for (int i = 0; i != m_march.Count; ++i) {
                    sp.Write(m_march[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_bench_main.Count);
                for (int i = 0; i != m_city_bench_main.Count; ++i) {
                    sp.Write(m_city_bench_main[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_bench_sub.Count);
                for (int i = 0; i != m_city_bench_sub.Count; ++i) {
                    sp.Write(m_city_bench_sub[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AgentStateInfo source) {
            m_city = source.m_city;
            m_march = source.m_march;
            m_map_guid = source.m_map_guid;
            m_city_bench_main = source.m_city_bench_main;
            m_city_bench_sub = source.m_city_bench_sub;
        }
    }
    
    [Serializable]
    public partial class UserSurveyFinishReqInfo : NetworkMessage {
        public static int[] Id = { 778,1 };
        public static Ctrl VC;
        public String m_token = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_token = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_token);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSurveyFinishReqInfo source) {
            m_token = source.m_token;
        }
    }
    
    [Serializable]
    public partial class NewAllianceBuildingTile : NetworkMessage {
        public static int[] Id = { 784,1 };
        public static Ctrl VC;
        public Int32 m_building_type;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Boolean m_is_finished;
        public Boolean m_is_burning;
        public Int32 m_endurance;
        public Int32 m_endurance_max;
        public UserAllianceBrief m_alliance;
        public SByte m_building_subtype;
        public Boolean m_is_active;
        public Int64 m_leader;
        public Int64 m_durability_speed;
        public Int64 m_durability_max;
        public Int64 m_durability;
        public LandGuardRect m_land_guard_rect;
        public Int64 m_disppear_ms;
        public List<Int16> m_state_list = new List<Int16>();
        public List<Int32> m_aura_ids = new List<Int32>();
        public Int64 m_force_burn_end_time;
        public Int32 m_burn_slow_down_ratio;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_is_finished = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_is_burning = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_endurance = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_endurance_max = sp.ReadInt32();}
            if (sp.TryRead(8)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_building_subtype = sp.ReadSByte();}
            if (sp.TryRead(10)) {m_is_active = sp.ReadBoolean();}
            if (sp.TryRead(11)) {m_leader = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_durability_speed = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_durability_max = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_durability = sp.ReadInt64();}
            if (sp.TryRead(15)) {
                m_land_guard_rect = new LandGuardRect();
                m_land_guard_rect.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_disppear_ms = sp.ReadInt64();}
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_state_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_state_list.Add(tmp);
                }
            }
            if (sp.TryRead(18)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            if (sp.TryRead(19)) {m_force_burn_end_time = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_burn_slow_down_ratio = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_type);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_x);}
            if (sp.TryWrite(3)) {sp.Write(m_y);}
            if (sp.TryWrite(4)) {sp.Write(m_is_finished);}
            if (sp.TryWrite(5)) {sp.Write(m_is_burning);}
            if (sp.TryWrite(6)) {sp.Write(m_endurance);}
            if (sp.TryWrite(7)) {sp.Write(m_endurance_max);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {sp.Write(m_building_subtype);}
            if (sp.TryWrite(10)) {sp.Write(m_is_active);}
            if (sp.TryWrite(11)) {sp.Write(m_leader);}
            if (sp.TryWrite(12)) {sp.Write(m_durability_speed);}
            if (sp.TryWrite(13)) {sp.Write(m_durability_max);}
            if (sp.TryWrite(14)) {sp.Write(m_durability);}
            if (sp.TryWrite(15)) {int pos = sp.GetPos();sp.Skip(2); m_land_guard_rect.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(16)) {sp.Write(m_disppear_ms);}
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_state_list.Count);
                for (int i = 0; i != m_state_list.Count; ++i) {
                    sp.Write(m_state_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(18)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(19)) {sp.Write(m_force_burn_end_time);}
            if (sp.TryWrite(20)) {sp.Write(m_burn_slow_down_ratio);}
            sp.EnEnd();
        }
        public void CopyFrom(NewAllianceBuildingTile source) {
            m_building_type = source.m_building_type;
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_is_finished = source.m_is_finished;
            m_is_burning = source.m_is_burning;
            m_endurance = source.m_endurance;
            m_endurance_max = source.m_endurance_max;
            m_alliance = source.m_alliance;
            m_building_subtype = source.m_building_subtype;
            m_is_active = source.m_is_active;
            m_leader = source.m_leader;
            m_durability_speed = source.m_durability_speed;
            m_durability_max = source.m_durability_max;
            m_durability = source.m_durability;
            m_land_guard_rect = source.m_land_guard_rect;
            m_disppear_ms = source.m_disppear_ms;
            m_state_list = source.m_state_list;
            m_aura_ids = source.m_aura_ids;
            m_force_burn_end_time = source.m_force_burn_end_time;
            m_burn_slow_down_ratio = source.m_burn_slow_down_ratio;
        }
    }
    
    [Serializable]
    public partial class MarchId : NetworkMessage {
        public static int[] Id = { 790,1 };
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
        public void CopyFrom(MarchId source) {
            m_march_id = source.m_march_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class EffectCastInfo : NetworkMessage {
        public static int[] Id = { 796,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_skill_id;
        public Int16 m_hero_id;
        public List<MapUnitId> m_targets = new List<MapUnitId>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_targets.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapUnitId tmp = new MapUnitId();
                    tmp.Decode(sp);
                    m_targets.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(2)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_targets.Count);
                for (int i = 0; i != m_targets.Count; ++i) {
                    m_targets[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(EffectCastInfo source) {
            m_id = source.m_id;
            m_skill_id = source.m_skill_id;
            m_hero_id = source.m_hero_id;
            m_targets = source.m_targets;
        }
    }
    
    [Serializable]
    public partial class AgentStarPointFragmentUseReqInfo : NetworkMessage {
        public static int[] Id = { 802,1 };
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
        public void CopyFrom(AgentStarPointFragmentUseReqInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalent : NetworkMessage {
        public static int[] Id = { 808,1 };
        public static Ctrl VC;
        public Int32 m_talent_id;
        public Int32 m_talent_group_id;
        public SByte m_talent_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_talent_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_talent_group_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_talent_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_talent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_talent_group_id);}
            if (sp.TryWrite(2)) {sp.Write(m_talent_level);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalent source) {
            m_talent_id = source.m_talent_id;
            m_talent_group_id = source.m_talent_group_id;
            m_talent_level = source.m_talent_level;
        }
    }
    
    [Serializable]
    public partial class CultureAgentLevelTable : NetworkMessage {
        public static int[] Id = { 814,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public SByte m_heroQuality;
        public Int16 m_heroLevel;
        public Int32 m_heroXpReq;
        public SByte m_talentPointRwd;
        public Int32 m_powerAwd;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_heroQuality = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_heroLevel = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_heroXpReq = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_talentPointRwd = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_powerAwd = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_heroQuality);}
            if (sp.TryWrite(2)) {sp.Write(m_heroLevel);}
            if (sp.TryWrite(3)) {sp.Write(m_heroXpReq);}
            if (sp.TryWrite(4)) {sp.Write(m_talentPointRwd);}
            if (sp.TryWrite(5)) {sp.Write(m_powerAwd);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentLevelTable source) {
            m_id = source.m_id;
            m_heroQuality = source.m_heroQuality;
            m_heroLevel = source.m_heroLevel;
            m_heroXpReq = source.m_heroXpReq;
            m_talentPointRwd = source.m_talentPointRwd;
            m_powerAwd = source.m_powerAwd;
        }
    }
    
    [Serializable]
    public partial class MapBuildingId : NetworkMessage {
        public static int[] Id = { 820,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MapBuildingId source) {
            m_id = source.m_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class MapBuildingType : NetworkMessage {
        public static int[] Id = { 826,1 };
        public static Ctrl VC;
        public Int32 m_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            sp.EnEnd();
        }
        public void CopyFrom(MapBuildingType source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class MapBuildingReqInfo : NetworkMessage {
        public static int[] Id = { 832,1 };
        public static Ctrl VC;
        public Int64 m_building_id;
        public TilePos m_pos;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MapBuildingReqInfo source) {
            m_building_id = source.m_building_id;
            m_pos = source.m_pos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class NewRtfMailNtfInfo : NetworkMessage {
        public static int[] Id = { 838,1 };
        public static Ctrl VC;
        public RtfMailBasicInfo m_basic_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new RtfMailBasicInfo();
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
        public void CopyFrom(NewRtfMailNtfInfo source) {
            m_basic_info = source.m_basic_info;
        }
    }
    
    [Serializable]
    public partial class ReadRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 844,1 };
        public static Ctrl VC;
        public List<String> m_mail_id = new List<String>();

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
            sp.EnEnd();
        }
        public void CopyFrom(ReadRtfMailReqInfo source) {
            m_mail_id = source.m_mail_id;
        }
    }
    
    [Serializable]
    public partial class ShareBattleMailReqInfo : NetworkMessage {
        public static int[] Id = { 850,1 };
        public static Ctrl VC;
        public String m_mail_id = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_mail_id = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_mail_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ShareBattleMailReqInfo source) {
            m_mail_id = source.m_mail_id;
        }
    }
    
    [Serializable]
    public partial class DeleteAllRtfMailAckInfo : NetworkMessage {
        public static int[] Id = { 856,1 };
        public static Ctrl VC;
        public Boolean m_del_collect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_del_collect = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_del_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(DeleteAllRtfMailAckInfo source) {
            m_del_collect = source.m_del_collect;
        }
    }
    
    [Serializable]
    public partial class AdjustInfo : NetworkMessage {
        public static int[] Id = { 862,1 };
        public static Ctrl VC;
        public String m_publisher_cd = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_publisher_cd = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_publisher_cd);}
            sp.EnEnd();
        }
        public void CopyFrom(AdjustInfo source) {
            m_publisher_cd = source.m_publisher_cd;
        }
    }
    
    [Serializable]
    public partial class MapLevelNtfInfo : NetworkMessage {
        public static int[] Id = { 868,1 };
        public static Ctrl VC;
        public SByte m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(MapLevelNtfInfo source) {
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class AllianceWarehouseRes : NetworkMessage {
        public static int[] Id = { 874,1 };
        public static Ctrl VC;
        public SByte m_type;
        public Int64 m_amount;
        public Int64 m_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_max = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            if (sp.TryWrite(2)) {sp.Write(m_max);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceWarehouseRes source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
            m_max = source.m_max;
        }
    }
    
    [Serializable]
    public partial class AllianceNewFortuneGiftNtfInfo : NetworkMessage {
        public static int[] Id = { 880,1 };
        public static Ctrl VC;
        public Int16 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_count = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceNewFortuneGiftNtfInfo source) {
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class BaseStepTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 886,1 };
        public static Ctrl VC;
        public SByte m_step;
        public Int64 m_open_time;
        public Int64 m_end_time;
        public Boolean m_ranked;
        public List<RankUnitInfo> m_rank_info_list = new List<RankUnitInfo>();
        public List<BaseTaskCampaignInfo> m_task_info = new List<BaseTaskCampaignInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_ranked = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankUnitInfo tmp = new RankUnitInfo();
                    tmp.Decode(sp);
                    m_rank_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_open_time);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            if (sp.TryWrite(3)) {sp.Write(m_ranked);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info_list.Count);
                for (int i = 0; i != m_rank_info_list.Count; ++i) {
                    m_rank_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_info.Count);
                for (int i = 0; i != m_task_info.Count; ++i) {
                    m_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BaseStepTaskCampaignInfo source) {
            m_step = source.m_step;
            m_open_time = source.m_open_time;
            m_end_time = source.m_end_time;
            m_ranked = source.m_ranked;
            m_rank_info_list = source.m_rank_info_list;
            m_task_info = source.m_task_info;
        }
    }
    
    [Serializable]
    public partial class ExpeditionStateInfo : NetworkMessage {
        public static int[] Id = { 892,1 };
        public static Ctrl VC;
        public List<ExpeditionCheckpointStateInfo> m_info = new List<ExpeditionCheckpointStateInfo>();
        public List<ArmyInfo> m_troop = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExpeditionCheckpointStateInfo tmp = new ExpeditionCheckpointStateInfo();
                    tmp.Decode(sp);
                    m_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troop.Add(tmp);
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop.Count);
                for (int i = 0; i != m_troop.Count; ++i) {
                    m_troop[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionStateInfo source) {
            m_info = source.m_info;
            m_troop = source.m_troop;
        }
    }
    
    [Serializable]
    public partial class StepTaskCampaignHistory : NetworkMessage {
        public static int[] Id = { 898,1 };
        public static Ctrl VC;
        public Int64 m_actId;
        public Int64 m_openTime;
        public List<StepTaskHistoryUserInfo> m_rank_tree = new List<StepTaskHistoryUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_actId = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_openTime = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_tree.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StepTaskHistoryUserInfo tmp = new StepTaskHistoryUserInfo();
                    tmp.Decode(sp);
                    m_rank_tree.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_actId);}
            if (sp.TryWrite(1)) {sp.Write(m_openTime);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_tree.Count);
                for (int i = 0; i != m_rank_tree.Count; ++i) {
                    m_rank_tree[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(StepTaskCampaignHistory source) {
            m_actId = source.m_actId;
            m_openTime = source.m_openTime;
            m_rank_tree = source.m_rank_tree;
        }
    }
    
    [Serializable]
    public partial class OccupyLandNtfInfo : NetworkMessage {
        public static int[] Id = { 904,1 };
        public static Ctrl VC;
        public SByte m_level;
        public Boolean m_first;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_first = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_first);}
            sp.EnEnd();
        }
        public void CopyFrom(OccupyLandNtfInfo source) {
            m_level = source.m_level;
            m_first = source.m_first;
        }
    }
    
    [Serializable]
    public partial class MapExploreGotRewardReqInfo : NetworkMessage {
        public static int[] Id = { 910,1 };
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
        public void CopyFrom(MapExploreGotRewardReqInfo source) {
            m_point_index = source.m_point_index;
        }
    }
    
    [Serializable]
    public partial class TechItemNtfInfo : NetworkMessage {
        public static int[] Id = { 916,1 };
        public static Ctrl VC;
        public List<ResearchBaseInfo> m_tech = new List<ResearchBaseInfo>();
        public Int64 m_diamond;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tech.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResearchBaseInfo tmp = new ResearchBaseInfo();
                    tmp.Decode(sp);
                    m_tech.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_diamond = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tech.Count);
                for (int i = 0; i != m_tech.Count; ++i) {
                    m_tech[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_diamond);}
            sp.EnEnd();
        }
        public void CopyFrom(TechItemNtfInfo source) {
            m_tech = source.m_tech;
            m_diamond = source.m_diamond;
        }
    }
    
    [Serializable]
    public partial class AssignmentCenterInfo : NetworkMessage {
        public static int[] Id = { 922,1 };
        public static Ctrl VC;
        public List<AssignmentCenterAgentInfo> m_agents = new List<AssignmentCenterAgentInfo>();
        public List<AgentAssignmentInfo> m_assignment = new List<AgentAssignmentInfo>();
        public Int32 m_minigame_cnt;
        public Boolean m_closed;
        public Int16 m_favor_agent;
        public Int16 m_used_quick_count;
        public Int16 m_total_quick_count;
        public List<Int32> m_skin_list = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AssignmentCenterAgentInfo tmp = new AssignmentCenterAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_assignment.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AgentAssignmentInfo tmp = new AgentAssignmentInfo();
                    tmp.Decode(sp);
                    m_assignment.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_minigame_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_closed = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_favor_agent = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_used_quick_count = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_total_quick_count = sp.ReadInt16();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skin_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_skin_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agents.Count);
                for (int i = 0; i != m_agents.Count; ++i) {
                    m_agents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_assignment.Count);
                for (int i = 0; i != m_assignment.Count; ++i) {
                    m_assignment[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_minigame_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_closed);}
            if (sp.TryWrite(4)) {sp.Write(m_favor_agent);}
            if (sp.TryWrite(5)) {sp.Write(m_used_quick_count);}
            if (sp.TryWrite(6)) {sp.Write(m_total_quick_count);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skin_list.Count);
                for (int i = 0; i != m_skin_list.Count; ++i) {
                    sp.Write(m_skin_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AssignmentCenterInfo source) {
            m_agents = source.m_agents;
            m_assignment = source.m_assignment;
            m_minigame_cnt = source.m_minigame_cnt;
            m_closed = source.m_closed;
            m_favor_agent = source.m_favor_agent;
            m_used_quick_count = source.m_used_quick_count;
            m_total_quick_count = source.m_total_quick_count;
            m_skin_list = source.m_skin_list;
        }
    }
    
    [Serializable]
    public partial class SetAgentSkinReqInfo : NetworkMessage {
        public static int[] Id = { 928,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_skin_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetAgentSkinReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_skin_id = source.m_skin_id;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelBeginReqInfo : NetworkMessage {
        public static int[] Id = { 934,1 };
        public static Ctrl VC;
        public Int32 m_delay_sec;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_delay_sec = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_delay_sec);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelBeginReqInfo source) {
            m_delay_sec = source.m_delay_sec;
        }
    }
    
    [Serializable]
    public partial class RebelBaseTile : NetworkMessage {
        public static int[] Id = { 940,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int16 m_cfg_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_cfg_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_stat);}
            if (sp.TryWrite(4)) {sp.Write(m_cfg_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelBaseTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
        }
    }
    
    [Serializable]
    public partial class DefenceCenterInfo : NetworkMessage {
        public static int[] Id = { 946,1 };
        public static Ctrl VC;
        public AgentStateInfo m_agent;
        public Int64 m_defence_value;
        public Int64 m_defence_value_max;
        public Int64 m_burn_speed;
        public Int64 m_burn_time;
        public Int64 m_repair_cd;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_agent = new AgentStateInfo();
                m_agent.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_defence_value = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_defence_value_max = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_burn_speed = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_burn_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_repair_cd = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_agent.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_defence_value);}
            if (sp.TryWrite(2)) {sp.Write(m_defence_value_max);}
            if (sp.TryWrite(3)) {sp.Write(m_burn_speed);}
            if (sp.TryWrite(4)) {sp.Write(m_burn_time);}
            if (sp.TryWrite(5)) {sp.Write(m_repair_cd);}
            if (sp.TryWrite(6)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(DefenceCenterInfo source) {
            m_agent = source.m_agent;
            m_defence_value = source.m_defence_value;
            m_defence_value_max = source.m_defence_value_max;
            m_burn_speed = source.m_burn_speed;
            m_burn_time = source.m_burn_time;
            m_repair_cd = source.m_repair_cd;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class B2VipShopItem : NetworkMessage {
        public static int[] Id = { 952,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int16 m_vip_lv_req;
        public SByte m_price_type;
        public Int64 m_price;
        public Int16 m_discount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_vip_lv_req = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_price_type = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_price = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_discount = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_num);}
            if (sp.TryWrite(3)) {sp.Write(m_vip_lv_req);}
            if (sp.TryWrite(4)) {sp.Write(m_price_type);}
            if (sp.TryWrite(5)) {sp.Write(m_price);}
            if (sp.TryWrite(6)) {sp.Write(m_discount);}
            sp.EnEnd();
        }
        public void CopyFrom(B2VipShopItem source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_vip_lv_req = source.m_vip_lv_req;
            m_price_type = source.m_price_type;
            m_price = source.m_price;
            m_discount = source.m_discount;
        }
    }
    
    [Serializable]
    public partial class GovLootRecord : NetworkMessage {
        public static int[] Id = { 958,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public String m_alliance_abbr = "";
        public Int64 m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(GovLootRecord source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_alliance_abbr = source.m_alliance_abbr;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignInfo : NetworkMessage {
        public static int[] Id = { 964,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int16 m_free_time;
        public Int32 m_once_diamond_cost;
        public Int32 m_five_diamond_cost;
        public Int16 m_once_dis_time;
        public Int16 m_five_dis_time;
        public Int16 m_once_dis_per;
        public Int16 m_five_dis_per;
        public Int32 m_daily_max_time;
        public Int32 m_daily_roll_time;
        public List<WheelCampaignGrid> m_grids = new List<WheelCampaignGrid>();
        public Int32 m_extra_reward_score;
        public Int32 m_extra_reward_total_score;
        public List<WheelCampaignAdditionReward> m_extra_reward = new List<WheelCampaignAdditionReward>();
        public List<Int32> m_extra_reward_got = new List<Int32>();
        public String m_ui_wheel = "";
        public String m_ui_pointer = "";
        public Int32 m_stage_up_limit;
        public Int32 m_cost_type;
        public Int32 m_cost_param;
        public String m_cost_icon = "";
        public Boolean m_is_special_optional;
        public List<Int32> m_special_optional_ids = new List<Int32>();
        public Int32 m_selected_special_id;
        public String m_wheel_bg = "";
        public String m_wheel_arrow = "";
        public List<WheelCampaignAdditionReward> m_extra_reward_got_infos = new List<WheelCampaignAdditionReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_free_time = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_once_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_five_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_once_dis_time = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_five_dis_time = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_once_dis_per = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_five_dis_per = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_daily_max_time = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_daily_roll_time = sp.ReadInt32();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_grids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignGrid tmp = new WheelCampaignGrid();
                    tmp.Decode(sp);
                    m_grids.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_extra_reward_score = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_extra_reward_total_score = sp.ReadInt32();}
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignAdditionReward tmp = new WheelCampaignAdditionReward();
                    tmp.Decode(sp);
                    m_extra_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_got.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_extra_reward_got.Add(tmp);
                }
            }
            if (sp.TryRead(15)) {m_ui_wheel = sp.ReadString();}
            if (sp.TryRead(16)) {m_ui_pointer = sp.ReadString();}
            if (sp.TryRead(17)) {m_stage_up_limit = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_cost_type = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_cost_param = sp.ReadInt32();}
            if (sp.TryRead(20)) {m_cost_icon = sp.ReadString();}
            if (sp.TryRead(21)) {m_is_special_optional = sp.ReadBoolean();}
            if (sp.TryRead(22)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_special_optional_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_special_optional_ids.Add(tmp);
                }
            }
            if (sp.TryRead(23)) {m_selected_special_id = sp.ReadInt32();}
            if (sp.TryRead(24)) {m_wheel_bg = sp.ReadString();}
            if (sp.TryRead(25)) {m_wheel_arrow = sp.ReadString();}
            if (sp.TryRead(26)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_got_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignAdditionReward tmp = new WheelCampaignAdditionReward();
                    tmp.Decode(sp);
                    m_extra_reward_got_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_free_time);}
            if (sp.TryWrite(2)) {sp.Write(m_once_diamond_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_five_diamond_cost);}
            if (sp.TryWrite(4)) {sp.Write(m_once_dis_time);}
            if (sp.TryWrite(5)) {sp.Write(m_five_dis_time);}
            if (sp.TryWrite(6)) {sp.Write(m_once_dis_per);}
            if (sp.TryWrite(7)) {sp.Write(m_five_dis_per);}
            if (sp.TryWrite(8)) {sp.Write(m_daily_max_time);}
            if (sp.TryWrite(9)) {sp.Write(m_daily_roll_time);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_grids.Count);
                for (int i = 0; i != m_grids.Count; ++i) {
                    m_grids[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_extra_reward_score);}
            if (sp.TryWrite(12)) {sp.Write(m_extra_reward_total_score);}
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward.Count);
                for (int i = 0; i != m_extra_reward.Count; ++i) {
                    m_extra_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_got.Count);
                for (int i = 0; i != m_extra_reward_got.Count; ++i) {
                    sp.Write(m_extra_reward_got[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(15)) {sp.Write(m_ui_wheel);}
            if (sp.TryWrite(16)) {sp.Write(m_ui_pointer);}
            if (sp.TryWrite(17)) {sp.Write(m_stage_up_limit);}
            if (sp.TryWrite(18)) {sp.Write(m_cost_type);}
            if (sp.TryWrite(19)) {sp.Write(m_cost_param);}
            if (sp.TryWrite(20)) {sp.Write(m_cost_icon);}
            if (sp.TryWrite(21)) {sp.Write(m_is_special_optional);}
            if (sp.TryWrite(22)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_special_optional_ids.Count);
                for (int i = 0; i != m_special_optional_ids.Count; ++i) {
                    sp.Write(m_special_optional_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(23)) {sp.Write(m_selected_special_id);}
            if (sp.TryWrite(24)) {sp.Write(m_wheel_bg);}
            if (sp.TryWrite(25)) {sp.Write(m_wheel_arrow);}
            if (sp.TryWrite(26)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_got_infos.Count);
                for (int i = 0; i != m_extra_reward_got_infos.Count; ++i) {
                    m_extra_reward_got_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_free_time = source.m_free_time;
            m_once_diamond_cost = source.m_once_diamond_cost;
            m_five_diamond_cost = source.m_five_diamond_cost;
            m_once_dis_time = source.m_once_dis_time;
            m_five_dis_time = source.m_five_dis_time;
            m_once_dis_per = source.m_once_dis_per;
            m_five_dis_per = source.m_five_dis_per;
            m_daily_max_time = source.m_daily_max_time;
            m_daily_roll_time = source.m_daily_roll_time;
            m_grids = source.m_grids;
            m_extra_reward_score = source.m_extra_reward_score;
            m_extra_reward_total_score = source.m_extra_reward_total_score;
            m_extra_reward = source.m_extra_reward;
            m_extra_reward_got = source.m_extra_reward_got;
            m_ui_wheel = source.m_ui_wheel;
            m_ui_pointer = source.m_ui_pointer;
            m_stage_up_limit = source.m_stage_up_limit;
            m_cost_type = source.m_cost_type;
            m_cost_param = source.m_cost_param;
            m_cost_icon = source.m_cost_icon;
            m_is_special_optional = source.m_is_special_optional;
            m_special_optional_ids = source.m_special_optional_ids;
            m_selected_special_id = source.m_selected_special_id;
            m_wheel_bg = source.m_wheel_bg;
            m_wheel_arrow = source.m_wheel_arrow;
            m_extra_reward_got_infos = source.m_extra_reward_got_infos;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 970,1 };
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
        public void CopyFrom(WheelCampaignExtraRewardReqInfo source) {
            m_aty_item = source.m_aty_item;
            m_reward_id = source.m_reward_id;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelDefenceInfo : NetworkMessage {
        public static int[] Id = { 976,1 };
        public static Ctrl VC;
        public String m_atk_rebel_icon = "";
        public TilePos m_atk_pos;
        public Int64 m_def_user;
        public String m_def_name = "";
        public Int16 m_def_icon;
        public String m_def_avatar = "";
        public TilePos m_def_pos;
        public Int16 m_stat;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_max_cnt;
        public Int64 m_cur_cnt;
        public MapUnitId m_def_target;
        public Int32 m_building_type;
        public Int16 m_sub_type;
        public MarchInfo m_rebel_march;
        public Int16 m_def_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_atk_rebel_icon = sp.ReadString();}
            if (sp.TryRead(1)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_def_user = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_def_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_def_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_def_avatar = sp.ReadString();}
            if (sp.TryRead(6)) {
                m_def_pos = new TilePos();
                m_def_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_stat = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_max_cnt = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_cur_cnt = sp.ReadInt64();}
            if (sp.TryRead(12)) {
                m_def_target = new MapUnitId();
                m_def_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_sub_type = sp.ReadInt16();}
            if (sp.TryRead(15)) {
                m_rebel_march = new MarchInfo();
                m_rebel_march.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_def_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_atk_rebel_icon);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_def_user);}
            if (sp.TryWrite(3)) {sp.Write(m_def_name);}
            if (sp.TryWrite(4)) {sp.Write(m_def_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_def_avatar);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_def_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_stat);}
            if (sp.TryWrite(8)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(9)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(10)) {sp.Write(m_max_cnt);}
            if (sp.TryWrite(11)) {sp.Write(m_cur_cnt);}
            if (sp.TryWrite(12)) {int pos = sp.GetPos();sp.Skip(2); m_def_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(13)) {sp.Write(m_building_type);}
            if (sp.TryWrite(14)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(15)) {int pos = sp.GetPos();sp.Skip(2); m_rebel_march.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(16)) {sp.Write(m_def_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelDefenceInfo source) {
            m_atk_rebel_icon = source.m_atk_rebel_icon;
            m_atk_pos = source.m_atk_pos;
            m_def_user = source.m_def_user;
            m_def_name = source.m_def_name;
            m_def_icon = source.m_def_icon;
            m_def_avatar = source.m_def_avatar;
            m_def_pos = source.m_def_pos;
            m_stat = source.m_stat;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_max_cnt = source.m_max_cnt;
            m_cur_cnt = source.m_cur_cnt;
            m_def_target = source.m_def_target;
            m_building_type = source.m_building_type;
            m_sub_type = source.m_sub_type;
            m_rebel_march = source.m_rebel_march;
            m_def_avatar_frame = source.m_def_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class UseExchangeCodeReqInfo : NetworkMessage {
        public static int[] Id = { 982,1 };
        public static Ctrl VC;
        public String m_code = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(UseExchangeCodeReqInfo source) {
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class BubbleInfo : NetworkMessage {
        public static int[] Id = { 988,1 };
        public static Ctrl VC;
        public Boolean m_is_open;
        public Int64 m_energy_last_click_time;
        public Int64 m_energy;
        public Int64 m_food_last_click_time;
        public Int64 m_food;
        public Int64 m_oil_last_click_time;
        public Int64 m_oil;
        public Int64 m_steel_last_click_time;
        public Int64 m_steel;
        public Boolean m_is_open2;
        public Int16 m_tank;
        public Int16 m_jeep;
        public Int16 m_flight;
        public Int16 m_cannon;
        public List<ArmyInfo> m_repair = new List<ArmyInfo>();
        public Int16 m_research;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_open = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_energy_last_click_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_energy = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_food_last_click_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_food = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_oil_last_click_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_oil = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_steel_last_click_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_steel = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_is_open2 = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_tank = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_jeep = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_flight = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_cannon = sp.ReadInt16();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_repair.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_repair.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_research = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_open);}
            if (sp.TryWrite(1)) {sp.Write(m_energy_last_click_time);}
            if (sp.TryWrite(2)) {sp.Write(m_energy);}
            if (sp.TryWrite(3)) {sp.Write(m_food_last_click_time);}
            if (sp.TryWrite(4)) {sp.Write(m_food);}
            if (sp.TryWrite(5)) {sp.Write(m_oil_last_click_time);}
            if (sp.TryWrite(6)) {sp.Write(m_oil);}
            if (sp.TryWrite(7)) {sp.Write(m_steel_last_click_time);}
            if (sp.TryWrite(8)) {sp.Write(m_steel);}
            if (sp.TryWrite(9)) {sp.Write(m_is_open2);}
            if (sp.TryWrite(10)) {sp.Write(m_tank);}
            if (sp.TryWrite(11)) {sp.Write(m_jeep);}
            if (sp.TryWrite(12)) {sp.Write(m_flight);}
            if (sp.TryWrite(13)) {sp.Write(m_cannon);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_repair.Count);
                for (int i = 0; i != m_repair.Count; ++i) {
                    m_repair[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_research);}
            sp.EnEnd();
        }
        public void CopyFrom(BubbleInfo source) {
            m_is_open = source.m_is_open;
            m_energy_last_click_time = source.m_energy_last_click_time;
            m_energy = source.m_energy;
            m_food_last_click_time = source.m_food_last_click_time;
            m_food = source.m_food;
            m_oil_last_click_time = source.m_oil_last_click_time;
            m_oil = source.m_oil;
            m_steel_last_click_time = source.m_steel_last_click_time;
            m_steel = source.m_steel;
            m_is_open2 = source.m_is_open2;
            m_tank = source.m_tank;
            m_jeep = source.m_jeep;
            m_flight = source.m_flight;
            m_cannon = source.m_cannon;
            m_repair = source.m_repair;
            m_research = source.m_research;
        }
    }
    
    [Serializable]
    public partial class SetAgentPoseReqInfo : NetworkMessage {
        public static int[] Id = { 994,1 };
        public static Ctrl VC;
        public Int16 m_pose;
        public Int16 m_agent_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pose = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_agent_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pose);}
            if (sp.TryWrite(1)) {sp.Write(m_agent_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetAgentPoseReqInfo source) {
            m_pose = source.m_pose;
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class CostActivityStatus : NetworkMessage {
        public static int[] Id = { 1000,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int64 m_cur_score;
        public Int16 m_cur_level;
        public List<Int16> m_got_level_reward = new List<Int16>();
        public List<Int16> m_got_level_ex_reward = new List<Int16>();
        public Boolean m_is_unlocked;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cur_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cur_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_got_level_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_got_level_reward.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_got_level_ex_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_got_level_ex_reward.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {m_is_unlocked = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_score);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_level);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_got_level_reward.Count);
                for (int i = 0; i != m_got_level_reward.Count; ++i) {
                    sp.Write(m_got_level_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_got_level_ex_reward.Count);
                for (int i = 0; i != m_got_level_ex_reward.Count; ++i) {
                    sp.Write(m_got_level_ex_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {sp.Write(m_is_unlocked);}
            sp.EnEnd();
        }
        public void CopyFrom(CostActivityStatus source) {
            m_act_id = source.m_act_id;
            m_cur_score = source.m_cur_score;
            m_cur_level = source.m_cur_level;
            m_got_level_reward = source.m_got_level_reward;
            m_got_level_ex_reward = source.m_got_level_ex_reward;
            m_is_unlocked = source.m_is_unlocked;
        }
    }
    
    [Serializable]
    public partial class BaseProgressiveTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 1006,1 };
        public static Ctrl VC;
        public SByte m_step;
        public Int64 m_open_time;
        public Boolean m_ranked;
        public List<RankUnitInfo> m_rank_info_list = new List<RankUnitInfo>();
        public List<BaseTaskGroupCampaignInfo> m_task_info = new List<BaseTaskGroupCampaignInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_ranked = sp.ReadBoolean();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankUnitInfo tmp = new RankUnitInfo();
                    tmp.Decode(sp);
                    m_rank_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskGroupCampaignInfo tmp = new BaseTaskGroupCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_open_time);}
            if (sp.TryWrite(2)) {sp.Write(m_ranked);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info_list.Count);
                for (int i = 0; i != m_rank_info_list.Count; ++i) {
                    m_rank_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_info.Count);
                for (int i = 0; i != m_task_info.Count; ++i) {
                    m_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BaseProgressiveTaskCampaignInfo source) {
            m_step = source.m_step;
            m_open_time = source.m_open_time;
            m_ranked = source.m_ranked;
            m_rank_info_list = source.m_rank_info_list;
            m_task_info = source.m_task_info;
        }
    }
    
    [Serializable]
    public partial class NonstopKillingCampaignInfo : NetworkMessage {
        public static int[] Id = { 1012,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseProgressCampaignInfo> m_task_info = new List<BaseProgressCampaignInfo>();
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
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseProgressCampaignInfo tmp = new BaseProgressCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_current_points = sp.ReadInt64();}
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
            sp.EnEnd();
        }
        public void CopyFrom(NonstopKillingCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
            m_current_points = source.m_current_points;
        }
    }
    
    [Serializable]
    public partial class AllianceShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 1018,1 };
        public static Ctrl VC;
        public Int32 m_stock_id;
        public Int32 m_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stock_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_stock_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopBuyReqInfo source) {
            m_stock_id = source.m_stock_id;
            m_item_num = source.m_item_num;
        }
    }
    
    [Serializable]
    public partial class AllianceShopStockItem : NetworkMessage {
        public static int[] Id = { 1024,1 };
        public static Ctrl VC;
        public Int32 m_stock_id;
        public SByte m_item_type;
        public Int32 m_item_id;
        public Int64 m_price;
        public Boolean m_selected;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stock_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_price = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_selected = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_stock_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_type);}
            if (sp.TryWrite(2)) {sp.Write(m_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_price);}
            if (sp.TryWrite(4)) {sp.Write(m_selected);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopStockItem source) {
            m_stock_id = source.m_stock_id;
            m_item_type = source.m_item_type;
            m_item_id = source.m_item_id;
            m_price = source.m_price;
            m_selected = source.m_selected;
        }
    }
    
    [Serializable]
    public partial class QuestCountdownListReq : NetworkMessage {
        public static int[] Id = { 1030,2 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(QuestCountdownListReq source) {
        }
    }
    
    [Serializable]
    public partial class RemoteLoginInfo : NetworkMessage {
        public static int[] Id = { 1036,2 };
        public static Ctrl VC;
        public Int16 m_target_server;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_server = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_server);}
            sp.EnEnd();
        }
        public void CopyFrom(RemoteLoginInfo source) {
            m_target_server = source.m_target_server;
        }
    }
    
    [Serializable]
    public partial class TimelimitTaskStartNtf : NetworkMessage {
        public static int[] Id = { 1042,2 };
        public static Ctrl VC;
        public Int64 m_camp_id;
        public Int32 m_task_id;
        public Int64 m_endtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_camp_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_endtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_camp_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            if (sp.TryWrite(2)) {sp.Write(m_endtime);}
            sp.EnEnd();
        }
        public void CopyFrom(TimelimitTaskStartNtf source) {
            m_camp_id = source.m_camp_id;
            m_task_id = source.m_task_id;
            m_endtime = source.m_endtime;
        }
    }
    
    [Serializable]
    public partial class LadderInfoAckInfo : NetworkMessage {
        public static int[] Id = { 1048,3 };
        public static Ctrl VC;
        public List<SByte> m_unlocked_list = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_unlocked_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_unlocked_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_unlocked_list.Count);
                for (int i = 0; i != m_unlocked_list.Count; ++i) {
                    sp.Write(m_unlocked_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderInfoAckInfo source) {
            m_unlocked_list = source.m_unlocked_list;
        }
    }
    
    [Serializable]
    public partial class LadderUserInitReqInfo : NetworkMessage {
        public static int[] Id = { 1054,3 };
        public static Ctrl VC;
        public SByte m_difficulty_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_difficulty_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_difficulty_level);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderUserInitReqInfo source) {
            m_difficulty_level = source.m_difficulty_level;
        }
    }
    
    [Serializable]
    public partial class LadderStepRewardInfo : NetworkMessage {
        public static int[] Id = { 1060,3 };
        public static Ctrl VC;
        public List<LadderCampaignStepReward> m_step_reward = new List<LadderCampaignStepReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_step_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderCampaignStepReward tmp = new LadderCampaignStepReward();
                    tmp.Decode(sp);
                    m_step_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_step_reward.Count);
                for (int i = 0; i != m_step_reward.Count; ++i) {
                    m_step_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderStepRewardInfo source) {
            m_step_reward = source.m_step_reward;
        }
    }
    
    [Serializable]
    public partial class CouponInfo : NetworkMessage {
        public static int[] Id = { 1066,3 };
        public static Ctrl VC;
        public Int32 m_trigger_type;
        public String m_trigger_info = "";
        public String m_code = "";
        public Int64 m_start_time;
        public Int64 m_end_time;
        public Int32 m_avail_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_trigger_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_trigger_info = sp.ReadString();}
            if (sp.TryRead(2)) {m_code = sp.ReadString();}
            if (sp.TryRead(3)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_avail_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_trigger_type);}
            if (sp.TryWrite(1)) {sp.Write(m_trigger_info);}
            if (sp.TryWrite(2)) {sp.Write(m_code);}
            if (sp.TryWrite(3)) {sp.Write(m_start_time);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            if (sp.TryWrite(5)) {sp.Write(m_avail_times);}
            sp.EnEnd();
        }
        public void CopyFrom(CouponInfo source) {
            m_trigger_type = source.m_trigger_type;
            m_trigger_info = source.m_trigger_info;
            m_code = source.m_code;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_avail_times = source.m_avail_times;
        }
    }
    
    [Serializable]
    public partial class BuffBaseTile : NetworkMessage {
        public static int[] Id = { 1072,4 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int32 m_buff_id;
        public Int64 m_disappear_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_buff_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_disappear_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_buff_id);}
            if (sp.TryWrite(4)) {sp.Write(m_disappear_time);}
            sp.EnEnd();
        }
        public void CopyFrom(BuffBaseTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_buff_id = source.m_buff_id;
            m_disappear_time = source.m_disappear_time;
        }
    }
    
    [Serializable]
    public partial class ArenaTroopInfo : NetworkMessage {
        public static int[] Id = { 1078,4 };
        public static Ctrl VC;
        public Byte m_index;
        public List<ArenaAgentInfo> m_agent = new List<ArenaAgentInfo>();
        public List<ArmyInfo> m_army = new List<ArmyInfo>();
        public Int16 m_warship_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaAgentInfo tmp = new ArenaAgentInfo();
                    tmp.Decode(sp);
                    m_agent.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_warship_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    m_agent[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army.Count);
                for (int i = 0; i != m_army.Count; ++i) {
                    m_army[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_warship_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaTroopInfo source) {
            m_index = source.m_index;
            m_agent = source.m_agent;
            m_army = source.m_army;
            m_warship_id = source.m_warship_id;
        }
    }
    
    [Serializable]
    public partial class ArenaNtfInfo : NetworkMessage {
        public static int[] Id = { 1084,4 };
        public static Ctrl VC;
        public UInt32 m_season;
        public Int64 m_end_time;
        public Int64 m_score;
        public Int32 m_free_cnt;
        public List<ArenaTroopInfo> m_defend_array = new List<ArenaTroopInfo>();
        public List<ArmyInfo> m_army_pool = new List<ArmyInfo>();
        public Int64 m_base_capacity;
        public Int32 m_free_cnt_max;
        public Int64 m_latest_fight;
        public Int64 m_latest_be_fight;
        public Int32 m_cost;
        public Int32 m_can_buy_cnt;
        public Int64 m_settle_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_season = sp.ReadUInt32();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_free_cnt = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defend_array.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopInfo tmp = new ArenaTroopInfo();
                    tmp.Decode(sp);
                    m_defend_array.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army_pool.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army_pool.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_base_capacity = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_free_cnt_max = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_latest_fight = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_latest_be_fight = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_cost = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_can_buy_cnt = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_settle_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_season);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_free_cnt);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defend_array.Count);
                for (int i = 0; i != m_defend_array.Count; ++i) {
                    m_defend_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army_pool.Count);
                for (int i = 0; i != m_army_pool.Count; ++i) {
                    m_army_pool[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_base_capacity);}
            if (sp.TryWrite(7)) {sp.Write(m_free_cnt_max);}
            if (sp.TryWrite(8)) {sp.Write(m_latest_fight);}
            if (sp.TryWrite(9)) {sp.Write(m_latest_be_fight);}
            if (sp.TryWrite(10)) {sp.Write(m_cost);}
            if (sp.TryWrite(11)) {sp.Write(m_can_buy_cnt);}
            if (sp.TryWrite(12)) {sp.Write(m_settle_time);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaNtfInfo source) {
            m_season = source.m_season;
            m_end_time = source.m_end_time;
            m_score = source.m_score;
            m_free_cnt = source.m_free_cnt;
            m_defend_array = source.m_defend_array;
            m_army_pool = source.m_army_pool;
            m_base_capacity = source.m_base_capacity;
            m_free_cnt_max = source.m_free_cnt_max;
            m_latest_fight = source.m_latest_fight;
            m_latest_be_fight = source.m_latest_be_fight;
            m_cost = source.m_cost;
            m_can_buy_cnt = source.m_can_buy_cnt;
            m_settle_time = source.m_settle_time;
        }
    }
    
    [Serializable]
    public partial class ArenaRanklistReqInfo : NetworkMessage {
        public static int[] Id = { 1090,4 };
        public static Ctrl VC;
        public Int32 m_start;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaRanklistReqInfo source) {
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class BattlePassportBuyExpReq : NetworkMessage {
        public static int[] Id = { 1096,4 };
        public static Ctrl VC;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(BattlePassportBuyExpReq source) {
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class CampaignEvent : NetworkMessage {
        public static int[] Id = { 1102,5 };
        public static Ctrl VC;
        public Int32 m_event_id;
        public Int64 m_event_pt;
        public Int64 m_event_param;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_event_pt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_event_param = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_event_pt);}
            if (sp.TryWrite(2)) {sp.Write(m_event_param);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignEvent source) {
            m_event_id = source.m_event_id;
            m_event_pt = source.m_event_pt;
            m_event_param = source.m_event_param;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeProgressInfo : NetworkMessage {
        public static int[] Id = { 1108,5 };
        public static Ctrl VC;
        public Int16 m_cur_level;
        public Int32 m_cur_point;
        public Int32 m_max_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_max_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_level);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_point);}
            if (sp.TryWrite(2)) {sp.Write(m_max_point);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeProgressInfo source) {
            m_cur_level = source.m_cur_level;
            m_cur_point = source.m_cur_point;
            m_max_point = source.m_max_point;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskAbandonAckInfo : NetworkMessage {
        public static int[] Id = { 1114,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public AllianceMobilizeTaskBaseInfo m_new_task;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_new_task = new AllianceMobilizeTaskBaseInfo();
                m_new_task.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_new_task.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeTaskAbandonAckInfo source) {
            m_act_id = source.m_act_id;
            m_new_task = source.m_new_task;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeProgressUpdateNtfInfo : NetworkMessage {
        public static int[] Id = { 1120,5 };
        public static Ctrl VC;
        public AllianceMobilizeProgressInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_info = new AllianceMobilizeProgressInfo();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeProgressUpdateNtfInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class ArenaTroopAttackSeq : NetworkMessage {
        public static int[] Id = { 1126,7 };
        public static Ctrl VC;
        public Byte m_index;
        public List<Byte> m_seq = new List<Byte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_seq.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Byte tmp = sp.ReadByte();
                    m_seq.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_seq.Count);
                for (int i = 0; i != m_seq.Count; ++i) {
                    sp.Write(m_seq[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaTroopAttackSeq source) {
            m_index = source.m_index;
            m_seq = source.m_seq;
        }
    }
    
    [Serializable]
    public partial class OccupyMonumentBannerNtfInfo : NetworkMessage {
        public static int[] Id = { 1133,7 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int64 m_monument_id;
        public Int64 m_occupy_time;
        public String m_alliance_abbr = "";
        public String m_alliance_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_monument_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_occupy_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(4)) {m_alliance_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_monument_id);}
            if (sp.TryWrite(2)) {sp.Write(m_occupy_time);}
            if (sp.TryWrite(3)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(4)) {sp.Write(m_alliance_name);}
            sp.EnEnd();
        }
        public void CopyFrom(OccupyMonumentBannerNtfInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_monument_id = source.m_monument_id;
            m_occupy_time = source.m_occupy_time;
            m_alliance_abbr = source.m_alliance_abbr;
            m_alliance_name = source.m_alliance_name;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerAck : NetworkMessage {
        public static int[] Id = { 1139,8 };
        public static Ctrl VC;
        public List<Int32> m_error_codes = new List<Int32>();
        public Boolean m_success;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_error_codes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_error_codes.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_success = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_error_codes.Count);
                for (int i = 0; i != m_error_codes.Count; ++i) {
                    sp.Write(m_error_codes[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_success);}
            sp.EnEnd();
        }
        public void CopyFrom(B2TransferServerAck source) {
            m_error_codes = source.m_error_codes;
            m_success = source.m_success;
        }
    }
    
    [Serializable]
    public partial class BattleSupportNtfInfo : NetworkMessage {
        public static int[] Id = { 1145,8 };
        public static Ctrl VC;
        public List<BattleSupportMarchPath> m_path = new List<BattleSupportMarchPath>();
        public List<String> m_player_list = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_path.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BattleSupportMarchPath tmp = new BattleSupportMarchPath();
                    tmp.Decode(sp);
                    m_path.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_player_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_player_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_path.Count);
                for (int i = 0; i != m_path.Count; ++i) {
                    m_path[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_player_list.Count);
                for (int i = 0; i != m_player_list.Count; ++i) {
                    sp.Write(m_player_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BattleSupportNtfInfo source) {
            m_path = source.m_path;
            m_player_list = source.m_player_list;
        }
    }
    
    [Serializable]
    public partial class LoudSpeakerNtfInfo : NetworkMessage {
        public static int[] Id = { 1151,11 };
        public static Ctrl VC;
        public Int32 m_total_reward_cnt;
        public Int64 m_next_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total_reward_cnt = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_next_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total_reward_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_next_time);}
            sp.EnEnd();
        }
        public void CopyFrom(LoudSpeakerNtfInfo source) {
            m_total_reward_cnt = source.m_total_reward_cnt;
            m_next_time = source.m_next_time;
        }
    }
    
    [Serializable]
    public partial class GvgQuitReqInfo : NetworkMessage {
        public static int[] Id = { 1157,12 };
        public static Ctrl VC;
        public Int64 m_battlefield_id;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_battlefield_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_battlefield_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgQuitReqInfo source) {
            m_battlefield_id = source.m_battlefield_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class GvgApplyMemberAgentInfo : NetworkMessage {
        public static int[] Id = { 1163,12 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_power;
        public Int16 m_level;
        public Int16 m_star;
        public Int16 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_power = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_rank = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_power);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_star);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyMemberAgentInfo source) {
            m_id = source.m_id;
            m_power = source.m_power;
            m_level = source.m_level;
            m_star = source.m_star;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class GvgBuildingTile : NetworkMessage {
        public static int[] Id = { 1169,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int64 m_open_time;
        public UserAllianceBrief m_alliance;
        public Int64 m_fighting;
        public Int64 m_land_time;
        public Int64 m_end_time;
        public Int32 m_removal_point;
        public Int32 m_land_as;
        public List<Int32> m_aura_ids = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_land_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_removal_point = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_land_as = sp.ReadInt32();}
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_stat);}
            if (sp.TryWrite(4)) {sp.Write(m_open_time);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_fighting);}
            if (sp.TryWrite(7)) {sp.Write(m_land_time);}
            if (sp.TryWrite(8)) {sp.Write(m_end_time);}
            if (sp.TryWrite(9)) {sp.Write(m_removal_point);}
            if (sp.TryWrite(10)) {sp.Write(m_land_as);}
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgBuildingTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_open_time = source.m_open_time;
            m_alliance = source.m_alliance;
            m_fighting = source.m_fighting;
            m_land_time = source.m_land_time;
            m_end_time = source.m_end_time;
            m_removal_point = source.m_removal_point;
            m_land_as = source.m_land_as;
            m_aura_ids = source.m_aura_ids;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldNtfInfo : NetworkMessage {
        public static int[] Id = { 1175,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int64 m_open_time;
        public Int64 m_end_time;
        public Int64 m_map_guid;
        public GvgBattlefieldAllianceInfo m_team_a;
        public GvgBattlefieldAllianceInfo m_team_b;
        public Int16 m_status;
        public Int16 m_result;
        public Int16 m_max_user;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                m_team_a = new GvgBattlefieldAllianceInfo();
                m_team_a.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_team_b = new GvgBattlefieldAllianceInfo();
                m_team_b.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_result = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_max_user = sp.ReadInt16();}
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
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldNtfInfo source) {
            m_id = source.m_id;
            m_open_time = source.m_open_time;
            m_end_time = source.m_end_time;
            m_map_guid = source.m_map_guid;
            m_team_a = source.m_team_a;
            m_team_b = source.m_team_b;
            m_status = source.m_status;
            m_result = source.m_result;
            m_max_user = source.m_max_user;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldListReqInfo : NetworkMessage {
        public static int[] Id = { 1181,12 };
        public static Ctrl VC;
        public Int32 m_index;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldListReqInfo source) {
            m_index = source.m_index;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class GvgAwardListRespInfo : NetworkMessage {
        public static int[] Id = { 1187,12 };
        public static Ctrl VC;
        public List<GvgArawdInfo> m_awards = new List<GvgArawdInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_awards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgArawdInfo tmp = new GvgArawdInfo();
                    tmp.Decode(sp);
                    m_awards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_awards.Count);
                for (int i = 0; i != m_awards.Count; ++i) {
                    m_awards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgAwardListRespInfo source) {
            m_awards = source.m_awards;
        }
    }
    
    [Serializable]
    public partial class NightFixedViewSingleUpdateInfo : NetworkMessage {
        public static int[] Id = { 1211,13 };
        public static Ctrl VC;
        public NightFixedViewInfo m_view;
        public SByte m_op_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_view = new NightFixedViewInfo();
                m_view.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_op_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_view.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_op_type);}
            sp.EnEnd();
        }
        public void CopyFrom(NightFixedViewSingleUpdateInfo source) {
            m_view = source.m_view;
            m_op_type = source.m_op_type;
        }
    }
    
    [Serializable]
    public partial class RouletteRollReqInfo : NetworkMessage {
        public static int[] Id = { 1217,14 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_circle_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_circle_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_circle_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteRollReqInfo source) {
            m_act_id = source.m_act_id;
            m_circle_id = source.m_circle_id;
        }
    }
    
    [Serializable]
    public partial class ActiveAgentStudyEffectReqInfo : NetworkMessage {
        public static int[] Id = { 1223,17 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int16 m_agent_id;
        public Boolean m_use_fragment;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_use_fragment = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(3)) {sp.Write(m_use_fragment);}
            sp.EnEnd();
        }
        public void CopyFrom(ActiveAgentStudyEffectReqInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_agent_id = source.m_agent_id;
            m_use_fragment = source.m_use_fragment;
        }
    }
    
    [Serializable]
    public partial class UserGetNewChatBubbleInfo : NetworkMessage {
        public static int[] Id = { 1229,18 };
        public static Ctrl VC;
        public Int16 m_new_one;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_one = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_one);}
            sp.EnEnd();
        }
        public void CopyFrom(UserGetNewChatBubbleInfo source) {
            m_new_one = source.m_new_one;
        }
    }
    
    [Serializable]
    public partial class DiamondBuyEmoticonInfo : NetworkMessage {
        public static int[] Id = { 1235,18 };
        public static Ctrl VC;
        public Int16 m_buy_type;
        public Int32 m_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_buy_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_buy_type);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondBuyEmoticonInfo source) {
            m_buy_type = source.m_buy_type;
            m_item_id = source.m_item_id;
        }
    }
    
    [Serializable]
    public partial class ArenaShopInfo : NetworkMessage {
        public static int[] Id = { 1241,19 };
        public static Ctrl VC;
        public Int32 m_my_score;
        public List<ArenaShopItem> m_items = new List<ArenaShopItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_my_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaShopItem tmp = new ArenaShopItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_my_score);}
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
        public void CopyFrom(ArenaShopInfo source) {
            m_my_score = source.m_my_score;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class UserDoVerifCodeReqInfo : NetworkMessage {
        public static int[] Id = { 1247,19 };
        public static Ctrl VC;
        public String m_verif_code = "";
        public Boolean m_is_force;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_verif_code = sp.ReadString();}
            if (sp.TryRead(1)) {m_is_force = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_verif_code);}
            if (sp.TryWrite(1)) {sp.Write(m_is_force);}
            sp.EnEnd();
        }
        public void CopyFrom(UserDoVerifCodeReqInfo source) {
            m_verif_code = source.m_verif_code;
            m_is_force = source.m_is_force;
        }
    }
    
    [Serializable]
    public partial class MailConfirmChoiceStatusReqInfo : NetworkMessage {
        public static int[] Id = { 1253,19 };
        public static Ctrl VC;
        public List<Int64> m_confirm_id = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_confirm_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_confirm_id.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_confirm_id.Count);
                for (int i = 0; i != m_confirm_id.Count; ++i) {
                    sp.Write(m_confirm_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmChoiceStatusReqInfo source) {
            m_confirm_id = source.m_confirm_id;
        }
    }
    
    [Serializable]
    public partial class RelocateServerInfo : NetworkMessage {
        public static int[] Id = { 1259,19 };
        public static Ctrl VC;
        public Int16 m_type;
        public UserInfo m_player_info;
        public Boolean m_first_kvk;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_player_info = new UserInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_first_kvk = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_first_kvk);}
            sp.EnEnd();
        }
        public void CopyFrom(RelocateServerInfo source) {
            m_type = source.m_type;
            m_player_info = source.m_player_info;
            m_first_kvk = source.m_first_kvk;
        }
    }
    
    [Serializable]
    public partial class BossCampaignArmySlotReqInfo : NetworkMessage {
        public static int[] Id = { 1265,19 };
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
        public void CopyFrom(BossCampaignArmySlotReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class BossCampaignClaimServerRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1271,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int16 m_reward_boss_lv;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_reward_boss_lv = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_boss_lv);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignClaimServerRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_reward_boss_lv = source.m_reward_boss_lv;
        }
    }
    
    [Serializable]
    public partial class RankCampaignSelfRankAckInfo : NetworkMessage {
        public static int[] Id = { 1277,19 };
        public static Ctrl VC;
        public Int64 m_ack_id;
        public List<RankCampaignSelfInfo> m_infos = new List<RankCampaignSelfInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ack_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankCampaignSelfInfo tmp = new RankCampaignSelfInfo();
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
        public void CopyFrom(RankCampaignSelfRankAckInfo source) {
            m_ack_id = source.m_ack_id;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRealPosReqInfo : NetworkMessage {
        public static int[] Id = { 1283,19 };
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
        public void CopyFrom(BossCampaignRealPosReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class KvkQuestListReqInfo : NetworkMessage {
        public static int[] Id = { 1289,19 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(KvkQuestListReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class KvkPrepareCampaign : NetworkMessage {
        public static int[] Id = { 1295,19 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public BaseExchangeCampaignInfo m_exchange_first;
        public List<BaseTaskCampaignInfo> m_task_second = new List<BaseTaskCampaignInfo>();
        public List<BaseExchangeCampaignInfo> m_exchange_third = new List<BaseExchangeCampaignInfo>();
        public SByte m_cur_step;
        public List<KvkPrepareStepInfo> m_step_list = new List<KvkPrepareStepInfo>();
        public Int64 m_self_score;
        public Int64 m_server_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_exchange_first = new BaseExchangeCampaignInfo();
                m_exchange_first.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_second.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_second.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_third.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_third.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_cur_step = sp.ReadSByte();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_step_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkPrepareStepInfo tmp = new KvkPrepareStepInfo();
                    tmp.Decode(sp);
                    m_step_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_self_score = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_server_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_exchange_first.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_second.Count);
                for (int i = 0; i != m_task_second.Count; ++i) {
                    m_task_second[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_third.Count);
                for (int i = 0; i != m_exchange_third.Count; ++i) {
                    m_exchange_third[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_step_list.Count);
                for (int i = 0; i != m_step_list.Count; ++i) {
                    m_step_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_self_score);}
            if (sp.TryWrite(7)) {sp.Write(m_server_score);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPrepareCampaign source) {
            m_basic_info = source.m_basic_info;
            m_exchange_first = source.m_exchange_first;
            m_task_second = source.m_task_second;
            m_exchange_third = source.m_exchange_third;
            m_cur_step = source.m_cur_step;
            m_step_list = source.m_step_list;
            m_self_score = source.m_self_score;
            m_server_score = source.m_server_score;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortStep : NetworkMessage {
        public static int[] Id = { 1301,19 };
        public static Ctrl VC;
        public SByte m_step;
        public Int64 m_cur_step_pt;
        public Int64 m_duringSec;
        public Int64 m_target_pt;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Boolean m_reward_got;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_cur_step_pt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_duringSec = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_target_pt = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_reward_got = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_step_pt);}
            if (sp.TryWrite(2)) {sp.Write(m_duringSec);}
            if (sp.TryWrite(3)) {sp.Write(m_target_pt);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_reward_got);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortStep source) {
            m_step = source.m_step;
            m_cur_step_pt = source.m_cur_step_pt;
            m_duringSec = source.m_duringSec;
            m_target_pt = source.m_target_pt;
            m_reward = source.m_reward;
            m_reward_got = source.m_reward_got;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortKillRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1307,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_method;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_method = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_method);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortKillRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_method = source.m_method;
        }
    }
    
    [Serializable]
    public partial class GvgApplyMemberListReqInfo : NetworkMessage {
        public static int[] Id = { 1313,19 };
        public static Ctrl VC;
        public Int64 m_camp_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_camp_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_camp_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyMemberListReqInfo source) {
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class ClaimMergeLoginRewardsReqInfo : NetworkMessage {
        public static int[] Id = { 1319,21 };
        public static Ctrl VC;
        public Int16 m_day;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_day = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_day);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimMergeLoginRewardsReqInfo source) {
            m_day = source.m_day;
        }
    }
    
    [Serializable]
    public partial class SlotMachineRollReqInfo : NetworkMessage {
        public static int[] Id = { 1339,22 };
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
        public void CopyFrom(SlotMachineRollReqInfo source) {
            m_aty_item = source.m_aty_item;
            m_roll_method = source.m_roll_method;
        }
    }
    
    [Serializable]
    public partial class KvkLabLoot : NetworkMessage {
        public static int[] Id = { 1345,23 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int64 m_lab_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_id;
        public Int64 m_endtime;

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
            if (sp.TryRead(1)) {m_lab_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_endtime = sp.ReadInt64();}
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
            if (sp.TryWrite(1)) {sp.Write(m_lab_id);}
            if (sp.TryWrite(2)) {sp.Write(m_x);}
            if (sp.TryWrite(3)) {sp.Write(m_y);}
            if (sp.TryWrite(4)) {sp.Write(m_id);}
            if (sp.TryWrite(5)) {sp.Write(m_endtime);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkLabLoot source) {
            m_items = source.m_items;
            m_lab_id = source.m_lab_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_id = source.m_id;
            m_endtime = source.m_endtime;
        }
    }
    
    [Serializable]
    public partial class KvkServerCountryList : NetworkMessage {
        public static int[] Id = { 1351,23 };
        public static Ctrl VC;
        public List<KvkServerCountry> m_list = new List<KvkServerCountry>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkServerCountry tmp = new KvkServerCountry();
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
        public void CopyFrom(KvkServerCountryList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class PlayerBlackListItem : NetworkMessage {
        public static int[] Id = { 1357,23 };
        public static Ctrl VC;
        public Int64 m_create_time;
        public Int64 m_player_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_create_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_create_time);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerBlackListItem source) {
            m_create_time = source.m_create_time;
            m_player_id = source.m_player_id;
        }
    }
    
    [Serializable]
    public partial class UserWarshipResearchStatusInfo : NetworkMessage {
        public static int[] Id = { 1363,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int16 m_page_id;
        public Int32 m_research_id;
        public Int64 m_begin_time;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_page_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_research_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_page_id);}
            if (sp.TryWrite(2)) {sp.Write(m_research_id);}
            if (sp.TryWrite(3)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipResearchStatusInfo source) {
            m_warship_id = source.m_warship_id;
            m_page_id = source.m_page_id;
            m_research_id = source.m_research_id;
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class UserWarshipResearchBubbleInfo : NetworkMessage {
        public static int[] Id = { 1369,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int32 m_warship_research;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_warship_research = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_warship_research);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipResearchBubbleInfo source) {
            m_warship_id = source.m_warship_id;
            m_warship_research = source.m_warship_research;
        }
    }
    
    [Serializable]
    public partial class KvkPrepareStepInfo : NetworkMessage {
        public static int[] Id = { 1375,23 };
        public static Ctrl VC;
        public Int64 m_during;
        public String m_ui_title = "";
        public String m_ui_banner = "";
        public String m_ui_rule = "";
        public SByte m_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_during = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_ui_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_ui_banner = sp.ReadString();}
            if (sp.TryRead(3)) {m_ui_rule = sp.ReadString();}
            if (sp.TryRead(4)) {m_step = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_during);}
            if (sp.TryWrite(1)) {sp.Write(m_ui_title);}
            if (sp.TryWrite(2)) {sp.Write(m_ui_banner);}
            if (sp.TryWrite(3)) {sp.Write(m_ui_rule);}
            if (sp.TryWrite(4)) {sp.Write(m_step);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPrepareStepInfo source) {
            m_during = source.m_during;
            m_ui_title = source.m_ui_title;
            m_ui_banner = source.m_ui_banner;
            m_ui_rule = source.m_ui_rule;
            m_step = source.m_step;
        }
    }
    
    [Serializable]
    public partial class BuySpecialPriceItemReqInfo : NetworkMessage {
        public static int[] Id = { 1381,23 };
        public static Ctrl VC;
        public Int32 m_special_item_id;
        public Int32 m_count;
        public Int16 m_op_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_special_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_op_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_special_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            if (sp.TryWrite(2)) {sp.Write(m_op_type);}
            sp.EnEnd();
        }
        public void CopyFrom(BuySpecialPriceItemReqInfo source) {
            m_special_item_id = source.m_special_item_id;
            m_count = source.m_count;
            m_op_type = source.m_op_type;
        }
    }
    
    [Serializable]
    public partial class TimeLimitedCitySkin : NetworkMessage {
        public static int[] Id = { 1387,23 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_endtime;
        public List<SByte> m_activate_part_ids = new List<SByte>();
        public Boolean m_selected;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_activate_part_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_activate_part_ids.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {m_selected = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_endtime);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_activate_part_ids.Count);
                for (int i = 0; i != m_activate_part_ids.Count; ++i) {
                    sp.Write(m_activate_part_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {sp.Write(m_selected);}
            sp.EnEnd();
        }
        public void CopyFrom(TimeLimitedCitySkin source) {
            m_id = source.m_id;
            m_endtime = source.m_endtime;
            m_activate_part_ids = source.m_activate_part_ids;
            m_selected = source.m_selected;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardSlotInfo : NetworkMessage {
        public static int[] Id = { 1393,23 };
        public static Ctrl VC;
        public SByte m_slot;
        public SByte m_slot_status;
        public Int32 m_task_id;
        public Int64 m_task_user;
        public Int64 m_flush_user;
        public Int64 m_flush_dt;
        public String m_task_user_name = "";
        public Int64 m_task_user_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_slot_status = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_task_user = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_flush_user = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_flush_dt = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_task_user_name = sp.ReadString();}
            if (sp.TryRead(7)) {m_task_user_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot);}
            if (sp.TryWrite(1)) {sp.Write(m_slot_status);}
            if (sp.TryWrite(2)) {sp.Write(m_task_id);}
            if (sp.TryWrite(3)) {sp.Write(m_task_user);}
            if (sp.TryWrite(4)) {sp.Write(m_flush_user);}
            if (sp.TryWrite(5)) {sp.Write(m_flush_dt);}
            if (sp.TryWrite(6)) {sp.Write(m_task_user_name);}
            if (sp.TryWrite(7)) {sp.Write(m_task_user_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardSlotInfo source) {
            m_slot = source.m_slot;
            m_slot_status = source.m_slot_status;
            m_task_id = source.m_task_id;
            m_task_user = source.m_task_user;
            m_flush_user = source.m_flush_user;
            m_flush_dt = source.m_flush_dt;
            m_task_user_name = source.m_task_user_name;
            m_task_user_dt = source.m_task_user_dt;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardApplyTaskAckInfo : NetworkMessage {
        public static int[] Id = { 1399,23 };
        public static Ctrl VC;
        public SByte m_slot_id;
        public Int32 m_task_id;
        public Int64 m_end_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            if (sp.TryWrite(2)) {sp.Write(m_end_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardApplyTaskAckInfo source) {
            m_slot_id = source.m_slot_id;
            m_task_id = source.m_task_id;
            m_end_dt = source.m_end_dt;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardOpenNtfInfo : NetworkMessage {
        public static int[] Id = { 1405,23 };
        public static Ctrl VC;
        public Int64 m_player_id;
        public String m_player_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_player_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_player_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_player_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_name);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardOpenNtfInfo source) {
            m_player_id = source.m_player_id;
            m_player_name = source.m_player_name;
        }
    }
    
    [Serializable]
    public partial class AsSkillInfo : NetworkMessage {
        public static int[] Id = { 1411,23 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_level;
        public Int32 m_points;
        public Int32 m_max_points;
        public Int64 m_cd_endtime;
        public Int64 m_cd_starttime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_points = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_max_points = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_cd_endtime = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_cd_starttime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_points);}
            if (sp.TryWrite(3)) {sp.Write(m_max_points);}
            if (sp.TryWrite(4)) {sp.Write(m_cd_endtime);}
            if (sp.TryWrite(5)) {sp.Write(m_cd_starttime);}
            sp.EnEnd();
        }
        public void CopyFrom(AsSkillInfo source) {
            m_type = source.m_type;
            m_level = source.m_level;
            m_points = source.m_points;
            m_max_points = source.m_max_points;
            m_cd_endtime = source.m_cd_endtime;
            m_cd_starttime = source.m_cd_starttime;
        }
    }
    
    [Serializable]
    public partial class CastGovSkillReqInfo : NetworkMessage {
        public static int[] Id = { 1417,23 };
        public static Ctrl VC;
        public Int32 m_id;
        public ServerTilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CastGovSkillReqInfo source) {
            m_id = source.m_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class AsTaskListInfo : NetworkMessage {
        public static int[] Id = { 1423,23 };
        public static Ctrl VC;
        public List<AsTaskInfo> m_list = new List<AsTaskInfo>();
        public List<Int16> m_unlock_info = new List<Int16>();
        public List<AsTaskPeriodInfo> m_period_info = new List<AsTaskPeriodInfo>();
        public Int64 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsTaskInfo tmp = new AsTaskInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_unlock_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_unlock_info.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_period_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsTaskPeriodInfo tmp = new AsTaskPeriodInfo();
                    tmp.Decode(sp);
                    m_period_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_unlock_info.Count);
                for (int i = 0; i != m_unlock_info.Count; ++i) {
                    sp.Write(m_unlock_info[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_period_info.Count);
                for (int i = 0; i != m_period_info.Count; ++i) {
                    m_period_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskListInfo source) {
            m_list = source.m_list;
            m_unlock_info = source.m_unlock_info;
            m_period_info = source.m_period_info;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class AgentBackgroundInfo : NetworkMessage {
        public static int[] Id = { 1429,23 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int16 m_background_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_background_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_background_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentBackgroundInfo source) {
            m_agent_id = source.m_agent_id;
            m_background_id = source.m_background_id;
        }
    }
    
    [Serializable]
    public partial class AsTaskScoreRankInfo : NetworkMessage {
        public static int[] Id = { 1435,23 };
        public static Ctrl VC;
        public AsTaskScoreRankElement m_self;
        public List<AsTaskScoreRankElement> m_rank = new List<AsTaskScoreRankElement>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_self = new AsTaskScoreRankElement();
                m_self.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsTaskScoreRankElement tmp = new AsTaskScoreRankElement();
                    tmp.Decode(sp);
                    m_rank.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_self.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank.Count);
                for (int i = 0; i != m_rank.Count; ++i) {
                    m_rank[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskScoreRankInfo source) {
            m_self = source.m_self;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class UserShameDetailAckInfo : NetworkMessage {
        public static int[] Id = { 1441,25 };
        public static Ctrl VC;
        public Int64 m_shame_source;
        public String m_shame_source_name = "";
        public Boolean m_is_set;
        public List<CultureAgentInfo> m_agent_list = new List<CultureAgentInfo>();
        public ShameAgentInfo m_shame_agent;
        public List<ShameAgentChoice> m_available_shame_agent = new List<ShameAgentChoice>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_shame_source = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_shame_source_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_is_set = sp.ReadBoolean();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentInfo tmp = new CultureAgentInfo();
                    tmp.Decode(sp);
                    m_agent_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_shame_agent = new ShameAgentInfo();
                m_shame_agent.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_available_shame_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ShameAgentChoice tmp = new ShameAgentChoice();
                    tmp.Decode(sp);
                    m_available_shame_agent.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_shame_source);}
            if (sp.TryWrite(1)) {sp.Write(m_shame_source_name);}
            if (sp.TryWrite(2)) {sp.Write(m_is_set);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent_list.Count);
                for (int i = 0; i != m_agent_list.Count; ++i) {
                    m_agent_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_shame_agent.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_available_shame_agent.Count);
                for (int i = 0; i != m_available_shame_agent.Count; ++i) {
                    m_available_shame_agent[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserShameDetailAckInfo source) {
            m_shame_source = source.m_shame_source;
            m_shame_source_name = source.m_shame_source_name;
            m_is_set = source.m_is_set;
            m_agent_list = source.m_agent_list;
            m_shame_agent = source.m_shame_agent;
            m_available_shame_agent = source.m_available_shame_agent;
        }
    }
    
    [Serializable]
    public partial class UserShameSimpleInfo : NetworkMessage {
        public static int[] Id = { 1447,25 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int64 m_shame_end;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_shame_end = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_shame_end);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShameSimpleInfo source) {
            m_user_id = source.m_user_id;
            m_shame_end = source.m_shame_end;
        }
    }
    
    [Serializable]
    public partial class WeaponSplitAckInfo : NetworkMessage {
        public static int[] Id = { 1453,25 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(WeaponSplitAckInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class WeaponGachaReqInfo : NetworkMessage {
        public static int[] Id = { 1459,25 };
        public static Ctrl VC;
        public Int16 m_gacha_id;
        public Int16 m_count;
        public SByte m_cost_type;
        public Int16 m_auto_split;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_gacha_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cost_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_auto_split = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_gacha_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_type);}
            if (sp.TryWrite(3)) {sp.Write(m_auto_split);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponGachaReqInfo source) {
            m_gacha_id = source.m_gacha_id;
            m_count = source.m_count;
            m_cost_type = source.m_cost_type;
            m_auto_split = source.m_auto_split;
        }
    }
    
    [Serializable]
    public partial class UserShameQuickQueryAckInfo : NetworkMessage {
        public static int[] Id = { 1465,25 };
        public static Ctrl VC;
        public Int64 m_shame_source;
        public Int64 m_end_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_shame_source = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_shame_source);}
            if (sp.TryWrite(1)) {sp.Write(m_end_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShameQuickQueryAckInfo source) {
            m_shame_source = source.m_shame_source;
            m_end_dt = source.m_end_dt;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomFurniture : NetworkMessage {
        public static int[] Id = { 1471,25 };
        public static Ctrl VC;
        public SByte m_f_type;
        public List<Int32> m_f_ids = new List<Int32>();
        public Int32 m_active_one;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_f_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_f_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_f_ids.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_active_one = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_f_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_f_ids.Count);
                for (int i = 0; i != m_f_ids.Count; ++i) {
                    sp.Write(m_f_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_active_one);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomFurniture source) {
            m_f_type = source.m_f_type;
            m_f_ids = source.m_f_ids;
            m_active_one = source.m_active_one;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomVisitInfo : NetworkMessage {
        public static int[] Id = { 1477,25 };
        public static Ctrl VC;
        public Int32 m_c_id;
        public Int32 m_gift_id;
        public Int64 m_v_time;
        public Boolean m_got;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_c_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_gift_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_v_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_got = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_c_id);}
            if (sp.TryWrite(1)) {sp.Write(m_gift_id);}
            if (sp.TryWrite(2)) {sp.Write(m_v_time);}
            if (sp.TryWrite(3)) {sp.Write(m_got);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomVisitInfo source) {
            m_c_id = source.m_c_id;
            m_gift_id = source.m_gift_id;
            m_v_time = source.m_v_time;
            m_got = source.m_got;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomStoryOpInfo : NetworkMessage {
        public static int[] Id = { 1483,25 };
        public static Ctrl VC;
        public Int32 m_c_id;
        public Int16 m_l_id;
        public Boolean m_r_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_c_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_l_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_r_flag = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_c_id);}
            if (sp.TryWrite(1)) {sp.Write(m_l_id);}
            if (sp.TryWrite(2)) {sp.Write(m_r_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomStoryOpInfo source) {
            m_c_id = source.m_c_id;
            m_l_id = source.m_l_id;
            m_r_flag = source.m_r_flag;
        }
    }
    
    [Serializable]
    public partial class ClaimRankingRewardAckInfo : NetworkMessage {
        public static int[] Id = { 1489,27 };
        public static Ctrl VC;
        public Int16 m_code;
        public RankingRewardInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_info = new RankingRewardInfo();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimRankingRewardAckInfo source) {
            m_code = source.m_code;
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class CumulativeRechargeCampaignCfg : NetworkMessage {
        public static int[] Id = { 1495,27 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_diamond_req;
        public String m_key = "";
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Boolean m_is_claimed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_diamond_req = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_key = sp.ReadString();}
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
            if (sp.TryRead(4)) {m_is_claimed = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_diamond_req);}
            if (sp.TryWrite(2)) {sp.Write(m_key);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_is_claimed);}
            sp.EnEnd();
        }
        public void CopyFrom(CumulativeRechargeCampaignCfg source) {
            m_id = source.m_id;
            m_diamond_req = source.m_diamond_req;
            m_key = source.m_key;
            m_items = source.m_items;
            m_is_claimed = source.m_is_claimed;
        }
    }
    
    [Serializable]
    public partial class AllianceUseResearchInfo : NetworkMessage {
        public static int[] Id = { 1502,29 };
        public static Ctrl VC;
        public Int16 m_research_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_research_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_research_type);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceUseResearchInfo source) {
            m_research_type = source.m_research_type;
        }
    }
    
    [Serializable]
    public partial class KvkBountyRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1531,32 };
        public static Ctrl VC;
        public Int32 m_draw_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_draw_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_draw_num);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBountyRewardReqInfo source) {
            m_draw_num = source.m_draw_num;
        }
    }
    
    [Serializable]
    public partial class SendGiftCfg : NetworkMessage {
        public static int[] Id = { 1540,32 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_gift_item_id;
        public List<ItemInfo> m_sender_rewards = new List<ItemInfo>();
        public List<ItemInfo> m_receiver_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_gift_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sender_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_sender_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_receiver_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_receiver_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_gift_item_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sender_rewards.Count);
                for (int i = 0; i != m_sender_rewards.Count; ++i) {
                    m_sender_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_receiver_rewards.Count);
                for (int i = 0; i != m_receiver_rewards.Count; ++i) {
                    m_receiver_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SendGiftCfg source) {
            m_id = source.m_id;
            m_gift_item_id = source.m_gift_item_id;
            m_sender_rewards = source.m_sender_rewards;
            m_receiver_rewards = source.m_receiver_rewards;
        }
    }
    
    [Serializable]
    public partial class AgentWgtBoxGradeUpReqInfo : NetworkMessage {
        public static int[] Id = { 1596,33 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int16 m_box_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_box_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_box_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentWgtBoxGradeUpReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_box_id = source.m_box_id;
        }
    }
    
    [Serializable]
    public partial class ReadGiftRecordReqInfo : NetworkMessage {
        public static int[] Id = { 1602,33 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(ReadGiftRecordReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class NbpDrawDailyTaskExpAckInfo : NetworkMessage {
        public static int[] Id = { 1640,34 };
        public static Ctrl VC;
        public Int32 m_exp;
        public Int32 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exp);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpDrawDailyTaskExpAckInfo source) {
            m_exp = source.m_exp;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class MonopolyEventsCfg : NetworkMessage {
        public static int[] Id = { 1647,35 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_event_icon = "";
        public String m_text = "";
        public String m_button_pic = "";
        public String m_button_effect = "";
        public Int32 m_event_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_event_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_text = sp.ReadString();}
            if (sp.TryRead(3)) {m_button_pic = sp.ReadString();}
            if (sp.TryRead(4)) {m_button_effect = sp.ReadString();}
            if (sp.TryRead(5)) {m_event_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_event_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_text);}
            if (sp.TryWrite(3)) {sp.Write(m_button_pic);}
            if (sp.TryWrite(4)) {sp.Write(m_button_effect);}
            if (sp.TryWrite(5)) {sp.Write(m_event_type);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyEventsCfg source) {
            m_id = source.m_id;
            m_event_icon = source.m_event_icon;
            m_text = source.m_text;
            m_button_pic = source.m_button_pic;
            m_button_effect = source.m_button_effect;
            m_event_type = source.m_event_type;
        }
    }
    
    [Serializable]
    public partial class KvkRecycleCenterInfo : NetworkMessage {
        public static int[] Id = { 1664,36 };
        public static Ctrl VC;
        public Int32 m_base_troop_refund_ratio;
        public Int32 m_item_add_troop_refund_ratio;
        public Int32 m_max_item_add_troop_refund_ratio;
        public List<KvkRecycleTroopInfo> m_troop_dead_info = new List<KvkRecycleTroopInfo>();
        public List<KvkRecycleTroopInfo> m_troop_refund_info = new List<KvkRecycleTroopInfo>();
        public Int32 m_add_refund_ratio_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_base_troop_refund_ratio = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_add_troop_refund_ratio = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_max_item_add_troop_refund_ratio = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop_dead_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkRecycleTroopInfo tmp = new KvkRecycleTroopInfo();
                    tmp.Decode(sp);
                    m_troop_dead_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop_refund_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkRecycleTroopInfo tmp = new KvkRecycleTroopInfo();
                    tmp.Decode(sp);
                    m_troop_refund_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_add_refund_ratio_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_base_troop_refund_ratio);}
            if (sp.TryWrite(1)) {sp.Write(m_item_add_troop_refund_ratio);}
            if (sp.TryWrite(2)) {sp.Write(m_max_item_add_troop_refund_ratio);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop_dead_info.Count);
                for (int i = 0; i != m_troop_dead_info.Count; ++i) {
                    m_troop_dead_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop_refund_info.Count);
                for (int i = 0; i != m_troop_refund_info.Count; ++i) {
                    m_troop_refund_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_add_refund_ratio_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkRecycleCenterInfo source) {
            m_base_troop_refund_ratio = source.m_base_troop_refund_ratio;
            m_item_add_troop_refund_ratio = source.m_item_add_troop_refund_ratio;
            m_max_item_add_troop_refund_ratio = source.m_max_item_add_troop_refund_ratio;
            m_troop_dead_info = source.m_troop_dead_info;
            m_troop_refund_info = source.m_troop_refund_info;
            m_add_refund_ratio_item_id = source.m_add_refund_ratio_item_id;
        }
    }
    
    [Serializable]
    public partial class WarshipWarmUpCampaignInfo : NetworkMessage {
        public static int[] Id = { 1670,37 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public WarshipWarmUpCfg m_cfg;
        public Boolean m_is_received_reward;
        public Boolean m_is_bought_gift;
        public Int32 m_received_times;
        public Int32 m_max_receive_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new WarshipWarmUpCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_is_received_reward = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_is_bought_gift = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_received_times = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_max_receive_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_is_received_reward);}
            if (sp.TryWrite(3)) {sp.Write(m_is_bought_gift);}
            if (sp.TryWrite(4)) {sp.Write(m_received_times);}
            if (sp.TryWrite(5)) {sp.Write(m_max_receive_times);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWarmUpCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
            m_is_received_reward = source.m_is_received_reward;
            m_is_bought_gift = source.m_is_bought_gift;
            m_received_times = source.m_received_times;
            m_max_receive_times = source.m_max_receive_times;
        }
    }
    
    [Serializable]
    public partial class PrivatecCustomPkgInfo : NetworkMessage {
        public static int[] Id = { 1681,38 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_pkg_id;
        public String m_desc = "";
        public String m_base_award = "";
        public String m_extra_award = "";
        public Int32 m_choose_award_num;
        public String m_choose_award = "";
        public Int32 m_as_chest_awd;
        public String m_product_id = "";
        public Int32 m_bought_cnt;
        public Int32 m_max_buy_cnt;
        public List<Int32> m_custom_reward_index = new List<Int32>();
        public String m_origin_product_id = "";
        public String m_discount_title = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_desc = sp.ReadString();}
            if (sp.TryRead(3)) {m_base_award = sp.ReadString();}
            if (sp.TryRead(4)) {m_extra_award = sp.ReadString();}
            if (sp.TryRead(5)) {m_choose_award_num = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_choose_award = sp.ReadString();}
            if (sp.TryRead(7)) {m_as_chest_awd = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_product_id = sp.ReadString();}
            if (sp.TryRead(9)) {m_bought_cnt = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_max_buy_cnt = sp.ReadInt32();}
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_custom_reward_index.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_custom_reward_index.Add(tmp);
                }
            }
            if (sp.TryRead(12)) {m_origin_product_id = sp.ReadString();}
            if (sp.TryRead(13)) {m_discount_title = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(2)) {sp.Write(m_desc);}
            if (sp.TryWrite(3)) {sp.Write(m_base_award);}
            if (sp.TryWrite(4)) {sp.Write(m_extra_award);}
            if (sp.TryWrite(5)) {sp.Write(m_choose_award_num);}
            if (sp.TryWrite(6)) {sp.Write(m_choose_award);}
            if (sp.TryWrite(7)) {sp.Write(m_as_chest_awd);}
            if (sp.TryWrite(8)) {sp.Write(m_product_id);}
            if (sp.TryWrite(9)) {sp.Write(m_bought_cnt);}
            if (sp.TryWrite(10)) {sp.Write(m_max_buy_cnt);}
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_custom_reward_index.Count);
                for (int i = 0; i != m_custom_reward_index.Count; ++i) {
                    sp.Write(m_custom_reward_index[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(12)) {sp.Write(m_origin_product_id);}
            if (sp.TryWrite(13)) {sp.Write(m_discount_title);}
            sp.EnEnd();
        }
        public void CopyFrom(PrivatecCustomPkgInfo source) {
            m_id = source.m_id;
            m_pkg_id = source.m_pkg_id;
            m_desc = source.m_desc;
            m_base_award = source.m_base_award;
            m_extra_award = source.m_extra_award;
            m_choose_award_num = source.m_choose_award_num;
            m_choose_award = source.m_choose_award;
            m_as_chest_awd = source.m_as_chest_awd;
            m_product_id = source.m_product_id;
            m_bought_cnt = source.m_bought_cnt;
            m_max_buy_cnt = source.m_max_buy_cnt;
            m_custom_reward_index = source.m_custom_reward_index;
            m_origin_product_id = source.m_origin_product_id;
            m_discount_title = source.m_discount_title;
        }
    }
    
    [Serializable]
    public partial class UserRefundPunishInfo : NetworkMessage {
        public static int[] Id = { 1688,39 };
        public static Ctrl VC;
        public Int64 m_fine_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fine_amount = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fine_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(UserRefundPunishInfo source) {
            m_fine_amount = source.m_fine_amount;
        }
    }
    
    [Serializable]
    public partial class EquipDecomposeReqInfo : NetworkMessage {
        public static int[] Id = { 1701,40 };
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
        public void CopyFrom(EquipDecomposeReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class PurchaseRebateCfg : NetworkMessage {
        public static int[] Id = { 1710,41 };
        public static Ctrl VC;
        public Int32 m_award_item_id;
        public String m_award_item_number = "";
        public String m_iap_button = "";
        public String m_iap_icon = "";
        public List<PurchaseRebateSubCfg> m_sub_cfgs = new List<PurchaseRebateSubCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_award_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_award_item_number = sp.ReadString();}
            if (sp.TryRead(2)) {m_iap_button = sp.ReadString();}
            if (sp.TryRead(3)) {m_iap_icon = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sub_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PurchaseRebateSubCfg tmp = new PurchaseRebateSubCfg();
                    tmp.Decode(sp);
                    m_sub_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_award_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_award_item_number);}
            if (sp.TryWrite(2)) {sp.Write(m_iap_button);}
            if (sp.TryWrite(3)) {sp.Write(m_iap_icon);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sub_cfgs.Count);
                for (int i = 0; i != m_sub_cfgs.Count; ++i) {
                    m_sub_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PurchaseRebateCfg source) {
            m_award_item_id = source.m_award_item_id;
            m_award_item_number = source.m_award_item_number;
            m_iap_button = source.m_iap_button;
            m_iap_icon = source.m_iap_icon;
            m_sub_cfgs = source.m_sub_cfgs;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeIapListReqInfo : NetworkMessage {
        public static int[] Id = { 1717,41 };
        public static Ctrl VC;
        public Int32 m_iap_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeIapListReqInfo source) {
            m_iap_type = source.m_iap_type;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalSetEndAwardReqInfo : NetworkMessage {
        public static int[] Id = { 1726,41 };
        public static Ctrl VC;
        public Int32 m_end_award_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_end_award_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_end_award_index);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalSetEndAwardReqInfo source) {
            m_end_award_index = source.m_end_award_index;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeCampaignInfo : NetworkMessage {
        public static int[] Id = { 1733,42 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public StrangeCubeCampaignPlayerInfo m_player_info;
        public StrangeCubeCampaignCfg m_config;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_player_info = new StrangeCubeCampaignPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_config = new StrangeCubeCampaignCfg();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(StrangeCubeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_player_info = source.m_player_info;
            m_config = source.m_config;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeOpenCubeAckInfo : NetworkMessage {
        public static int[] Id = { 1739,42 };
        public static Ctrl VC;
        public StrangeCubeCampaignPlayerInfo m_player_info;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_player_info = new StrangeCubeCampaignPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
        public void CopyFrom(StrangeCubeOpenCubeAckInfo source) {
            m_player_info = source.m_player_info;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class WarMarketDrawReqInfo : NetworkMessage {
        public static int[] Id = { 1745,42 };
        public static Ctrl VC;
        public Int32 m_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_times);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketDrawReqInfo source) {
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignCfg : NetworkMessage {
        public static int[] Id = { 1751,44 };
        public static Ctrl VC;
        public List<LineTaskCampaignExtraAwardCfg> m_extra_award_cfgs = new List<LineTaskCampaignExtraAwardCfg>();
        public List<LineTaskCampaignLineCfg> m_line_cfgs = new List<LineTaskCampaignLineCfg>();
        public LineTaskCampaignPicCfg m_pic_cfg;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_award_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LineTaskCampaignExtraAwardCfg tmp = new LineTaskCampaignExtraAwardCfg();
                    tmp.Decode(sp);
                    m_extra_award_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_line_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LineTaskCampaignLineCfg tmp = new LineTaskCampaignLineCfg();
                    tmp.Decode(sp);
                    m_line_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_pic_cfg = new LineTaskCampaignPicCfg();
                m_pic_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_award_cfgs.Count);
                for (int i = 0; i != m_extra_award_cfgs.Count; ++i) {
                    m_extra_award_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_line_cfgs.Count);
                for (int i = 0; i != m_line_cfgs.Count; ++i) {
                    m_line_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_pic_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LineTaskCampaignCfg source) {
            m_extra_award_cfgs = source.m_extra_award_cfgs;
            m_line_cfgs = source.m_line_cfgs;
            m_pic_cfg = source.m_pic_cfg;
        }
    }
    
    [Serializable]
    public partial class LineTaskGetExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1757,44 };
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
        public void CopyFrom(LineTaskGetExtraRewardReqInfo source) {
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class LegendShopItemInfo : NetworkMessage {
        public static int[] Id = { 1772,44 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int32 m_token_id;
        public Int32 m_price_value;
        public Int32 m_item_num_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_token_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_price_value = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_item_num_max = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_num);}
            if (sp.TryWrite(3)) {sp.Write(m_token_id);}
            if (sp.TryWrite(4)) {sp.Write(m_price_value);}
            if (sp.TryWrite(5)) {sp.Write(m_item_num_max);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendShopItemInfo source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_token_id = source.m_token_id;
            m_price_value = source.m_price_value;
            m_item_num_max = source.m_item_num_max;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitExchangeOptionalAwardReqInfo : NetworkMessage {
        public static int[] Id = { 1780,44 };
        public static Ctrl VC;
        public List<Int32> m_ids = new List<Int32>();
        public List<Int32> m_nums = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_ids.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_nums.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_nums.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ids.Count);
                for (int i = 0; i != m_ids.Count; ++i) {
                    sp.Write(m_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_nums.Count);
                for (int i = 0; i != m_nums.Count; ++i) {
                    sp.Write(m_nums[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitExchangeOptionalAwardReqInfo source) {
            m_ids = source.m_ids;
            m_nums = source.m_nums;
        }
    }
    
    [Serializable]
    public partial class VoteCampaignItem : NetworkMessage {
        public static int[] Id = { 1809,44 };
        public static Ctrl VC;
        public Int16 m_order;
        public String m_icon = "";
        public String m_vote_desc = "";
        public Int64 m_score;
        public Boolean m_is_vote;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_vote_desc = sp.ReadString();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_is_vote = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_vote_desc);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_is_vote);}
            sp.EnEnd();
        }
        public void CopyFrom(VoteCampaignItem source) {
            m_order = source.m_order;
            m_icon = source.m_icon;
            m_vote_desc = source.m_vote_desc;
            m_score = source.m_score;
            m_is_vote = source.m_is_vote;
        }
    }
    
    [Serializable]
    public partial class DailyFreeMiniPack : NetworkMessage {
        public static int[] Id = { 1815,45 };
        public static Ctrl VC;
        public List<DailyFreePackItem> m_items = new List<DailyFreePackItem>();
        public SByte m_is_available;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailyFreePackItem tmp = new DailyFreePackItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_is_available = sp.ReadSByte();}
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
            if (sp.TryWrite(1)) {sp.Write(m_is_available);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyFreeMiniPack source) {
            m_items = source.m_items;
            m_is_available = source.m_is_available;
        }
    }
    
    [Serializable]
    public partial class CityDecorationList : NetworkMessage {
        public static int[] Id = { 1889,46 };
        public static Ctrl VC;
        public List<CityDecoration> m_list = new List<CityDecoration>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CityDecoration tmp = new CityDecoration();
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
        public void CopyFrom(CityDecorationList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class RecycleCampaignExchangeCfg : NetworkMessage {
        public static int[] Id = { 1895,46 };
        public static Ctrl VC;
        public Int16 m_order;
        public ItemInfo m_reward_item;
        public Int32 m_exchange_limit;
        public Int32 m_curr_exchange_num;
        public ItemInfo m_cost_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_reward_item = new ItemInfo();
                m_reward_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_exchange_limit = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_curr_exchange_num = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                m_cost_item = new ItemInfo();
                m_cost_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_reward_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_exchange_limit);}
            if (sp.TryWrite(3)) {sp.Write(m_curr_exchange_num);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_cost_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RecycleCampaignExchangeCfg source) {
            m_order = source.m_order;
            m_reward_item = source.m_reward_item;
            m_exchange_limit = source.m_exchange_limit;
            m_curr_exchange_num = source.m_curr_exchange_num;
            m_cost_item = source.m_cost_item;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignInfo : NetworkMessage {
        public static int[] Id = { 1901,46 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public AllianceTreasureCampaignAsInfo m_as_info;
        public AllianceTreasureCampaignPlayerInfo m_player_info;
        public AllianceTreasureCampaignCfg m_config;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_as_info = new AllianceTreasureCampaignAsInfo();
                m_as_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new AllianceTreasureCampaignPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_config = new AllianceTreasureCampaignCfg();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_as_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_as_info = source.m_as_info;
            m_player_info = source.m_player_info;
            m_config = source.m_config;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureReceiveAsRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1907,46 };
        public static Ctrl VC;
        public SByte m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureReceiveAsRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class PlayerReturnEventNtfInfo : NetworkMessage {
        public static int[] Id = { 1916,47 };
        public static Ctrl VC;
        public Int64 m_end_time;
        public Int32 m_login_day_num;
        public List<Int32> m_received_reward_login_days = new List<Int32>();
        public List<PlayerReturnEventTaskInfo> m_tasks = new List<PlayerReturnEventTaskInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_login_day_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_received_reward_login_days.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_received_reward_login_days.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tasks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PlayerReturnEventTaskInfo tmp = new PlayerReturnEventTaskInfo();
                    tmp.Decode(sp);
                    m_tasks.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_end_time);}
            if (sp.TryWrite(1)) {sp.Write(m_login_day_num);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_received_reward_login_days.Count);
                for (int i = 0; i != m_received_reward_login_days.Count; ++i) {
                    sp.Write(m_received_reward_login_days[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tasks.Count);
                for (int i = 0; i != m_tasks.Count; ++i) {
                    m_tasks[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PlayerReturnEventNtfInfo source) {
            m_end_time = source.m_end_time;
            m_login_day_num = source.m_login_day_num;
            m_received_reward_login_days = source.m_received_reward_login_days;
            m_tasks = source.m_tasks;
        }
    }
    
    [Serializable]
    public partial class HeroOptionalPkgGroup : NetworkMessage {
        public static int[] Id = { 1926,48 };
        public static Ctrl VC;
        public Int16 m_hero_id;
        public List<HeroOptionalPkgGroupItem> m_pkgs = new List<HeroOptionalPkgGroupItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pkgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HeroOptionalPkgGroupItem tmp = new HeroOptionalPkgGroupItem();
                    tmp.Decode(sp);
                    m_pkgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pkgs.Count);
                for (int i = 0; i != m_pkgs.Count; ++i) {
                    m_pkgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(HeroOptionalPkgGroup source) {
            m_hero_id = source.m_hero_id;
            m_pkgs = source.m_pkgs;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStepRewardsInfo : NetworkMessage {
        public static int[] Id = { 1987,49 };
        public static Ctrl VC;
        public Boolean m_is_drew;
        public SByte m_right_num;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_drew = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_right_num = sp.ReadSByte();}
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
            if (sp.TryWrite(0)) {sp.Write(m_is_drew);}
            if (sp.TryWrite(1)) {sp.Write(m_right_num);}
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
        public void CopyFrom(QuestionAnswerStepRewardsInfo source) {
            m_is_drew = source.m_is_drew;
            m_right_num = source.m_right_num;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerCommitAckInfo : NetworkMessage {
        public static int[] Id = { 1993,49 };
        public static Ctrl VC;
        public QuestionAnswerStepInfo m_step_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_step_info = new QuestionAnswerStepInfo();
                m_step_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_step_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerCommitAckInfo source) {
            m_step_info = source.m_step_info;
        }
    }
    
    [Serializable]
    public partial class FlipCardCellRewardConfig : NetworkMessage {
        public static int[] Id = { 1999,49 };
        public static Ctrl VC;
        public Int16 m_id;
        public ItemInfo m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_reward = new ItemInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardCellRewardConfig source) {
            m_id = source.m_id;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class FlipCardReqInfo : NetworkMessage {
        public static int[] Id = { 2005,49 };
        public static Ctrl VC;
        public SByte m_x;
        public SByte m_y;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_y = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardReqInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponSellReqInfo : NetworkMessage {
        public static int[] Id = { 2037,50 };
        public static Ctrl VC;
        public Int64 m_id;
        public List<Int64> m_ids = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_ids.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ids.Count);
                for (int i = 0; i != m_ids.Count; ++i) {
                    sp.Write(m_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponSellReqInfo source) {
            m_id = source.m_id;
            m_ids = source.m_ids;
        }
    }
    
    [Serializable]
    public partial class UserWarshipWeaponNtfInfo : NetworkMessage {
        public static int[] Id = { 2043,50 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public List<WarshipWeaponInfo> m_weapons = new List<WarshipWeaponInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapons.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarshipWeaponInfo tmp = new WarshipWeaponInfo();
                    tmp.Decode(sp);
                    m_weapons.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapons.Count);
                for (int i = 0; i != m_weapons.Count; ++i) {
                    m_weapons[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipWeaponNtfInfo source) {
            m_warship_id = source.m_warship_id;
            m_weapons = source.m_weapons;
        }
    }
    
    [Serializable]
    public partial class ValorShopNtfInfo : NetworkMessage {
        public static int[] Id = { 2053,51 };
        public static Ctrl VC;
        public List<ValorShopItemBuyRecord> m_buy_records = new List<ValorShopItemBuyRecord>();
        public Int64 m_kvk_season_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buy_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ValorShopItemBuyRecord tmp = new ValorShopItemBuyRecord();
                    tmp.Decode(sp);
                    m_buy_records.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_kvk_season_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buy_records.Count);
                for (int i = 0; i != m_buy_records.Count; ++i) {
                    m_buy_records[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_kvk_season_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(ValorShopNtfInfo source) {
            m_buy_records = source.m_buy_records;
            m_kvk_season_end_time = source.m_kvk_season_end_time;
        }
    }
    
    [Serializable]
    public partial class BattleBannerList : NetworkMessage {
        public static int[] Id = { 2059,53 };
        public static Ctrl VC;
        public List<BattleBannerInfo> m_list = new List<BattleBannerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BattleBannerInfo tmp = new BattleBannerInfo();
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
        public void CopyFrom(BattleBannerList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class RaidPlayerEffectInfo : NetworkMessage {
        public static int[] Id = { 2117,54 };
        public static Ctrl VC;
        public Int32 m_effect_id;
        public Int32 m_effect_value;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_effect_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_effect_value = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_effect_id);}
            if (sp.TryWrite(1)) {sp.Write(m_effect_value);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidPlayerEffectInfo source) {
            m_effect_id = source.m_effect_id;
            m_effect_value = source.m_effect_value;
        }
    }
    
    [Serializable]
    public partial class RaidChooseEffectReqInfo : NetworkMessage {
        public static int[] Id = { 2123,54 };
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
        public void CopyFrom(RaidChooseEffectReqInfo source) {
            m_index = source.m_index;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeGroupStatInfo : NetworkMessage {
        public static int[] Id = { 2129,54 };
        public static Ctrl VC;
        public RaidChallengeGroupInfo m_group;
        public Int64 m_kill;
        public Int64 m_health;
        public Int64 m_remain;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_group = new RaidChallengeGroupInfo();
                m_group.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_kill = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_health = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_remain = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_group.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_kill);}
            if (sp.TryWrite(2)) {sp.Write(m_health);}
            if (sp.TryWrite(3)) {sp.Write(m_remain);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidChallengeGroupStatInfo source) {
            m_group = source.m_group;
            m_kill = source.m_kill;
            m_health = source.m_health;
            m_remain = source.m_remain;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactUnlockReqInfo : NetworkMessage {
        public static int[] Id = { 2146,56 };
        public static Ctrl VC;
        public Int32 m_model_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_model_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_model_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactUnlockReqInfo source) {
            m_model_id = source.m_model_id;
        }
    }
    
    [Serializable]
    public partial class MuseumRewardInfo : NetworkMessage {
        public static int[] Id = { 2152,56 };
        public static Ctrl VC;
        public Int32 m_gold_num;
        public Int32 m_event_id;
        public Boolean m_is_received;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_gold_num = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_event_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_is_received = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_gold_num);}
            if (sp.TryWrite(1)) {sp.Write(m_event_id);}
            if (sp.TryWrite(2)) {sp.Write(m_is_received);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumRewardInfo source) {
            m_gold_num = source.m_gold_num;
            m_event_id = source.m_event_id;
            m_is_received = source.m_is_received;
        }
    }
    
    [Serializable]
    public partial class OverturnCardInfo : NetworkMessage {
        public static int[] Id = { 2158,57 };
        public static Ctrl VC;
        public SByte m_x;
        public SByte m_y;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Boolean m_is_end_tag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_y = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_is_end_tag = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            if (sp.TryWrite(2)) {sp.Write(m_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_item_num);}
            if (sp.TryWrite(4)) {sp.Write(m_is_end_tag);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnCardInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_is_end_tag = source.m_is_end_tag;
        }
    }
    
    [Serializable]
    public partial class OverturnShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 2167,57 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnShopBuyReqInfo source) {
            m_id = source.m_id;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactConvertInfo : NetworkMessage {
        public static int[] Id = { 2173,58 };
        public static Ctrl VC;
        public Int32 m_model_id;
        public Int32 m_num;
        public Int32 m_shards_item_id;
        public Int32 m_shards_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_model_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_shards_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_shards_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_model_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            if (sp.TryWrite(2)) {sp.Write(m_shards_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_shards_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactConvertInfo source) {
            m_model_id = source.m_model_id;
            m_num = source.m_num;
            m_shards_item_id = source.m_shards_item_id;
            m_shards_item_num = source.m_shards_item_num;
        }
    }
    
    [Serializable]
    public partial class UnlockTroopSkinReqInfo : NetworkMessage {
        public static int[] Id = { 2185,59 };
        public static Ctrl VC;
        public Int16 m_troop_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_troop_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_troop_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UnlockTroopSkinReqInfo source) {
            m_troop_skin_id = source.m_troop_skin_id;
        }
    }
    
    [Serializable]
    public partial class AgentShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 2191,61 };
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
        public void CopyFrom(AgentShopBuyReqInfo source) {
            m_goods_id = source.m_goods_id;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class ChainGiftsCampaignRewardAdditionalInfo : NetworkMessage {
        public static int[] Id = { 2253,63 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_score;
        public List<ItemInfo> m_reward_list = new List<ItemInfo>();
        public Boolean m_is_received;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_is_received = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_list.Count);
                for (int i = 0; i != m_reward_list.Count; ++i) {
                    m_reward_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_is_received);}
            sp.EnEnd();
        }
        public void CopyFrom(ChainGiftsCampaignRewardAdditionalInfo source) {
            m_id = source.m_id;
            m_score = source.m_score;
            m_reward_list = source.m_reward_list;
            m_is_received = source.m_is_received;
        }
    }
    
    [Serializable]
    public partial class FriendInfoAckInfo : NetworkMessage {
        public static int[] Id = { 2259,63 };
        public static Ctrl VC;
        public List<FriendUserInfo> m_friend_list = new List<FriendUserInfo>();
        public List<FriendSendGiftInfo> m_send_gift_list = new List<FriendSendGiftInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_friend_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendUserInfo tmp = new FriendUserInfo();
                    tmp.Decode(sp);
                    m_friend_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_send_gift_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendSendGiftInfo tmp = new FriendSendGiftInfo();
                    tmp.Decode(sp);
                    m_send_gift_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_friend_list.Count);
                for (int i = 0; i != m_friend_list.Count; ++i) {
                    m_friend_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_send_gift_list.Count);
                for (int i = 0; i != m_send_gift_list.Count; ++i) {
                    m_send_gift_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FriendInfoAckInfo source) {
            m_friend_list = source.m_friend_list;
            m_send_gift_list = source.m_send_gift_list;
        }
    }
    
    [Serializable]
    public partial class FriendDeleteReqInfo : NetworkMessage {
        public static int[] Id = { 2265,63 };
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
        public void CopyFrom(FriendDeleteReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class PuzzleCampaignInfo : NetworkMessage {
        public static int[] Id = { 2271,63 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<PuzzleCampaignPuzzleInfo> m_puzzle_list = new List<PuzzleCampaignPuzzleInfo>();
        public PuzzleCampaignGachaInfo m_gacha_info;
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();
        public List<ItemInfo> m_reward_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_puzzle_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PuzzleCampaignPuzzleInfo tmp = new PuzzleCampaignPuzzleInfo();
                    tmp.Decode(sp);
                    m_puzzle_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_gacha_info = new PuzzleCampaignGachaInfo();
                m_gacha_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_current_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_current_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward_items.Add(tmp);
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
                sp.Write((UInt16)m_puzzle_list.Count);
                for (int i = 0; i != m_puzzle_list.Count; ++i) {
                    m_puzzle_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_gacha_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_info.Count);
                for (int i = 0; i != m_exchange_info.Count; ++i) {
                    m_exchange_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_current_items.Count);
                for (int i = 0; i != m_current_items.Count; ++i) {
                    m_current_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_items.Count);
                for (int i = 0; i != m_reward_items.Count; ++i) {
                    m_reward_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PuzzleCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_puzzle_list = source.m_puzzle_list;
            m_gacha_info = source.m_gacha_info;
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
            m_reward_items = source.m_reward_items;
        }
    }
    
    [Serializable]
    public partial class PuzzleDrawItemInfo : NetworkMessage {
        public static int[] Id = { 2277,63 };
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
        public void CopyFrom(PuzzleDrawItemInfo source) {
            m_item_id = source.m_item_id;
            m_item_count = source.m_item_count;
            m_new_item_id = source.m_new_item_id;
            m_new_item_count = source.m_new_item_count;
        }
    }
    
    [Serializable]
    public partial class AgentEquipPurifyAckInfo : NetworkMessage {
        public static int[] Id = { 2289,64 };
        public static Ctrl VC;
        public EquipInfo m_equip_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_equip_info = new EquipInfo();
                m_equip_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_equip_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentEquipPurifyAckInfo source) {
            m_equip_info = source.m_equip_info;
        }
    }
    
    [Serializable]
    public partial class HomeEffectList : NetworkMessage {
        public static int[] Id = { 2295,64 };
        public static Ctrl VC;
        public List<HomeEffectInfo> m_list = new List<HomeEffectInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HomeEffectInfo tmp = new HomeEffectInfo();
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
        public void CopyFrom(HomeEffectList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class BaseTeleportEffectInfo : NetworkMessage {
        public static int[] Id = { 2312,65 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseTeleportEffectInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class SignInCampaignSignInAckInfo : NetworkMessage {
        public static int[] Id = { 2318,65 };
        public static Ctrl VC;
        public SignInCampaignPlayerInfo m_player_info;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_player_info = new SignInCampaignPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
        public void CopyFrom(SignInCampaignSignInAckInfo source) {
            m_player_info = source.m_player_info;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoDetailsReqInfo : NetworkMessage {
        public static int[] Id = { 2324,66 };
        public static Ctrl VC;
        public Int64 m_video_id;
        public Boolean m_return_related_video;
        public Int32 m_related_video_start_index;
        public Int32 m_related_video_end_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_return_related_video = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_related_video_start_index = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_related_video_end_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            if (sp.TryWrite(1)) {sp.Write(m_return_related_video);}
            if (sp.TryWrite(2)) {sp.Write(m_related_video_start_index);}
            if (sp.TryWrite(3)) {sp.Write(m_related_video_end_index);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoDetailsReqInfo source) {
            m_video_id = source.m_video_id;
            m_return_related_video = source.m_return_related_video;
            m_related_video_start_index = source.m_related_video_start_index;
            m_related_video_end_index = source.m_related_video_end_index;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDislikeVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2330,66 };
        public static Ctrl VC;
        public Int64 m_video_id;
        public Boolean m_positive;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_positive = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            if (sp.TryWrite(1)) {sp.Write(m_positive);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelDislikeVideoReqInfo source) {
            m_video_id = source.m_video_id;
            m_positive = source.m_positive;
        }
    }
    
    [Serializable]
    public partial class VideoChannelCommitVideoCommentAckInfo : NetworkMessage {
        public static int[] Id = { 2336,66 };
        public static Ctrl VC;
        public VideoCommentInfo m_comment;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_comment = new VideoCommentInfo();
                m_comment.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_comment.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelCommitVideoCommentAckInfo source) {
            m_comment = source.m_comment;
        }
    }
    
    [Serializable]
    public partial class VideoChannelLikeVideoCommentAckInfo : NetworkMessage {
        public static int[] Id = { 2342,66 };
        public static Ctrl VC;
        public VideoCommentInfo m_comment;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_comment = new VideoCommentInfo();
                m_comment.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_comment.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelLikeVideoCommentAckInfo source) {
            m_comment = source.m_comment;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoCreatorRankReqInfo : NetworkMessage {
        public static int[] Id = { 2348,66 };
        public static Ctrl VC;
        public String m_rank_type = "";
        public String m_time_range = "";
        public Int32 m_start_rank;
        public Int32 m_end_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank_type = sp.ReadString();}
            if (sp.TryRead(1)) {m_time_range = sp.ReadString();}
            if (sp.TryRead(2)) {m_start_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_end_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank_type);}
            if (sp.TryWrite(1)) {sp.Write(m_time_range);}
            if (sp.TryWrite(2)) {sp.Write(m_start_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_end_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoCreatorRankReqInfo source) {
            m_rank_type = source.m_rank_type;
            m_time_range = source.m_time_range;
            m_start_rank = source.m_start_rank;
            m_end_rank = source.m_end_rank;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetTagVideoListReqInfo : NetworkMessage {
        public static int[] Id = { 2354,66 };
        public static Ctrl VC;
        public String m_tag = "";
        public Int32 m_start_rank;
        public Int32 m_end_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_tag = sp.ReadString();}
            if (sp.TryRead(1)) {m_start_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_tag);}
            if (sp.TryWrite(1)) {sp.Write(m_start_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_end_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetTagVideoListReqInfo source) {
            m_tag = source.m_tag;
            m_start_rank = source.m_start_rank;
            m_end_rank = source.m_end_rank;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetShopDataAckInfo : NetworkMessage {
        public static int[] Id = { 2360,66 };
        public static Ctrl VC;
        public List<VideoChannelShopBuyRecord> m_buy_record_list = new List<VideoChannelShopBuyRecord>();
        public Int64 m_next_daily_refresh_time_ms;
        public Int64 m_next_week_refresh_time_ms;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buy_record_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoChannelShopBuyRecord tmp = new VideoChannelShopBuyRecord();
                    tmp.Decode(sp);
                    m_buy_record_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_next_daily_refresh_time_ms = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_next_week_refresh_time_ms = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buy_record_list.Count);
                for (int i = 0; i != m_buy_record_list.Count; ++i) {
                    m_buy_record_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_next_daily_refresh_time_ms);}
            if (sp.TryWrite(2)) {sp.Write(m_next_week_refresh_time_ms);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetShopDataAckInfo source) {
            m_buy_record_list = source.m_buy_record_list;
            m_next_daily_refresh_time_ms = source.m_next_daily_refresh_time_ms;
            m_next_week_refresh_time_ms = source.m_next_week_refresh_time_ms;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoDemandReqInfo : NetworkMessage {
        public static int[] Id = { 2366,66 };
        public static Ctrl VC;
        public String m_platform = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_platform = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_platform);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoDemandReqInfo source) {
            m_platform = source.m_platform;
        }
    }
    
    [Serializable]
    public partial class UserMedalInfo : NetworkMessage {
        public static int[] Id = { 2391,68 };
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
        public void CopyFrom(UserMedalInfo source) {
            m_id = source.m_id;
            m_star = source.m_star;
            m_slot = source.m_slot;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetSubchannelCandidateVideoListAckInfo : NetworkMessage {
        public static int[] Id = { 2397,68 };
        public static Ctrl VC;
        public Int32 m_total_count;
        public List<VideoInfo> m_video_list = new List<VideoInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total_count = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_video_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoInfo tmp = new VideoInfo();
                    tmp.Decode(sp);
                    m_video_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total_count);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_video_list.Count);
                for (int i = 0; i != m_video_list.Count; ++i) {
                    m_video_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetSubchannelCandidateVideoListAckInfo source) {
            m_total_count = source.m_total_count;
            m_video_list = source.m_video_list;
        }
    }
    
    [Serializable]
    public partial class KvkStrategyChangeAckInfo : NetworkMessage {
        public static int[] Id = { 2403,69 };
        public static Ctrl VC;
        public KvkStrategyGroupInfo m_strategy_group;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_strategy_group = new KvkStrategyGroupInfo();
                m_strategy_group.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_strategy_group.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkStrategyChangeAckInfo source) {
            m_strategy_group = source.m_strategy_group;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventTaskData : NetworkMessage {
        public static int[] Id = { 2439,72 };
        public static Ctrl VC;
        public List<BaseProgressiveTaskCampaignInfo> m_task_info = new List<BaseProgressiveTaskCampaignInfo>();
        public List<ItemInfo> m_final_reward = new List<ItemInfo>();
        public Int64 m_final_reward_min_score;
        public SByte m_cur_step;
        public SByte m_max_step;
        public Int64 m_final_reward_limit_dt;
        public Boolean m_final_reward_got;
        public Int32 m_final_reward_got_cnt;
        public List<CampaignFinalReward> m_new_final_reward = new List<CampaignFinalReward>();
        public Int32 m_cur_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseProgressiveTaskCampaignInfo tmp = new BaseProgressiveTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_final_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_final_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_final_reward_min_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_cur_step = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_max_step = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_final_reward_limit_dt = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_final_reward_got = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_final_reward_got_cnt = sp.ReadInt32();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_new_final_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignFinalReward tmp = new CampaignFinalReward();
                    tmp.Decode(sp);
                    m_new_final_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_cur_score = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_info.Count);
                for (int i = 0; i != m_task_info.Count; ++i) {
                    m_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_final_reward.Count);
                for (int i = 0; i != m_final_reward.Count; ++i) {
                    m_final_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_final_reward_min_score);}
            if (sp.TryWrite(3)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(4)) {sp.Write(m_max_step);}
            if (sp.TryWrite(5)) {sp.Write(m_final_reward_limit_dt);}
            if (sp.TryWrite(6)) {sp.Write(m_final_reward_got);}
            if (sp.TryWrite(7)) {sp.Write(m_final_reward_got_cnt);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_new_final_reward.Count);
                for (int i = 0; i != m_new_final_reward.Count; ++i) {
                    m_new_final_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {sp.Write(m_cur_score);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventTaskData source) {
            m_task_info = source.m_task_info;
            m_final_reward = source.m_final_reward;
            m_final_reward_min_score = source.m_final_reward_min_score;
            m_cur_step = source.m_cur_step;
            m_max_step = source.m_max_step;
            m_final_reward_limit_dt = source.m_final_reward_limit_dt;
            m_final_reward_got = source.m_final_reward_got;
            m_final_reward_got_cnt = source.m_final_reward_got_cnt;
            m_new_final_reward = source.m_new_final_reward;
            m_cur_score = source.m_cur_score;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetPackageFreeRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2445,72 };
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
        public void CopyFrom(NewReturnEventGetPackageFreeRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
}
