using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class PvcInfo : NetworkMessage {
        public static int[] Id = { 3,1 };
        public static Ctrl VC;
        public Int16 m_ver;
        public Byte[] m_content;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ver = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_content = sp.ReadBytes2();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_ver);}
            if (sp.TryWrite(1)) {sp.WriteBytes2(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(PvcInfo source) {
            m_ver = source.m_ver;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class UserReqInfo : NetworkMessage {
        public static int[] Id = { 9,1 };
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
        public void CopyFrom(UserReqInfo source) {
            m_id = source.m_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class BuildingInfo : NetworkMessage {
        public static int[] Id = { 15,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_build_type;
        public Int16 m_build_status;
        public Int16 m_level;
        public Int16 m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_build_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_build_status = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_pos = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_build_type);}
            if (sp.TryWrite(2)) {sp.Write(m_build_status);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_pos);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingInfo source) {
            m_id = source.m_id;
            m_build_type = source.m_build_type;
            m_build_status = source.m_build_status;
            m_level = source.m_level;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class BuildProgNtfInfo : NetworkMessage {
        public static int[] Id = { 21,1 };
        public static Ctrl VC;
        public List<BuildingProgInfo> m_progs = new List<BuildingProgInfo>();

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
        public void CopyFrom(BuildProgNtfInfo source) {
            m_progs = source.m_progs;
        }
    }
    
    [Serializable]
    public partial class StyleInfo : NetworkMessage {
        public static int[] Id = { 27,1 };
        public static Ctrl VC;
        public Int16 m_jeep;
        public Int16 m_tank;
        public Int16 m_flight;
        public Int16 m_cannon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_jeep = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_tank = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_flight = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_cannon = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_jeep);}
            if (sp.TryWrite(1)) {sp.Write(m_tank);}
            if (sp.TryWrite(2)) {sp.Write(m_flight);}
            if (sp.TryWrite(3)) {sp.Write(m_cannon);}
            sp.EnEnd();
        }
        public void CopyFrom(StyleInfo source) {
            m_jeep = source.m_jeep;
            m_tank = source.m_tank;
            m_flight = source.m_flight;
            m_cannon = source.m_cannon;
        }
    }
    
    [Serializable]
    public partial class FightArmyJoin : NetworkMessage {
        public static int[] Id = { 33,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int64 m_kill;
        public Int64 m_repair;
        public List<ArmyInfo> m_army_list = new List<ArmyInfo>();
        public Int16 m_home_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_kill = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_repair = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_home_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_kill);}
            if (sp.TryWrite(4)) {sp.Write(m_repair);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army_list.Count);
                for (int i = 0; i != m_army_list.Count; ++i) {
                    m_army_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_home_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FightArmyJoin source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_kill = source.m_kill;
            m_repair = source.m_repair;
            m_army_list = source.m_army_list;
            m_home_server_id = source.m_home_server_id;
        }
    }
    
    [Serializable]
    public partial class FightReportV1 : NetworkMessage {
        public static int[] Id = { 39,1 };
        public static Ctrl VC;
        public Int32 m_fight_id;
        public Int64 m_fight_time;
        public Int16 m_fight_type;
        public Int16 m_server_id;
        public TilePos m_pos;
        public Int16 m_result;
        public List<CaptiveInfo> m_captive = new List<CaptiveInfo>();
        public FightUserV1 m_atker;
        public FightUserV1 m_defer;
        public List<FightRound> m_rounds = new List<FightRound>();
        public TilePos m_atk_pos;
        public Int16 m_mob_wave;
        public Int64 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fight_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_fight_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_fight_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_result = sp.ReadInt16();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_captive.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptiveInfo tmp = new CaptiveInfo();
                    tmp.Decode(sp);
                    m_captive.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                m_atker = new FightUserV1();
                m_atker.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                m_defer = new FightUserV1();
                m_defer.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rounds.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightRound tmp = new FightRound();
                    tmp.Decode(sp);
                    m_rounds.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_mob_wave = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fight_id);}
            if (sp.TryWrite(1)) {sp.Write(m_fight_time);}
            if (sp.TryWrite(2)) {sp.Write(m_fight_type);}
            if (sp.TryWrite(3)) {sp.Write(m_server_id);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_result);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_captive.Count);
                for (int i = 0; i != m_captive.Count; ++i) {
                    m_captive[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_atker.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_defer.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rounds.Count);
                for (int i = 0; i != m_rounds.Count; ++i) {
                    m_rounds[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {sp.Write(m_mob_wave);}
            if (sp.TryWrite(12)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(FightReportV1 source) {
            m_fight_id = source.m_fight_id;
            m_fight_time = source.m_fight_time;
            m_fight_type = source.m_fight_type;
            m_server_id = source.m_server_id;
            m_pos = source.m_pos;
            m_result = source.m_result;
            m_captive = source.m_captive;
            m_atker = source.m_atker;
            m_defer = source.m_defer;
            m_rounds = source.m_rounds;
            m_atk_pos = source.m_atk_pos;
            m_mob_wave = source.m_mob_wave;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class AbilityAction : NetworkMessage {
        public static int[] Id = { 45,1 };
        public static Ctrl VC;
        public Int16 m_action_id;
        public Boolean m_is_p1;
        public Int32 m_agent;
        public Int32 m_ability;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_agent = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_ability = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(2)) {sp.Write(m_agent);}
            if (sp.TryWrite(3)) {sp.Write(m_ability);}
            sp.EnEnd();
        }
        public void CopyFrom(AbilityAction source) {
            m_action_id = source.m_action_id;
            m_is_p1 = source.m_is_p1;
            m_agent = source.m_agent;
            m_ability = source.m_ability;
        }
    }
    
    [Serializable]
    public partial class ItemTileInfo : NetworkMessage {
        public static int[] Id = { 51,1 };
        public static Ctrl VC;
        public SByte m_source;
        public Boolean m_stat;
        public Int64 m_open_cost;
        public Int64 m_open_at;
        public Int64 m_gather_cost;
        public Int32 m_reward_item;
        public Int32 m_reward_item_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_source = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_stat = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_open_cost = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_open_at = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_gather_cost = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_reward_item = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_reward_item_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_source);}
            if (sp.TryWrite(1)) {sp.Write(m_stat);}
            if (sp.TryWrite(2)) {sp.Write(m_open_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_open_at);}
            if (sp.TryWrite(4)) {sp.Write(m_gather_cost);}
            if (sp.TryWrite(5)) {sp.Write(m_reward_item);}
            if (sp.TryWrite(6)) {sp.Write(m_reward_item_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(ItemTileInfo source) {
            m_source = source.m_source;
            m_stat = source.m_stat;
            m_open_cost = source.m_open_cost;
            m_open_at = source.m_open_at;
            m_gather_cost = source.m_gather_cost;
            m_reward_item = source.m_reward_item;
            m_reward_item_cnt = source.m_reward_item_cnt;
        }
    }
    
    [Serializable]
    public partial class CompressedLandInfo : NetworkMessage {
        public static int[] Id = { 57,1 };
        public static Ctrl VC;
        public List<AllianceSnapInfo> m_landalliance = new List<AllianceSnapInfo>();
        public List<CompressedLandData> m_land_data = new List<CompressedLandData>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_landalliance.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceSnapInfo tmp = new AllianceSnapInfo();
                    tmp.Decode(sp);
                    m_landalliance.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_land_data.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CompressedLandData tmp = new CompressedLandData();
                    tmp.Decode(sp);
                    m_land_data.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_landalliance.Count);
                for (int i = 0; i != m_landalliance.Count; ++i) {
                    m_landalliance[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_land_data.Count);
                for (int i = 0; i != m_land_data.Count; ++i) {
                    m_land_data[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(CompressedLandInfo source) {
            m_landalliance = source.m_landalliance;
            m_land_data = source.m_land_data;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class TilePos : NetworkMessage {
        public static int[] Id = { 63,1 };
        public static Ctrl VC;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(TilePos source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceBriefInfo : NetworkMessage {
        public static int[] Id = { 69,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int32 m_alliance_id;
        public Int64 m_force;
        public Int64 m_founder;
        public String m_founder_name = "";
        public Int64 m_owner;
        public String m_owner_name = "";
        public Int16 m_owner_server_id;
        public Int16 m_owner_icon;
        public String m_owner_avatar = "";
        public Int16 m_color;
        public Int16 m_logo;
        public String m_name = "";
        public String m_abbr = "";
        public String m_lang = "";
        public String m_desc = "";
        public String m_headline = "";
        public Boolean m_open;
        public Int16 m_member_cnt;
        public Int16 m_max_member_cnt;
        public Int16 m_gift_level;
        public Int64 m_gift_points;
        public Int64 m_gift_fortune_points;
        public Int64 m_land_count;
        public Int16 m_glory;
        public AllianceRecruitSnap m_recruit;
        public Boolean m_game_instructor;
        public Int64 m_power;
        public Int32 m_level;
        public AllianceIstanaSnap m_istana;
        public AllianceTaxInfo m_tax;
        public Int64 m_funds;
        public Int64 m_cash;
        public List<Int16> m_max_member_detail = new List<Int16>();
        public Int64 m_max_cash;
        public String m_desc_editor = "";
        public Int64 m_desc_edit_time;
        public AllianceTaxInfo m_kvk_tax;
        public Int64 m_kvk_cash;
        public Int64 m_kvk_max_cash;
        public Int16 m_owner_avatar_frame;
        public Int16 m_join_hq_level;
        public Int64 m_join_power;
        public SByte m_cur_as_board_difficulty;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_force = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_founder = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_founder_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(7)) {m_owner_server_id = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_owner_icon = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_owner_avatar = sp.ReadString();}
            if (sp.TryRead(10)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_name = sp.ReadString();}
            if (sp.TryRead(13)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(14)) {m_lang = sp.ReadString();}
            if (sp.TryRead(15)) {m_desc = sp.ReadString();}
            if (sp.TryRead(16)) {m_headline = sp.ReadString();}
            if (sp.TryRead(17)) {m_open = sp.ReadBoolean();}
            if (sp.TryRead(18)) {m_member_cnt = sp.ReadInt16();}
            if (sp.TryRead(19)) {m_max_member_cnt = sp.ReadInt16();}
            if (sp.TryRead(20)) {m_gift_level = sp.ReadInt16();}
            if (sp.TryRead(21)) {m_gift_points = sp.ReadInt64();}
            if (sp.TryRead(22)) {m_gift_fortune_points = sp.ReadInt64();}
            if (sp.TryRead(23)) {m_land_count = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_glory = sp.ReadInt16();}
            if (sp.TryRead(25)) {
                m_recruit = new AllianceRecruitSnap();
                m_recruit.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(26)) {m_game_instructor = sp.ReadBoolean();}
            if (sp.TryRead(27)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(28)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(29)) {
                m_istana = new AllianceIstanaSnap();
                m_istana.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(30)) {
                m_tax = new AllianceTaxInfo();
                m_tax.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(31)) {m_funds = sp.ReadInt64();}
            if (sp.TryRead(32)) {m_cash = sp.ReadInt64();}
            if (sp.TryRead(33)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_max_member_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_max_member_detail.Add(tmp);
                }
            }
            if (sp.TryRead(34)) {m_max_cash = sp.ReadInt64();}
            if (sp.TryRead(35)) {m_desc_editor = sp.ReadString();}
            if (sp.TryRead(36)) {m_desc_edit_time = sp.ReadInt64();}
            if (sp.TryRead(37)) {
                m_kvk_tax = new AllianceTaxInfo();
                m_kvk_tax.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(38)) {m_kvk_cash = sp.ReadInt64();}
            if (sp.TryRead(39)) {m_kvk_max_cash = sp.ReadInt64();}
            if (sp.TryRead(40)) {m_owner_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(41)) {m_join_hq_level = sp.ReadInt16();}
            if (sp.TryRead(42)) {m_join_power = sp.ReadInt64();}
            if (sp.TryRead(43)) {m_cur_as_board_difficulty = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(2)) {sp.Write(m_force);}
            if (sp.TryWrite(3)) {sp.Write(m_founder);}
            if (sp.TryWrite(4)) {sp.Write(m_founder_name);}
            if (sp.TryWrite(5)) {sp.Write(m_owner);}
            if (sp.TryWrite(6)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(7)) {sp.Write(m_owner_server_id);}
            if (sp.TryWrite(8)) {sp.Write(m_owner_icon);}
            if (sp.TryWrite(9)) {sp.Write(m_owner_avatar);}
            if (sp.TryWrite(10)) {sp.Write(m_color);}
            if (sp.TryWrite(11)) {sp.Write(m_logo);}
            if (sp.TryWrite(12)) {sp.Write(m_name);}
            if (sp.TryWrite(13)) {sp.Write(m_abbr);}
            if (sp.TryWrite(14)) {sp.Write(m_lang);}
            if (sp.TryWrite(15)) {sp.Write(m_desc);}
            if (sp.TryWrite(16)) {sp.Write(m_headline);}
            if (sp.TryWrite(17)) {sp.Write(m_open);}
            if (sp.TryWrite(18)) {sp.Write(m_member_cnt);}
            if (sp.TryWrite(19)) {sp.Write(m_max_member_cnt);}
            if (sp.TryWrite(20)) {sp.Write(m_gift_level);}
            if (sp.TryWrite(21)) {sp.Write(m_gift_points);}
            if (sp.TryWrite(22)) {sp.Write(m_gift_fortune_points);}
            if (sp.TryWrite(23)) {sp.Write(m_land_count);}
            if (sp.TryWrite(24)) {sp.Write(m_glory);}
            if (sp.TryWrite(25)) {int pos = sp.GetPos();sp.Skip(2); m_recruit.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(26)) {sp.Write(m_game_instructor);}
            if (sp.TryWrite(27)) {sp.Write(m_power);}
            if (sp.TryWrite(28)) {sp.Write(m_level);}
            if (sp.TryWrite(29)) {int pos = sp.GetPos();sp.Skip(2); m_istana.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(30)) {int pos = sp.GetPos();sp.Skip(2); m_tax.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(31)) {sp.Write(m_funds);}
            if (sp.TryWrite(32)) {sp.Write(m_cash);}
            if (sp.TryWrite(33)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_max_member_detail.Count);
                for (int i = 0; i != m_max_member_detail.Count; ++i) {
                    sp.Write(m_max_member_detail[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(34)) {sp.Write(m_max_cash);}
            if (sp.TryWrite(35)) {sp.Write(m_desc_editor);}
            if (sp.TryWrite(36)) {sp.Write(m_desc_edit_time);}
            if (sp.TryWrite(37)) {int pos = sp.GetPos();sp.Skip(2); m_kvk_tax.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(38)) {sp.Write(m_kvk_cash);}
            if (sp.TryWrite(39)) {sp.Write(m_kvk_max_cash);}
            if (sp.TryWrite(40)) {sp.Write(m_owner_avatar_frame);}
            if (sp.TryWrite(41)) {sp.Write(m_join_hq_level);}
            if (sp.TryWrite(42)) {sp.Write(m_join_power);}
            if (sp.TryWrite(43)) {sp.Write(m_cur_as_board_difficulty);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBriefInfo source) {
            m_server_id = source.m_server_id;
            m_alliance_id = source.m_alliance_id;
            m_force = source.m_force;
            m_founder = source.m_founder;
            m_founder_name = source.m_founder_name;
            m_owner = source.m_owner;
            m_owner_name = source.m_owner_name;
            m_owner_server_id = source.m_owner_server_id;
            m_owner_icon = source.m_owner_icon;
            m_owner_avatar = source.m_owner_avatar;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_lang = source.m_lang;
            m_desc = source.m_desc;
            m_headline = source.m_headline;
            m_open = source.m_open;
            m_member_cnt = source.m_member_cnt;
            m_max_member_cnt = source.m_max_member_cnt;
            m_gift_level = source.m_gift_level;
            m_gift_points = source.m_gift_points;
            m_gift_fortune_points = source.m_gift_fortune_points;
            m_land_count = source.m_land_count;
            m_glory = source.m_glory;
            m_recruit = source.m_recruit;
            m_game_instructor = source.m_game_instructor;
            m_power = source.m_power;
            m_level = source.m_level;
            m_istana = source.m_istana;
            m_tax = source.m_tax;
            m_funds = source.m_funds;
            m_cash = source.m_cash;
            m_max_member_detail = source.m_max_member_detail;
            m_max_cash = source.m_max_cash;
            m_desc_editor = source.m_desc_editor;
            m_desc_edit_time = source.m_desc_edit_time;
            m_kvk_tax = source.m_kvk_tax;
            m_kvk_cash = source.m_kvk_cash;
            m_kvk_max_cash = source.m_kvk_max_cash;
            m_owner_avatar_frame = source.m_owner_avatar_frame;
            m_join_hq_level = source.m_join_hq_level;
            m_join_power = source.m_join_power;
            m_cur_as_board_difficulty = source.m_cur_as_board_difficulty;
        }
    }
    
    [Serializable]
    public partial class ApplyJoinAllianceReqInfo : NetworkMessage {
        public static int[] Id = { 75,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_profile = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_profile = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_profile);}
            sp.EnEnd();
        }
        public void CopyFrom(ApplyJoinAllianceReqInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_profile = source.m_profile;
        }
    }
    
    [Serializable]
    public partial class ResApplyReportBaseInfo : NetworkMessage {
        public static int[] Id = { 81,1 };
        public static Ctrl VC;
        public String m_alliance_abbr = "";
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(1)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(1)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(ResApplyReportBaseInfo source) {
            m_alliance_abbr = source.m_alliance_abbr;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class ScoutReportBaseInfo : NetworkMessage {
        public static int[] Id = { 87,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_user_icon;
        public UserAllianceBrief m_alliance;
        public TilePos m_pos;
        public Boolean m_result;
        public Int16 m_scout_type;
        public Int16 m_fail_type;
        public TilePos m_atk_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_user_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_result = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_scout_type = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_fail_type = sp.ReadInt16();}
            if (sp.TryRead(8)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_result);}
            if (sp.TryWrite(6)) {sp.Write(m_scout_type);}
            if (sp.TryWrite(7)) {sp.Write(m_fail_type);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ScoutReportBaseInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_alliance = source.m_alliance;
            m_pos = source.m_pos;
            m_result = source.m_result;
            m_scout_type = source.m_scout_type;
            m_fail_type = source.m_fail_type;
            m_atk_pos = source.m_atk_pos;
        }
    }
    
    [Serializable]
    public partial class CollectResReportBaseInfo : NetworkMessage {
        public static int[] Id = { 93,1 };
        public static Ctrl VC;
        public TilePos m_pos;
        public SByte m_res_point_level;
        public SByte m_res_point_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_res_point_level = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_res_point_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_res_point_level);}
            if (sp.TryWrite(2)) {sp.Write(m_res_point_type);}
            sp.EnEnd();
        }
        public void CopyFrom(CollectResReportBaseInfo source) {
            m_pos = source.m_pos;
            m_res_point_level = source.m_res_point_level;
            m_res_point_type = source.m_res_point_type;
        }
    }
    
    [Serializable]
    public partial class MonumentScoutReportBaseInfo : NetworkMessage {
        public static int[] Id = { 99,1 };
        public static Ctrl VC;
        public Int64 m_captain;
        public Int16 m_captain_icon;
        public String m_captain_name = "";
        public AllianceSnapInfo m_alliance;
        public ServerTilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_captain = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_captain_icon = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_captain_name = sp.ReadString();}
            if (sp.TryRead(3)) {
                m_alliance = new AllianceSnapInfo();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_captain);}
            if (sp.TryWrite(1)) {sp.Write(m_captain_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_captain_name);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentScoutReportBaseInfo source) {
            m_captain = source.m_captain;
            m_captain_icon = source.m_captain_icon;
            m_captain_name = source.m_captain_name;
            m_alliance = source.m_alliance;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class RebelSummaryReportMemberInfo : NetworkMessage {
        public static int[] Id = { 105,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int64 m_user_id;
        public Int16 m_user_icon;
        public String m_user_name = "";
        public String m_alliance_abbr = "";
        public Int64 m_hp_max;
        public Int64 m_hp_killed;
        public List<Item> m_items = new List<Item>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_user_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(5)) {m_hp_max = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_hp_killed = sp.ReadInt64();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_user_name);}
            if (sp.TryWrite(4)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(5)) {sp.Write(m_hp_max);}
            if (sp.TryWrite(6)) {sp.Write(m_hp_killed);}
            if (sp.TryWrite(7)) {
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
        public void CopyFrom(RebelSummaryReportMemberInfo source) {
            m_type = source.m_type;
            m_user_id = source.m_user_id;
            m_user_icon = source.m_user_icon;
            m_user_name = source.m_user_name;
            m_alliance_abbr = source.m_alliance_abbr;
            m_hp_max = source.m_hp_max;
            m_hp_killed = source.m_hp_killed;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class PlayerMailDetailInfo : NetworkMessage {
        public static int[] Id = { 111,1 };
        public static Ctrl VC;
        public PlayerMailBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new PlayerMailBaseInfo();
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
        public void CopyFrom(PlayerMailDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class BeScoutReportDetailInfo : NetworkMessage {
        public static int[] Id = { 117,1 };
        public static Ctrl VC;
        public ScoutReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ScoutReportBaseInfo();
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
        public void CopyFrom(BeScoutReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class ReforceReportDetailInfo : NetworkMessage {
        public static int[] Id = { 123,1 };
        public static Ctrl VC;
        public ReforceReportBaseInfo m_base_info;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ReforceReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
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
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ReforceReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_troops = source.m_troops;
        }
    }
    
    [Serializable]
    public partial class MbRewardReportDetailInfo : NetworkMessage {
        public static int[] Id = { 129,1 };
        public static Ctrl VC;
        public MbRewardReportBaseInfo m_base_info;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new MbRewardReportBaseInfo();
                m_base_info.Decode(sp);
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
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
        public void CopyFrom(MbRewardReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class GetResearchReqInfo : NetworkMessage {
        public static int[] Id = { 135,1 };
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
        public void CopyFrom(GetResearchReqInfo source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class ResearchCancelInfo : NetworkMessage {
        public static int[] Id = { 141,1 };
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
        public void CopyFrom(ResearchCancelInfo source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class BeginDailyQuestReqInfo : NetworkMessage {
        public static int[] Id = { 147,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_daily_or_alliance;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_daily_or_alliance = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_daily_or_alliance);}
            sp.EnEnd();
        }
        public void CopyFrom(BeginDailyQuestReqInfo source) {
            m_id = source.m_id;
            m_daily_or_alliance = source.m_daily_or_alliance;
        }
    }
    
    [Serializable]
    public partial class QuestListReqInfo : NetworkMessage {
        public static int[] Id = { 153,1 };
        public static Ctrl VC;
        public Int32 m_begin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_begin_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_begin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestListReqInfo source) {
            m_begin_id = source.m_begin_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMemberAckInfo : NetworkMessage {
        public static int[] Id = { 159,1 };
        public static Ctrl VC;
        public AllianceBriefInfo m_brief;
        public List<AllianceMember> m_members = new List<AllianceMember>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_brief = new AllianceBriefInfo();
                m_brief.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_members.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMember tmp = new AllianceMember();
                    tmp.Decode(sp);
                    m_members.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_brief.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
        public void CopyFrom(AllianceMemberAckInfo source) {
            m_brief = source.m_brief;
            m_members = source.m_members;
        }
    }
    
    [Serializable]
    public partial class RallyReqInfo : NetworkMessage {
        public static int[] Id = { 165,1 };
        public static Ctrl VC;
        public Int64 m_prepare_time;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Int16 m_hero_id;
        public List<Int16> m_agent = new List<Int16>();
        public MapUnitId m_target;
        public Int16 m_subtype;
        public Int64 m_map_guid;
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;
        public Int16 m_rally_troop_type;
        public Boolean m_auto_depart;
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prepare_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                m_target = new MapUnitId();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_rally_troop_type = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_auto_depart = sp.ReadBoolean();}
            if (sp.TryRead(11)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prepare_time);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_subtype);}
            if (sp.TryWrite(6)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(7)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(8)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(9)) {sp.Write(m_rally_troop_type);}
            if (sp.TryWrite(10)) {sp.Write(m_auto_depart);}
            if (sp.TryWrite(11)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(12)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RallyReqInfo source) {
            m_prepare_time = source.m_prepare_time;
            m_troops = source.m_troops;
            m_hero_id = source.m_hero_id;
            m_agent = source.m_agent;
            m_target = source.m_target;
            m_subtype = source.m_subtype;
            m_map_guid = source.m_map_guid;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
            m_rally_troop_type = source.m_rally_troop_type;
            m_auto_depart = source.m_auto_depart;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class UserItems : NetworkMessage {
        public static int[] Id = { 171,1 };
        public static Ctrl VC;
        public List<Item> m_items = new List<Item>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
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
        public void CopyFrom(UserItems source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class Rankinfo : NetworkMessage {
        public static int[] Id = { 177,1 };
        public static Ctrl VC;
        public Int32 m_rank;
        public String m_alliance = "";
        public String m_name = "";
        public Int64 m_power;
        public Int16 m_server_id;
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_alliance_logo;
        public Int16 m_alliance_color;
        public Int64 m_id;
        public Int16 m_vip_level;
        public Int16 m_favor_agent;
        public Int32 m_skin;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_alliance_logo = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_alliance_color = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_vip_level = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_favor_agent = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_skin = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_server_id);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(8)) {sp.Write(m_alliance_logo);}
            if (sp.TryWrite(9)) {sp.Write(m_alliance_color);}
            if (sp.TryWrite(10)) {sp.Write(m_id);}
            if (sp.TryWrite(11)) {sp.Write(m_vip_level);}
            if (sp.TryWrite(12)) {sp.Write(m_favor_agent);}
            if (sp.TryWrite(13)) {sp.Write(m_skin);}
            sp.EnEnd();
        }
        public void CopyFrom(Rankinfo source) {
            m_rank = source.m_rank;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_power = source.m_power;
            m_server_id = source.m_server_id;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_alliance_logo = source.m_alliance_logo;
            m_alliance_color = source.m_alliance_color;
            m_id = source.m_id;
            m_vip_level = source.m_vip_level;
            m_favor_agent = source.m_favor_agent;
            m_skin = source.m_skin;
        }
    }
    
    [Serializable]
    public partial class AllianceHelpInfo : NetworkMessage {
        public static int[] Id = { 183,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_help_id;
        public Int16 m_prog_type;
        public Int16 m_bstatus;
        public Int64 m_level;
        public Int16 m_times;
        public Int16 m_max_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_help_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_prog_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_bstatus = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_level = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_times = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_max_times = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_help_id);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_type);}
            if (sp.TryWrite(3)) {sp.Write(m_bstatus);}
            if (sp.TryWrite(4)) {sp.Write(m_level);}
            if (sp.TryWrite(5)) {sp.Write(m_times);}
            if (sp.TryWrite(6)) {sp.Write(m_max_times);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceHelpInfo source) {
            m_user_id = source.m_user_id;
            m_help_id = source.m_help_id;
            m_prog_type = source.m_prog_type;
            m_bstatus = source.m_bstatus;
            m_level = source.m_level;
            m_times = source.m_times;
            m_max_times = source.m_max_times;
        }
    }
    
    [Serializable]
    public partial class UserRanklistReq : NetworkMessage {
        public static int[] Id = { 189,1 };
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
        public void CopyFrom(UserRanklistReq source) {
            m_type = source.m_type;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class DetailRanklistInfo : NetworkMessage {
        public static int[] Id = { 195,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public List<Rankinfo> m_infos = new List<Rankinfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(DetailRanklistInfo source) {
            m_type = source.m_type;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class BuildingFreeCheckAck : NetworkMessage {
        public static int[] Id = { 201,1 };
        public static Ctrl VC;
        public Int16 m_prog_id;
        public Boolean m_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prog_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_flag = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prog_id);}
            if (sp.TryWrite(1)) {sp.Write(m_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingFreeCheckAck source) {
            m_prog_id = source.m_prog_id;
            m_flag = source.m_flag;
        }
    }
    
    [Serializable]
    public partial class BeScoutInfo : NetworkMessage {
        public static int[] Id = { 207,1 };
        public static Ctrl VC;
        public Int16 m_radar_levle;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_scout_user_id;
        public String m_scout_user_name = "";
        public UserAllianceBrief m_scout_user_alliance;
        public Int16 m_scout_icon;
        public String m_scout_avatar = "";
        public Int16 m_scout_avatar_frame;
        public TilePos m_scout_pos;
        public MapUnitId m_unit_id;
        public Int64 m_scout_march_id;
        public Int64 m_target_user_id;
        public String m_target_user_name = "";
        public Int16 m_target_icon;
        public String m_target_avatar = "";
        public Int16 m_target_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_radar_levle = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_scout_user_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_scout_user_name = sp.ReadString();}
            if (sp.TryRead(5)) {
                m_scout_user_alliance = new UserAllianceBrief();
                m_scout_user_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_scout_icon = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_scout_avatar = sp.ReadString();}
            if (sp.TryRead(8)) {m_scout_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(9)) {
                m_scout_pos = new TilePos();
                m_scout_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                m_unit_id = new MapUnitId();
                m_unit_id.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_scout_march_id = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_target_user_id = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_target_user_name = sp.ReadString();}
            if (sp.TryRead(14)) {m_target_icon = sp.ReadInt16();}
            if (sp.TryRead(15)) {m_target_avatar = sp.ReadString();}
            if (sp.TryRead(16)) {m_target_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_radar_levle);}
            if (sp.TryWrite(1)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(3)) {sp.Write(m_scout_user_id);}
            if (sp.TryWrite(4)) {sp.Write(m_scout_user_name);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_scout_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_scout_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_scout_avatar);}
            if (sp.TryWrite(8)) {sp.Write(m_scout_avatar_frame);}
            if (sp.TryWrite(9)) {int pos = sp.GetPos();sp.Skip(2); m_scout_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_unit_id.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {sp.Write(m_scout_march_id);}
            if (sp.TryWrite(12)) {sp.Write(m_target_user_id);}
            if (sp.TryWrite(13)) {sp.Write(m_target_user_name);}
            if (sp.TryWrite(14)) {sp.Write(m_target_icon);}
            if (sp.TryWrite(15)) {sp.Write(m_target_avatar);}
            if (sp.TryWrite(16)) {sp.Write(m_target_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(BeScoutInfo source) {
            m_radar_levle = source.m_radar_levle;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_scout_user_id = source.m_scout_user_id;
            m_scout_user_name = source.m_scout_user_name;
            m_scout_user_alliance = source.m_scout_user_alliance;
            m_scout_icon = source.m_scout_icon;
            m_scout_avatar = source.m_scout_avatar;
            m_scout_avatar_frame = source.m_scout_avatar_frame;
            m_scout_pos = source.m_scout_pos;
            m_unit_id = source.m_unit_id;
            m_scout_march_id = source.m_scout_march_id;
            m_target_user_id = source.m_target_user_id;
            m_target_user_name = source.m_target_user_name;
            m_target_icon = source.m_target_icon;
            m_target_avatar = source.m_target_avatar;
            m_target_avatar_frame = source.m_target_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ClientSaveInfo : NetworkMessage {
        public static int[] Id = { 213,1 };
        public static Ctrl VC;
        public String m_data = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_data = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientSaveInfo source) {
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class ServerTilePos : NetworkMessage {
        public static int[] Id = { 219,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public TilePos m_pos;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
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
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerTilePos source) {
            m_server_id = source.m_server_id;
            m_pos = source.m_pos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ChangeAllianceOwnerNtfInfo : NetworkMessage {
        public static int[] Id = { 225,1 };
        public static Ctrl VC;
        public Int64 m_owner_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_owner_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_owner_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeAllianceOwnerNtfInfo source) {
            m_owner_id = source.m_owner_id;
        }
    }
    
    [Serializable]
    public partial class ListInviteInfo : NetworkMessage {
        public static int[] Id = { 231,1 };
        public static Ctrl VC;
        public List<AllianceInviteNtfInfo> m_infos = new List<AllianceInviteNtfInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceInviteNtfInfo tmp = new AllianceInviteNtfInfo();
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
        public void CopyFrom(ListInviteInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class AllianceResHistoryInfo : NetworkMessage {
        public static int[] Id = { 237,1 };
        public static Ctrl VC;
        public List<ResHistoryInfo> m_histories = new List<ResHistoryInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_histories.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResHistoryInfo tmp = new ResHistoryInfo();
                    tmp.Decode(sp);
                    m_histories.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_histories.Count);
                for (int i = 0; i != m_histories.Count; ++i) {
                    m_histories[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResHistoryInfo source) {
            m_histories = source.m_histories;
        }
    }
    
    [Serializable]
    public partial class KtilePos : NetworkMessage {
        public static int[] Id = { 243,1 };
        public static Ctrl VC;
        public Int16 m_k;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_k = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_k);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(KtilePos source) {
            m_k = source.m_k;
            m_x = source.m_x;
            m_y = source.m_y;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ListDominionMapInfo : NetworkMessage {
        public static int[] Id = { 249,1 };
        public static Ctrl VC;
        public List<DominionMapInfo> m_infos = new List<DominionMapInfo>();
        public DominionMapInfo m_self_alliance;
        public Int16 m_amount;
        public Int64 m_expired;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DominionMapInfo tmp = new DominionMapInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_self_alliance = new DominionMapInfo();
                m_self_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_amount = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_expired = sp.ReadInt64();}
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
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_amount);}
            if (sp.TryWrite(3)) {sp.Write(m_expired);}
            sp.EnEnd();
        }
        public void CopyFrom(ListDominionMapInfo source) {
            m_infos = source.m_infos;
            m_self_alliance = source.m_self_alliance;
            m_amount = source.m_amount;
            m_expired = source.m_expired;
        }
    }
    
    [Serializable]
    public partial class SearchNameReq : NetworkMessage {
        public static int[] Id = { 255,1 };
        public static Ctrl VC;
        public String m_prefix = "";
        public Int16 m_type;
        public Int16 m_mode;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prefix = sp.ReadString();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_mode = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prefix);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_mode);}
            sp.EnEnd();
        }
        public void CopyFrom(SearchNameReq source) {
            m_prefix = source.m_prefix;
            m_type = source.m_type;
            m_mode = source.m_mode;
        }
    }
    
    [Serializable]
    public partial class RallyCompleteInfo : NetworkMessage {
        public static int[] Id = { 261,1 };
        public static Ctrl VC;
        public Int64 m_atk_user;
        public Int64 m_def_user;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_atk_user = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_def_user = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_atk_user);}
            if (sp.TryWrite(1)) {sp.Write(m_def_user);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(RallyCompleteInfo source) {
            m_atk_user = source.m_atk_user;
            m_def_user = source.m_def_user;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ListAllianceCommentReq : NetworkMessage {
        public static int[] Id = { 267,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceCommentReq source) {
            m_alliance_id = source.m_alliance_id;
        }
    }
    
    [Serializable]
    public partial class ListAllianceAuthorityReq : NetworkMessage {
        public static int[] Id = { 273,1 };
        public static Ctrl VC;
        public List<Int16> m_ranks = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ranks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_ranks.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ranks.Count);
                for (int i = 0; i != m_ranks.Count; ++i) {
                    sp.Write(m_ranks[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceAuthorityReq source) {
            m_ranks = source.m_ranks;
        }
    }
    
    [Serializable]
    public partial class UpdateAllianceMemberTitleInfo : NetworkMessage {
        public static int[] Id = { 279,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_title;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_title = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdateAllianceMemberTitleInfo source) {
            m_user_id = source.m_user_id;
            m_title = source.m_title;
        }
    }
    
    [Serializable]
    public partial class DelAllianceJoinApplyInfo : NetworkMessage {
        public static int[] Id = { 285,1 };
        public static Ctrl VC;
        public List<Int64> m_users = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_users.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_users.Count);
                for (int i = 0; i != m_users.Count; ++i) {
                    sp.Write(m_users[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DelAllianceJoinApplyInfo source) {
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class OpenAllianceGiftResult : NetworkMessage {
        public static int[] Id = { 291,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_id);}
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
        public void CopyFrom(OpenAllianceGiftResult source) {
            m_id = source.m_id;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class IapListInfo : NetworkMessage {
        public static int[] Id = { 297,1 };
        public static Ctrl VC;
        public List<IapPackageInfo> m_list = new List<IapPackageInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapPackageInfo tmp = new IapPackageInfo();
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
        public void CopyFrom(IapListInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class MapmarkListInfo : NetworkMessage {
        public static int[] Id = { 303,1 };
        public static Ctrl VC;
        public List<MapmarkInfo> m_marks = new List<MapmarkInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_marks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapmarkInfo tmp = new MapmarkInfo();
                    tmp.Decode(sp);
                    m_marks.Add(tmp);
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
                sp.Write((UInt16)m_marks.Count);
                for (int i = 0; i != m_marks.Count; ++i) {
                    m_marks[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MapmarkListInfo source) {
            m_marks = source.m_marks;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class UserStatisticsReqInfo : NetworkMessage {
        public static int[] Id = { 309,1 };
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
        public void CopyFrom(UserStatisticsReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class ClientDataInfo : NetworkMessage {
        public static int[] Id = { 315,1 };
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
        public void CopyFrom(ClientDataInfo source) {
            m_key = source.m_key;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class ScreenRefreshInfo : NetworkMessage {
        public static int[] Id = { 321,1 };
        public static Ctrl VC;
        public String m_iap_theme = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_theme = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_theme);}
            sp.EnEnd();
        }
        public void CopyFrom(ScreenRefreshInfo source) {
            m_iap_theme = source.m_iap_theme;
        }
    }
    
    [Serializable]
    public partial class NewUserGiftInfo : NetworkMessage {
        public static int[] Id = { 327,1 };
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
        public void CopyFrom(NewUserGiftInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class DailyEventUpdateNtf : NetworkMessage {
        public static int[] Id = { 333,1 };
        public static Ctrl VC;
        public List<DailyEventNode> m_events = new List<DailyEventNode>();
        public Int64 m_next_update_time;
        public Int16 m_score;
        public Int16 m_option;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_events.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailyEventNode tmp = new DailyEventNode();
                    tmp.Decode(sp);
                    m_events.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_next_update_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_option = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_events.Count);
                for (int i = 0; i != m_events.Count; ++i) {
                    m_events[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_next_update_time);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_option);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyEventUpdateNtf source) {
            m_events = source.m_events;
            m_next_update_time = source.m_next_update_time;
            m_score = source.m_score;
            m_option = source.m_option;
        }
    }
    
    [Serializable]
    public partial class InvitationModeInfo : NetworkMessage {
        public static int[] Id = { 339,1 };
        public static Ctrl VC;
        public Boolean m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(InvitationModeInfo source) {
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class TitleInfo : NetworkMessage {
        public static int[] Id = { 345,1 };
        public static Ctrl VC;
        public Int16 m_title_id;
        public Int16 m_title_rank;
        public Int64 m_user_id;
        public Int16 m_tax_percent;
        public String m_name = "";
        public Int16 m_icon;
        public UserAllianceBrief m_alliance;
        public Int16 m_server_id;
        public List<Int16> m_privileges = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_title_rank = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_tax_percent = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_privileges.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_privileges.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            if (sp.TryWrite(3)) {sp.Write(m_tax_percent);}
            if (sp.TryWrite(4)) {sp.Write(m_name);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_server_id);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_privileges.Count);
                for (int i = 0; i != m_privileges.Count; ++i) {
                    sp.Write(m_privileges[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TitleInfo source) {
            m_title_id = source.m_title_id;
            m_title_rank = source.m_title_rank;
            m_user_id = source.m_user_id;
            m_tax_percent = source.m_tax_percent;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_alliance = source.m_alliance;
            m_server_id = source.m_server_id;
            m_privileges = source.m_privileges;
        }
    }
    
    [Serializable]
    public partial class NuclearStrileDetailInfo : NetworkMessage {
        public static int[] Id = { 351,1 };
        public static Ctrl VC;
        public NuclearStrileBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new NuclearStrileBaseInfo();
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
        public void CopyFrom(NuclearStrileDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class PrizeInfo : NetworkMessage {
        public static int[] Id = { 357,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_type;
        public Int64 m_create_time;
        public PrizeDetailInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_create_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                m_info = new PrizeDetailInfo();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_create_time);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(PrizeInfo source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_create_time = source.m_create_time;
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class DiamondMineFriendInfo : NetworkMessage {
        public static int[] Id = { 363,1 };
        public static Ctrl VC;
        public List<DiamondMineBindInfo> m_list = new List<DiamondMineBindInfo>();
        public Int32 m_cur_cnt;
        public Int32 m_limit_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DiamondMineBindInfo tmp = new DiamondMineBindInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_limit_cnt = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_cur_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_limit_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondMineFriendInfo source) {
            m_list = source.m_list;
            m_cur_cnt = source.m_cur_cnt;
            m_limit_cnt = source.m_limit_cnt;
        }
    }
    
    [Serializable]
    public partial class GroupHeroInfo : NetworkMessage {
        public static int[] Id = { 369,1 };
        public static Ctrl VC;
        public Int16 m_hero_id;
        public Int16 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_hero_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_hero_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(GroupHeroInfo source) {
            m_hero_id = source.m_hero_id;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class AllianceHivePosInfo : NetworkMessage {
        public static int[] Id = { 375,1 };
        public static Ctrl VC;
        public ServerTilePos m_leader_pos;
        public ServerTilePos m_pos;
        public Boolean m_is_land;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_leader_pos = new ServerTilePos();
                m_leader_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_is_land = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_leader_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_is_land);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceHivePosInfo source) {
            m_leader_pos = source.m_leader_pos;
            m_pos = source.m_pos;
            m_is_land = source.m_is_land;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryInfo : NetworkMessage {
        public static int[] Id = { 381,1 };
        public static Ctrl VC;
        public Int16 m_rank;
        public Int64 m_amount;
        public Boolean m_assigned;
        public List<AllianceMemberSalaryInfo> m_users = new List<AllianceMemberSalaryInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_assigned = sp.ReadBoolean();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMemberSalaryInfo tmp = new AllianceMemberSalaryInfo();
                    tmp.Decode(sp);
                    m_users.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            if (sp.TryWrite(2)) {sp.Write(m_assigned);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_users.Count);
                for (int i = 0; i != m_users.Count; ++i) {
                    m_users[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSalaryInfo source) {
            m_rank = source.m_rank;
            m_amount = source.m_amount;
            m_assigned = source.m_assigned;
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class RepairTroopInfo : NetworkMessage {
        public static int[] Id = { 387,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_army_list = new List<ArmyInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army_list.Add(tmp);
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
                sp.Write((UInt16)m_army_list.Count);
                for (int i = 0; i != m_army_list.Count; ++i) {
                    m_army_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(RepairTroopInfo source) {
            m_army_list = source.m_army_list;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class IapPriceReqInfo : NetworkMessage {
        public static int[] Id = { 393,1 };
        public static Ctrl VC;
        public Int32 m_iap_type;
        public SByte m_currency_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_currency_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(1)) {sp.Write(m_currency_type);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPriceReqInfo source) {
            m_iap_type = source.m_iap_type;
            m_currency_type = source.m_currency_type;
        }
    }
    
    [Serializable]
    public partial class OfficerId : NetworkMessage {
        public static int[] Id = { 399,1 };
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
        public void CopyFrom(OfficerId source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class RoleInfo : NetworkMessage {
        public static int[] Id = { 405,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_server_id;
        public String m_user_name = "";
        public Int16 m_icon;
        public Int64 m_power;
        public UserAllianceBrief m_alliance;
        public String m_avatar = "";
        public Boolean m_forbidden;
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {m_forbidden = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_name);}
            if (sp.TryWrite(3)) {sp.Write(m_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_power);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {sp.Write(m_forbidden);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(RoleInfo source) {
            m_user_id = source.m_user_id;
            m_server_id = source.m_server_id;
            m_user_name = source.m_user_name;
            m_icon = source.m_icon;
            m_power = source.m_power;
            m_alliance = source.m_alliance;
            m_avatar = source.m_avatar;
            m_forbidden = source.m_forbidden;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class BiddingInfo : NetworkMessage {
        public static int[] Id = { 411,1 };
        public static Ctrl VC;
        public Int32 m_founds;
        public Int16 m_expiry_hour;
        public Int16 m_remain_hour;
        public Int64 m_create_time;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_founds = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_expiry_hour = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_remain_hour = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_create_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_founds);}
            if (sp.TryWrite(1)) {sp.Write(m_expiry_hour);}
            if (sp.TryWrite(2)) {sp.Write(m_remain_hour);}
            if (sp.TryWrite(3)) {sp.Write(m_create_time);}
            if (sp.TryWrite(4)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(BiddingInfo source) {
            m_founds = source.m_founds;
            m_expiry_hour = source.m_expiry_hour;
            m_remain_hour = source.m_remain_hour;
            m_create_time = source.m_create_time;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class RegionMsgReqInfo : NetworkMessage {
        public static int[] Id = { 417,1 };
        public static Ctrl VC;
        public String m_content = "";
        public SByte m_lang;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_content = sp.ReadString();}
            if (sp.TryRead(1)) {m_lang = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_content);}
            if (sp.TryWrite(1)) {sp.Write(m_lang);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionMsgReqInfo source) {
            m_content = source.m_content;
            m_lang = source.m_lang;
        }
    }
    
    [Serializable]
    public partial class LastAllianceCommentInfo : NetworkMessage {
        public static int[] Id = { 423,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int64 m_post_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_post_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_post_time);}
            sp.EnEnd();
        }
        public void CopyFrom(LastAllianceCommentInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_post_time = source.m_post_time;
        }
    }
    
    [Serializable]
    public partial class AnnouceInfo : NetworkMessage {
        public static int[] Id = { 429,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Byte m_type;
        public String m_icon = "";
        public String m_title = "";
        public String m_content = "";
        public Boolean m_popup;
        public SByte m_priority;
        public Int64 m_star_time;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadByte();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_content = sp.ReadString();}
            if (sp.TryRead(5)) {m_popup = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_priority = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_star_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_content);}
            if (sp.TryWrite(5)) {sp.Write(m_popup);}
            if (sp.TryWrite(6)) {sp.Write(m_priority);}
            if (sp.TryWrite(7)) {sp.Write(m_star_time);}
            if (sp.TryWrite(8)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AnnouceInfo source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_icon = source.m_icon;
            m_title = source.m_title;
            m_content = source.m_content;
            m_popup = source.m_popup;
            m_priority = source.m_priority;
            m_star_time = source.m_star_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class WarLicenseInfo : NetworkMessage {
        public static int[] Id = { 435,1 };
        public static Ctrl VC;
        public Int16 m_location_server_id;
        public Int64 m_start_time;
        public Int64 m_end_time;
        public Int16 m_home_server_id;
        public Int16 m_state;
        public Int16 m_aim;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_location_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_state = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_aim = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_location_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_start_time);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            if (sp.TryWrite(3)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(4)) {sp.Write(m_state);}
            if (sp.TryWrite(5)) {sp.Write(m_aim);}
            sp.EnEnd();
        }
        public void CopyFrom(WarLicenseInfo source) {
            m_location_server_id = source.m_location_server_id;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_home_server_id = source.m_home_server_id;
            m_state = source.m_state;
            m_aim = source.m_aim;
        }
    }
    
    [Serializable]
    public partial class PveCost : NetworkMessage {
        public static int[] Id = { 441,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_level;
        public Int32 m_atk_cost;
        public Int32 m_rally_cost;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_atk_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_rally_cost = sp.ReadInt32();}
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_atk_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_rally_cost);}
            if (sp.TryWrite(4)) {
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
        public void CopyFrom(PveCost source) {
            m_id = source.m_id;
            m_level = source.m_level;
            m_atk_cost = source.m_atk_cost;
            m_rally_cost = source.m_rally_cost;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class HuodongRewardInfo : NetworkMessage {
        public static int[] Id = { 447,1 };
        public static Ctrl VC;
        public Int32 m_type;
        public Int32 m_dan;
        public Int32 m_grade;
        public Int64 m_score;
        public SByte m_stat;
        public Int16 m_max_reward_cnt;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_dan = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_grade = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_max_reward_cnt = sp.ReadInt16();}
            if (sp.TryRead(6)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_dan);}
            if (sp.TryWrite(2)) {sp.Write(m_grade);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_stat);}
            if (sp.TryWrite(5)) {sp.Write(m_max_reward_cnt);}
            if (sp.TryWrite(6)) {
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
        public void CopyFrom(HuodongRewardInfo source) {
            m_type = source.m_type;
            m_dan = source.m_dan;
            m_grade = source.m_grade;
            m_score = source.m_score;
            m_stat = source.m_stat;
            m_max_reward_cnt = source.m_max_reward_cnt;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class MemberContribute : NetworkMessage {
        public static int[] Id = { 453,1 };
        public static Ctrl VC;
        public String m_name = "";
        public Int64 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(MemberContribute source) {
            m_name = source.m_name;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class SuperResDestroyReportDetailInfo : NetworkMessage {
        public static int[] Id = { 459,1 };
        public static Ctrl VC;
        public SuperResDestroyReportBaseInfo m_base_info;
        public List<SuperResGatherInfo> m_gather_list = new List<SuperResGatherInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new SuperResDestroyReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gather_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SuperResGatherInfo tmp = new SuperResGatherInfo();
                    tmp.Decode(sp);
                    m_gather_list.Add(tmp);
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
                sp.Write((UInt16)m_gather_list.Count);
                for (int i = 0; i != m_gather_list.Count; ++i) {
                    m_gather_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SuperResDestroyReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_gather_list = source.m_gather_list;
        }
    }
    
    [Serializable]
    public partial class ContactInfoV1 : NetworkMessage {
        public static int[] Id = { 465,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_alliance_name = "";
        public Int32 m_alliance_rank;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int32 m_user_icon;
        public String m_user_avatar = "";
        public Int16 m_user_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_user_icon = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_user_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {m_user_avatar_frame = sp.ReadInt16();}
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
            if (sp.TryWrite(6)) {sp.Write(m_user_avatar);}
            if (sp.TryWrite(7)) {sp.Write(m_user_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(ContactInfoV1 source) {
            m_alliance_id = source.m_alliance_id;
            m_alliance_name = source.m_alliance_name;
            m_alliance_rank = source.m_alliance_rank;
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_user_avatar = source.m_user_avatar;
            m_user_avatar_frame = source.m_user_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class AllianceDonateRewards : NetworkMessage {
        public static int[] Id = { 471,1 };
        public static Ctrl VC;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
        public void CopyFrom(AllianceDonateRewards source) {
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class TicketStatus : NetworkMessage {
        public static int[] Id = { 477,1 };
        public static Ctrl VC;
        public SByte m_idx;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_idx = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_idx);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(TicketStatus source) {
            m_idx = source.m_idx;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class ScrollOfficerUpstar : NetworkMessage {
        public static int[] Id = { 483,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_officer_id;
        public SByte m_star;

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
            if (sp.TryRead(4)) {m_officer_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_star = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_officer_id);}
            if (sp.TryWrite(5)) {sp.Write(m_star);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollOfficerUpstar source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_officer_id = source.m_officer_id;
            m_star = source.m_star;
        }
    }
    
    [Serializable]
    public partial class LangLikeRankMemberInfo : NetworkMessage {
        public static int[] Id = { 489,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int32 m_lang_rank;
        public Int16 m_alliance_rank;
        public String m_alliance_abbr = "";
        public Int32 m_like_num;
        public String m_avatar = "";
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_lang_rank = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_alliance_rank = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(6)) {m_like_num = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(8)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_lang_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_alliance_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(6)) {sp.Write(m_like_num);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(LangLikeRankMemberInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_lang_rank = source.m_lang_rank;
            m_alliance_rank = source.m_alliance_rank;
            m_alliance_abbr = source.m_alliance_abbr;
            m_like_num = source.m_like_num;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ExchangeResearchPointInfoAckInfo : NetworkMessage {
        public static int[] Id = { 495,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public SByte m_exchange_type;
        public Int16 m_times;
        public Int32 m_common_count;
        public Int32 m_special_count;
        public AllianceResearchBaseInfo m_detail_info;
        public AsSkillInfo m_skill_info;
        public Int16 m_target_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_exchange_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_times = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_common_count = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_special_count = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                m_detail_info = new AllianceResearchBaseInfo();
                m_detail_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                m_skill_info = new AsSkillInfo();
                m_skill_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_target_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_exchange_type);}
            if (sp.TryWrite(2)) {sp.Write(m_times);}
            if (sp.TryWrite(3)) {sp.Write(m_common_count);}
            if (sp.TryWrite(4)) {sp.Write(m_special_count);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_detail_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_skill_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_target_type);}
            sp.EnEnd();
        }
        public void CopyFrom(ExchangeResearchPointInfoAckInfo source) {
            m_type = source.m_type;
            m_exchange_type = source.m_exchange_type;
            m_times = source.m_times;
            m_common_count = source.m_common_count;
            m_special_count = source.m_special_count;
            m_detail_info = source.m_detail_info;
            m_skill_info = source.m_skill_info;
            m_target_type = source.m_target_type;
        }
    }
    
    [Serializable]
    public partial class GetAllianceResearchListAckInfo : NetworkMessage {
        public static int[] Id = { 501,1 };
        public static Ctrl VC;
        public Int16 m_suggested;
        public Int32 m_user_daily_point;
        public List<AllianceResearchBaseInfo> m_list_info = new List<AllianceResearchBaseInfo>();
        public Int16 m_suggested_target_type;
        public List<AsSkillInfo> m_skill_list = new List<AsSkillInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_suggested = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_user_daily_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceResearchBaseInfo tmp = new AllianceResearchBaseInfo();
                    tmp.Decode(sp);
                    m_list_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_suggested_target_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skill_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsSkillInfo tmp = new AsSkillInfo();
                    tmp.Decode(sp);
                    m_skill_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_suggested);}
            if (sp.TryWrite(1)) {sp.Write(m_user_daily_point);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list_info.Count);
                for (int i = 0; i != m_list_info.Count; ++i) {
                    m_list_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_suggested_target_type);}
            if (sp.TryWrite(4)) {
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
        public void CopyFrom(GetAllianceResearchListAckInfo source) {
            m_suggested = source.m_suggested;
            m_user_daily_point = source.m_user_daily_point;
            m_list_info = source.m_list_info;
            m_suggested_target_type = source.m_suggested_target_type;
            m_skill_list = source.m_skill_list;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchProgInfo : NetworkMessage {
        public static int[] Id = { 507,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int64 m_prog_start;
        public Int64 m_prog_end;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_prog_end = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_end);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchProgInfo source) {
            m_type = source.m_type;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDonateRankListReqInfo : NetworkMessage {
        public static int[] Id = { 513,1 };
        public static Ctrl VC;
        public SByte m_rank_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank_type);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchDonateRankListReqInfo source) {
            m_rank_type = source.m_rank_type;
        }
    }
    
    [Serializable]
    public partial class RebelPartRewardDetailInfo : NetworkMessage {
        public static int[] Id = { 519,1 };
        public static Ctrl VC;
        public RebelPartRewardBaseInfo m_base_info;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int16 m_part;
        public Int64 m_hp_max;
        public Int64 m_hp_killed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelPartRewardBaseInfo();
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
            if (sp.TryRead(2)) {m_part = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_hp_max = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_hp_killed = sp.ReadInt64();}
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
            if (sp.TryWrite(2)) {sp.Write(m_part);}
            if (sp.TryWrite(3)) {sp.Write(m_hp_max);}
            if (sp.TryWrite(4)) {sp.Write(m_hp_killed);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelPartRewardDetailInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
            m_part = source.m_part;
            m_hp_max = source.m_hp_max;
            m_hp_killed = source.m_hp_killed;
        }
    }
    
    [Serializable]
    public partial class AllianceBuildingUpgradeReportDetailInfo : NetworkMessage {
        public static int[] Id = { 525,1 };
        public static Ctrl VC;
        public AllianceBuildingUpgradeReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceBuildingUpgradeReportBaseInfo();
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
        public void CopyFrom(AllianceBuildingUpgradeReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class GuestRegionLoginInfo : NetworkMessage {
        public static int[] Id = { 531,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_token = "";
        public Int16 m_orig_region;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_token = sp.ReadString();}
            if (sp.TryRead(2)) {m_orig_region = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_token);}
            if (sp.TryWrite(2)) {sp.Write(m_orig_region);}
            sp.EnEnd();
        }
        public void CopyFrom(GuestRegionLoginInfo source) {
            m_user_id = source.m_user_id;
            m_token = source.m_token;
            m_orig_region = source.m_orig_region;
        }
    }
    
    [Serializable]
    public partial class AllianceJoinApplyMail : NetworkMessage {
        public static int[] Id = { 537,1 };
        public static Ctrl VC;
        public Int32 m_as_id;
        public String m_as_name = "";
        public String m_as_abbr = "";
        public Int64 m_owner_id;
        public Int16 m_owner_server_id;
        public String m_owner_name = "";
        public Int32 m_member_count;
        public Int64 m_force;
        public Int64 m_power;
        public Int16 m_giftLevel;
        public String m_lang = "";
        public Int16 m_logo;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_as_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_owner_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_owner_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_member_count = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_force = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_giftLevel = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_lang = sp.ReadString();}
            if (sp.TryRead(11)) {m_logo = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_as_id);}
            if (sp.TryWrite(1)) {sp.Write(m_as_name);}
            if (sp.TryWrite(2)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_owner_id);}
            if (sp.TryWrite(4)) {sp.Write(m_owner_server_id);}
            if (sp.TryWrite(5)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(6)) {sp.Write(m_member_count);}
            if (sp.TryWrite(7)) {sp.Write(m_force);}
            if (sp.TryWrite(8)) {sp.Write(m_power);}
            if (sp.TryWrite(9)) {sp.Write(m_giftLevel);}
            if (sp.TryWrite(10)) {sp.Write(m_lang);}
            if (sp.TryWrite(11)) {sp.Write(m_logo);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceJoinApplyMail source) {
            m_as_id = source.m_as_id;
            m_as_name = source.m_as_name;
            m_as_abbr = source.m_as_abbr;
            m_owner_id = source.m_owner_id;
            m_owner_server_id = source.m_owner_server_id;
            m_owner_name = source.m_owner_name;
            m_member_count = source.m_member_count;
            m_force = source.m_force;
            m_power = source.m_power;
            m_giftLevel = source.m_giftLevel;
            m_lang = source.m_lang;
            m_logo = source.m_logo;
        }
    }
    
    [Serializable]
    public partial class ComeBackRewardStatusInfo : NetworkMessage {
        public static int[] Id = { 543,1 };
        public static Ctrl VC;
        public Boolean m_main_status;
        public List<GetLoginRewardStatus> m_login_rewards_status = new List<GetLoginRewardStatus>();
        public Boolean m_get_come_back_sale_status;
        public Boolean m_get_iap_package;
        public Int64 m_left_secs;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_main_status = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_login_rewards_status.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GetLoginRewardStatus tmp = new GetLoginRewardStatus();
                    tmp.Decode(sp);
                    m_login_rewards_status.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_get_come_back_sale_status = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_get_iap_package = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_left_secs = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_main_status);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_login_rewards_status.Count);
                for (int i = 0; i != m_login_rewards_status.Count; ++i) {
                    m_login_rewards_status[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_get_come_back_sale_status);}
            if (sp.TryWrite(3)) {sp.Write(m_get_iap_package);}
            if (sp.TryWrite(4)) {sp.Write(m_left_secs);}
            sp.EnEnd();
        }
        public void CopyFrom(ComeBackRewardStatusInfo source) {
            m_main_status = source.m_main_status;
            m_login_rewards_status = source.m_login_rewards_status;
            m_get_come_back_sale_status = source.m_get_come_back_sale_status;
            m_get_iap_package = source.m_get_iap_package;
            m_left_secs = source.m_left_secs;
        }
    }
    
    [Serializable]
    public partial class RegionUserStatisticsReqInfo : NetworkMessage {
        public static int[] Id = { 549,1 };
        public static Ctrl VC;
        public Int64 m_region_user_id;
        public Int16 m_user_server_id;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_region_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_region_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionUserStatisticsReqInfo source) {
            m_region_user_id = source.m_region_user_id;
            m_user_server_id = source.m_user_server_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class AsOwnerChangeMail : NetworkMessage {
        public static int[] Id = { 555,1 };
        public static Ctrl VC;
        public SByte m_change_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_change_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_change_type);}
            sp.EnEnd();
        }
        public void CopyFrom(AsOwnerChangeMail source) {
            m_change_type = source.m_change_type;
        }
    }
    
    [Serializable]
    public partial class AchievementInfo : NetworkMessage {
        public static int[] Id = { 561,1 };
        public static Ctrl VC;
        public List<AchievementNode> m_list = new List<AchievementNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AchievementNode tmp = new AchievementNode();
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
        public void CopyFrom(AchievementInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class IstanaNationAckInfo : NetworkMessage {
        public static int[] Id = { 567,1 };
        public static Ctrl VC;
        public Int16 m_declare_server;
        public List<IstanaServerInfo> m_server_info_list = new List<IstanaServerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_declare_server = sp.ReadInt16();}
            if (sp.TryRead(1)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_declare_server);}
            if (sp.TryWrite(1)) {
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
        public void CopyFrom(IstanaNationAckInfo source) {
            m_declare_server = source.m_declare_server;
            m_server_info_list = source.m_server_info_list;
        }
    }
    
    [Serializable]
    public partial class ScrollMapboxRefresh : NetworkMessage {
        public static int[] Id = { 573,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public SByte m_source;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_source = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_source);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollMapboxRefresh source) {
            m_server_id = source.m_server_id;
            m_source = source.m_source;
        }
    }
    
    [Serializable]
    public partial class SwitchInfo : NetworkMessage {
        public static int[] Id = { 579,1 };
        public static Ctrl VC;
        public List<SwitchNode> m_list = new List<SwitchNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SwitchNode tmp = new SwitchNode();
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
        public void CopyFrom(SwitchInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class GetIstanaNationReqInfo : NetworkMessage {
        public static int[] Id = { 585,1 };
        public static Ctrl VC;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GetIstanaNationReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class EliteMonsterSummaryReportDetailInfo : NetworkMessage {
        public static int[] Id = { 591,1 };
        public static Ctrl VC;
        public RebelSummaryReportBaseInfo m_base_info;
        public FightSummaryElite m_fight_summary;
        public StyleInfo m_style;
        public StyleInfo m_user_style;
        public List<Item> m_rewards = new List<Item>();
        public List<Item> m_rewards_rand = new List<Item>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelSummaryReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_fight_summary = new FightSummaryElite();
                m_fight_summary.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_style = new StyleInfo();
                m_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_user_style = new StyleInfo();
                m_user_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards_rand.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
                    tmp.Decode(sp);
                    m_rewards_rand.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_fight_summary.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_user_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
                sp.Write((UInt16)m_rewards_rand.Count);
                for (int i = 0; i != m_rewards_rand.Count; ++i) {
                    m_rewards_rand[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(EliteMonsterSummaryReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_fight_summary = source.m_fight_summary;
            m_style = source.m_style;
            m_user_style = source.m_user_style;
            m_rewards = source.m_rewards;
            m_rewards_rand = source.m_rewards_rand;
        }
    }
    
    [Serializable]
    public partial class RegionListInfo : NetworkMessage {
        public static int[] Id = { 597,1 };
        public static Ctrl VC;
        public Int16 m_region_id;
        public String m_gate_ip = "";
        public String m_gate_port = "";
        public SByte m_status;
        public Int64 m_server_protect_period;
        public Int64 m_user_relocate_protect_period;
        public List<Int16> m_server_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_region_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_gate_ip = sp.ReadString();}
            if (sp.TryRead(2)) {m_gate_port = sp.ReadString();}
            if (sp.TryRead(3)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_server_protect_period = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_user_relocate_protect_period = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_server_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_region_id);}
            if (sp.TryWrite(1)) {sp.Write(m_gate_ip);}
            if (sp.TryWrite(2)) {sp.Write(m_gate_port);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            if (sp.TryWrite(4)) {sp.Write(m_server_protect_period);}
            if (sp.TryWrite(5)) {sp.Write(m_user_relocate_protect_period);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_list.Count);
                for (int i = 0; i != m_server_list.Count; ++i) {
                    sp.Write(m_server_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RegionListInfo source) {
            m_region_id = source.m_region_id;
            m_gate_ip = source.m_gate_ip;
            m_gate_port = source.m_gate_port;
            m_status = source.m_status;
            m_server_protect_period = source.m_server_protect_period;
            m_user_relocate_protect_period = source.m_user_relocate_protect_period;
            m_server_list = source.m_server_list;
        }
    }
    
    [Serializable]
    public partial class ClientClickRecordInfo : NetworkMessage {
        public static int[] Id = { 603,1 };
        public static Ctrl VC;
        public List<ClientClickRecord> m_records = new List<ClientClickRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ClientClickRecord tmp = new ClientClickRecord();
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
        public void CopyFrom(ClientClickRecordInfo source) {
            m_records = source.m_records;
        }
    }
    
    [Serializable]
    public partial class LevelRewardDetail : NetworkMessage {
        public static int[] Id = { 609,1 };
        public static Ctrl VC;
        public Int64 m_trigger_num;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public SByte m_get_status;
        public SByte m_reward_level;
        public Int16 m_dayth;
        public Int64 m_cur_day_total_charge;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_trigger_num = sp.ReadInt64();}
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
            if (sp.TryRead(2)) {m_get_status = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_reward_level = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_dayth = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_cur_day_total_charge = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_trigger_num);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_get_status);}
            if (sp.TryWrite(3)) {sp.Write(m_reward_level);}
            if (sp.TryWrite(4)) {sp.Write(m_dayth);}
            if (sp.TryWrite(5)) {sp.Write(m_cur_day_total_charge);}
            sp.EnEnd();
        }
        public void CopyFrom(LevelRewardDetail source) {
            m_trigger_num = source.m_trigger_num;
            m_rewards = source.m_rewards;
            m_get_status = source.m_get_status;
            m_reward_level = source.m_reward_level;
            m_dayth = source.m_dayth;
            m_cur_day_total_charge = source.m_cur_day_total_charge;
        }
    }
    
    [Serializable]
    public partial class TaskStepInfo : NetworkMessage {
        public static int[] Id = { 615,1 };
        public static Ctrl VC;
        public SByte m_step;
        public Int64 m_points;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Boolean m_get;
        public SByte m_show_day;
        public SByte m_page;
        public String m_jump_str = "";
        public List<CampaignEvent> m_event = new List<CampaignEvent>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
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
            if (sp.TryRead(3)) {m_get = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_show_day = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_page = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_jump_str = sp.ReadString();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_event.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignEvent tmp = new CampaignEvent();
                    tmp.Decode(sp);
                    m_event.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_get);}
            if (sp.TryWrite(4)) {sp.Write(m_show_day);}
            if (sp.TryWrite(5)) {sp.Write(m_page);}
            if (sp.TryWrite(6)) {sp.Write(m_jump_str);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_event.Count);
                for (int i = 0; i != m_event.Count; ++i) {
                    m_event[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TaskStepInfo source) {
            m_step = source.m_step;
            m_points = source.m_points;
            m_rewards = source.m_rewards;
            m_get = source.m_get;
            m_show_day = source.m_show_day;
            m_page = source.m_page;
            m_jump_str = source.m_jump_str;
            m_event = source.m_event;
        }
    }
    
    [Serializable]
    public partial class FpsInfo : NetworkMessage {
        public static int[] Id = { 621,1 };
        public static Ctrl VC;
        public Int16 m_current_level;
        public Int16 m_max_level;
        public Int16 m_sweep_cnt;
        public List<FpsSweepCntInfo> m_sweep_cnt_list = new List<FpsSweepCntInfo>();
        public Int64 m_sweep_reset_time;
        public SByte m_status;
        public Int32 m_scan_point;
        public Int32 m_score;
        public Int32 m_kill_num;
        public List<Rankinfo> m_ranklist = new List<Rankinfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_max_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_sweep_cnt = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sweep_cnt_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FpsSweepCntInfo tmp = new FpsSweepCntInfo();
                    tmp.Decode(sp);
                    m_sweep_cnt_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_sweep_reset_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_scan_point = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_kill_num = sp.ReadInt32();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ranklist.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Rankinfo tmp = new Rankinfo();
                    tmp.Decode(sp);
                    m_ranklist.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_level);}
            if (sp.TryWrite(1)) {sp.Write(m_max_level);}
            if (sp.TryWrite(2)) {sp.Write(m_sweep_cnt);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sweep_cnt_list.Count);
                for (int i = 0; i != m_sweep_cnt_list.Count; ++i) {
                    m_sweep_cnt_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_sweep_reset_time);}
            if (sp.TryWrite(5)) {sp.Write(m_status);}
            if (sp.TryWrite(6)) {sp.Write(m_scan_point);}
            if (sp.TryWrite(7)) {sp.Write(m_score);}
            if (sp.TryWrite(8)) {sp.Write(m_kill_num);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ranklist.Count);
                for (int i = 0; i != m_ranklist.Count; ++i) {
                    m_ranklist[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FpsInfo source) {
            m_current_level = source.m_current_level;
            m_max_level = source.m_max_level;
            m_sweep_cnt = source.m_sweep_cnt;
            m_sweep_cnt_list = source.m_sweep_cnt_list;
            m_sweep_reset_time = source.m_sweep_reset_time;
            m_status = source.m_status;
            m_scan_point = source.m_scan_point;
            m_score = source.m_score;
            m_kill_num = source.m_kill_num;
            m_ranklist = source.m_ranklist;
        }
    }
    
    [Serializable]
    public partial class FpsRewardItem : NetworkMessage {
        public static int[] Id = { 627,1 };
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
        public void CopyFrom(FpsRewardItem source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class GloryWallsReqInfo : NetworkMessage {
        public static int[] Id = { 633,1 };
        public static Ctrl VC;
        public Int16 m_region_id;
        public SByte m_glory_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_region_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_glory_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_region_id);}
            if (sp.TryWrite(1)) {sp.Write(m_glory_type);}
            sp.EnEnd();
        }
        public void CopyFrom(GloryWallsReqInfo source) {
            m_region_id = source.m_region_id;
            m_glory_type = source.m_glory_type;
        }
    }
    
    [Serializable]
    public partial class VerifyPhoneCodeReqInfo : NetworkMessage {
        public static int[] Id = { 639,1 };
        public static Ctrl VC;
        public String m_phone_number = "";
        public String m_verify_code = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_phone_number = sp.ReadString();}
            if (sp.TryRead(1)) {m_verify_code = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_phone_number);}
            if (sp.TryWrite(1)) {sp.Write(m_verify_code);}
            sp.EnEnd();
        }
        public void CopyFrom(VerifyPhoneCodeReqInfo source) {
            m_phone_number = source.m_phone_number;
            m_verify_code = source.m_verify_code;
        }
    }
    
    [Serializable]
    public partial class FirstChargeRewardItem : NetworkMessage {
        public static int[] Id = { 645,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int16 m_item_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_num);}
            if (sp.TryWrite(2)) {sp.Write(m_item_type);}
            sp.EnEnd();
        }
        public void CopyFrom(FirstChargeRewardItem source) {
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_item_type = source.m_item_type;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedMember : NetworkMessage {
        public static int[] Id = { 651,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int32 m_rank;
        public Int64 m_score;
        public Int32 m_win_times;
        public Int32 m_lose_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_win_times = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_lose_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_win_times);}
            if (sp.TryWrite(4)) {sp.Write(m_lose_times);}
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedMember source) {
            m_server_id = source.m_server_id;
            m_rank = source.m_rank;
            m_score = source.m_score;
            m_win_times = source.m_win_times;
            m_lose_times = source.m_lose_times;
        }
    }
    
    [Serializable]
    public partial class SwitchConfigNode : NetworkMessage {
        public static int[] Id = { 657,1 };
        public static Ctrl VC;
        public String m_switch = "";
        public String m_status = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_switch = sp.ReadString();}
            if (sp.TryRead(1)) {m_status = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_switch);}
            if (sp.TryWrite(1)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(SwitchConfigNode source) {
            m_switch = source.m_switch;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class CaptchaVerifyReqInfo : NetworkMessage {
        public static int[] Id = { 663,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public Int16 m_server_id;
        public String m_ip = "";
        public String m_open_udid = "";
        public String m_captcha = "";
        public String m_user_name = "";
        public String m_appid = "";
        public String m_os_version = "";
        public String m_device_name = "";
        public String m_device_id = "";
        public String m_locale = "";
        public String m_country = "";
        public Int32 m_device_type;
        public Int32 m_verify_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_ip = sp.ReadString();}
            if (sp.TryRead(3)) {m_open_udid = sp.ReadString();}
            if (sp.TryRead(4)) {m_captcha = sp.ReadString();}
            if (sp.TryRead(5)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_appid = sp.ReadString();}
            if (sp.TryRead(7)) {m_os_version = sp.ReadString();}
            if (sp.TryRead(8)) {m_device_name = sp.ReadString();}
            if (sp.TryRead(9)) {m_device_id = sp.ReadString();}
            if (sp.TryRead(10)) {m_locale = sp.ReadString();}
            if (sp.TryRead(11)) {m_country = sp.ReadString();}
            if (sp.TryRead(12)) {m_device_type = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_verify_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_ip);}
            if (sp.TryWrite(3)) {sp.Write(m_open_udid);}
            if (sp.TryWrite(4)) {sp.Write(m_captcha);}
            if (sp.TryWrite(5)) {sp.Write(m_user_name);}
            if (sp.TryWrite(6)) {sp.Write(m_appid);}
            if (sp.TryWrite(7)) {sp.Write(m_os_version);}
            if (sp.TryWrite(8)) {sp.Write(m_device_name);}
            if (sp.TryWrite(9)) {sp.Write(m_device_id);}
            if (sp.TryWrite(10)) {sp.Write(m_locale);}
            if (sp.TryWrite(11)) {sp.Write(m_country);}
            if (sp.TryWrite(12)) {sp.Write(m_device_type);}
            if (sp.TryWrite(13)) {sp.Write(m_verify_type);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptchaVerifyReqInfo source) {
            m_access_token = source.m_access_token;
            m_server_id = source.m_server_id;
            m_ip = source.m_ip;
            m_open_udid = source.m_open_udid;
            m_captcha = source.m_captcha;
            m_user_name = source.m_user_name;
            m_appid = source.m_appid;
            m_os_version = source.m_os_version;
            m_device_name = source.m_device_name;
            m_device_id = source.m_device_id;
            m_locale = source.m_locale;
            m_country = source.m_country;
            m_device_type = source.m_device_type;
            m_verify_type = source.m_verify_type;
        }
    }
    
    [Serializable]
    public partial class ItemDurationInfo : NetworkMessage {
        public static int[] Id = { 669,1 };
        public static Ctrl VC;
        public List<Item> m_list = new List<Item>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Item tmp = new Item();
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
        public void CopyFrom(ItemDurationInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ScrollEquipColor : NetworkMessage {
        public static int[] Id = { 675,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_equip_id;
        public Int16 m_equip_type;
        public Int16 m_color;

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
            if (sp.TryRead(4)) {m_equip_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_equip_type = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_color = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_equip_id);}
            if (sp.TryWrite(5)) {sp.Write(m_equip_type);}
            if (sp.TryWrite(6)) {sp.Write(m_color);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollEquipColor source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_equip_id = source.m_equip_id;
            m_equip_type = source.m_equip_type;
            m_color = source.m_color;
        }
    }
    
    [Serializable]
    public partial class EventCalendarInfo : NetworkMessage {
        public static int[] Id = { 681,1 };
        public static Ctrl VC;
        public Int32 m_event_id;
        public Int32 m_event_sub_type;
        public Int64 m_begin_offset;
        public Int64 m_last_time;
        public Int64 m_ready_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_event_sub_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_begin_offset = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_last_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_ready_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_event_sub_type);}
            if (sp.TryWrite(2)) {sp.Write(m_begin_offset);}
            if (sp.TryWrite(3)) {sp.Write(m_last_time);}
            if (sp.TryWrite(4)) {sp.Write(m_ready_time);}
            sp.EnEnd();
        }
        public void CopyFrom(EventCalendarInfo source) {
            m_event_id = source.m_event_id;
            m_event_sub_type = source.m_event_sub_type;
            m_begin_offset = source.m_begin_offset;
            m_last_time = source.m_last_time;
            m_ready_time = source.m_ready_time;
        }
    }
    
    [Serializable]
    public partial class LastLoginTime : NetworkMessage {
        public static int[] Id = { 687,1 };
        public static Ctrl VC;
        public Int64 m_time_stamp;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_time_stamp = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_time_stamp);}
            sp.EnEnd();
        }
        public void CopyFrom(LastLoginTime source) {
            m_time_stamp = source.m_time_stamp;
        }
    }
    
    [Serializable]
    public partial class FpsPointInfo : NetworkMessage {
        public static int[] Id = { 693,1 };
        public static Ctrl VC;
        public Int32 m_fps_point;
        public Int32 m_fps_point_limit;
        public Int32 m_recover;
        public Int64 m_update_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fps_point = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_fps_point_limit = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_recover = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_update_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fps_point);}
            if (sp.TryWrite(1)) {sp.Write(m_fps_point_limit);}
            if (sp.TryWrite(2)) {sp.Write(m_recover);}
            if (sp.TryWrite(3)) {sp.Write(m_update_time);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsPointInfo source) {
            m_fps_point = source.m_fps_point;
            m_fps_point_limit = source.m_fps_point_limit;
            m_recover = source.m_recover;
            m_update_time = source.m_update_time;
        }
    }
    
    [Serializable]
    public partial class FpsSlotInfo : NetworkMessage {
        public static int[] Id = { 699,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSlotInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class UserClickTracking : NetworkMessage {
        public static int[] Id = { 705,1 };
        public static Ctrl VC;
        public Int64 m_event_id;
        public String m_control_id = "";
        public String m_from_page_id = "";
        public String m_to_page_id = "";
        public String m_ext_data = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_control_id = sp.ReadString();}
            if (sp.TryRead(2)) {m_from_page_id = sp.ReadString();}
            if (sp.TryRead(3)) {m_to_page_id = sp.ReadString();}
            if (sp.TryRead(4)) {m_ext_data = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_control_id);}
            if (sp.TryWrite(2)) {sp.Write(m_from_page_id);}
            if (sp.TryWrite(3)) {sp.Write(m_to_page_id);}
            if (sp.TryWrite(4)) {sp.Write(m_ext_data);}
            sp.EnEnd();
        }
        public void CopyFrom(UserClickTracking source) {
            m_event_id = source.m_event_id;
            m_control_id = source.m_control_id;
            m_from_page_id = source.m_from_page_id;
            m_to_page_id = source.m_to_page_id;
            m_ext_data = source.m_ext_data;
        }
    }
    
    [Serializable]
    public partial class FirstChargePack : NetworkMessage {
        public static int[] Id = { 711,1 };
        public static Ctrl VC;
        public List<FirstChargePackItem> m_items = new List<FirstChargePackItem>();
        public SByte m_is_available;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FirstChargePackItem tmp = new FirstChargePackItem();
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
        public void CopyFrom(FirstChargePack source) {
            m_items = source.m_items;
            m_is_available = source.m_is_available;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelDetailReqInfo : NetworkMessage {
        public static int[] Id = { 717,1 };
        public static Ctrl VC;
        public Int16 m_level_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSpecialLevelDetailReqInfo source) {
            m_level_id = source.m_level_id;
        }
    }
    
    [Serializable]
    public partial class BaseCampaignCond : NetworkMessage {
        public static int[] Id = { 723,1 };
        public static Ctrl VC;
        public Int16 m_min_lv;
        public Int16 m_max_lv;
        public Int16 m_min_vip;
        public Int16 m_max_vip;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_min_lv = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_max_lv = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_min_vip = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_max_vip = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_min_lv);}
            if (sp.TryWrite(1)) {sp.Write(m_max_lv);}
            if (sp.TryWrite(2)) {sp.Write(m_min_vip);}
            if (sp.TryWrite(3)) {sp.Write(m_max_vip);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseCampaignCond source) {
            m_min_lv = source.m_min_lv;
            m_max_lv = source.m_max_lv;
            m_min_vip = source.m_min_vip;
            m_max_vip = source.m_max_vip;
        }
    }
    
    [Serializable]
    public partial class TaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 729,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseTaskCampaignInfo> m_task_info = new List<BaseTaskCampaignInfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(TaskCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
        }
    }
    
    [Serializable]
    public partial class BaseExchangeCampaignInfo : NetworkMessage {
        public static int[] Id = { 735,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public List<ItemInfo> m_source = new List<ItemInfo>();
        public List<ItemInfo> m_target = new List<ItemInfo>();
        public Int32 m_limit;
        public Int32 m_cnt;
        public Int32 m_daily_limit;
        public Int16 m_level_min;
        public Int16 m_level_max;
        public Int16 m_vip_min;
        public Int16 m_vip_max;
        public Int64 m_start_dt;
        public Int64 m_end_dt;
        public List<ExchangeItemPic> m_source_item_pic = new List<ExchangeItemPic>();
        public String m_bg_banner = "";
        public String m_lc_limit_desc = "";
        public Int32 m_resource_id;
        public String m_group = "";
        public String m_resource_desc = "";
        public Int16 m_sort;
        public Int16 m_show_repeat;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_source.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_source.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_target.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_target.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_limit = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_daily_limit = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_level_min = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_level_max = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_vip_min = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_vip_max = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_start_dt = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_end_dt = sp.ReadInt64();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_source_item_pic.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExchangeItemPic tmp = new ExchangeItemPic();
                    tmp.Decode(sp);
                    m_source_item_pic.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_bg_banner = sp.ReadString();}
            if (sp.TryRead(14)) {m_lc_limit_desc = sp.ReadString();}
            if (sp.TryRead(15)) {m_resource_id = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_group = sp.ReadString();}
            if (sp.TryRead(17)) {m_resource_desc = sp.ReadString();}
            if (sp.TryRead(18)) {m_sort = sp.ReadInt16();}
            if (sp.TryRead(19)) {m_show_repeat = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_source.Count);
                for (int i = 0; i != m_source.Count; ++i) {
                    m_source[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_target.Count);
                for (int i = 0; i != m_target.Count; ++i) {
                    m_target[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_limit);}
            if (sp.TryWrite(4)) {sp.Write(m_cnt);}
            if (sp.TryWrite(5)) {sp.Write(m_daily_limit);}
            if (sp.TryWrite(6)) {sp.Write(m_level_min);}
            if (sp.TryWrite(7)) {sp.Write(m_level_max);}
            if (sp.TryWrite(8)) {sp.Write(m_vip_min);}
            if (sp.TryWrite(9)) {sp.Write(m_vip_max);}
            if (sp.TryWrite(10)) {sp.Write(m_start_dt);}
            if (sp.TryWrite(11)) {sp.Write(m_end_dt);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_source_item_pic.Count);
                for (int i = 0; i != m_source_item_pic.Count; ++i) {
                    m_source_item_pic[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {sp.Write(m_bg_banner);}
            if (sp.TryWrite(14)) {sp.Write(m_lc_limit_desc);}
            if (sp.TryWrite(15)) {sp.Write(m_resource_id);}
            if (sp.TryWrite(16)) {sp.Write(m_group);}
            if (sp.TryWrite(17)) {sp.Write(m_resource_desc);}
            if (sp.TryWrite(18)) {sp.Write(m_sort);}
            if (sp.TryWrite(19)) {sp.Write(m_show_repeat);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseExchangeCampaignInfo source) {
            m_id = source.m_id;
            m_source = source.m_source;
            m_target = source.m_target;
            m_limit = source.m_limit;
            m_cnt = source.m_cnt;
            m_daily_limit = source.m_daily_limit;
            m_level_min = source.m_level_min;
            m_level_max = source.m_level_max;
            m_vip_min = source.m_vip_min;
            m_vip_max = source.m_vip_max;
            m_start_dt = source.m_start_dt;
            m_end_dt = source.m_end_dt;
            m_source_item_pic = source.m_source_item_pic;
            m_bg_banner = source.m_bg_banner;
            m_lc_limit_desc = source.m_lc_limit_desc;
            m_resource_id = source.m_resource_id;
            m_group = source.m_group;
            m_resource_desc = source.m_resource_desc;
            m_sort = source.m_sort;
            m_show_repeat = source.m_show_repeat;
        }
    }
    
    [Serializable]
    public partial class CampaignRankReqInfo : NetworkMessage {
        public static int[] Id = { 741,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_sub_rank_id;
        public Int32 m_min;
        public Int32 m_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_sub_rank_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_min = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_max = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_sub_rank_id);}
            if (sp.TryWrite(2)) {sp.Write(m_min);}
            if (sp.TryWrite(3)) {sp.Write(m_max);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignRankReqInfo source) {
            m_id = source.m_id;
            m_sub_rank_id = source.m_sub_rank_id;
            m_min = source.m_min;
            m_max = source.m_max;
        }
    }
    
    [Serializable]
    public partial class BannerInfo : NetworkMessage {
        public static int[] Id = { 747,1 };
        public static Ctrl VC;
        public String m_id = "";
        public String m_title = "";
        public String m_desc = "";
        public String m_cd = "";
        public String m_key_item = "";
        public String m_order = "";
        public String m_data = "";
        public String m_banner = "";
        public String m_goto = "";
        public String m_template = "";
        public String m_iap = "";
        public Int64 m_start;
        public Int64 m_end;
        public Int32 m_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_desc = sp.ReadString();}
            if (sp.TryRead(3)) {m_cd = sp.ReadString();}
            if (sp.TryRead(4)) {m_key_item = sp.ReadString();}
            if (sp.TryRead(5)) {m_order = sp.ReadString();}
            if (sp.TryRead(6)) {m_data = sp.ReadString();}
            if (sp.TryRead(7)) {m_banner = sp.ReadString();}
            if (sp.TryRead(8)) {m_goto = sp.ReadString();}
            if (sp.TryRead(9)) {m_template = sp.ReadString();}
            if (sp.TryRead(10)) {m_iap = sp.ReadString();}
            if (sp.TryRead(11)) {m_start = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_end = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_desc);}
            if (sp.TryWrite(3)) {sp.Write(m_cd);}
            if (sp.TryWrite(4)) {sp.Write(m_key_item);}
            if (sp.TryWrite(5)) {sp.Write(m_order);}
            if (sp.TryWrite(6)) {sp.Write(m_data);}
            if (sp.TryWrite(7)) {sp.Write(m_banner);}
            if (sp.TryWrite(8)) {sp.Write(m_goto);}
            if (sp.TryWrite(9)) {sp.Write(m_template);}
            if (sp.TryWrite(10)) {sp.Write(m_iap);}
            if (sp.TryWrite(11)) {sp.Write(m_start);}
            if (sp.TryWrite(12)) {sp.Write(m_end);}
            if (sp.TryWrite(13)) {sp.Write(m_times);}
            sp.EnEnd();
        }
        public void CopyFrom(BannerInfo source) {
            m_id = source.m_id;
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_cd = source.m_cd;
            m_key_item = source.m_key_item;
            m_order = source.m_order;
            m_data = source.m_data;
            m_banner = source.m_banner;
            m_goto = source.m_goto;
            m_template = source.m_template;
            m_iap = source.m_iap;
            m_start = source.m_start;
            m_end = source.m_end;
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class ClientText : NetworkMessage {
        public static int[] Id = { 753,1 };
        public static Ctrl VC;
        public String m_id = "";
        public String m_text = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_text = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_text);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientText source) {
            m_id = source.m_id;
            m_text = source.m_text;
        }
    }
    
    [Serializable]
    public partial class DailySignRewardInfo : NetworkMessage {
        public static int[] Id = { 759,1 };
        public static Ctrl VC;
        public Int32 m_days;
        public List<DailySignRewardItem> m_reward_list = new List<DailySignRewardItem>();
        public Boolean m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_days = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailySignRewardItem tmp = new DailySignRewardItem();
                    tmp.Decode(sp);
                    m_reward_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_status = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_days);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_list.Count);
                for (int i = 0; i != m_reward_list.Count; ++i) {
                    m_reward_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(DailySignRewardInfo source) {
            m_days = source.m_days;
            m_reward_list = source.m_reward_list;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class SecondPurchaseReward : NetworkMessage {
        public static int[] Id = { 765,1 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int32 m_score;
        public SByte m_status;

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
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_status = sp.ReadSByte();}
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
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(SecondPurchaseReward source) {
            m_items = source.m_items;
            m_score = source.m_score;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class SetCityAgent : NetworkMessage {
        public static int[] Id = { 771,1 };
        public static Ctrl VC;
        public List<Int16> m_agent = new List<Int16>();
        public Int64 m_map_guid;
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;
        public List<Int16> m_bench_main_agents = new List<Int16>();
        public List<Int16> m_bench_sub_agents = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_bench_main_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_bench_main_agents.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_bench_sub_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_bench_sub_agents.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(2)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(3)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_bench_main_agents.Count);
                for (int i = 0; i != m_bench_main_agents.Count; ++i) {
                    sp.Write(m_bench_main_agents[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_bench_sub_agents.Count);
                for (int i = 0; i != m_bench_sub_agents.Count; ++i) {
                    sp.Write(m_bench_sub_agents[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SetCityAgent source) {
            m_agent = source.m_agent;
            m_map_guid = source.m_map_guid;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
            m_bench_main_agents = source.m_bench_main_agents;
            m_bench_sub_agents = source.m_bench_sub_agents;
        }
    }
    
    [Serializable]
    public partial class UserSurveyListNtfInfo : NetworkMessage {
        public static int[] Id = { 777,1 };
        public static Ctrl VC;
        public List<UserSurveyInfo> m_survey_list = new List<UserSurveyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_survey_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserSurveyInfo tmp = new UserSurveyInfo();
                    tmp.Decode(sp);
                    m_survey_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_survey_list.Count);
                for (int i = 0; i != m_survey_list.Count; ++i) {
                    m_survey_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserSurveyListNtfInfo source) {
            m_survey_list = source.m_survey_list;
        }
    }
    
    [Serializable]
    public partial class CommonBuildingTile : NetworkMessage {
        public static int[] Id = { 783,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_type;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_w;
        public Int16 m_h;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_w = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_h = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_x);}
            if (sp.TryWrite(3)) {sp.Write(m_y);}
            if (sp.TryWrite(4)) {sp.Write(m_w);}
            if (sp.TryWrite(5)) {sp.Write(m_h);}
            sp.EnEnd();
        }
        public void CopyFrom(CommonBuildingTile source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_x = source.m_x;
            m_y = source.m_y;
            m_w = source.m_w;
            m_h = source.m_h;
        }
    }
    
    [Serializable]
    public partial class UpdateMarchReqInfo : NetworkMessage {
        public static int[] Id = { 789,1 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public MapUnitId m_target;
        public Int16 m_march_type;
        public Int16 m_subtype;
        public Boolean m_encamp;
        public Int64 m_map_guid;
        public String m_target_extra_data = "";
        public Boolean m_building_and_reinforce;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_target = new MapUnitId();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_march_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_encamp = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_target_extra_data = sp.ReadString();}
            if (sp.TryRead(7)) {m_building_and_reinforce = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_march_type);}
            if (sp.TryWrite(3)) {sp.Write(m_subtype);}
            if (sp.TryWrite(4)) {sp.Write(m_encamp);}
            if (sp.TryWrite(5)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(6)) {sp.Write(m_target_extra_data);}
            if (sp.TryWrite(7)) {sp.Write(m_building_and_reinforce);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdateMarchReqInfo source) {
            m_march_id = source.m_march_id;
            m_target = source.m_target;
            m_march_type = source.m_march_type;
            m_subtype = source.m_subtype;
            m_encamp = source.m_encamp;
            m_map_guid = source.m_map_guid;
            m_target_extra_data = source.m_target_extra_data;
            m_building_and_reinforce = source.m_building_and_reinforce;
        }
    }
    
    [Serializable]
    public partial class CreepInfo : NetworkMessage {
        public static int[] Id = { 795,1 };
        public static Ctrl VC;
        public SByte m_enemy_type;
        public Int16 m_level;
        public Int64 m_cur_hp;
        public Int64 m_hp_max;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int64 m_end_time;
        public List<RedwolfBuffInfo> m_redwolf_buffs = new List<RedwolfBuffInfo>();
        public Boolean m_refresh_by_skill;
        public Int16 m_action;
        public Int32 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_enemy_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cur_hp = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_hp_max = sp.ReadInt64();}
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
            if (sp.TryRead(5)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_redwolf_buffs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RedwolfBuffInfo tmp = new RedwolfBuffInfo();
                    tmp.Decode(sp);
                    m_redwolf_buffs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_refresh_by_skill = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_action = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_enemy_type);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_hp);}
            if (sp.TryWrite(3)) {sp.Write(m_hp_max);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_end_time);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_redwolf_buffs.Count);
                for (int i = 0; i != m_redwolf_buffs.Count; ++i) {
                    m_redwolf_buffs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_refresh_by_skill);}
            if (sp.TryWrite(8)) {sp.Write(m_action);}
            if (sp.TryWrite(9)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CreepInfo source) {
            m_enemy_type = source.m_enemy_type;
            m_level = source.m_level;
            m_cur_hp = source.m_cur_hp;
            m_hp_max = source.m_hp_max;
            m_items = source.m_items;
            m_end_time = source.m_end_time;
            m_redwolf_buffs = source.m_redwolf_buffs;
            m_refresh_by_skill = source.m_refresh_by_skill;
            m_action = source.m_action;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AgentStarPointItemUseReqInfo : NetworkMessage {
        public static int[] Id = { 801,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int16 m_agent_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_agent_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_agent_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentStarPointItemUseReqInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalentTree : NetworkMessage {
        public static int[] Id = { 807,1 };
        public static Ctrl VC;
        public Int32 m_talent_tree_id;
        public SByte m_index;
        public List<CultureAgentTalent> m_talents = new List<CultureAgentTalent>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_talent_tree_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_index = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_talents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalent tmp = new CultureAgentTalent();
                    tmp.Decode(sp);
                    m_talents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_talent_tree_id);}
            if (sp.TryWrite(1)) {sp.Write(m_index);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_talents.Count);
                for (int i = 0; i != m_talents.Count; ++i) {
                    m_talents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalentTree source) {
            m_talent_tree_id = source.m_talent_tree_id;
            m_index = source.m_index;
            m_talents = source.m_talents;
        }
    }
    
    [Serializable]
    public partial class CultureAgentStarTable : NetworkMessage {
        public static int[] Id = { 813,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public SByte m_heroQuality;
        public Int16 m_heroStar;
        public Int16 m_heroLevelReq;
        public Int32 m_heroStarPointReq;
        public Int32 m_troopsAwd;
        public Int32 m_powerAdd;
        public Int16 m_talentPointRwd;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_heroQuality = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_heroStar = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_heroLevelReq = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_heroStarPointReq = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_troopsAwd = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_powerAdd = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_talentPointRwd = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_heroQuality);}
            if (sp.TryWrite(2)) {sp.Write(m_heroStar);}
            if (sp.TryWrite(3)) {sp.Write(m_heroLevelReq);}
            if (sp.TryWrite(4)) {sp.Write(m_heroStarPointReq);}
            if (sp.TryWrite(5)) {sp.Write(m_troopsAwd);}
            if (sp.TryWrite(6)) {sp.Write(m_powerAdd);}
            if (sp.TryWrite(7)) {sp.Write(m_talentPointRwd);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentStarTable source) {
            m_id = source.m_id;
            m_heroQuality = source.m_heroQuality;
            m_heroStar = source.m_heroStar;
            m_heroLevelReq = source.m_heroLevelReq;
            m_heroStarPointReq = source.m_heroStarPointReq;
            m_troopsAwd = source.m_troopsAwd;
            m_powerAdd = source.m_powerAdd;
            m_talentPointRwd = source.m_talentPointRwd;
        }
    }
    
    [Serializable]
    public partial class LandMaterials : NetworkMessage {
        public static int[] Id = { 819,1 };
        public static Ctrl VC;
        public Int32 m_land_mat;
        public Int32 m_land_mat_speed;
        public Int32 m_land_mat_max;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_land_mat = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_land_mat_speed = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_land_mat_max = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_land_mat);}
            if (sp.TryWrite(1)) {sp.Write(m_land_mat_speed);}
            if (sp.TryWrite(2)) {sp.Write(m_land_mat_max);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(LandMaterials source) {
            m_land_mat = source.m_land_mat;
            m_land_mat_speed = source.m_land_mat_speed;
            m_land_mat_max = source.m_land_mat_max;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class TroopPromotionInfo : NetworkMessage {
        public static int[] Id = { 825,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Boolean m_instant;
        public Int16 m_target_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_instant = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_target_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_instant);}
            if (sp.TryWrite(2)) {sp.Write(m_target_type);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopPromotionInfo source) {
            m_troops = source.m_troops;
            m_instant = source.m_instant;
            m_target_type = source.m_target_type;
        }
    }
    
    [Serializable]
    public partial class MonumentTile : NetworkMessage {
        public static int[] Id = { 831,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int64 m_open_time;
        public UserAllianceBrief m_alliance;
        public UserBriefInfo m_mayor;
        public Boolean m_first_awd;
        public Int32 m_land_cnt;
        public Boolean m_buff_active;
        public Int16 m_buff_level;
        public Int32 m_total_land_cnt;
        public Boolean m_is_claimed;
        public Int64 m_close_time;
        public List<MonumentSkillTime> m_last_skill_times = new List<MonumentSkillTime>();
        public Int16 m_server_id;
        public List<MonumentActionCd> m_action_cd = new List<MonumentActionCd>();
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
            if (sp.TryRead(6)) {
                m_mayor = new UserBriefInfo();
                m_mayor.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_first_awd = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_land_cnt = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_buff_active = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_buff_level = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_total_land_cnt = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_is_claimed = sp.ReadBoolean();}
            if (sp.TryRead(13)) {m_close_time = sp.ReadInt64();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_last_skill_times.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonumentSkillTime tmp = new MonumentSkillTime();
                    tmp.Decode(sp);
                    m_last_skill_times.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_action_cd.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonumentActionCd tmp = new MonumentActionCd();
                    tmp.Decode(sp);
                    m_action_cd.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {
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
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_mayor.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_first_awd);}
            if (sp.TryWrite(8)) {sp.Write(m_land_cnt);}
            if (sp.TryWrite(9)) {sp.Write(m_buff_active);}
            if (sp.TryWrite(10)) {sp.Write(m_buff_level);}
            if (sp.TryWrite(11)) {sp.Write(m_total_land_cnt);}
            if (sp.TryWrite(12)) {sp.Write(m_is_claimed);}
            if (sp.TryWrite(13)) {sp.Write(m_close_time);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_last_skill_times.Count);
                for (int i = 0; i != m_last_skill_times.Count; ++i) {
                    m_last_skill_times[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_server_id);}
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_action_cd.Count);
                for (int i = 0; i != m_action_cd.Count; ++i) {
                    m_action_cd[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MonumentTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_open_time = source.m_open_time;
            m_alliance = source.m_alliance;
            m_mayor = source.m_mayor;
            m_first_awd = source.m_first_awd;
            m_land_cnt = source.m_land_cnt;
            m_buff_active = source.m_buff_active;
            m_buff_level = source.m_buff_level;
            m_total_land_cnt = source.m_total_land_cnt;
            m_is_claimed = source.m_is_claimed;
            m_close_time = source.m_close_time;
            m_last_skill_times = source.m_last_skill_times;
            m_server_id = source.m_server_id;
            m_action_cd = source.m_action_cd;
            m_aura_ids = source.m_aura_ids;
        }
    }
    
    [Serializable]
    public partial class CreateRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 837,1 };
        public static Ctrl VC;
        public List<Int64> m_receiver_list = new List<Int64>();
        public Int32 m_alliance_id;
        public Int16 m_server_id;
        public String m_title = "";
        public String m_content = "";
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<SendResInfo> m_res = new List<SendResInfo>();
        public MailConfirmCreateInfo m_confirm_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_receiver_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_receiver_list.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_content = sp.ReadString();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SendResInfo tmp = new SendResInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                m_confirm_info = new MailConfirmCreateInfo();
                m_confirm_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_receiver_list.Count);
                for (int i = 0; i != m_receiver_list.Count; ++i) {
                    sp.Write(m_receiver_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(2)) {sp.Write(m_server_id);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_content);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_confirm_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CreateRtfMailReqInfo source) {
            m_receiver_list = source.m_receiver_list;
            m_alliance_id = source.m_alliance_id;
            m_server_id = source.m_server_id;
            m_title = source.m_title;
            m_content = source.m_content;
            m_items = source.m_items;
            m_res = source.m_res;
            m_confirm_info = source.m_confirm_info;
        }
    }
    
    [Serializable]
    public partial class GetRtfMailAckInfo : NetworkMessage {
        public static int[] Id = { 843,1 };
        public static Ctrl VC;
        public RtfMailInfo m_mail;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_mail = new RtfMailInfo();
                m_mail.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_mail.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(GetRtfMailAckInfo source) {
            m_mail = source.m_mail;
        }
    }
    
    [Serializable]
    public partial class CollectRtfMailInfo : NetworkMessage {
        public static int[] Id = { 849,1 };
        public static Ctrl VC;
        public List<String> m_mail_id = new List<String>();
        public Boolean m_collect;

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
            if (sp.TryRead(1)) {m_collect = sp.ReadBoolean();}
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
            if (sp.TryWrite(1)) {sp.Write(m_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(CollectRtfMailInfo source) {
            m_mail_id = source.m_mail_id;
            m_collect = source.m_collect;
        }
    }
    
    [Serializable]
    public partial class DeleteAllRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 855,1 };
        public static Ctrl VC;
        public Int16 m_category;
        public Boolean m_del_collect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_category = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_del_collect = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_category);}
            if (sp.TryWrite(1)) {sp.Write(m_del_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(DeleteAllRtfMailReqInfo source) {
            m_category = source.m_category;
            m_del_collect = source.m_del_collect;
        }
    }
    
    [Serializable]
    public partial class TavernBoxOpenAckInfo : NetworkMessage {
        public static int[] Id = { 861,1 };
        public static Ctrl VC;
        public SByte m_box_type;
        public List<BoxItemInfo> m_items = new List<BoxItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_box_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BoxItemInfo tmp = new BoxItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_box_type);}
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
        public void CopyFrom(TavernBoxOpenAckInfo source) {
            m_box_type = source.m_box_type;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class MapMilestoneAwdInfo : NetworkMessage {
        public static int[] Id = { 867,1 };
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
        public void CopyFrom(MapMilestoneAwdInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AllianceWarehouseAckInfo : NetworkMessage {
        public static int[] Id = { 873,1 };
        public static Ctrl VC;
        public Int64 m_funds;
        public List<AllianceWarehouseRes> m_res = new List<AllianceWarehouseRes>();
        public List<AllianceWarehouseCostRecord> m_cost_record = new List<AllianceWarehouseCostRecord>();
        public List<AllianceWarehouseCostRecord> m_kvk_cost_record = new List<AllianceWarehouseCostRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_funds = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceWarehouseRes tmp = new AllianceWarehouseRes();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cost_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceWarehouseCostRecord tmp = new AllianceWarehouseCostRecord();
                    tmp.Decode(sp);
                    m_cost_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_cost_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceWarehouseCostRecord tmp = new AllianceWarehouseCostRecord();
                    tmp.Decode(sp);
                    m_kvk_cost_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_funds);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cost_record.Count);
                for (int i = 0; i != m_cost_record.Count; ++i) {
                    m_cost_record[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_cost_record.Count);
                for (int i = 0; i != m_kvk_cost_record.Count; ++i) {
                    m_kvk_cost_record[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceWarehouseAckInfo source) {
            m_funds = source.m_funds;
            m_res = source.m_res;
            m_cost_record = source.m_cost_record;
            m_kvk_cost_record = source.m_kvk_cost_record;
        }
    }
    
    [Serializable]
    public partial class AllianceFortuneGiftOpenAckInfo : NetworkMessage {
        public static int[] Id = { 879,1 };
        public static Ctrl VC;
        public Int16 m_left;
        public Int64 m_expire_dt;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_left = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_expire_dt = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_left);}
            if (sp.TryWrite(1)) {sp.Write(m_expire_dt);}
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
        public void CopyFrom(AllianceFortuneGiftOpenAckInfo source) {
            m_left = source.m_left;
            m_expire_dt = source.m_expire_dt;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class StepTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 885,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseStepTaskCampaignInfo> m_task_info = new List<BaseStepTaskCampaignInfo>();
        public SByte m_cur_step;
        public SByte m_max_step;

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
                    BaseStepTaskCampaignInfo tmp = new BaseStepTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_cur_step = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_max_step = sp.ReadSByte();}
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
            if (sp.TryWrite(2)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(3)) {sp.Write(m_max_step);}
            sp.EnEnd();
        }
        public void CopyFrom(StepTaskCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
            m_cur_step = source.m_cur_step;
            m_max_step = source.m_max_step;
        }
    }
    
    [Serializable]
    public partial class RoomInfo : NetworkMessage {
        public static int[] Id = { 891,1 };
        public static Ctrl VC;
        public List<MarchInfo> m_march_list = new List<MarchInfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(RoomInfo source) {
            m_march_list = source.m_march_list;
        }
    }
    
    [Serializable]
    public partial class StepTaskCampaignHistoryList : NetworkMessage {
        public static int[] Id = { 897,1 };
        public static Ctrl VC;
        public List<StepTaskCampaignHistory> m_list = new List<StepTaskCampaignHistory>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StepTaskCampaignHistory tmp = new StepTaskCampaignHistory();
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
        public void CopyFrom(StepTaskCampaignHistoryList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ExpeditionStarRewardReqInfo : NetworkMessage {
        public static int[] Id = { 903,1 };
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
        public void CopyFrom(ExpeditionStarRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class MapExploreSearchReqInfo : NetworkMessage {
        public static int[] Id = { 909,1 };
        public static Ctrl VC;
        public Boolean m_force_clean;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_force_clean = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_force_clean);}
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreSearchReqInfo source) {
            m_force_clean = source.m_force_clean;
        }
    }
    
    [Serializable]
    public partial class FpsAtyEndAckInfo : NetworkMessage {
        public static int[] Id = { 915,1 };
        public static Ctrl VC;
        public Boolean m_win;
        public Int16 m_level_id;
        public Int32 m_score;
        public List<Int32> m_score_list = new List<Int32>();
        public CampaignReqItemInfo m_aty_item;
        public FpsRewardItem m_score_to_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_win = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_level_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_score_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_score_list.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                m_aty_item = new CampaignReqItemInfo();
                m_aty_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_score_to_item = new FpsRewardItem();
                m_score_to_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_win);}
            if (sp.TryWrite(1)) {sp.Write(m_level_id);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_score_list.Count);
                for (int i = 0; i != m_score_list.Count; ++i) {
                    sp.Write(m_score_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_aty_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_score_to_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsAtyEndAckInfo source) {
            m_win = source.m_win;
            m_level_id = source.m_level_id;
            m_score = source.m_score;
            m_score_list = source.m_score_list;
            m_aty_item = source.m_aty_item;
            m_score_to_item = source.m_score_to_item;
        }
    }
    
    [Serializable]
    public partial class ExpeditionStoreBuyReqInfo : NetworkMessage {
        public static int[] Id = { 921,1 };
        public static Ctrl VC;
        public Boolean m_random_window;
        public Int32 m_window_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_random_window = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_window_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_random_window);}
            if (sp.TryWrite(1)) {sp.Write(m_window_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionStoreBuyReqInfo source) {
            m_random_window = source.m_random_window;
            m_window_id = source.m_window_id;
        }
    }
    
    [Serializable]
    public partial class AssignmentCenterMiniGameAckInfo : NetworkMessage {
        public static int[] Id = { 927,1 };
        public static Ctrl VC;
        public Int64 m_exp;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exp = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exp);}
            sp.EnEnd();
        }
        public void CopyFrom(AssignmentCenterMiniGameAckInfo source) {
            m_exp = source.m_exp;
        }
    }
    
    [Serializable]
    public partial class CampaignAllIdAckInfo : NetworkMessage {
        public static int[] Id = { 933,1 };
        public static Ctrl VC;
        public List<CampaignIdInfo> m_list = new List<CampaignIdInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignIdInfo tmp = new CampaignIdInfo();
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
        public void CopyFrom(CampaignAllIdAckInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class CampaignHistoryAllianceInfo : NetworkMessage {
        public static int[] Id = { 939,1 };
        public static Ctrl VC;
        public Int32 m_rank;
        public String m_asName = "";
        public Int64 m_score;
        public Int16 m_color;
        public Int16 m_logo;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_asName = sp.ReadString();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_logo = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_asName);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_color);}
            if (sp.TryWrite(4)) {sp.Write(m_logo);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignHistoryAllianceInfo source) {
            m_rank = source.m_rank;
            m_asName = source.m_asName;
            m_score = source.m_score;
            m_color = source.m_color;
            m_logo = source.m_logo;
        }
    }
    
    [Serializable]
    public partial class TapAgentAckInfo : NetworkMessage {
        public static int[] Id = { 945,1 };
        public static Ctrl VC;
        public Int64 m_exp;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exp = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exp);}
            sp.EnEnd();
        }
        public void CopyFrom(TapAgentAckInfo source) {
            m_exp = source.m_exp;
        }
    }
    
    [Serializable]
    public partial class B2VipLevelupNtfInfo : NetworkMessage {
        public static int[] Id = { 951,1 };
        public static Ctrl VC;
        public Int16 m_current_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_level);}
            sp.EnEnd();
        }
        public void CopyFrom(B2VipLevelupNtfInfo source) {
            m_current_level = source.m_current_level;
        }
    }
    
    [Serializable]
    public partial class GovLoot : NetworkMessage {
        public static int[] Id = { 957,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_item_id;
        public Int32 m_limit;
        public List<GovLootRecord> m_record = new List<GovLootRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_limit = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GovLootRecord tmp = new GovLootRecord();
                    tmp.Decode(sp);
                    m_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_limit);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_record.Count);
                for (int i = 0; i != m_record.Count; ++i) {
                    m_record[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GovLoot source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_limit = source.m_limit;
            m_record = source.m_record;
        }
    }
    
    [Serializable]
    public partial class SendGovLootReqInfo : NetworkMessage {
        public static int[] Id = { 963,1 };
        public static Ctrl VC;
        public Int32 m_loot_id;
        public Int64 m_player_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_loot_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_loot_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SendGovLootReqInfo source) {
            m_loot_id = source.m_loot_id;
            m_player_id = source.m_player_id;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignRollResult : NetworkMessage {
        public static int[] Id = { 969,1 };
        public static Ctrl VC;
        public SByte m_time;
        public Int16 m_order;
        public Int16 m_tag;
        public ItemInfo m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_time = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_tag = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                m_reward = new ItemInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_time);}
            if (sp.TryWrite(1)) {sp.Write(m_order);}
            if (sp.TryWrite(2)) {sp.Write(m_tag);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignRollResult source) {
            m_time = source.m_time;
            m_order = source.m_order;
            m_tag = source.m_tag;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelDefenceListInfo : NetworkMessage {
        public static int[] Id = { 975,1 };
        public static Ctrl VC;
        public List<AllianceRebelDefenceInfo> m_defence_list = new List<AllianceRebelDefenceInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defence_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceRebelDefenceInfo tmp = new AllianceRebelDefenceInfo();
                    tmp.Decode(sp);
                    m_defence_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defence_list.Count);
                for (int i = 0; i != m_defence_list.Count; ++i) {
                    m_defence_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelDefenceListInfo source) {
            m_defence_list = source.m_defence_list;
        }
    }
    
    [Serializable]
    public partial class DailySubscriptionReward : NetworkMessage {
        public static int[] Id = { 981,1 };
        public static Ctrl VC;
        public Int64 m_diamonds;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_diamonds = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_diamonds);}
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
        public void CopyFrom(DailySubscriptionReward source) {
            m_diamonds = source.m_diamonds;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelUserLoseNtfInfo : NetworkMessage {
        public static int[] Id = { 987,1 };
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
        public void CopyFrom(AllianceRebelUserLoseNtfInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class SetSignReqInfo : NetworkMessage {
        public static int[] Id = { 993,1 };
        public static Ctrl VC;
        public String m_sign = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sign = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sign);}
            sp.EnEnd();
        }
        public void CopyFrom(SetSignReqInfo source) {
            m_sign = source.m_sign;
        }
    }
    
    [Serializable]
    public partial class UserCostCampaignLevelInfo : NetworkMessage {
        public static int[] Id = { 999,1 };
        public static Ctrl VC;
        public Int16 m_level;
        public Int64 m_exp_next_level;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public List<ItemInfo> m_ex_reward = new List<ItemInfo>();
        public Int64 m_unlock_diamond;
        public String m_tree_pic = "";
        public String m_tree_title = "";
        public String m_reward_pic = "";
        public String m_ex_reward_pic = "";
        public String m_level_pic = "";
        public String m_add_pic = "";
        public String m_item_remain_pic = "";
        public String m_item_remain_text = "";
        public String m_unlock_tip = "";
        public String m_gold_btn_text = "";
        public String m_item_btn_text = "";
        public String m_tree_effect = "";
        public String m_bg_effect = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_exp_next_level = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ex_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_ex_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_unlock_diamond = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_tree_pic = sp.ReadString();}
            if (sp.TryRead(6)) {m_tree_title = sp.ReadString();}
            if (sp.TryRead(7)) {m_reward_pic = sp.ReadString();}
            if (sp.TryRead(8)) {m_ex_reward_pic = sp.ReadString();}
            if (sp.TryRead(9)) {m_level_pic = sp.ReadString();}
            if (sp.TryRead(10)) {m_add_pic = sp.ReadString();}
            if (sp.TryRead(11)) {m_item_remain_pic = sp.ReadString();}
            if (sp.TryRead(12)) {m_item_remain_text = sp.ReadString();}
            if (sp.TryRead(13)) {m_unlock_tip = sp.ReadString();}
            if (sp.TryRead(14)) {m_gold_btn_text = sp.ReadString();}
            if (sp.TryRead(15)) {m_item_btn_text = sp.ReadString();}
            if (sp.TryRead(16)) {m_tree_effect = sp.ReadString();}
            if (sp.TryRead(17)) {m_bg_effect = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_exp_next_level);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ex_reward.Count);
                for (int i = 0; i != m_ex_reward.Count; ++i) {
                    m_ex_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_unlock_diamond);}
            if (sp.TryWrite(5)) {sp.Write(m_tree_pic);}
            if (sp.TryWrite(6)) {sp.Write(m_tree_title);}
            if (sp.TryWrite(7)) {sp.Write(m_reward_pic);}
            if (sp.TryWrite(8)) {sp.Write(m_ex_reward_pic);}
            if (sp.TryWrite(9)) {sp.Write(m_level_pic);}
            if (sp.TryWrite(10)) {sp.Write(m_add_pic);}
            if (sp.TryWrite(11)) {sp.Write(m_item_remain_pic);}
            if (sp.TryWrite(12)) {sp.Write(m_item_remain_text);}
            if (sp.TryWrite(13)) {sp.Write(m_unlock_tip);}
            if (sp.TryWrite(14)) {sp.Write(m_gold_btn_text);}
            if (sp.TryWrite(15)) {sp.Write(m_item_btn_text);}
            if (sp.TryWrite(16)) {sp.Write(m_tree_effect);}
            if (sp.TryWrite(17)) {sp.Write(m_bg_effect);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCostCampaignLevelInfo source) {
            m_level = source.m_level;
            m_exp_next_level = source.m_exp_next_level;
            m_reward = source.m_reward;
            m_ex_reward = source.m_ex_reward;
            m_unlock_diamond = source.m_unlock_diamond;
            m_tree_pic = source.m_tree_pic;
            m_tree_title = source.m_tree_title;
            m_reward_pic = source.m_reward_pic;
            m_ex_reward_pic = source.m_ex_reward_pic;
            m_level_pic = source.m_level_pic;
            m_add_pic = source.m_add_pic;
            m_item_remain_pic = source.m_item_remain_pic;
            m_item_remain_text = source.m_item_remain_text;
            m_unlock_tip = source.m_unlock_tip;
            m_gold_btn_text = source.m_gold_btn_text;
            m_item_btn_text = source.m_item_btn_text;
            m_tree_effect = source.m_tree_effect;
            m_bg_effect = source.m_bg_effect;
        }
    }
    
    [Serializable]
    public partial class ProgressiveTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 1005,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
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
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseProgressiveTaskCampaignInfo tmp = new BaseProgressiveTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_final_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_final_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_final_reward_min_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_cur_step = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_max_step = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_final_reward_limit_dt = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_final_reward_got = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_final_reward_got_cnt = sp.ReadInt32();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_new_final_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignFinalReward tmp = new CampaignFinalReward();
                    tmp.Decode(sp);
                    m_new_final_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {m_cur_score = sp.ReadInt32();}
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
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_final_reward.Count);
                for (int i = 0; i != m_final_reward.Count; ++i) {
                    m_final_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_final_reward_min_score);}
            if (sp.TryWrite(4)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(5)) {sp.Write(m_max_step);}
            if (sp.TryWrite(6)) {sp.Write(m_final_reward_limit_dt);}
            if (sp.TryWrite(7)) {sp.Write(m_final_reward_got);}
            if (sp.TryWrite(8)) {sp.Write(m_final_reward_got_cnt);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_new_final_reward.Count);
                for (int i = 0; i != m_new_final_reward.Count; ++i) {
                    m_new_final_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {sp.Write(m_cur_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ProgressiveTaskCampaignInfo source) {
            m_basic_info = source.m_basic_info;
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
    public partial class CampaignJump : NetworkMessage {
        public static int[] Id = { 1011,1 };
        public static Ctrl VC;
        public String m_title = "";
        public String m_desc = "";
        public String m_icon = "";
        public String m_jump = "";
        public String m_group_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title = sp.ReadString();}
            if (sp.TryRead(1)) {m_desc = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_jump = sp.ReadString();}
            if (sp.TryRead(4)) {m_group_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title);}
            if (sp.TryWrite(1)) {sp.Write(m_desc);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_jump);}
            if (sp.TryWrite(4)) {sp.Write(m_group_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignJump source) {
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_icon = source.m_icon;
            m_jump = source.m_jump;
            m_group_desc = source.m_group_desc;
        }
    }
    
    [Serializable]
    public partial class AllianceShopInfo : NetworkMessage {
        public static int[] Id = { 1017,1 };
        public static Ctrl VC;
        public Int64 m_next_modify_time;
        public List<AllianceShopItem> m_items = new List<AllianceShopItem>();
        public List<AllianceShopStockItem> m_stock = new List<AllianceShopStockItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_next_modify_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceShopItem tmp = new AllianceShopItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_stock.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceShopStockItem tmp = new AllianceShopStockItem();
                    tmp.Decode(sp);
                    m_stock.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_next_modify_time);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_stock.Count);
                for (int i = 0; i != m_stock.Count; ++i) {
                    m_stock[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopInfo source) {
            m_next_modify_time = source.m_next_modify_time;
            m_items = source.m_items;
            m_stock = source.m_stock;
        }
    }
    
    [Serializable]
    public partial class AllianceShopRestockHistoryInfo : NetworkMessage {
        public static int[] Id = { 1023,1 };
        public static Ctrl VC;
        public List<AllianceShopRestockHistoryEntry> m_history = new List<AllianceShopRestockHistoryEntry>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_history.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceShopRestockHistoryEntry tmp = new AllianceShopRestockHistoryEntry();
                    tmp.Decode(sp);
                    m_history.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_history.Count);
                for (int i = 0; i != m_history.Count; ++i) {
                    m_history[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopRestockHistoryInfo source) {
            m_history = source.m_history;
        }
    }
    
    [Serializable]
    public partial class QuestCountdownInfo : NetworkMessage {
        public static int[] Id = { 1029,2 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_begin_time;
        public Int16 m_status;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            if (sp.TryWrite(3)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestCountdownInfo source) {
            m_id = source.m_id;
            m_begin_time = source.m_begin_time;
            m_status = source.m_status;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class FogData3 : NetworkMessage {
        public static int[] Id = { 1035,2 };
        public static Ctrl VC;
        public SByte m_pos1;
        public SByte m_pos2;
        public List<UInt64> m_data = new List<UInt64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pos1 = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_pos2 = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_data.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UInt64 tmp = sp.ReadUInt64();
                    m_data.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pos1);}
            if (sp.TryWrite(1)) {sp.Write(m_pos2);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_data.Count);
                for (int i = 0; i != m_data.Count; ++i) {
                    sp.Write(m_data[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FogData3 source) {
            m_pos1 = source.m_pos1;
            m_pos2 = source.m_pos2;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class FakeFogOpenInfo : NetworkMessage {
        public static int[] Id = { 1041,2 };
        public static Ctrl VC;
        public List<TilePos> m_player_city = new List<TilePos>();
        public List<TilePos> m_stronghold = new List<TilePos>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_player_city.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_player_city.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_stronghold.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_stronghold.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_player_city.Count);
                for (int i = 0; i != m_player_city.Count; ++i) {
                    m_player_city[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_stronghold.Count);
                for (int i = 0; i != m_stronghold.Count; ++i) {
                    m_stronghold[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FakeFogOpenInfo source) {
            m_player_city = source.m_player_city;
            m_stronghold = source.m_stronghold;
        }
    }
    
    [Serializable]
    public partial class LadderRebelInfo : NetworkMessage {
        public static int[] Id = { 1047,3 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_icon = "";
        public Int64 m_end_dt;
        public RealPos m_pos;
        public List<ItemInfo> m_pre_reward = new List<ItemInfo>();
        public Int64 m_rebel_march_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_end_dt = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                m_pos = new RealPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pre_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_pre_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_rebel_march_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_end_dt);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pre_reward.Count);
                for (int i = 0; i != m_pre_reward.Count; ++i) {
                    m_pre_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_rebel_march_id);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderRebelInfo source) {
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_end_dt = source.m_end_dt;
            m_pos = source.m_pos;
            m_pre_reward = source.m_pre_reward;
            m_rebel_march_id = source.m_rebel_march_id;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBossCondDetail : NetworkMessage {
        public static int[] Id = { 1053,3 };
        public static Ctrl VC;
        public SByte m_difficulty_level;
        public Int16 m_user_cnt;
        public Int16 m_reach_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_difficulty_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_user_cnt = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_reach_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_difficulty_level);}
            if (sp.TryWrite(1)) {sp.Write(m_user_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_reach_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBossCondDetail source) {
            m_difficulty_level = source.m_difficulty_level;
            m_user_cnt = source.m_user_cnt;
            m_reach_cnt = source.m_reach_cnt;
        }
    }
    
    [Serializable]
    public partial class LadderUserBrief : NetworkMessage {
        public static int[] Id = { 1059,3 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_vip;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(4)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_vip = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_avatar);}
            if (sp.TryWrite(4)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(5)) {sp.Write(m_vip);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderUserBrief source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_vip = source.m_vip;
        }
    }
    
    [Serializable]
    public partial class CouponInfos : NetworkMessage {
        public static int[] Id = { 1065,3 };
        public static Ctrl VC;
        public List<CouponInfo> m_infos = new List<CouponInfo>();
        public Int32 m_op;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CouponInfo tmp = new CouponInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_op = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_op);}
            sp.EnEnd();
        }
        public void CopyFrom(CouponInfos source) {
            m_infos = source.m_infos;
            m_op = source.m_op;
        }
    }
    
    [Serializable]
    public partial class RedwolfBuffInfo : NetworkMessage {
        public static int[] Id = { 1071,3 };
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
        public void CopyFrom(RedwolfBuffInfo source) {
            m_id = source.m_id;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class ArenaAgentInfo : NetworkMessage {
        public static int[] Id = { 1077,4 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_level;
        public Int16 m_star;
        public Int16 m_rank;
        public Int32 m_skin;
        public Int32 m_power;
        public Int32 m_study_level;
        public Int32 m_weapon_id;
        public List<Int32> m_weapon_skill = new List<Int32>();
        public List<Int32> m_weapon_attrbutes = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_skin = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_power = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_study_level = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_weapon_id = sp.ReadInt32();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapon_skill.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_weapon_skill.Add(tmp);
                }
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapon_attrbutes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_weapon_attrbutes.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_star);}
            if (sp.TryWrite(3)) {sp.Write(m_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_skin);}
            if (sp.TryWrite(5)) {sp.Write(m_power);}
            if (sp.TryWrite(6)) {sp.Write(m_study_level);}
            if (sp.TryWrite(7)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_skill.Count);
                for (int i = 0; i != m_weapon_skill.Count; ++i) {
                    sp.Write(m_weapon_skill[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_attrbutes.Count);
                for (int i = 0; i != m_weapon_attrbutes.Count; ++i) {
                    sp.Write(m_weapon_attrbutes[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaAgentInfo source) {
            m_id = source.m_id;
            m_level = source.m_level;
            m_star = source.m_star;
            m_rank = source.m_rank;
            m_skin = source.m_skin;
            m_power = source.m_power;
            m_study_level = source.m_study_level;
            m_weapon_id = source.m_weapon_id;
            m_weapon_skill = source.m_weapon_skill;
            m_weapon_attrbutes = source.m_weapon_attrbutes;
        }
    }
    
    [Serializable]
    public partial class ArenaRankRewardInfo : NetworkMessage {
        public static int[] Id = { 1083,4 };
        public static Ctrl VC;
        public Int32 m_rank_d;
        public Int32 m_rank_u;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank_d = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_rank_u = sp.ReadInt32();}
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
            if (sp.TryWrite(0)) {sp.Write(m_rank_d);}
            if (sp.TryWrite(1)) {sp.Write(m_rank_u);}
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
        public void CopyFrom(ArenaRankRewardInfo source) {
            m_rank_d = source.m_rank_d;
            m_rank_u = source.m_rank_u;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class ArenaHistoryAckInfo : NetworkMessage {
        public static int[] Id = { 1089,4 };
        public static Ctrl VC;
        public List<ArenaHistoryEntryInfo> m_history = new List<ArenaHistoryEntryInfo>();
        public UInt32 m_season;
        public UInt16 m_max_battle_time;
        public Int32 m_troop_speed;
        public List<ArenaTroopAttackSeq> m_attack_seq = new List<ArenaTroopAttackSeq>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_history.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaHistoryEntryInfo tmp = new ArenaHistoryEntryInfo();
                    tmp.Decode(sp);
                    m_history.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_season = sp.ReadUInt32();}
            if (sp.TryRead(2)) {m_max_battle_time = sp.ReadUInt16();}
            if (sp.TryRead(3)) {m_troop_speed = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attack_seq.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopAttackSeq tmp = new ArenaTroopAttackSeq();
                    tmp.Decode(sp);
                    m_attack_seq.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_history.Count);
                for (int i = 0; i != m_history.Count; ++i) {
                    m_history[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_season);}
            if (sp.TryWrite(2)) {sp.Write(m_max_battle_time);}
            if (sp.TryWrite(3)) {sp.Write(m_troop_speed);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attack_seq.Count);
                for (int i = 0; i != m_attack_seq.Count; ++i) {
                    m_attack_seq[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaHistoryAckInfo source) {
            m_history = source.m_history;
            m_season = source.m_season;
            m_max_battle_time = source.m_max_battle_time;
            m_troop_speed = source.m_troop_speed;
            m_attack_seq = source.m_attack_seq;
        }
    }
    
    [Serializable]
    public partial class BattlePassportRwdReq : NetworkMessage {
        public static int[] Id = { 1095,4 };
        public static Ctrl VC;
        public Int16 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(BattlePassportRwdReq source) {
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class CityGuideTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1101,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_group;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_group = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_group);}
            if (sp.TryWrite(2)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CityGuideTaskRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_group = source.m_group;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskBaseInfo : NetworkMessage {
        public static int[] Id = { 1107,5 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public String m_title = "";
        public String m_icon = "";
        public String m_desc = "";
        public Int32 m_cur_point;
        public Int32 m_max_point;
        public Int32 m_reward_point;
        public String m_jump = "";
        public Int64 m_end_dt;
        public Int64 m_during_sec;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_desc = sp.ReadString();}
            if (sp.TryRead(4)) {m_cur_point = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_max_point = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_reward_point = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_jump = sp.ReadString();}
            if (sp.TryRead(8)) {m_end_dt = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_during_sec = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_desc);}
            if (sp.TryWrite(4)) {sp.Write(m_cur_point);}
            if (sp.TryWrite(5)) {sp.Write(m_max_point);}
            if (sp.TryWrite(6)) {sp.Write(m_reward_point);}
            if (sp.TryWrite(7)) {sp.Write(m_jump);}
            if (sp.TryWrite(8)) {sp.Write(m_end_dt);}
            if (sp.TryWrite(9)) {sp.Write(m_during_sec);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeTaskBaseInfo source) {
            m_task_id = source.m_task_id;
            m_title = source.m_title;
            m_icon = source.m_icon;
            m_desc = source.m_desc;
            m_cur_point = source.m_cur_point;
            m_max_point = source.m_max_point;
            m_reward_point = source.m_reward_point;
            m_jump = source.m_jump;
            m_end_dt = source.m_end_dt;
            m_during_sec = source.m_during_sec;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskAbandonReqInfo : NetworkMessage {
        public static int[] Id = { 1113,5 };
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
        public void CopyFrom(AllianceMobilizeTaskAbandonReqInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskAchieveNtfInfo : NetworkMessage {
        public static int[] Id = { 1119,5 };
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
        public void CopyFrom(AllianceMobilizeTaskAchieveNtfInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class ArenaFightDetailInfo : NetworkMessage {
        public static int[] Id = { 1125,6 };
        public static Ctrl VC;
        public UInt16 m_cur;
        public UInt16 m_total;
        public List<BattleRoundInfo> m_rounds = new List<BattleRoundInfo>();
        public Boolean m_is_attacker;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur = sp.ReadUInt16();}
            if (sp.TryRead(1)) {m_total = sp.ReadUInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rounds.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BattleRoundInfo tmp = new BattleRoundInfo();
                    tmp.Decode(sp);
                    m_rounds.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_is_attacker = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur);}
            if (sp.TryWrite(1)) {sp.Write(m_total);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rounds.Count);
                for (int i = 0; i != m_rounds.Count; ++i) {
                    m_rounds[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_is_attacker);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaFightDetailInfo source) {
            m_cur = source.m_cur;
            m_total = source.m_total;
            m_rounds = source.m_rounds;
            m_is_attacker = source.m_is_attacker;
        }
    }
    
    [Serializable]
    public partial class MonumentSkillTime : NetworkMessage {
        public static int[] Id = { 1132,7 };
        public static Ctrl VC;
        public Int32 m_skill_id;
        public Int64 m_last_casting_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_last_casting_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(1)) {sp.Write(m_last_casting_time);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentSkillTime source) {
            m_skill_id = source.m_skill_id;
            m_last_casting_time = source.m_last_casting_time;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerReq : NetworkMessage {
        public static int[] Id = { 1138,8 };
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
        public void CopyFrom(B2TransferServerReq source) {
            m_target_server = source.m_target_server;
            m_trans_type = source.m_trans_type;
        }
    }
    
    [Serializable]
    public partial class BattleSupportMarchPath : NetworkMessage {
        public static int[] Id = { 1144,8 };
        public static Ctrl VC;
        public List<RealPos> m_path = new List<RealPos>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_path.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RealPos tmp = new RealPos();
                    tmp.Decode(sp);
                    m_path.Add(tmp);
                }
                sp.BindCtrl(VC);
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
            sp.EnEnd();
        }
        public void CopyFrom(BattleSupportMarchPath source) {
            m_path = source.m_path;
        }
    }
    
    [Serializable]
    public partial class KillzombieAckInfo : NetworkMessage {
        public static int[] Id = { 1150,11 };
        public static Ctrl VC;
        public Int32 m_reward_cnt;
        public Int32 m_total_reward_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward_cnt = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_total_reward_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_total_reward_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(KillzombieAckInfo source) {
            m_reward_cnt = source.m_reward_cnt;
            m_total_reward_cnt = source.m_total_reward_cnt;
        }
    }
    
    [Serializable]
    public partial class GvgJoinAckInfo : NetworkMessage {
        public static int[] Id = { 1156,12 };
        public static Ctrl VC;
        public Int64 m_battlefield_id;
        public Int64 m_user_id;
        public Int16 m_code;
        public Int64 m_map_guid;
        public UserInfo m_user;
        public Int16 m_mapid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_battlefield_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                m_user = new UserInfo();
                m_user.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_mapid = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_battlefield_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_code);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_user.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_mapid);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgJoinAckInfo source) {
            m_battlefield_id = source.m_battlefield_id;
            m_user_id = source.m_user_id;
            m_code = source.m_code;
            m_map_guid = source.m_map_guid;
            m_user = source.m_user;
            m_mapid = source.m_mapid;
        }
    }
    
    [Serializable]
    public partial class GvgApplyTimeReqInfo : NetworkMessage {
        public static int[] Id = { 1162,12 };
        public static Ctrl VC;
        public Int64 m_apply_battle_time;
        public Int64 m_camp_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_apply_battle_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_camp_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_apply_battle_time);}
            if (sp.TryWrite(1)) {sp.Write(m_camp_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyTimeReqInfo source) {
            m_apply_battle_time = source.m_apply_battle_time;
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class GvgApplyManageNtfInfo : NetworkMessage {
        public static int[] Id = { 1168,12 };
        public static Ctrl VC;
        public List<GvgApplyMemberStatusChangeInfo> m_changes = new List<GvgApplyMemberStatusChangeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_changes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgApplyMemberStatusChangeInfo tmp = new GvgApplyMemberStatusChangeInfo();
                    tmp.Decode(sp);
                    m_changes.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_changes.Count);
                for (int i = 0; i != m_changes.Count; ++i) {
                    m_changes[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyManageNtfInfo source) {
            m_changes = source.m_changes;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldAllianceInfo : NetworkMessage {
        public static int[] Id = { 1174,12 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_color;
        public Int16 m_logo;
        public Int16 m_server_id;
        public Int32 m_score;
        public Int32 m_teleport_cnt;
        public Int32 m_teleport_max;
        public Int32 m_score_raise_rate;
        public List<GvgBattlefieldAllianceMemberInfo> m_member_info = new List<GvgBattlefieldAllianceMemberInfo>();
        public List<GvgStatistics> m_statistic_list = new List<GvgStatistics>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_teleport_cnt = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_teleport_max = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_score_raise_rate = sp.ReadInt32();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_member_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgBattlefieldAllianceMemberInfo tmp = new GvgBattlefieldAllianceMemberInfo();
                    tmp.Decode(sp);
                    m_member_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_statistic_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgStatistics tmp = new GvgStatistics();
                    tmp.Decode(sp);
                    m_statistic_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_color);}
            if (sp.TryWrite(4)) {sp.Write(m_logo);}
            if (sp.TryWrite(5)) {sp.Write(m_server_id);}
            if (sp.TryWrite(6)) {sp.Write(m_score);}
            if (sp.TryWrite(7)) {sp.Write(m_teleport_cnt);}
            if (sp.TryWrite(8)) {sp.Write(m_teleport_max);}
            if (sp.TryWrite(9)) {sp.Write(m_score_raise_rate);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_member_info.Count);
                for (int i = 0; i != m_member_info.Count; ++i) {
                    m_member_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_statistic_list.Count);
                for (int i = 0; i != m_statistic_list.Count; ++i) {
                    m_statistic_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldAllianceInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_server_id = source.m_server_id;
            m_score = source.m_score;
            m_teleport_cnt = source.m_teleport_cnt;
            m_teleport_max = source.m_teleport_max;
            m_score_raise_rate = source.m_score_raise_rate;
            m_member_info = source.m_member_info;
            m_statistic_list = source.m_statistic_list;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldAckInfo : NetworkMessage {
        public static int[] Id = { 1180,12 };
        public static Ctrl VC;
        public List<GvgBattlefieldStatusNtfInfo> m_battlefield_list = new List<GvgBattlefieldStatusNtfInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_battlefield_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgBattlefieldStatusNtfInfo tmp = new GvgBattlefieldStatusNtfInfo();
                    tmp.Decode(sp);
                    m_battlefield_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_battlefield_list.Count);
                for (int i = 0; i != m_battlefield_list.Count; ++i) {
                    m_battlefield_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldAckInfo source) {
            m_battlefield_list = source.m_battlefield_list;
        }
    }
    
    [Serializable]
    public partial class GvgArawdInfo : NetworkMessage {
        public static int[] Id = { 1186,12 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_type;
        public Int32 m_para;
        public String m_text = "";
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_para = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_text = sp.ReadString();}
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_para);}
            if (sp.TryWrite(3)) {sp.Write(m_text);}
            if (sp.TryWrite(4)) {
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
        public void CopyFrom(GvgArawdInfo source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_para = source.m_para;
            m_text = source.m_text;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class NightFixedViewNtfInfo : NetworkMessage {
        public static int[] Id = { 1209,13 };
        public static Ctrl VC;
        public List<NightFixedViewInfo> m_views = new List<NightFixedViewInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_views.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NightFixedViewInfo tmp = new NightFixedViewInfo();
                    tmp.Decode(sp);
                    m_views.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_views.Count);
                for (int i = 0; i != m_views.Count; ++i) {
                    m_views[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NightFixedViewNtfInfo source) {
            m_views = source.m_views;
        }
    }
    
    [Serializable]
    public partial class RouletteCircleStatus : NetworkMessage {
        public static int[] Id = { 1216,14 };
        public static Ctrl VC;
        public SByte m_cur_pos;
        public List<SByte> m_got_cell = new List<SByte>();
        public SByte m_available_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_pos = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_got_cell.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_got_cell.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_available_pt = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_pos);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_got_cell.Count);
                for (int i = 0; i != m_got_cell.Count; ++i) {
                    sp.Write(m_got_cell[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_available_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteCircleStatus source) {
            m_cur_pos = source.m_cur_pos;
            m_got_cell = source.m_got_cell;
            m_available_pt = source.m_available_pt;
        }
    }
    
    [Serializable]
    public partial class UpgradeAgentStudyLevelReqInfo : NetworkMessage {
        public static int[] Id = { 1222,17 };
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
        public void CopyFrom(UpgradeAgentStudyLevelReqInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class UserSetCurrentChatBubbleInfo : NetworkMessage {
        public static int[] Id = { 1228,18 };
        public static Ctrl VC;
        public Int16 m_current_one;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_one = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_one);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSetCurrentChatBubbleInfo source) {
            m_current_one = source.m_current_one;
        }
    }
    
    [Serializable]
    public partial class UserEmoticonInfo : NetworkMessage {
        public static int[] Id = { 1234,18 };
        public static Ctrl VC;
        public List<UserEmoticonItem> m_emoticon_info = new List<UserEmoticonItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_emoticon_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserEmoticonItem tmp = new UserEmoticonItem();
                    tmp.Decode(sp);
                    m_emoticon_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_emoticon_info.Count);
                for (int i = 0; i != m_emoticon_info.Count; ++i) {
                    m_emoticon_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserEmoticonInfo source) {
            m_emoticon_info = source.m_emoticon_info;
        }
    }
    
    [Serializable]
    public partial class ArenaShopItem : NetworkMessage {
        public static int[] Id = { 1240,19 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int32 m_priority;
        public Int32 m_price;
        public Int32 m_item_cnt_max;
        public Int16 m_label_purchased;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_priority = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_price = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_item_cnt_max = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_label_purchased = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_priority);}
            if (sp.TryWrite(4)) {sp.Write(m_price);}
            if (sp.TryWrite(5)) {sp.Write(m_item_cnt_max);}
            if (sp.TryWrite(6)) {sp.Write(m_label_purchased);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaShopItem source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_priority = source.m_priority;
            m_price = source.m_price;
            m_item_cnt_max = source.m_item_cnt_max;
            m_label_purchased = source.m_label_purchased;
        }
    }
    
    [Serializable]
    public partial class UserGetVerifCodeAckInfo : NetworkMessage {
        public static int[] Id = { 1246,19 };
        public static Ctrl VC;
        public String m_verif_code = "";
        public Int64 m_freeze_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_verif_code = sp.ReadString();}
            if (sp.TryRead(1)) {m_freeze_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_verif_code);}
            if (sp.TryWrite(1)) {sp.Write(m_freeze_time);}
            sp.EnEnd();
        }
        public void CopyFrom(UserGetVerifCodeAckInfo source) {
            m_verif_code = source.m_verif_code;
            m_freeze_time = source.m_freeze_time;
        }
    }
    
    [Serializable]
    public partial class MailConfirmUserInfo : NetworkMessage {
        public static int[] Id = { 1252,19 };
        public static Ctrl VC;
        public SByte m_choice;
        public AllianceMember m_mem_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_choice = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_mem_info = new AllianceMember();
                m_mem_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_choice);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_mem_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmUserInfo source) {
            m_choice = source.m_choice;
            m_mem_info = source.m_mem_info;
        }
    }
    
    [Serializable]
    public partial class UserInfoCollectInfo : NetworkMessage {
        public static int[] Id = { 1258,19 };
        public static Ctrl VC;
        public String m_url = "";
        public Int16 m_err_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_url = sp.ReadString();}
            if (sp.TryRead(1)) {m_err_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_url);}
            if (sp.TryWrite(1)) {sp.Write(m_err_code);}
            sp.EnEnd();
        }
        public void CopyFrom(UserInfoCollectInfo source) {
            m_url = source.m_url;
            m_err_code = source.m_err_code;
        }
    }
    
    [Serializable]
    public partial class BossCampaignScoreRule : NetworkMessage {
        public static int[] Id = { 1264,19 };
        public static Ctrl VC;
        public SByte m_level;
        public Int64 m_damage;
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_damage);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignScoreRule source) {
            m_level = source.m_level;
            m_damage = source.m_damage;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class BossCampaignClaimRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1270,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_slot;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_slot = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_slot);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignClaimRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_slot = source.m_slot;
        }
    }
    
    [Serializable]
    public partial class RankCampaignSelfRankReqInfo : NetworkMessage {
        public static int[] Id = { 1276,19 };
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
        public void CopyFrom(RankCampaignSelfRankReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class BossCampaignStrongestZoneAckInfo : NetworkMessage {
        public static int[] Id = { 1282,19 };
        public static Ctrl VC;
        public List<Int16> m_serverIds = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_serverIds.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_serverIds.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_serverIds.Count);
                for (int i = 0; i != m_serverIds.Count; ++i) {
                    sp.Write(m_serverIds[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignStrongestZoneAckInfo source) {
            m_serverIds = source.m_serverIds;
        }
    }
    
    [Serializable]
    public partial class MapIdInfo : NetworkMessage {
        public static int[] Id = { 1288,19 };
        public static Ctrl VC;
        public String m_map_id = "";
        public SByte m_map_level;
        public Int16 m_err_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_map_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_map_level = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_err_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_map_id);}
            if (sp.TryWrite(1)) {sp.Write(m_map_level);}
            if (sp.TryWrite(2)) {sp.Write(m_err_code);}
            sp.EnEnd();
        }
        public void CopyFrom(MapIdInfo source) {
            m_map_id = source.m_map_id;
            m_map_level = source.m_map_level;
            m_err_code = source.m_err_code;
        }
    }
    
    [Serializable]
    public partial class KvkQuestRewardClaimReqInfo : NetworkMessage {
        public static int[] Id = { 1294,19 };
        public static Ctrl VC;
        public Int32 m_quest_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_quest_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_quest_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkQuestRewardClaimReqInfo source) {
            m_quest_id = source.m_quest_id;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortInfo : NetworkMessage {
        public static int[] Id = { 1300,19 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public SByte m_cur_step;
        public Int64 m_cur_step_end_dt;
        public Int16 m_cur_res_donate_pt;
        public Int16 m_res_donate_pt_max;
        public Int64 m_next_res_donate_recover;
        public List<CampaignKvkFortStep> m_steps = new List<CampaignKvkFortStep>();
        public List<CampaignKvkFortResDonateInfo> m_res_donate_rule = new List<CampaignKvkFortResDonateInfo>();
        public List<CampaignKvkFortKillDonateInfo> m_kill_donate_rule = new List<CampaignKvkFortKillDonateInfo>();
        public List<CampaignKvkFortItemDonateInfo> m_item_donate_rule = new List<CampaignKvkFortItemDonateInfo>();
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();
        public Int64 m_first_step_start_dt;
        public Int64 m_last_step_end_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_step = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_cur_step_end_dt = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_cur_res_donate_pt = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_res_donate_pt_max = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_next_res_donate_recover = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_steps.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignKvkFortStep tmp = new CampaignKvkFortStep();
                    tmp.Decode(sp);
                    m_steps.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_donate_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignKvkFortResDonateInfo tmp = new CampaignKvkFortResDonateInfo();
                    tmp.Decode(sp);
                    m_res_donate_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kill_donate_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignKvkFortKillDonateInfo tmp = new CampaignKvkFortKillDonateInfo();
                    tmp.Decode(sp);
                    m_kill_donate_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_donate_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignKvkFortItemDonateInfo tmp = new CampaignKvkFortItemDonateInfo();
                    tmp.Decode(sp);
                    m_item_donate_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_current_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_current_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_first_step_start_dt = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_last_step_end_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_step_end_dt);}
            if (sp.TryWrite(3)) {sp.Write(m_cur_res_donate_pt);}
            if (sp.TryWrite(4)) {sp.Write(m_res_donate_pt_max);}
            if (sp.TryWrite(5)) {sp.Write(m_next_res_donate_recover);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_steps.Count);
                for (int i = 0; i != m_steps.Count; ++i) {
                    m_steps[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_donate_rule.Count);
                for (int i = 0; i != m_res_donate_rule.Count; ++i) {
                    m_res_donate_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kill_donate_rule.Count);
                for (int i = 0; i != m_kill_donate_rule.Count; ++i) {
                    m_kill_donate_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_donate_rule.Count);
                for (int i = 0; i != m_item_donate_rule.Count; ++i) {
                    m_item_donate_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_info.Count);
                for (int i = 0; i != m_exchange_info.Count; ++i) {
                    m_exchange_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_current_items.Count);
                for (int i = 0; i != m_current_items.Count; ++i) {
                    m_current_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(12)) {sp.Write(m_first_step_start_dt);}
            if (sp.TryWrite(13)) {sp.Write(m_last_step_end_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortInfo source) {
            m_basic_info = source.m_basic_info;
            m_cur_step = source.m_cur_step;
            m_cur_step_end_dt = source.m_cur_step_end_dt;
            m_cur_res_donate_pt = source.m_cur_res_donate_pt;
            m_res_donate_pt_max = source.m_res_donate_pt_max;
            m_next_res_donate_recover = source.m_next_res_donate_recover;
            m_steps = source.m_steps;
            m_res_donate_rule = source.m_res_donate_rule;
            m_kill_donate_rule = source.m_kill_donate_rule;
            m_item_donate_rule = source.m_item_donate_rule;
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
            m_first_step_start_dt = source.m_first_step_start_dt;
            m_last_step_end_dt = source.m_last_step_end_dt;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortDonateAckInfo : NetworkMessage {
        public static int[] Id = { 1306,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_donate_id;
        public Int32 m_donate_pt;
        public Int64 m_gs_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_donate_id = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_donate_pt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_gs_pt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_donate_id);}
            if (sp.TryWrite(2)) {sp.Write(m_donate_pt);}
            if (sp.TryWrite(3)) {sp.Write(m_gs_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortDonateAckInfo source) {
            m_act_id = source.m_act_id;
            m_donate_id = source.m_donate_id;
            m_donate_pt = source.m_donate_pt;
            m_gs_pt = source.m_gs_pt;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortStepChangeNtfInfo : NetworkMessage {
        public static int[] Id = { 1312,19 };
        public static Ctrl VC;
        public Int16 m_gs_id;
        public SByte m_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_gs_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_step = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_gs_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortStepChangeNtfInfo source) {
            m_gs_id = source.m_gs_id;
            m_step = source.m_step;
        }
    }
    
    [Serializable]
    public partial class MergeLoginRewardsNtfInfo : NetworkMessage {
        public static int[] Id = { 1318,21 };
        public static Ctrl VC;
        public Int16 m_login_day;
        public List<Int16> m_reward_claimed_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_login_day = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_claimed_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_reward_claimed_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_login_day);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_claimed_list.Count);
                for (int i = 0; i != m_reward_claimed_list.Count; ++i) {
                    sp.Write(m_reward_claimed_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MergeLoginRewardsNtfInfo source) {
            m_login_day = source.m_login_day;
            m_reward_claimed_list = source.m_reward_claimed_list;
        }
    }
    
    [Serializable]
    public partial class SlotMachineAdditionReward : NetworkMessage {
        public static int[] Id = { 1338,22 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_need_score;
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_need_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_need_score);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SlotMachineAdditionReward source) {
            m_id = source.m_id;
            m_need_score = source.m_need_score;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class ExchangeItemPic : NetworkMessage {
        public static int[] Id = { 1344,23 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public String m_pic = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(ExchangeItemPic source) {
            m_item_id = source.m_item_id;
            m_pic = source.m_pic;
        }
    }
    
    [Serializable]
    public partial class KvkServerCountry : NetworkMessage {
        public static int[] Id = { 1350,23 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public SByte m_country;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_country = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_country);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkServerCountry source) {
            m_server_id = source.m_server_id;
            m_country = source.m_country;
        }
    }
    
    [Serializable]
    public partial class SetAllianceJoinConditionInfo : NetworkMessage {
        public static int[] Id = { 1356,23 };
        public static Ctrl VC;
        public Int16 m_hq_level;
        public Int64 m_power;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_hq_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_power = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_hq_level);}
            if (sp.TryWrite(1)) {sp.Write(m_power);}
            sp.EnEnd();
        }
        public void CopyFrom(SetAllianceJoinConditionInfo source) {
            m_hq_level = source.m_hq_level;
            m_power = source.m_power;
        }
    }
    
    [Serializable]
    public partial class GovTowerFireNtfInfo : NetworkMessage {
        public static int[] Id = { 1362,23 };
        public static Ctrl VC;
        public Int64 m_tower_id;
        public TilePos m_pos;
        public Int64 m_fly_time;
        public TilePos m_target;
        public Int64 m_target_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_tower_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_fly_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                m_target = new TilePos();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_target_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_tower_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_fly_time);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_target_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GovTowerFireNtfInfo source) {
            m_tower_id = source.m_tower_id;
            m_pos = source.m_pos;
            m_fly_time = source.m_fly_time;
            m_target = source.m_target;
            m_target_id = source.m_target_id;
        }
    }
    
    [Serializable]
    public partial class UserWarshipResearchQueueInfo : NetworkMessage {
        public static int[] Id = { 1368,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public List<UserWarshipResearchStatusInfo> m_research_queue = new List<UserWarshipResearchStatusInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_research_queue.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserWarshipResearchStatusInfo tmp = new UserWarshipResearchStatusInfo();
                    tmp.Decode(sp);
                    m_research_queue.Add(tmp);
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
                sp.Write((UInt16)m_research_queue.Count);
                for (int i = 0; i != m_research_queue.Count; ++i) {
                    m_research_queue[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipResearchQueueInfo source) {
            m_warship_id = source.m_warship_id;
            m_research_queue = source.m_research_queue;
        }
    }
    
    [Serializable]
    public partial class GatherLabLootNtfInfo : NetworkMessage {
        public static int[] Id = { 1374,23 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public Int64 m_end_time;
        public Int64 m_loot_id;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_loot_id = sp.ReadInt64();}
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_loot_id);}
            if (sp.TryWrite(3)) {
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
        public void CopyFrom(GatherLabLootNtfInfo source) {
            m_march_id = source.m_march_id;
            m_end_time = source.m_end_time;
            m_loot_id = source.m_loot_id;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class KvkLabLootOwnerCheckReqInfo : NetworkMessage {
        public static int[] Id = { 1380,23 };
        public static Ctrl VC;
        public Int64 m_loot_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_loot_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_loot_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkLabLootOwnerCheckReqInfo source) {
            m_loot_id = source.m_loot_id;
        }
    }
    
    [Serializable]
    public partial class KvkGovTowerInfo : NetworkMessage {
        public static int[] Id = { 1386,23 };
        public static Ctrl VC;
        public List<MonumentTile> m_enemy_tower = new List<MonumentTile>();
        public List<MapBuildingDetailInfo> m_gov = new List<MapBuildingDetailInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_enemy_tower.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonumentTile tmp = new MonumentTile();
                    tmp.Decode(sp);
                    m_enemy_tower.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gov.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapBuildingDetailInfo tmp = new MapBuildingDetailInfo();
                    tmp.Decode(sp);
                    m_gov.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_enemy_tower.Count);
                for (int i = 0; i != m_enemy_tower.Count; ++i) {
                    m_enemy_tower[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_gov.Count);
                for (int i = 0; i != m_gov.Count; ++i) {
                    m_gov[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkGovTowerInfo source) {
            m_enemy_tower = source.m_enemy_tower;
            m_gov = source.m_gov;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardCampaignBeginReqInfo : NetworkMessage {
        public static int[] Id = { 1392,23 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardCampaignBeginReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardApplyTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1398,23 };
        public static Ctrl VC;
        public SByte m_slot_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardApplyTaskReqInfo source) {
            m_slot_id = source.m_slot_id;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardTaskStatusNtfInfo : NetworkMessage {
        public static int[] Id = { 1404,23 };
        public static Ctrl VC;
        public AllianceBoardTaskStatusInfo m_task_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_task_status = new AllianceBoardTaskStatusInfo();
                m_task_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_task_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardTaskStatusNtfInfo source) {
            m_task_status = source.m_task_status;
        }
    }
    
    [Serializable]
    public partial class AsChestHideNameInfo : NetworkMessage {
        public static int[] Id = { 1410,23 };
        public static Ctrl VC;
        public Boolean m_hide_name;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_hide_name = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_hide_name);}
            sp.EnEnd();
        }
        public void CopyFrom(AsChestHideNameInfo source) {
            m_hide_name = source.m_hide_name;
        }
    }
    
    [Serializable]
    public partial class GovSkill : NetworkMessage {
        public static int[] Id = { 1416,23 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_cd;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cd = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cd);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(GovSkill source) {
            m_id = source.m_id;
            m_cd = source.m_cd;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class AsTaskInfo : NetworkMessage {
        public static int[] Id = { 1422,23 };
        public static Ctrl VC;
        public Int16 m_class;
        public Int16 m_rewarded_stage;
        public Int64 m_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_class = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_rewarded_stage = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_class);}
            if (sp.TryWrite(1)) {sp.Write(m_rewarded_stage);}
            if (sp.TryWrite(2)) {sp.Write(m_points);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskInfo source) {
            m_class = source.m_class;
            m_rewarded_stage = source.m_rewarded_stage;
            m_points = source.m_points;
        }
    }
    
    [Serializable]
    public partial class CastAsAkillNtfInfo : NetworkMessage {
        public static int[] Id = { 1428,23 };
        public static Ctrl VC;
        public Int64 m_player_id;
        public String m_player_name = "";
        public Int16 m_type;
        public Int16 m_level;
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_player_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_player_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_player_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_name);}
            if (sp.TryWrite(2)) {sp.Write(m_type);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CastAsAkillNtfInfo source) {
            m_player_id = source.m_player_id;
            m_player_name = source.m_player_name;
            m_type = source.m_type;
            m_level = source.m_level;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class AsTaskScoreRankElement : NetworkMessage {
        public static int[] Id = { 1434,23 };
        public static Ctrl VC;
        public Int32 m_as_id;
        public Int64 m_score;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_color;
        public Int16 m_logo;
        public Int32 m_rank;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_as_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(4)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_as_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_abbr);}
            if (sp.TryWrite(4)) {sp.Write(m_color);}
            if (sp.TryWrite(5)) {sp.Write(m_logo);}
            if (sp.TryWrite(6)) {sp.Write(m_rank);}
            if (sp.TryWrite(7)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskScoreRankElement source) {
            m_as_id = source.m_as_id;
            m_score = source.m_score;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_rank = source.m_rank;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class UserShameDetailReqInfo : NetworkMessage {
        public static int[] Id = { 1440,25 };
        public static Ctrl VC;
        public Int64 m_target_user_id;
        public Boolean m_want_shame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_want_shame = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_want_shame);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShameDetailReqInfo source) {
            m_target_user_id = source.m_target_user_id;
            m_want_shame = source.m_want_shame;
        }
    }
    
    [Serializable]
    public partial class UserShamePtInfo : NetworkMessage {
        public static int[] Id = { 1446,25 };
        public static Ctrl VC;
        public Int64 m_target_user;
        public Int32 m_cur_pt;
        public Int64 m_last_update_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_user = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cur_pt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_last_update_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_user);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_pt);}
            if (sp.TryWrite(2)) {sp.Write(m_last_update_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShamePtInfo source) {
            m_target_user = source.m_target_user;
            m_cur_pt = source.m_cur_pt;
            m_last_update_dt = source.m_last_update_dt;
        }
    }
    
    [Serializable]
    public partial class WeaponSplitReqInfo : NetworkMessage {
        public static int[] Id = { 1452,25 };
        public static Ctrl VC;
        public List<Int64> m_weapon_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapon_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_weapon_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_list.Count);
                for (int i = 0; i != m_weapon_list.Count; ++i) {
                    sp.Write(m_weapon_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeaponSplitReqInfo source) {
            m_weapon_list = source.m_weapon_list;
        }
    }
    
    [Serializable]
    public partial class WeaponLockReqInfo : NetworkMessage {
        public static int[] Id = { 1458,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public Boolean m_lock;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_lock = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_lock);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponLockReqInfo source) {
            m_id = source.m_id;
            m_lock = source.m_lock;
        }
    }
    
    [Serializable]
    public partial class UserShameQuickQueryReqInfo : NetworkMessage {
        public static int[] Id = { 1464,25 };
        public static Ctrl VC;
        public Int64 m_target_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShameQuickQueryReqInfo source) {
            m_target_id = source.m_target_id;
        }
    }
    
    [Serializable]
    public partial class CaptainRoom : NetworkMessage {
        public static int[] Id = { 1470,25 };
        public static Ctrl VC;
        public Int32 m_r_id;
        public Int64 m_score;
        public Int64 m_lux_value;
        public Int64 m_pit_value;
        public Int64 m_class_value;
        public Int64 m_modern_value;
        public List<CaptainRoomFurniture> m_furnitures = new List<CaptainRoomFurniture>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_r_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_lux_value = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_pit_value = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_class_value = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_modern_value = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_furnitures.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptainRoomFurniture tmp = new CaptainRoomFurniture();
                    tmp.Decode(sp);
                    m_furnitures.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_r_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_lux_value);}
            if (sp.TryWrite(3)) {sp.Write(m_pit_value);}
            if (sp.TryWrite(4)) {sp.Write(m_class_value);}
            if (sp.TryWrite(5)) {sp.Write(m_modern_value);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_furnitures.Count);
                for (int i = 0; i != m_furnitures.Count; ++i) {
                    m_furnitures[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoom source) {
            m_r_id = source.m_r_id;
            m_score = source.m_score;
            m_lux_value = source.m_lux_value;
            m_pit_value = source.m_pit_value;
            m_class_value = source.m_class_value;
            m_modern_value = source.m_modern_value;
            m_furnitures = source.m_furnitures;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomDailyGiftInfo : NetworkMessage {
        public static int[] Id = { 1476,25 };
        public static Ctrl VC;
        public Int32 m_d_gift_id;
        public Int32 m_daily_cnt;
        public Int32 m_cur_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_d_gift_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_daily_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cur_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_d_gift_id);}
            if (sp.TryWrite(1)) {sp.Write(m_daily_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomDailyGiftInfo source) {
            m_d_gift_id = source.m_d_gift_id;
            m_daily_cnt = source.m_daily_cnt;
            m_cur_cnt = source.m_cur_cnt;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomStoryInfos : NetworkMessage {
        public static int[] Id = { 1482,25 };
        public static Ctrl VC;
        public List<CaptainRoomStoryInfo> m_c_storys = new List<CaptainRoomStoryInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_c_storys.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptainRoomStoryInfo tmp = new CaptainRoomStoryInfo();
                    tmp.Decode(sp);
                    m_c_storys.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_c_storys.Count);
                for (int i = 0; i != m_c_storys.Count; ++i) {
                    m_c_storys[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomStoryInfos source) {
            m_c_storys = source.m_c_storys;
        }
    }
    
    [Serializable]
    public partial class RankingRewardInfo : NetworkMessage {
        public static int[] Id = { 1488,27 };
        public static Ctrl VC;
        public Int64 m_next_time;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_next_time = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_next_time);}
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
        public void CopyFrom(RankingRewardInfo source) {
            m_next_time = source.m_next_time;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class CumulativeRechargeCampaignInfo : NetworkMessage {
        public static int[] Id = { 1494,27 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int16 m_cur_id;
        public List<CumulativeRechargeCampaignCfg> m_cfg = new List<CumulativeRechargeCampaignCfg>();
        public Int64 m_cur_diamonds;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cfg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CumulativeRechargeCampaignCfg tmp = new CumulativeRechargeCampaignCfg();
                    tmp.Decode(sp);
                    m_cfg.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_cur_diamonds = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cfg.Count);
                for (int i = 0; i != m_cfg.Count; ++i) {
                    m_cfg[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_cur_diamonds);}
            sp.EnEnd();
        }
        public void CopyFrom(CumulativeRechargeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cur_id = source.m_cur_id;
            m_cfg = source.m_cfg;
            m_cur_diamonds = source.m_cur_diamonds;
        }
    }
    
    [Serializable]
    public partial class ModifyGenderAckInfo : NetworkMessage {
        public static int[] Id = { 1501,28 };
        public static Ctrl VC;
        public Int32 m_reward_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(ModifyGenderAckInfo source) {
            m_reward_cnt = source.m_reward_cnt;
        }
    }
    
    [Serializable]
    public partial class KvkBountyInfo : NetworkMessage {
        public static int[] Id = { 1530,32 };
        public static Ctrl VC;
        public Int16 m_bounty_server_id;
        public Int32 m_bounty_amount;
        public Int64 m_bounty_server_score;
        public Int32 m_bounty_server_rank;
        public Int64 m_server_score_diff_value;
        public Int64 m_user_score;
        public Int32 m_predict_amount;
        public Int32 m_reward_total_num;
        public Int32 m_reward_drew_num;
        public Int64 m_last_settle_time;
        public Int64 m_stand_top_time;
        public Boolean m_is_max_bounty_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_bounty_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_bounty_amount = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_bounty_server_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_bounty_server_rank = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_server_score_diff_value = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_user_score = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_predict_amount = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_reward_total_num = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_reward_drew_num = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_last_settle_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_stand_top_time = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_is_max_bounty_amount = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_bounty_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_bounty_amount);}
            if (sp.TryWrite(2)) {sp.Write(m_bounty_server_score);}
            if (sp.TryWrite(3)) {sp.Write(m_bounty_server_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_server_score_diff_value);}
            if (sp.TryWrite(5)) {sp.Write(m_user_score);}
            if (sp.TryWrite(6)) {sp.Write(m_predict_amount);}
            if (sp.TryWrite(7)) {sp.Write(m_reward_total_num);}
            if (sp.TryWrite(8)) {sp.Write(m_reward_drew_num);}
            if (sp.TryWrite(9)) {sp.Write(m_last_settle_time);}
            if (sp.TryWrite(10)) {sp.Write(m_stand_top_time);}
            if (sp.TryWrite(11)) {sp.Write(m_is_max_bounty_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBountyInfo source) {
            m_bounty_server_id = source.m_bounty_server_id;
            m_bounty_amount = source.m_bounty_amount;
            m_bounty_server_score = source.m_bounty_server_score;
            m_bounty_server_rank = source.m_bounty_server_rank;
            m_server_score_diff_value = source.m_server_score_diff_value;
            m_user_score = source.m_user_score;
            m_predict_amount = source.m_predict_amount;
            m_reward_total_num = source.m_reward_total_num;
            m_reward_drew_num = source.m_reward_drew_num;
            m_last_settle_time = source.m_last_settle_time;
            m_stand_top_time = source.m_stand_top_time;
            m_is_max_bounty_amount = source.m_is_max_bounty_amount;
        }
    }
    
    [Serializable]
    public partial class SendGiftCampaignInfo : NetworkMessage {
        public static int[] Id = { 1539,32 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public SendGiftCfg m_cfg;
        public List<SendGiftRecord> m_send_records = new List<SendGiftRecord>();
        public List<SendGiftRecord> m_receive_records = new List<SendGiftRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new SendGiftCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_send_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SendGiftRecord tmp = new SendGiftRecord();
                    tmp.Decode(sp);
                    m_send_records.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_receive_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SendGiftRecord tmp = new SendGiftRecord();
                    tmp.Decode(sp);
                    m_receive_records.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_send_records.Count);
                for (int i = 0; i != m_send_records.Count; ++i) {
                    m_send_records[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_receive_records.Count);
                for (int i = 0; i != m_receive_records.Count; ++i) {
                    m_receive_records[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SendGiftCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
            m_send_records = source.m_send_records;
            m_receive_records = source.m_receive_records;
        }
    }
    
    [Serializable]
    public partial class AgentWgtUnlockBoxReqInfo : NetworkMessage {
        public static int[] Id = { 1595,33 };
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
        public void CopyFrom(AgentWgtUnlockBoxReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_box_id = source.m_box_id;
        }
    }
    
    [Serializable]
    public partial class SendGiftRecord : NetworkMessage {
        public static int[] Id = { 1601,33 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_player_id;
        public String m_player_name = "";
        public String m_as_abbr = "";
        public Int32 m_send_num;
        public Boolean m_is_read;
        public Int64 m_time;
        public SByte m_record_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_player_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(4)) {m_send_num = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_is_read = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_record_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            if (sp.TryWrite(2)) {sp.Write(m_player_name);}
            if (sp.TryWrite(3)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(4)) {sp.Write(m_send_num);}
            if (sp.TryWrite(5)) {sp.Write(m_is_read);}
            if (sp.TryWrite(6)) {sp.Write(m_time);}
            if (sp.TryWrite(7)) {sp.Write(m_record_type);}
            sp.EnEnd();
        }
        public void CopyFrom(SendGiftRecord source) {
            m_server_id = source.m_server_id;
            m_player_id = source.m_player_id;
            m_player_name = source.m_player_name;
            m_as_abbr = source.m_as_abbr;
            m_send_num = source.m_send_num;
            m_is_read = source.m_is_read;
            m_time = source.m_time;
            m_record_type = source.m_record_type;
        }
    }
    
    [Serializable]
    public partial class NbpBuyExpReqInfo : NetworkMessage {
        public static int[] Id = { 1639,34 };
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
        public void CopyFrom(NbpBuyExpReqInfo source) {
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class MonopolyAdditionalCfg : NetworkMessage {
        public static int[] Id = { 1646,35 };
        public static Ctrl VC;
        public Int32 m_score;
        public String m_reward = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_reward = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {sp.Write(m_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyAdditionalCfg source) {
            m_score = source.m_score;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class SuperpositionEffectInfo : NetworkMessage {
        public static int[] Id = { 1655,36 };
        public static Ctrl VC;
        public Int32 m_effect_id;
        public Int32 m_layer;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_effect_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_layer = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_effect_id);}
            if (sp.TryWrite(1)) {sp.Write(m_layer);}
            sp.EnEnd();
        }
        public void CopyFrom(SuperpositionEffectInfo source) {
            m_effect_id = source.m_effect_id;
            m_layer = source.m_layer;
        }
    }
    
    [Serializable]
    public partial class KvkShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 1669,36 };
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
        public void CopyFrom(KvkShopBuyReqInfo source) {
            m_index = source.m_index;
        }
    }
    
    [Serializable]
    public partial class PrivateCustomCampaignInfo : NetworkMessage {
        public static int[] Id = { 1680,38 };
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
        public void CopyFrom(PrivateCustomCampaignInfo source) {
            m_basic_info = source.m_basic_info;
        }
    }
    
    [Serializable]
    public partial class GetPrivateCustomInfoReqInfo : NetworkMessage {
        public static int[] Id = { 1686,38 };
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
        public void CopyFrom(GetPrivateCustomInfoReqInfo source) {
            m_iap_type = source.m_iap_type;
        }
    }
    
    [Serializable]
    public partial class EquipChooseExclusiveTalentAckInfo : NetworkMessage {
        public static int[] Id = { 1700,40 };
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
        public void CopyFrom(EquipChooseExclusiveTalentAckInfo source) {
            m_new_equip = source.m_new_equip;
        }
    }
    
    [Serializable]
    public partial class PurchaseRebateCampaignInfo : NetworkMessage {
        public static int[] Id = { 1709,41 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public PurchaseRebateCfg m_cfg;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new PurchaseRebateCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(PurchaseRebateCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeItemExchangeAckInfo : NetworkMessage {
        public static int[] Id = { 1715,41 };
        public static Ctrl VC;
        public IapPackageInfo m_pkg_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pkg_info = new IapPackageInfo();
                m_pkg_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pkg_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeItemExchangeAckInfo source) {
            m_pkg_info = source.m_pkg_info;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalCampaignCfg : NetworkMessage {
        public static int[] Id = { 1725,41 };
        public static Ctrl VC;
        public ItemInfo m_cost;
        public List<ItemInfo> m_base_awards = new List<ItemInfo>();
        public List<EndAwardsCfg> m_end_awards = new List<EndAwardsCfg>();
        public ItemBuyCfg m_buy_cost_cfg;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_cost = new ItemInfo();
                m_cost.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_base_awards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_base_awards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_end_awards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EndAwardsCfg tmp = new EndAwardsCfg();
                    tmp.Decode(sp);
                    m_end_awards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_buy_cost_cfg = new ItemBuyCfg();
                m_buy_cost_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_cost.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_base_awards.Count);
                for (int i = 0; i != m_base_awards.Count; ++i) {
                    m_base_awards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_end_awards.Count);
                for (int i = 0; i != m_end_awards.Count; ++i) {
                    m_end_awards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_buy_cost_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalCampaignCfg source) {
            m_cost = source.m_cost;
            m_base_awards = source.m_base_awards;
            m_end_awards = source.m_end_awards;
            m_buy_cost_cfg = source.m_buy_cost_cfg;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalBuyCostItemAckInfo : NetworkMessage {
        public static int[] Id = { 1732,41 };
        public static Ctrl VC;
        public Int32 m_buy_cost_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_buy_cost_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_buy_cost_num);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalBuyCostItemAckInfo source) {
            m_buy_cost_num = source.m_buy_cost_num;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeOpenCubeReqInfo : NetworkMessage {
        public static int[] Id = { 1738,42 };
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
        public void CopyFrom(StrangeCubeOpenCubeReqInfo source) {
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class WarMarketExchangeReqInfo : NetworkMessage {
        public static int[] Id = { 1744,42 };
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
        public void CopyFrom(WarMarketExchangeReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignInfo : NetworkMessage {
        public static int[] Id = { 1750,44 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public LineTaskCampaignCfg m_config;
        public LineTaskCampaignPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new LineTaskCampaignCfg();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new LineTaskCampaignPlayerInfo();
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
        public void CopyFrom(LineTaskCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class LineTaskGetTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1756,44 };
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
        public void CopyFrom(LineTaskGetTaskRewardReqInfo source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class LegendShopInfo : NetworkMessage {
        public static int[] Id = { 1771,44 };
        public static Ctrl VC;
        public List<LegendShopItemInfo> m_shop_items = new List<LegendShopItemInfo>();
        public Int64 m_refresh_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_shop_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LegendShopItemInfo tmp = new LegendShopItemInfo();
                    tmp.Decode(sp);
                    m_shop_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_refresh_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_shop_items.Count);
                for (int i = 0; i != m_shop_items.Count; ++i) {
                    m_shop_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_refresh_time);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendShopInfo source) {
            m_shop_items = source.m_shop_items;
            m_refresh_time = source.m_refresh_time;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitShopBuyAckInfo : NetworkMessage {
        public static int[] Id = { 1778,44 };
        public static Ctrl VC;
        public LegendShopItemInfo m_item_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_item_info = new LegendShopItemInfo();
                m_item_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_item_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitShopBuyAckInfo source) {
            m_item_info = source.m_item_info;
        }
    }
    
    [Serializable]
    public partial class VoteCampaignCfg : NetworkMessage {
        public static int[] Id = { 1808,44 };
        public static Ctrl VC;
        public Int32 m_suggestion_length;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Boolean m_open_suggestion;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_suggestion_length = sp.ReadInt32();}
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
            if (sp.TryRead(2)) {m_open_suggestion = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_suggestion_length);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_open_suggestion);}
            sp.EnEnd();
        }
        public void CopyFrom(VoteCampaignCfg source) {
            m_suggestion_length = source.m_suggestion_length;
            m_rewards = source.m_rewards;
            m_open_suggestion = source.m_open_suggestion;
        }
    }
    
    [Serializable]
    public partial class NbpDrawTaskRewardsReqInfo : NetworkMessage {
        public static int[] Id = { 1814,45 };
        public static Ctrl VC;
        public Int32 m_week;
        public Int32 m_order;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_week = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_order = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_week);}
            if (sp.TryWrite(1)) {sp.Write(m_order);}
            if (sp.TryWrite(2)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpDrawTaskRewardsReqInfo source) {
            m_week = source.m_week;
            m_order = source.m_order;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class CityDecoration : NetworkMessage {
        public static int[] Id = { 1888,46 };
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
        public void CopyFrom(CityDecoration source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class RecycleCampaignRecycleCfg : NetworkMessage {
        public static int[] Id = { 1894,46 };
        public static Ctrl VC;
        public Int16 m_order;
        public ItemInfo m_recycle_item;
        public Int32 m_recycle_limit;
        public Int32 m_curr_recycle_num;
        public ItemInfo m_token_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_recycle_item = new ItemInfo();
                m_recycle_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_recycle_limit = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_curr_recycle_num = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                m_token_item = new ItemInfo();
                m_token_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_recycle_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_recycle_limit);}
            if (sp.TryWrite(3)) {sp.Write(m_curr_recycle_num);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_token_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RecycleCampaignRecycleCfg source) {
            m_order = source.m_order;
            m_recycle_item = source.m_recycle_item;
            m_recycle_limit = source.m_recycle_limit;
            m_curr_recycle_num = source.m_curr_recycle_num;
            m_token_item = source.m_token_item;
        }
    }
    
    [Serializable]
    public partial class AgentTalentSchemeRenameReqInfo : NetworkMessage {
        public static int[] Id = { 1900,46 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public SByte m_id;
        public String m_new_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_id = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_new_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_new_name);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentTalentSchemeRenameReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_id = source.m_id;
            m_new_name = source.m_new_name;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignPlayerCfg : NetworkMessage {
        public static int[] Id = { 1906,46 };
        public static Ctrl VC;
        public SByte m_id;
        public Int32 m_score;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public String m_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
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
            if (sp.TryRead(3)) {m_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureCampaignPlayerCfg source) {
            m_id = source.m_id;
            m_score = source.m_score;
            m_rewards = source.m_rewards;
            m_desc = source.m_desc;
        }
    }
    
    [Serializable]
    public partial class OutItemInfo : NetworkMessage {
        public static int[] Id = { 1912,47 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_weight;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_weight = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_weight);}
            sp.EnEnd();
        }
        public void CopyFrom(OutItemInfo source) {
            m_item_id = source.m_item_id;
            m_weight = source.m_weight;
        }
    }
    
    [Serializable]
    public partial class HeroOptionalPkgAckInfo : NetworkMessage {
        public static int[] Id = { 1925,48 };
        public static Ctrl VC;
        public List<HeroOptionalPkgGroup> m_pkg_groups = new List<HeroOptionalPkgGroup>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pkg_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HeroOptionalPkgGroup tmp = new HeroOptionalPkgGroup();
                    tmp.Decode(sp);
                    m_pkg_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pkg_groups.Count);
                for (int i = 0; i != m_pkg_groups.Count; ++i) {
                    m_pkg_groups[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(HeroOptionalPkgAckInfo source) {
            m_pkg_groups = source.m_pkg_groups;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStepCfg : NetworkMessage {
        public static int[] Id = { 1986,49 };
        public static Ctrl VC;
        public SByte m_step_id;
        public String m_step_title = "";
        public SByte m_model;
        public SByte m_total_num;
        public SByte m_wrong_num_limit;
        public List<QuestionAnswerStepRewardsInfo> m_rewards = new List<QuestionAnswerStepRewardsInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_step_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_model = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_total_num = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_wrong_num_limit = sp.ReadSByte();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestionAnswerStepRewardsInfo tmp = new QuestionAnswerStepRewardsInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step_title);}
            if (sp.TryWrite(2)) {sp.Write(m_model);}
            if (sp.TryWrite(3)) {sp.Write(m_total_num);}
            if (sp.TryWrite(4)) {sp.Write(m_wrong_num_limit);}
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
        public void CopyFrom(QuestionAnswerStepCfg source) {
            m_step_id = source.m_step_id;
            m_step_title = source.m_step_title;
            m_model = source.m_model;
            m_total_num = source.m_total_num;
            m_wrong_num_limit = source.m_wrong_num_limit;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerCommitReqInfo : NetworkMessage {
        public static int[] Id = { 1992,49 };
        public static Ctrl VC;
        public SByte m_step_id;
        public SByte m_answer_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_answer_index = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step_id);}
            if (sp.TryWrite(1)) {sp.Write(m_answer_index);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerCommitReqInfo source) {
            m_step_id = source.m_step_id;
            m_answer_index = source.m_answer_index;
        }
    }
    
    [Serializable]
    public partial class FlipCardLayerConfig : NetworkMessage {
        public static int[] Id = { 1998,49 };
        public static Ctrl VC;
        public SByte m_layer_type;
        public String m_card_pic = "";
        public ItemInfo m_cost_item;
        public List<FlipCardCellRewardConfig> m_rewards = new List<FlipCardCellRewardConfig>();
        public List<ItemInfo> m_end_rewards = new List<ItemInfo>();
        public SByte m_unlock_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_layer_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_card_pic = sp.ReadString();}
            if (sp.TryRead(2)) {
                m_cost_item = new ItemInfo();
                m_cost_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlipCardCellRewardConfig tmp = new FlipCardCellRewardConfig();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_end_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_end_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_unlock_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_layer_type);}
            if (sp.TryWrite(1)) {sp.Write(m_card_pic);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_cost_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_end_rewards.Count);
                for (int i = 0; i != m_end_rewards.Count; ++i) {
                    m_end_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_unlock_type);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardLayerConfig source) {
            m_layer_type = source.m_layer_type;
            m_card_pic = source.m_card_pic;
            m_cost_item = source.m_cost_item;
            m_rewards = source.m_rewards;
            m_end_rewards = source.m_end_rewards;
            m_unlock_type = source.m_unlock_type;
        }
    }
    
    [Serializable]
    public partial class FlipCardCellRewardInfo : NetworkMessage {
        public static int[] Id = { 2004,49 };
        public static Ctrl VC;
        public Int16 m_id;
        public Boolean m_is_drew;
        public SByte m_x;
        public SByte m_y;
        public SByte m_width;
        public SByte m_height;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_drew = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_x = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_y = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_width = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_height = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_drew);}
            if (sp.TryWrite(2)) {sp.Write(m_x);}
            if (sp.TryWrite(3)) {sp.Write(m_y);}
            if (sp.TryWrite(4)) {sp.Write(m_width);}
            if (sp.TryWrite(5)) {sp.Write(m_height);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardCellRewardInfo source) {
            m_id = source.m_id;
            m_is_drew = source.m_is_drew;
            m_x = source.m_x;
            m_y = source.m_y;
            m_width = source.m_width;
            m_height = source.m_height;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponMakeReqInfo : NetworkMessage {
        public static int[] Id = { 2036,50 };
        public static Ctrl VC;
        public Int32 m_make_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_make_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_make_id);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponMakeReqInfo source) {
            m_make_id = source.m_make_id;
        }
    }
    
    [Serializable]
    public partial class WarshipWearWeaponReqInfo : NetworkMessage {
        public static int[] Id = { 2042,50 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public SByte m_part_type;
        public Int64 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_part_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_part_type);}
            if (sp.TryWrite(2)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWearWeaponReqInfo source) {
            m_warship_id = source.m_warship_id;
            m_part_type = source.m_part_type;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class SubmarineExploreAckInfo : NetworkMessage {
        public static int[] Id = { 2048,50 };
        public static Ctrl VC;
        public Int32 m_explore_num;
        public SubmarineOfficerExploreLog m_officer_explore_log;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_explore_num = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_officer_explore_log = new SubmarineOfficerExploreLog();
                m_officer_explore_log.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_explore_num);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_officer_explore_log.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(SubmarineExploreAckInfo source) {
            m_explore_num = source.m_explore_num;
            m_officer_explore_log = source.m_officer_explore_log;
        }
    }
    
    [Serializable]
    public partial class BattleBannerInfo : NetworkMessage {
        public static int[] Id = { 2058,53 };
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
        public void CopyFrom(BattleBannerInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class RaidPlayerInfo : NetworkMessage {
        public static int[] Id = { 2116,54 };
        public static Ctrl VC;
        public Int32 m_level;
        public SByte m_challenge_num;
        public List<RaidPlayerEffectInfo> m_curr_effects = new List<RaidPlayerEffectInfo>();
        public List<Int32> m_level_effect_reward_ids = new List<Int32>();
        public List<RaidGroupInfo> m_groups = new List<RaidGroupInfo>();
        public Int64 m_total_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_challenge_num = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_curr_effects.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidPlayerEffectInfo tmp = new RaidPlayerEffectInfo();
                    tmp.Decode(sp);
                    m_curr_effects.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_effect_reward_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_level_effect_reward_ids.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidGroupInfo tmp = new RaidGroupInfo();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_total_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_challenge_num);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_curr_effects.Count);
                for (int i = 0; i != m_curr_effects.Count; ++i) {
                    m_curr_effects[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_effect_reward_ids.Count);
                for (int i = 0; i != m_level_effect_reward_ids.Count; ++i) {
                    sp.Write(m_level_effect_reward_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_groups.Count);
                for (int i = 0; i != m_groups.Count; ++i) {
                    m_groups[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_total_score);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidPlayerInfo source) {
            m_level = source.m_level;
            m_challenge_num = source.m_challenge_num;
            m_curr_effects = source.m_curr_effects;
            m_level_effect_reward_ids = source.m_level_effect_reward_ids;
            m_groups = source.m_groups;
            m_total_score = source.m_total_score;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeAckInfo : NetworkMessage {
        public static int[] Id = { 2122,54 };
        public static Ctrl VC;
        public RaidPlayerInfo m_player_info;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Int64 m_score;
        public Int64 m_old_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_player_info = new RaidPlayerInfo();
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
            if (sp.TryRead(2)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_old_score = sp.ReadInt64();}
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
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_old_score);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidChallengeAckInfo source) {
            m_player_info = source.m_player_info;
            m_rewards = source.m_rewards;
            m_score = source.m_score;
            m_old_score = source.m_old_score;
        }
    }
    
    [Serializable]
    public partial class RaidChallengePlayerStatInfo : NetworkMessage {
        public static int[] Id = { 2128,54 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_boss_id;
        public String m_user_name = "";
        public Boolean m_win;
        public Int64 m_score;
        public Int16 m_icon;
        public String m_avatar = "";
        public List<RaidChallengeGroupStatInfo> m_group_stat = new List<RaidChallengeGroupStatInfo>();
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_boss_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_win = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_group_stat.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidChallengeGroupStatInfo tmp = new RaidChallengeGroupStatInfo();
                    tmp.Decode(sp);
                    m_group_stat.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_boss_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_name);}
            if (sp.TryWrite(3)) {sp.Write(m_win);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_group_stat.Count);
                for (int i = 0; i != m_group_stat.Count; ++i) {
                    m_group_stat[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidChallengePlayerStatInfo source) {
            m_user_id = source.m_user_id;
            m_boss_id = source.m_boss_id;
            m_user_name = source.m_user_name;
            m_win = source.m_win;
            m_score = source.m_score;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_group_stat = source.m_group_stat;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class AgentSkillResetBreakthroughLevelReqInfo : NetworkMessage {
        public static int[] Id = { 2136,55 };
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
        public void CopyFrom(AgentSkillResetBreakthroughLevelReqInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactMarketInfo : NetworkMessage {
        public static int[] Id = { 2151,56 };
        public static Ctrl VC;
        public Int32 m_normal_free_open_cnt;
        public Int64 m_normal_next_free_time;
        public Int32 m_advance_free_open_cnt;
        public Int64 m_advance_next_free_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_normal_free_open_cnt = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_normal_next_free_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_advance_free_open_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_advance_next_free_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_normal_free_open_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_normal_next_free_time);}
            if (sp.TryWrite(2)) {sp.Write(m_advance_free_open_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_advance_next_free_time);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactMarketInfo source) {
            m_normal_free_open_cnt = source.m_normal_free_open_cnt;
            m_normal_next_free_time = source.m_normal_next_free_time;
            m_advance_free_open_cnt = source.m_advance_free_open_cnt;
            m_advance_next_free_time = source.m_advance_next_free_time;
        }
    }
    
    [Serializable]
    public partial class OverturnBaseInfo : NetworkMessage {
        public static int[] Id = { 2157,57 };
        public static Ctrl VC;
        public Int32 m_max_free_count;
        public Int32 m_max_end_tag_count;
        public Int32 m_cost_item_id;
        public Int32 m_cost_item_count;
        public Int32 m_token_item_id1;
        public Int32 m_token_item_id2;
        public String m_end_icon = "";
        public Int32 m_free_count;
        public List<OverturnCardInfo> m_cards = new List<OverturnCardInfo>();
        public Int32 m_max_flip_count;
        public String m_end_hp_icon = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_max_free_count = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_max_end_tag_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cost_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_cost_item_count = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_token_item_id1 = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_token_item_id2 = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_end_icon = sp.ReadString();}
            if (sp.TryRead(7)) {m_free_count = sp.ReadInt32();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OverturnCardInfo tmp = new OverturnCardInfo();
                    tmp.Decode(sp);
                    m_cards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_max_flip_count = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_end_hp_icon = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_max_free_count);}
            if (sp.TryWrite(1)) {sp.Write(m_max_end_tag_count);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_cost_item_count);}
            if (sp.TryWrite(4)) {sp.Write(m_token_item_id1);}
            if (sp.TryWrite(5)) {sp.Write(m_token_item_id2);}
            if (sp.TryWrite(6)) {sp.Write(m_end_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_free_count);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cards.Count);
                for (int i = 0; i != m_cards.Count; ++i) {
                    m_cards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {sp.Write(m_max_flip_count);}
            if (sp.TryWrite(10)) {sp.Write(m_end_hp_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnBaseInfo source) {
            m_max_free_count = source.m_max_free_count;
            m_max_end_tag_count = source.m_max_end_tag_count;
            m_cost_item_id = source.m_cost_item_id;
            m_cost_item_count = source.m_cost_item_count;
            m_token_item_id1 = source.m_token_item_id1;
            m_token_item_id2 = source.m_token_item_id2;
            m_end_icon = source.m_end_icon;
            m_free_count = source.m_free_count;
            m_cards = source.m_cards;
            m_max_flip_count = source.m_max_flip_count;
            m_end_hp_icon = source.m_end_hp_icon;
        }
    }
    
    [Serializable]
    public partial class OverturnFlipAckInfo : NetworkMessage {
        public static int[] Id = { 2165,57 };
        public static Ctrl VC;
        public List<OverturnCardInfo> m_card_infos = new List<OverturnCardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_card_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OverturnCardInfo tmp = new OverturnCardInfo();
                    tmp.Decode(sp);
                    m_card_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_card_infos.Count);
                for (int i = 0; i != m_card_infos.Count; ++i) {
                    m_card_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OverturnFlipAckInfo source) {
            m_card_infos = source.m_card_infos;
        }
    }
    
    [Serializable]
    public partial class WantedUserInfo : NetworkMessage {
        public static int[] Id = { 2172,58 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public ServerTilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WantedUserInfo source) {
            m_user_id = source.m_user_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class ItemUpgradeRecord : NetworkMessage {
        public static int[] Id = { 2178,59 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_times);}
            sp.EnEnd();
        }
        public void CopyFrom(ItemUpgradeRecord source) {
            m_id = source.m_id;
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class IapDiscountCampaignInfo : NetworkMessage {
        public static int[] Id = { 2190,60 };
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
        public void CopyFrom(IapDiscountCampaignInfo source) {
            m_basic_info = source.m_basic_info;
        }
    }
    
    [Serializable]
    public partial class ChainGiftsCampaignNormalRewardInfo : NetworkMessage {
        public static int[] Id = { 2252,63 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_is_unlock;
        public SByte m_reward_type;
        public Int32 m_iap_id;
        public List<ItemInfo> m_reward_list = new List<ItemInfo>();
        public Int32 m_score;
        public Boolean m_is_received;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_unlock = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_reward_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_iap_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_is_received = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_unlock);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_type);}
            if (sp.TryWrite(3)) {sp.Write(m_iap_id);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_list.Count);
                for (int i = 0; i != m_reward_list.Count; ++i) {
                    m_reward_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_score);}
            if (sp.TryWrite(6)) {sp.Write(m_is_received);}
            sp.EnEnd();
        }
        public void CopyFrom(ChainGiftsCampaignNormalRewardInfo source) {
            m_id = source.m_id;
            m_is_unlock = source.m_is_unlock;
            m_reward_type = source.m_reward_type;
            m_iap_id = source.m_iap_id;
            m_reward_list = source.m_reward_list;
            m_score = source.m_score;
            m_is_received = source.m_is_received;
        }
    }
    
    [Serializable]
    public partial class FriendSendGiftInfo : NetworkMessage {
        public static int[] Id = { 2258,63 };
        public static Ctrl VC;
        public Int32 m_pkg_id;
        public Int32 m_send_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_send_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(1)) {sp.Write(m_send_num);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendSendGiftInfo source) {
            m_pkg_id = source.m_pkg_id;
            m_send_num = source.m_send_num;
        }
    }
    
    [Serializable]
    public partial class FriendApplyChangeNtfInfo : NetworkMessage {
        public static int[] Id = { 2264,63 };
        public static Ctrl VC;
        public SByte m_change_type;
        public List<FriendApplyInfo> m_apply_info_list = new List<FriendApplyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_change_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_apply_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendApplyInfo tmp = new FriendApplyInfo();
                    tmp.Decode(sp);
                    m_apply_info_list.Add(tmp);
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
                sp.Write((UInt16)m_apply_info_list.Count);
                for (int i = 0; i != m_apply_info_list.Count; ++i) {
                    m_apply_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FriendApplyChangeNtfInfo source) {
            m_change_type = source.m_change_type;
            m_apply_info_list = source.m_apply_info_list;
        }
    }
    
    [Serializable]
    public partial class FriendShopGoodsInfo : NetworkMessage {
        public static int[] Id = { 2270,63 };
        public static Ctrl VC;
        public Int32 m_goods_id;
        public Int32 m_bought_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_goods_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_bought_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_goods_id);}
            if (sp.TryWrite(1)) {sp.Write(m_bought_num);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendShopGoodsInfo source) {
            m_goods_id = source.m_goods_id;
            m_bought_num = source.m_bought_num;
        }
    }
    
    [Serializable]
    public partial class PuzzleDrawAckInfo : NetworkMessage {
        public static int[] Id = { 2276,63 };
        public static Ctrl VC;
        public List<PuzzleDrawItemInfo> m_items = new List<PuzzleDrawItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PuzzleDrawItemInfo tmp = new PuzzleDrawItemInfo();
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
        public void CopyFrom(PuzzleDrawAckInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class AgentEquipPurifyReqInfo : NetworkMessage {
        public static int[] Id = { 2288,64 };
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
        public void CopyFrom(AgentEquipPurifyReqInfo source) {
            m_equip_id = source.m_equip_id;
        }
    }
    
    [Serializable]
    public partial class HomeEffectInfo : NetworkMessage {
        public static int[] Id = { 2294,64 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(HomeEffectInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class SetBaseTeleportEffectReqInfo : NetworkMessage {
        public static int[] Id = { 2311,65 };
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
        public void CopyFrom(SetBaseTeleportEffectReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class SignInCampaignPlayerInfo : NetworkMessage {
        public static int[] Id = { 2317,65 };
        public static Ctrl VC;
        public Int32 m_sign_in_times;
        public Boolean m_is_can_sign_in;
        public Boolean m_is_can_resign_in;
        public Boolean m_is_buy_advance;
        public List<Int32> m_drew_normal_reward_days = new List<Int32>();
        public List<Int32> m_drew_advance_reward_days = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sign_in_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_can_sign_in = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_is_can_resign_in = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_is_buy_advance = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_normal_reward_days.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_normal_reward_days.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_advance_reward_days.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_advance_reward_days.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sign_in_times);}
            if (sp.TryWrite(1)) {sp.Write(m_is_can_sign_in);}
            if (sp.TryWrite(2)) {sp.Write(m_is_can_resign_in);}
            if (sp.TryWrite(3)) {sp.Write(m_is_buy_advance);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_normal_reward_days.Count);
                for (int i = 0; i != m_drew_normal_reward_days.Count; ++i) {
                    sp.Write(m_drew_normal_reward_days[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_advance_reward_days.Count);
                for (int i = 0; i != m_drew_advance_reward_days.Count; ++i) {
                    sp.Write(m_drew_advance_reward_days[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SignInCampaignPlayerInfo source) {
            m_sign_in_times = source.m_sign_in_times;
            m_is_can_sign_in = source.m_is_can_sign_in;
            m_is_can_resign_in = source.m_is_can_resign_in;
            m_is_buy_advance = source.m_is_buy_advance;
            m_drew_normal_reward_days = source.m_drew_normal_reward_days;
            m_drew_advance_reward_days = source.m_drew_advance_reward_days;
        }
    }
    
    [Serializable]
    public partial class VideoCreatorRankItem : NetworkMessage {
        public static int[] Id = { 2323,66 };
        public static Ctrl VC;
        public Int32 m_rank;
        public Int64 m_score;
        public Int64 m_user_id;
        public Int16 m_server_id;
        public String m_alliance = "";
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(5)) {m_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(8)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            if (sp.TryWrite(3)) {sp.Write(m_server_id);}
            if (sp.TryWrite(4)) {sp.Write(m_alliance);}
            if (sp.TryWrite(5)) {sp.Write(m_name);}
            if (sp.TryWrite(6)) {sp.Write(m_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoCreatorRankItem source) {
            m_rank = source.m_rank;
            m_score = source.m_score;
            m_user_id = source.m_user_id;
            m_server_id = source.m_server_id;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class VideoChannelLikeVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2329,66 };
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
        public void CopyFrom(VideoChannelLikeVideoReqInfo source) {
            m_video_id = source.m_video_id;
            m_positive = source.m_positive;
        }
    }
    
    [Serializable]
    public partial class VideoChannelCommitVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2335,66 };
        public static Ctrl VC;
        public Int64 m_video_id;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            if (sp.TryWrite(1)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelCommitVideoCommentReqInfo source) {
            m_video_id = source.m_video_id;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class VideoChannelLikeVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2341,66 };
        public static Ctrl VC;
        public Int64 m_id;
        public Boolean m_positive;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_positive = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_positive);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelLikeVideoCommentReqInfo source) {
            m_id = source.m_id;
            m_positive = source.m_positive;
        }
    }
    
    [Serializable]
    public partial class VideoChannelClaimRewardAckInfo : NetworkMessage {
        public static int[] Id = { 2347,66 };
        public static Ctrl VC;
        public Int32 m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelClaimRewardAckInfo source) {
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetNewVideoListAckInfo : NetworkMessage {
        public static int[] Id = { 2353,66 };
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
        public void CopyFrom(VideoChannelGetNewVideoListAckInfo source) {
            m_video_list = source.m_video_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetUserVideoListAckInfo : NetworkMessage {
        public static int[] Id = { 2359,66 };
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
        public void CopyFrom(VideoChannelGetUserVideoListAckInfo source) {
            m_video_list = source.m_video_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetShopBuyLog : NetworkMessage {
        public static int[] Id = { 2365,66 };
        public static Ctrl VC;
        public Int32 m_obtain_item_id;
        public Int32 m_obtain_item_num;
        public SByte m_cost_res_type;
        public Int64 m_cost_res_num;
        public Int32 m_num;
        public Int64 m_time_ms;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_obtain_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_obtain_item_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cost_res_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_cost_res_num = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_num = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_time_ms = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_obtain_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_obtain_item_num);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_res_type);}
            if (sp.TryWrite(3)) {sp.Write(m_cost_res_num);}
            if (sp.TryWrite(4)) {sp.Write(m_num);}
            if (sp.TryWrite(5)) {sp.Write(m_time_ms);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetShopBuyLog source) {
            m_obtain_item_id = source.m_obtain_item_id;
            m_obtain_item_num = source.m_obtain_item_num;
            m_cost_res_type = source.m_cost_res_type;
            m_cost_res_num = source.m_cost_res_num;
            m_num = source.m_num;
            m_time_ms = source.m_time_ms;
        }
    }
    
    [Serializable]
    public partial class WearMedalReqInfo : NetworkMessage {
        public static int[] Id = { 2390,68 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_is_wear;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_wear = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_wear);}
            sp.EnEnd();
        }
        public void CopyFrom(WearMedalReqInfo source) {
            m_id = source.m_id;
            m_is_wear = source.m_is_wear;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetSubchannelCandidateVideoListReqInfo : NetworkMessage {
        public static int[] Id = { 2396,68 };
        public static Ctrl VC;
        public SByte m_subchannel_type;
        public Int64 m_subchannel_id;
        public String m_sort_type = "";
        public Int32 m_start_index;
        public Int32 m_end_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_subchannel_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_subchannel_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_sort_type = sp.ReadString();}
            if (sp.TryRead(3)) {m_start_index = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_end_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_subchannel_type);}
            if (sp.TryWrite(1)) {sp.Write(m_subchannel_id);}
            if (sp.TryWrite(2)) {sp.Write(m_sort_type);}
            if (sp.TryWrite(3)) {sp.Write(m_start_index);}
            if (sp.TryWrite(4)) {sp.Write(m_end_index);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetSubchannelCandidateVideoListReqInfo source) {
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
            m_sort_type = source.m_sort_type;
            m_start_index = source.m_start_index;
            m_end_index = source.m_end_index;
        }
    }
    
    [Serializable]
    public partial class KvkStrategyChangeReqInfo : NetworkMessage {
        public static int[] Id = { 2402,69 };
        public static Ctrl VC;
        public Int32 m_group_id;
        public Int32 m_strategy_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_strategy_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {sp.Write(m_strategy_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkStrategyChangeReqInfo source) {
            m_group_id = source.m_group_id;
            m_strategy_id = source.m_strategy_id;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetTaskDataAckInfo : NetworkMessage {
        public static int[] Id = { 2438,72 };
        public static Ctrl VC;
        public NewReturnEventTaskData m_task_data;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_task_data = new NewReturnEventTaskData();
                m_task_data.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_task_data.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventGetTaskDataAckInfo source) {
            m_task_data = source.m_task_data;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventPackageInfo : NetworkMessage {
        public static int[] Id = { 2444,72 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_remain_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_remain_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_remain_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventPackageInfo source) {
            m_id = source.m_id;
            m_remain_cnt = source.m_remain_cnt;
        }
    }
    
}
