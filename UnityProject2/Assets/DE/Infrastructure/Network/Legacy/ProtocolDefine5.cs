using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class UserInfo : NetworkMessage {
        public static int[] Id = { 6,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_location_server_id;
        public Int16 m_home_server_id;
        public String m_name = "";
        public Int16 m_level;
        public Int16 m_icon;
        public Int64 m_power;
        public Int64 m_kill_cnt;
        public Int64 m_city_id;
        public Int16 m_x;
        public Int16 m_y;
        public UserAllianceBrief m_alliance;
        public Int32 m_power_rank;
        public Int16 m_vip;
        public Int64 m_total_pay_price;
        public List<MapTitleInfo> m_title = new List<MapTitleInfo>();
        public String m_jid = "";
        public Int32 m_likeNum;
        public Boolean m_Islike;
        public String m_sign = "";
        public String m_avatar = "";
        public SByte m_lang;
        public Int16 m_national_flag;
        public Int16 m_bit_flag;
        public Boolean m_new_role;
        public Int32 m_city_energy;
        public String m_payload = "";
        public List<Int16> m_avatar_frame = new List<Int16>();
        public Int16 m_current_avatar_frame;
        public SByte m_bind_reward_state;
        public String m_new_sign = "";
        public Int16 m_favor_agent;
        public Int32 m_skin;
        public Int16 m_agent_pose;
        public Int16 m_faction;
        public Int16 m_city_skin;
        public List<MayorInfo> m_mayor = new List<MayorInfo>();
        public Boolean m_vip_switch;
        public Int16 m_archive_level;
        public Int64 m_bit_label;
        public Int16 m_city_nameplate;
        public Int16 m_chat_bubble;
        public List<AvatarFrameId> m_time_limit_avatar_frame = new List<AvatarFrameId>();
        public String m_server_map = "";
        public Int16 m_hq_level;
        public SByte m_gender;
        public Boolean m_is_modify_gender;
        public Int64 m_kill_points;
        public List<KillTroopInfo> m_kill_troop_infos = new List<KillTroopInfo>();
        public Int16 m_city_decoration_pendant;
        public Int16 m_city_decoration_hole;
        public Int16 m_battle_banner;
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;
        public Int16 m_city_decoration_counterattack;
        public Int32 m_home_background_id;
        public Int32 m_home_effect_id;
        public Int16 m_base_teleport_effect_id;
        public List<UserMedalSimpleInfo> m_medal_list = new List<UserMedalSimpleInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_location_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_kill_cnt = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_city_id = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(11)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_power_rank = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_vip = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_total_pay_price = sp.ReadInt64();}
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_title.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapTitleInfo tmp = new MapTitleInfo();
                    tmp.Decode(sp);
                    m_title.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_jid = sp.ReadString();}
            if (sp.TryRead(17)) {m_likeNum = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_Islike = sp.ReadBoolean();}
            if (sp.TryRead(19)) {m_sign = sp.ReadString();}
            if (sp.TryRead(20)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(21)) {m_lang = sp.ReadSByte();}
            if (sp.TryRead(22)) {m_national_flag = sp.ReadInt16();}
            if (sp.TryRead(23)) {m_bit_flag = sp.ReadInt16();}
            if (sp.TryRead(24)) {m_new_role = sp.ReadBoolean();}
            if (sp.TryRead(25)) {m_city_energy = sp.ReadInt32();}
            if (sp.TryRead(26)) {m_payload = sp.ReadString();}
            if (sp.TryRead(27)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_avatar_frame.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_avatar_frame.Add(tmp);
                }
            }
            if (sp.TryRead(28)) {m_current_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(29)) {m_bind_reward_state = sp.ReadSByte();}
            if (sp.TryRead(30)) {m_new_sign = sp.ReadString();}
            if (sp.TryRead(31)) {m_favor_agent = sp.ReadInt16();}
            if (sp.TryRead(32)) {m_skin = sp.ReadInt32();}
            if (sp.TryRead(33)) {m_agent_pose = sp.ReadInt16();}
            if (sp.TryRead(34)) {m_faction = sp.ReadInt16();}
            if (sp.TryRead(35)) {m_city_skin = sp.ReadInt16();}
            if (sp.TryRead(36)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_mayor.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MayorInfo tmp = new MayorInfo();
                    tmp.Decode(sp);
                    m_mayor.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(37)) {m_vip_switch = sp.ReadBoolean();}
            if (sp.TryRead(38)) {m_archive_level = sp.ReadInt16();}
            if (sp.TryRead(39)) {m_bit_label = sp.ReadInt64();}
            if (sp.TryRead(40)) {m_city_nameplate = sp.ReadInt16();}
            if (sp.TryRead(41)) {m_chat_bubble = sp.ReadInt16();}
            if (sp.TryRead(42)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_time_limit_avatar_frame.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AvatarFrameId tmp = new AvatarFrameId();
                    tmp.Decode(sp);
                    m_time_limit_avatar_frame.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(43)) {m_server_map = sp.ReadString();}
            if (sp.TryRead(44)) {m_hq_level = sp.ReadInt16();}
            if (sp.TryRead(45)) {m_gender = sp.ReadSByte();}
            if (sp.TryRead(46)) {m_is_modify_gender = sp.ReadBoolean();}
            if (sp.TryRead(47)) {m_kill_points = sp.ReadInt64();}
            if (sp.TryRead(48)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kill_troop_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KillTroopInfo tmp = new KillTroopInfo();
                    tmp.Decode(sp);
                    m_kill_troop_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(49)) {m_city_decoration_pendant = sp.ReadInt16();}
            if (sp.TryRead(50)) {m_city_decoration_hole = sp.ReadInt16();}
            if (sp.TryRead(51)) {m_battle_banner = sp.ReadInt16();}
            if (sp.TryRead(52)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(53)) {m_troop_tail_skin_id = sp.ReadInt16();}
            if (sp.TryRead(54)) {m_city_decoration_counterattack = sp.ReadInt16();}
            if (sp.TryRead(55)) {m_home_background_id = sp.ReadInt32();}
            if (sp.TryRead(56)) {m_home_effect_id = sp.ReadInt32();}
            if (sp.TryRead(57)) {m_base_teleport_effect_id = sp.ReadInt16();}
            if (sp.TryRead(58)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_medal_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMedalSimpleInfo tmp = new UserMedalSimpleInfo();
                    tmp.Decode(sp);
                    m_medal_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_location_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {sp.Write(m_name);}
            if (sp.TryWrite(4)) {sp.Write(m_level);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_power);}
            if (sp.TryWrite(7)) {sp.Write(m_kill_cnt);}
            if (sp.TryWrite(8)) {sp.Write(m_city_id);}
            if (sp.TryWrite(9)) {sp.Write(m_x);}
            if (sp.TryWrite(10)) {sp.Write(m_y);}
            if (sp.TryWrite(11)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(12)) {sp.Write(m_power_rank);}
            if (sp.TryWrite(13)) {sp.Write(m_vip);}
            if (sp.TryWrite(14)) {sp.Write(m_total_pay_price);}
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_title.Count);
                for (int i = 0; i != m_title.Count; ++i) {
                    m_title[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(16)) {sp.Write(m_jid);}
            if (sp.TryWrite(17)) {sp.Write(m_likeNum);}
            if (sp.TryWrite(18)) {sp.Write(m_Islike);}
            if (sp.TryWrite(19)) {sp.Write(m_sign);}
            if (sp.TryWrite(20)) {sp.Write(m_avatar);}
            if (sp.TryWrite(21)) {sp.Write(m_lang);}
            if (sp.TryWrite(22)) {sp.Write(m_national_flag);}
            if (sp.TryWrite(23)) {sp.Write(m_bit_flag);}
            if (sp.TryWrite(24)) {sp.Write(m_new_role);}
            if (sp.TryWrite(25)) {sp.Write(m_city_energy);}
            if (sp.TryWrite(26)) {sp.Write(m_payload);}
            if (sp.TryWrite(27)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_avatar_frame.Count);
                for (int i = 0; i != m_avatar_frame.Count; ++i) {
                    sp.Write(m_avatar_frame[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(28)) {sp.Write(m_current_avatar_frame);}
            if (sp.TryWrite(29)) {sp.Write(m_bind_reward_state);}
            if (sp.TryWrite(30)) {sp.Write(m_new_sign);}
            if (sp.TryWrite(31)) {sp.Write(m_favor_agent);}
            if (sp.TryWrite(32)) {sp.Write(m_skin);}
            if (sp.TryWrite(33)) {sp.Write(m_agent_pose);}
            if (sp.TryWrite(34)) {sp.Write(m_faction);}
            if (sp.TryWrite(35)) {sp.Write(m_city_skin);}
            if (sp.TryWrite(36)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_mayor.Count);
                for (int i = 0; i != m_mayor.Count; ++i) {
                    m_mayor[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(37)) {sp.Write(m_vip_switch);}
            if (sp.TryWrite(38)) {sp.Write(m_archive_level);}
            if (sp.TryWrite(39)) {sp.Write(m_bit_label);}
            if (sp.TryWrite(40)) {sp.Write(m_city_nameplate);}
            if (sp.TryWrite(41)) {sp.Write(m_chat_bubble);}
            if (sp.TryWrite(42)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_time_limit_avatar_frame.Count);
                for (int i = 0; i != m_time_limit_avatar_frame.Count; ++i) {
                    m_time_limit_avatar_frame[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(43)) {sp.Write(m_server_map);}
            if (sp.TryWrite(44)) {sp.Write(m_hq_level);}
            if (sp.TryWrite(45)) {sp.Write(m_gender);}
            if (sp.TryWrite(46)) {sp.Write(m_is_modify_gender);}
            if (sp.TryWrite(47)) {sp.Write(m_kill_points);}
            if (sp.TryWrite(48)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kill_troop_infos.Count);
                for (int i = 0; i != m_kill_troop_infos.Count; ++i) {
                    m_kill_troop_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(49)) {sp.Write(m_city_decoration_pendant);}
            if (sp.TryWrite(50)) {sp.Write(m_city_decoration_hole);}
            if (sp.TryWrite(51)) {sp.Write(m_battle_banner);}
            if (sp.TryWrite(52)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(53)) {sp.Write(m_troop_tail_skin_id);}
            if (sp.TryWrite(54)) {sp.Write(m_city_decoration_counterattack);}
            if (sp.TryWrite(55)) {sp.Write(m_home_background_id);}
            if (sp.TryWrite(56)) {sp.Write(m_home_effect_id);}
            if (sp.TryWrite(57)) {sp.Write(m_base_teleport_effect_id);}
            if (sp.TryWrite(58)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_medal_list.Count);
                for (int i = 0; i != m_medal_list.Count; ++i) {
                    m_medal_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserInfo source) {
            m_id = source.m_id;
            m_location_server_id = source.m_location_server_id;
            m_home_server_id = source.m_home_server_id;
            m_name = source.m_name;
            m_level = source.m_level;
            m_icon = source.m_icon;
            m_power = source.m_power;
            m_kill_cnt = source.m_kill_cnt;
            m_city_id = source.m_city_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_alliance = source.m_alliance;
            m_power_rank = source.m_power_rank;
            m_vip = source.m_vip;
            m_total_pay_price = source.m_total_pay_price;
            m_title = source.m_title;
            m_jid = source.m_jid;
            m_likeNum = source.m_likeNum;
            m_Islike = source.m_Islike;
            m_sign = source.m_sign;
            m_avatar = source.m_avatar;
            m_lang = source.m_lang;
            m_national_flag = source.m_national_flag;
            m_bit_flag = source.m_bit_flag;
            m_new_role = source.m_new_role;
            m_city_energy = source.m_city_energy;
            m_payload = source.m_payload;
            m_avatar_frame = source.m_avatar_frame;
            m_current_avatar_frame = source.m_current_avatar_frame;
            m_bind_reward_state = source.m_bind_reward_state;
            m_new_sign = source.m_new_sign;
            m_favor_agent = source.m_favor_agent;
            m_skin = source.m_skin;
            m_agent_pose = source.m_agent_pose;
            m_faction = source.m_faction;
            m_city_skin = source.m_city_skin;
            m_mayor = source.m_mayor;
            m_vip_switch = source.m_vip_switch;
            m_archive_level = source.m_archive_level;
            m_bit_label = source.m_bit_label;
            m_city_nameplate = source.m_city_nameplate;
            m_chat_bubble = source.m_chat_bubble;
            m_time_limit_avatar_frame = source.m_time_limit_avatar_frame;
            m_server_map = source.m_server_map;
            m_hq_level = source.m_hq_level;
            m_gender = source.m_gender;
            m_is_modify_gender = source.m_is_modify_gender;
            m_kill_points = source.m_kill_points;
            m_kill_troop_infos = source.m_kill_troop_infos;
            m_city_decoration_pendant = source.m_city_decoration_pendant;
            m_city_decoration_hole = source.m_city_decoration_hole;
            m_battle_banner = source.m_battle_banner;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
            m_city_decoration_counterattack = source.m_city_decoration_counterattack;
            m_home_background_id = source.m_home_background_id;
            m_home_effect_id = source.m_home_effect_id;
            m_base_teleport_effect_id = source.m_base_teleport_effect_id;
            m_medal_list = source.m_medal_list;
        }
    }
    
    [Serializable]
    public partial class BuildReqInfo : NetworkMessage {
        public static int[] Id = { 12,1 };
        public static Ctrl VC;
        public Int16 m_build_type;
        public Int16 m_pos;
        public Boolean m_instant;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_build_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_pos = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_instant = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_build_type);}
            if (sp.TryWrite(1)) {sp.Write(m_pos);}
            if (sp.TryWrite(2)) {sp.Write(m_instant);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildReqInfo source) {
            m_build_type = source.m_build_type;
            m_pos = source.m_pos;
            m_instant = source.m_instant;
        }
    }
    
    [Serializable]
    public partial class BuildingProgInfo : NetworkMessage {
        public static int[] Id = { 18,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_prog_type;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int16 m_queue_id;
        public Boolean m_joined_as;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_prog_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_queue_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_joined_as = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_prog_type);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(3)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(4)) {sp.Write(m_queue_id);}
            if (sp.TryWrite(5)) {sp.Write(m_joined_as);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingProgInfo source) {
            m_id = source.m_id;
            m_prog_type = source.m_prog_type;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_queue_id = source.m_queue_id;
            m_joined_as = source.m_joined_as;
        }
    }
    
    [Serializable]
    public partial class TroopProgInfo : NetworkMessage {
        public static int[] Id = { 24,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Int32 m_prog_id;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Boolean m_is_wait;
        public TroopTrainingCapInfo m_cap_bonus;

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
            if (sp.TryRead(1)) {m_prog_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_is_wait = sp.ReadBoolean();}
            if (sp.TryRead(5)) {
                m_cap_bonus = new TroopTrainingCapInfo();
                m_cap_bonus.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(1)) {sp.Write(m_prog_id);}
            if (sp.TryWrite(2)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(3)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(4)) {sp.Write(m_is_wait);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_cap_bonus.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopProgInfo source) {
            m_troops = source.m_troops;
            m_prog_id = source.m_prog_id;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_is_wait = source.m_is_wait;
            m_cap_bonus = source.m_cap_bonus;
        }
    }
    
    [Serializable]
    public partial class FightResInfo : NetworkMessage {
        public static int[] Id = { 30,1 };
        public static Ctrl VC;
        public SByte m_res_type;
        public Int64 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_res_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_res_type);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FightResInfo source) {
            m_res_type = source.m_res_type;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class FightUserV1 : NetworkMessage {
        public static int[] Id = { 36,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int64 m_power;
        public Int64 m_exp;
        public Int16 m_icon;
        public UserAllianceBrief m_alliance;
        public List<BuffNtfInfo> m_buff_list = new List<BuffNtfInfo>();
        public List<FightTroop> m_troop = new List<FightTroop>();
        public FightStatistic m_stat;
        public List<FightArmyLost> m_lost_list = new List<FightArmyLost>();
        public FightLoot m_loot;
        public List<MilitaryGoods> m_items = new List<MilitaryGoods>();
        public StyleInfo m_style;
        public List<DetailStyle> m_tandp = new List<DetailStyle>();
        public List<FightArmyJoin> m_join_list = new List<FightArmyJoin>();
        public Int16 m_home_server_id;
        public String m_avatar = "";
        public List<FightAgentInfo> m_agent = new List<FightAgentInfo>();
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_exp = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buff_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_buff_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troop.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightTroop tmp = new FightTroop();
                    tmp.Decode(sp);
                    m_troop.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                m_stat = new FightStatistic();
                m_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_lost_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightArmyLost tmp = new FightArmyLost();
                    tmp.Decode(sp);
                    m_lost_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                m_loot = new FightLoot();
                m_loot.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MilitaryGoods tmp = new MilitaryGoods();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {
                m_style = new StyleInfo();
                m_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tandp.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DetailStyle tmp = new DetailStyle();
                    tmp.Decode(sp);
                    m_tandp.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_join_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightArmyJoin tmp = new FightArmyJoin();
                    tmp.Decode(sp);
                    m_join_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(16)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightAgentInfo tmp = new FightAgentInfo();
                    tmp.Decode(sp);
                    m_agent.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(18)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_power);}
            if (sp.TryWrite(3)) {sp.Write(m_exp);}
            if (sp.TryWrite(4)) {sp.Write(m_icon);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_list.Count);
                for (int i = 0; i != m_buff_list.Count; ++i) {
                    m_buff_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troop.Count);
                for (int i = 0; i != m_troop.Count; ++i) {
                    m_troop[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_lost_list.Count);
                for (int i = 0; i != m_lost_list.Count; ++i) {
                    m_lost_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_loot.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(12)) {int pos = sp.GetPos();sp.Skip(2); m_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tandp.Count);
                for (int i = 0; i != m_tandp.Count; ++i) {
                    m_tandp[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_join_list.Count);
                for (int i = 0; i != m_join_list.Count; ++i) {
                    m_join_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(16)) {sp.Write(m_avatar);}
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    m_agent[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(18)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(FightUserV1 source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_power = source.m_power;
            m_exp = source.m_exp;
            m_icon = source.m_icon;
            m_alliance = source.m_alliance;
            m_buff_list = source.m_buff_list;
            m_troop = source.m_troop;
            m_stat = source.m_stat;
            m_lost_list = source.m_lost_list;
            m_loot = source.m_loot;
            m_items = source.m_items;
            m_style = source.m_style;
            m_tandp = source.m_tandp;
            m_join_list = source.m_join_list;
            m_home_server_id = source.m_home_server_id;
            m_avatar = source.m_avatar;
            m_agent = source.m_agent;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class LoseInfoGve : NetworkMessage {
        public static int[] Id = { 42,1 };
        public static Ctrl VC;
        public Int64 m_troop_lost_cnt;
        public Int64 m_trap_lost_cnt;
        public Int64 m_power_lost;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_troop_lost_cnt = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_trap_lost_cnt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_power_lost = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_troop_lost_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_trap_lost_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_power_lost);}
            sp.EnEnd();
        }
        public void CopyFrom(LoseInfoGve source) {
            m_troop_lost_cnt = source.m_troop_lost_cnt;
            m_trap_lost_cnt = source.m_trap_lost_cnt;
            m_power_lost = source.m_power_lost;
        }
    }
    
    [Serializable]
    public partial class DamageAction : NetworkMessage {
        public static int[] Id = { 48,1 };
        public static Ctrl VC;
        public Int16 m_action_id;
        public Boolean m_is_p1;
        public Int16 m_atk_type;
        public Int16 m_def_type;
        public Int64 m_damage;
        public Int64 m_hp;
        public Int16 m_model;
        public EffectAction m_effect;
        public Int32 m_ability;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_atk_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_def_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_hp = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_model = sp.ReadInt16();}
            if (sp.TryRead(7)) {
                m_effect = new EffectAction();
                m_effect.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_ability = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(2)) {sp.Write(m_atk_type);}
            if (sp.TryWrite(3)) {sp.Write(m_def_type);}
            if (sp.TryWrite(4)) {sp.Write(m_damage);}
            if (sp.TryWrite(5)) {sp.Write(m_hp);}
            if (sp.TryWrite(6)) {sp.Write(m_model);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_effect.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_ability);}
            sp.EnEnd();
        }
        public void CopyFrom(DamageAction source) {
            m_action_id = source.m_action_id;
            m_is_p1 = source.m_is_p1;
            m_atk_type = source.m_atk_type;
            m_def_type = source.m_def_type;
            m_damage = source.m_damage;
            m_hp = source.m_hp;
            m_model = source.m_model;
            m_effect = source.m_effect;
            m_ability = source.m_ability;
        }
    }
    
    [Serializable]
    public partial class LanderTile : NetworkMessage {
        public static int[] Id = { 54,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_owner;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public Int64 m_land_time;
        public Int64 m_burning_time;
        public Int64 m_group_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_name = sp.ReadString();}
            if (sp.TryRead(5)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_land_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_burning_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_group_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_owner);}
            if (sp.TryWrite(4)) {sp.Write(m_name);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_land_time);}
            if (sp.TryWrite(7)) {sp.Write(m_burning_time);}
            if (sp.TryWrite(8)) {sp.Write(m_group_id);}
            sp.EnEnd();
        }
        public void CopyFrom(LanderTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_owner = source.m_owner;
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_land_time = source.m_land_time;
            m_burning_time = source.m_burning_time;
            m_group_id = source.m_group_id;
        }
    }
    
    [Serializable]
    public partial class TerritoryInfo : NetworkMessage {
        public static int[] Id = { 60,1 };
        public static Ctrl VC;
        public AllianceSnapInfo m_landalliance;
        public List<LandTileInfo> m_area = new List<LandTileInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_landalliance = new AllianceSnapInfo();
                m_landalliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_area.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LandTileInfo tmp = new LandTileInfo();
                    tmp.Decode(sp);
                    m_area.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_landalliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_area.Count);
                for (int i = 0; i != m_area.Count; ++i) {
                    m_area[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TerritoryInfo source) {
            m_landalliance = source.m_landalliance;
            m_area = source.m_area;
        }
    }
    
    [Serializable]
    public partial class TileDetailInfo : NetworkMessage {
        public static int[] Id = { 66,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_level;
        public SByte m_tile_type;
        public Int64 m_owner;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public Int16 m_status;
        public Int64 m_cnt;
        public Int64 m_gather_speed;
        public Int64 m_gather_time;
        public Int64 m_fighting;
        public List<Int16> m_fighting_army = new List<Int16>();
        public Int16 m_fighting_type;
        public Int64 m_capacity;
        public AllianceSnapInfo m_landalliance;
        public Int64 m_landtime;
        public Int64 m_endtime;
        public SByte m_character;
        public UserAllianceBrief m_belong;
        public Int16 m_land_home_server_id;
        public ItemTileInfo m_item_tile;
        public Int64 m_rebel_owner;
        public Int16 m_rebel_level;
        public SByte m_rebel_stat;
        public Int16 m_rebel_cfgid;
        public Int32 m_building_type;
        public Int64 m_building_id;
        public SByte m_building_subtype;
        public Boolean m_is_finished;
        public Boolean m_is_burning;
        public Int64 m_durability_max;
        public Int64 m_durability;
        public Int64 m_durability_speed;
        public Int64 m_build_remain;
        public Int64 m_build_remain_speed;
        public Int64 m_build_remain_max;
        public Int64 m_pof_cost;
        public Int64 m_gather_cnt;
        public Int64 m_map_guid;
        public Int64 m_total_cnt_left;
        public Int64 m_total_gather_speed;
        public Int64 m_group_id;
        public Int64 m_last_update_time;
        public Int64 m_force_burn_end_time;
        public Int32 m_burn_slow_down_ratio;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_tile_type = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_name = sp.ReadString();}
            if (sp.TryRead(7)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_cnt = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_gather_speed = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_gather_time = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fighting_army.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_fighting_army.Add(tmp);
                }
            }
            if (sp.TryRead(14)) {m_fighting_type = sp.ReadInt16();}
            if (sp.TryRead(15)) {m_capacity = sp.ReadInt64();}
            if (sp.TryRead(16)) {
                m_landalliance = new AllianceSnapInfo();
                m_landalliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_landtime = sp.ReadInt64();}
            if (sp.TryRead(18)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(19)) {m_character = sp.ReadSByte();}
            if (sp.TryRead(20)) {
                m_belong = new UserAllianceBrief();
                m_belong.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(21)) {m_land_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(22)) {
                m_item_tile = new ItemTileInfo();
                m_item_tile.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(23)) {m_rebel_owner = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_rebel_level = sp.ReadInt16();}
            if (sp.TryRead(25)) {m_rebel_stat = sp.ReadSByte();}
            if (sp.TryRead(26)) {m_rebel_cfgid = sp.ReadInt16();}
            if (sp.TryRead(27)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(28)) {m_building_id = sp.ReadInt64();}
            if (sp.TryRead(29)) {m_building_subtype = sp.ReadSByte();}
            if (sp.TryRead(30)) {m_is_finished = sp.ReadBoolean();}
            if (sp.TryRead(31)) {m_is_burning = sp.ReadBoolean();}
            if (sp.TryRead(32)) {m_durability_max = sp.ReadInt64();}
            if (sp.TryRead(33)) {m_durability = sp.ReadInt64();}
            if (sp.TryRead(34)) {m_durability_speed = sp.ReadInt64();}
            if (sp.TryRead(35)) {m_build_remain = sp.ReadInt64();}
            if (sp.TryRead(36)) {m_build_remain_speed = sp.ReadInt64();}
            if (sp.TryRead(37)) {m_build_remain_max = sp.ReadInt64();}
            if (sp.TryRead(38)) {m_pof_cost = sp.ReadInt64();}
            if (sp.TryRead(39)) {m_gather_cnt = sp.ReadInt64();}
            if (sp.TryRead(40)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(41)) {m_total_cnt_left = sp.ReadInt64();}
            if (sp.TryRead(42)) {m_total_gather_speed = sp.ReadInt64();}
            if (sp.TryRead(43)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(44)) {m_last_update_time = sp.ReadInt64();}
            if (sp.TryRead(45)) {m_force_burn_end_time = sp.ReadInt64();}
            if (sp.TryRead(46)) {m_burn_slow_down_ratio = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_tile_type);}
            if (sp.TryWrite(5)) {sp.Write(m_owner);}
            if (sp.TryWrite(6)) {sp.Write(m_name);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_status);}
            if (sp.TryWrite(9)) {sp.Write(m_cnt);}
            if (sp.TryWrite(10)) {sp.Write(m_gather_speed);}
            if (sp.TryWrite(11)) {sp.Write(m_gather_time);}
            if (sp.TryWrite(12)) {sp.Write(m_fighting);}
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fighting_army.Count);
                for (int i = 0; i != m_fighting_army.Count; ++i) {
                    sp.Write(m_fighting_army[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(14)) {sp.Write(m_fighting_type);}
            if (sp.TryWrite(15)) {sp.Write(m_capacity);}
            if (sp.TryWrite(16)) {int pos = sp.GetPos();sp.Skip(2); m_landalliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(17)) {sp.Write(m_landtime);}
            if (sp.TryWrite(18)) {sp.Write(m_endtime);}
            if (sp.TryWrite(19)) {sp.Write(m_character);}
            if (sp.TryWrite(20)) {int pos = sp.GetPos();sp.Skip(2); m_belong.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(21)) {sp.Write(m_land_home_server_id);}
            if (sp.TryWrite(22)) {int pos = sp.GetPos();sp.Skip(2); m_item_tile.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(23)) {sp.Write(m_rebel_owner);}
            if (sp.TryWrite(24)) {sp.Write(m_rebel_level);}
            if (sp.TryWrite(25)) {sp.Write(m_rebel_stat);}
            if (sp.TryWrite(26)) {sp.Write(m_rebel_cfgid);}
            if (sp.TryWrite(27)) {sp.Write(m_building_type);}
            if (sp.TryWrite(28)) {sp.Write(m_building_id);}
            if (sp.TryWrite(29)) {sp.Write(m_building_subtype);}
            if (sp.TryWrite(30)) {sp.Write(m_is_finished);}
            if (sp.TryWrite(31)) {sp.Write(m_is_burning);}
            if (sp.TryWrite(32)) {sp.Write(m_durability_max);}
            if (sp.TryWrite(33)) {sp.Write(m_durability);}
            if (sp.TryWrite(34)) {sp.Write(m_durability_speed);}
            if (sp.TryWrite(35)) {sp.Write(m_build_remain);}
            if (sp.TryWrite(36)) {sp.Write(m_build_remain_speed);}
            if (sp.TryWrite(37)) {sp.Write(m_build_remain_max);}
            if (sp.TryWrite(38)) {sp.Write(m_pof_cost);}
            if (sp.TryWrite(39)) {sp.Write(m_gather_cnt);}
            if (sp.TryWrite(40)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(41)) {sp.Write(m_total_cnt_left);}
            if (sp.TryWrite(42)) {sp.Write(m_total_gather_speed);}
            if (sp.TryWrite(43)) {sp.Write(m_group_id);}
            if (sp.TryWrite(44)) {sp.Write(m_last_update_time);}
            if (sp.TryWrite(45)) {sp.Write(m_force_burn_end_time);}
            if (sp.TryWrite(46)) {sp.Write(m_burn_slow_down_ratio);}
            sp.EnEnd();
        }
        public void CopyFrom(TileDetailInfo source) {
            m_server_id = source.m_server_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_level = source.m_level;
            m_tile_type = source.m_tile_type;
            m_owner = source.m_owner;
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_status = source.m_status;
            m_cnt = source.m_cnt;
            m_gather_speed = source.m_gather_speed;
            m_gather_time = source.m_gather_time;
            m_fighting = source.m_fighting;
            m_fighting_army = source.m_fighting_army;
            m_fighting_type = source.m_fighting_type;
            m_capacity = source.m_capacity;
            m_landalliance = source.m_landalliance;
            m_landtime = source.m_landtime;
            m_endtime = source.m_endtime;
            m_character = source.m_character;
            m_belong = source.m_belong;
            m_land_home_server_id = source.m_land_home_server_id;
            m_item_tile = source.m_item_tile;
            m_rebel_owner = source.m_rebel_owner;
            m_rebel_level = source.m_rebel_level;
            m_rebel_stat = source.m_rebel_stat;
            m_rebel_cfgid = source.m_rebel_cfgid;
            m_building_type = source.m_building_type;
            m_building_id = source.m_building_id;
            m_building_subtype = source.m_building_subtype;
            m_is_finished = source.m_is_finished;
            m_is_burning = source.m_is_burning;
            m_durability_max = source.m_durability_max;
            m_durability = source.m_durability;
            m_durability_speed = source.m_durability_speed;
            m_build_remain = source.m_build_remain;
            m_build_remain_speed = source.m_build_remain_speed;
            m_build_remain_max = source.m_build_remain_max;
            m_pof_cost = source.m_pof_cost;
            m_gather_cnt = source.m_gather_cnt;
            m_map_guid = source.m_map_guid;
            m_total_cnt_left = source.m_total_cnt_left;
            m_total_gather_speed = source.m_total_gather_speed;
            m_group_id = source.m_group_id;
            m_last_update_time = source.m_last_update_time;
            m_force_burn_end_time = source.m_force_burn_end_time;
            m_burn_slow_down_ratio = source.m_burn_slow_down_ratio;
        }
    }
    
    [Serializable]
    public partial class AllianceListInfo : NetworkMessage {
        public static int[] Id = { 72,1 };
        public static Ctrl VC;
        public List<AllianceBriefInfo> m_alliance_list = new List<AllianceBriefInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBriefInfo tmp = new AllianceBriefInfo();
                    tmp.Decode(sp);
                    m_alliance_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_list.Count);
                for (int i = 0; i != m_alliance_list.Count; ++i) {
                    m_alliance_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceListInfo source) {
            m_alliance_list = source.m_alliance_list;
        }
    }
    
    [Serializable]
    public partial class UserMapInfo : NetworkMessage {
        public static int[] Id = { 78,1 };
        public static Ctrl VC;
        public List<UserMapGroup> m_groups = new List<UserMapGroup>();
        public List<UserMapMarch> m_march_list = new List<UserMapMarch>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMapGroup tmp = new UserMapGroup();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMapMarch tmp = new UserMapMarch();
                    tmp.Decode(sp);
                    m_march_list.Add(tmp);
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
                sp.Write((UInt16)m_groups.Count);
                for (int i = 0; i != m_groups.Count; ++i) {
                    m_groups[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_march_list.Count);
                for (int i = 0; i != m_march_list.Count; ++i) {
                    m_march_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(UserMapInfo source) {
            m_groups = source.m_groups;
            m_march_list = source.m_march_list;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class Receivers : NetworkMessage {
        public static int[] Id = { 84,1 };
        public static Ctrl VC;
        public List<ContactInfo> m_receiver_list = new List<ContactInfo>();
        public Int32 m_as_id;
        public String m_as_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_receiver_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ContactInfo tmp = new ContactInfo();
                    tmp.Decode(sp);
                    m_receiver_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_as_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_as_abbr = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_receiver_list.Count);
                for (int i = 0; i != m_receiver_list.Count; ++i) {
                    m_receiver_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_as_id);}
            if (sp.TryWrite(2)) {sp.Write(m_as_abbr);}
            sp.EnEnd();
        }
        public void CopyFrom(Receivers source) {
            m_receiver_list = source.m_receiver_list;
            m_as_id = source.m_as_id;
            m_as_abbr = source.m_as_abbr;
        }
    }
    
    [Serializable]
    public partial class HeroExecutedReportBaseInfo : NetworkMessage {
        public static int[] Id = { 90,1 };
        public static Ctrl VC;
        public Int16 m_icon;
        public CaptorsInfo m_captors;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_captors = new CaptorsInfo();
                m_captors.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_icon);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_captors.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(HeroExecutedReportBaseInfo source) {
            m_icon = source.m_icon;
            m_captors = source.m_captors;
        }
    }
    
    [Serializable]
    public partial class LostItemReportBaseInfo : NetworkMessage {
        public static int[] Id = { 96,1 };
        public static Ctrl VC;
        public String m_title = "";
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title = sp.ReadString();}
            if (sp.TryRead(1)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title);}
            if (sp.TryWrite(1)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(LostItemReportBaseInfo source) {
            m_title = source.m_title;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class RebelRewardReportBaseInfo : NetworkMessage {
        public static int[] Id = { 102,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_id;
        public Int16 m_level;
        public SByte m_stat;
        public Int16 m_cfg_id;
        public Int64 m_owner;
        public String m_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_name = sp.ReadString();}
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
            if (sp.TryWrite(7)) {sp.Write(m_owner);}
            if (sp.TryWrite(8)) {sp.Write(m_name);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelRewardReportBaseInfo source) {
            m_type = source.m_type;
            m_x = source.m_x;
            m_y = source.m_y;
            m_id = source.m_id;
            m_level = source.m_level;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
            m_owner = source.m_owner;
            m_name = source.m_name;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryReportDetailInfo : NetworkMessage {
        public static int[] Id = { 108,1 };
        public static Ctrl VC;
        public AllianceSalaryReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceSalaryReportBaseInfo();
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
        public void CopyFrom(AllianceSalaryReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class MonumentScoutReportDetailInfo : NetworkMessage {
        public static int[] Id = { 114,1 };
        public static Ctrl VC;
        public MonumentScoutReportBaseInfo m_base_info;
        public StyleInfo m_def_style;
        public StyleInfo m_atk_style;
        public List<TroopGroup> m_troops = new List<TroopGroup>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new MonumentScoutReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_def_style = new StyleInfo();
                m_def_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_atk_style = new StyleInfo();
                m_atk_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
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
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_def_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_atk_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
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
        public void CopyFrom(MonumentScoutReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_def_style = source.m_def_style;
            m_atk_style = source.m_atk_style;
            m_troops = source.m_troops;
        }
    }
    
    [Serializable]
    public partial class RecvResReportDetailInfo : NetworkMessage {
        public static int[] Id = { 120,1 };
        public static Ctrl VC;
        public RecvResReportBaseInfo m_base_info;
        public List<FightResInfo> m_res_info = new List<FightResInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RecvResReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightResInfo tmp = new FightResInfo();
                    tmp.Decode(sp);
                    m_res_info.Add(tmp);
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
                sp.Write((UInt16)m_res_info.Count);
                for (int i = 0; i != m_res_info.Count; ++i) {
                    m_res_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RecvResReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_res_info = source.m_res_info;
        }
    }
    
    [Serializable]
    public partial class SystemReportDetailInfo : NetworkMessage {
        public static int[] Id = { 126,1 };
        public static Ctrl VC;
        public SystemReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new SystemReportBaseInfo();
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
        public void CopyFrom(SystemReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class ResearchDetailInfo : NetworkMessage {
        public static int[] Id = { 132,1 };
        public static Ctrl VC;
        public ResearchBaseInfo m_base_info;
        public Int16 m_effect_id;
        public Int64 m_effect_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ResearchBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_effect_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_effect_num = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_effect_id);}
            if (sp.TryWrite(2)) {sp.Write(m_effect_num);}
            sp.EnEnd();
        }
        public void CopyFrom(ResearchDetailInfo source) {
            m_base_info = source.m_base_info;
            m_effect_id = source.m_effect_id;
            m_effect_num = source.m_effect_num;
        }
    }
    
    [Serializable]
    public partial class UpgradeResearchAckInfo : NetworkMessage {
        public static int[] Id = { 138,1 };
        public static Ctrl VC;
        public ResearchBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ResearchBaseInfo();
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
        public void CopyFrom(UpgradeResearchAckInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class DailyQuestInfo : NetworkMessage {
        public static int[] Id = { 144,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_dtype;
        public Int32 m_dclass;
        public Int32 m_status;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_need_time;
        public Int32 m_food_award;
        public Int32 m_energy_award;
        public Int32 m_oil_award;
        public Int32 m_steel_award;
        public Int32 m_cash_award;
        public Int32 m_item1_award;
        public Int32 m_item1_cnt;
        public Int32 m_item2_award;
        public Int32 m_item2_cnt;
        public Int32 m_exp_award;
        public Int32 m_loyal;
        public Int32 m_funds;
        public Int32 m_chips_award;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_dtype = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_dclass = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_status = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_need_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_food_award = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_energy_award = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_oil_award = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_steel_award = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_cash_award = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_item1_award = sp.ReadInt32();}
            if (sp.TryRead(13)) {m_item1_cnt = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_item2_award = sp.ReadInt32();}
            if (sp.TryRead(15)) {m_item2_cnt = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_exp_award = sp.ReadInt32();}
            if (sp.TryRead(17)) {m_loyal = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_funds = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_chips_award = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_dtype);}
            if (sp.TryWrite(2)) {sp.Write(m_dclass);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            if (sp.TryWrite(4)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(5)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(6)) {sp.Write(m_need_time);}
            if (sp.TryWrite(7)) {sp.Write(m_food_award);}
            if (sp.TryWrite(8)) {sp.Write(m_energy_award);}
            if (sp.TryWrite(9)) {sp.Write(m_oil_award);}
            if (sp.TryWrite(10)) {sp.Write(m_steel_award);}
            if (sp.TryWrite(11)) {sp.Write(m_cash_award);}
            if (sp.TryWrite(12)) {sp.Write(m_item1_award);}
            if (sp.TryWrite(13)) {sp.Write(m_item1_cnt);}
            if (sp.TryWrite(14)) {sp.Write(m_item2_award);}
            if (sp.TryWrite(15)) {sp.Write(m_item2_cnt);}
            if (sp.TryWrite(16)) {sp.Write(m_exp_award);}
            if (sp.TryWrite(17)) {sp.Write(m_loyal);}
            if (sp.TryWrite(18)) {sp.Write(m_funds);}
            if (sp.TryWrite(19)) {sp.Write(m_chips_award);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyQuestInfo source) {
            m_id = source.m_id;
            m_dtype = source.m_dtype;
            m_dclass = source.m_dclass;
            m_status = source.m_status;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_need_time = source.m_need_time;
            m_food_award = source.m_food_award;
            m_energy_award = source.m_energy_award;
            m_oil_award = source.m_oil_award;
            m_steel_award = source.m_steel_award;
            m_cash_award = source.m_cash_award;
            m_item1_award = source.m_item1_award;
            m_item1_cnt = source.m_item1_cnt;
            m_item2_award = source.m_item2_award;
            m_item2_cnt = source.m_item2_cnt;
            m_exp_award = source.m_exp_award;
            m_loyal = source.m_loyal;
            m_funds = source.m_funds;
            m_chips_award = source.m_chips_award;
        }
    }
    
    [Serializable]
    public partial class GetDailyQuestRewardAckInfo : NetworkMessage {
        public static int[] Id = { 150,1 };
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
        public void CopyFrom(GetDailyQuestRewardAckInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class QuestGetRewardReqInfo : NetworkMessage {
        public static int[] Id = { 156,1 };
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
        public void CopyFrom(QuestGetRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class GroupAgentInfo : NetworkMessage {
        public static int[] Id = { 162,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_level;
        public Int32 m_weapon_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_weapon_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_weapon_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GroupAgentInfo source) {
            m_id = source.m_id;
            m_level = source.m_level;
            m_weapon_id = source.m_weapon_id;
        }
    }
    
    [Serializable]
    public partial class RallyListInfo : NetworkMessage {
        public static int[] Id = { 168,1 };
        public static Ctrl VC;
        public List<RallyInfo> m_rally_list = new List<RallyInfo>();
        public List<DefenceInfo> m_defence_list = new List<DefenceInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rally_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RallyInfo tmp = new RallyInfo();
                    tmp.Decode(sp);
                    m_rally_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defence_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DefenceInfo tmp = new DefenceInfo();
                    tmp.Decode(sp);
                    m_defence_list.Add(tmp);
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
                sp.Write((UInt16)m_rally_list.Count);
                for (int i = 0; i != m_rally_list.Count; ++i) {
                    m_rally_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defence_list.Count);
                for (int i = 0; i != m_defence_list.Count; ++i) {
                    m_defence_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(RallyListInfo source) {
            m_rally_list = source.m_rally_list;
            m_defence_list = source.m_defence_list;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class SpeedupInfo : NetworkMessage {
        public static int[] Id = { 174,1 };
        public static Ctrl VC;
        public Int32 m_speedup_count;
        public Int16 m_speedup_type;
        public Int32 m_speedup_item_type;
        public Int32 m_speedup_buy_type;
        public Int32 m_target;
        public Int32 m_param;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_speedup_count = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_speedup_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_speedup_item_type = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_speedup_buy_type = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_target = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_param = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_speedup_count);}
            if (sp.TryWrite(1)) {sp.Write(m_speedup_type);}
            if (sp.TryWrite(2)) {sp.Write(m_speedup_item_type);}
            if (sp.TryWrite(3)) {sp.Write(m_speedup_buy_type);}
            if (sp.TryWrite(4)) {sp.Write(m_target);}
            if (sp.TryWrite(5)) {sp.Write(m_param);}
            if (sp.TryWrite(6)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(SpeedupInfo source) {
            m_speedup_count = source.m_speedup_count;
            m_speedup_type = source.m_speedup_type;
            m_speedup_item_type = source.m_speedup_item_type;
            m_speedup_buy_type = source.m_speedup_buy_type;
            m_target = source.m_target;
            m_param = source.m_param;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GmCmdReq : NetworkMessage {
        public static int[] Id = { 180,1 };
        public static Ctrl VC;
        public String m_cmd = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cmd = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cmd);}
            sp.EnEnd();
        }
        public void CopyFrom(GmCmdReq source) {
            m_cmd = source.m_cmd;
        }
    }
    
    [Serializable]
    public partial class AllianceListHelpInfo : NetworkMessage {
        public static int[] Id = { 186,1 };
        public static Ctrl VC;
        public List<AllianceHelpInfo> m_helps = new List<AllianceHelpInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_helps.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceHelpInfo tmp = new AllianceHelpInfo();
                    tmp.Decode(sp);
                    m_helps.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_helps.Count);
                for (int i = 0; i != m_helps.Count; ++i) {
                    m_helps[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceListHelpInfo source) {
            m_helps = source.m_helps;
        }
    }
    
    [Serializable]
    public partial class AllianceRanklistReq : NetworkMessage {
        public static int[] Id = { 192,1 };
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
        public void CopyFrom(AllianceRanklistReq source) {
            m_type = source.m_type;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class RepairFactoryInfo : NetworkMessage {
        public static int[] Id = { 198,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_repairing_list = new List<ArmyInfo>();
        public List<ArmyInfo> m_pending_list = new List<ArmyInfo>();
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Boolean m_joined_as;
        public Int64 m_map_guid;
        public Int32 m_daily_help_count;
        public Int32 m_max_repair_help_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_repairing_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_repairing_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pending_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_pending_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_joined_as = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_daily_help_count = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_max_repair_help_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_repairing_list.Count);
                for (int i = 0; i != m_repairing_list.Count; ++i) {
                    m_repairing_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pending_list.Count);
                for (int i = 0; i != m_pending_list.Count; ++i) {
                    m_pending_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(3)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(4)) {sp.Write(m_joined_as);}
            if (sp.TryWrite(5)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(6)) {sp.Write(m_daily_help_count);}
            if (sp.TryWrite(7)) {sp.Write(m_max_repair_help_count);}
            sp.EnEnd();
        }
        public void CopyFrom(RepairFactoryInfo source) {
            m_repairing_list = source.m_repairing_list;
            m_pending_list = source.m_pending_list;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_joined_as = source.m_joined_as;
            m_map_guid = source.m_map_guid;
            m_daily_help_count = source.m_daily_help_count;
            m_max_repair_help_count = source.m_max_repair_help_count;
        }
    }
    
    [Serializable]
    public partial class BuyResInfo : NetworkMessage {
        public static int[] Id = { 204,1 };
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
        public void CopyFrom(BuyResInfo source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class BeReinforceInfo : NetworkMessage {
        public static int[] Id = { 210,1 };
        public static Ctrl VC;
        public TilePos m_reinforce_pos;
        public Int64 m_reinforce_user_id;
        public String m_reinforce_user_name = "";
        public UserAllianceBrief m_reinforce_user_alliance;
        public Int16 m_reinforce_icon;
        public String m_reinforce_avatar = "";
        public Int16 m_reinforce_avatar_frame;
        public Boolean m_is_rally;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public List<TroopGroup> m_troops = new List<TroopGroup>();
        public BeAtkHero m_hero;
        public Int64 m_reinforce_march_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_reinforce_pos = new TilePos();
                m_reinforce_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_reinforce_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_reinforce_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {
                m_reinforce_user_alliance = new UserAllianceBrief();
                m_reinforce_user_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_reinforce_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_reinforce_avatar = sp.ReadString();}
            if (sp.TryRead(6)) {m_reinforce_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_is_rally = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                m_hero = new BeAtkHero();
                m_hero.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_reinforce_march_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_reinforce_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_reinforce_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_reinforce_user_name);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_reinforce_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_reinforce_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_reinforce_avatar);}
            if (sp.TryWrite(6)) {sp.Write(m_reinforce_avatar_frame);}
            if (sp.TryWrite(7)) {sp.Write(m_is_rally);}
            if (sp.TryWrite(8)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(9)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {int pos = sp.GetPos();sp.Skip(2); m_hero.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(12)) {sp.Write(m_reinforce_march_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BeReinforceInfo source) {
            m_reinforce_pos = source.m_reinforce_pos;
            m_reinforce_user_id = source.m_reinforce_user_id;
            m_reinforce_user_name = source.m_reinforce_user_name;
            m_reinforce_user_alliance = source.m_reinforce_user_alliance;
            m_reinforce_icon = source.m_reinforce_icon;
            m_reinforce_avatar = source.m_reinforce_avatar;
            m_reinforce_avatar_frame = source.m_reinforce_avatar_frame;
            m_is_rally = source.m_is_rally;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_troops = source.m_troops;
            m_hero = source.m_hero;
            m_reinforce_march_id = source.m_reinforce_march_id;
        }
    }
    
    [Serializable]
    public partial class SendResInfo : NetworkMessage {
        public static int[] Id = { 216,1 };
        public static Ctrl VC;
        public SByte m_res_type;
        public Int64 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_res_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_res_type);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(SendResInfo source) {
            m_res_type = source.m_res_type;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class UpdateAllianceBriefInfo : NetworkMessage {
        public static int[] Id = { 222,1 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_logo;
        public String m_lang = "";
        public String m_desc = "";
        public String m_headline = "";
        public Int16 m_glory;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_lang = sp.ReadString();}
            if (sp.TryRead(4)) {m_desc = sp.ReadString();}
            if (sp.TryRead(5)) {m_headline = sp.ReadString();}
            if (sp.TryRead(6)) {m_glory = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_logo);}
            if (sp.TryWrite(3)) {sp.Write(m_lang);}
            if (sp.TryWrite(4)) {sp.Write(m_desc);}
            if (sp.TryWrite(5)) {sp.Write(m_headline);}
            if (sp.TryWrite(6)) {sp.Write(m_glory);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdateAllianceBriefInfo source) {
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_logo = source.m_logo;
            m_lang = source.m_lang;
            m_desc = source.m_desc;
            m_headline = source.m_headline;
            m_glory = source.m_glory;
        }
    }
    
    [Serializable]
    public partial class RevokeAllianceInviteInfo : NetworkMessage {
        public static int[] Id = { 228,1 };
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
        public void CopyFrom(RevokeAllianceInviteInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class AllianceResInfo : NetworkMessage {
        public static int[] Id = { 234,1 };
        public static Ctrl VC;
        public List<ResTypeInfo> m_res_info = new List<ResTypeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(AllianceResInfo source) {
            m_res_info = source.m_res_info;
        }
    }
    
    [Serializable]
    public partial class ListAllianceResApplyInfo : NetworkMessage {
        public static int[] Id = { 240,1 };
        public static Ctrl VC;
        public List<AllianceResApplyInfo> m_infos = new List<AllianceResApplyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceResApplyInfo tmp = new AllianceResApplyInfo();
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
        public void CopyFrom(ListAllianceResApplyInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class ListAllianceDominionInfo : NetworkMessage {
        public static int[] Id = { 246,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int32 m_amount;
        public List<DominionInfo> m_infos = new List<DominionInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DominionInfo tmp = new DominionInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
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
        public void CopyFrom(ListAllianceDominionInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_amount = source.m_amount;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class EventRewardParamInfo : NetworkMessage {
        public static int[] Id = { 252,1 };
        public static Ctrl VC;
        public Int64 m_score;
        public SByte m_stat;
        public List<ItemInfo> m_item = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(2)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {sp.Write(m_stat);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(EventRewardParamInfo source) {
            m_score = source.m_score;
            m_stat = source.m_stat;
            m_item = source.m_item;
        }
    }
    
    [Serializable]
    public partial class SearchAllianceReq : NetworkMessage {
        public static int[] Id = { 258,1 };
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
        public void CopyFrom(SearchAllianceReq source) {
            m_prefix = source.m_prefix;
            m_type = source.m_type;
            m_mode = source.m_mode;
        }
    }
    
    [Serializable]
    public partial class OnlineUsersInfo : NetworkMessage {
        public static int[] Id = { 264,1 };
        public static Ctrl VC;
        public Int64 m_num;
        public List<SimpleUserInfo> m_list = new List<SimpleUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_num = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SimpleUserInfo tmp = new SimpleUserInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_num);}
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
        public void CopyFrom(OnlineUsersInfo source) {
            m_num = source.m_num;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ListAllianceJoinApplyInfo : NetworkMessage {
        public static int[] Id = { 270,1 };
        public static Ctrl VC;
        public List<AllianceJoinApplyInfo> m_infos = new List<AllianceJoinApplyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceJoinApplyInfo tmp = new AllianceJoinApplyInfo();
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
        public void CopyFrom(ListAllianceJoinApplyInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class ListAllianceAuthorityInfo : NetworkMessage {
        public static int[] Id = { 276,1 };
        public static Ctrl VC;
        public List<AllianceAuthorityInfo> m_infos = new List<AllianceAuthorityInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceAuthorityInfo tmp = new AllianceAuthorityInfo();
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
        public void CopyFrom(ListAllianceAuthorityInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class SearchUsersInfo : NetworkMessage {
        public static int[] Id = { 282,1 };
        public static Ctrl VC;
        public List<UserBriefInfo> m_users = new List<UserBriefInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserBriefInfo tmp = new UserBriefInfo();
                    tmp.Decode(sp);
                    m_users.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(SearchUsersInfo source) {
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class ListAllianceGiftInfo : NetworkMessage {
        public static int[] Id = { 288,1 };
        public static Ctrl VC;
        public List<AllianceGiftInfo> m_gifts = new List<AllianceGiftInfo>();
        public Boolean m_left;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gifts.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceGiftInfo tmp = new AllianceGiftInfo();
                    tmp.Decode(sp);
                    m_gifts.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_left = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_gifts.Count);
                for (int i = 0; i != m_gifts.Count; ++i) {
                    m_gifts[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_left);}
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceGiftInfo source) {
            m_gifts = source.m_gifts;
            m_left = source.m_left;
        }
    }
    
    [Serializable]
    public partial class IapItemInfo : NetworkMessage {
        public static int[] Id = { 294,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_cnt;
        public SByte m_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_type);}
            sp.EnEnd();
        }
        public void CopyFrom(IapItemInfo source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class IapFinishInfo : NetworkMessage {
        public static int[] Id = { 300,1 };
        public static Ctrl VC;
        public Int32 m_iap_type;
        public SByte m_currency_type;
        public String m_iap_sub_type = "";
        public Int32 m_pay_price;
        public String m_token = "";
        public String m_product_id = "";
        public String m_transaction_id = "";
        public Int32 m_package_id;
        public String m_receipt = "";
        public String m_signature = "";
        public String m_card_id = "";
        public String m_card_pwd = "";
        public String m_payload = "";
        public Int32 m_publisher_channel;
        public String m_currency_type_str = "";
        public Int32 m_actual_charge;
        public String m_locale = "";
        public String m_app_store = "";
        public String m_third_part_device_id = "";
        public String m_attribute = "";
        public Boolean m_inner_flag;
        public String m_app_receipt = "";
        public String m_order_id = "";
        public String m_order_uuid = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_currency_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_iap_sub_type = sp.ReadString();}
            if (sp.TryRead(3)) {m_pay_price = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_token = sp.ReadString();}
            if (sp.TryRead(5)) {m_product_id = sp.ReadString();}
            if (sp.TryRead(6)) {m_transaction_id = sp.ReadString();}
            if (sp.TryRead(7)) {m_package_id = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_receipt = sp.ReadString();}
            if (sp.TryRead(9)) {m_signature = sp.ReadString();}
            if (sp.TryRead(10)) {m_card_id = sp.ReadString();}
            if (sp.TryRead(11)) {m_card_pwd = sp.ReadString();}
            if (sp.TryRead(12)) {m_payload = sp.ReadString();}
            if (sp.TryRead(13)) {m_publisher_channel = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_currency_type_str = sp.ReadString();}
            if (sp.TryRead(15)) {m_actual_charge = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_locale = sp.ReadString();}
            if (sp.TryRead(17)) {m_app_store = sp.ReadString();}
            if (sp.TryRead(18)) {m_third_part_device_id = sp.ReadString();}
            if (sp.TryRead(19)) {m_attribute = sp.ReadString();}
            if (sp.TryRead(20)) {m_inner_flag = sp.ReadBoolean();}
            if (sp.TryRead(21)) {m_app_receipt = sp.ReadString();}
            if (sp.TryRead(22)) {m_order_id = sp.ReadString();}
            if (sp.TryRead(23)) {m_order_uuid = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(1)) {sp.Write(m_currency_type);}
            if (sp.TryWrite(2)) {sp.Write(m_iap_sub_type);}
            if (sp.TryWrite(3)) {sp.Write(m_pay_price);}
            if (sp.TryWrite(4)) {sp.Write(m_token);}
            if (sp.TryWrite(5)) {sp.Write(m_product_id);}
            if (sp.TryWrite(6)) {sp.Write(m_transaction_id);}
            if (sp.TryWrite(7)) {sp.Write(m_package_id);}
            if (sp.TryWrite(8)) {sp.Write(m_receipt);}
            if (sp.TryWrite(9)) {sp.Write(m_signature);}
            if (sp.TryWrite(10)) {sp.Write(m_card_id);}
            if (sp.TryWrite(11)) {sp.Write(m_card_pwd);}
            if (sp.TryWrite(12)) {sp.Write(m_payload);}
            if (sp.TryWrite(13)) {sp.Write(m_publisher_channel);}
            if (sp.TryWrite(14)) {sp.Write(m_currency_type_str);}
            if (sp.TryWrite(15)) {sp.Write(m_actual_charge);}
            if (sp.TryWrite(16)) {sp.Write(m_locale);}
            if (sp.TryWrite(17)) {sp.Write(m_app_store);}
            if (sp.TryWrite(18)) {sp.Write(m_third_part_device_id);}
            if (sp.TryWrite(19)) {sp.Write(m_attribute);}
            if (sp.TryWrite(20)) {sp.Write(m_inner_flag);}
            if (sp.TryWrite(21)) {sp.Write(m_app_receipt);}
            if (sp.TryWrite(22)) {sp.Write(m_order_id);}
            if (sp.TryWrite(23)) {sp.Write(m_order_uuid);}
            sp.EnEnd();
        }
        public void CopyFrom(IapFinishInfo source) {
            m_iap_type = source.m_iap_type;
            m_currency_type = source.m_currency_type;
            m_iap_sub_type = source.m_iap_sub_type;
            m_pay_price = source.m_pay_price;
            m_token = source.m_token;
            m_product_id = source.m_product_id;
            m_transaction_id = source.m_transaction_id;
            m_package_id = source.m_package_id;
            m_receipt = source.m_receipt;
            m_signature = source.m_signature;
            m_card_id = source.m_card_id;
            m_card_pwd = source.m_card_pwd;
            m_payload = source.m_payload;
            m_publisher_channel = source.m_publisher_channel;
            m_currency_type_str = source.m_currency_type_str;
            m_actual_charge = source.m_actual_charge;
            m_locale = source.m_locale;
            m_app_store = source.m_app_store;
            m_third_part_device_id = source.m_third_part_device_id;
            m_attribute = source.m_attribute;
            m_inner_flag = source.m_inner_flag;
            m_app_receipt = source.m_app_receipt;
            m_order_id = source.m_order_id;
            m_order_uuid = source.m_order_uuid;
        }
    }
    
    [Serializable]
    public partial class PushOpenappStatInfo : NetworkMessage {
        public static int[] Id = { 306,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public String m_msg_id = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_msg_id = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {sp.Write(m_msg_id);}
            sp.EnEnd();
        }
        public void CopyFrom(PushOpenappStatInfo source) {
            m_access_token = source.m_access_token;
            m_msg_id = source.m_msg_id;
        }
    }
    
    [Serializable]
    public partial class NewMapmarkInfo : NetworkMessage {
        public static int[] Id = { 312,1 };
        public static Ctrl VC;
        public KtilePos m_pos;
        public String m_comments = "";
        public Int16 m_type;
        public SByte m_catalog;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new KtilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_comments = sp.ReadString();}
            if (sp.TryRead(2)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_catalog = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_comments);}
            if (sp.TryWrite(2)) {sp.Write(m_type);}
            if (sp.TryWrite(3)) {sp.Write(m_catalog);}
            if (sp.TryWrite(4)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(NewMapmarkInfo source) {
            m_pos = source.m_pos;
            m_comments = source.m_comments;
            m_type = source.m_type;
            m_catalog = source.m_catalog;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class SettingNode : NetworkMessage {
        public static int[] Id = { 318,1 };
        public static Ctrl VC;
        public Byte m_key;
        public Boolean m_value;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key = sp.ReadByte();}
            if (sp.TryRead(1)) {m_value = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            sp.EnEnd();
        }
        public void CopyFrom(SettingNode source) {
            m_key = source.m_key;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class MonumentReqInfo : NetworkMessage {
        public static int[] Id = { 324,1 };
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
        public void CopyFrom(MonumentReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class WeeklyActivityReward : NetworkMessage {
        public static int[] Id = { 330,1 };
        public static Ctrl VC;
        public Int16 m_stage;
        public Int32 m_points;
        public Int16 m_got_status;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stage = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_got_status = sp.ReadInt16();}
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
            if (sp.TryWrite(0)) {sp.Write(m_stage);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {sp.Write(m_got_status);}
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
        public void CopyFrom(WeeklyActivityReward source) {
            m_stage = source.m_stage;
            m_points = source.m_points;
            m_got_status = source.m_got_status;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class GetDailyEventRewardAckInfo : NetworkMessage {
        public static int[] Id = { 336,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int16 m_crit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_crit = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_crit);}
            sp.EnEnd();
        }
        public void CopyFrom(GetDailyEventRewardAckInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_crit = source.m_crit;
        }
    }
    
    [Serializable]
    public partial class InvitationRewardListInfo : NetworkMessage {
        public static int[] Id = { 342,1 };
        public static Ctrl VC;
        public List<InvitationRewardInfo> m_user_reward = new List<InvitationRewardInfo>();
        public List<InvitationRewardInfo> m_owner_reward = new List<InvitationRewardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_user_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    InvitationRewardInfo tmp = new InvitationRewardInfo();
                    tmp.Decode(sp);
                    m_user_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_owner_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    InvitationRewardInfo tmp = new InvitationRewardInfo();
                    tmp.Decode(sp);
                    m_owner_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_user_reward.Count);
                for (int i = 0; i != m_user_reward.Count; ++i) {
                    m_user_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_owner_reward.Count);
                for (int i = 0; i != m_owner_reward.Count; ++i) {
                    m_owner_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(InvitationRewardListInfo source) {
            m_user_reward = source.m_user_reward;
            m_owner_reward = source.m_owner_reward;
        }
    }
    
    [Serializable]
    public partial class TitlePrivileges : NetworkMessage {
        public static int[] Id = { 348,1 };
        public static Ctrl VC;
        public Int16 m_title_id;
        public List<Int16> m_privileges = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_privileges.Count);
                for (int i = 0; i != m_privileges.Count; ++i) {
                    sp.Write(m_privileges[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(TitlePrivileges source) {
            m_title_id = source.m_title_id;
            m_privileges = source.m_privileges;
        }
    }
    
    [Serializable]
    public partial class TitleResBaseInfo : NetworkMessage {
        public static int[] Id = { 354,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public List<TaxResInfo> m_res = new List<TaxResInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaxResInfo tmp = new TaxResInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
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
        public void CopyFrom(TitleResBaseInfo source) {
            m_server_id = source.m_server_id;
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class BindDiamondMineInfo : NetworkMessage {
        public static int[] Id = { 360,1 };
        public static Ctrl VC;
        public String m_id = "";
        public String m_token = "";
        public String m_name = "";
        public String m_email = "";
        public Int64 m_reward_time;
        public Int64 m_unbind_time;
        public String m_appid = "";
        public String m_open_udid = "";
        public String m_ip = "";
        public Int32 m_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_token = sp.ReadString();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_email = sp.ReadString();}
            if (sp.TryRead(4)) {m_reward_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_unbind_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_appid = sp.ReadString();}
            if (sp.TryRead(7)) {m_open_udid = sp.ReadString();}
            if (sp.TryRead(8)) {m_ip = sp.ReadString();}
            if (sp.TryRead(9)) {m_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_token);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_email);}
            if (sp.TryWrite(4)) {sp.Write(m_reward_time);}
            if (sp.TryWrite(5)) {sp.Write(m_unbind_time);}
            if (sp.TryWrite(6)) {sp.Write(m_appid);}
            if (sp.TryWrite(7)) {sp.Write(m_open_udid);}
            if (sp.TryWrite(8)) {sp.Write(m_ip);}
            if (sp.TryWrite(9)) {sp.Write(m_type);}
            sp.EnEnd();
        }
        public void CopyFrom(BindDiamondMineInfo source) {
            m_id = source.m_id;
            m_token = source.m_token;
            m_name = source.m_name;
            m_email = source.m_email;
            m_reward_time = source.m_reward_time;
            m_unbind_time = source.m_unbind_time;
            m_appid = source.m_appid;
            m_open_udid = source.m_open_udid;
            m_ip = source.m_ip;
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class DonateDiamondAckInfo : NetworkMessage {
        public static int[] Id = { 366,1 };
        public static Ctrl VC;
        public List<DonateDiamondAckNode> m_to_user_id = new List<DonateDiamondAckNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_to_user_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DonateDiamondAckNode tmp = new DonateDiamondAckNode();
                    tmp.Decode(sp);
                    m_to_user_id.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_to_user_id.Count);
                for (int i = 0; i != m_to_user_id.Count; ++i) {
                    m_to_user_id[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DonateDiamondAckInfo source) {
            m_to_user_id = source.m_to_user_id;
        }
    }
    
    [Serializable]
    public partial class BundleUserInfo : NetworkMessage {
        public static int[] Id = { 372,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public String m_as_abbr = "";
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_icon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(4)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_avatar);}
            if (sp.TryWrite(4)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(BundleUserInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_as_abbr = source.m_as_abbr;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_icon = source.m_icon;
        }
    }
    
    [Serializable]
    public partial class ListAllianceBriefInfo : NetworkMessage {
        public static int[] Id = { 378,1 };
        public static Ctrl VC;
        public List<AllianceBriefInfo> m_infos = new List<AllianceBriefInfo>();
        public List<AllianceLandCnt> m_land_cnt = new List<AllianceLandCnt>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBriefInfo tmp = new AllianceBriefInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_land_cnt.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceLandCnt tmp = new AllianceLandCnt();
                    tmp.Decode(sp);
                    m_land_cnt.Add(tmp);
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_land_cnt.Count);
                for (int i = 0; i != m_land_cnt.Count; ++i) {
                    m_land_cnt[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceBriefInfo source) {
            m_infos = source.m_infos;
            m_land_cnt = source.m_land_cnt;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryHistoryInfo : NetworkMessage {
        public static int[] Id = { 384,1 };
        public static Ctrl VC;
        public List<AllianceSalaryHistory> m_infos = new List<AllianceSalaryHistory>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceSalaryHistory tmp = new AllianceSalaryHistory();
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
        public void CopyFrom(AllianceSalaryHistoryInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class AccountCreateInfo : NetworkMessage {
        public static int[] Id = { 390,1 };
        public static Ctrl VC;
        public SByte m_type;
        public String m_name = "";
        public String m_passwd = "";
        public String m_udid = "";
        public String m_mac_addr = "";
        public String m_locale = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_passwd = sp.ReadString();}
            if (sp.TryRead(3)) {m_udid = sp.ReadString();}
            if (sp.TryRead(4)) {m_mac_addr = sp.ReadString();}
            if (sp.TryRead(5)) {m_locale = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_passwd);}
            if (sp.TryWrite(3)) {sp.Write(m_udid);}
            if (sp.TryWrite(4)) {sp.Write(m_mac_addr);}
            if (sp.TryWrite(5)) {sp.Write(m_locale);}
            sp.EnEnd();
        }
        public void CopyFrom(AccountCreateInfo source) {
            m_type = source.m_type;
            m_name = source.m_name;
            m_passwd = source.m_passwd;
            m_udid = source.m_udid;
            m_mac_addr = source.m_mac_addr;
            m_locale = source.m_locale;
        }
    }
    
    [Serializable]
    public partial class IapListByTypeInfo : NetworkMessage {
        public static int[] Id = { 396,1 };
        public static Ctrl VC;
        public Int16 m_locale;
        public Int32 m_iap_type;
        public SByte m_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_locale = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_locale);}
            if (sp.TryWrite(1)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(2)) {sp.Write(m_type);}
            sp.EnEnd();
        }
        public void CopyFrom(IapListByTypeInfo source) {
            m_locale = source.m_locale;
            m_iap_type = source.m_iap_type;
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class RecruitResInfo : NetworkMessage {
        public static int[] Id = { 402,1 };
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
        public void CopyFrom(RecruitResInfo source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class ResolveOfficerInfo : NetworkMessage {
        public static int[] Id = { 408,1 };
        public static Ctrl VC;
        public Int32 m_src_officer;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<RecruitResInfo> m_res = new List<RecruitResInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_src_officer = sp.ReadInt32();}
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
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RecruitResInfo tmp = new RecruitResInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_src_officer);}
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
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ResolveOfficerInfo source) {
            m_src_officer = source.m_src_officer;
            m_items = source.m_items;
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class AllianceRecruitInfo : NetworkMessage {
        public static int[] Id = { 414,1 };
        public static Ctrl VC;
        public RecruitInfo m_alliance;
        public Boolean m_stat_ranking;
        public Boolean m_stat_pending;
        public RankInfo m_ranking;
        public BiddingInfo m_bidding;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_alliance = new RecruitInfo();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_stat_ranking = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_stat_pending = sp.ReadBoolean();}
            if (sp.TryRead(3)) {
                m_ranking = new RankInfo();
                m_ranking.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_bidding = new BiddingInfo();
                m_bidding.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_stat_ranking);}
            if (sp.TryWrite(2)) {sp.Write(m_stat_pending);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_ranking.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_bidding.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRecruitInfo source) {
            m_alliance = source.m_alliance;
            m_stat_ranking = source.m_stat_ranking;
            m_stat_pending = source.m_stat_pending;
            m_ranking = source.m_ranking;
            m_bidding = source.m_bidding;
        }
    }
    
    [Serializable]
    public partial class RegionMsgListInfo : NetworkMessage {
        public static int[] Id = { 420,1 };
        public static Ctrl VC;
        public List<RegionMsgInfo> m_list = new List<RegionMsgInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RegionMsgInfo tmp = new RegionMsgInfo();
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
        public void CopyFrom(RegionMsgListInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AllianceDominionCharacterReqInfo : NetworkMessage {
        public static int[] Id = { 426,1 };
        public static Ctrl VC;
        public TilePos m_pos;
        public SByte m_character;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_character = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_character);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceDominionCharacterReqInfo source) {
            m_pos = source.m_pos;
            m_character = source.m_character;
        }
    }
    
    [Serializable]
    public partial class SignatureReqInfo : NetworkMessage {
        public static int[] Id = { 432,1 };
        public static Ctrl VC;
        public String m_signature = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_signature = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_signature);}
            sp.EnEnd();
        }
        public void CopyFrom(SignatureReqInfo source) {
            m_signature = source.m_signature;
        }
    }
    
    [Serializable]
    public partial class ListAllianceBriefReqInfo : NetworkMessage {
        public static int[] Id = { 438,1 };
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
        public void CopyFrom(ListAllianceBriefReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class ExpiredItemCompDetailInfo : NetworkMessage {
        public static int[] Id = { 444,1 };
        public static Ctrl VC;
        public ExpiredItemCompBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ExpiredItemCompBaseInfo();
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
        public void CopyFrom(ExpiredItemCompDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class HuodongParamInfo : NetworkMessage {
        public static int[] Id = { 450,1 };
        public static Ctrl VC;
        public String m_key = "";
        public Int32 m_value;
        public Int32 m_order;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key = sp.ReadString();}
            if (sp.TryRead(1)) {m_value = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_order = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            if (sp.TryWrite(2)) {sp.Write(m_order);}
            sp.EnEnd();
        }
        public void CopyFrom(HuodongParamInfo source) {
            m_key = source.m_key;
            m_value = source.m_value;
            m_order = source.m_order;
        }
    }
    
    [Serializable]
    public partial class BuildSuperResReqInfo : NetworkMessage {
        public static int[] Id = { 456,1 };
        public static Ctrl VC;
        public TilePos m_pos;
        public SByte m_res_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_res_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_res_type);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildSuperResReqInfo source) {
            m_pos = source.m_pos;
            m_res_type = source.m_res_type;
        }
    }
    
    [Serializable]
    public partial class PlayerMailDetailInfoV1 : NetworkMessage {
        public static int[] Id = { 462,1 };
        public static Ctrl VC;
        public PlayerMailBaseInfoV1 m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new PlayerMailBaseInfoV1();
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
        public void CopyFrom(PlayerMailDetailInfoV1 source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class LikeUserInfo : NetworkMessage {
        public static int[] Id = { 468,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public SByte m_sex;
        public Int16 m_icon;
        public Int64 m_power;
        public Int32 m_power_rank;
        public Boolean m_Islike;
        public String m_as_abbr = "";
        public Int16 m_server_id;
        public Int64 m_like_time;
        public String m_avatar = "";
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_sex = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_power_rank = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_Islike = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(8)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_like_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(11)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_sex);}
            if (sp.TryWrite(3)) {sp.Write(m_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_power);}
            if (sp.TryWrite(5)) {sp.Write(m_power_rank);}
            if (sp.TryWrite(6)) {sp.Write(m_Islike);}
            if (sp.TryWrite(7)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(8)) {sp.Write(m_server_id);}
            if (sp.TryWrite(9)) {sp.Write(m_like_time);}
            if (sp.TryWrite(10)) {sp.Write(m_avatar);}
            if (sp.TryWrite(11)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(LikeUserInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_sex = source.m_sex;
            m_icon = source.m_icon;
            m_power = source.m_power;
            m_power_rank = source.m_power_rank;
            m_Islike = source.m_Islike;
            m_as_abbr = source.m_as_abbr;
            m_server_id = source.m_server_id;
            m_like_time = source.m_like_time;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class DonateInfo : NetworkMessage {
        public static int[] Id = { 474,1 };
        public static Ctrl VC;
        public SByte m_donate_type;
        public SByte m_res_type;
        public Int64 m_res_num;
        public Int64 m_exp;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_donate_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_res_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_res_num = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_exp = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_donate_type);}
            if (sp.TryWrite(1)) {sp.Write(m_res_type);}
            if (sp.TryWrite(2)) {sp.Write(m_res_num);}
            if (sp.TryWrite(3)) {sp.Write(m_exp);}
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
        public void CopyFrom(DonateInfo source) {
            m_donate_type = source.m_donate_type;
            m_res_type = source.m_res_type;
            m_res_num = source.m_res_num;
            m_exp = source.m_exp;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class ScrollPlayerPower : NetworkMessage {
        public static int[] Id = { 480,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_rank;

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
            if (sp.TryRead(4)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollPlayerPower source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class ScrollPveRefresh : NetworkMessage {
        public static int[] Id = { 486,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public SByte m_stat;
        public Int64 m_refrsh_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_refrsh_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_stat);}
            if (sp.TryWrite(2)) {sp.Write(m_refrsh_time);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollPveRefresh source) {
            m_server_id = source.m_server_id;
            m_stat = source.m_stat;
            m_refrsh_time = source.m_refrsh_time;
        }
    }
    
    [Serializable]
    public partial class GetOrderFromSdkInfo : NetworkMessage {
        public static int[] Id = { 492,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public String m_cp_order_number = "";
        public String m_notify_url = "";
        public Int32 m_order_amount;
        public String m_order_title = "";
        public String m_order_desc = "";
        public String m_ext_info = "";
        public String m_order_time = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_cp_order_number = sp.ReadString();}
            if (sp.TryRead(2)) {m_notify_url = sp.ReadString();}
            if (sp.TryRead(3)) {m_order_amount = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_order_title = sp.ReadString();}
            if (sp.TryRead(5)) {m_order_desc = sp.ReadString();}
            if (sp.TryRead(6)) {m_ext_info = sp.ReadString();}
            if (sp.TryRead(7)) {m_order_time = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {sp.Write(m_cp_order_number);}
            if (sp.TryWrite(2)) {sp.Write(m_notify_url);}
            if (sp.TryWrite(3)) {sp.Write(m_order_amount);}
            if (sp.TryWrite(4)) {sp.Write(m_order_title);}
            if (sp.TryWrite(5)) {sp.Write(m_order_desc);}
            if (sp.TryWrite(6)) {sp.Write(m_ext_info);}
            if (sp.TryWrite(7)) {sp.Write(m_order_time);}
            sp.EnEnd();
        }
        public void CopyFrom(GetOrderFromSdkInfo source) {
            m_access_token = source.m_access_token;
            m_cp_order_number = source.m_cp_order_number;
            m_notify_url = source.m_notify_url;
            m_order_amount = source.m_order_amount;
            m_order_title = source.m_order_title;
            m_order_desc = source.m_order_desc;
            m_ext_info = source.m_ext_info;
            m_order_time = source.m_order_time;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchBaseInfo : NetworkMessage {
        public static int[] Id = { 498,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_curr_level;
        public Int16 m_max_level;
        public Int16 m_status;
        public Int32 m_point;
        public Int32 m_point_req;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_skill_cd_end_time;
        public Int64 m_buff_expire_time;
        public Int16 m_use_skill_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_curr_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_max_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_point = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_point_req = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_skill_cd_end_time = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_buff_expire_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_use_skill_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_curr_level);}
            if (sp.TryWrite(2)) {sp.Write(m_max_level);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            if (sp.TryWrite(4)) {sp.Write(m_point);}
            if (sp.TryWrite(5)) {sp.Write(m_point_req);}
            if (sp.TryWrite(6)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(7)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(8)) {sp.Write(m_skill_cd_end_time);}
            if (sp.TryWrite(9)) {sp.Write(m_buff_expire_time);}
            if (sp.TryWrite(10)) {sp.Write(m_use_skill_level);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchBaseInfo source) {
            m_type = source.m_type;
            m_curr_level = source.m_curr_level;
            m_max_level = source.m_max_level;
            m_status = source.m_status;
            m_point = source.m_point;
            m_point_req = source.m_point_req;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_skill_cd_end_time = source.m_skill_cd_end_time;
            m_buff_expire_time = source.m_buff_expire_time;
            m_use_skill_level = source.m_use_skill_level;
        }
    }
    
    [Serializable]
    public partial class GetAllianceResearchAckInfo : NetworkMessage {
        public static int[] Id = { 504,1 };
        public static Ctrl VC;
        public AllianceResearchDetailInfo m_detail_info;
        public AllianceResearchCostInfo m_cost_info;
        public AsSkillInfo m_skill_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_detail_info = new AllianceResearchDetailInfo();
                m_detail_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cost_info = new AllianceResearchCostInfo();
                m_cost_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_skill_info = new AsSkillInfo();
                m_skill_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_detail_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cost_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_skill_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(GetAllianceResearchAckInfo source) {
            m_detail_info = source.m_detail_info;
            m_cost_info = source.m_cost_info;
            m_skill_info = source.m_skill_info;
        }
    }
    
    [Serializable]
    public partial class UnbindDiamondMineAckInfo : NetworkMessage {
        public static int[] Id = { 510,1 };
        public static Ctrl VC;
        public Boolean m_result;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_result = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(UnbindDiamondMineAckInfo source) {
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDonateRankList : NetworkMessage {
        public static int[] Id = { 516,1 };
        public static Ctrl VC;
        public Int64 m_min_score;
        public Int64 m_end_time;
        public SByte m_rank_type;
        public List<AllianceResearchDonateRankRewardsInfo> m_rank_rewards = new List<AllianceResearchDonateRankRewardsInfo>();
        public List<AllianceResearchDonateRankInfo> m_rank_infos = new List<AllianceResearchDonateRankInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_min_score = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_rank_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceResearchDonateRankRewardsInfo tmp = new AllianceResearchDonateRankRewardsInfo();
                    tmp.Decode(sp);
                    m_rank_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceResearchDonateRankInfo tmp = new AllianceResearchDonateRankInfo();
                    tmp.Decode(sp);
                    m_rank_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_min_score);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_rank_type);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_rewards.Count);
                for (int i = 0; i != m_rank_rewards.Count; ++i) {
                    m_rank_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_infos.Count);
                for (int i = 0; i != m_rank_infos.Count; ++i) {
                    m_rank_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchDonateRankList source) {
            m_min_score = source.m_min_score;
            m_end_time = source.m_end_time;
            m_rank_type = source.m_rank_type;
            m_rank_rewards = source.m_rank_rewards;
            m_rank_infos = source.m_rank_infos;
        }
    }
    
    [Serializable]
    public partial class VerifyFakeUserInfo : NetworkMessage {
        public static int[] Id = { 522,1 };
        public static Ctrl VC;
        public List<Int32> m_code_arr = new List<Int32>();
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
            if (sp.TryRead(1)) {m_ok_type = sp.ReadString();}
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
            if (sp.TryWrite(1)) {sp.Write(m_ok_type);}
            sp.EnEnd();
        }
        public void CopyFrom(VerifyFakeUserInfo source) {
            m_code_arr = source.m_code_arr;
            m_ok_type = source.m_ok_type;
        }
    }
    
    [Serializable]
    public partial class FirstPayRewardInfo : NetworkMessage {
        public static int[] Id = { 528,1 };
        public static Ctrl VC;
        public List<PayRewardInfo> m_reward = new List<PayRewardInfo>();
        public Int64 m_cost;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PayRewardInfo tmp = new PayRewardInfo();
                    tmp.Decode(sp);
                    m_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cost = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_cost);}
            sp.EnEnd();
        }
        public void CopyFrom(FirstPayRewardInfo source) {
            m_reward = source.m_reward;
            m_cost = source.m_cost;
        }
    }
    
    [Serializable]
    public partial class ListAllianceDominionCntInfo : NetworkMessage {
        public static int[] Id = { 534,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int32 m_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceDominionCntInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class LoginComeBackItemInfo : NetworkMessage {
        public static int[] Id = { 540,1 };
        public static Ctrl VC;
        public List<ComeBackItemInfo> m_items = new List<ComeBackItemInfo>();
        public SByte m_dayth;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ComeBackItemInfo tmp = new ComeBackItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_dayth = sp.ReadSByte();}
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
            if (sp.TryWrite(1)) {sp.Write(m_dayth);}
            sp.EnEnd();
        }
        public void CopyFrom(LoginComeBackItemInfo source) {
            m_items = source.m_items;
            m_dayth = source.m_dayth;
        }
    }
    
    [Serializable]
    public partial class UserAccountInfo : NetworkMessage {
        public static int[] Id = { 546,1 };
        public static Ctrl VC;
        public Int64 m_register_time;
        public Int64 m_last_login_time;
        public Int64 m_last_logout_time;
        public String m_register_version = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_register_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_last_login_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_last_logout_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_register_version = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_register_time);}
            if (sp.TryWrite(1)) {sp.Write(m_last_login_time);}
            if (sp.TryWrite(2)) {sp.Write(m_last_logout_time);}
            if (sp.TryWrite(3)) {sp.Write(m_register_version);}
            sp.EnEnd();
        }
        public void CopyFrom(UserAccountInfo source) {
            m_register_time = source.m_register_time;
            m_last_login_time = source.m_last_login_time;
            m_last_logout_time = source.m_last_logout_time;
            m_register_version = source.m_register_version;
        }
    }
    
    [Serializable]
    public partial class ClientConfigInfo : NetworkMessage {
        public static int[] Id = { 552,1 };
        public static Ctrl VC;
        public List<ClientConfigDetail> m_list = new List<ClientConfigDetail>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ClientConfigDetail tmp = new ClientConfigDetail();
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
        public void CopyFrom(ClientConfigInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AsBossFeedHisInfo : NetworkMessage {
        public static int[] Id = { 558,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int32 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(AsBossFeedHisInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class IstanaDeclareWarAckInfo : NetworkMessage {
        public static int[] Id = { 564,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public AllianceSnapInfo m_alliance_snap;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_alliance_snap = new AllianceSnapInfo();
                m_alliance_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaDeclareWarAckInfo source) {
            m_server_id = source.m_server_id;
            m_alliance_snap = source.m_alliance_snap;
        }
    }
    
    [Serializable]
    public partial class IstanaTitleInfo : NetworkMessage {
        public static int[] Id = { 570,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public AllianceSnapInfo m_alliance_snap;
        public List<IstanaTitle> m_list = new List<IstanaTitle>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_alliance_snap = new AllianceSnapInfo();
                m_alliance_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IstanaTitle tmp = new IstanaTitle();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(IstanaTitleInfo source) {
            m_server_id = source.m_server_id;
            m_alliance_snap = source.m_alliance_snap;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ShareFlagRankInfo : NetworkMessage {
        public static int[] Id = { 576,1 };
        public static Ctrl VC;
        public Int16 m_count;
        public Int16 m_limit_count;
        public Int32 m_itembox;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_count = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_limit_count = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_itembox = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_count);}
            if (sp.TryWrite(1)) {sp.Write(m_limit_count);}
            if (sp.TryWrite(2)) {sp.Write(m_itembox);}
            sp.EnEnd();
        }
        public void CopyFrom(ShareFlagRankInfo source) {
            m_count = source.m_count;
            m_limit_count = source.m_limit_count;
            m_itembox = source.m_itembox;
        }
    }
    
    [Serializable]
    public partial class AllianceIstanaSnap : NetworkMessage {
        public static int[] Id = { 582,1 };
        public static Ctrl VC;
        public Int16 m_declare;
        public List<IstanaSnap> m_istana = new List<IstanaSnap>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_declare = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_istana.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IstanaSnap tmp = new IstanaSnap();
                    tmp.Decode(sp);
                    m_istana.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_declare);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_istana.Count);
                for (int i = 0; i != m_istana.Count; ++i) {
                    m_istana[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceIstanaSnap source) {
            m_declare = source.m_declare;
            m_istana = source.m_istana;
        }
    }
    
    [Serializable]
    public partial class GuestIstanaNationReqInfo : NetworkMessage {
        public static int[] Id = { 588,1 };
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
        public void CopyFrom(GuestIstanaNationReqInfo source) {
            m_server_id = source.m_server_id;
            m_region_user_id = source.m_region_user_id;
        }
    }
    
    [Serializable]
    public partial class MactingReportBaseInfo : NetworkMessage {
        public static int[] Id = { 594,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_dead = new List<ArmyInfo>();
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_dead.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_dead.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_dead.Count);
                for (int i = 0; i != m_dead.Count; ++i) {
                    m_dead[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
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
        public void CopyFrom(MactingReportBaseInfo source) {
            m_dead = source.m_dead;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class CommanderSkillArmyInfo : NetworkMessage {
        public static int[] Id = { 600,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_army = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army.Count);
                for (int i = 0; i != m_army.Count; ++i) {
                    m_army[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CommanderSkillArmyInfo source) {
            m_army = source.m_army;
        }
    }
    
    [Serializable]
    public partial class CrowdInvestRewardReportBaseInfo : NetworkMessage {
        public static int[] Id = { 606,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_server_id;
        public String m_as_abbr = "";
        public Int32 m_copies;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(6)) {m_copies = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            if (sp.TryWrite(3)) {sp.Write(m_user_name);}
            if (sp.TryWrite(4)) {sp.Write(m_server_id);}
            if (sp.TryWrite(5)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(6)) {sp.Write(m_copies);}
            sp.EnEnd();
        }
        public void CopyFrom(CrowdInvestRewardReportBaseInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_server_id = source.m_server_id;
            m_as_abbr = source.m_as_abbr;
            m_copies = source.m_copies;
        }
    }
    
    [Serializable]
    public partial class ChargeSignRewardInfo : NetworkMessage {
        public static int[] Id = { 612,1 };
        public static Ctrl VC;
        public SByte m_reward_type;
        public SByte m_dayth;
        public SByte m_reward_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_dayth = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_reward_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward_type);}
            if (sp.TryWrite(1)) {sp.Write(m_dayth);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_level);}
            sp.EnEnd();
        }
        public void CopyFrom(ChargeSignRewardInfo source) {
            m_reward_type = source.m_reward_type;
            m_dayth = source.m_dayth;
            m_reward_level = source.m_reward_level;
        }
    }
    
    [Serializable]
    public partial class GetSevendayRewardReqInfo : NetworkMessage {
        public static int[] Id = { 618,1 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public SByte m_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_step = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step);}
            sp.EnEnd();
        }
        public void CopyFrom(GetSevendayRewardReqInfo source) {
            m_task_id = source.m_task_id;
            m_step = source.m_step;
        }
    }
    
    [Serializable]
    public partial class FpsEndBattleAckInfo : NetworkMessage {
        public static int[] Id = { 624,1 };
        public static Ctrl VC;
        public Boolean m_win;
        public FpsRewardInfo m_reward_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_win = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                m_reward_info = new FpsRewardInfo();
                m_reward_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_win);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_reward_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsEndBattleAckInfo source) {
            m_win = source.m_win;
            m_reward_info = source.m_reward_info;
        }
    }
    
    [Serializable]
    public partial class IdcardVerifyReqInfo : NetworkMessage {
        public static int[] Id = { 630,1 };
        public static Ctrl VC;
        public String m_id_card = "";
        public String m_card_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id_card = sp.ReadString();}
            if (sp.TryRead(1)) {m_card_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id_card);}
            if (sp.TryWrite(1)) {sp.Write(m_card_name);}
            sp.EnEnd();
        }
        public void CopyFrom(IdcardVerifyReqInfo source) {
            m_id_card = source.m_id_card;
            m_card_name = source.m_card_name;
        }
    }
    
    [Serializable]
    public partial class DiamondMineShareReqInfo : NetworkMessage {
        public static int[] Id = { 636,1 };
        public static Ctrl VC;
        public SByte m_share_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_share_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_share_type);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondMineShareReqInfo source) {
            m_share_type = source.m_share_type;
        }
    }
    
    [Serializable]
    public partial class BestBattleReportInfo : NetworkMessage {
        public static int[] Id = { 642,1 };
        public static Ctrl VC;
        public BestBattleReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new BestBattleReportBaseInfo();
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
        public void CopyFrom(BestBattleReportInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class NewbieTriggerInfo : NetworkMessage {
        public static int[] Id = { 648,1 };
        public static Ctrl VC;
        public Int16 m_trigger_type;
        public Int64 m_finish_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_trigger_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_finish_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_trigger_type);}
            if (sp.TryWrite(1)) {sp.Write(m_finish_time);}
            sp.EnEnd();
        }
        public void CopyFrom(NewbieTriggerInfo source) {
            m_trigger_type = source.m_trigger_type;
            m_finish_time = source.m_finish_time;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedCycle : NetworkMessage {
        public static int[] Id = { 654,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_type;
        public Int32 m_cycle;
        public Int64 m_start_time;
        public Int64 m_end_time;
        public Int16 m_server_id1;
        public Int64 m_score1;
        public Int16 m_server_id2;
        public Int64 m_score2;
        public Int16 m_win_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cycle = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_server_id1 = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_score1 = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_server_id2 = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_score2 = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_win_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_cycle);}
            if (sp.TryWrite(3)) {sp.Write(m_start_time);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            if (sp.TryWrite(5)) {sp.Write(m_server_id1);}
            if (sp.TryWrite(6)) {sp.Write(m_score1);}
            if (sp.TryWrite(7)) {sp.Write(m_server_id2);}
            if (sp.TryWrite(8)) {sp.Write(m_score2);}
            if (sp.TryWrite(9)) {sp.Write(m_win_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedCycle source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_cycle = source.m_cycle;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_server_id1 = source.m_server_id1;
            m_score1 = source.m_score1;
            m_server_id2 = source.m_server_id2;
            m_score2 = source.m_score2;
            m_win_server_id = source.m_win_server_id;
        }
    }
    
    [Serializable]
    public partial class CaptchaLevelVerifyInfo : NetworkMessage {
        public static int[] Id = { 660,1 };
        public static Ctrl VC;
        public List<CaptchaConfigRecord> m_records = new List<CaptchaConfigRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptchaConfigRecord tmp = new CaptchaConfigRecord();
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
        public void CopyFrom(CaptchaLevelVerifyInfo source) {
            m_records = source.m_records;
        }
    }
    
    [Serializable]
    public partial class IapPopupNtfInfo : NetworkMessage {
        public static int[] Id = { 666,1 };
        public static Ctrl VC;
        public Int64 m_interval;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_interval = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_interval);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPopupNtfInfo source) {
            m_interval = source.m_interval;
        }
    }
    
    [Serializable]
    public partial class PenddingQuest : NetworkMessage {
        public static int[] Id = { 672,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_param2;
        public Int64 m_cur_2cnt;
        public Int64 m_param3;
        public Int64 m_cur_3cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_param2 = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cur_2cnt = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_param3 = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_cur_3cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_param2);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_2cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_param3);}
            if (sp.TryWrite(4)) {sp.Write(m_cur_3cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(PenddingQuest source) {
            m_id = source.m_id;
            m_param2 = source.m_param2;
            m_cur_2cnt = source.m_cur_2cnt;
            m_param3 = source.m_param3;
            m_cur_3cnt = source.m_cur_3cnt;
        }
    }
    
    [Serializable]
    public partial class ScrollMobAlliance : NetworkMessage {
        public static int[] Id = { 678,1 };
        public static Ctrl VC;
        public AllianceSnapInfo m_alliance;
        public Int64 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_alliance = new AllianceSnapInfo();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollMobAlliance source) {
            m_alliance = source.m_alliance;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class ScrollAllianceEventRank : NetworkMessage {
        public static int[] Id = { 684,1 };
        public static Ctrl VC;
        public Int32 m_as_id;
        public String m_as_name = "";
        public String m_as_name_abbr = "";
        public Int16 m_as_server_id;
        public Int32 m_event_id;
        public Int32 m_event_type;
        public Int32 m_rank;
        public Int64 m_endtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_as_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_as_name_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_as_server_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_event_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_event_type = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_endtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_as_id);}
            if (sp.TryWrite(1)) {sp.Write(m_as_name);}
            if (sp.TryWrite(2)) {sp.Write(m_as_name_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_as_server_id);}
            if (sp.TryWrite(4)) {sp.Write(m_event_id);}
            if (sp.TryWrite(5)) {sp.Write(m_event_type);}
            if (sp.TryWrite(6)) {sp.Write(m_rank);}
            if (sp.TryWrite(7)) {sp.Write(m_endtime);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollAllianceEventRank source) {
            m_as_id = source.m_as_id;
            m_as_name = source.m_as_name;
            m_as_name_abbr = source.m_as_name_abbr;
            m_as_server_id = source.m_as_server_id;
            m_event_id = source.m_event_id;
            m_event_type = source.m_event_type;
            m_rank = source.m_rank;
            m_endtime = source.m_endtime;
        }
    }
    
    [Serializable]
    public partial class SpeedupDiamondsInfo : NetworkMessage {
        public static int[] Id = { 690,1 };
        public static Ctrl VC;
        public Int16 m_speedup_type;
        public Int32 m_target;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_speedup_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_target = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_speedup_type);}
            if (sp.TryWrite(1)) {sp.Write(m_target);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(SpeedupDiamondsInfo source) {
            m_speedup_type = source.m_speedup_type;
            m_target = source.m_target;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class FpsEquipmentReqInfo : NetworkMessage {
        public static int[] Id = { 696,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_equipment_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_equipment_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_equipment_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsEquipmentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_equipment_id = source.m_equipment_id;
        }
    }
    
    [Serializable]
    public partial class FpsNewGunInfo : NetworkMessage {
        public static int[] Id = { 702,1 };
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
        public void CopyFrom(FpsNewGunInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class UserReportTracking : NetworkMessage {
        public static int[] Id = { 708,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_report_place;
        public Int32 m_report_type;
        public String m_report_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_report_place = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_report_type = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_report_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_report_place);}
            if (sp.TryWrite(2)) {sp.Write(m_report_type);}
            if (sp.TryWrite(3)) {sp.Write(m_report_content);}
            sp.EnEnd();
        }
        public void CopyFrom(UserReportTracking source) {
            m_user_id = source.m_user_id;
            m_report_place = source.m_report_place;
            m_report_type = source.m_report_type;
            m_report_content = source.m_report_content;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelStartAckInfo : NetworkMessage {
        public static int[] Id = { 714,1 };
        public static Ctrl VC;
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
            if (sp.TryRead(0)) {
                m_agent_info = new FpsAgentInfo();
                m_agent_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_enemy_hp_param = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_enemy_att_param = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_ally_hp_param = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_ally_att_param = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_dmg_factor_head = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_dmg_factor_chest = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_dmg_factor_limbs = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_agent_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_enemy_hp_param);}
            if (sp.TryWrite(2)) {sp.Write(m_enemy_att_param);}
            if (sp.TryWrite(3)) {sp.Write(m_ally_hp_param);}
            if (sp.TryWrite(4)) {sp.Write(m_ally_att_param);}
            if (sp.TryWrite(5)) {sp.Write(m_dmg_factor_head);}
            if (sp.TryWrite(6)) {sp.Write(m_dmg_factor_chest);}
            if (sp.TryWrite(7)) {sp.Write(m_dmg_factor_limbs);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSpecialLevelStartAckInfo source) {
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
    public partial class CampaignReqItemInfo : NetworkMessage {
        public static int[] Id = { 720,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_sub_rank_id;
        public List<Int32> m_sub_id = new List<Int32>();
        public List<Int32> m_sub_num = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_sub_rank_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sub_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_sub_id.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sub_num.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_sub_num.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_sub_rank_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sub_id.Count);
                for (int i = 0; i != m_sub_id.Count; ++i) {
                    sp.Write(m_sub_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sub_num.Count);
                for (int i = 0; i != m_sub_num.Count; ++i) {
                    sp.Write(m_sub_num[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CampaignReqItemInfo source) {
            m_id = source.m_id;
            m_sub_rank_id = source.m_sub_rank_id;
            m_sub_id = source.m_sub_id;
            m_sub_num = source.m_sub_num;
        }
    }
    
    [Serializable]
    public partial class FpsCampaignInfo : NetworkMessage {
        public static int[] Id = { 726,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();
        public Int16 m_fps_point;
        public Int64 m_top_score;
        public Int64 m_total_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_current_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_current_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_fps_point = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_top_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_total_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_info.Count);
                for (int i = 0; i != m_exchange_info.Count; ++i) {
                    m_exchange_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_current_items.Count);
                for (int i = 0; i != m_current_items.Count; ++i) {
                    m_current_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_fps_point);}
            if (sp.TryWrite(4)) {sp.Write(m_top_score);}
            if (sp.TryWrite(5)) {sp.Write(m_total_score);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
            m_fps_point = source.m_fps_point;
            m_top_score = source.m_top_score;
            m_total_score = source.m_total_score;
        }
    }
    
    [Serializable]
    public partial class RankUnitInfo : NetworkMessage {
        public static int[] Id = { 732,1 };
        public static Ctrl VC;
        public Int32 m_sub_rank_id;
        public Int64 m_points;
        public Int32 m_rank;
        public List<Int32> m_reward_record = new List<Int32>();
        public List<RankCampaignFixedRewardInfo> m_fixed_rewards = new List<RankCampaignFixedRewardInfo>();
        public List<RankCampaignRankRewardInfo> m_rank_rewards = new List<RankCampaignRankRewardInfo>();
        public Int64 m_rank_points_limit;
        public Int16 m_rank_type;
        public SByte m_cross_type;
        public Int32 m_max_show;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sub_rank_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_reward_record.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fixed_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankCampaignFixedRewardInfo tmp = new RankCampaignFixedRewardInfo();
                    tmp.Decode(sp);
                    m_fixed_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankCampaignRankRewardInfo tmp = new RankCampaignRankRewardInfo();
                    tmp.Decode(sp);
                    m_rank_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_rank_points_limit = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_rank_type = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_cross_type = sp.ReadSByte();}
            if (sp.TryRead(9)) {m_max_show = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sub_rank_id);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_record.Count);
                for (int i = 0; i != m_reward_record.Count; ++i) {
                    sp.Write(m_reward_record[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fixed_rewards.Count);
                for (int i = 0; i != m_fixed_rewards.Count; ++i) {
                    m_fixed_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_rewards.Count);
                for (int i = 0; i != m_rank_rewards.Count; ++i) {
                    m_rank_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_rank_points_limit);}
            if (sp.TryWrite(7)) {sp.Write(m_rank_type);}
            if (sp.TryWrite(8)) {sp.Write(m_cross_type);}
            if (sp.TryWrite(9)) {sp.Write(m_max_show);}
            sp.EnEnd();
        }
        public void CopyFrom(RankUnitInfo source) {
            m_sub_rank_id = source.m_sub_rank_id;
            m_points = source.m_points;
            m_rank = source.m_rank;
            m_reward_record = source.m_reward_record;
            m_fixed_rewards = source.m_fixed_rewards;
            m_rank_rewards = source.m_rank_rewards;
            m_rank_points_limit = source.m_rank_points_limit;
            m_rank_type = source.m_rank_type;
            m_cross_type = source.m_cross_type;
            m_max_show = source.m_max_show;
        }
    }
    
    [Serializable]
    public partial class CampaignRedpointInfo : NetworkMessage {
        public static int[] Id = { 738,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int16 m_act_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_act_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_act_type);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignRedpointInfo source) {
            m_act_id = source.m_act_id;
            m_act_type = source.m_act_type;
        }
    }
    
    [Serializable]
    public partial class ResizeableGridViewInfo : NetworkMessage {
        public static int[] Id = { 744,1 };
        public static Ctrl VC;
        public List<ResizeableTileInfo> m_tile_info = new List<ResizeableTileInfo>();
        public List<ResizeableLandInfo> m_land_info = new List<ResizeableLandInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tile_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResizeableTileInfo tmp = new ResizeableTileInfo();
                    tmp.Decode(sp);
                    m_tile_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_land_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResizeableLandInfo tmp = new ResizeableLandInfo();
                    tmp.Decode(sp);
                    m_land_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tile_info.Count);
                for (int i = 0; i != m_tile_info.Count; ++i) {
                    m_tile_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_land_info.Count);
                for (int i = 0; i != m_land_info.Count; ++i) {
                    m_land_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ResizeableGridViewInfo source) {
            m_tile_info = source.m_tile_info;
            m_land_info = source.m_land_info;
        }
    }
    
    [Serializable]
    public partial class SevendayPageInfo : NetworkMessage {
        public static int[] Id = { 750,1 };
        public static Ctrl VC;
        public SByte m_page;
        public String m_title = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_page = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_page);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            sp.EnEnd();
        }
        public void CopyFrom(SevendayPageInfo source) {
            m_page = source.m_page;
            m_title = source.m_title;
        }
    }
    
    [Serializable]
    public partial class FpsCurrentGunNtfInfo : NetworkMessage {
        public static int[] Id = { 756,1 };
        public static Ctrl VC;
        public Int16 m_current_gun_rifle;
        public Int16 m_current_gun_smg;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_gun_rifle = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_current_gun_smg = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_gun_rifle);}
            if (sp.TryWrite(1)) {sp.Write(m_current_gun_smg);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsCurrentGunNtfInfo source) {
            m_current_gun_rifle = source.m_current_gun_rifle;
            m_current_gun_smg = source.m_current_gun_smg;
        }
    }
    
    [Serializable]
    public partial class DefaultAgentReqInfo : NetworkMessage {
        public static int[] Id = { 762,1 };
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
        public void CopyFrom(DefaultAgentReqInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class ChangeUserIconReqInfo : NetworkMessage {
        public static int[] Id = { 768,1 };
        public static Ctrl VC;
        public Int16 m_icon_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_icon_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_icon_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeUserIconReqInfo source) {
            m_icon_id = source.m_icon_id;
        }
    }
    
    [Serializable]
    public partial class DynamicClientData : NetworkMessage {
        public static int[] Id = { 774,1 };
        public static Ctrl VC;
        public List<DynamicClientDataPair> m_data = new List<DynamicClientDataPair>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_data.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DynamicClientDataPair tmp = new DynamicClientDataPair();
                    tmp.Decode(sp);
                    m_data.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_data.Count);
                for (int i = 0; i != m_data.Count; ++i) {
                    m_data[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(DynamicClientData source) {
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class ChapterMissionTable : NetworkMessage {
        public static int[] Id = { 780,1 };
        public static Ctrl VC;
        public List<ChapterMission> m_chapter_list = new List<ChapterMission>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_chapter_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ChapterMission tmp = new ChapterMission();
                    tmp.Decode(sp);
                    m_chapter_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_chapter_list.Count);
                for (int i = 0; i != m_chapter_list.Count; ++i) {
                    m_chapter_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ChapterMissionTable source) {
            m_chapter_list = source.m_chapter_list;
        }
    }
    
    [Serializable]
    public partial class MapUnitId : NetworkMessage {
        public static int[] Id = { 786,1 };
        public static Ctrl VC;
        public SByte m_type;
        public Int64 m_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MapUnitId source) {
            m_type = source.m_type;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class CreateAllianceBuildingInfo : NetworkMessage {
        public static int[] Id = { 792,1 };
        public static Ctrl VC;
        public Int32 m_building_type;
        public TilePos m_pos;
        public Int32 m_cfg_id;
        public TilePos m_land_rect_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_cfg_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                m_land_rect_pos = new TilePos();
                m_land_rect_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_type);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_cfg_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_land_rect_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CreateAllianceBuildingInfo source) {
            m_building_type = source.m_building_type;
            m_pos = source.m_pos;
            m_cfg_id = source.m_cfg_id;
            m_land_rect_pos = source.m_land_rect_pos;
        }
    }
    
    [Serializable]
    public partial class CultureAgentInfo : NetworkMessage {
        public static int[] Id = { 798,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_fragment;
        public Int32 m_fragment_need;
        public Int32 m_almighty_item;
        public Boolean m_has_agent;
        public Boolean m_coming_soon;
        public Int16 m_level;
        public Int32 m_level_exp;
        public Int32 m_level_exp_need;
        public Int16 m_star;
        public Int32 m_star_point;
        public Int32 m_star_point_need;
        public Int16 m_rank;
        public Int64 m_troop_num;
        public Int32 m_force;
        public List<Int32> m_force_detail = new List<Int32>();
        public List<CultureAgentSkillInfo> m_skills = new List<CultureAgentSkillInfo>();
        public Int32 m_available_skill_point;
        public Int32 m_available_talent_point;
        public SByte m_quality;
        public SByte m_state;
        public Int32 m_study_level;
        public Int64 m_study_effect_endtime;
        public Int16 m_ServerDay;
        public Int64 m_weapon_id;
        public Int32 m_weapon_power;
        public List<AgentWgtBoxInfo> m_war_god_talent_boxes = new List<AgentWgtBoxInfo>();
        public List<EquipInfo> m_equips = new List<EquipInfo>();
        public UInt32 m_sort_id;
        public Int16 m_break_level;
        public Int32 m_break_exp;
        public Int32 m_break_skill_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_fragment = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_fragment_need = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_almighty_item = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_has_agent = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_coming_soon = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_level_exp = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_level_exp_need = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_star_point = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_star_point_need = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_troop_num = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_force = sp.ReadInt32();}
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_force_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_force_detail.Add(tmp);
                }
            }
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skills.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentSkillInfo tmp = new CultureAgentSkillInfo();
                    tmp.Decode(sp);
                    m_skills.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_available_skill_point = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_available_talent_point = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_quality = sp.ReadSByte();}
            if (sp.TryRead(20)) {m_state = sp.ReadSByte();}
            if (sp.TryRead(21)) {m_study_level = sp.ReadInt32();}
            if (sp.TryRead(22)) {m_study_effect_endtime = sp.ReadInt64();}
            if (sp.TryRead(23)) {m_ServerDay = sp.ReadInt16();}
            if (sp.TryRead(24)) {m_weapon_id = sp.ReadInt64();}
            if (sp.TryRead(25)) {m_weapon_power = sp.ReadInt32();}
            if (sp.TryRead(26)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_war_god_talent_boxes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AgentWgtBoxInfo tmp = new AgentWgtBoxInfo();
                    tmp.Decode(sp);
                    m_war_god_talent_boxes.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(27)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_equips.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EquipInfo tmp = new EquipInfo();
                    tmp.Decode(sp);
                    m_equips.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(28)) {m_sort_id = sp.ReadUInt32();}
            if (sp.TryRead(29)) {m_break_level = sp.ReadInt16();}
            if (sp.TryRead(30)) {m_break_exp = sp.ReadInt32();}
            if (sp.TryRead(31)) {m_break_skill_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_fragment);}
            if (sp.TryWrite(2)) {sp.Write(m_fragment_need);}
            if (sp.TryWrite(3)) {sp.Write(m_almighty_item);}
            if (sp.TryWrite(4)) {sp.Write(m_has_agent);}
            if (sp.TryWrite(5)) {sp.Write(m_coming_soon);}
            if (sp.TryWrite(6)) {sp.Write(m_level);}
            if (sp.TryWrite(7)) {sp.Write(m_level_exp);}
            if (sp.TryWrite(8)) {sp.Write(m_level_exp_need);}
            if (sp.TryWrite(9)) {sp.Write(m_star);}
            if (sp.TryWrite(10)) {sp.Write(m_star_point);}
            if (sp.TryWrite(11)) {sp.Write(m_star_point_need);}
            if (sp.TryWrite(12)) {sp.Write(m_rank);}
            if (sp.TryWrite(13)) {sp.Write(m_troop_num);}
            if (sp.TryWrite(14)) {sp.Write(m_force);}
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_force_detail.Count);
                for (int i = 0; i != m_force_detail.Count; ++i) {
                    sp.Write(m_force_detail[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skills.Count);
                for (int i = 0; i != m_skills.Count; ++i) {
                    m_skills[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(17)) {sp.Write(m_available_skill_point);}
            if (sp.TryWrite(18)) {sp.Write(m_available_talent_point);}
            if (sp.TryWrite(19)) {sp.Write(m_quality);}
            if (sp.TryWrite(20)) {sp.Write(m_state);}
            if (sp.TryWrite(21)) {sp.Write(m_study_level);}
            if (sp.TryWrite(22)) {sp.Write(m_study_effect_endtime);}
            if (sp.TryWrite(23)) {sp.Write(m_ServerDay);}
            if (sp.TryWrite(24)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(25)) {sp.Write(m_weapon_power);}
            if (sp.TryWrite(26)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_war_god_talent_boxes.Count);
                for (int i = 0; i != m_war_god_talent_boxes.Count; ++i) {
                    m_war_god_talent_boxes[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(27)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_equips.Count);
                for (int i = 0; i != m_equips.Count; ++i) {
                    m_equips[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(28)) {sp.Write(m_sort_id);}
            if (sp.TryWrite(29)) {sp.Write(m_break_level);}
            if (sp.TryWrite(30)) {sp.Write(m_break_exp);}
            if (sp.TryWrite(31)) {sp.Write(m_break_skill_point);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentInfo source) {
            m_id = source.m_id;
            m_fragment = source.m_fragment;
            m_fragment_need = source.m_fragment_need;
            m_almighty_item = source.m_almighty_item;
            m_has_agent = source.m_has_agent;
            m_coming_soon = source.m_coming_soon;
            m_level = source.m_level;
            m_level_exp = source.m_level_exp;
            m_level_exp_need = source.m_level_exp_need;
            m_star = source.m_star;
            m_star_point = source.m_star_point;
            m_star_point_need = source.m_star_point_need;
            m_rank = source.m_rank;
            m_troop_num = source.m_troop_num;
            m_force = source.m_force;
            m_force_detail = source.m_force_detail;
            m_skills = source.m_skills;
            m_available_skill_point = source.m_available_skill_point;
            m_available_talent_point = source.m_available_talent_point;
            m_quality = source.m_quality;
            m_state = source.m_state;
            m_study_level = source.m_study_level;
            m_study_effect_endtime = source.m_study_effect_endtime;
            m_ServerDay = source.m_ServerDay;
            m_weapon_id = source.m_weapon_id;
            m_weapon_power = source.m_weapon_power;
            m_war_god_talent_boxes = source.m_war_god_talent_boxes;
            m_equips = source.m_equips;
            m_sort_id = source.m_sort_id;
            m_break_level = source.m_break_level;
            m_break_exp = source.m_break_exp;
            m_break_skill_point = source.m_break_skill_point;
        }
    }
    
    [Serializable]
    public partial class AgentFragmentExchangeReqInfo : NetworkMessage {
        public static int[] Id = { 804,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentFragmentExchangeReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class AgentTalentTreeResetReqInfo : NetworkMessage {
        public static int[] Id = { 810,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public SByte m_scheme_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_scheme_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_scheme_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentTalentTreeResetReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_scheme_id = source.m_scheme_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentRankUpgradeReqInfo : NetworkMessage {
        public static int[] Id = { 816,1 };
        public static Ctrl VC;
        public Int16 m_agentId;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agentId = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agentId);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentRankUpgradeReqInfo source) {
            m_agentId = source.m_agentId;
        }
    }
    
    [Serializable]
    public partial class BuildingGroupDetailInfo : NetworkMessage {
        public static int[] Id = { 822,1 };
        public static Ctrl VC;
        public Int64 m_group_id;
        public Int64 m_start_build_time;
        public Int64 m_fund;
        public Int64 m_arrive_time;
        public Int64 m_gather_time;
        public SByte m_res_type;
        public Int64 m_res_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_start_build_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_fund = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_arrive_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_gather_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_res_type = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_res_count = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {sp.Write(m_start_build_time);}
            if (sp.TryWrite(2)) {sp.Write(m_fund);}
            if (sp.TryWrite(3)) {sp.Write(m_arrive_time);}
            if (sp.TryWrite(4)) {sp.Write(m_gather_time);}
            if (sp.TryWrite(5)) {sp.Write(m_res_type);}
            if (sp.TryWrite(6)) {sp.Write(m_res_count);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingGroupDetailInfo source) {
            m_group_id = source.m_group_id;
            m_start_build_time = source.m_start_build_time;
            m_fund = source.m_fund;
            m_arrive_time = source.m_arrive_time;
            m_gather_time = source.m_gather_time;
            m_res_type = source.m_res_type;
            m_res_count = source.m_res_count;
        }
    }
    
    [Serializable]
    public partial class CmpLandDataReqInfo : NetworkMessage {
        public static int[] Id = { 828,1 };
        public static Ctrl VC;
        public List<TilePos> m_chunk_pos = new List<TilePos>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_chunk_pos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_chunk_pos.Add(tmp);
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
                sp.Write((UInt16)m_chunk_pos.Count);
                for (int i = 0; i != m_chunk_pos.Count; ++i) {
                    m_chunk_pos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(CmpLandDataReqInfo source) {
            m_chunk_pos = source.m_chunk_pos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class CmpLandThumbnail : NetworkMessage {
        public static int[] Id = { 834,1 };
        public static Ctrl VC;
        public List<AllianceSnapInfo> m_landalliance = new List<AllianceSnapInfo>();
        public Byte[] m_land_data;
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
            if (sp.TryRead(1)) {m_land_data = sp.ReadBytes2();}
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
            if (sp.TryWrite(1)) {sp.WriteBytes2(m_land_data);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(CmpLandThumbnail source) {
            m_landalliance = source.m_landalliance;
            m_land_data = source.m_land_data;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GetRtfMailListAckInfo : NetworkMessage {
        public static int[] Id = { 840,1 };
        public static Ctrl VC;
        public List<RtfMailBasicInfo> m_list = new List<RtfMailBasicInfo>();
        public Int32 m_left_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RtfMailBasicInfo tmp = new RtfMailBasicInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_left_count = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_left_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GetRtfMailListAckInfo source) {
            m_list = source.m_list;
            m_left_count = source.m_left_count;
        }
    }
    
    [Serializable]
    public partial class UnreadRtfMailCountInfo : NetworkMessage {
        public static int[] Id = { 846,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int32 m_num;
        public Int32 m_total;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_total = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            if (sp.TryWrite(2)) {sp.Write(m_total);}
            sp.EnEnd();
        }
        public void CopyFrom(UnreadRtfMailCountInfo source) {
            m_type = source.m_type;
            m_num = source.m_num;
            m_total = source.m_total;
        }
    }
    
    [Serializable]
    public partial class GetShareBattleMailAckInfo : NetworkMessage {
        public static int[] Id = { 852,1 };
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
        public void CopyFrom(GetShareBattleMailAckInfo source) {
            m_mail = source.m_mail;
        }
    }
    
    [Serializable]
    public partial class ReadAllRtfMailAckInfo : NetworkMessage {
        public static int[] Id = { 858,1 };
        public static Ctrl VC;
        public Boolean m_read_collect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_read_collect = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_read_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(ReadAllRtfMailAckInfo source) {
            m_read_collect = source.m_read_collect;
        }
    }
    
    [Serializable]
    public partial class MapMilestoneCfg : NetworkMessage {
        public static int[] Id = { 864,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_participant;
        public Int64 m_duration;
        public Boolean m_wait;
        public Int32 m_class;
        public Int64 m_param1;
        public Int64 m_param2;
        public SByte m_award_target;
        public List<ItemInfo> m_awd = new List<ItemInfo>();
        public Int32 m_unlock;
        public Int32 m_unlock_param;
        public Int32 m_unlock_fort;
        public Int64 m_rank_scroe_req;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_participant = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_duration = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_wait = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_class = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_param1 = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_param2 = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_award_target = sp.ReadSByte();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_awd.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_awd.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_unlock = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_unlock_param = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_unlock_fort = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_rank_scroe_req = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_participant);}
            if (sp.TryWrite(2)) {sp.Write(m_duration);}
            if (sp.TryWrite(3)) {sp.Write(m_wait);}
            if (sp.TryWrite(4)) {sp.Write(m_class);}
            if (sp.TryWrite(5)) {sp.Write(m_param1);}
            if (sp.TryWrite(6)) {sp.Write(m_param2);}
            if (sp.TryWrite(7)) {sp.Write(m_award_target);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_awd.Count);
                for (int i = 0; i != m_awd.Count; ++i) {
                    m_awd[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {sp.Write(m_unlock);}
            if (sp.TryWrite(10)) {sp.Write(m_unlock_param);}
            if (sp.TryWrite(11)) {sp.Write(m_unlock_fort);}
            if (sp.TryWrite(12)) {sp.Write(m_rank_scroe_req);}
            sp.EnEnd();
        }
        public void CopyFrom(MapMilestoneCfg source) {
            m_id = source.m_id;
            m_participant = source.m_participant;
            m_duration = source.m_duration;
            m_wait = source.m_wait;
            m_class = source.m_class;
            m_param1 = source.m_param1;
            m_param2 = source.m_param2;
            m_award_target = source.m_award_target;
            m_awd = source.m_awd;
            m_unlock = source.m_unlock;
            m_unlock_param = source.m_unlock_param;
            m_unlock_fort = source.m_unlock_fort;
            m_rank_scroe_req = source.m_rank_scroe_req;
        }
    }
    
    [Serializable]
    public partial class CityBattleNtfInfo : NetworkMessage {
        public static int[] Id = { 870,1 };
        public static Ctrl VC;
        public Int16 m_result;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_result = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(CityBattleNtfInfo source) {
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class TimerIapNtf : NetworkMessage {
        public static int[] Id = { 876,1 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(TimerIapNtf source) {
        }
    }
    
    [Serializable]
    public partial class QuickReconnectFinishNtf : NetworkMessage {
        public static int[] Id = { 882,1 };
        public static Ctrl VC;
        public Boolean m_is_login;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_login = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_login);}
            sp.EnEnd();
        }
        public void CopyFrom(QuickReconnectFinishNtf source) {
            m_is_login = source.m_is_login;
        }
    }
    
    [Serializable]
    public partial class ExpeditionTroop : NetworkMessage {
        public static int[] Id = { 888,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public List<Int16> m_agent = new List<Int16>();
        public Int32 m_seat_id;
        public Int16 m_warship_id;

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
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_seat_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_warship_id = sp.ReadInt16();}
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_seat_id);}
            if (sp.TryWrite(3)) {sp.Write(m_warship_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionTroop source) {
            m_troops = source.m_troops;
            m_agent = source.m_agent;
            m_seat_id = source.m_seat_id;
            m_warship_id = source.m_warship_id;
        }
    }
    
    [Serializable]
    public partial class ExpeditionRewardStateInfo : NetworkMessage {
        public static int[] Id = { 894,1 };
        public static Ctrl VC;
        public SByte m_first;
        public SByte m_star1;
        public SByte m_star2;
        public SByte m_star3;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_first = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_star1 = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_star2 = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_star3 = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_first);}
            if (sp.TryWrite(1)) {sp.Write(m_star1);}
            if (sp.TryWrite(2)) {sp.Write(m_star2);}
            if (sp.TryWrite(3)) {sp.Write(m_star3);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionRewardStateInfo source) {
            m_first = source.m_first;
            m_star1 = source.m_star1;
            m_star2 = source.m_star2;
            m_star3 = source.m_star3;
        }
    }
    
    [Serializable]
    public partial class BoxItemInfo : NetworkMessage {
        public static int[] Id = { 900,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_count;
        public SByte m_hint;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_hint = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            if (sp.TryWrite(2)) {sp.Write(m_hint);}
            sp.EnEnd();
        }
        public void CopyFrom(BoxItemInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
            m_hint = source.m_hint;
        }
    }
    
    [Serializable]
    public partial class B2ScrollMessage : NetworkMessage {
        public static int[] Id = { 906,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public String m_param = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_param = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_param);}
            sp.EnEnd();
        }
        public void CopyFrom(B2ScrollMessage source) {
            m_type = source.m_type;
            m_param = source.m_param;
        }
    }
    
    [Serializable]
    public partial class MapExploreReachNtfInfo : NetworkMessage {
        public static int[] Id = { 912,1 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_point_type;
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_point_type = sp.ReadSByte();}
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_point_type);}
            if (sp.TryWrite(4)) {
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
        public void CopyFrom(MapExploreReachNtfInfo source) {
            m_march_id = source.m_march_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_point_type = source.m_point_type;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class HelpRewardNtfInfo : NetworkMessage {
        public static int[] Id = { 918,1 };
        public static Ctrl VC;
        public Int64 m_fund;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fund = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fund);}
            sp.EnEnd();
        }
        public void CopyFrom(HelpRewardNtfInfo source) {
            m_fund = source.m_fund;
        }
    }
    
    [Serializable]
    public partial class AssignmentCenterAgentInfo : NetworkMessage {
        public static int[] Id = { 924,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_level;
        public Int64 m_exp;
        public Int32 m_skin;
        public Int64 m_tap_exp_cnt;
        public List<Int32> m_skin_list = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_exp = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_skin = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_tap_exp_cnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_exp);}
            if (sp.TryWrite(3)) {sp.Write(m_skin);}
            if (sp.TryWrite(4)) {sp.Write(m_tap_exp_cnt);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skin_list.Count);
                for (int i = 0; i != m_skin_list.Count; ++i) {
                    sp.Write(m_skin_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AssignmentCenterAgentInfo source) {
            m_id = source.m_id;
            m_level = source.m_level;
            m_exp = source.m_exp;
            m_skin = source.m_skin;
            m_tap_exp_cnt = source.m_tap_exp_cnt;
            m_skin_list = source.m_skin_list;
        }
    }
    
    [Serializable]
    public partial class UnfinishedLandRectList : NetworkMessage {
        public static int[] Id = { 930,1 };
        public static Ctrl VC;
        public List<UnfinishedLandRect> m_list = new List<UnfinishedLandRect>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UnfinishedLandRect tmp = new UnfinishedLandRect();
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
        public void CopyFrom(UnfinishedLandRectList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelInfo : NetworkMessage {
        public static int[] Id = { 936,1 };
        public static Ctrl VC;
        public SByte m_state;
        public SByte m_sub_state;
        public SByte m_round;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Int64 m_dt;
        public Boolean m_can_update;
        public SByte m_camp_lv;
        public Int64 m_p_score;
        public Int64 m_g_score;
        public Boolean m_is_member;
        public Boolean m_is_lose;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_state = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_sub_state = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_round = sp.ReadSByte();}
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
            if (sp.TryRead(4)) {m_dt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_can_update = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_camp_lv = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_p_score = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_g_score = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_is_member = sp.ReadBoolean();}
            if (sp.TryRead(10)) {m_is_lose = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_state);}
            if (sp.TryWrite(1)) {sp.Write(m_sub_state);}
            if (sp.TryWrite(2)) {sp.Write(m_round);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_dt);}
            if (sp.TryWrite(5)) {sp.Write(m_can_update);}
            if (sp.TryWrite(6)) {sp.Write(m_camp_lv);}
            if (sp.TryWrite(7)) {sp.Write(m_p_score);}
            if (sp.TryWrite(8)) {sp.Write(m_g_score);}
            if (sp.TryWrite(9)) {sp.Write(m_is_member);}
            if (sp.TryWrite(10)) {sp.Write(m_is_lose);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelInfo source) {
            m_state = source.m_state;
            m_sub_state = source.m_sub_state;
            m_round = source.m_round;
            m_reward = source.m_reward;
            m_dt = source.m_dt;
            m_can_update = source.m_can_update;
            m_camp_lv = source.m_camp_lv;
            m_p_score = source.m_p_score;
            m_g_score = source.m_g_score;
            m_is_member = source.m_is_member;
            m_is_lose = source.m_is_lose;
        }
    }
    
    [Serializable]
    public partial class AsRebelMarchInfoReqInfo : NetworkMessage {
        public static int[] Id = { 942,1 };
        public static Ctrl VC;
        public Int64 m_march_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AsRebelMarchInfoReqInfo source) {
            m_march_id = source.m_march_id;
        }
    }
    
    [Serializable]
    public partial class RailwayShopInfo : NetworkMessage {
        public static int[] Id = { 948,1 };
        public static Ctrl VC;
        public Int64 m_expire_time;
        public Int16 m_refresh_time;
        public Int16 m_refresh_time_max;
        public Int32 m_refresh_price;
        public List<RailwayShopItem> m_items = new List<RailwayShopItem>();
        public SByte m_shop_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_expire_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_refresh_time = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_refresh_time_max = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_refresh_price = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RailwayShopItem tmp = new RailwayShopItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_shop_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_expire_time);}
            if (sp.TryWrite(1)) {sp.Write(m_refresh_time);}
            if (sp.TryWrite(2)) {sp.Write(m_refresh_time_max);}
            if (sp.TryWrite(3)) {sp.Write(m_refresh_price);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_shop_type);}
            sp.EnEnd();
        }
        public void CopyFrom(RailwayShopInfo source) {
            m_expire_time = source.m_expire_time;
            m_refresh_time = source.m_refresh_time;
            m_refresh_time_max = source.m_refresh_time_max;
            m_refresh_price = source.m_refresh_price;
            m_items = source.m_items;
            m_shop_type = source.m_shop_type;
        }
    }
    
    [Serializable]
    public partial class B2VipShopBuyInfo : NetworkMessage {
        public static int[] Id = { 954,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(B2VipShopBuyInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class GovBuff : NetworkMessage {
        public static int[] Id = { 960,1 };
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
        public void CopyFrom(GovBuff source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignGrid : NetworkMessage {
        public static int[] Id = { 966,1 };
        public static Ctrl VC;
        public Int16 m_order;
        public Int16 m_tag;
        public ItemInfo m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_tag = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                m_reward = new ItemInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_tag);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignGrid source) {
            m_order = source.m_order;
            m_tag = source.m_tag;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class ClaimDailySubscriptionReqInfo : NetworkMessage {
        public static int[] Id = { 972,1 };
        public static Ctrl VC;
        public Int32 m_pkg_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pkg_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pkg_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimDailySubscriptionReqInfo source) {
            m_pkg_id = source.m_pkg_id;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelCurrentScoreNtfInfo : NetworkMessage {
        public static int[] Id = { 978,1 };
        public static Ctrl VC;
        public SByte m_type;
        public Int64 m_new_score;
        public Int64 m_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_new_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_new_score);}
            if (sp.TryWrite(2)) {sp.Write(m_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelCurrentScoreNtfInfo source) {
            m_type = source.m_type;
            m_new_score = source.m_new_score;
            m_dt = source.m_dt;
        }
    }
    
    [Serializable]
    public partial class RechargeCampaignInfo : NetworkMessage {
        public static int[] Id = { 984,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int16 m_cur_id;
        public Int64 m_cur_diamonds;
        public Int64 m_end_time;
        public List<RechargeCampaignCfg> m_cfg = new List<RechargeCampaignCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cur_diamonds = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cfg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RechargeCampaignCfg tmp = new RechargeCampaignCfg();
                    tmp.Decode(sp);
                    m_cfg.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_diamonds);}
            if (sp.TryWrite(3)) {sp.Write(m_end_time);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cfg.Count);
                for (int i = 0; i != m_cfg.Count; ++i) {
                    m_cfg[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RechargeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cur_id = source.m_cur_id;
            m_cur_diamonds = source.m_cur_diamonds;
            m_end_time = source.m_end_time;
            m_cfg = source.m_cfg;
        }
    }
    
    [Serializable]
    public partial class CampaignPopupNtfInfo : NetworkMessage {
        public static int[] Id = { 990,1 };
        public static Ctrl VC;
        public List<CampaignPopupInfo> m_list = new List<CampaignPopupInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignPopupInfo tmp = new CampaignPopupInfo();
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
        public void CopyFrom(CampaignPopupNtfInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class UserCostCampaignItemRule : NetworkMessage {
        public static int[] Id = { 996,1 };
        public static Ctrl VC;
        public Int32 m_cost_id;
        public ItemInfo m_src_item;
        public Int64 m_base_score;
        public List<CampaignJump> m_jump_list = new List<CampaignJump>();
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public String m_src_pic = "";
        public String m_dst_pic = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cost_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_src_item = new ItemInfo();
                m_src_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_base_score = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_jump_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignJump tmp = new CampaignJump();
                    tmp.Decode(sp);
                    m_jump_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            if (sp.TryRead(5)) {m_src_pic = sp.ReadString();}
            if (sp.TryRead(6)) {m_dst_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_src_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_base_score);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_jump_list.Count);
                for (int i = 0; i != m_jump_list.Count; ++i) {
                    m_jump_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_src_pic);}
            if (sp.TryWrite(6)) {sp.Write(m_dst_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCostCampaignItemRule source) {
            m_cost_id = source.m_cost_id;
            m_src_item = source.m_src_item;
            m_base_score = source.m_base_score;
            m_jump_list = source.m_jump_list;
            m_reward = source.m_reward;
            m_src_pic = source.m_src_pic;
            m_dst_pic = source.m_dst_pic;
        }
    }
    
    [Serializable]
    public partial class CostActivityCostAckInfo : NetworkMessage {
        public static int[] Id = { 1002,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<CostActivityCostOnce> m_result = new List<CostActivityCostOnce>();
        public CostActivityStatus m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CostActivityCostOnce tmp = new CostActivityCostOnce();
                    tmp.Decode(sp);
                    m_result.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_status = new CostActivityStatus();
                m_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_result.Count);
                for (int i = 0; i != m_result.Count; ++i) {
                    m_result[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CostActivityCostAckInfo source) {
            m_act_id = source.m_act_id;
            m_result = source.m_result;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class ProgressiveTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1008,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_step;
        public SByte m_group;
        public Int32 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_group = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_task_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step);}
            if (sp.TryWrite(2)) {sp.Write(m_group);}
            if (sp.TryWrite(3)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ProgressiveTaskRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_step = source.m_step;
            m_group = source.m_group;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class TroopCompleteNtfInfo : NetworkMessage {
        public static int[] Id = { 1014,1 };
        public static Ctrl VC;
        public Int16 m_atk_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_atk_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_atk_type);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopCompleteNtfInfo source) {
            m_atk_type = source.m_atk_type;
        }
    }
    
    [Serializable]
    public partial class AllianceShopBuyHistoryInfo : NetworkMessage {
        public static int[] Id = { 1020,1 };
        public static Ctrl VC;
        public List<AllianceShopBuyHistoryEntry> m_history = new List<AllianceShopBuyHistoryEntry>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_history.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceShopBuyHistoryEntry tmp = new AllianceShopBuyHistoryEntry();
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
        public void CopyFrom(AllianceShopBuyHistoryInfo source) {
            m_history = source.m_history;
        }
    }
    
    [Serializable]
    public partial class CitySkinListInfo : NetworkMessage {
        public static int[] Id = { 1026,1 };
        public static Ctrl VC;
        public List<CitySkinInfo> m_list = new List<CitySkinInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CitySkinInfo tmp = new CitySkinInfo();
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
        public void CopyFrom(CitySkinListInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class FogData : NetworkMessage {
        public static int[] Id = { 1032,2 };
        public static Ctrl VC;
        public UInt64 m_data1;
        public List<FogData2> m_data2 = new List<FogData2>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_data1 = sp.ReadUInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_data2.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FogData2 tmp = new FogData2();
                    tmp.Decode(sp);
                    m_data2.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_data1);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_data2.Count);
                for (int i = 0; i != m_data2.Count; ++i) {
                    m_data2[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FogData source) {
            m_data1 = source.m_data1;
            m_data2 = source.m_data2;
        }
    }
    
    [Serializable]
    public partial class TinyMonumentTile : NetworkMessage {
        public static int[] Id = { 1038,2 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_type;
        public Boolean m_is_claimed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_is_claimed = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_type);}
            if (sp.TryWrite(4)) {sp.Write(m_is_claimed);}
            sp.EnEnd();
        }
        public void CopyFrom(TinyMonumentTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_type = source.m_type;
            m_is_claimed = source.m_is_claimed;
        }
    }
    
    [Serializable]
    public partial class FireworksInfo : NetworkMessage {
        public static int[] Id = { 1044,2 };
        public static Ctrl VC;
        public Int64 m_endtime;
        public Int64 m_map_guid;
        public Int32 m_fireworks_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_fireworks_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_endtime);}
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(2)) {sp.Write(m_fireworks_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FireworksInfo source) {
            m_endtime = source.m_endtime;
            m_map_guid = source.m_map_guid;
            m_fireworks_id = source.m_fireworks_id;
        }
    }
    
    [Serializable]
    public partial class LadderDifficultyUnlockCond : NetworkMessage {
        public static int[] Id = { 1050,3 };
        public static Ctrl VC;
        public SByte m_difficulty_level;
        public Int16 m_need_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_difficulty_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_need_step = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_difficulty_level);}
            if (sp.TryWrite(1)) {sp.Write(m_need_step);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderDifficultyUnlockCond source) {
            m_difficulty_level = source.m_difficulty_level;
            m_need_step = source.m_need_step;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBoardAckInfo : NetworkMessage {
        public static int[] Id = { 1056,3 };
        public static Ctrl VC;
        public List<LadderAllianceBoardUser> m_info = new List<LadderAllianceBoardUser>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderAllianceBoardUser tmp = new LadderAllianceBoardUser();
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
        public void CopyFrom(LadderAllianceBoardAckInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class LadderEnemyMarchTipInfo : NetworkMessage {
        public static int[] Id = { 1062,3 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public String m_name = "";
        public String m_icon = "";
        public SByte m_type;
        public Int64 m_owner_id;
        public String m_owner_name = "";
        public Int32 m_owner_alliance_id;
        public String m_owner_alliance_abbr = "";
        public String m_owner_alliance_name = "";
        public Boolean m_call_help;
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_owner_id = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_owner_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_owner_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(8)) {m_owner_alliance_name = sp.ReadString();}
            if (sp.TryRead(9)) {m_call_help = sp.ReadBoolean();}
            if (sp.TryRead(10)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_type);}
            if (sp.TryWrite(4)) {sp.Write(m_owner_id);}
            if (sp.TryWrite(5)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(6)) {sp.Write(m_owner_alliance_id);}
            if (sp.TryWrite(7)) {sp.Write(m_owner_alliance_abbr);}
            if (sp.TryWrite(8)) {sp.Write(m_owner_alliance_name);}
            if (sp.TryWrite(9)) {sp.Write(m_call_help);}
            if (sp.TryWrite(10)) {
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
        public void CopyFrom(LadderEnemyMarchTipInfo source) {
            m_march_id = source.m_march_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_type = source.m_type;
            m_owner_id = source.m_owner_id;
            m_owner_name = source.m_owner_name;
            m_owner_alliance_id = source.m_owner_alliance_id;
            m_owner_alliance_abbr = source.m_owner_alliance_abbr;
            m_owner_alliance_name = source.m_owner_alliance_name;
            m_call_help = source.m_call_help;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class ActivityCmdReq : NetworkMessage {
        public static int[] Id = { 1068,3 };
        public static Ctrl VC;
        public String m_cmd = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cmd = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cmd);}
            sp.EnEnd();
        }
        public void CopyFrom(ActivityCmdReq source) {
            m_cmd = source.m_cmd;
        }
    }
    
    [Serializable]
    public partial class TimelimitQuestInfo : NetworkMessage {
        public static int[] Id = { 1074,4 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_endtime;
        public Boolean m_is_finished;
        public Boolean m_is_claimed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_is_finished = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_is_claimed = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_endtime);}
            if (sp.TryWrite(2)) {sp.Write(m_is_finished);}
            if (sp.TryWrite(3)) {sp.Write(m_is_claimed);}
            sp.EnEnd();
        }
        public void CopyFrom(TimelimitQuestInfo source) {
            m_id = source.m_id;
            m_endtime = source.m_endtime;
            m_is_finished = source.m_is_finished;
            m_is_claimed = source.m_is_claimed;
        }
    }
    
    [Serializable]
    public partial class ArenaTroopStatInfo : NetworkMessage {
        public static int[] Id = { 1080,4 };
        public static Ctrl VC;
        public ArenaTroopInfo m_troop;
        public Int64 m_kill;
        public Int64 m_heal;
        public Int64 m_remain;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_troop = new ArenaTroopInfo();
                m_troop.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_kill = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_heal = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_remain = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_troop.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_kill);}
            if (sp.TryWrite(2)) {sp.Write(m_heal);}
            if (sp.TryWrite(3)) {sp.Write(m_remain);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaTroopStatInfo source) {
            m_troop = source.m_troop;
            m_kill = source.m_kill;
            m_heal = source.m_heal;
            m_remain = source.m_remain;
        }
    }
    
    [Serializable]
    public partial class ArenaMatchAckInfo : NetworkMessage {
        public static int[] Id = { 1086,4 };
        public static Ctrl VC;
        public List<ArenaPlayerInfo> m_players = new List<ArenaPlayerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_players.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaPlayerInfo tmp = new ArenaPlayerInfo();
                    tmp.Decode(sp);
                    m_players.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_players.Count);
                for (int i = 0; i != m_players.Count; ++i) {
                    m_players[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaMatchAckInfo source) {
            m_players = source.m_players;
        }
    }
    
    [Serializable]
    public partial class ArenaRewardAckInfo : NetworkMessage {
        public static int[] Id = { 1092,4 };
        public static Ctrl VC;
        public List<ArenaRankRewardInfo> m_daily_rank_reward = new List<ArenaRankRewardInfo>();
        public List<ArenaRankRewardInfo> m_season_rank_reward = new List<ArenaRankRewardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_daily_rank_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaRankRewardInfo tmp = new ArenaRankRewardInfo();
                    tmp.Decode(sp);
                    m_daily_rank_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_season_rank_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaRankRewardInfo tmp = new ArenaRankRewardInfo();
                    tmp.Decode(sp);
                    m_season_rank_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_daily_rank_reward.Count);
                for (int i = 0; i != m_daily_rank_reward.Count; ++i) {
                    m_daily_rank_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_season_rank_reward.Count);
                for (int i = 0; i != m_season_rank_reward.Count; ++i) {
                    m_season_rank_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaRewardAckInfo source) {
            m_daily_rank_reward = source.m_daily_rank_reward;
            m_season_rank_reward = source.m_season_rank_reward;
        }
    }
    
    [Serializable]
    public partial class QuestCountdownAck : NetworkMessage {
        public static int[] Id = { 1098,4 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_begin_time;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestCountdownAck source) {
            m_id = source.m_id;
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeStatusReqInfo : NetworkMessage {
        public static int[] Id = { 1104,5 };
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
        public void CopyFrom(AllianceMobilizeStatusReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeFlushTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1110,5 };
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
        public void CopyFrom(AllianceMobilizeFlushTaskReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskFinishAckInfo : NetworkMessage {
        public static int[] Id = { 1116,5 };
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
        public void CopyFrom(AllianceMobilizeTaskFinishAckInfo source) {
            m_act_id = source.m_act_id;
            m_new_task = source.m_new_task;
        }
    }
    
    [Serializable]
    public partial class Compressed4b : NetworkMessage {
        public static int[] Id = { 1122,5 };
        public static Ctrl VC;
        public Int32 m_orig_size;
        public Byte[] m_data;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_orig_size = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_data = sp.ReadBytes4();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_orig_size);}
            if (sp.TryWrite(1)) {sp.WriteBytes4(m_data);}
            sp.EnEnd();
        }
        public void CopyFrom(Compressed4b source) {
            m_orig_size = source.m_orig_size;
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class PlayerMayorInfo : NetworkMessage {
        public static int[] Id = { 1128,7 };
        public static Ctrl VC;
        public List<MayorInfo> m_mayor = new List<MayorInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_mayor.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MayorInfo tmp = new MayorInfo();
                    tmp.Decode(sp);
                    m_mayor.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_mayor.Count);
                for (int i = 0; i != m_mayor.Count; ++i) {
                    m_mayor[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PlayerMayorInfo source) {
            m_mayor = source.m_mayor;
        }
    }
    
    [Serializable]
    public partial class UseItemParam : NetworkMessage {
        public static int[] Id = { 1135,7 };
        public static Ctrl VC;
        public List<SByte> m_optional_index = new List<SByte>();
        public String m_str_param = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_optional_index.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_optional_index.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_str_param = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_optional_index.Count);
                for (int i = 0; i != m_optional_index.Count; ++i) {
                    sp.Write(m_optional_index[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_str_param);}
            sp.EnEnd();
        }
        public void CopyFrom(UseItemParam source) {
            m_optional_index = source.m_optional_index;
            m_str_param = source.m_str_param;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerDisInfoReq : NetworkMessage {
        public static int[] Id = { 1141,8 };
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
        public void CopyFrom(B2TransferServerDisInfoReq source) {
            m_target_server = source.m_target_server;
            m_trans_type = source.m_trans_type;
        }
    }
    
    [Serializable]
    public partial class LimitedBuffInfo : NetworkMessage {
        public static int[] Id = { 1147,8 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_value;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_value = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            sp.EnEnd();
        }
        public void CopyFrom(LimitedBuffInfo source) {
            m_id = source.m_id;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class LoudSpeakerAckInfo : NetworkMessage {
        public static int[] Id = { 1153,11 };
        public static Ctrl VC;
        public Int64 m_next_time;
        public Int32 m_total_reward_cnt;
        public Int16 m_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_next_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_total_reward_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_next_time);}
            if (sp.TryWrite(1)) {sp.Write(m_total_reward_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(LoudSpeakerAckInfo source) {
            m_next_time = source.m_next_time;
            m_total_reward_cnt = source.m_total_reward_cnt;
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class MsgMap : NetworkMessage {
        public static int[] Id = { 1159,12 };
        public static Ctrl VC;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MsgMap source) {
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GvgApplyMemberListNtfInfo : NetworkMessage {
        public static int[] Id = { 1165,12 };
        public static Ctrl VC;
        public Int16 m_main_num_max;
        public Int16 m_alt_num_max;
        public List<GvgApplyMemberInfo> m_members = new List<GvgApplyMemberInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_main_num_max = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_alt_num_max = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_members.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgApplyMemberInfo tmp = new GvgApplyMemberInfo();
                    tmp.Decode(sp);
                    m_members.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_main_num_max);}
            if (sp.TryWrite(1)) {sp.Write(m_alt_num_max);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(GvgApplyMemberListNtfInfo source) {
            m_main_num_max = source.m_main_num_max;
            m_alt_num_max = source.m_alt_num_max;
            m_members = source.m_members;
        }
    }
    
    [Serializable]
    public partial class GoodsBaseTile : NetworkMessage {
        public static int[] Id = { 1171,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int32 m_cnt;
        public Int32 m_goods_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_goods_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_cnt);}
            if (sp.TryWrite(4)) {sp.Write(m_goods_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GoodsBaseTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_cnt = source.m_cnt;
            m_goods_id = source.m_goods_id;
        }
    }
    
    [Serializable]
    public partial class GvgStatistics : NetworkMessage {
        public static int[] Id = { 1177,12 };
        public static Ctrl VC;
        public Int32 m_statistics_type;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_statistics_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_statistics_type);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgStatistics source) {
            m_statistics_type = source.m_statistics_type;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldAllianceStatusInfo : NetworkMessage {
        public static int[] Id = { 1183,12 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_color;
        public Int16 m_logo;
        public Int16 m_server_id;
        public Int32 m_score;
        public Int32 m_user_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_user_count = sp.ReadInt32();}
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
            if (sp.TryWrite(7)) {sp.Write(m_user_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldAllianceStatusInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_color = source.m_color;
            m_logo = source.m_logo;
            m_server_id = source.m_server_id;
            m_score = source.m_score;
            m_user_count = source.m_user_count;
        }
    }
    
    [Serializable]
    public partial class UserArchiveInfo : NetworkMessage {
        public static int[] Id = { 1189,12 };
        public static Ctrl VC;
        public Int16 m_current_level;
        public Int64 m_cd_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cd_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_level);}
            if (sp.TryWrite(1)) {sp.Write(m_cd_time);}
            sp.EnEnd();
        }
        public void CopyFrom(UserArchiveInfo source) {
            m_current_level = source.m_current_level;
            m_cd_time = source.m_cd_time;
        }
    }
    
    [Serializable]
    public partial class RouletteCampaignInfo : NetworkMessage {
        public static int[] Id = { 1213,14 };
        public static Ctrl VC;
        public BaseCampaignInfo m_base_info;
        public List<RouletteCircleInfo> m_circle_info = new List<RouletteCircleInfo>();
        public Int32 m_diamond_exch_cost;
        public List<BaseTaskCampaignInfo> m_task_info = new List<BaseTaskCampaignInfo>();
        public String m_coin_pic = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new BaseCampaignInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_circle_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RouletteCircleInfo tmp = new RouletteCircleInfo();
                    tmp.Decode(sp);
                    m_circle_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_diamond_exch_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_coin_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_circle_info.Count);
                for (int i = 0; i != m_circle_info.Count; ++i) {
                    m_circle_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_diamond_exch_cost);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_info.Count);
                for (int i = 0; i != m_task_info.Count; ++i) {
                    m_task_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_coin_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteCampaignInfo source) {
            m_base_info = source.m_base_info;
            m_circle_info = source.m_circle_info;
            m_diamond_exch_cost = source.m_diamond_exch_cost;
            m_task_info = source.m_task_info;
            m_coin_pic = source.m_coin_pic;
        }
    }
    
    [Serializable]
    public partial class RouletteTaskCompleteReqInfo : NetworkMessage {
        public static int[] Id = { 1219,14 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int64 m_task_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteTaskCompleteReqInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class UserSetCurrentCityNameplateInfo : NetworkMessage {
        public static int[] Id = { 1225,18 };
        public static Ctrl VC;
        public Int16 m_current_nameplate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_nameplate = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_nameplate);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSetCurrentCityNameplateInfo source) {
            m_current_nameplate = source.m_current_nameplate;
        }
    }
    
    [Serializable]
    public partial class DiamondBuyCityNameplateInfo : NetworkMessage {
        public static int[] Id = { 1231,18 };
        public static Ctrl VC;
        public Int16 m_city_nameplate_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_city_nameplate_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_city_nameplate_id);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondBuyCityNameplateInfo source) {
            m_city_nameplate_id = source.m_city_nameplate_id;
        }
    }
    
    [Serializable]
    public partial class UserUnlockEmoticonInfo : NetworkMessage {
        public static int[] Id = { 1237,18 };
        public static Ctrl VC;
        public Int16 m_unlock_type;
        public Int16 m_unlock_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_unlock_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_unlock_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_unlock_type);}
            if (sp.TryWrite(1)) {sp.Write(m_unlock_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserUnlockEmoticonInfo source) {
            m_unlock_type = source.m_unlock_type;
            m_unlock_id = source.m_unlock_id;
        }
    }
    
    [Serializable]
    public partial class UserDailyGatherRewardInfo : NetworkMessage {
        public static int[] Id = { 1243,19 };
        public static Ctrl VC;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<ItemInfo> m_gacha_items = new List<ItemInfo>();

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
                m_gacha_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_gacha_items.Add(tmp);
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
                sp.Write((UInt16)m_gacha_items.Count);
                for (int i = 0; i != m_gacha_items.Count; ++i) {
                    m_gacha_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserDailyGatherRewardInfo source) {
            m_items = source.m_items;
            m_gacha_items = source.m_gacha_items;
        }
    }
    
    [Serializable]
    public partial class MailConfirmDoChoiceReqInfo : NetworkMessage {
        public static int[] Id = { 1249,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;
        public SByte m_choice;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_choice = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
            if (sp.TryWrite(1)) {sp.Write(m_choice);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmDoChoiceReqInfo source) {
            m_confirm_id = source.m_confirm_id;
            m_choice = source.m_choice;
        }
    }
    
    [Serializable]
    public partial class MailConfirmChoiceStatus : NetworkMessage {
        public static int[] Id = { 1255,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;
        public SByte m_choice;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_choice = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
            if (sp.TryWrite(1)) {sp.Write(m_choice);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmChoiceStatus source) {
            m_confirm_id = source.m_confirm_id;
            m_choice = source.m_choice;
        }
    }
    
    [Serializable]
    public partial class KvkCampaignInfo : NetworkMessage {
        public static int[] Id = { 1261,19 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public String m_kvk_map = "";
        public Int16 m_kvk_id;
        public List<Int16> m_server_id_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_kvk_map = sp.ReadString();}
            if (sp.TryRead(2)) {m_kvk_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_id_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_server_id_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_kvk_map);}
            if (sp.TryWrite(2)) {sp.Write(m_kvk_id);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_id_list.Count);
                for (int i = 0; i != m_server_id_list.Count; ++i) {
                    sp.Write(m_server_id_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_kvk_map = source.m_kvk_map;
            m_kvk_id = source.m_kvk_id;
            m_server_id_list = source.m_server_id_list;
        }
    }
    
    [Serializable]
    public partial class BossCampaignSlotInfo : NetworkMessage {
        public static int[] Id = { 1267,19 };
        public static Ctrl VC;
        public SByte m_slot;
        public BossCampaignSlotArmy m_army_info;
        public Boolean m_can_edit;
        public Int64 m_cur_march_id;
        public SByte m_score_level;
        public Int64 m_damage;
        public Boolean m_can_claim;
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_army_info = new BossCampaignSlotArmy();
                m_army_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_can_edit = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_cur_march_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_score_level = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_can_claim = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_army_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_can_edit);}
            if (sp.TryWrite(3)) {sp.Write(m_cur_march_id);}
            if (sp.TryWrite(4)) {sp.Write(m_score_level);}
            if (sp.TryWrite(5)) {sp.Write(m_damage);}
            if (sp.TryWrite(6)) {sp.Write(m_can_claim);}
            if (sp.TryWrite(7)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(8)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(9)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(10)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignSlotInfo source) {
            m_slot = source.m_slot;
            m_army_info = source.m_army_info;
            m_can_edit = source.m_can_edit;
            m_cur_march_id = source.m_cur_march_id;
            m_score_level = source.m_score_level;
            m_damage = source.m_damage;
            m_can_claim = source.m_can_claim;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class BossCampaignBeKilledNtfInfo : NetworkMessage {
        public static int[] Id = { 1273,19 };
        public static Ctrl VC;
        public SByte m_boss_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_boss_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_boss_level);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignBeKilledNtfInfo source) {
            m_boss_level = source.m_boss_level;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRecordReqInfo : NetworkMessage {
        public static int[] Id = { 1279,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_start;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_start = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_start);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignRecordReqInfo source) {
            m_act_id = source.m_act_id;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class ServerAllianceBuildingStateList : NetworkMessage {
        public static int[] Id = { 1285,19 };
        public static Ctrl VC;
        public Int16 m_gs_id;
        public List<AllianceBuildingState> m_list = new List<AllianceBuildingState>();
        public Int32 m_max_tower;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_gs_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBuildingState tmp = new AllianceBuildingState();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_max_tower = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_gs_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_max_tower);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerAllianceBuildingStateList source) {
            m_gs_id = source.m_gs_id;
            m_list = source.m_list;
            m_max_tower = source.m_max_tower;
        }
    }
    
    [Serializable]
    public partial class KvkFinishedQuestInfo : NetworkMessage {
        public static int[] Id = { 1291,19 };
        public static Ctrl VC;
        public Int32 m_quest_id;
        public Boolean m_can_claim;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_quest_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_can_claim = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_quest_id);}
            if (sp.TryWrite(1)) {sp.Write(m_can_claim);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkFinishedQuestInfo source) {
            m_quest_id = source.m_quest_id;
            m_can_claim = source.m_can_claim;
        }
    }
    
    [Serializable]
    public partial class KvkLandInfo : NetworkMessage {
        public static int[] Id = { 1297,19 };
        public static Ctrl VC;
        public List<KvkLandColorInfo> m_color_info = new List<KvkLandColorInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_color_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkLandColorInfo tmp = new KvkLandColorInfo();
                    tmp.Decode(sp);
                    m_color_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_color_info.Count);
                for (int i = 0; i != m_color_info.Count; ++i) {
                    m_color_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkLandInfo source) {
            m_color_info = source.m_color_info;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortKillDonateInfo : NetworkMessage {
        public static int[] Id = { 1303,19 };
        public static Ctrl VC;
        public SByte m_type;
        public Int16 m_kill_cnt;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Int32 m_cur_kill_cnt;
        public Int32 m_kvk_honour;
        public Int32 m_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_kill_cnt = sp.ReadInt16();}
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
            if (sp.TryRead(3)) {m_cur_kill_cnt = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_kvk_honour = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_pt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_kill_cnt);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_cur_kill_cnt);}
            if (sp.TryWrite(4)) {sp.Write(m_kvk_honour);}
            if (sp.TryWrite(5)) {sp.Write(m_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortKillDonateInfo source) {
            m_type = source.m_type;
            m_kill_cnt = source.m_kill_cnt;
            m_reward = source.m_reward;
            m_cur_kill_cnt = source.m_cur_kill_cnt;
            m_kvk_honour = source.m_kvk_honour;
            m_pt = source.m_pt;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortExchangeDonateReqInfo : NetworkMessage {
        public static int[] Id = { 1309,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_item_id;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortExchangeDonateReqInfo source) {
            m_act_id = source.m_act_id;
            m_item_id = source.m_item_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class SevenDailyLoginInfo : NetworkMessage {
        public static int[] Id = { 1315,20 };
        public static Ctrl VC;
        public Int64 m_begin_time;
        public List<SByte> m_rewards_state = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards_state.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_rewards_state.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards_state.Count);
                for (int i = 0; i != m_rewards_state.Count; ++i) {
                    sp.Write(m_rewards_state[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SevenDailyLoginInfo source) {
            m_begin_time = source.m_begin_time;
            m_rewards_state = source.m_rewards_state;
        }
    }
    
    [Serializable]
    public partial class ServerTypeInfo : NetworkMessage {
        public static int[] Id = { 1321,21 };
        public static Ctrl VC;
        public Int16 m_server_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_type);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerTypeInfo source) {
            m_server_type = source.m_server_type;
        }
    }
    
    [Serializable]
    public partial class SlotMachineRollResult : NetworkMessage {
        public static int[] Id = { 1341,22 };
        public static Ctrl VC;
        public List<Int32> m_result_uid = new List<Int32>();
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result_uid.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_result_uid.Add(tmp);
                }
            }
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_result_uid.Count);
                for (int i = 0; i != m_result_uid.Count; ++i) {
                    sp.Write(m_result_uid[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
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
        public void CopyFrom(SlotMachineRollResult source) {
            m_result_uid = source.m_result_uid;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class MonumentActionCd : NetworkMessage {
        public static int[] Id = { 1347,23 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int64 m_cd;
        public List<Int64> m_param = new List<Int64>();
        public Int64 m_endtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cd = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_param.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_param.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {m_endtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_cd);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_param.Count);
                for (int i = 0; i != m_param.Count; ++i) {
                    sp.Write(m_param[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {sp.Write(m_endtime);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentActionCd source) {
            m_type = source.m_type;
            m_cd = source.m_cd;
            m_param = source.m_param;
            m_endtime = source.m_endtime;
        }
    }
    
    [Serializable]
    public partial class KvkAvailableAgentListInfo : NetworkMessage {
        public static int[] Id = { 1353,23 };
        public static Ctrl VC;
        public List<Int16> m_agent_list = new List<Int16>();
        public Int16 m_gs_id;
        public Int16 m_open_day;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent_list.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_gs_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_open_day = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent_list.Count);
                for (int i = 0; i != m_agent_list.Count; ++i) {
                    sp.Write(m_agent_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_gs_id);}
            if (sp.TryWrite(2)) {sp.Write(m_open_day);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkAvailableAgentListInfo source) {
            m_agent_list = source.m_agent_list;
            m_gs_id = source.m_gs_id;
            m_open_day = source.m_open_day;
        }
    }
    
    [Serializable]
    public partial class PlayerBlackListNtfInfo : NetworkMessage {
        public static int[] Id = { 1359,23 };
        public static Ctrl VC;
        public List<PlayerBlackListItem> m_black_list = new List<PlayerBlackListItem>();
        public SByte m_ntf_type;

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
            if (sp.TryRead(1)) {m_ntf_type = sp.ReadSByte();}
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
            if (sp.TryWrite(1)) {sp.Write(m_ntf_type);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerBlackListNtfInfo source) {
            m_black_list = source.m_black_list;
            m_ntf_type = source.m_ntf_type;
        }
    }
    
    [Serializable]
    public partial class UserAllWarshipsInfo : NetworkMessage {
        public static int[] Id = { 1365,23 };
        public static Ctrl VC;
        public List<UserWarshipInfo> m_warships = new List<UserWarshipInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_warships.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserWarshipInfo tmp = new UserWarshipInfo();
                    tmp.Decode(sp);
                    m_warships.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_warships.Count);
                for (int i = 0; i != m_warships.Count; ++i) {
                    m_warships[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserAllWarshipsInfo source) {
            m_warships = source.m_warships;
        }
    }
    
    [Serializable]
    public partial class UserWarshipSkillInfo : NetworkMessage {
        public static int[] Id = { 1371,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int16 m_cur_skill_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_skill_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_skill_level);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipSkillInfo source) {
            m_warship_id = source.m_warship_id;
            m_cur_skill_level = source.m_cur_skill_level;
        }
    }
    
    [Serializable]
    public partial class KvkPreCreepExchangeAckInfo : NetworkMessage {
        public static int[] Id = { 1377,23 };
        public static Ctrl VC;
        public SByte m_step;
        public Int32 m_exchange_id;
        public Int32 m_add_point;
        public Int32 m_cur_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_exchange_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_add_point = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_cur_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_exchange_id);}
            if (sp.TryWrite(2)) {sp.Write(m_add_point);}
            if (sp.TryWrite(3)) {sp.Write(m_cur_point);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreCreepExchangeAckInfo source) {
            m_step = source.m_step;
            m_exchange_id = source.m_exchange_id;
            m_add_point = source.m_add_point;
            m_cur_point = source.m_cur_point;
        }
    }
    
    [Serializable]
    public partial class BuySpecialPriceItemNtfInfo : NetworkMessage {
        public static int[] Id = { 1383,23 };
        public static Ctrl VC;
        public List<SpecialItemPrice> m_prices = new List<SpecialItemPrice>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_prices.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SpecialItemPrice tmp = new SpecialItemPrice();
                    tmp.Decode(sp);
                    m_prices.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_prices.Count);
                for (int i = 0; i != m_prices.Count; ++i) {
                    m_prices[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BuySpecialPriceItemNtfInfo source) {
            m_prices = source.m_prices;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardCampaignInfo : NetworkMessage {
        public static int[] Id = { 1389,23 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public SByte m_difficulty;
        public List<AllianceBoardLevelInfo> m_level_reward = new List<AllianceBoardLevelInfo>();
        public AllianceBoardLevelStatus m_level_status;
        public Boolean m_open;
        public Int32 m_member_cnt;
        public Boolean m_is_exit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_difficulty = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardLevelInfo tmp = new AllianceBoardLevelInfo();
                    tmp.Decode(sp);
                    m_level_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_level_status = new AllianceBoardLevelStatus();
                m_level_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_open = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_member_cnt = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_is_exit = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_difficulty);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_reward.Count);
                for (int i = 0; i != m_level_reward.Count; ++i) {
                    m_level_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_level_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_open);}
            if (sp.TryWrite(5)) {sp.Write(m_member_cnt);}
            if (sp.TryWrite(6)) {sp.Write(m_is_exit);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_difficulty = source.m_difficulty;
            m_level_reward = source.m_level_reward;
            m_level_status = source.m_level_status;
            m_open = source.m_open;
            m_member_cnt = source.m_member_cnt;
            m_is_exit = source.m_is_exit;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardTaskStatusInfo : NetworkMessage {
        public static int[] Id = { 1395,23 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public Int32 m_cur_point;
        public Int64 m_end_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cur_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_point);}
            if (sp.TryWrite(2)) {sp.Write(m_end_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardTaskStatusInfo source) {
            m_task_id = source.m_task_id;
            m_cur_point = source.m_cur_point;
            m_end_dt = source.m_end_dt;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardFinishTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1401,23 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardFinishTaskReqInfo source) {
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardLevelStatusUpdateNtfInfo : NetworkMessage {
        public static int[] Id = { 1407,23 };
        public static Ctrl VC;
        public AllianceBoardLevelStatus m_level_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_level_status = new AllianceBoardLevelStatus();
                m_level_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_level_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardLevelStatusUpdateNtfInfo source) {
            m_level_status = source.m_level_status;
        }
    }
    
    [Serializable]
    public partial class UseAllRssItemReqInfo : NetworkMessage {
        public static int[] Id = { 1413,23 };
        public static Ctrl VC;
        public SByte m_rss_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rss_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rss_type);}
            sp.EnEnd();
        }
        public void CopyFrom(UseAllRssItemReqInfo source) {
            m_rss_type = source.m_rss_type;
        }
    }
    
    [Serializable]
    public partial class KvkPreCreepListAckInfo : NetworkMessage {
        public static int[] Id = { 1419,23 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreCreepListAckInfo source) {
            m_march_id = source.m_march_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class UnlockAsTaskGroupReqInfo : NetworkMessage {
        public static int[] Id = { 1425,23 };
        public static Ctrl VC;
        public Int16 m_group;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group);}
            sp.EnEnd();
        }
        public void CopyFrom(UnlockAsTaskGroupReqInfo source) {
            m_group = source.m_group;
        }
    }
    
    [Serializable]
    public partial class SetAgentBackgroundReqInfo : NetworkMessage {
        public static int[] Id = { 1431,23 };
        public static Ctrl VC;
        public List<AgentBackgroundInfo> m_agent_bg = new List<AgentBackgroundInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent_bg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AgentBackgroundInfo tmp = new AgentBackgroundInfo();
                    tmp.Decode(sp);
                    m_agent_bg.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent_bg.Count);
                for (int i = 0; i != m_agent_bg.Count; ++i) {
                    m_agent_bg[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SetAgentBackgroundReqInfo source) {
            m_agent_bg = source.m_agent_bg;
        }
    }
    
    [Serializable]
    public partial class AsTaskScoreMemberInfo : NetworkMessage {
        public static int[] Id = { 1437,23 };
        public static Ctrl VC;
        public String m_name = "";
        public Int64 m_score;
        public Int64 m_id;
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_vip_level;
        public Int16 m_favor_agent;
        public Int32 m_skin;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(5)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_vip_level = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_favor_agent = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_skin = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_id);}
            if (sp.TryWrite(3)) {sp.Write(m_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_avatar);}
            if (sp.TryWrite(5)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(6)) {sp.Write(m_vip_level);}
            if (sp.TryWrite(7)) {sp.Write(m_favor_agent);}
            if (sp.TryWrite(8)) {sp.Write(m_skin);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskScoreMemberInfo source) {
            m_name = source.m_name;
            m_score = source.m_score;
            m_id = source.m_id;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_vip_level = source.m_vip_level;
            m_favor_agent = source.m_favor_agent;
            m_skin = source.m_skin;
        }
    }
    
    [Serializable]
    public partial class ShameAgentChoice : NetworkMessage {
        public static int[] Id = { 1443,25 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int16 m_level;
        public Int16 m_star;
        public Int16 m_rank;
        public Int32 m_force;
        public SByte m_quality;
        public Int32 m_study_level;
        public Int64 m_weapon_id;
        public Int32 m_weapon_power;
        public Int32 m_skin;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_force = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_quality = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_study_level = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_weapon_id = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_weapon_power = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_skin = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_star);}
            if (sp.TryWrite(3)) {sp.Write(m_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_force);}
            if (sp.TryWrite(5)) {sp.Write(m_quality);}
            if (sp.TryWrite(6)) {sp.Write(m_study_level);}
            if (sp.TryWrite(7)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(8)) {sp.Write(m_weapon_power);}
            if (sp.TryWrite(9)) {sp.Write(m_skin);}
            sp.EnEnd();
        }
        public void CopyFrom(ShameAgentChoice source) {
            m_agent_id = source.m_agent_id;
            m_level = source.m_level;
            m_star = source.m_star;
            m_rank = source.m_rank;
            m_force = source.m_force;
            m_quality = source.m_quality;
            m_study_level = source.m_study_level;
            m_weapon_id = source.m_weapon_id;
            m_weapon_power = source.m_weapon_power;
            m_skin = source.m_skin;
        }
    }
    
    [Serializable]
    public partial class WeaponInfo : NetworkMessage {
        public static int[] Id = { 1449,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_weapon_id;
        public Int16 m_star;
        public Int16 m_level;
        public Int32 m_level_exp;
        public Int32 m_star_exp;
        public List<Int16> m_attr_list = new List<Int16>();
        public List<Int16> m_attr_level = new List<Int16>();
        public Int32 m_skill_id;
        public Int16 m_skill_level;
        public Int16 m_agent;
        public Int32 m_init_id;
        public Boolean m_lock;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_weapon_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_level_exp = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_star_exp = sp.ReadInt32();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attr_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_attr_list.Add(tmp);
                }
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_attr_level.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_attr_level.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_skill_level = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_agent = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_init_id = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_lock = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(2)) {sp.Write(m_star);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_level_exp);}
            if (sp.TryWrite(5)) {sp.Write(m_star_exp);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attr_list.Count);
                for (int i = 0; i != m_attr_list.Count; ++i) {
                    sp.Write(m_attr_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attr_level.Count);
                for (int i = 0; i != m_attr_level.Count; ++i) {
                    sp.Write(m_attr_level[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(9)) {sp.Write(m_skill_level);}
            if (sp.TryWrite(10)) {sp.Write(m_agent);}
            if (sp.TryWrite(11)) {sp.Write(m_init_id);}
            if (sp.TryWrite(12)) {sp.Write(m_lock);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponInfo source) {
            m_id = source.m_id;
            m_weapon_id = source.m_weapon_id;
            m_star = source.m_star;
            m_level = source.m_level;
            m_level_exp = source.m_level_exp;
            m_star_exp = source.m_star_exp;
            m_attr_list = source.m_attr_list;
            m_attr_level = source.m_attr_level;
            m_skill_id = source.m_skill_id;
            m_skill_level = source.m_skill_level;
            m_agent = source.m_agent;
            m_init_id = source.m_init_id;
            m_lock = source.m_lock;
        }
    }
    
    [Serializable]
    public partial class WeaponAddStarReqInfo : NetworkMessage {
        public static int[] Id = { 1455,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public List<Int64> m_weapon_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_list.Count);
                for (int i = 0; i != m_weapon_list.Count; ++i) {
                    sp.Write(m_weapon_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeaponAddStarReqInfo source) {
            m_id = source.m_id;
            m_weapon_list = source.m_weapon_list;
        }
    }
    
    [Serializable]
    public partial class WeaponGachaAckInfo : NetworkMessage {
        public static int[] Id = { 1461,25 };
        public static Ctrl VC;
        public List<WeaponInfo> m_weapon_list = new List<WeaponInfo>();
        public List<WeaponAutoSplitInfo> m_auto_split = new List<WeaponAutoSplitInfo>();

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
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_auto_split.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WeaponAutoSplitInfo tmp = new WeaponAutoSplitInfo();
                    tmp.Decode(sp);
                    m_auto_split.Add(tmp);
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_auto_split.Count);
                for (int i = 0; i != m_auto_split.Count; ++i) {
                    m_auto_split[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeaponGachaAckInfo source) {
            m_weapon_list = source.m_weapon_list;
            m_auto_split = source.m_auto_split;
        }
    }
    
    [Serializable]
    public partial class UserRefundInfo : NetworkMessage {
        public static int[] Id = { 1467,25 };
        public static Ctrl VC;
        public String m_title = "";
        public String m_product_id = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title = sp.ReadString();}
            if (sp.TryRead(1)) {m_product_id = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title);}
            if (sp.TryWrite(1)) {sp.Write(m_product_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserRefundInfo source) {
            m_title = source.m_title;
            m_product_id = source.m_product_id;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomOpInfo : NetworkMessage {
        public static int[] Id = { 1473,25 };
        public static Ctrl VC;
        public Int32 m_r_id;
        public SByte m_op_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_r_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_op_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_r_id);}
            if (sp.TryWrite(1)) {sp.Write(m_op_type);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomOpInfo source) {
            m_r_id = source.m_r_id;
            m_op_type = source.m_op_type;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomGiftOpInfo : NetworkMessage {
        public static int[] Id = { 1479,25 };
        public static Ctrl VC;
        public Int64 m_op_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_op_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_op_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomGiftOpInfo source) {
            m_op_id = source.m_op_id;
        }
    }
    
    [Serializable]
    public partial class SwapReinforceTroopReqInfo : NetworkMessage {
        public static int[] Id = { 1485,25 };
        public static Ctrl VC;
        public Int64 m_building_id;
        public Int64 m_group1_id;
        public Int64 m_group2_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_group1_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_group2_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_id);}
            if (sp.TryWrite(1)) {sp.Write(m_group1_id);}
            if (sp.TryWrite(2)) {sp.Write(m_group2_id);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(SwapReinforceTroopReqInfo source) {
            m_building_id = source.m_building_id;
            m_group1_id = source.m_group1_id;
            m_group2_id = source.m_group2_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardApplyTaskRecord : NetworkMessage {
        public static int[] Id = { 1491,27 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int32 m_task_id;
        public Int64 m_apply_dt;
        public Int16 m_vip;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(4)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_apply_dt = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_vip = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_avatar);}
            if (sp.TryWrite(4)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(5)) {sp.Write(m_task_id);}
            if (sp.TryWrite(6)) {sp.Write(m_apply_dt);}
            if (sp.TryWrite(7)) {sp.Write(m_vip);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardApplyTaskRecord source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_task_id = source.m_task_id;
            m_apply_dt = source.m_apply_dt;
            m_vip = source.m_vip;
        }
    }
    
    [Serializable]
    public partial class RankingRewardCfgList : NetworkMessage {
        public static int[] Id = { 1497,27 };
        public static Ctrl VC;
        public List<RankingRewardCfg> m_list = new List<RankingRewardCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankingRewardCfg tmp = new RankingRewardCfg();
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
        public void CopyFrom(RankingRewardCfgList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class UserArmyBannerInfo : NetworkMessage {
        public static int[] Id = { 1510,29 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_num;
        public List<Int64> m_used_group_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_used_group_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_used_group_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_used_group_list.Count);
                for (int i = 0; i != m_used_group_list.Count; ++i) {
                    sp.Write(m_used_group_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserArmyBannerInfo source) {
            m_id = source.m_id;
            m_num = source.m_num;
            m_used_group_list = source.m_used_group_list;
        }
    }
    
    [Serializable]
    public partial class KvkBountyServerRankAckInfo : NetworkMessage {
        public static int[] Id = { 1533,32 };
        public static Ctrl VC;
        public List<KvkBountyServerRankInfo> m_rank_list = new List<KvkBountyServerRankInfo>();
        public KvkBountyServerRankInfo m_user_server_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkBountyServerRankInfo tmp = new KvkBountyServerRankInfo();
                    tmp.Decode(sp);
                    m_rank_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_user_server_rank = new KvkBountyServerRankInfo();
                m_user_server_rank.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_list.Count);
                for (int i = 0; i != m_rank_list.Count; ++i) {
                    m_rank_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_user_server_rank.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBountyServerRankAckInfo source) {
            m_rank_list = source.m_rank_list;
            m_user_server_rank = source.m_user_server_rank;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignSelectOptionAckInfo : NetworkMessage {
        public static int[] Id = { 1544,33 };
        public static Ctrl VC;
        public WheelCampaignInfo m_campaign_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_campaign_info = new WheelCampaignInfo();
                m_campaign_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_campaign_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignSelectOptionAckInfo source) {
            m_campaign_info = source.m_campaign_info;
        }
    }
    
    [Serializable]
    public partial class AgentWgtChangeTalentReqInfo : NetworkMessage {
        public static int[] Id = { 1598,33 };
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
        public void CopyFrom(AgentWgtChangeTalentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_box_id = source.m_box_id;
        }
    }
    
    [Serializable]
    public partial class NbpCfg : NetworkMessage {
        public static int[] Id = { 1636,34 };
        public static Ctrl VC;
        public List<NbpLevelCfg> m_level_rewards = new List<NbpLevelCfg>();
        public Int32 m_buy_exp_point;
        public Int32 m_buy_exp_cost_gold;
        public Int32 m_extra_normal_reward;
        public Int32 m_extra_senior_reward;
        public Int32 m_grade_exp;
        public Int32 m_max_grade;
        public Int32 m_kill_enemy_exp;
        public Int32 m_kill_monster_exp;
        public Int32 m_daily_event_point;
        public Int32 m_daily_event_exp;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NbpLevelCfg tmp = new NbpLevelCfg();
                    tmp.Decode(sp);
                    m_level_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_buy_exp_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_buy_exp_cost_gold = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_extra_normal_reward = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_extra_senior_reward = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_grade_exp = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_max_grade = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_kill_enemy_exp = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_kill_monster_exp = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_daily_event_point = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_daily_event_exp = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_rewards.Count);
                for (int i = 0; i != m_level_rewards.Count; ++i) {
                    m_level_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_buy_exp_point);}
            if (sp.TryWrite(2)) {sp.Write(m_buy_exp_cost_gold);}
            if (sp.TryWrite(3)) {sp.Write(m_extra_normal_reward);}
            if (sp.TryWrite(4)) {sp.Write(m_extra_senior_reward);}
            if (sp.TryWrite(5)) {sp.Write(m_grade_exp);}
            if (sp.TryWrite(6)) {sp.Write(m_max_grade);}
            if (sp.TryWrite(7)) {sp.Write(m_kill_enemy_exp);}
            if (sp.TryWrite(8)) {sp.Write(m_kill_monster_exp);}
            if (sp.TryWrite(9)) {sp.Write(m_daily_event_point);}
            if (sp.TryWrite(10)) {sp.Write(m_daily_event_exp);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpCfg source) {
            m_level_rewards = source.m_level_rewards;
            m_buy_exp_point = source.m_buy_exp_point;
            m_buy_exp_cost_gold = source.m_buy_exp_cost_gold;
            m_extra_normal_reward = source.m_extra_normal_reward;
            m_extra_senior_reward = source.m_extra_senior_reward;
            m_grade_exp = source.m_grade_exp;
            m_max_grade = source.m_max_grade;
            m_kill_enemy_exp = source.m_kill_enemy_exp;
            m_kill_monster_exp = source.m_kill_monster_exp;
            m_daily_event_point = source.m_daily_event_point;
            m_daily_event_exp = source.m_daily_event_exp;
        }
    }
    
    [Serializable]
    public partial class MonopolyCampaignInfo : NetworkMessage {
        public static int[] Id = { 1642,35 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public MonopolyCfg m_cfg;
        public MonopolyPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new MonopolyCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new MonopolyPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class MonopolyRollDiceAckInfo : NetworkMessage {
        public static int[] Id = { 1650,35 };
        public static Ctrl VC;
        public List<Int32> m_points = new List<Int32>();
        public MonopolyPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_points.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_points.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                m_player_info = new MonopolyPlayerInfo();
                m_player_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_points.Count);
                for (int i = 0; i != m_points.Count; ++i) {
                    sp.Write(m_points[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_player_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyRollDiceAckInfo source) {
            m_points = source.m_points;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class KvkPvpRewardChangeInfo : NetworkMessage {
        public static int[] Id = { 1666,36 };
        public static Ctrl VC;
        public Int64 m_diamond;
        public Int64 m_kvk_kill_point;
        public Int64 m_food;
        public Int64 m_energy;
        public Int64 m_oil;
        public Int64 m_steel;
        public Int64 m_honor_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_diamond = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_kvk_kill_point = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_food = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_energy = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_oil = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_steel = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_honor_point = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_diamond);}
            if (sp.TryWrite(1)) {sp.Write(m_kvk_kill_point);}
            if (sp.TryWrite(2)) {sp.Write(m_food);}
            if (sp.TryWrite(3)) {sp.Write(m_energy);}
            if (sp.TryWrite(4)) {sp.Write(m_oil);}
            if (sp.TryWrite(5)) {sp.Write(m_steel);}
            if (sp.TryWrite(6)) {sp.Write(m_honor_point);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPvpRewardChangeInfo source) {
            m_diamond = source.m_diamond;
            m_kvk_kill_point = source.m_kvk_kill_point;
            m_food = source.m_food;
            m_energy = source.m_energy;
            m_oil = source.m_oil;
            m_steel = source.m_steel;
            m_honor_point = source.m_honor_point;
        }
    }
    
    [Serializable]
    public partial class DeleteCharacterCheckReqInfo : NetworkMessage {
        public static int[] Id = { 1672,38 };
        public static Ctrl VC;
        public Int64 m_character_id;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_character_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_character_id);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(DeleteCharacterCheckReqInfo source) {
            m_character_id = source.m_character_id;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class SetPrivateCustomRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1683,38 };
        public static Ctrl VC;
        public Int32 m_id;
        public List<Int32> m_custom_reward_index = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_custom_reward_index.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_custom_reward_index.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_custom_reward_index.Count);
                for (int i = 0; i != m_custom_reward_index.Count; ++i) {
                    sp.Write(m_custom_reward_index[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SetPrivateCustomRewardReqInfo source) {
            m_id = source.m_id;
            m_custom_reward_index = source.m_custom_reward_index;
        }
    }
    
    [Serializable]
    public partial class EquipMakeReqInfo : NetworkMessage {
        public static int[] Id = { 1697,40 };
        public static Ctrl VC;
        public Int32 m_model_id;
        public Boolean m_use_convenient;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_model_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_use_convenient = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_model_id);}
            if (sp.TryWrite(1)) {sp.Write(m_use_convenient);}
            sp.EnEnd();
        }
        public void CopyFrom(EquipMakeReqInfo source) {
            m_model_id = source.m_model_id;
            m_use_convenient = source.m_use_convenient;
        }
    }
    
    [Serializable]
    public partial class AgentWearEquipReqInfo : NetworkMessage {
        public static int[] Id = { 1703,40 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public SByte m_part_id;
        public Int64 m_equip_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_part_id = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_equip_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_part_id);}
            if (sp.TryWrite(2)) {sp.Write(m_equip_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentWearEquipReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_part_id = source.m_part_id;
            m_equip_id = source.m_equip_id;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeCampaignInfo : NetworkMessage {
        public static int[] Id = { 1712,41 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<LimitedExchangeCfg> m_cfgs = new List<LimitedExchangeCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LimitedExchangeCfg tmp = new LimitedExchangeCfg();
                    tmp.Decode(sp);
                    m_cfgs.Add(tmp);
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
                sp.Write((UInt16)m_cfgs.Count);
                for (int i = 0; i != m_cfgs.Count; ++i) {
                    m_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfgs = source.m_cfgs;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalCampaignInfo : NetworkMessage {
        public static int[] Id = { 1722,41 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int32 m_season;
        public Int32 m_level;
        public Int32 m_max_level;
        public Int32 m_end_award_index;
        public List<AbandonedArsenalGridInfo> m_grids = new List<AbandonedArsenalGridInfo>();
        public AbandonedArsenalCampaignCfg m_level_cfg;
        public Int32 m_buy_cost_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_season = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_max_level = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_end_award_index = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_grids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AbandonedArsenalGridInfo tmp = new AbandonedArsenalGridInfo();
                    tmp.Decode(sp);
                    m_grids.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                m_level_cfg = new AbandonedArsenalCampaignCfg();
                m_level_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_buy_cost_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_season);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_max_level);}
            if (sp.TryWrite(4)) {sp.Write(m_end_award_index);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_grids.Count);
                for (int i = 0; i != m_grids.Count; ++i) {
                    m_grids[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_level_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_buy_cost_num);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_season = source.m_season;
            m_level = source.m_level;
            m_max_level = source.m_max_level;
            m_end_award_index = source.m_end_award_index;
            m_grids = source.m_grids;
            m_level_cfg = source.m_level_cfg;
            m_buy_cost_num = source.m_buy_cost_num;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalOpenGridAckInfo : NetworkMessage {
        public static int[] Id = { 1728,41 };
        public static Ctrl VC;
        public Int32 m_grid_index;
        public Int32 m_award_cfg_index;
        public AbandonedArsenalCampaignInfo m_campaign_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_grid_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_award_cfg_index = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                m_campaign_info = new AbandonedArsenalCampaignInfo();
                m_campaign_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_grid_index);}
            if (sp.TryWrite(1)) {sp.Write(m_award_cfg_index);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_campaign_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalOpenGridAckInfo source) {
            m_grid_index = source.m_grid_index;
            m_award_cfg_index = source.m_award_cfg_index;
            m_campaign_info = source.m_campaign_info;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeCampaignCfg : NetworkMessage {
        public static int[] Id = { 1735,42 };
        public static Ctrl VC;
        public Int32 m_cost_type;
        public Int32 m_cost_param;
        public Int32 m_once_price;
        public Int32 m_fifth_price;
        public Int32 m_once_discount;
        public Int32 m_fifth_discount;
        public Int32 m_limit_time;
        public List<Int32> m_core_rewards = new List<Int32>();
        public List<ItemInfo> m_normal_rewards = new List<ItemInfo>();
        public List<StrangeCubeCampaignAdditionalCfg> m_extra_reward_config = new List<StrangeCubeCampaignAdditionalCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cost_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cost_param = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_once_price = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_fifth_price = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_once_discount = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_fifth_discount = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_limit_time = sp.ReadInt32();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_core_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_core_rewards.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_normal_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_config.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StrangeCubeCampaignAdditionalCfg tmp = new StrangeCubeCampaignAdditionalCfg();
                    tmp.Decode(sp);
                    m_extra_reward_config.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_type);}
            if (sp.TryWrite(1)) {sp.Write(m_cost_param);}
            if (sp.TryWrite(2)) {sp.Write(m_once_price);}
            if (sp.TryWrite(3)) {sp.Write(m_fifth_price);}
            if (sp.TryWrite(4)) {sp.Write(m_once_discount);}
            if (sp.TryWrite(5)) {sp.Write(m_fifth_discount);}
            if (sp.TryWrite(6)) {sp.Write(m_limit_time);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_core_rewards.Count);
                for (int i = 0; i != m_core_rewards.Count; ++i) {
                    sp.Write(m_core_rewards[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_rewards.Count);
                for (int i = 0; i != m_normal_rewards.Count; ++i) {
                    m_normal_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_config.Count);
                for (int i = 0; i != m_extra_reward_config.Count; ++i) {
                    m_extra_reward_config[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(StrangeCubeCampaignCfg source) {
            m_cost_type = source.m_cost_type;
            m_cost_param = source.m_cost_param;
            m_once_price = source.m_once_price;
            m_fifth_price = source.m_fifth_price;
            m_once_discount = source.m_once_discount;
            m_fifth_discount = source.m_fifth_discount;
            m_limit_time = source.m_limit_time;
            m_core_rewards = source.m_core_rewards;
            m_normal_rewards = source.m_normal_rewards;
            m_extra_reward_config = source.m_extra_reward_config;
        }
    }
    
    [Serializable]
    public partial class WarMarketExchangeCampaignInfo : NetworkMessage {
        public static int[] Id = { 1741,42 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public WarMarketExchangeCampaignCfg m_config;
        public Int32 m_guarantee_num;
        public Boolean m_own_all_item;
        public Int64 m_refresh_discount_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new WarMarketExchangeCampaignCfg();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_guarantee_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_own_all_item = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_refresh_discount_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_guarantee_num);}
            if (sp.TryWrite(3)) {sp.Write(m_own_all_item);}
            if (sp.TryWrite(4)) {sp.Write(m_refresh_discount_time);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketExchangeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
            m_guarantee_num = source.m_guarantee_num;
            m_own_all_item = source.m_own_all_item;
            m_refresh_discount_time = source.m_refresh_discount_time;
        }
    }
    
    [Serializable]
    public partial class WarMarketDrawAckInfo : NetworkMessage {
        public static int[] Id = { 1747,42 };
        public static Ctrl VC;
        public List<WarMarketDrawRewardInfo> m_rewards = new List<WarMarketDrawRewardInfo>();
        public Int32 m_guarantee_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarMarketDrawRewardInfo tmp = new WarMarketDrawRewardInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_guarantee_num = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_guarantee_num);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketDrawAckInfo source) {
            m_rewards = source.m_rewards;
            m_guarantee_num = source.m_guarantee_num;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignLineCfg : NetworkMessage {
        public static int[] Id = { 1753,44 };
        public static Ctrl VC;
        public Int32 m_line_id;
        public Int32 m_score;
        public String m_line_pic = "";
        public String m_line_f_pic = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_line_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_line_pic = sp.ReadString();}
            if (sp.TryRead(3)) {m_line_f_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_line_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_line_pic);}
            if (sp.TryWrite(3)) {sp.Write(m_line_f_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(LineTaskCampaignLineCfg source) {
            m_line_id = source.m_line_id;
            m_score = source.m_score;
            m_line_pic = source.m_line_pic;
            m_line_f_pic = source.m_line_f_pic;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitInfo : NetworkMessage {
        public static int[] Id = { 1768,44 };
        public static Ctrl VC;
        public Int32 m_free_times;
        public Int32 m_exp;
        public Int32 m_exp_max;
        public Int32 m_exchange_times;
        public Int32 m_rare_times;
        public Int32 m_max_open_times;
        public Int32 m_cost_item_id;
        public Int32 m_buy_item_cost_diamond;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_free_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_exp_max = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_exchange_times = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_rare_times = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_max_open_times = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_cost_item_id = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_buy_item_cost_diamond = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_free_times);}
            if (sp.TryWrite(1)) {sp.Write(m_exp);}
            if (sp.TryWrite(2)) {sp.Write(m_exp_max);}
            if (sp.TryWrite(3)) {sp.Write(m_exchange_times);}
            if (sp.TryWrite(4)) {sp.Write(m_rare_times);}
            if (sp.TryWrite(5)) {sp.Write(m_max_open_times);}
            if (sp.TryWrite(6)) {sp.Write(m_cost_item_id);}
            if (sp.TryWrite(7)) {sp.Write(m_buy_item_cost_diamond);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitInfo source) {
            m_free_times = source.m_free_times;
            m_exp = source.m_exp;
            m_exp_max = source.m_exp_max;
            m_exchange_times = source.m_exchange_times;
            m_rare_times = source.m_rare_times;
            m_max_open_times = source.m_max_open_times;
            m_cost_item_id = source.m_cost_item_id;
            m_buy_item_cost_diamond = source.m_buy_item_cost_diamond;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitAckInfo : NetworkMessage {
        public static int[] Id = { 1774,44 };
        public static Ctrl VC;
        public LegendRecruitInfo m_base_info;
        public List<LegendRecruitItemInfo> m_items = new List<LegendRecruitItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new LegendRecruitInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LegendRecruitItemInfo tmp = new LegendRecruitItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
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
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitAckInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitOutItemInfo : NetworkMessage {
        public static int[] Id = { 1782,44 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_odds;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_odds = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_odds);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitOutItemInfo source) {
            m_item_id = source.m_item_id;
            m_odds = source.m_odds;
        }
    }
    
    [Serializable]
    public partial class VoteSubmitSuggestionReqInfo : NetworkMessage {
        public static int[] Id = { 1811,44 };
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
        public void CopyFrom(VoteSubmitSuggestionReqInfo source) {
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalentSchemeInfo : NetworkMessage {
        public static int[] Id = { 1885,46 };
        public static Ctrl VC;
        public SByte m_id;
        public String m_name = "";
        public Int32 m_available_talent_point;
        public List<CultureAgentTalentTree> m_trees = new List<CultureAgentTalentTree>();
        public Boolean m_applied;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_available_talent_point = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_trees.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalentTree tmp = new CultureAgentTalentTree();
                    tmp.Decode(sp);
                    m_trees.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_applied = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_available_talent_point);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_trees.Count);
                for (int i = 0; i != m_trees.Count; ++i) {
                    m_trees[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_applied);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalentSchemeInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_available_talent_point = source.m_available_talent_point;
            m_trees = source.m_trees;
            m_applied = source.m_applied;
        }
    }
    
    [Serializable]
    public partial class UserGetNewCityDecorationInfo : NetworkMessage {
        public static int[] Id = { 1891,46 };
        public static Ctrl VC;
        public Int16 m_new_decoration_id;
        public SByte m_decoration_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_decoration_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_decoration_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_decoration_id);}
            if (sp.TryWrite(1)) {sp.Write(m_decoration_type);}
            sp.EnEnd();
        }
        public void CopyFrom(UserGetNewCityDecorationInfo source) {
            m_new_decoration_id = source.m_new_decoration_id;
            m_decoration_type = source.m_decoration_type;
        }
    }
    
    [Serializable]
    public partial class RecycleAtyExchangeReqInfo : NetworkMessage {
        public static int[] Id = { 1897,46 };
        public static Ctrl VC;
        public Int16 m_order;
        public Int32 m_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            sp.EnEnd();
        }
        public void CopyFrom(RecycleAtyExchangeReqInfo source) {
            m_order = source.m_order;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignPlayerInfo : NetworkMessage {
        public static int[] Id = { 1903,46 };
        public static Ctrl VC;
        public Int32 m_score;
        public List<SByte> m_drew_as_reward_id = new List<SByte>();
        public List<SByte> m_drew_player_reward_id = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_as_reward_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_drew_as_reward_id.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_player_reward_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_drew_player_reward_id.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_as_reward_id.Count);
                for (int i = 0; i != m_drew_as_reward_id.Count; ++i) {
                    sp.Write(m_drew_as_reward_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_player_reward_id.Count);
                for (int i = 0; i != m_drew_player_reward_id.Count; ++i) {
                    sp.Write(m_drew_player_reward_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureCampaignPlayerInfo source) {
            m_score = source.m_score;
            m_drew_as_reward_id = source.m_drew_as_reward_id;
            m_drew_player_reward_id = source.m_drew_player_reward_id;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureRedPointInfo : NetworkMessage {
        public static int[] Id = { 1909,46 };
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
        public void CopyFrom(AllianceTreasureRedPointInfo source) {
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class PlayerReturnEventTaskNtfInfo : NetworkMessage {
        public static int[] Id = { 1918,47 };
        public static Ctrl VC;
        public PlayerReturnEventTaskInfo m_task_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_task_info = new PlayerReturnEventTaskInfo();
                m_task_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_task_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerReturnEventTaskNtfInfo source) {
            m_task_info = source.m_task_info;
        }
    }
    
    [Serializable]
    public partial class HeroOptionalPkgChangeNtfInfo : NetworkMessage {
        public static int[] Id = { 1928,48 };
        public static Ctrl VC;
        public List<HeroOptionalPkgGroupItem> m_change_pkgs = new List<HeroOptionalPkgGroupItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_change_pkgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HeroOptionalPkgGroupItem tmp = new HeroOptionalPkgGroupItem();
                    tmp.Decode(sp);
                    m_change_pkgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_change_pkgs.Count);
                for (int i = 0; i != m_change_pkgs.Count; ++i) {
                    m_change_pkgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(HeroOptionalPkgChangeNtfInfo source) {
            m_change_pkgs = source.m_change_pkgs;
        }
    }
    
    [Serializable]
    public partial class QuestionInfo : NetworkMessage {
        public static int[] Id = { 1989,49 };
        public static Ctrl VC;
        public Int32 m_question_id;
        public String m_question_text = "";
        public List<String> m_answer_texts = new List<String>();
        public SByte m_answer_index;
        public SByte m_right_answer_index;
        public Int64 m_start_time;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_question_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_question_text = sp.ReadString();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_answer_texts.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_answer_texts.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {m_answer_index = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_right_answer_index = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_question_id);}
            if (sp.TryWrite(1)) {sp.Write(m_question_text);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_answer_texts.Count);
                for (int i = 0; i != m_answer_texts.Count; ++i) {
                    sp.Write(m_answer_texts[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {sp.Write(m_answer_index);}
            if (sp.TryWrite(4)) {sp.Write(m_right_answer_index);}
            if (sp.TryWrite(5)) {sp.Write(m_start_time);}
            if (sp.TryWrite(6)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionInfo source) {
            m_question_id = source.m_question_id;
            m_question_text = source.m_question_text;
            m_answer_texts = source.m_answer_texts;
            m_answer_index = source.m_answer_index;
            m_right_answer_index = source.m_right_answer_index;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStepChangeNtfInfo : NetworkMessage {
        public static int[] Id = { 1995,49 };
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
        public void CopyFrom(QuestionAnswerStepChangeNtfInfo source) {
            m_step_info = source.m_step_info;
        }
    }
    
    [Serializable]
    public partial class FlipCardPlayerInfo : NetworkMessage {
        public static int[] Id = { 2001,49 };
        public static Ctrl VC;
        public Int32 m_score;
        public List<Int32> m_drew_rewards_score = new List<Int32>();
        public Boolean m_is_unlock_next_layer;
        public SByte m_unlock_next_layer_cell_x;
        public SByte m_unlock_next_layer_cell_y;
        public FlipCardLayerInfo m_layer_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_rewards_score.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_rewards_score.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_is_unlock_next_layer = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_unlock_next_layer_cell_x = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_unlock_next_layer_cell_y = sp.ReadSByte();}
            if (sp.TryRead(5)) {
                m_layer_info = new FlipCardLayerInfo();
                m_layer_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_rewards_score.Count);
                for (int i = 0; i != m_drew_rewards_score.Count; ++i) {
                    sp.Write(m_drew_rewards_score[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_is_unlock_next_layer);}
            if (sp.TryWrite(3)) {sp.Write(m_unlock_next_layer_cell_x);}
            if (sp.TryWrite(4)) {sp.Write(m_unlock_next_layer_cell_y);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_layer_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardPlayerInfo source) {
            m_score = source.m_score;
            m_drew_rewards_score = source.m_drew_rewards_score;
            m_is_unlock_next_layer = source.m_is_unlock_next_layer;
            m_unlock_next_layer_cell_x = source.m_unlock_next_layer_cell_x;
            m_unlock_next_layer_cell_y = source.m_unlock_next_layer_cell_y;
            m_layer_info = source.m_layer_info;
        }
    }
    
    [Serializable]
    public partial class FlipCardPickRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2007,49 };
        public static Ctrl VC;
        public Int16 m_reward_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardPickRewardReqInfo source) {
            m_reward_id = source.m_reward_id;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponNtfInfo : NetworkMessage {
        public static int[] Id = { 2039,50 };
        public static Ctrl VC;
        public Int32 m_change_type;
        public List<WarshipWeaponInfo> m_weapon_infos = new List<WarshipWeaponInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_change_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_weapon_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WarshipWeaponInfo tmp = new WarshipWeaponInfo();
                    tmp.Decode(sp);
                    m_weapon_infos.Add(tmp);
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
                sp.Write((UInt16)m_weapon_infos.Count);
                for (int i = 0; i != m_weapon_infos.Count; ++i) {
                    m_weapon_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponNtfInfo source) {
            m_change_type = source.m_change_type;
            m_weapon_infos = source.m_weapon_infos;
        }
    }
    
    [Serializable]
    public partial class SubmarineNtfInfo : NetworkMessage {
        public static int[] Id = { 2045,50 };
        public static Ctrl VC;
        public Int32 m_explore_num;
        public List<SubmarineOfficerExploreLog> m_officer_explore_logs = new List<SubmarineOfficerExploreLog>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_explore_num = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_officer_explore_logs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SubmarineOfficerExploreLog tmp = new SubmarineOfficerExploreLog();
                    tmp.Decode(sp);
                    m_officer_explore_logs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_explore_num);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_officer_explore_logs.Count);
                for (int i = 0; i != m_officer_explore_logs.Count; ++i) {
                    m_officer_explore_logs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SubmarineNtfInfo source) {
            m_explore_num = source.m_explore_num;
            m_officer_explore_logs = source.m_officer_explore_logs;
        }
    }
    
    [Serializable]
    public partial class ValorShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 2055,51 };
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
        public void CopyFrom(ValorShopBuyReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class RaidConfig : NetworkMessage {
        public static int[] Id = { 2113,54 };
        public static Ctrl VC;
        public Int64 m_remain_time;
        public SByte m_max_challenge_num;
        public List<RaidLevelConfig> m_level_configs = new List<RaidLevelConfig>();
        public List<RaidTrialOfficerConfig> m_trial_officers = new List<RaidTrialOfficerConfig>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_remain_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_max_challenge_num = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_configs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidLevelConfig tmp = new RaidLevelConfig();
                    tmp.Decode(sp);
                    m_level_configs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_trial_officers.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidTrialOfficerConfig tmp = new RaidTrialOfficerConfig();
                    tmp.Decode(sp);
                    m_trial_officers.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_remain_time);}
            if (sp.TryWrite(1)) {sp.Write(m_max_challenge_num);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_configs.Count);
                for (int i = 0; i != m_level_configs.Count; ++i) {
                    m_level_configs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_trial_officers.Count);
                for (int i = 0; i != m_trial_officers.Count; ++i) {
                    m_trial_officers[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RaidConfig source) {
            m_remain_time = source.m_remain_time;
            m_max_challenge_num = source.m_max_challenge_num;
            m_level_configs = source.m_level_configs;
            m_trial_officers = source.m_trial_officers;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeReqInfo : NetworkMessage {
        public static int[] Id = { 2119,54 };
        public static Ctrl VC;
        public Int32 m_level;
        public List<RaidGroupInfo> m_groups = new List<RaidGroupInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidGroupInfo tmp = new RaidGroupInfo();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
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
                sp.Write((UInt16)m_groups.Count);
                for (int i = 0; i != m_groups.Count; ++i) {
                    m_groups[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RaidChallengeReqInfo source) {
            m_level = source.m_level;
            m_groups = source.m_groups;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeFightStatInfo : NetworkMessage {
        public static int[] Id = { 2125,54 };
        public static Ctrl VC;
        public UInt32 m_id;
        public RaidChallengePlayerStatInfo m_self_stat;
        public RaidChallengePlayerStatInfo m_target_stat;
        public UInt16 m_max_battle_time;
        public Int32 m_troop_speed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadUInt32();}
            if (sp.TryRead(1)) {
                m_self_stat = new RaidChallengePlayerStatInfo();
                m_self_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_target_stat = new RaidChallengePlayerStatInfo();
                m_target_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_max_battle_time = sp.ReadUInt16();}
            if (sp.TryRead(4)) {m_troop_speed = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_target_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_max_battle_time);}
            if (sp.TryWrite(4)) {sp.Write(m_troop_speed);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidChallengeFightStatInfo source) {
            m_id = source.m_id;
            m_self_stat = source.m_self_stat;
            m_target_stat = source.m_target_stat;
            m_max_battle_time = source.m_max_battle_time;
            m_troop_speed = source.m_troop_speed;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeAgentInfo : NetworkMessage {
        public static int[] Id = { 2131,54 };
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
        public void CopyFrom(RaidChallengeAgentInfo source) {
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
    public partial class MuseumArtifactDisplayReqInfo : NetworkMessage {
        public static int[] Id = { 2148,56 };
        public static Ctrl VC;
        public SByte m_slot_id;
        public Int32 m_model_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_model_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot_id);}
            if (sp.TryWrite(1)) {sp.Write(m_model_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactDisplayReqInfo source) {
            m_slot_id = source.m_slot_id;
            m_model_id = source.m_model_id;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactLotteryAckInfo : NetworkMessage {
        public static int[] Id = { 2154,56 };
        public static Ctrl VC;
        public SByte m_lottery_type;
        public List<MuseumArtifactLotteryItemInfo> m_items = new List<MuseumArtifactLotteryItemInfo>();
        public MuseumArtifactMarketInfo m_market;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_lottery_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MuseumArtifactLotteryItemInfo tmp = new MuseumArtifactLotteryItemInfo();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_market = new MuseumArtifactMarketInfo();
                m_market.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_lottery_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_market.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactLotteryAckInfo source) {
            m_lottery_type = source.m_lottery_type;
            m_items = source.m_items;
            m_market = source.m_market;
        }
    }
    
    [Serializable]
    public partial class OverturnShopInfoItem : NetworkMessage {
        public static int[] Id = { 2162,57 };
        public static Ctrl VC;
        public Int32 m_id;
        public List<ItemInfo> m_cost = new List<ItemInfo>();
        public ItemInfo m_rewards;
        public Int32 m_sort_priority;
        public Int32 m_buy_num_limit;
        public Int32 m_bought_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cost.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_cost.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_rewards = new ItemInfo();
                m_rewards.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_sort_priority = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_buy_num_limit = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_bought_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cost.Count);
                for (int i = 0; i != m_cost.Count; ++i) {
                    m_cost[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_rewards.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_sort_priority);}
            if (sp.TryWrite(4)) {sp.Write(m_buy_num_limit);}
            if (sp.TryWrite(5)) {sp.Write(m_bought_num);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnShopInfoItem source) {
            m_id = source.m_id;
            m_cost = source.m_cost;
            m_rewards = source.m_rewards;
            m_sort_priority = source.m_sort_priority;
            m_buy_num_limit = source.m_buy_num_limit;
            m_bought_num = source.m_bought_num;
        }
    }
    
    [Serializable]
    public partial class OverturnBattlePassportInfo : NetworkMessage {
        public static int[] Id = { 2169,57 };
        public static Ctrl VC;
        public List<OverturnBattlePassportInfoItem> m_items = new List<OverturnBattlePassportInfoItem>();
        public List<ItemInfo> m_extra_normal_rewards = new List<ItemInfo>();
        public List<ItemInfo> m_extra_senior_rewards = new List<ItemInfo>();
        public List<Int32> m_drew_normal_reward_times = new List<Int32>();
        public List<Int32> m_drew_senior_reward_times = new List<Int32>();
        public Int32 m_times;
        public Boolean m_is_buy_senior;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OverturnBattlePassportInfoItem tmp = new OverturnBattlePassportInfoItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_normal_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_extra_normal_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_senior_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_extra_senior_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_normal_reward_times.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_normal_reward_times.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_senior_reward_times.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_senior_reward_times.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {m_times = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_is_buy_senior = sp.ReadBoolean();}
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
                sp.Write((UInt16)m_extra_normal_rewards.Count);
                for (int i = 0; i != m_extra_normal_rewards.Count; ++i) {
                    m_extra_normal_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_senior_rewards.Count);
                for (int i = 0; i != m_extra_senior_rewards.Count; ++i) {
                    m_extra_senior_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_normal_reward_times.Count);
                for (int i = 0; i != m_drew_normal_reward_times.Count; ++i) {
                    sp.Write(m_drew_normal_reward_times[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_senior_reward_times.Count);
                for (int i = 0; i != m_drew_senior_reward_times.Count; ++i) {
                    sp.Write(m_drew_senior_reward_times[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {sp.Write(m_times);}
            if (sp.TryWrite(6)) {sp.Write(m_is_buy_senior);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnBattlePassportInfo source) {
            m_items = source.m_items;
            m_extra_normal_rewards = source.m_extra_normal_rewards;
            m_extra_senior_rewards = source.m_extra_senior_rewards;
            m_drew_normal_reward_times = source.m_drew_normal_reward_times;
            m_drew_senior_reward_times = source.m_drew_senior_reward_times;
            m_times = source.m_times;
            m_is_buy_senior = source.m_is_buy_senior;
        }
    }
    
    [Serializable]
    public partial class RebuildingCampaignBuffInfo : NetworkMessage {
        public static int[] Id = { 2175,58 };
        public static Ctrl VC;
        public Boolean m_is_open;
        public Int16 m_open_day;
        public Int16 m_id;
        public Int16 m_buff_type;
        public List<Int32> m_buff_value = new List<Int32>();
        public String m_buff_name = "";
        public String m_buff_desc = "";
        public String m_buff_icon = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_open = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_open_day = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_buff_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buff_value.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_buff_value.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {m_buff_name = sp.ReadString();}
            if (sp.TryRead(6)) {m_buff_desc = sp.ReadString();}
            if (sp.TryRead(7)) {m_buff_icon = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_open);}
            if (sp.TryWrite(1)) {sp.Write(m_open_day);}
            if (sp.TryWrite(2)) {sp.Write(m_id);}
            if (sp.TryWrite(3)) {sp.Write(m_buff_type);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_value.Count);
                for (int i = 0; i != m_buff_value.Count; ++i) {
                    sp.Write(m_buff_value[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {sp.Write(m_buff_name);}
            if (sp.TryWrite(6)) {sp.Write(m_buff_desc);}
            if (sp.TryWrite(7)) {sp.Write(m_buff_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(RebuildingCampaignBuffInfo source) {
            m_is_open = source.m_is_open;
            m_open_day = source.m_open_day;
            m_id = source.m_id;
            m_buff_type = source.m_buff_type;
            m_buff_value = source.m_buff_value;
            m_buff_name = source.m_buff_name;
            m_buff_desc = source.m_buff_desc;
            m_buff_icon = source.m_buff_icon;
        }
    }
    
    [Serializable]
    public partial class TroopSkinInfo : NetworkMessage {
        public static int[] Id = { 2187,59 };
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
        public void CopyFrom(TroopSkinInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class AgentShopGoodsInfo : NetworkMessage {
        public static int[] Id = { 2193,61 };
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
        public void CopyFrom(AgentShopGoodsInfo source) {
            m_goods_id = source.m_goods_id;
            m_bought_num = source.m_bought_num;
        }
    }
    
    [Serializable]
    public partial class ChainGiftsReceiveAdditionalRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2255,63 };
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
        public void CopyFrom(ChainGiftsReceiveAdditionalRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class FriendApplyReqInfo : NetworkMessage {
        public static int[] Id = { 2261,63 };
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
        public void CopyFrom(FriendApplyReqInfo source) {
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class FriendSearchUserAckInfo : NetworkMessage {
        public static int[] Id = { 2267,63 };
        public static Ctrl VC;
        public List<FriendUserInfo> m_user_info_list = new List<FriendUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_user_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendUserInfo tmp = new FriendUserInfo();
                    tmp.Decode(sp);
                    m_user_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_user_info_list.Count);
                for (int i = 0; i != m_user_info_list.Count; ++i) {
                    m_user_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FriendSearchUserAckInfo source) {
            m_user_info_list = source.m_user_info_list;
        }
    }
    
    [Serializable]
    public partial class PuzzleCampaignPuzzlePieceInfo : NetworkMessage {
        public static int[] Id = { 2273,63 };
        public static Ctrl VC;
        public SByte m_number;
        public Int32 m_item_id;
        public Boolean m_is_active;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_number = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_is_active = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_number);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_is_active);}
            sp.EnEnd();
        }
        public void CopyFrom(PuzzleCampaignPuzzlePieceInfo source) {
            m_number = source.m_number;
            m_item_id = source.m_item_id;
            m_is_active = source.m_is_active;
        }
    }
    
    [Serializable]
    public partial class AgentEquipEnhanceAckInfo : NetworkMessage {
        public static int[] Id = { 2285,64 };
        public static Ctrl VC;
        public Boolean m_is_success;
        public EquipInfo m_equip_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_success = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                m_equip_info = new EquipInfo();
                m_equip_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_success);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_equip_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentEquipEnhanceAckInfo source) {
            m_is_success = source.m_is_success;
            m_equip_info = source.m_equip_info;
        }
    }
    
    [Serializable]
    public partial class HomeBackgroundInfo : NetworkMessage {
        public static int[] Id = { 2291,64 };
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
        public void CopyFrom(HomeBackgroundInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class TroopTailSkinInfo : NetworkMessage {
        public static int[] Id = { 2297,64 };
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
        public void CopyFrom(TroopTailSkinInfo source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class SignInCampaignInfo : NetworkMessage {
        public static int[] Id = { 2314,65 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public SignInCampaignConfig m_config;
        public SignInCampaignPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new SignInCampaignConfig();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new SignInCampaignPlayerInfo();
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
        public void CopyFrom(SignInCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class VideoInfo : NetworkMessage {
        public static int[] Id = { 2320,66 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int64 m_user_id;
        public Int16 m_server_id;
        public String m_alliance = "";
        public String m_name = "";
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int64 m_create_time_sec;
        public String m_video_url = "";
        public String m_video_cover = "";
        public String m_video_title = "";
        public String m_video_description = "";
        public Int64 m_video_length;
        public Int64 m_platform_view_count;
        public Int64 m_reward_count;
        public Int64 m_in_game_view_count;
        public Int64 m_like_count;
        public Boolean m_self_like;
        public Int64 m_dislike_count;
        public Boolean m_self_dislike;
        public Int64 m_comment_count;
        public String m_video_status_health = "";
        public String m_video_status_review = "";
        public String m_video_status_access = "";
        public String m_video_status_expire = "";
        public String m_video_status_restriction = "";
        public Int64 m_audit_time_sec;
        public Int64 m_refresh_access_status_cd_end_sec;
        public String m_platform = "";
        public String m_video_id = "";
        public Int64 m_video_published_at;
        public String m_reject_reason = "";
        public List<String> m_tag_list = new List<String>();
        public SByte m_subchannel_type;
        public Int64 m_subchannel_id;
        public Boolean m_featured;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_alliance = sp.ReadString();}
            if (sp.TryRead(4)) {m_name = sp.ReadString();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_create_time_sec = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_video_url = sp.ReadString();}
            if (sp.TryRead(10)) {m_video_cover = sp.ReadString();}
            if (sp.TryRead(11)) {m_video_title = sp.ReadString();}
            if (sp.TryRead(12)) {m_video_description = sp.ReadString();}
            if (sp.TryRead(13)) {m_video_length = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_platform_view_count = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_reward_count = sp.ReadInt64();}
            if (sp.TryRead(16)) {m_in_game_view_count = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_like_count = sp.ReadInt64();}
            if (sp.TryRead(18)) {m_self_like = sp.ReadBoolean();}
            if (sp.TryRead(19)) {m_dislike_count = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_self_dislike = sp.ReadBoolean();}
            if (sp.TryRead(21)) {m_comment_count = sp.ReadInt64();}
            if (sp.TryRead(22)) {m_video_status_health = sp.ReadString();}
            if (sp.TryRead(23)) {m_video_status_review = sp.ReadString();}
            if (sp.TryRead(24)) {m_video_status_access = sp.ReadString();}
            if (sp.TryRead(25)) {m_video_status_expire = sp.ReadString();}
            if (sp.TryRead(26)) {m_video_status_restriction = sp.ReadString();}
            if (sp.TryRead(27)) {m_audit_time_sec = sp.ReadInt64();}
            if (sp.TryRead(28)) {m_refresh_access_status_cd_end_sec = sp.ReadInt64();}
            if (sp.TryRead(29)) {m_platform = sp.ReadString();}
            if (sp.TryRead(30)) {m_video_id = sp.ReadString();}
            if (sp.TryRead(31)) {m_video_published_at = sp.ReadInt64();}
            if (sp.TryRead(32)) {m_reject_reason = sp.ReadString();}
            if (sp.TryRead(33)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tag_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_tag_list.Add(tmp);
                }
            }
            if (sp.TryRead(34)) {m_subchannel_type = sp.ReadSByte();}
            if (sp.TryRead(35)) {m_subchannel_id = sp.ReadInt64();}
            if (sp.TryRead(36)) {m_featured = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_server_id);}
            if (sp.TryWrite(3)) {sp.Write(m_alliance);}
            if (sp.TryWrite(4)) {sp.Write(m_name);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(8)) {sp.Write(m_create_time_sec);}
            if (sp.TryWrite(9)) {sp.Write(m_video_url);}
            if (sp.TryWrite(10)) {sp.Write(m_video_cover);}
            if (sp.TryWrite(11)) {sp.Write(m_video_title);}
            if (sp.TryWrite(12)) {sp.Write(m_video_description);}
            if (sp.TryWrite(13)) {sp.Write(m_video_length);}
            if (sp.TryWrite(14)) {sp.Write(m_platform_view_count);}
            if (sp.TryWrite(15)) {sp.Write(m_reward_count);}
            if (sp.TryWrite(16)) {sp.Write(m_in_game_view_count);}
            if (sp.TryWrite(17)) {sp.Write(m_like_count);}
            if (sp.TryWrite(18)) {sp.Write(m_self_like);}
            if (sp.TryWrite(19)) {sp.Write(m_dislike_count);}
            if (sp.TryWrite(20)) {sp.Write(m_self_dislike);}
            if (sp.TryWrite(21)) {sp.Write(m_comment_count);}
            if (sp.TryWrite(22)) {sp.Write(m_video_status_health);}
            if (sp.TryWrite(23)) {sp.Write(m_video_status_review);}
            if (sp.TryWrite(24)) {sp.Write(m_video_status_access);}
            if (sp.TryWrite(25)) {sp.Write(m_video_status_expire);}
            if (sp.TryWrite(26)) {sp.Write(m_video_status_restriction);}
            if (sp.TryWrite(27)) {sp.Write(m_audit_time_sec);}
            if (sp.TryWrite(28)) {sp.Write(m_refresh_access_status_cd_end_sec);}
            if (sp.TryWrite(29)) {sp.Write(m_platform);}
            if (sp.TryWrite(30)) {sp.Write(m_video_id);}
            if (sp.TryWrite(31)) {sp.Write(m_video_published_at);}
            if (sp.TryWrite(32)) {sp.Write(m_reject_reason);}
            if (sp.TryWrite(33)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tag_list.Count);
                for (int i = 0; i != m_tag_list.Count; ++i) {
                    sp.Write(m_tag_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(34)) {sp.Write(m_subchannel_type);}
            if (sp.TryWrite(35)) {sp.Write(m_subchannel_id);}
            if (sp.TryWrite(36)) {sp.Write(m_featured);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoInfo source) {
            m_id = source.m_id;
            m_user_id = source.m_user_id;
            m_server_id = source.m_server_id;
            m_alliance = source.m_alliance;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_create_time_sec = source.m_create_time_sec;
            m_video_url = source.m_video_url;
            m_video_cover = source.m_video_cover;
            m_video_title = source.m_video_title;
            m_video_description = source.m_video_description;
            m_video_length = source.m_video_length;
            m_platform_view_count = source.m_platform_view_count;
            m_reward_count = source.m_reward_count;
            m_in_game_view_count = source.m_in_game_view_count;
            m_like_count = source.m_like_count;
            m_self_like = source.m_self_like;
            m_dislike_count = source.m_dislike_count;
            m_self_dislike = source.m_self_dislike;
            m_comment_count = source.m_comment_count;
            m_video_status_health = source.m_video_status_health;
            m_video_status_review = source.m_video_status_review;
            m_video_status_access = source.m_video_status_access;
            m_video_status_expire = source.m_video_status_expire;
            m_video_status_restriction = source.m_video_status_restriction;
            m_audit_time_sec = source.m_audit_time_sec;
            m_refresh_access_status_cd_end_sec = source.m_refresh_access_status_cd_end_sec;
            m_platform = source.m_platform;
            m_video_id = source.m_video_id;
            m_video_published_at = source.m_video_published_at;
            m_reject_reason = source.m_reject_reason;
            m_tag_list = source.m_tag_list;
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
            m_featured = source.m_featured;
        }
    }
    
    [Serializable]
    public partial class VideoChannelCommitVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2326,66 };
        public static Ctrl VC;
        public String m_video_url = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_url = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_url);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelCommitVideoReqInfo source) {
            m_video_url = source.m_video_url;
        }
    }
    
    [Serializable]
    public partial class VideoChannelReportVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2332,66 };
        public static Ctrl VC;
        public Int64 m_video_id;
        public String m_reason = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_reason = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_id);}
            if (sp.TryWrite(1)) {sp.Write(m_reason);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelReportVideoReqInfo source) {
            m_video_id = source.m_video_id;
            m_reason = source.m_reason;
        }
    }
    
    [Serializable]
    public partial class VideoChannelReplyVideoCommentAckInfo : NetworkMessage {
        public static int[] Id = { 2338,66 };
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
        public void CopyFrom(VideoChannelReplyVideoCommentAckInfo source) {
            m_comment = source.m_comment;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDislikeVideoCommentAckInfo : NetworkMessage {
        public static int[] Id = { 2344,66 };
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
        public void CopyFrom(VideoChannelDislikeVideoCommentAckInfo source) {
            m_comment = source.m_comment;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetPopularVideoListReqInfo : NetworkMessage {
        public static int[] Id = { 2350,66 };
        public static Ctrl VC;
        public String m_time_range = "";
        public Int32 m_start_rank;
        public Int32 m_end_rank;
        public SByte m_subchannel_type;
        public Int64 m_subchannel_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_time_range = sp.ReadString();}
            if (sp.TryRead(1)) {m_start_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_subchannel_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_subchannel_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_time_range);}
            if (sp.TryWrite(1)) {sp.Write(m_start_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_end_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_subchannel_type);}
            if (sp.TryWrite(4)) {sp.Write(m_subchannel_id);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetPopularVideoListReqInfo source) {
            m_time_range = source.m_time_range;
            m_start_rank = source.m_start_rank;
            m_end_rank = source.m_end_rank;
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetUserVideoStatsReqInfo : NetworkMessage {
        public static int[] Id = { 2356,66 };
        public static Ctrl VC;
        public String m_time_range = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_time_range = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_time_range);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetUserVideoStatsReqInfo source) {
            m_time_range = source.m_time_range;
        }
    }
    
    [Serializable]
    public partial class VideoChannelBuyShopGoodsReqInfo : NetworkMessage {
        public static int[] Id = { 2362,66 };
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
        public void CopyFrom(VideoChannelBuyShopGoodsReqInfo source) {
            m_goods_id = source.m_goods_id;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class VideoChannelReportVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2368,66 };
        public static Ctrl VC;
        public Int64 m_video_comment_id;
        public String m_reason = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_video_comment_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_reason = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_video_comment_id);}
            if (sp.TryWrite(1)) {sp.Write(m_reason);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelReportVideoCommentReqInfo source) {
            m_video_comment_id = source.m_video_comment_id;
            m_reason = source.m_reason;
        }
    }
    
    [Serializable]
    public partial class UserMedalList : NetworkMessage {
        public static int[] Id = { 2393,68 };
        public static Ctrl VC;
        public List<UserMedalInfo> m_list = new List<UserMedalInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMedalInfo tmp = new UserMedalInfo();
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
        public void CopyFrom(UserMedalList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class VideoChannelTakeDownVideoFromSubchannelReqInfo : NetworkMessage {
        public static int[] Id = { 2399,68 };
        public static Ctrl VC;
        public SByte m_subchannel_type;
        public Int64 m_subchannel_id;
        public Int64 m_video_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_subchannel_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_subchannel_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_video_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_subchannel_type);}
            if (sp.TryWrite(1)) {sp.Write(m_subchannel_id);}
            if (sp.TryWrite(2)) {sp.Write(m_video_id);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelTakeDownVideoFromSubchannelReqInfo source) {
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
            m_video_id = source.m_video_id;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventBaseInfo : NetworkMessage {
        public static int[] Id = { 2435,72 };
        public static Ctrl VC;
        public Int64 m_begin_time;
        public Int64 m_end_time;
        public Int32 m_current_tutorial_step;
        public List<NewReturnEventChangeBuildingInfo> m_change_building_list = new List<NewReturnEventChangeBuildingInfo>();
        public List<NewReturnEventChangeResearchInfo> m_change_research_list = new List<NewReturnEventChangeResearchInfo>();
        public List<ArmyInfo> m_change_troops = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_current_tutorial_step = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_change_building_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NewReturnEventChangeBuildingInfo tmp = new NewReturnEventChangeBuildingInfo();
                    tmp.Decode(sp);
                    m_change_building_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_change_research_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NewReturnEventChangeResearchInfo tmp = new NewReturnEventChangeResearchInfo();
                    tmp.Decode(sp);
                    m_change_research_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_change_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_change_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_current_tutorial_step);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_change_building_list.Count);
                for (int i = 0; i != m_change_building_list.Count; ++i) {
                    m_change_building_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_change_research_list.Count);
                for (int i = 0; i != m_change_research_list.Count; ++i) {
                    m_change_research_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_change_troops.Count);
                for (int i = 0; i != m_change_troops.Count; ++i) {
                    m_change_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventBaseInfo source) {
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
            m_current_tutorial_step = source.m_current_tutorial_step;
            m_change_building_list = source.m_change_building_list;
            m_change_research_list = source.m_change_research_list;
            m_change_troops = source.m_change_troops;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetWheelDataAckInfo : NetworkMessage {
        public static int[] Id = { 2441,72 };
        public static Ctrl VC;
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
        public String m_wheel_bg = "";
        public String m_wheel_arrow = "";
        public List<WheelCampaignAdditionReward> m_extra_reward_got_infos = new List<WheelCampaignAdditionReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_free_time = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_once_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_five_diamond_cost = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_once_dis_time = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_five_dis_time = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_once_dis_per = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_five_dis_per = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_daily_max_time = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_daily_roll_time = sp.ReadInt32();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_grids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignGrid tmp = new WheelCampaignGrid();
                    tmp.Decode(sp);
                    m_grids.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {m_extra_reward_score = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_extra_reward_total_score = sp.ReadInt32();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignAdditionReward tmp = new WheelCampaignAdditionReward();
                    tmp.Decode(sp);
                    m_extra_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_got.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_extra_reward_got.Add(tmp);
                }
            }
            if (sp.TryRead(14)) {m_ui_wheel = sp.ReadString();}
            if (sp.TryRead(15)) {m_ui_pointer = sp.ReadString();}
            if (sp.TryRead(16)) {m_stage_up_limit = sp.ReadInt32();}
            if (sp.TryRead(17)) {m_cost_type = sp.ReadInt32();}
            if (sp.TryRead(18)) {m_cost_param = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_cost_icon = sp.ReadString();}
            if (sp.TryRead(20)) {m_wheel_bg = sp.ReadString();}
            if (sp.TryRead(21)) {m_wheel_arrow = sp.ReadString();}
            if (sp.TryRead(22)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_free_time);}
            if (sp.TryWrite(1)) {sp.Write(m_once_diamond_cost);}
            if (sp.TryWrite(2)) {sp.Write(m_five_diamond_cost);}
            if (sp.TryWrite(3)) {sp.Write(m_once_dis_time);}
            if (sp.TryWrite(4)) {sp.Write(m_five_dis_time);}
            if (sp.TryWrite(5)) {sp.Write(m_once_dis_per);}
            if (sp.TryWrite(6)) {sp.Write(m_five_dis_per);}
            if (sp.TryWrite(7)) {sp.Write(m_daily_max_time);}
            if (sp.TryWrite(8)) {sp.Write(m_daily_roll_time);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_grids.Count);
                for (int i = 0; i != m_grids.Count; ++i) {
                    m_grids[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {sp.Write(m_extra_reward_score);}
            if (sp.TryWrite(11)) {sp.Write(m_extra_reward_total_score);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward.Count);
                for (int i = 0; i != m_extra_reward.Count; ++i) {
                    m_extra_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_got.Count);
                for (int i = 0; i != m_extra_reward_got.Count; ++i) {
                    sp.Write(m_extra_reward_got[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(14)) {sp.Write(m_ui_wheel);}
            if (sp.TryWrite(15)) {sp.Write(m_ui_pointer);}
            if (sp.TryWrite(16)) {sp.Write(m_stage_up_limit);}
            if (sp.TryWrite(17)) {sp.Write(m_cost_type);}
            if (sp.TryWrite(18)) {sp.Write(m_cost_param);}
            if (sp.TryWrite(19)) {sp.Write(m_cost_icon);}
            if (sp.TryWrite(20)) {sp.Write(m_wheel_bg);}
            if (sp.TryWrite(21)) {sp.Write(m_wheel_arrow);}
            if (sp.TryWrite(22)) {
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
        public void CopyFrom(NewReturnEventGetWheelDataAckInfo source) {
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
            m_wheel_bg = source.m_wheel_bg;
            m_wheel_arrow = source.m_wheel_arrow;
            m_extra_reward_got_infos = source.m_extra_reward_got_infos;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventRedpointInfo : NetworkMessage {
        public static int[] Id = { 2447,72 };
        public static Ctrl VC;
        public SByte m_function_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_function_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_function_type);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventRedpointInfo source) {
            m_function_type = source.m_function_type;
        }
    }
    
}
