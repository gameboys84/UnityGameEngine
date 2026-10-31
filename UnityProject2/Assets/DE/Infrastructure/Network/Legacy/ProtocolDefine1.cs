using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class LoginInfo : NetworkMessage {
        public static int[] Id = { 2,1 };
        public static Ctrl VC;
        public UInt32 m_pvc_ver;
        public SByte m_account_type;
        public String m_token = "";
        public String m_login_name = "";
        public String m_ip = "";
        public String m_client_version = "";
        public String m_os_version = "";
        public String m_device_name = "";
        public String m_device_id = "";
        public Int32 m_device_id_type;
        public String m_locale = "";
        public String m_open_udid = "";
        public Int16 m_platform_id;
        public Int64 m_user_id;
        public SByte m_mode;
        public Int16 m_server_id;
        public String m_device_id_type_str = "";
        public String m_bundle_id = "";
        public Int32 m_publisher_channel;
        public String m_locale_lang = "";
        public SByte m_device_state;
        public SByte m_is_simulator;
        public String m_idfa = "";
        public String m_idfv = "";
        public String m_google_aid = "";
        public String m_android_id = "";
        public String m_mac_address = "";
        public Int32 m_latitude;
        public Int32 m_longitude;
        public Int32 m_altitude;
        public String m_network_type = "";
        public String m_third_part_device_id = "";
        public String m_attribute = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pvc_ver = sp.ReadUInt32();}
            if (sp.TryRead(1)) {m_account_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_token = sp.ReadString();}
            if (sp.TryRead(3)) {m_login_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_ip = sp.ReadString();}
            if (sp.TryRead(5)) {m_client_version = sp.ReadString();}
            if (sp.TryRead(6)) {m_os_version = sp.ReadString();}
            if (sp.TryRead(7)) {m_device_name = sp.ReadString();}
            if (sp.TryRead(8)) {m_device_id = sp.ReadString();}
            if (sp.TryRead(9)) {m_device_id_type = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_locale = sp.ReadString();}
            if (sp.TryRead(11)) {m_open_udid = sp.ReadString();}
            if (sp.TryRead(12)) {m_platform_id = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_mode = sp.ReadSByte();}
            if (sp.TryRead(15)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(16)) {m_device_id_type_str = sp.ReadString();}
            if (sp.TryRead(17)) {m_bundle_id = sp.ReadString();}
            if (sp.TryRead(18)) {m_publisher_channel = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_locale_lang = sp.ReadString();}
            if (sp.TryRead(20)) {m_device_state = sp.ReadSByte();}
            if (sp.TryRead(21)) {m_is_simulator = sp.ReadSByte();}
            if (sp.TryRead(22)) {m_idfa = sp.ReadString();}
            if (sp.TryRead(23)) {m_idfv = sp.ReadString();}
            if (sp.TryRead(24)) {m_google_aid = sp.ReadString();}
            if (sp.TryRead(25)) {m_android_id = sp.ReadString();}
            if (sp.TryRead(26)) {m_mac_address = sp.ReadString();}
            if (sp.TryRead(27)) {m_latitude = sp.ReadInt32();}
            if (sp.TryRead(28)) {m_longitude = sp.ReadInt32();}
            if (sp.TryRead(29)) {m_altitude = sp.ReadInt32();}
            if (sp.TryRead(30)) {m_network_type = sp.ReadString();}
            if (sp.TryRead(31)) {m_third_part_device_id = sp.ReadString();}
            if (sp.TryRead(32)) {m_attribute = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pvc_ver);}
            if (sp.TryWrite(1)) {sp.Write(m_account_type);}
            if (sp.TryWrite(2)) {sp.Write(m_token);}
            if (sp.TryWrite(3)) {sp.Write(m_login_name);}
            if (sp.TryWrite(4)) {sp.Write(m_ip);}
            if (sp.TryWrite(5)) {sp.Write(m_client_version);}
            if (sp.TryWrite(6)) {sp.Write(m_os_version);}
            if (sp.TryWrite(7)) {sp.Write(m_device_name);}
            if (sp.TryWrite(8)) {sp.Write(m_device_id);}
            if (sp.TryWrite(9)) {sp.Write(m_device_id_type);}
            if (sp.TryWrite(10)) {sp.Write(m_locale);}
            if (sp.TryWrite(11)) {sp.Write(m_open_udid);}
            if (sp.TryWrite(12)) {sp.Write(m_platform_id);}
            if (sp.TryWrite(13)) {sp.Write(m_user_id);}
            if (sp.TryWrite(14)) {sp.Write(m_mode);}
            if (sp.TryWrite(15)) {sp.Write(m_server_id);}
            if (sp.TryWrite(16)) {sp.Write(m_device_id_type_str);}
            if (sp.TryWrite(17)) {sp.Write(m_bundle_id);}
            if (sp.TryWrite(18)) {sp.Write(m_publisher_channel);}
            if (sp.TryWrite(19)) {sp.Write(m_locale_lang);}
            if (sp.TryWrite(20)) {sp.Write(m_device_state);}
            if (sp.TryWrite(21)) {sp.Write(m_is_simulator);}
            if (sp.TryWrite(22)) {sp.Write(m_idfa);}
            if (sp.TryWrite(23)) {sp.Write(m_idfv);}
            if (sp.TryWrite(24)) {sp.Write(m_google_aid);}
            if (sp.TryWrite(25)) {sp.Write(m_android_id);}
            if (sp.TryWrite(26)) {sp.Write(m_mac_address);}
            if (sp.TryWrite(27)) {sp.Write(m_latitude);}
            if (sp.TryWrite(28)) {sp.Write(m_longitude);}
            if (sp.TryWrite(29)) {sp.Write(m_altitude);}
            if (sp.TryWrite(30)) {sp.Write(m_network_type);}
            if (sp.TryWrite(31)) {sp.Write(m_third_part_device_id);}
            if (sp.TryWrite(32)) {sp.Write(m_attribute);}
            sp.EnEnd();
        }
        public void CopyFrom(LoginInfo source) {
            m_pvc_ver = source.m_pvc_ver;
            m_account_type = source.m_account_type;
            m_token = source.m_token;
            m_login_name = source.m_login_name;
            m_ip = source.m_ip;
            m_client_version = source.m_client_version;
            m_os_version = source.m_os_version;
            m_device_name = source.m_device_name;
            m_device_id = source.m_device_id;
            m_device_id_type = source.m_device_id_type;
            m_locale = source.m_locale;
            m_open_udid = source.m_open_udid;
            m_platform_id = source.m_platform_id;
            m_user_id = source.m_user_id;
            m_mode = source.m_mode;
            m_server_id = source.m_server_id;
            m_device_id_type_str = source.m_device_id_type_str;
            m_bundle_id = source.m_bundle_id;
            m_publisher_channel = source.m_publisher_channel;
            m_locale_lang = source.m_locale_lang;
            m_device_state = source.m_device_state;
            m_is_simulator = source.m_is_simulator;
            m_idfa = source.m_idfa;
            m_idfv = source.m_idfv;
            m_google_aid = source.m_google_aid;
            m_android_id = source.m_android_id;
            m_mac_address = source.m_mac_address;
            m_latitude = source.m_latitude;
            m_longitude = source.m_longitude;
            m_altitude = source.m_altitude;
            m_network_type = source.m_network_type;
            m_third_part_device_id = source.m_third_part_device_id;
            m_attribute = source.m_attribute;
        }
    }
    
    [Serializable]
    public partial class ServerListInfo : NetworkMessage {
        public static int[] Id = { 8,1 };
        public static Ctrl VC;
        public Int16 m_num;
        public List<ServerInfo> m_list = new List<ServerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_num = sp.ReadInt16();}
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
        public void CopyFrom(ServerListInfo source) {
            m_num = source.m_num;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class BuildingCancelInfo : NetworkMessage {
        public static int[] Id = { 14,1 };
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
        public void CopyFrom(BuildingCancelInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class TimeNtfInfo : NetworkMessage {
        public static int[] Id = { 20,1 };
        public static Ctrl VC;
        public Int64 m_t;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_t = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_t);}
            sp.EnEnd();
        }
        public void CopyFrom(TimeNtfInfo source) {
            m_t = source.m_t;
        }
    }
    
    [Serializable]
    public partial class ArmyInfo : NetworkMessage {
        public static int[] Id = { 26,1 };
        public static Ctrl VC;
        public Int16 m_army_type;
        public Int64 m_army_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_army_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_army_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_army_type);}
            if (sp.TryWrite(1)) {sp.Write(m_army_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(ArmyInfo source) {
            m_army_type = source.m_army_type;
            m_army_cnt = source.m_army_cnt;
        }
    }
    
    [Serializable]
    public partial class FightTroop : NetworkMessage {
        public static int[] Id = { 32,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int16 m_atk_type;
        public Int64 m_hp;
        public List<ArmyInfo> m_army_list = new List<ArmyInfo>();
        public Int16 m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_atk_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_hp = sp.ReadInt64();}
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
            if (sp.TryRead(6)) {m_pos = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_atk_type);}
            if (sp.TryWrite(4)) {sp.Write(m_hp);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army_list.Count);
                for (int i = 0; i != m_army_list.Count; ++i) {
                    m_army_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_pos);}
            sp.EnEnd();
        }
        public void CopyFrom(FightTroop source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_atk_type = source.m_atk_type;
            m_hp = source.m_hp;
            m_army_list = source.m_army_list;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class FightLoot : NetworkMessage {
        public static int[] Id = { 38,1 };
        public static Ctrl VC;
        public List<FightResInfo> m_res = new List<FightResInfo>();
        public Int32 m_rate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightResInfo tmp = new FightResInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_rate = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_rate);}
            sp.EnEnd();
        }
        public void CopyFrom(FightLoot source) {
            m_res = source.m_res;
            m_rate = source.m_rate;
        }
    }
    
    [Serializable]
    public partial class FightRound : NetworkMessage {
        public static int[] Id = { 44,1 };
        public static Ctrl VC;
        public Int16 m_circle;
        public Int32 m_timestamp;
        public List<AtkAction> m_atk_list = new List<AtkAction>();
        public List<DamageAction> m_damage_list = new List<DamageAction>();
        public CleanAction m_clean;
        public List<AbilityAction> m_ability = new List<AbilityAction>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_circle = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_timestamp = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_atk_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AtkAction tmp = new AtkAction();
                    tmp.Decode(sp);
                    m_atk_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_damage_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DamageAction tmp = new DamageAction();
                    tmp.Decode(sp);
                    m_damage_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_clean = new CleanAction();
                m_clean.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ability.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AbilityAction tmp = new AbilityAction();
                    tmp.Decode(sp);
                    m_ability.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_circle);}
            if (sp.TryWrite(1)) {sp.Write(m_timestamp);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_atk_list.Count);
                for (int i = 0; i != m_atk_list.Count; ++i) {
                    m_atk_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_damage_list.Count);
                for (int i = 0; i != m_damage_list.Count; ++i) {
                    m_damage_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_clean.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_ability.Count);
                for (int i = 0; i != m_ability.Count; ++i) {
                    m_ability[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FightRound source) {
            m_circle = source.m_circle;
            m_timestamp = source.m_timestamp;
            m_atk_list = source.m_atk_list;
            m_damage_list = source.m_damage_list;
            m_clean = source.m_clean;
            m_ability = source.m_ability;
        }
    }
    
    [Serializable]
    public partial class UserAllianceBrief : NetworkMessage {
        public static int[] Id = { 50,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int16 m_rank;
        public Int16 m_color;
        public Int16 m_title;
        public Int16 m_logo;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_color = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_title = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_logo = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_color);}
            if (sp.TryWrite(5)) {sp.Write(m_title);}
            if (sp.TryWrite(6)) {sp.Write(m_logo);}
            sp.EnEnd();
        }
        public void CopyFrom(UserAllianceBrief source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_rank = source.m_rank;
            m_color = source.m_color;
            m_title = source.m_title;
            m_logo = source.m_logo;
        }
    }
    
    [Serializable]
    public partial class GridInfo : NetworkMessage {
        public static int[] Id = { 56,1 };
        public static Ctrl VC;
        public MapBuildingInfo m_building;
        public List<TerritoryInfo> m_territory = new List<TerritoryInfo>();
        public List<MarchInfo> m_march = new List<MarchInfo>();
        public List<FightRecord> m_fight_record = new List<FightRecord>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_building = new MapBuildingInfo();
                m_building.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_territory.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TerritoryInfo tmp = new TerritoryInfo();
                    tmp.Decode(sp);
                    m_territory.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fight_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightRecord tmp = new FightRecord();
                    tmp.Decode(sp);
                    m_fight_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_building.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_territory.Count);
                for (int i = 0; i != m_territory.Count; ++i) {
                    m_territory[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_march.Count);
                for (int i = 0; i != m_march.Count; ++i) {
                    m_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fight_record.Count);
                for (int i = 0; i != m_fight_record.Count; ++i) {
                    m_fight_record[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(GridInfo source) {
            m_building = source.m_building;
            m_territory = source.m_territory;
            m_march = source.m_march;
            m_fight_record = source.m_fight_record;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GridPos : NetworkMessage {
        public static int[] Id = { 62,1 };
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
        public void CopyFrom(GridPos source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceRecruitSnap : NetworkMessage {
        public static int[] Id = { 68,1 };
        public static Ctrl VC;
        public Boolean m_stat_ranking;
        public Boolean m_stat_pending;
        public RankInfo m_ranking;
        public String m_recruit_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stat_ranking = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_stat_pending = sp.ReadBoolean();}
            if (sp.TryRead(2)) {
                m_ranking = new RankInfo();
                m_ranking.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_recruit_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_stat_ranking);}
            if (sp.TryWrite(1)) {sp.Write(m_stat_pending);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_ranking.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_recruit_content);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRecruitSnap source) {
            m_stat_ranking = source.m_stat_ranking;
            m_stat_pending = source.m_stat_pending;
            m_ranking = source.m_ranking;
            m_recruit_content = source.m_recruit_content;
        }
    }
    
    [Serializable]
    public partial class AllianceReqInfo : NetworkMessage {
        public static int[] Id = { 74,1 };
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
        public void CopyFrom(AllianceReqInfo source) {
            m_alliance_id = source.m_alliance_id;
        }
    }
    
    [Serializable]
    public partial class EventRewardReportBaseInfo : NetworkMessage {
        public static int[] Id = { 80,1 };
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
        public void CopyFrom(EventRewardReportBaseInfo source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class NpcMailBaseInfo : NetworkMessage {
        public static int[] Id = { 86,1 };
        public static Ctrl VC;
        public String m_user_name = "";
        public Int32 m_user_icon;
        public String m_title = "";
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_user_icon = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_name);}
            if (sp.TryWrite(1)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_title);}
            if (sp.TryWrite(3)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(NpcMailBaseInfo source) {
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_title = source.m_title;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class RecvGiftReportBaseInfo : NetworkMessage {
        public static int[] Id = { 92,1 };
        public static Ctrl VC;
        public Int16 m_alliance_rank;
        public String m_alliance_name = "";
        public String m_user_name = "";
        public TilePos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_rank = sp.ReadInt16();}
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
        public void CopyFrom(RecvGiftReportBaseInfo source) {
            m_alliance_rank = source.m_alliance_rank;
            m_alliance_name = source.m_alliance_name;
            m_user_name = source.m_user_name;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class OccupyReportBaseInfo : NetworkMessage {
        public static int[] Id = { 98,1 };
        public static Ctrl VC;
        public TilePos m_pos;
        public Int16 m_res_point_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_res_point_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_res_point_type);}
            sp.EnEnd();
        }
        public void CopyFrom(OccupyReportBaseInfo source) {
            m_pos = source.m_pos;
            m_res_point_type = source.m_res_point_type;
        }
    }
    
    [Serializable]
    public partial class RebelSummaryReportBaseInfo : NetworkMessage {
        public static int[] Id = { 104,1 };
        public static Ctrl VC;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_id;
        public Int16 m_level;
        public SByte m_stat;
        public Int16 m_cfg_id;
        public SByte m_result;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_result = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            if (sp.TryWrite(2)) {sp.Write(m_id);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_stat);}
            if (sp.TryWrite(5)) {sp.Write(m_cfg_id);}
            if (sp.TryWrite(6)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelSummaryReportBaseInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_id = source.m_id;
            m_level = source.m_level;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class PresMailDetailInfo : NetworkMessage {
        public static int[] Id = { 110,1 };
        public static Ctrl VC;
        public PresMailBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new PresMailBaseInfo();
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
        public void CopyFrom(PresMailDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class RebelScoutReportDetailInfo : NetworkMessage {
        public static int[] Id = { 116,1 };
        public static Ctrl VC;
        public RebelScoutReportBaseInfo m_base_info;
        public Int32 m_cur_wave;
        public List<ScoutTroopGroup> m_troops = new List<ScoutTroopGroup>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelScoutReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_wave = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ScoutTroopGroup tmp = new ScoutTroopGroup();
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
            if (sp.TryWrite(1)) {sp.Write(m_cur_wave);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(RebelScoutReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_cur_wave = source.m_cur_wave;
            m_troops = source.m_troops;
        }
    }
    
    [Serializable]
    public partial class CollectResReportDetailInfo : NetworkMessage {
        public static int[] Id = { 122,1 };
        public static Ctrl VC;
        public CollectResReportBaseInfo m_base_info;
        public List<FightResInfo> m_res_info = new List<FightResInfo>();
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new CollectResReportBaseInfo();
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
        public void CopyFrom(CollectResReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_res_info = source.m_res_info;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class MbRewardReportBaseInfo : NetworkMessage {
        public static int[] Id = { 128,1 };
        public static Ctrl VC;
        public Int16 m_x;
        public Int16 m_y;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_y = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_x);}
            if (sp.TryWrite(1)) {sp.Write(m_y);}
            sp.EnEnd();
        }
        public void CopyFrom(MbRewardReportBaseInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class GetResearchListAckInfo : NetworkMessage {
        public static int[] Id = { 134,1 };
        public static Ctrl VC;
        public List<ResearchBaseInfo> m_list_info = new List<ResearchBaseInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResearchBaseInfo tmp = new ResearchBaseInfo();
                    tmp.Decode(sp);
                    m_list_info.Add(tmp);
                }
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
            sp.EnEnd();
        }
        public void CopyFrom(GetResearchListAckInfo source) {
            m_list_info = source.m_list_info;
        }
    }
    
    [Serializable]
    public partial class UpgradeResearchNtfInfo : NetworkMessage {
        public static int[] Id = { 140,1 };
        public static Ctrl VC;
        public List<ResearchProgInfo> m_progs = new List<ResearchProgInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_progs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResearchProgInfo tmp = new ResearchProgInfo();
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
        public void CopyFrom(UpgradeResearchNtfInfo source) {
            m_progs = source.m_progs;
        }
    }
    
    [Serializable]
    public partial class GetDailyQuestListAckInfo : NetworkMessage {
        public static int[] Id = { 146,1 };
        public static Ctrl VC;
        public Int64 m_last_update_time;
        public Int32 m_update_time_length;
        public List<DailyQuestInfo> m_quest_list = new List<DailyQuestInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_last_update_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_update_time_length = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_quest_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailyQuestInfo tmp = new DailyQuestInfo();
                    tmp.Decode(sp);
                    m_quest_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_last_update_time);}
            if (sp.TryWrite(1)) {sp.Write(m_update_time_length);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_quest_list.Count);
                for (int i = 0; i != m_quest_list.Count; ++i) {
                    m_quest_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GetDailyQuestListAckInfo source) {
            m_last_update_time = source.m_last_update_time;
            m_update_time_length = source.m_update_time_length;
            m_quest_list = source.m_quest_list;
        }
    }
    
    [Serializable]
    public partial class QuestPendingInfo : NetworkMessage {
        public static int[] Id = { 152,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_count;
        public Int64 m_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_max = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            if (sp.TryWrite(2)) {sp.Write(m_max);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestPendingInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
            m_max = source.m_max;
        }
    }
    
    [Serializable]
    public partial class AllianceMember : NetworkMessage {
        public static int[] Id = { 158,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_rank;
        public Int64 m_force;
        public Int16 m_title;
        public Int16 m_icon;
        public String m_avatar = "";
        public List<Int16> m_permissions = new List<Int16>();
        public Int64 m_killcnt;
        public Int64 m_last_offline_time;
        public Int64 m_land_count;
        public ServerTilePos m_pos;
        public Int16 m_avatar_frame;
        public List<ResTypeInfo> m_land_res = new List<ResTypeInfo>();
        public Int64 m_monument_id;
        public Int64 m_city_id;
        public Int64 m_weekly_donate;
        public Int64 m_weekly_help;
        public Boolean m_land_res_full;
        public Int16 m_vip;
        public List<ResTypeInfo> m_kvk_land_res = new List<ResTypeInfo>();
        public Boolean m_kvk_land_res_full;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_force = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_title = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_permissions.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_permissions.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_killcnt = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_last_offline_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_land_count = sp.ReadInt64();}
            if (sp.TryRead(11)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_land_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_land_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {m_monument_id = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_city_id = sp.ReadInt64();}
            if (sp.TryRead(16)) {m_weekly_donate = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_weekly_help = sp.ReadInt64();}
            if (sp.TryRead(18)) {m_land_res_full = sp.ReadBoolean();}
            if (sp.TryRead(19)) {m_vip = sp.ReadInt16();}
            if (sp.TryRead(20)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_land_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_kvk_land_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(21)) {m_kvk_land_res_full = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_force);}
            if (sp.TryWrite(4)) {sp.Write(m_title);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_permissions.Count);
                for (int i = 0; i != m_permissions.Count; ++i) {
                    sp.Write(m_permissions[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_killcnt);}
            if (sp.TryWrite(9)) {sp.Write(m_last_offline_time);}
            if (sp.TryWrite(10)) {sp.Write(m_land_count);}
            if (sp.TryWrite(11)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(12)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_land_res.Count);
                for (int i = 0; i != m_land_res.Count; ++i) {
                    m_land_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {sp.Write(m_monument_id);}
            if (sp.TryWrite(15)) {sp.Write(m_city_id);}
            if (sp.TryWrite(16)) {sp.Write(m_weekly_donate);}
            if (sp.TryWrite(17)) {sp.Write(m_weekly_help);}
            if (sp.TryWrite(18)) {sp.Write(m_land_res_full);}
            if (sp.TryWrite(19)) {sp.Write(m_vip);}
            if (sp.TryWrite(20)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_land_res.Count);
                for (int i = 0; i != m_kvk_land_res.Count; ++i) {
                    m_kvk_land_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(21)) {sp.Write(m_kvk_land_res_full);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMember source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_rank = source.m_rank;
            m_force = source.m_force;
            m_title = source.m_title;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_permissions = source.m_permissions;
            m_killcnt = source.m_killcnt;
            m_last_offline_time = source.m_last_offline_time;
            m_land_count = source.m_land_count;
            m_pos = source.m_pos;
            m_avatar_frame = source.m_avatar_frame;
            m_land_res = source.m_land_res;
            m_monument_id = source.m_monument_id;
            m_city_id = source.m_city_id;
            m_weekly_donate = source.m_weekly_donate;
            m_weekly_help = source.m_weekly_help;
            m_land_res_full = source.m_land_res_full;
            m_vip = source.m_vip;
            m_kvk_land_res = source.m_kvk_land_res;
            m_kvk_land_res_full = source.m_kvk_land_res_full;
        }
    }
    
    [Serializable]
    public partial class DetailStyle : NetworkMessage {
        public static int[] Id = { 164,1 };
        public static Ctrl VC;
        public Int16 m_pos;
        public Int16 m_t_type;
        public Boolean m_anyone;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pos = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_t_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_anyone = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pos);}
            if (sp.TryWrite(1)) {sp.Write(m_t_type);}
            if (sp.TryWrite(2)) {sp.Write(m_anyone);}
            sp.EnEnd();
        }
        public void CopyFrom(DetailStyle source) {
            m_pos = source.m_pos;
            m_t_type = source.m_t_type;
            m_anyone = source.m_anyone;
        }
    }
    
    [Serializable]
    public partial class Item : NetworkMessage {
        public static int[] Id = { 170,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int16 m_item_subtype;
        public Int16 m_item_optype;
        public Int64 m_item_duration;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_subtype = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_item_optype = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_item_duration = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_item_subtype);}
            if (sp.TryWrite(3)) {sp.Write(m_item_optype);}
            if (sp.TryWrite(4)) {sp.Write(m_item_duration);}
            sp.EnEnd();
        }
        public void CopyFrom(Item source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_item_subtype = source.m_item_subtype;
            m_item_optype = source.m_item_optype;
            m_item_duration = source.m_item_duration;
        }
    }
    
    [Serializable]
    public partial class PowerRanklistReq : NetworkMessage {
        public static int[] Id = { 176,1 };
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
        public void CopyFrom(PowerRanklistReq source) {
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class AllianceHelpReq : NetworkMessage {
        public static int[] Id = { 182,1 };
        public static Ctrl VC;
        public Int16 m_prog_type;
        public Int16 m_prog_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_prog_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_prog_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_prog_type);}
            if (sp.TryWrite(1)) {sp.Write(m_prog_id);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceHelpReq source) {
            m_prog_type = source.m_prog_type;
            m_prog_id = source.m_prog_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AllianceDelHelpNtf : NetworkMessage {
        public static int[] Id = { 188,1 };
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
        public void CopyFrom(AllianceDelHelpNtf source) {
            m_user_id = source.m_user_id;
            m_help_id = source.m_help_id;
        }
    }
    
    [Serializable]
    public partial class DetailRanklistReq : NetworkMessage {
        public static int[] Id = { 194,1 };
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
        public void CopyFrom(DetailRanklistReq source) {
            m_type = source.m_type;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class BuildingFreeCheckReq : NetworkMessage {
        public static int[] Id = { 200,1 };
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
        public void CopyFrom(BuildingFreeCheckReq source) {
            m_prog_id = source.m_prog_id;
        }
    }
    
    [Serializable]
    public partial class BeAtkHero : NetworkMessage {
        public static int[] Id = { 206,1 };
        public static Ctrl VC;
        public List<GroupAgentInfo> m_agents = new List<GroupAgentInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GroupAgentInfo tmp = new GroupAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
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
            sp.EnEnd();
        }
        public void CopyFrom(BeAtkHero source) {
            m_agents = source.m_agents;
        }
    }
    
    [Serializable]
    public partial class EmbassyInfo : NetworkMessage {
        public static int[] Id = { 212,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int64 m_cur_cnt;
        public Int64 m_max_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cur_cnt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_max_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_max_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(EmbassyInfo source) {
            m_user_id = source.m_user_id;
            m_cur_cnt = source.m_cur_cnt;
            m_max_cnt = source.m_max_cnt;
        }
    }
    
    [Serializable]
    public partial class ServerGridInfo : NetworkMessage {
        public static int[] Id = { 218,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_user_id;
        public GridInfo m_grid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                m_grid = new GridInfo();
                m_grid.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_grid.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ServerGridInfo source) {
            m_server_id = source.m_server_id;
            m_user_id = source.m_user_id;
            m_grid = source.m_grid;
        }
    }
    
    [Serializable]
    public partial class UpdateAllianceMemberTitleAckInfo : NetworkMessage {
        public static int[] Id = { 224,1 };
        public static Ctrl VC;
        public Int16 m_code;
        public Int64 m_datetime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_datetime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {sp.Write(m_datetime);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdateAllianceMemberTitleAckInfo source) {
            m_code = source.m_code;
            m_datetime = source.m_datetime;
        }
    }
    
    [Serializable]
    public partial class ListAllianceInviteInfo : NetworkMessage {
        public static int[] Id = { 230,1 };
        public static Ctrl VC;
        public List<InviteInfo> m_infos = new List<InviteInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    InviteInfo tmp = new InviteInfo();
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
        public void CopyFrom(ListAllianceInviteInfo source) {
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class ResHistoryInfo : NetworkMessage {
        public static int[] Id = { 236,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public ResTypeInfo m_res;
        public Int64 m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_res = new ResTypeInfo();
                m_res.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_res.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(ResHistoryInfo source) {
            m_user_id = source.m_user_id;
            m_res = source.m_res;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class AllianceResApplyResultInfo : NetworkMessage {
        public static int[] Id = { 242,1 };
        public static Ctrl VC;
        public ResTypeInfo m_res;
        public Boolean m_approved;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_res = new ResTypeInfo();
                m_res.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_approved = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_res.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_approved);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResApplyResultInfo source) {
            m_res = source.m_res;
            m_approved = source.m_approved;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class DominionMapInfo : NetworkMessage {
        public static int[] Id = { 248,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_alliance_abbr = "";
        public Int16 m_alliance_color;
        public List<TilePos> m_tiles = new List<TilePos>();
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_alliance_color = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tiles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_tiles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_alliance_color);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tiles.Count);
                for (int i = 0; i != m_tiles.Count; ++i) {
                    m_tiles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(DominionMapInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_alliance_abbr = source.m_alliance_abbr;
            m_alliance_color = source.m_alliance_color;
            m_tiles = source.m_tiles;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class ShutDownMessage : NetworkMessage {
        public static int[] Id = { 254,1 };
        public static Ctrl VC;
        public String m_message = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_message = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_message);}
            sp.EnEnd();
        }
        public void CopyFrom(ShutDownMessage source) {
            m_message = source.m_message;
        }
    }
    
    [Serializable]
    public partial class CaptorsInfo : NetworkMessage {
        public static int[] Id = { 260,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int16 m_src_x;
        public Int16 m_src_y;
        public UserAllianceBrief m_alliance_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_src_x = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_src_y = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                m_alliance_info = new UserAllianceBrief();
                m_alliance_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_src_x);}
            if (sp.TryWrite(3)) {sp.Write(m_src_y);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptorsInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_src_x = source.m_src_x;
            m_src_y = source.m_src_y;
            m_alliance_info = source.m_alliance_info;
        }
    }
    
    [Serializable]
    public partial class AllianceCommentInfo : NetworkMessage {
        public static int[] Id = { 266,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_user_icon;
        public Int16 m_vip;
        public Boolean m_mods;
        public UserAllianceBrief m_user_alliance;
        public AllianceSnapInfo m_alliance_snap;
        public String m_content = "";
        public Int64 m_post_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_user_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_vip = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_mods = sp.ReadBoolean();}
            if (sp.TryRead(5)) {
                m_user_alliance = new UserAllianceBrief();
                m_user_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                m_alliance_snap = new AllianceSnapInfo();
                m_alliance_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_content = sp.ReadString();}
            if (sp.TryRead(8)) {m_post_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_vip);}
            if (sp.TryWrite(4)) {sp.Write(m_mods);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_content);}
            if (sp.TryWrite(8)) {sp.Write(m_post_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceCommentInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_vip = source.m_vip;
            m_mods = source.m_mods;
            m_user_alliance = source.m_user_alliance;
            m_alliance_snap = source.m_alliance_snap;
            m_content = source.m_content;
            m_post_time = source.m_post_time;
        }
    }
    
    [Serializable]
    public partial class AllianceJoinApplyInfo : NetworkMessage {
        public static int[] Id = { 272,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_icon;
        public String m_name = "";
        public Int64 m_power;
        public Int64 m_troop_kill;
        public Int64 m_apply_time;
        public String m_profile = "";
        public Int16 m_hq_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_troop_kill = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_apply_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_profile = sp.ReadString();}
            if (sp.TryRead(7)) {m_hq_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_troop_kill);}
            if (sp.TryWrite(5)) {sp.Write(m_apply_time);}
            if (sp.TryWrite(6)) {sp.Write(m_profile);}
            if (sp.TryWrite(7)) {sp.Write(m_hq_level);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceJoinApplyInfo source) {
            m_user_id = source.m_user_id;
            m_icon = source.m_icon;
            m_name = source.m_name;
            m_power = source.m_power;
            m_troop_kill = source.m_troop_kill;
            m_apply_time = source.m_apply_time;
            m_profile = source.m_profile;
            m_hq_level = source.m_hq_level;
        }
    }
    
    [Serializable]
    public partial class ManageAllianceRecruitmentInfo : NetworkMessage {
        public static int[] Id = { 278,1 };
        public static Ctrl VC;
        public Boolean m_open;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_open = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_open);}
            sp.EnEnd();
        }
        public void CopyFrom(ManageAllianceRecruitmentInfo source) {
            m_open = source.m_open;
        }
    }
    
    [Serializable]
    public partial class DismissAllianceInfo : NetworkMessage {
        public static int[] Id = { 284,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(DismissAllianceInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class OpenAllianceGiftAckInfo : NetworkMessage {
        public static int[] Id = { 290,1 };
        public static Ctrl VC;
        public List<OpenAllianceGiftResult> m_result = new List<OpenAllianceGiftResult>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OpenAllianceGiftResult tmp = new OpenAllianceGiftResult();
                    tmp.Decode(sp);
                    m_result.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_result.Count);
                for (int i = 0; i != m_result.Count; ++i) {
                    m_result[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OpenAllianceGiftAckInfo source) {
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class IapActivationInfo : NetworkMessage {
        public static int[] Id = { 296,1 };
        public static Ctrl VC;
        public Int32 m_sub_id;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sub_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sub_id);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(IapActivationInfo source) {
            m_sub_id = source.m_sub_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class DefenceListInfo : NetworkMessage {
        public static int[] Id = { 302,1 };
        public static Ctrl VC;
        public List<DefenceInfo> m_defence_list = new List<DefenceInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defence_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DefenceInfo tmp = new DefenceInfo();
                    tmp.Decode(sp);
                    m_defence_list.Add(tmp);
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
                sp.Write((UInt16)m_defence_list.Count);
                for (int i = 0; i != m_defence_list.Count; ++i) {
                    m_defence_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(DefenceListInfo source) {
            m_defence_list = source.m_defence_list;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class BindInfo : NetworkMessage {
        public static int[] Id = { 308,1 };
        public static Ctrl VC;
        public String m_token = "";
        public String m_login_name = "";
        public String m_pwd = "";
        public SByte m_enter_type;
        public String m_sns_id = "";
        public String m_sns_mail = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_login_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_pwd = sp.ReadString();}
            if (sp.TryRead(3)) {m_enter_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_sns_id = sp.ReadString();}
            if (sp.TryRead(5)) {m_sns_mail = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_token);}
            if (sp.TryWrite(1)) {sp.Write(m_login_name);}
            if (sp.TryWrite(2)) {sp.Write(m_pwd);}
            if (sp.TryWrite(3)) {sp.Write(m_enter_type);}
            if (sp.TryWrite(4)) {sp.Write(m_sns_id);}
            if (sp.TryWrite(5)) {sp.Write(m_sns_mail);}
            sp.EnEnd();
        }
        public void CopyFrom(BindInfo source) {
            m_token = source.m_token;
            m_login_name = source.m_login_name;
            m_pwd = source.m_pwd;
            m_enter_type = source.m_enter_type;
            m_sns_id = source.m_sns_id;
            m_sns_mail = source.m_sns_mail;
        }
    }
    
    [Serializable]
    public partial class MapmarkIdInfo : NetworkMessage {
        public static int[] Id = { 314,1 };
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
        public void CopyFrom(MapmarkIdInfo source) {
            m_id = source.m_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class FteInfo : NetworkMessage {
        public static int[] Id = { 320,1 };
        public static Ctrl VC;
        public Int32 m_step;
        public String m_udid = "";
        public Int16 m_bit_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_udid = sp.ReadString();}
            if (sp.TryRead(2)) {m_bit_flag = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_udid);}
            if (sp.TryWrite(2)) {sp.Write(m_bit_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(FteInfo source) {
            m_step = source.m_step;
            m_udid = source.m_udid;
            m_bit_flag = source.m_bit_flag;
        }
    }
    
    [Serializable]
    public partial class MonumentStatus : NetworkMessage {
        public static int[] Id = { 326,1 };
        public static Ctrl VC;
        public SByte m_status;
        public Int64 m_open_time;
        public Int64 m_occupy_start;
        public Int64 m_occupy_end;
        public Int64 m_city_hp;
        public Int64 m_city_hp_limit;
        public Int64 m_city_hp_recover_speed;
        public Int64 m_city_hp_recover_time;
        public Int64 m_city_hp_update_time;
        public Int64 m_close_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_occupy_start = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_occupy_end = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_city_hp = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_city_hp_limit = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_city_hp_recover_speed = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_city_hp_recover_time = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_city_hp_update_time = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_close_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_open_time);}
            if (sp.TryWrite(2)) {sp.Write(m_occupy_start);}
            if (sp.TryWrite(3)) {sp.Write(m_occupy_end);}
            if (sp.TryWrite(4)) {sp.Write(m_city_hp);}
            if (sp.TryWrite(5)) {sp.Write(m_city_hp_limit);}
            if (sp.TryWrite(6)) {sp.Write(m_city_hp_recover_speed);}
            if (sp.TryWrite(7)) {sp.Write(m_city_hp_recover_time);}
            if (sp.TryWrite(8)) {sp.Write(m_city_hp_update_time);}
            if (sp.TryWrite(9)) {sp.Write(m_close_time);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentStatus source) {
            m_status = source.m_status;
            m_open_time = source.m_open_time;
            m_occupy_start = source.m_occupy_start;
            m_occupy_end = source.m_occupy_end;
            m_city_hp = source.m_city_hp;
            m_city_hp_limit = source.m_city_hp_limit;
            m_city_hp_recover_speed = source.m_city_hp_recover_speed;
            m_city_hp_recover_time = source.m_city_hp_recover_time;
            m_city_hp_update_time = source.m_city_hp_update_time;
            m_close_time = source.m_close_time;
        }
    }
    
    [Serializable]
    public partial class DailyEventInfo : NetworkMessage {
        public static int[] Id = { 332,1 };
        public static Ctrl VC;
        public List<DailyEventNode> m_events = new List<DailyEventNode>();
        public Int64 m_next_update_time;
        public Int16 m_score;
        public List<DailyEventReward> m_rewards = new List<DailyEventReward>();
        public WeeklyActivityInfo m_weekly_ac_detail;

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
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailyEventReward tmp = new DailyEventReward();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_weekly_ac_detail = new WeeklyActivityInfo();
                m_weekly_ac_detail.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_weekly_ac_detail.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyEventInfo source) {
            m_events = source.m_events;
            m_next_update_time = source.m_next_update_time;
            m_score = source.m_score;
            m_rewards = source.m_rewards;
            m_weekly_ac_detail = source.m_weekly_ac_detail;
        }
    }
    
    [Serializable]
    public partial class UseInvitationReqInfo : NetworkMessage {
        public static int[] Id = { 338,1 };
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
        public void CopyFrom(UseInvitationReqInfo source) {
            m_cdkey = source.m_cdkey;
        }
    }
    
    [Serializable]
    public partial class GovernmentReqInfo : NetworkMessage {
        public static int[] Id = { 344,1 };
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
        public void CopyFrom(GovernmentReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class PayPresidentTaxBaseInfo : NetworkMessage {
        public static int[] Id = { 350,1 };
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
        public void CopyFrom(PayPresidentTaxBaseInfo source) {
            m_server_id = source.m_server_id;
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class PrizeListInfo : NetworkMessage {
        public static int[] Id = { 356,1 };
        public static Ctrl VC;
        public List<PrizeInfo> m_list_info = new List<PrizeInfo>();
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PrizeInfo tmp = new PrizeInfo();
                    tmp.Decode(sp);
                    m_list_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_count = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(PrizeListInfo source) {
            m_list_info = source.m_list_info;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class DiamondMineBindInfo : NetworkMessage {
        public static int[] Id = { 362,1 };
        public static Ctrl VC;
        public String m_id = "";
        public Int64 m_user_id;
        public Int64 m_next_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_next_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_next_time);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondMineBindInfo source) {
            m_id = source.m_id;
            m_user_id = source.m_user_id;
            m_next_time = source.m_next_time;
        }
    }
    
    [Serializable]
    public partial class FieldCaptivesInfo : NetworkMessage {
        public static int[] Id = { 368,1 };
        public static Ctrl VC;
        public List<BaseCaptiveInfo> m_list = new List<BaseCaptiveInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseCaptiveInfo tmp = new BaseCaptiveInfo();
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
        public void CopyFrom(FieldCaptivesInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class UserShieldInfo : NetworkMessage {
        public static int[] Id = { 374,1 };
        public static Ctrl VC;
        public Int64 m_shield_start;
        public Int64 m_shield_end;
        public Boolean m_newbie_shield;
        public Int64 m_newbie_shield_end;
        public Int64 m_newbie_shield_start;
        public Int64 m_gvg_shield_start;
        public Int64 m_gvg_shield_end;
        public Int64 m_map_guid;
        public Int64 m_as_shield_start;
        public Int64 m_as_shield_end;
        public Boolean m_as_shield;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_shield_start = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_shield_end = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_newbie_shield = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_newbie_shield_end = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_newbie_shield_start = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_gvg_shield_start = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_gvg_shield_end = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_as_shield_start = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_as_shield_end = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_as_shield = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_shield_start);}
            if (sp.TryWrite(1)) {sp.Write(m_shield_end);}
            if (sp.TryWrite(2)) {sp.Write(m_newbie_shield);}
            if (sp.TryWrite(3)) {sp.Write(m_newbie_shield_end);}
            if (sp.TryWrite(4)) {sp.Write(m_newbie_shield_start);}
            if (sp.TryWrite(5)) {sp.Write(m_gvg_shield_start);}
            if (sp.TryWrite(6)) {sp.Write(m_gvg_shield_end);}
            if (sp.TryWrite(7)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(8)) {sp.Write(m_as_shield_start);}
            if (sp.TryWrite(9)) {sp.Write(m_as_shield_end);}
            if (sp.TryWrite(10)) {sp.Write(m_as_shield);}
            sp.EnEnd();
        }
        public void CopyFrom(UserShieldInfo source) {
            m_shield_start = source.m_shield_start;
            m_shield_end = source.m_shield_end;
            m_newbie_shield = source.m_newbie_shield;
            m_newbie_shield_end = source.m_newbie_shield_end;
            m_newbie_shield_start = source.m_newbie_shield_start;
            m_gvg_shield_start = source.m_gvg_shield_start;
            m_gvg_shield_end = source.m_gvg_shield_end;
            m_map_guid = source.m_map_guid;
            m_as_shield_start = source.m_as_shield_start;
            m_as_shield_end = source.m_as_shield_end;
            m_as_shield = source.m_as_shield;
        }
    }
    
    [Serializable]
    public partial class AllianceMemberSalaryInfo : NetworkMessage {
        public static int[] Id = { 380,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_rank;
        public Int16 m_title;
        public Int64 m_amount;
        public Int64 m_contribution;
        public Boolean m_assigned;
        public Int16 m_icon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_title = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_contribution = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_assigned = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_icon = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_amount);}
            if (sp.TryWrite(5)) {sp.Write(m_contribution);}
            if (sp.TryWrite(6)) {sp.Write(m_assigned);}
            if (sp.TryWrite(7)) {sp.Write(m_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMemberSalaryInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_rank = source.m_rank;
            m_title = source.m_title;
            m_amount = source.m_amount;
            m_contribution = source.m_contribution;
            m_assigned = source.m_assigned;
            m_icon = source.m_icon;
        }
    }
    
    [Serializable]
    public partial class UseOutsourceInfo : NetworkMessage {
        public static int[] Id = { 386,1 };
        public static Ctrl VC;
        public Int64 m_size;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_size = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_size);}
            sp.EnEnd();
        }
        public void CopyFrom(UseOutsourceInfo source) {
            m_size = source.m_size;
        }
    }
    
    [Serializable]
    public partial class AccountCreateCheckReqInfo : NetworkMessage {
        public static int[] Id = { 392,1 };
        public static Ctrl VC;
        public String m_open_udid = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_open_udid = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_open_udid);}
            sp.EnEnd();
        }
        public void CopyFrom(AccountCreateCheckReqInfo source) {
            m_open_udid = source.m_open_udid;
        }
    }
    
    [Serializable]
    public partial class IapUnfinishOrderListInfo : NetworkMessage {
        public static int[] Id = { 398,1 };
        public static Ctrl VC;
        public Int32 m_iap_type;
        public List<String> m_list = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_list.Count);
                for (int i = 0; i != m_list.Count; ++i) {
                    sp.Write(m_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(IapUnfinishOrderListInfo source) {
            m_iap_type = source.m_iap_type;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class GetGuestRoleListReqInfo : NetworkMessage {
        public static int[] Id = { 404,1 };
        public static Ctrl VC;
        public String m_user_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_name);}
            sp.EnEnd();
        }
        public void CopyFrom(GetGuestRoleListReqInfo source) {
            m_user_name = source.m_user_name;
        }
    }
    
    [Serializable]
    public partial class AllianceRecruitReqInfo : NetworkMessage {
        public static int[] Id = { 410,1 };
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
        public void CopyFrom(AllianceRecruitReqInfo source) {
            m_alliance_id = source.m_alliance_id;
        }
    }
    
    [Serializable]
    public partial class RecruitWallListInfo : NetworkMessage {
        public static int[] Id = { 416,1 };
        public static Ctrl VC;
        public List<AllianceRecruitInfo> m_list = new List<AllianceRecruitInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceRecruitInfo tmp = new AllianceRecruitInfo();
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
        public void CopyFrom(RecruitWallListInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class LastAllianceCommentInfoList : NetworkMessage {
        public static int[] Id = { 422,1 };
        public static Ctrl VC;
        public List<LastAllianceCommentInfo> m_comment_list = new List<LastAllianceCommentInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_comment_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LastAllianceCommentInfo tmp = new LastAllianceCommentInfo();
                    tmp.Decode(sp);
                    m_comment_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_comment_list.Count);
                for (int i = 0; i != m_comment_list.Count; ++i) {
                    m_comment_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LastAllianceCommentInfoList source) {
            m_comment_list = source.m_comment_list;
        }
    }
    
    [Serializable]
    public partial class ListUserDominionInfo : NetworkMessage {
        public static int[] Id = { 428,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_amount;
        public List<DominionInfo> m_infos = new List<DominionInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
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
        public void CopyFrom(ListUserDominionInfo source) {
            m_user_id = source.m_user_id;
            m_amount = source.m_amount;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class AwesomeRelocateCityInfo : NetworkMessage {
        public static int[] Id = { 434,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_target_region_id;
        public ServerTilePos m_target;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_target_region_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                m_target = new ServerTilePos();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_target_region_id);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AwesomeRelocateCityInfo source) {
            m_type = source.m_type;
            m_target_region_id = source.m_target_region_id;
            m_target = source.m_target;
        }
    }
    
    [Serializable]
    public partial class ConfigToClientInfo : NetworkMessage {
        public static int[] Id = { 440,1 };
        public static Ctrl VC;
        public Boolean m_auto_translate_open;
        public Boolean m_free_translate_open;
        public Boolean m_baidu_free_translate;
        public Boolean m_google_free_translate;
        public String m_client_keep_str = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_auto_translate_open = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_free_translate_open = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_baidu_free_translate = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_google_free_translate = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_client_keep_str = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_auto_translate_open);}
            if (sp.TryWrite(1)) {sp.Write(m_free_translate_open);}
            if (sp.TryWrite(2)) {sp.Write(m_baidu_free_translate);}
            if (sp.TryWrite(3)) {sp.Write(m_google_free_translate);}
            if (sp.TryWrite(4)) {sp.Write(m_client_keep_str);}
            sp.EnEnd();
        }
        public void CopyFrom(ConfigToClientInfo source) {
            m_auto_translate_open = source.m_auto_translate_open;
            m_free_translate_open = source.m_free_translate_open;
            m_baidu_free_translate = source.m_baidu_free_translate;
            m_google_free_translate = source.m_google_free_translate;
            m_client_keep_str = source.m_client_keep_str;
        }
    }
    
    [Serializable]
    public partial class CsDyControlInfo : NetworkMessage {
        public static int[] Id = { 446,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public SByte m_action;
        public String m_cmd = "";
        public String m_param = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_action = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_cmd = sp.ReadString();}
            if (sp.TryRead(3)) {m_param = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_action);}
            if (sp.TryWrite(2)) {sp.Write(m_cmd);}
            if (sp.TryWrite(3)) {sp.Write(m_param);}
            sp.EnEnd();
        }
        public void CopyFrom(CsDyControlInfo source) {
            m_user_id = source.m_user_id;
            m_action = source.m_action;
            m_cmd = source.m_cmd;
            m_param = source.m_param;
        }
    }
    
    [Serializable]
    public partial class SpecialRewardInfo : NetworkMessage {
        public static int[] Id = { 452,1 };
        public static Ctrl VC;
        public String m_icon = "";
        public String m_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_icon = sp.ReadString();}
            if (sp.TryRead(1)) {m_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_icon);}
            if (sp.TryWrite(1)) {sp.Write(m_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(SpecialRewardInfo source) {
            m_icon = source.m_icon;
            m_desc = source.m_desc;
        }
    }
    
    [Serializable]
    public partial class SuperResGatherInfo : NetworkMessage {
        public static int[] Id = { 458,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int64 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(SuperResGatherInfo source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class ReceiversV1 : NetworkMessage {
        public static int[] Id = { 464,1 };
        public static Ctrl VC;
        public List<ContactInfoV1> m_receiver_list = new List<ContactInfoV1>();
        public Int32 m_as_id;
        public String m_as_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_receiver_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ContactInfoV1 tmp = new ContactInfoV1();
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
        public void CopyFrom(ReceiversV1 source) {
            m_receiver_list = source.m_receiver_list;
            m_as_id = source.m_as_id;
            m_as_abbr = source.m_as_abbr;
        }
    }
    
    [Serializable]
    public partial class AllianceDonate : NetworkMessage {
        public static int[] Id = { 470,1 };
        public static Ctrl VC;
        public SByte m_donate_type;
        public Int32 m_as_lvl;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_donate_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_as_lvl = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_donate_type);}
            if (sp.TryWrite(1)) {sp.Write(m_as_lvl);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceDonate source) {
            m_donate_type = source.m_donate_type;
            m_as_lvl = source.m_as_lvl;
        }
    }
    
    [Serializable]
    public partial class AllianceLevelInfo : NetworkMessage {
        public static int[] Id = { 476,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_level;
        public String m_name = "";
        public Int64 m_cur_exp;
        public Int64 m_need_exp;
        public Int64 m_cur_score;
        public Int64 m_refresh_time;
        public Int32 m_cur_donate_cnt;
        public Int32 m_can_donate_cnt;
        public List<ItemInfo> m_levelUp_reward = new List<ItemInfo>();
        public List<DonateInfo> m_donate_infos = new List<DonateInfo>();
        public List<DonateSectionInfo> m_sections = new List<DonateSectionInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_cur_exp = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_need_exp = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_cur_score = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_refresh_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_cur_donate_cnt = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_can_donate_cnt = sp.ReadInt32();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_levelUp_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_levelUp_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_donate_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DonateInfo tmp = new DonateInfo();
                    tmp.Decode(sp);
                    m_donate_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_sections.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DonateSectionInfo tmp = new DonateSectionInfo();
                    tmp.Decode(sp);
                    m_sections.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_cur_exp);}
            if (sp.TryWrite(4)) {sp.Write(m_need_exp);}
            if (sp.TryWrite(5)) {sp.Write(m_cur_score);}
            if (sp.TryWrite(6)) {sp.Write(m_refresh_time);}
            if (sp.TryWrite(7)) {sp.Write(m_cur_donate_cnt);}
            if (sp.TryWrite(8)) {sp.Write(m_can_donate_cnt);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_levelUp_reward.Count);
                for (int i = 0; i != m_levelUp_reward.Count; ++i) {
                    m_levelUp_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_donate_infos.Count);
                for (int i = 0; i != m_donate_infos.Count; ++i) {
                    m_donate_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_sections.Count);
                for (int i = 0; i != m_sections.Count; ++i) {
                    m_sections[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceLevelInfo source) {
            m_id = source.m_id;
            m_level = source.m_level;
            m_name = source.m_name;
            m_cur_exp = source.m_cur_exp;
            m_need_exp = source.m_need_exp;
            m_cur_score = source.m_cur_score;
            m_refresh_time = source.m_refresh_time;
            m_cur_donate_cnt = source.m_cur_donate_cnt;
            m_can_donate_cnt = source.m_can_donate_cnt;
            m_levelUp_reward = source.m_levelUp_reward;
            m_donate_infos = source.m_donate_infos;
            m_sections = source.m_sections;
        }
    }
    
    [Serializable]
    public partial class ScrollOfficer : NetworkMessage {
        public static int[] Id = { 482,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_officer_id;
        public SByte m_quality;

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
            if (sp.TryRead(5)) {m_quality = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_officer_id);}
            if (sp.TryWrite(5)) {sp.Write(m_quality);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollOfficer source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_officer_id = source.m_officer_id;
            m_quality = source.m_quality;
        }
    }
    
    [Serializable]
    public partial class LangLikeRankReq : NetworkMessage {
        public static int[] Id = { 488,1 };
        public static Ctrl VC;
        public SByte m_lang;
        public Int32 m_start;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_lang = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_start = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_lang);}
            if (sp.TryWrite(1)) {sp.Write(m_start);}
            if (sp.TryWrite(2)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(LangLikeRankReq source) {
            m_lang = source.m_lang;
            m_start = source.m_start;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class ExchangeResearchPointInfo : NetworkMessage {
        public static int[] Id = { 494,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public SByte m_exchange_type;
        public Int16 m_target_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_exchange_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_target_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_exchange_type);}
            if (sp.TryWrite(2)) {sp.Write(m_target_type);}
            sp.EnEnd();
        }
        public void CopyFrom(ExchangeResearchPointInfo source) {
            m_type = source.m_type;
            m_exchange_type = source.m_exchange_type;
            m_target_type = source.m_target_type;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchBuilding : NetworkMessage {
        public static int[] Id = { 500,1 };
        public static Ctrl VC;
        public SByte m_type;
        public SByte m_sub_type;
        public SByte m_status;
        public SByte m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_sub_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceResearchBuilding source) {
            m_type = source.m_type;
            m_sub_type = source.m_sub_type;
            m_status = source.m_status;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class UpgradeAllianceResearchAckInfo : NetworkMessage {
        public static int[] Id = { 506,1 };
        public static Ctrl VC;
        public AllianceResearchBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceResearchBaseInfo();
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
        public void CopyFrom(UpgradeAllianceResearchAckInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchUpgradeInfo : NetworkMessage {
        public static int[] Id = { 512,1 };
        public static Ctrl VC;
        public AllianceResearchDetailInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceResearchDetailInfo();
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
        public void CopyFrom(AllianceResearchUpgradeInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class RebelPartRewardBaseInfo : NetworkMessage {
        public static int[] Id = { 518,1 };
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
        public void CopyFrom(RebelPartRewardBaseInfo source) {
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
    public partial class AllianceBuildingUpgradeReportBaseInfo : NetworkMessage {
        public static int[] Id = { 524,1 };
        public static Ctrl VC;
        public ServerTilePos m_pos;
        public SByte m_type;
        public SByte m_sub_type;
        public SByte m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_sub_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_level = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBuildingUpgradeReportBaseInfo source) {
            m_pos = source.m_pos;
            m_type = source.m_type;
            m_sub_type = source.m_sub_type;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class KrelocatingNtfInfo : NetworkMessage {
        public static int[] Id = { 530,1 };
        public static Ctrl VC;
        public Int16 m_status;
        public Int64 m_last_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_last_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_last_time);}
            sp.EnEnd();
        }
        public void CopyFrom(KrelocatingNtfInfo source) {
            m_status = source.m_status;
            m_last_time = source.m_last_time;
        }
    }
    
    [Serializable]
    public partial class ItemExchangeInfo : NetworkMessage {
        public static int[] Id = { 536,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_limit;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_limit = sp.ReadInt16();}
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
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_limit);}
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
        public void CopyFrom(ItemExchangeInfo source) {
            m_id = source.m_id;
            m_limit = source.m_limit;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class GetLoginRewardStatus : NetworkMessage {
        public static int[] Id = { 542,1 };
        public static Ctrl VC;
        public SByte m_dayth;
        public SByte m_get;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_dayth = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_get = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_dayth);}
            if (sp.TryWrite(1)) {sp.Write(m_get);}
            sp.EnEnd();
        }
        public void CopyFrom(GetLoginRewardStatus source) {
            m_dayth = source.m_dayth;
            m_get = source.m_get;
        }
    }
    
    [Serializable]
    public partial class FbLoginShowRewardInfo : NetworkMessage {
        public static int[] Id = { 548,1 };
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
        public void CopyFrom(FbLoginShowRewardInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class AsOwnerChangeMailInfo : NetworkMessage {
        public static int[] Id = { 554,1 };
        public static Ctrl VC;
        public AsOwnerChangeMail m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AsOwnerChangeMail();
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
        public void CopyFrom(AsOwnerChangeMailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class AchievementNode : NetworkMessage {
        public static int[] Id = { 560,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_score;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(AchievementNode source) {
            m_id = source.m_id;
            m_score = source.m_score;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class IstanaServerInfo : NetworkMessage {
        public static int[] Id = { 566,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public AllianceSnapInfo m_alliance_snap;
        public List<BuffNtfInfo> m_buff_list = new List<BuffNtfInfo>();
        public AllianceOwnerInfo m_owner;
        public Int64 m_end_time;
        public Int64 m_base_war_time;

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
                m_buff_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_buff_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_owner = new AllianceOwnerInfo();
                m_owner.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_base_war_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_list.Count);
                for (int i = 0; i != m_buff_list.Count; ++i) {
                    m_buff_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_owner.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            if (sp.TryWrite(5)) {sp.Write(m_base_war_time);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaServerInfo source) {
            m_server_id = source.m_server_id;
            m_alliance_snap = source.m_alliance_snap;
            m_buff_list = source.m_buff_list;
            m_owner = source.m_owner;
            m_end_time = source.m_end_time;
            m_base_war_time = source.m_base_war_time;
        }
    }
    
    [Serializable]
    public partial class IstanaWarBaseInfo : NetworkMessage {
        public static int[] Id = { 572,1 };
        public static Ctrl VC;
        public List<IstanaServerInfo> m_list = new List<IstanaServerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IstanaServerInfo tmp = new IstanaServerInfo();
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
        public void CopyFrom(IstanaWarBaseInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class SwitchNode : NetworkMessage {
        public static int[] Id = { 578,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Boolean m_open;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_open = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_open);}
            sp.EnEnd();
        }
        public void CopyFrom(SwitchNode source) {
            m_type = source.m_type;
            m_open = source.m_open;
        }
    }
    
    [Serializable]
    public partial class IstanaRegionOwnerAckInfo : NetworkMessage {
        public static int[] Id = { 584,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public UserBriefInfo m_brief;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_brief = new UserBriefInfo();
                m_brief.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_brief.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaRegionOwnerAckInfo source) {
            m_server_id = source.m_server_id;
            m_brief = source.m_brief;
        }
    }
    
    [Serializable]
    public partial class FightSummaryElite : NetworkMessage {
        public static int[] Id = { 590,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_army_list = new List<ArmyInfo>();
        public List<FightArmyJoin> m_join_list = new List<FightArmyJoin>();
        public List<FightArmyLost> m_lose_list = new List<FightArmyLost>();

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
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_join_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightArmyJoin tmp = new FightArmyJoin();
                    tmp.Decode(sp);
                    m_join_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_lose_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightArmyLost tmp = new FightArmyLost();
                    tmp.Decode(sp);
                    m_lose_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_join_list.Count);
                for (int i = 0; i != m_join_list.Count; ++i) {
                    m_join_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_lose_list.Count);
                for (int i = 0; i != m_lose_list.Count; ++i) {
                    m_lose_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FightSummaryElite source) {
            m_army_list = source.m_army_list;
            m_join_list = source.m_join_list;
            m_lose_list = source.m_lose_list;
        }
    }
    
    [Serializable]
    public partial class MonthlyBookSuccessStatus : NetworkMessage {
        public static int[] Id = { 596,1 };
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
        public void CopyFrom(MonthlyBookSuccessStatus source) {
            m_success = source.m_success;
        }
    }
    
    [Serializable]
    public partial class ClientClickRecord : NetworkMessage {
        public static int[] Id = { 602,1 };
        public static Ctrl VC;
        public Int64 m_begin_date;
        public Int64 m_end_date;
        public Int64 m_option_in;
        public Int64 m_option_out;
        public String m_param1 = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_begin_date = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_end_date = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_option_in = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_option_out = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_param1 = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_begin_date);}
            if (sp.TryWrite(1)) {sp.Write(m_end_date);}
            if (sp.TryWrite(2)) {sp.Write(m_option_in);}
            if (sp.TryWrite(3)) {sp.Write(m_option_out);}
            if (sp.TryWrite(4)) {sp.Write(m_param1);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientClickRecord source) {
            m_begin_date = source.m_begin_date;
            m_end_date = source.m_end_date;
            m_option_in = source.m_option_in;
            m_option_out = source.m_option_out;
            m_param1 = source.m_param1;
        }
    }
    
    [Serializable]
    public partial class CrowdInvestPaybackReportBaseInfo : NetworkMessage {
        public static int[] Id = { 608,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Int32 m_copies;
        public Int64 m_diamonds;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_copies = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_diamonds = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_copies);}
            if (sp.TryWrite(3)) {sp.Write(m_diamonds);}
            sp.EnEnd();
        }
        public void CopyFrom(CrowdInvestPaybackReportBaseInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_copies = source.m_copies;
            m_diamonds = source.m_diamonds;
        }
    }
    
    [Serializable]
    public partial class SevendayTaskInfo : NetworkMessage {
        public static int[] Id = { 614,1 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public Int64 m_points;
        public List<TaskStepInfo> m_steps = new List<TaskStepInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_steps.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TaskStepInfo tmp = new TaskStepInfo();
                    tmp.Decode(sp);
                    m_steps.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_steps.Count);
                for (int i = 0; i != m_steps.Count; ++i) {
                    m_steps[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SevendayTaskInfo source) {
            m_task_id = source.m_task_id;
            m_points = source.m_points;
            m_steps = source.m_steps;
        }
    }
    
    [Serializable]
    public partial class GrowRebelInfo : NetworkMessage {
        public static int[] Id = { 620,1 };
        public static Ctrl VC;
        public Int32 m_user_ap;
        public Int16 m_grow_level;
        public Int16 m_max_level;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<TilePos> m_tiles = new List<TilePos>();
        public List<Int16> m_unissued = new List<Int16>();
        public Int32 m_ap_max;
        public Int64 m_march_buff_endtime;
        public Int16 m_pass_kill_limit;
        public Int16 m_kill_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_ap = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_grow_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_max_level = sp.ReadInt16();}
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
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tiles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_tiles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_unissued.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_unissued.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {m_ap_max = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_march_buff_endtime = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_pass_kill_limit = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_kill_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_ap);}
            if (sp.TryWrite(1)) {sp.Write(m_grow_level);}
            if (sp.TryWrite(2)) {sp.Write(m_max_level);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tiles.Count);
                for (int i = 0; i != m_tiles.Count; ++i) {
                    m_tiles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_unissued.Count);
                for (int i = 0; i != m_unissued.Count; ++i) {
                    sp.Write(m_unissued[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {sp.Write(m_ap_max);}
            if (sp.TryWrite(7)) {sp.Write(m_march_buff_endtime);}
            if (sp.TryWrite(8)) {sp.Write(m_pass_kill_limit);}
            if (sp.TryWrite(9)) {sp.Write(m_kill_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(GrowRebelInfo source) {
            m_user_ap = source.m_user_ap;
            m_grow_level = source.m_grow_level;
            m_max_level = source.m_max_level;
            m_items = source.m_items;
            m_tiles = source.m_tiles;
            m_unissued = source.m_unissued;
            m_ap_max = source.m_ap_max;
            m_march_buff_endtime = source.m_march_buff_endtime;
            m_pass_kill_limit = source.m_pass_kill_limit;
            m_kill_cnt = source.m_kill_cnt;
        }
    }
    
    [Serializable]
    public partial class FpsLevelInfo : NetworkMessage {
        public static int[] Id = { 626,1 };
        public static Ctrl VC;
        public Int16 m_fps_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fps_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fps_level);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsLevelInfo source) {
            m_fps_level = source.m_fps_level;
        }
    }
    
    [Serializable]
    public partial class AntiAdictionInfo : NetworkMessage {
        public static int[] Id = { 632,1 };
        public static Ctrl VC;
        public Int64 m_online_dur;
        public String m_id_card = "";
        public String m_card_name = "";
        public Boolean m_young;
        public Int32 m_verify_interval;
        public List<AntiAdictionRule> m_rules = new List<AntiAdictionRule>();
        public List<ItemInfo> m_verify_rewards = new List<ItemInfo>();
        public String m_phone_number = "";
        public Boolean m_id_card_forcibly;
        public Int64 m_monthly_pay_price;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_online_dur = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_id_card = sp.ReadString();}
            if (sp.TryRead(2)) {m_card_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_young = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_verify_interval = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rules.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AntiAdictionRule tmp = new AntiAdictionRule();
                    tmp.Decode(sp);
                    m_rules.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_verify_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_verify_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_phone_number = sp.ReadString();}
            if (sp.TryRead(8)) {m_id_card_forcibly = sp.ReadBoolean();}
            if (sp.TryRead(9)) {m_monthly_pay_price = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_online_dur);}
            if (sp.TryWrite(1)) {sp.Write(m_id_card);}
            if (sp.TryWrite(2)) {sp.Write(m_card_name);}
            if (sp.TryWrite(3)) {sp.Write(m_young);}
            if (sp.TryWrite(4)) {sp.Write(m_verify_interval);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rules.Count);
                for (int i = 0; i != m_rules.Count; ++i) {
                    m_rules[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_verify_rewards.Count);
                for (int i = 0; i != m_verify_rewards.Count; ++i) {
                    m_verify_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_phone_number);}
            if (sp.TryWrite(8)) {sp.Write(m_id_card_forcibly);}
            if (sp.TryWrite(9)) {sp.Write(m_monthly_pay_price);}
            sp.EnEnd();
        }
        public void CopyFrom(AntiAdictionInfo source) {
            m_online_dur = source.m_online_dur;
            m_id_card = source.m_id_card;
            m_card_name = source.m_card_name;
            m_young = source.m_young;
            m_verify_interval = source.m_verify_interval;
            m_rules = source.m_rules;
            m_verify_rewards = source.m_verify_rewards;
            m_phone_number = source.m_phone_number;
            m_id_card_forcibly = source.m_id_card_forcibly;
            m_monthly_pay_price = source.m_monthly_pay_price;
        }
    }
    
    [Serializable]
    public partial class LinkPhoneNumberReqInfo : NetworkMessage {
        public static int[] Id = { 638,1 };
        public static Ctrl VC;
        public String m_phone_number = "";
        public String m_area = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_phone_number = sp.ReadString();}
            if (sp.TryRead(1)) {m_area = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_phone_number);}
            if (sp.TryWrite(1)) {sp.Write(m_area);}
            sp.EnEnd();
        }
        public void CopyFrom(LinkPhoneNumberReqInfo source) {
            m_phone_number = source.m_phone_number;
            m_area = source.m_area;
        }
    }
    
    [Serializable]
    public partial class SpecialRewardsDetail : NetworkMessage {
        public static int[] Id = { 644,1 };
        public static Ctrl VC;
        public List<SpecialGrowRebelReward> m_rewards = new List<SpecialGrowRebelReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SpecialGrowRebelReward tmp = new SpecialGrowRebelReward();
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
        public void CopyFrom(SpecialRewardsDetail source) {
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class NewbieTriggerAllInfo : NetworkMessage {
        public static int[] Id = { 650,1 };
        public static Ctrl VC;
        public List<NewbieTriggerInfo> m_list = new List<NewbieTriggerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NewbieTriggerInfo tmp = new NewbieTriggerInfo();
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
        public void CopyFrom(NewbieTriggerAllInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedAll : NetworkMessage {
        public static int[] Id = { 656,1 };
        public static Ctrl VC;
        public ZvzUnitedGroupList m_groups;
        public ZvzUnitedKnockoutList m_knockouts;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_groups = new ZvzUnitedGroupList();
                m_groups.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_knockouts = new ZvzUnitedKnockoutList();
                m_knockouts.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_groups.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_knockouts.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedAll source) {
            m_groups = source.m_groups;
            m_knockouts = source.m_knockouts;
        }
    }
    
    [Serializable]
    public partial class CaptchaAckInfo : NetworkMessage {
        public static int[] Id = { 662,1 };
        public static Ctrl VC;
        public Int16 m_code;
        public String m_captcha_type = "";
        public List<Int32> m_captcha_list = new List<Int32>();
        public Int64 m_active_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_captcha_type = sp.ReadString();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_captcha_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_captcha_list.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {m_active_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {sp.Write(m_captcha_type);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_captcha_list.Count);
                for (int i = 0; i != m_captcha_list.Count; ++i) {
                    sp.Write(m_captcha_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {sp.Write(m_active_time);}
            sp.EnEnd();
        }
        public void CopyFrom(CaptchaAckInfo source) {
            m_code = source.m_code;
            m_captcha_type = source.m_captcha_type;
            m_captcha_list = source.m_captcha_list;
            m_active_time = source.m_active_time;
        }
    }
    
    [Serializable]
    public partial class FileUploadAckInfo : NetworkMessage {
        public static int[] Id = { 668,1 };
        public static Ctrl VC;
        public Int16 m_err_code;
        public String m_payload = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_err_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_payload = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_err_code);}
            if (sp.TryWrite(1)) {sp.Write(m_payload);}
            sp.EnEnd();
        }
        public void CopyFrom(FileUploadAckInfo source) {
            m_err_code = source.m_err_code;
            m_payload = source.m_payload;
        }
    }
    
    [Serializable]
    public partial class ScrollEquipLevelUp : NetworkMessage {
        public static int[] Id = { 674,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int32 m_equip_id;
        public Int16 m_equip_type;
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
            if (sp.TryRead(4)) {m_equip_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_equip_type = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_level = sp.ReadInt16();}
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
            if (sp.TryWrite(6)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollEquipLevelUp source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_equip_id = source.m_equip_id;
            m_equip_type = source.m_equip_type;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class EventCalendarReqInfo : NetworkMessage {
        public static int[] Id = { 680,1 };
        public static Ctrl VC;
        public SByte m_event_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_type);}
            sp.EnEnd();
        }
        public void CopyFrom(EventCalendarReqInfo source) {
            m_event_type = source.m_event_type;
        }
    }
    
    [Serializable]
    public partial class ComeBackRoleLimitInfo : NetworkMessage {
        public static int[] Id = { 686,1 };
        public static Ctrl VC;
        public Boolean m_switch;
        public Int32 m_over_day_limit;
        public Int32 m_hq_limit;
        public Int32 m_vip_limit;
        public Int32 m_bind_roles_limit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_switch = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_over_day_limit = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_hq_limit = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_vip_limit = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_bind_roles_limit = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_switch);}
            if (sp.TryWrite(1)) {sp.Write(m_over_day_limit);}
            if (sp.TryWrite(2)) {sp.Write(m_hq_limit);}
            if (sp.TryWrite(3)) {sp.Write(m_vip_limit);}
            if (sp.TryWrite(4)) {sp.Write(m_bind_roles_limit);}
            sp.EnEnd();
        }
        public void CopyFrom(ComeBackRoleLimitInfo source) {
            m_switch = source.m_switch;
            m_over_day_limit = source.m_over_day_limit;
            m_hq_limit = source.m_hq_limit;
            m_vip_limit = source.m_vip_limit;
            m_bind_roles_limit = source.m_bind_roles_limit;
        }
    }
    
    [Serializable]
    public partial class FpsSweepCntInfo : NetworkMessage {
        public static int[] Id = { 692,1 };
        public static Ctrl VC;
        public Int16 m_fps_level;
        public Int16 m_sweep_cnt;
        public Int16 m_remain_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_fps_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_sweep_cnt = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_remain_cnt = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_fps_level);}
            if (sp.TryWrite(1)) {sp.Write(m_sweep_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_remain_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSweepCntInfo source) {
            m_fps_level = source.m_fps_level;
            m_sweep_cnt = source.m_sweep_cnt;
            m_remain_cnt = source.m_remain_cnt;
        }
    }
    
    [Serializable]
    public partial class FpsEquipmentInfo : NetworkMessage {
        public static int[] Id = { 698,1 };
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
        public void CopyFrom(FpsEquipmentInfo source) {
            m_agent_id = source.m_agent_id;
            m_equipment_id = source.m_equipment_id;
        }
    }
    
    [Serializable]
    public partial class ResListAckInfo : NetworkMessage {
        public static int[] Id = { 704,1 };
        public static Ctrl VC;
        public Int16 m_level;
        public SByte m_tile_type;
        public List<TilePos> m_tiles = new List<TilePos>();
        public Int64 m_march_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_tile_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tiles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_tiles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_march_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_tile_type);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tiles.Count);
                for (int i = 0; i != m_tiles.Count; ++i) {
                    m_tiles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_march_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ResListAckInfo source) {
            m_level = source.m_level;
            m_tile_type = source.m_tile_type;
            m_tiles = source.m_tiles;
            m_march_id = source.m_march_id;
        }
    }
    
    [Serializable]
    public partial class FpsTracking : NetworkMessage {
        public static int[] Id = { 710,1 };
        public static Ctrl VC;
        public Int64 m_event_id;
        public Int32 m_fps_level_id;
        public Int16 m_level_result;
        public Int16 m_agent_id;
        public Int32 m_agent_rank;
        public Int16 m_weapon_id;
        public Int64 m_level_duration;
        public Int32 m_fire_times;
        public Int32 m_hit_times;
        public Int32 m_kill_times;
        public Int32 m_hit_head_times;
        public Int32 m_headshot_times;
        public Int64 m_remaining_hp;
        public Int32 m_reload_times;
        public Int32 m_button_reload_times;
        public Int32 m_button_zoomout_times;
        public Int32 m_button_pause_times;
        public List<Int64> m_loot_info = new List<Int64>();
        public Int64 m_client_time;
        public Int64 m_exp_info;
        public Int64 m_challenge_score;
        public Int64 m_hit_sniper_times;
        public Int64 m_kill_sniper_times;
        public Int64 m_headshot_sniper_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_fps_level_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_level_result = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_agent_rank = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_weapon_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_level_duration = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_fire_times = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_hit_times = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_kill_times = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_hit_head_times = sp.ReadInt32();}
            if (sp.TryRead(11)) {m_headshot_times = sp.ReadInt32();}
            if (sp.TryRead(12)) {m_remaining_hp = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_reload_times = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_button_reload_times = sp.ReadInt32();}
            if (sp.TryRead(15)) {m_button_zoomout_times = sp.ReadInt32();}
            if (sp.TryRead(16)) {m_button_pause_times = sp.ReadInt32();}
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_loot_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_loot_info.Add(tmp);
                }
            }
            if (sp.TryRead(18)) {m_client_time = sp.ReadInt64();}
            if (sp.TryRead(19)) {m_exp_info = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_challenge_score = sp.ReadInt64();}
            if (sp.TryRead(21)) {m_hit_sniper_times = sp.ReadInt64();}
            if (sp.TryRead(22)) {m_kill_sniper_times = sp.ReadInt64();}
            if (sp.TryRead(23)) {m_headshot_sniper_times = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_event_id);}
            if (sp.TryWrite(1)) {sp.Write(m_fps_level_id);}
            if (sp.TryWrite(2)) {sp.Write(m_level_result);}
            if (sp.TryWrite(3)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(4)) {sp.Write(m_agent_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_weapon_id);}
            if (sp.TryWrite(6)) {sp.Write(m_level_duration);}
            if (sp.TryWrite(7)) {sp.Write(m_fire_times);}
            if (sp.TryWrite(8)) {sp.Write(m_hit_times);}
            if (sp.TryWrite(9)) {sp.Write(m_kill_times);}
            if (sp.TryWrite(10)) {sp.Write(m_hit_head_times);}
            if (sp.TryWrite(11)) {sp.Write(m_headshot_times);}
            if (sp.TryWrite(12)) {sp.Write(m_remaining_hp);}
            if (sp.TryWrite(13)) {sp.Write(m_reload_times);}
            if (sp.TryWrite(14)) {sp.Write(m_button_reload_times);}
            if (sp.TryWrite(15)) {sp.Write(m_button_zoomout_times);}
            if (sp.TryWrite(16)) {sp.Write(m_button_pause_times);}
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_loot_info.Count);
                for (int i = 0; i != m_loot_info.Count; ++i) {
                    sp.Write(m_loot_info[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(18)) {sp.Write(m_client_time);}
            if (sp.TryWrite(19)) {sp.Write(m_exp_info);}
            if (sp.TryWrite(20)) {sp.Write(m_challenge_score);}
            if (sp.TryWrite(21)) {sp.Write(m_hit_sniper_times);}
            if (sp.TryWrite(22)) {sp.Write(m_kill_sniper_times);}
            if (sp.TryWrite(23)) {sp.Write(m_headshot_sniper_times);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsTracking source) {
            m_event_id = source.m_event_id;
            m_fps_level_id = source.m_fps_level_id;
            m_level_result = source.m_level_result;
            m_agent_id = source.m_agent_id;
            m_agent_rank = source.m_agent_rank;
            m_weapon_id = source.m_weapon_id;
            m_level_duration = source.m_level_duration;
            m_fire_times = source.m_fire_times;
            m_hit_times = source.m_hit_times;
            m_kill_times = source.m_kill_times;
            m_hit_head_times = source.m_hit_head_times;
            m_headshot_times = source.m_headshot_times;
            m_remaining_hp = source.m_remaining_hp;
            m_reload_times = source.m_reload_times;
            m_button_reload_times = source.m_button_reload_times;
            m_button_zoomout_times = source.m_button_zoomout_times;
            m_button_pause_times = source.m_button_pause_times;
            m_loot_info = source.m_loot_info;
            m_client_time = source.m_client_time;
            m_exp_info = source.m_exp_info;
            m_challenge_score = source.m_challenge_score;
            m_hit_sniper_times = source.m_hit_sniper_times;
            m_kill_sniper_times = source.m_kill_sniper_times;
            m_headshot_sniper_times = source.m_headshot_sniper_times;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelEndAckInfo : NetworkMessage {
        public static int[] Id = { 716,1 };
        public static Ctrl VC;
        public Boolean m_win;
        public Int16 m_level_id;
        public Int32 m_score;
        public List<Int32> m_score_list = new List<Int32>();
        public FpsRewardInfo m_reward_info;

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
                m_reward_info = new FpsRewardInfo();
                m_reward_info.Decode(sp);
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
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_reward_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsSpecialLevelEndAckInfo source) {
            m_win = source.m_win;
            m_level_id = source.m_level_id;
            m_score = source.m_score;
            m_score_list = source.m_score_list;
            m_reward_info = source.m_reward_info;
        }
    }
    
    [Serializable]
    public partial class BaseCampaignInfo : NetworkMessage {
        public static int[] Id = { 722,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_title = "";
        public String m_desc = "";
        public String m_rule = "";
        public String m_icon_title = "";
        public String m_icon_url = "";
        public String m_banner_url = "";
        public Int16 m_state;
        public Int64 m_begin_time;
        public Int64 m_end_time;
        public List<ItemInfo> m_rewards_review = new List<ItemInfo>();
        public String m_button_name = "";
        public String m_button_jump = "";
        public String m_ui_control = "";
        public List<ItemInfo> m_calendar_review = new List<ItemInfo>();
        public Boolean m_ranked;
        public List<RankUnitInfo> m_rank_info_list = new List<RankUnitInfo>();
        public Boolean m_daily_reset;
        public Int32 m_sort_weight;
        public String m_rank_review = "";
        public String m_pop_up_url = "";
        public BaseCampaignCond m_cond;
        public String m_temp_id = "";
        public Int16 m_activity_type;
        public String m_short_desc = "";
        public Int16 m_sub_type;
        public String m_lnk_icon_url = "";
        public List<Int16> m_server_ids = new List<Int16>();
        public Int64 m_close_time;
        public List<String> m_s_jump = new List<String>();
        public List<String> m_s_text = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_desc = sp.ReadString();}
            if (sp.TryRead(3)) {m_rule = sp.ReadString();}
            if (sp.TryRead(4)) {m_icon_title = sp.ReadString();}
            if (sp.TryRead(5)) {m_icon_url = sp.ReadString();}
            if (sp.TryRead(6)) {m_banner_url = sp.ReadString();}
            if (sp.TryRead(7)) {m_state = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards_review.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards_review.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_button_name = sp.ReadString();}
            if (sp.TryRead(12)) {m_button_jump = sp.ReadString();}
            if (sp.TryRead(13)) {m_ui_control = sp.ReadString();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_calendar_review.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_calendar_review.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_ranked = sp.ReadBoolean();}
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RankUnitInfo tmp = new RankUnitInfo();
                    tmp.Decode(sp);
                    m_rank_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_daily_reset = sp.ReadBoolean();}
            if (sp.TryRead(18)) {m_sort_weight = sp.ReadInt32();}
            if (sp.TryRead(19)) {m_rank_review = sp.ReadString();}
            if (sp.TryRead(20)) {m_pop_up_url = sp.ReadString();}
            if (sp.TryRead(21)) {
                m_cond = new BaseCampaignCond();
                m_cond.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(22)) {m_temp_id = sp.ReadString();}
            if (sp.TryRead(23)) {m_activity_type = sp.ReadInt16();}
            if (sp.TryRead(24)) {m_short_desc = sp.ReadString();}
            if (sp.TryRead(25)) {m_sub_type = sp.ReadInt16();}
            if (sp.TryRead(26)) {m_lnk_icon_url = sp.ReadString();}
            if (sp.TryRead(27)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_server_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_server_ids.Add(tmp);
                }
            }
            if (sp.TryRead(28)) {m_close_time = sp.ReadInt64();}
            if (sp.TryRead(29)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_s_jump.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_s_jump.Add(tmp);
                }
            }
            if (sp.TryRead(30)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_s_text.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_s_text.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_desc);}
            if (sp.TryWrite(3)) {sp.Write(m_rule);}
            if (sp.TryWrite(4)) {sp.Write(m_icon_title);}
            if (sp.TryWrite(5)) {sp.Write(m_icon_url);}
            if (sp.TryWrite(6)) {sp.Write(m_banner_url);}
            if (sp.TryWrite(7)) {sp.Write(m_state);}
            if (sp.TryWrite(8)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(9)) {sp.Write(m_end_time);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards_review.Count);
                for (int i = 0; i != m_rewards_review.Count; ++i) {
                    m_rewards_review[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_button_name);}
            if (sp.TryWrite(12)) {sp.Write(m_button_jump);}
            if (sp.TryWrite(13)) {sp.Write(m_ui_control);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_calendar_review.Count);
                for (int i = 0; i != m_calendar_review.Count; ++i) {
                    m_calendar_review[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_ranked);}
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info_list.Count);
                for (int i = 0; i != m_rank_info_list.Count; ++i) {
                    m_rank_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(17)) {sp.Write(m_daily_reset);}
            if (sp.TryWrite(18)) {sp.Write(m_sort_weight);}
            if (sp.TryWrite(19)) {sp.Write(m_rank_review);}
            if (sp.TryWrite(20)) {sp.Write(m_pop_up_url);}
            if (sp.TryWrite(21)) {int pos = sp.GetPos();sp.Skip(2); m_cond.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(22)) {sp.Write(m_temp_id);}
            if (sp.TryWrite(23)) {sp.Write(m_activity_type);}
            if (sp.TryWrite(24)) {sp.Write(m_short_desc);}
            if (sp.TryWrite(25)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(26)) {sp.Write(m_lnk_icon_url);}
            if (sp.TryWrite(27)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_server_ids.Count);
                for (int i = 0; i != m_server_ids.Count; ++i) {
                    sp.Write(m_server_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(28)) {sp.Write(m_close_time);}
            if (sp.TryWrite(29)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_s_jump.Count);
                for (int i = 0; i != m_s_jump.Count; ++i) {
                    sp.Write(m_s_jump[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(30)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_s_text.Count);
                for (int i = 0; i != m_s_text.Count; ++i) {
                    sp.Write(m_s_text[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BaseCampaignInfo source) {
            m_id = source.m_id;
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_rule = source.m_rule;
            m_icon_title = source.m_icon_title;
            m_icon_url = source.m_icon_url;
            m_banner_url = source.m_banner_url;
            m_state = source.m_state;
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
            m_rewards_review = source.m_rewards_review;
            m_button_name = source.m_button_name;
            m_button_jump = source.m_button_jump;
            m_ui_control = source.m_ui_control;
            m_calendar_review = source.m_calendar_review;
            m_ranked = source.m_ranked;
            m_rank_info_list = source.m_rank_info_list;
            m_daily_reset = source.m_daily_reset;
            m_sort_weight = source.m_sort_weight;
            m_rank_review = source.m_rank_review;
            m_pop_up_url = source.m_pop_up_url;
            m_cond = source.m_cond;
            m_temp_id = source.m_temp_id;
            m_activity_type = source.m_activity_type;
            m_short_desc = source.m_short_desc;
            m_sub_type = source.m_sub_type;
            m_lnk_icon_url = source.m_lnk_icon_url;
            m_server_ids = source.m_server_ids;
            m_close_time = source.m_close_time;
            m_s_jump = source.m_s_jump;
            m_s_text = source.m_s_text;
        }
    }
    
    [Serializable]
    public partial class DropCampaignRuleInfo : NetworkMessage {
        public static int[] Id = { 728,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_task_icon = "";
        public String m_task_title = "";
        public String m_task_desc = "";
        public String m_task_jump = "";
        public Int32 m_daily_limit;
        public Int32 m_total_limit;
        public ItemInfo m_drop_item;
        public Int32 m_daily_got;
        public Int32 m_total_got;
        public String m_task_bg = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_task_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_task_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_task_desc = sp.ReadString();}
            if (sp.TryRead(4)) {m_task_jump = sp.ReadString();}
            if (sp.TryRead(5)) {m_daily_limit = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_total_limit = sp.ReadInt32();}
            if (sp.TryRead(7)) {
                m_drop_item = new ItemInfo();
                m_drop_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_daily_got = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_total_got = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_task_bg = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_task_title);}
            if (sp.TryWrite(3)) {sp.Write(m_task_desc);}
            if (sp.TryWrite(4)) {sp.Write(m_task_jump);}
            if (sp.TryWrite(5)) {sp.Write(m_daily_limit);}
            if (sp.TryWrite(6)) {sp.Write(m_total_limit);}
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_drop_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_daily_got);}
            if (sp.TryWrite(9)) {sp.Write(m_total_got);}
            if (sp.TryWrite(10)) {sp.Write(m_task_bg);}
            sp.EnEnd();
        }
        public void CopyFrom(DropCampaignRuleInfo source) {
            m_id = source.m_id;
            m_task_icon = source.m_task_icon;
            m_task_title = source.m_task_title;
            m_task_desc = source.m_task_desc;
            m_task_jump = source.m_task_jump;
            m_daily_limit = source.m_daily_limit;
            m_total_limit = source.m_total_limit;
            m_drop_item = source.m_drop_item;
            m_daily_got = source.m_daily_got;
            m_total_got = source.m_total_got;
            m_task_bg = source.m_task_bg;
        }
    }
    
    [Serializable]
    public partial class RankCampaignRankRewardInfo : NetworkMessage {
        public static int[] Id = { 734,1 };
        public static Ctrl VC;
        public Int32 m_min;
        public Int32 m_max;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_min = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_max = sp.ReadInt32();}
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
            if (sp.TryWrite(0)) {sp.Write(m_min);}
            if (sp.TryWrite(1)) {sp.Write(m_max);}
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
        public void CopyFrom(RankCampaignRankRewardInfo source) {
            m_min = source.m_min;
            m_max = source.m_max;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class InstantBuyItemInfo : NetworkMessage {
        public static int[] Id = { 740,1 };
        public static Ctrl VC;
        public String m_name = "";
        public List<Int32> m_items = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_items.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    sp.Write(m_items[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(InstantBuyItemInfo source) {
            m_name = source.m_name;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class ResizeableLandInfo : NetworkMessage {
        public static int[] Id = { 746,1 };
        public static Ctrl VC;
        public Int16 m_color;
        public List<TilePos> m_tiles = new List<TilePos>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_color = sp.ReadInt16();}
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
            if (sp.TryWrite(0)) {sp.Write(m_color);}
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
        public void CopyFrom(ResizeableLandInfo source) {
            m_color = source.m_color;
            m_tiles = source.m_tiles;
        }
    }
    
    [Serializable]
    public partial class SevendayFinalRewardId : NetworkMessage {
        public static int[] Id = { 752,1 };
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
        public void CopyFrom(SevendayFinalRewardId source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class DailySignRewardItem : NetworkMessage {
        public static int[] Id = { 758,1 };
        public static Ctrl VC;
        public Int32 m_day;
        public Int32 m_item_id;
        public Int32 m_item_cnt;
        public Boolean m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_day = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_status = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_day);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(DailySignRewardItem source) {
            m_day = source.m_day;
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class AvatarFrameId : NetworkMessage {
        public static int[] Id = { 764,1 };
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
        public void CopyFrom(AvatarFrameId source) {
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class CurrentUserIconNtfInfo : NetworkMessage {
        public static int[] Id = { 770,1 };
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
        public void CopyFrom(CurrentUserIconNtfInfo source) {
            m_icon_id = source.m_icon_id;
        }
    }
    
    [Serializable]
    public partial class UserSurveyInfo : NetworkMessage {
        public static int[] Id = { 776,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_title = "";
        public Int16 m_level;
        public String m_token = "";
        public Int64 m_start_time;
        public Int64 m_end_time;
        public SByte m_status;
        public SByte m_open_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_token = sp.ReadString();}
            if (sp.TryRead(4)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_open_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_token);}
            if (sp.TryWrite(4)) {sp.Write(m_start_time);}
            if (sp.TryWrite(5)) {sp.Write(m_end_time);}
            if (sp.TryWrite(6)) {sp.Write(m_status);}
            if (sp.TryWrite(7)) {sp.Write(m_open_type);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSurveyInfo source) {
            m_id = source.m_id;
            m_title = source.m_title;
            m_level = source.m_level;
            m_token = source.m_token;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_status = source.m_status;
            m_open_type = source.m_open_type;
        }
    }
    
    [Serializable]
    public partial class MapBuildingInfo : NetworkMessage {
        public static int[] Id = { 782,1 };
        public static Ctrl VC;
        public Int16 m_behaviour;
        public List<ResTile> m_res_list = new List<ResTile>();
        public List<FortTile> m_fort_list = new List<FortTile>();
        public List<CityTile> m_city_list = new List<CityTile>();
        public List<BigRebelTile> m_big_rebel_list = new List<BigRebelTile>();
        public List<NewAllianceBuildingTile> m_alliance_building_list = new List<NewAllianceBuildingTile>();
        public List<LanderTile> m_lander_list = new List<LanderTile>();
        public List<MonumentTile> m_monument_list = new List<MonumentTile>();
        public List<RebelBaseTile> m_as_rebel_base_list = new List<RebelBaseTile>();
        public List<GuideRebelTile> m_guide_rebel_list = new List<GuideRebelTile>();
        public List<CommonBuildingTile> m_common_building_info = new List<CommonBuildingTile>();
        public List<TinyMonumentTile> m_tiny_monument_list = new List<TinyMonumentTile>();
        public List<BuffBaseTile> m_buff_base_list = new List<BuffBaseTile>();
        public Int64 m_map_guid;
        public List<GvgBuildingTile> m_gvg_building_list = new List<GvgBuildingTile>();
        public List<MuseumTile> m_museum_tile_list = new List<MuseumTile>();
        public List<GoodsBaseTile> m_goods_base_tile_list = new List<GoodsBaseTile>();
        public List<DepotTile> m_depot_tile_list = new List<DepotTile>();
        public Int16 m_level;
        public List<KvkLabLoot> m_kvk_lab_loot_list = new List<KvkLabLoot>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_behaviour = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTile tmp = new ResTile();
                    tmp.Decode(sp);
                    m_res_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fort_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FortTile tmp = new FortTile();
                    tmp.Decode(sp);
                    m_fort_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_city_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CityTile tmp = new CityTile();
                    tmp.Decode(sp);
                    m_city_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_big_rebel_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BigRebelTile tmp = new BigRebelTile();
                    tmp.Decode(sp);
                    m_big_rebel_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_building_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NewAllianceBuildingTile tmp = new NewAllianceBuildingTile();
                    tmp.Decode(sp);
                    m_alliance_building_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_lander_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LanderTile tmp = new LanderTile();
                    tmp.Decode(sp);
                    m_lander_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_monument_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MonumentTile tmp = new MonumentTile();
                    tmp.Decode(sp);
                    m_monument_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_as_rebel_base_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RebelBaseTile tmp = new RebelBaseTile();
                    tmp.Decode(sp);
                    m_as_rebel_base_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_guide_rebel_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GuideRebelTile tmp = new GuideRebelTile();
                    tmp.Decode(sp);
                    m_guide_rebel_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_common_building_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CommonBuildingTile tmp = new CommonBuildingTile();
                    tmp.Decode(sp);
                    m_common_building_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tiny_monument_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TinyMonumentTile tmp = new TinyMonumentTile();
                    tmp.Decode(sp);
                    m_tiny_monument_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buff_base_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffBaseTile tmp = new BuffBaseTile();
                    tmp.Decode(sp);
                    m_buff_base_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_gvg_building_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgBuildingTile tmp = new GvgBuildingTile();
                    tmp.Decode(sp);
                    m_gvg_building_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_museum_tile_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MuseumTile tmp = new MuseumTile();
                    tmp.Decode(sp);
                    m_museum_tile_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_goods_base_tile_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GoodsBaseTile tmp = new GoodsBaseTile();
                    tmp.Decode(sp);
                    m_goods_base_tile_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_depot_tile_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DepotTile tmp = new DepotTile();
                    tmp.Decode(sp);
                    m_depot_tile_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(18)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(19)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_kvk_lab_loot_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkLabLoot tmp = new KvkLabLoot();
                    tmp.Decode(sp);
                    m_kvk_lab_loot_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_behaviour);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_list.Count);
                for (int i = 0; i != m_res_list.Count; ++i) {
                    m_res_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fort_list.Count);
                for (int i = 0; i != m_fort_list.Count; ++i) {
                    m_fort_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_city_list.Count);
                for (int i = 0; i != m_city_list.Count; ++i) {
                    m_city_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_big_rebel_list.Count);
                for (int i = 0; i != m_big_rebel_list.Count; ++i) {
                    m_big_rebel_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_building_list.Count);
                for (int i = 0; i != m_alliance_building_list.Count; ++i) {
                    m_alliance_building_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_lander_list.Count);
                for (int i = 0; i != m_lander_list.Count; ++i) {
                    m_lander_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_monument_list.Count);
                for (int i = 0; i != m_monument_list.Count; ++i) {
                    m_monument_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_as_rebel_base_list.Count);
                for (int i = 0; i != m_as_rebel_base_list.Count; ++i) {
                    m_as_rebel_base_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_guide_rebel_list.Count);
                for (int i = 0; i != m_guide_rebel_list.Count; ++i) {
                    m_guide_rebel_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_common_building_info.Count);
                for (int i = 0; i != m_common_building_info.Count; ++i) {
                    m_common_building_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tiny_monument_list.Count);
                for (int i = 0; i != m_tiny_monument_list.Count; ++i) {
                    m_tiny_monument_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_base_list.Count);
                for (int i = 0; i != m_buff_base_list.Count; ++i) {
                    m_buff_base_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_gvg_building_list.Count);
                for (int i = 0; i != m_gvg_building_list.Count; ++i) {
                    m_gvg_building_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_museum_tile_list.Count);
                for (int i = 0; i != m_museum_tile_list.Count; ++i) {
                    m_museum_tile_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(16)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_goods_base_tile_list.Count);
                for (int i = 0; i != m_goods_base_tile_list.Count; ++i) {
                    m_goods_base_tile_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_depot_tile_list.Count);
                for (int i = 0; i != m_depot_tile_list.Count; ++i) {
                    m_depot_tile_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(18)) {sp.Write(m_level);}
            if (sp.TryWrite(19)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_kvk_lab_loot_list.Count);
                for (int i = 0; i != m_kvk_lab_loot_list.Count; ++i) {
                    m_kvk_lab_loot_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MapBuildingInfo source) {
            m_behaviour = source.m_behaviour;
            m_res_list = source.m_res_list;
            m_fort_list = source.m_fort_list;
            m_city_list = source.m_city_list;
            m_big_rebel_list = source.m_big_rebel_list;
            m_alliance_building_list = source.m_alliance_building_list;
            m_lander_list = source.m_lander_list;
            m_monument_list = source.m_monument_list;
            m_as_rebel_base_list = source.m_as_rebel_base_list;
            m_guide_rebel_list = source.m_guide_rebel_list;
            m_common_building_info = source.m_common_building_info;
            m_tiny_monument_list = source.m_tiny_monument_list;
            m_buff_base_list = source.m_buff_base_list;
            m_map_guid = source.m_map_guid;
            m_gvg_building_list = source.m_gvg_building_list;
            m_museum_tile_list = source.m_museum_tile_list;
            m_goods_base_tile_list = source.m_goods_base_tile_list;
            m_depot_tile_list = source.m_depot_tile_list;
            m_level = source.m_level;
            m_kvk_lab_loot_list = source.m_kvk_lab_loot_list;
        }
    }
    
    [Serializable]
    public partial class MarchInfo : NetworkMessage {
        public static int[] Id = { 788,1 };
        public static Ctrl VC;
        public Int64 m_march_id;
        public Int64 m_owner;
        public Int16 m_icon;
        public String m_name = "";
        public MapUnitId m_target;
        public MapUnitId m_source;
        public Int16 m_march_type;
        public Int16 m_subtype;
        public Int32 m_speed;
        public UserAllianceBrief m_alliance;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public String m_avatar = "";
        public Int32 m_model;
        public List<GroupAgentInfo> m_agents = new List<GroupAgentInfo>();
        public List<RealPos> m_path = new List<RealPos>();
        public RealPos m_pos;
        public Int64 m_start_time;
        public Int64 m_capacity;
        public Boolean m_is_rally;
        public List<CreepInfo> m_creep_data = new List<CreepInfo>();
        public Int32 m_target_as;
        public Int16 m_state;
        public List<TroopGroup> m_group_list = new List<TroopGroup>();
        public Int64 m_room_id;
        public Int16 m_faction;
        public Int16 m_energy_decay;
        public Int16 m_current_decay_index;
        public Int16 m_max_decay_count;
        public Int64 m_map_guid;
        public List<GoodsInfo> m_goods_list = new List<GoodsInfo>();
        public Int16 m_avatar_frame;
        public Int16 m_home_server_id;
        public Int16 m_warship_id;
        public Int16 m_warship_skill_level;
        public Int32 m_warship_level;
        public Int16 m_speed_down;
        public Int16 m_army_banner_id;
        public List<Int32> m_aura_ids = new List<Int32>();
        public List<Int32> m_effect_old_troop_model = new List<Int32>();
        public List<Int32> m_effect_new_troop_model = new List<Int32>();
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_name = sp.ReadString();}
            if (sp.TryRead(4)) {
                m_target = new MapUnitId();
                m_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_source = new MapUnitId();
                m_source.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_march_type = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_speed = sp.ReadInt32();}
            if (sp.TryRead(9)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(12)) {m_model = sp.ReadInt32();}
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GroupAgentInfo tmp = new GroupAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_path.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RealPos tmp = new RealPos();
                    tmp.Decode(sp);
                    m_path.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {
                m_pos = new RealPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(16)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_capacity = sp.ReadInt64();}
            if (sp.TryRead(18)) {m_is_rally = sp.ReadBoolean();}
            if (sp.TryRead(19)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_creep_data.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CreepInfo tmp = new CreepInfo();
                    tmp.Decode(sp);
                    m_creep_data.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(20)) {m_target_as = sp.ReadInt32();}
            if (sp.TryRead(21)) {m_state = sp.ReadInt16();}
            if (sp.TryRead(22)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_group_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_group_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(23)) {m_room_id = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_faction = sp.ReadInt16();}
            if (sp.TryRead(25)) {m_energy_decay = sp.ReadInt16();}
            if (sp.TryRead(26)) {m_current_decay_index = sp.ReadInt16();}
            if (sp.TryRead(27)) {m_max_decay_count = sp.ReadInt16();}
            if (sp.TryRead(28)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(29)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_goods_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GoodsInfo tmp = new GoodsInfo();
                    tmp.Decode(sp);
                    m_goods_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(30)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(31)) {m_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(32)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(33)) {m_warship_skill_level = sp.ReadInt16();}
            if (sp.TryRead(34)) {m_warship_level = sp.ReadInt32();}
            if (sp.TryRead(35)) {m_speed_down = sp.ReadInt16();}
            if (sp.TryRead(36)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(37)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            if (sp.TryRead(38)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_effect_old_troop_model.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_effect_old_troop_model.Add(tmp);
                }
            }
            if (sp.TryRead(39)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_effect_new_troop_model.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_effect_new_troop_model.Add(tmp);
                }
            }
            if (sp.TryRead(40)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(41)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_march_id);}
            if (sp.TryWrite(1)) {sp.Write(m_owner);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_name);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_source.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_march_type);}
            if (sp.TryWrite(7)) {sp.Write(m_subtype);}
            if (sp.TryWrite(8)) {sp.Write(m_speed);}
            if (sp.TryWrite(9)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_avatar);}
            if (sp.TryWrite(12)) {sp.Write(m_model);}
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agents.Count);
                for (int i = 0; i != m_agents.Count; ++i) {
                    m_agents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_path.Count);
                for (int i = 0; i != m_path.Count; ++i) {
                    m_path[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(16)) {sp.Write(m_start_time);}
            if (sp.TryWrite(17)) {sp.Write(m_capacity);}
            if (sp.TryWrite(18)) {sp.Write(m_is_rally);}
            if (sp.TryWrite(19)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_creep_data.Count);
                for (int i = 0; i != m_creep_data.Count; ++i) {
                    m_creep_data[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(20)) {sp.Write(m_target_as);}
            if (sp.TryWrite(21)) {sp.Write(m_state);}
            if (sp.TryWrite(22)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_group_list.Count);
                for (int i = 0; i != m_group_list.Count; ++i) {
                    m_group_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(23)) {sp.Write(m_room_id);}
            if (sp.TryWrite(24)) {sp.Write(m_faction);}
            if (sp.TryWrite(25)) {sp.Write(m_energy_decay);}
            if (sp.TryWrite(26)) {sp.Write(m_current_decay_index);}
            if (sp.TryWrite(27)) {sp.Write(m_max_decay_count);}
            if (sp.TryWrite(28)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(29)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_goods_list.Count);
                for (int i = 0; i != m_goods_list.Count; ++i) {
                    m_goods_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(30)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(31)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(32)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(33)) {sp.Write(m_warship_skill_level);}
            if (sp.TryWrite(34)) {sp.Write(m_warship_level);}
            if (sp.TryWrite(35)) {sp.Write(m_speed_down);}
            if (sp.TryWrite(36)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(37)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(38)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_effect_old_troop_model.Count);
                for (int i = 0; i != m_effect_old_troop_model.Count; ++i) {
                    sp.Write(m_effect_old_troop_model[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(39)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_effect_new_troop_model.Count);
                for (int i = 0; i != m_effect_new_troop_model.Count; ++i) {
                    sp.Write(m_effect_new_troop_model[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(40)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(41)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MarchInfo source) {
            m_march_id = source.m_march_id;
            m_owner = source.m_owner;
            m_icon = source.m_icon;
            m_name = source.m_name;
            m_target = source.m_target;
            m_source = source.m_source;
            m_march_type = source.m_march_type;
            m_subtype = source.m_subtype;
            m_speed = source.m_speed;
            m_alliance = source.m_alliance;
            m_troops = source.m_troops;
            m_avatar = source.m_avatar;
            m_model = source.m_model;
            m_agents = source.m_agents;
            m_path = source.m_path;
            m_pos = source.m_pos;
            m_start_time = source.m_start_time;
            m_capacity = source.m_capacity;
            m_is_rally = source.m_is_rally;
            m_creep_data = source.m_creep_data;
            m_target_as = source.m_target_as;
            m_state = source.m_state;
            m_group_list = source.m_group_list;
            m_room_id = source.m_room_id;
            m_faction = source.m_faction;
            m_energy_decay = source.m_energy_decay;
            m_current_decay_index = source.m_current_decay_index;
            m_max_decay_count = source.m_max_decay_count;
            m_map_guid = source.m_map_guid;
            m_goods_list = source.m_goods_list;
            m_avatar_frame = source.m_avatar_frame;
            m_home_server_id = source.m_home_server_id;
            m_warship_id = source.m_warship_id;
            m_warship_skill_level = source.m_warship_skill_level;
            m_warship_level = source.m_warship_level;
            m_speed_down = source.m_speed_down;
            m_army_banner_id = source.m_army_banner_id;
            m_aura_ids = source.m_aura_ids;
            m_effect_old_troop_model = source.m_effect_old_troop_model;
            m_effect_new_troop_model = source.m_effect_new_troop_model;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class BattleRoundInfo : NetworkMessage {
        public static int[] Id = { 794,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_battle_id;
        public Int32 m_round;
        public Byte m_status;
        public RoundFighterInfo m_p1_info;
        public RoundFighterInfo m_p2_info;
        public Int64 m_frame_time;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_battle_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_round = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_status = sp.ReadByte();}
            if (sp.TryRead(4)) {
                m_p1_info = new RoundFighterInfo();
                m_p1_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                m_p2_info = new RoundFighterInfo();
                m_p2_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_frame_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_battle_id);}
            if (sp.TryWrite(2)) {sp.Write(m_round);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_p1_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_p2_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_frame_time);}
            if (sp.TryWrite(7)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(BattleRoundInfo source) {
            m_server_id = source.m_server_id;
            m_battle_id = source.m_battle_id;
            m_round = source.m_round;
            m_status = source.m_status;
            m_p1_info = source.m_p1_info;
            m_p2_info = source.m_p2_info;
            m_frame_time = source.m_frame_time;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AgentLevelExpItemUseReqInfo : NetworkMessage {
        public static int[] Id = { 800,1 };
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
        public void CopyFrom(AgentLevelExpItemUseReqInfo source) {
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalentInfo : NetworkMessage {
        public static int[] Id = { 806,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public List<CultureAgentTalentTree> m_trees = new List<CultureAgentTalentTree>();
        public List<CultureAgentTalentSchemeInfo> m_schemes = new List<CultureAgentTalentSchemeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_trees.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalentTree tmp = new CultureAgentTalentTree();
                    tmp.Decode(sp);
                    m_trees.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_schemes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentTalentSchemeInfo tmp = new CultureAgentTalentSchemeInfo();
                    tmp.Decode(sp);
                    m_schemes.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_trees.Count);
                for (int i = 0; i != m_trees.Count; ++i) {
                    m_trees[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_schemes.Count);
                for (int i = 0; i != m_schemes.Count; ++i) {
                    m_schemes[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalentInfo source) {
            m_agent_id = source.m_agent_id;
            m_trees = source.m_trees;
            m_schemes = source.m_schemes;
        }
    }
    
    [Serializable]
    public partial class CultureAgentRankTable : NetworkMessage {
        public static int[] Id = { 812,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public SByte m_heroQuality;
        public Int16 m_heroRankLevel;
        public Int16 m_heroShardReq;
        public Int16 m_skillPointRwd;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_heroQuality = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_heroRankLevel = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_heroShardReq = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_skillPointRwd = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_heroQuality);}
            if (sp.TryWrite(2)) {sp.Write(m_heroRankLevel);}
            if (sp.TryWrite(3)) {sp.Write(m_heroShardReq);}
            if (sp.TryWrite(4)) {sp.Write(m_skillPointRwd);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentRankTable source) {
            m_id = source.m_id;
            m_heroQuality = source.m_heroQuality;
            m_heroRankLevel = source.m_heroRankLevel;
            m_heroShardReq = source.m_heroShardReq;
            m_skillPointRwd = source.m_skillPointRwd;
        }
    }
    
    [Serializable]
    public partial class UnlockAgentReqInfo : NetworkMessage {
        public static int[] Id = { 818,1 };
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
        public void CopyFrom(UnlockAgentReqInfo source) {
            m_agentId = source.m_agentId;
        }
    }
    
    [Serializable]
    public partial class AllianceBuildingState : NetworkMessage {
        public static int[] Id = { 824,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_is_existed;
        public NewAllianceBuildingTile m_info;
        public Int32 m_build_progress;
        public List<ResTypeInfo> m_res_req = new List<ResTypeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_existed = sp.ReadBoolean();}
            if (sp.TryRead(2)) {
                m_info = new NewAllianceBuildingTile();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_build_progress = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_req.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_res_req.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_existed);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_build_progress);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_req.Count);
                for (int i = 0; i != m_res_req.Count; ++i) {
                    m_res_req[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBuildingState source) {
            m_id = source.m_id;
            m_is_existed = source.m_is_existed;
            m_info = source.m_info;
            m_build_progress = source.m_build_progress;
            m_res_req = source.m_res_req;
        }
    }
    
    [Serializable]
    public partial class KickReinforceTroopReqInfo : NetworkMessage {
        public static int[] Id = { 830,1 };
        public static Ctrl VC;
        public Int64 m_building_id;
        public Int64 m_group_id;
        public Int64 m_march_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_building_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_building_id);}
            if (sp.TryWrite(1)) {sp.Write(m_group_id);}
            if (sp.TryWrite(2)) {sp.Write(m_march_id);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(KickReinforceTroopReqInfo source) {
            m_building_id = source.m_building_id;
            m_group_id = source.m_group_id;
            m_march_id = source.m_march_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class UpdateMapmarkInfo : NetworkMessage {
        public static int[] Id = { 836,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public KtilePos m_pos;
        public String m_comments = "";
        public Int16 m_type;
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
            if (sp.TryRead(4)) {m_catalog = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_comments);}
            if (sp.TryWrite(3)) {sp.Write(m_type);}
            if (sp.TryWrite(4)) {sp.Write(m_catalog);}
            if (sp.TryWrite(5)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdateMapmarkInfo source) {
            m_id = source.m_id;
            m_pos = source.m_pos;
            m_comments = source.m_comments;
            m_type = source.m_type;
            m_catalog = source.m_catalog;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GetRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 842,1 };
        public static Ctrl VC;
        public String m_mail_id = "";
        public Int16 m_mail_type;
        public Int16 m_mail_ex_type;
        public Boolean m_read;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_mail_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_mail_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_mail_ex_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_read = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_mail_id);}
            if (sp.TryWrite(1)) {sp.Write(m_mail_type);}
            if (sp.TryWrite(2)) {sp.Write(m_mail_ex_type);}
            if (sp.TryWrite(3)) {sp.Write(m_read);}
            sp.EnEnd();
        }
        public void CopyFrom(GetRtfMailReqInfo source) {
            m_mail_id = source.m_mail_id;
            m_mail_type = source.m_mail_type;
            m_mail_ex_type = source.m_mail_ex_type;
            m_read = source.m_read;
        }
    }
    
    [Serializable]
    public partial class RtfMailInfo : NetworkMessage {
        public static int[] Id = { 848,1 };
        public static Ctrl VC;
        public RtfMailBasicInfo m_basic;
        public Byte[] m_mail_content;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public List<ResTypeInfo> m_res = new List<ResTypeInfo>();
        public Byte[] m_mail_content_raw;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic = new RtfMailBasicInfo();
                m_basic.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_mail_content = sp.ReadBytes2();}
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
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_mail_content_raw = sp.ReadBytes4();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.WriteBytes2(m_mail_content);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_items.Count);
                for (int i = 0; i != m_items.Count; ++i) {
                    m_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res.Count);
                for (int i = 0; i != m_res.Count; ++i) {
                    m_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.WriteBytes4(m_mail_content_raw);}
            sp.EnEnd();
        }
        public void CopyFrom(RtfMailInfo source) {
            m_basic = source.m_basic;
            m_mail_content = source.m_mail_content;
            m_items = source.m_items;
            m_res = source.m_res;
            m_mail_content_raw = source.m_mail_content_raw;
        }
    }
    
    [Serializable]
    public partial class GetGatherReportListAckInfo : NetworkMessage {
        public static int[] Id = { 854,1 };
        public static Ctrl VC;
        public List<RtfMailInfo> m_list = new List<RtfMailInfo>();
        public Int32 m_left_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RtfMailInfo tmp = new RtfMailInfo();
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
        public void CopyFrom(GetGatherReportListAckInfo source) {
            m_list = source.m_list;
            m_left_count = source.m_left_count;
        }
    }
    
    [Serializable]
    public partial class TavernBoxOpenReqInfo : NetworkMessage {
        public static int[] Id = { 860,1 };
        public static Ctrl VC;
        public SByte m_box_type;
        public SByte m_open_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_box_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_open_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_box_type);}
            if (sp.TryWrite(1)) {sp.Write(m_open_type);}
            sp.EnEnd();
        }
        public void CopyFrom(TavernBoxOpenReqInfo source) {
            m_box_type = source.m_box_type;
            m_open_type = source.m_open_type;
        }
    }
    
    [Serializable]
    public partial class AllianceRankInfo : NetworkMessage {
        public static int[] Id = { 866,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_name = "";
        public String m_abbr = "";
        public Int64 m_score;
        public Int32 m_rank;
        public Boolean m_disbanded;
        public Int64 m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_disbanded = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_rank);}
            if (sp.TryWrite(5)) {sp.Write(m_disbanded);}
            if (sp.TryWrite(6)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRankInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_score = source.m_score;
            m_rank = source.m_rank;
            m_disbanded = source.m_disbanded;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class TrackingFteInfo : NetworkMessage {
        public static int[] Id = { 872,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_step_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_step_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step_name);}
            sp.EnEnd();
        }
        public void CopyFrom(TrackingFteInfo source) {
            m_id = source.m_id;
            m_step_name = source.m_step_name;
        }
    }
    
    [Serializable]
    public partial class AllianceFortuneGiftOpenReqInfo : NetworkMessage {
        public static int[] Id = { 878,1 };
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
        public void CopyFrom(AllianceFortuneGiftOpenReqInfo source) {
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class BaseProgressCampaignInfo : NetworkMessage {
        public static int[] Id = { 884,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_title = "";
        public Int64 m_target_point;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();
        public Int16 m_reward_state;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_title = sp.ReadString();}
            if (sp.TryRead(2)) {m_target_point = sp.ReadInt64();}
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
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_target_point);}
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
        public void CopyFrom(BaseProgressCampaignInfo source) {
            m_id = source.m_id;
            m_title = source.m_title;
            m_target_point = source.m_target_point;
            m_rewards = source.m_rewards;
            m_reward_state = source.m_reward_state;
        }
    }
    
    [Serializable]
    public partial class UserRoomInfo : NetworkMessage {
        public static int[] Id = { 890,1 };
        public static Ctrl VC;
        public List<RoomInfo> m_list = new List<RoomInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RoomInfo tmp = new RoomInfo();
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
        public void CopyFrom(UserRoomInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class MbMonumentSnapInfo : NetworkMessage {
        public static int[] Id = { 896,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public AllianceSnapInfo m_as;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_as = new AllianceSnapInfo();
                m_as.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_as.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(MbMonumentSnapInfo source) {
            m_id = source.m_id;
            m_as = source.m_as;
        }
    }
    
    [Serializable]
    public partial class CurrentExpeditionStateInfo : NetworkMessage {
        public static int[] Id = { 902,1 };
        public static Ctrl VC;
        public List<ExpeditionCheckpointStateInfo> m_list = new List<ExpeditionCheckpointStateInfo>();
        public ExpeditionCheckpointEndNtfInfo m_last_result;
        public List<Int64> m_destroyed = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExpeditionCheckpointStateInfo tmp = new ExpeditionCheckpointStateInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_last_result = new ExpeditionCheckpointEndNtfInfo();
                m_last_result.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_destroyed.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_destroyed.Add(tmp);
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
                    m_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_last_result.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_destroyed.Count);
                for (int i = 0; i != m_destroyed.Count; ++i) {
                    sp.Write(m_destroyed[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CurrentExpeditionStateInfo source) {
            m_list = source.m_list;
            m_last_result = source.m_last_result;
            m_destroyed = source.m_destroyed;
        }
    }
    
    [Serializable]
    public partial class MapExploreVirtualPoint : NetworkMessage {
        public static int[] Id = { 908,1 };
        public static Ctrl VC;
        public SByte m_index;
        public SByte m_type;
        public SByte m_level;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_march_id;
        public SByte m_reward_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_reward_status = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_level);}
            if (sp.TryWrite(3)) {sp.Write(m_x);}
            if (sp.TryWrite(4)) {sp.Write(m_y);}
            if (sp.TryWrite(5)) {sp.Write(m_march_id);}
            if (sp.TryWrite(6)) {sp.Write(m_reward_status);}
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreVirtualPoint source) {
            m_index = source.m_index;
            m_type = source.m_type;
            m_level = source.m_level;
            m_x = source.m_x;
            m_y = source.m_y;
            m_march_id = source.m_march_id;
            m_reward_status = source.m_reward_status;
        }
    }
    
    [Serializable]
    public partial class FpsAtyEndReqInfo : NetworkMessage {
        public static int[] Id = { 914,1 };
        public static Ctrl VC;
        public Int16 m_level_id;
        public Int64 m_level_time;
        public Int32 m_score;
        public List<Int32> m_score_list = new List<Int32>();
        public Int32 m_kill_num;
        public Int32 m_head_kill_num;
        public CampaignReqItemInfo m_aty_item;

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
            if (sp.TryRead(6)) {
                m_aty_item = new CampaignReqItemInfo();
                m_aty_item.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_aty_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsAtyEndReqInfo source) {
            m_level_id = source.m_level_id;
            m_level_time = source.m_level_time;
            m_score = source.m_score;
            m_score_list = source.m_score_list;
            m_kill_num = source.m_kill_num;
            m_head_kill_num = source.m_head_kill_num;
            m_aty_item = source.m_aty_item;
        }
    }
    
    [Serializable]
    public partial class ExpeditionStoreInfo : NetworkMessage {
        public static int[] Id = { 920,1 };
        public static Ctrl VC;
        public Int32 m_refresh_times;
        public List<ExpeditionStoreItem> m_fixed_items = new List<ExpeditionStoreItem>();
        public List<ExpeditionStoreItem> m_random_items = new List<ExpeditionStoreItem>();
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_refresh_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fixed_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExpeditionStoreItem tmp = new ExpeditionStoreItem();
                    tmp.Decode(sp);
                    m_fixed_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_random_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExpeditionStoreItem tmp = new ExpeditionStoreItem();
                    tmp.Decode(sp);
                    m_random_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_refresh_times);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fixed_items.Count);
                for (int i = 0; i != m_fixed_items.Count; ++i) {
                    m_fixed_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_random_items.Count);
                for (int i = 0; i != m_random_items.Count; ++i) {
                    m_random_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionStoreInfo source) {
            m_refresh_times = source.m_refresh_times;
            m_fixed_items = source.m_fixed_items;
            m_random_items = source.m_random_items;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class AssignmentCenterMiniGameReqInfo : NetworkMessage {
        public static int[] Id = { 926,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Boolean m_win;
        public Boolean m_is_quick;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_win = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_is_quick = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_win);}
            if (sp.TryWrite(2)) {sp.Write(m_is_quick);}
            sp.EnEnd();
        }
        public void CopyFrom(AssignmentCenterMiniGameReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_win = source.m_win;
            m_is_quick = source.m_is_quick;
        }
    }
    
    [Serializable]
    public partial class CampaignIdInfo : NetworkMessage {
        public static int[] Id = { 932,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_camp_type;
        public String m_icon = "";
        public String m_title = "";
        public Int64 m_begin_time;
        public Int64 m_end_time;
        public List<ItemInfo> m_rewards_review = new List<ItemInfo>();
        public String m_short_desc = "";
        public Int16 m_sub_type;
        public Int32 m_sort_weight;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_camp_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards_review.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_rewards_review.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_short_desc = sp.ReadString();}
            if (sp.TryRead(8)) {m_sub_type = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_sort_weight = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_camp_type);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(5)) {sp.Write(m_end_time);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards_review.Count);
                for (int i = 0; i != m_rewards_review.Count; ++i) {
                    m_rewards_review[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_short_desc);}
            if (sp.TryWrite(8)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(9)) {sp.Write(m_sort_weight);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignIdInfo source) {
            m_id = source.m_id;
            m_camp_type = source.m_camp_type;
            m_icon = source.m_icon;
            m_title = source.m_title;
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
            m_rewards_review = source.m_rewards_review;
            m_short_desc = source.m_short_desc;
            m_sub_type = source.m_sub_type;
            m_sort_weight = source.m_sort_weight;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelCampaignHistory : NetworkMessage {
        public static int[] Id = { 938,1 };
        public static Ctrl VC;
        public Int64 m_actId;
        public Int64 m_openTime;
        public List<StepTaskHistoryUserInfo> m_user_rank_tree = new List<StepTaskHistoryUserInfo>();
        public List<CampaignHistoryAllianceInfo> m_alliance_rank_tree = new List<CampaignHistoryAllianceInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_actId = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_openTime = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_user_rank_tree.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    StepTaskHistoryUserInfo tmp = new StepTaskHistoryUserInfo();
                    tmp.Decode(sp);
                    m_user_rank_tree.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_alliance_rank_tree.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignHistoryAllianceInfo tmp = new CampaignHistoryAllianceInfo();
                    tmp.Decode(sp);
                    m_alliance_rank_tree.Add(tmp);
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
                sp.Write((UInt16)m_user_rank_tree.Count);
                for (int i = 0; i != m_user_rank_tree.Count; ++i) {
                    m_user_rank_tree[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_alliance_rank_tree.Count);
                for (int i = 0; i != m_alliance_rank_tree.Count; ++i) {
                    m_alliance_rank_tree[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelCampaignHistory source) {
            m_actId = source.m_actId;
            m_openTime = source.m_openTime;
            m_user_rank_tree = source.m_user_rank_tree;
            m_alliance_rank_tree = source.m_alliance_rank_tree;
        }
    }
    
    [Serializable]
    public partial class AgentId : NetworkMessage {
        public static int[] Id = { 944,1 };
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
        public void CopyFrom(AgentId source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class B2VipNtfInfo : NetworkMessage {
        public static int[] Id = { 950,1 };
        public static Ctrl VC;
        public Int32 m_curr_point;
        public Int16 m_curr_level;
        public Int32 m_combo_days;
        public Boolean m_daily_reward;
        public Int32 m_next_login_point;
        public Int64 m_next_daily_reward_time;
        public Boolean m_daily_login_point;
        public Boolean m_vip_switch;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_curr_point = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_curr_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_combo_days = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_daily_reward = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_next_login_point = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_next_daily_reward_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_daily_login_point = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_vip_switch = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_curr_point);}
            if (sp.TryWrite(1)) {sp.Write(m_curr_level);}
            if (sp.TryWrite(2)) {sp.Write(m_combo_days);}
            if (sp.TryWrite(3)) {sp.Write(m_daily_reward);}
            if (sp.TryWrite(4)) {sp.Write(m_next_login_point);}
            if (sp.TryWrite(5)) {sp.Write(m_next_daily_reward_time);}
            if (sp.TryWrite(6)) {sp.Write(m_daily_login_point);}
            if (sp.TryWrite(7)) {sp.Write(m_vip_switch);}
            sp.EnEnd();
        }
        public void CopyFrom(B2VipNtfInfo source) {
            m_curr_point = source.m_curr_point;
            m_curr_level = source.m_curr_level;
            m_combo_days = source.m_combo_days;
            m_daily_reward = source.m_daily_reward;
            m_next_login_point = source.m_next_login_point;
            m_next_daily_reward_time = source.m_next_daily_reward_time;
            m_daily_login_point = source.m_daily_login_point;
            m_vip_switch = source.m_vip_switch;
        }
    }
    
    [Serializable]
    public partial class GovLootCfg : NetworkMessage {
        public static int[] Id = { 956,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GovLootCfg source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
        }
    }
    
    [Serializable]
    public partial class ActivateGovBuffReqInfo : NetworkMessage {
        public static int[] Id = { 962,1 };
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
        public void CopyFrom(ActivateGovBuffReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignRollAckInfo : NetworkMessage {
        public static int[] Id = { 968,1 };
        public static Ctrl VC;
        public List<WheelCampaignRollResult> m_result = new List<WheelCampaignRollResult>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WheelCampaignRollResult tmp = new WheelCampaignRollResult();
                    tmp.Decode(sp);
                    m_result.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_result.Count);
                for (int i = 0; i != m_result.Count; ++i) {
                    m_result[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignRollAckInfo source) {
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class DailySubscriptionInfoList : NetworkMessage {
        public static int[] Id = { 974,1 };
        public static Ctrl VC;
        public List<DailySubscriptionInfo> m_info = new List<DailySubscriptionInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DailySubscriptionInfo tmp = new DailySubscriptionInfo();
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
        public void CopyFrom(DailySubscriptionInfoList source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class ClaimRebatePackageReqInfo : NetworkMessage {
        public static int[] Id = { 980,1 };
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
        public void CopyFrom(ClaimRebatePackageReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class ClaimRechargeCampaignRwdReqInfo : NetworkMessage {
        public static int[] Id = { 986,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_camp_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_camp_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_camp_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ClaimRechargeCampaignRwdReqInfo source) {
            m_id = source.m_id;
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class RechargeRedpointInfo : NetworkMessage {
        public static int[] Id = { 992,1 };
        public static Ctrl VC;
        public List<Int64> m_camp_id = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_camp_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_camp_id.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_camp_id.Count);
                for (int i = 0; i != m_camp_id.Count; ++i) {
                    sp.Write(m_camp_id[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RechargeRedpointInfo source) {
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class UserCostCampaignItemExchangeRule : NetworkMessage {
        public static int[] Id = { 998,1 };
        public static Ctrl VC;
        public Int32 m_cost_id;
        public ItemInfo m_src_item;
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
            if (sp.TryRead(3)) {m_src_pic = sp.ReadString();}
            if (sp.TryRead(4)) {m_dst_pic = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cost_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_src_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_src_pic);}
            if (sp.TryWrite(4)) {sp.Write(m_dst_pic);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCostCampaignItemExchangeRule source) {
            m_cost_id = source.m_cost_id;
            m_src_item = source.m_src_item;
            m_reward = source.m_reward;
            m_src_pic = source.m_src_pic;
            m_dst_pic = source.m_dst_pic;
        }
    }
    
    [Serializable]
    public partial class CostActivityLevelRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1004,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int16 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(CostActivityLevelRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class CampaignId : NetworkMessage {
        public static int[] Id = { 1010,1 };
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
        public void CopyFrom(CampaignId source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class AllianceShopItem : NetworkMessage {
        public static int[] Id = { 1016,1 };
        public static Ctrl VC;
        public Int32 m_stock_id;
        public SByte m_item_type;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int64 m_price;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_stock_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_price = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_stock_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_type);}
            if (sp.TryWrite(2)) {sp.Write(m_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_item_num);}
            if (sp.TryWrite(4)) {sp.Write(m_price);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopItem source) {
            m_stock_id = source.m_stock_id;
            m_item_type = source.m_item_type;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_price = source.m_price;
        }
    }
    
    [Serializable]
    public partial class AllianceShopRestockHistoryEntry : NetworkMessage {
        public static int[] Id = { 1022,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_user_icon;
        public String m_user_avatar = "";
        public List<Int32> m_stock = new List<Int32>();
        public Int64 m_happen_time;
        public Int16 m_user_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_user_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_user_avatar = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_stock.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_stock.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {m_happen_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_user_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_user_avatar);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_stock.Count);
                for (int i = 0; i != m_stock.Count; ++i) {
                    sp.Write(m_stock[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {sp.Write(m_happen_time);}
            if (sp.TryWrite(6)) {sp.Write(m_user_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopRestockHistoryEntry source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_user_avatar = source.m_user_avatar;
            m_stock = source.m_stock;
            m_happen_time = source.m_happen_time;
            m_user_avatar_frame = source.m_user_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class QuestCountdownReq : NetworkMessage {
        public static int[] Id = { 1028,2 };
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
        public void CopyFrom(QuestCountdownReq source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class FogDataExt : NetworkMessage {
        public static int[] Id = { 1034,2 };
        public static Ctrl VC;
        public List<FogData3> m_data = new List<FogData3>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_data.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FogData3 tmp = new FogData3();
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
        public void CopyFrom(FogDataExt source) {
            m_data = source.m_data;
        }
    }
    
    [Serializable]
    public partial class MonumentExploreInfo : NetworkMessage {
        public static int[] Id = { 1040,2 };
        public static Ctrl VC;
        public Int16 m_total;
        public Int16 m_claimed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_claimed = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total);}
            if (sp.TryWrite(1)) {sp.Write(m_claimed);}
            sp.EnEnd();
        }
        public void CopyFrom(MonumentExploreInfo source) {
            m_total = source.m_total;
            m_claimed = source.m_claimed;
        }
    }
    
    [Serializable]
    public partial class LadderStatusInfo : NetworkMessage {
        public static int[] Id = { 1046,3 };
        public static Ctrl VC;
        public Boolean m_is_init;
        public Boolean m_is_called;
        public SByte m_difficulty_level;
        public Boolean m_send_help;
        public Int16 m_cur_step;
        public LadderRebelInfo m_creep;
        public Int16 m_energy_cost;
        public Boolean m_is_complete;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_init = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_is_called = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_difficulty_level = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_send_help = sp.ReadBoolean();}
            if (sp.TryRead(4)) {m_cur_step = sp.ReadInt16();}
            if (sp.TryRead(5)) {
                m_creep = new LadderRebelInfo();
                m_creep.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_energy_cost = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_is_complete = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_init);}
            if (sp.TryWrite(1)) {sp.Write(m_is_called);}
            if (sp.TryWrite(2)) {sp.Write(m_difficulty_level);}
            if (sp.TryWrite(3)) {sp.Write(m_send_help);}
            if (sp.TryWrite(4)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_creep.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_energy_cost);}
            if (sp.TryWrite(7)) {sp.Write(m_is_complete);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderStatusInfo source) {
            m_is_init = source.m_is_init;
            m_is_called = source.m_is_called;
            m_difficulty_level = source.m_difficulty_level;
            m_send_help = source.m_send_help;
            m_cur_step = source.m_cur_step;
            m_creep = source.m_creep;
            m_energy_cost = source.m_energy_cost;
            m_is_complete = source.m_is_complete;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBossCond : NetworkMessage {
        public static int[] Id = { 1052,3 };
        public static Ctrl VC;
        public List<LadderAllianceBossCondDetail> m_detail = new List<LadderAllianceBossCondDetail>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderAllianceBossCondDetail tmp = new LadderAllianceBossCondDetail();
                    tmp.Decode(sp);
                    m_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_detail.Count);
                for (int i = 0; i != m_detail.Count; ++i) {
                    m_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBossCond source) {
            m_detail = source.m_detail;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBoardFlushNtf : NetworkMessage {
        public static int[] Id = { 1058,3 };
        public static Ctrl VC;
        public LadderAllianceBoardUser m_user_info;
        public Int16 m_cur_step;
        public Boolean m_need_help;
        public RealPos m_target_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_user_info = new LadderAllianceBoardUser();
                m_user_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_cur_step = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_need_help = sp.ReadBoolean();}
            if (sp.TryRead(3)) {
                m_target_pos = new RealPos();
                m_target_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_user_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_step);}
            if (sp.TryWrite(2)) {sp.Write(m_need_help);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_target_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBoardFlushNtf source) {
            m_user_info = source.m_user_info;
            m_cur_step = source.m_cur_step;
            m_need_help = source.m_need_help;
            m_target_pos = source.m_target_pos;
        }
    }
    
    [Serializable]
    public partial class LadderAllianceBossInfo : NetworkMessage {
        public static int[] Id = { 1064,3 };
        public static Ctrl VC;
        public Int32 m_boss_id;
        public LadderAllianceBossShow m_boss_info;
        public Int64 m_boss_march_id;
        public Int64 m_boss_end_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_boss_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_boss_info = new LadderAllianceBossShow();
                m_boss_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_boss_march_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_boss_end_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_boss_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_boss_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_boss_march_id);}
            if (sp.TryWrite(3)) {sp.Write(m_boss_end_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(LadderAllianceBossInfo source) {
            m_boss_id = source.m_boss_id;
            m_boss_info = source.m_boss_info;
            m_boss_march_id = source.m_boss_march_id;
            m_boss_end_dt = source.m_boss_end_dt;
        }
    }
    
    [Serializable]
    public partial class TimelimitTaskPointNtf : NetworkMessage {
        public static int[] Id = { 1070,3 };
        public static Ctrl VC;
        public Int64 m_camp_id;
        public Int32 m_task_id;
        public Int64 m_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_camp_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_camp_id);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id);}
            if (sp.TryWrite(2)) {sp.Write(m_points);}
            sp.EnEnd();
        }
        public void CopyFrom(TimelimitTaskPointNtf source) {
            m_camp_id = source.m_camp_id;
            m_task_id = source.m_task_id;
            m_points = source.m_points;
        }
    }
    
    [Serializable]
    public partial class ProgressiveTaskCampaignFinalRewardStatusInfo : NetworkMessage {
        public static int[] Id = { 1076,4 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<ItemInfo> m_final_reward = new List<ItemInfo>();
        public Int32 m_cur_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
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
            if (sp.TryRead(2)) {m_cur_score = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_final_reward.Count);
                for (int i = 0; i != m_final_reward.Count; ++i) {
                    m_final_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_cur_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ProgressiveTaskCampaignFinalRewardStatusInfo source) {
            m_act_id = source.m_act_id;
            m_final_reward = source.m_final_reward;
            m_cur_score = source.m_cur_score;
        }
    }
    
    [Serializable]
    public partial class ArenaHistoryEntryInfo : NetworkMessage {
        public static int[] Id = { 1082,4 };
        public static Ctrl VC;
        public UInt32 m_id;
        public Int64 m_time;
        public ArenaPlayerStatInfo m_attacker;
        public ArenaPlayerStatInfo m_defender;
        public List<ArenaTroopInfo> m_defend_array = new List<ArenaTroopInfo>();
        public Int32 m_defend_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadUInt32();}
            if (sp.TryRead(1)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                m_attacker = new ArenaPlayerStatInfo();
                m_attacker.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_defender = new ArenaPlayerStatInfo();
                m_defender.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryRead(5)) {m_defend_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_time);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_attacker.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_defender.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defend_array.Count);
                for (int i = 0; i != m_defend_array.Count; ++i) {
                    m_defend_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_defend_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaHistoryEntryInfo source) {
            m_id = source.m_id;
            m_time = source.m_time;
            m_attacker = source.m_attacker;
            m_defender = source.m_defender;
            m_defend_array = source.m_defend_array;
            m_defend_rank = source.m_defend_rank;
        }
    }
    
    [Serializable]
    public partial class ArenaFightStatInfo : NetworkMessage {
        public static int[] Id = { 1088,4 };
        public static Ctrl VC;
        public UInt32 m_id;
        public ArenaPlayerStatInfo m_self_stat;
        public ArenaPlayerStatInfo m_target_stat;
        public UInt32 m_season;
        public UInt16 m_max_battle_time;
        public Int32 m_troop_speed;
        public List<ArenaTroopAttackSeq> m_attack_seq = new List<ArenaTroopAttackSeq>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadUInt32();}
            if (sp.TryRead(1)) {
                m_self_stat = new ArenaPlayerStatInfo();
                m_self_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_target_stat = new ArenaPlayerStatInfo();
                m_target_stat.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_season = sp.ReadUInt32();}
            if (sp.TryRead(4)) {m_max_battle_time = sp.ReadUInt16();}
            if (sp.TryRead(5)) {m_troop_speed = sp.ReadInt32();}
            if (sp.TryRead(6)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_target_stat.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_season);}
            if (sp.TryWrite(4)) {sp.Write(m_max_battle_time);}
            if (sp.TryWrite(5)) {sp.Write(m_troop_speed);}
            if (sp.TryWrite(6)) {
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
        public void CopyFrom(ArenaFightStatInfo source) {
            m_id = source.m_id;
            m_self_stat = source.m_self_stat;
            m_target_stat = source.m_target_stat;
            m_season = source.m_season;
            m_max_battle_time = source.m_max_battle_time;
            m_troop_speed = source.m_troop_speed;
            m_attack_seq = source.m_attack_seq;
        }
    }
    
    [Serializable]
    public partial class BattlePassportInfo : NetworkMessage {
        public static int[] Id = { 1094,4 };
        public static Ctrl VC;
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

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_endtime = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_is_premium = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_reward_record.Add(tmp);
                }
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_premium_reward_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_premium_reward_record.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BattlePassportTask tmp = new BattlePassportTask();
                    tmp.Decode(sp);
                    m_task.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_box_score = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_box_reward = sp.ReadBoolean();}
            if (sp.TryRead(9)) {m_exp_ratio = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_extra_rwd = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_exp);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_endtime);}
            if (sp.TryWrite(3)) {sp.Write(m_is_premium);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_record.Count);
                for (int i = 0; i != m_reward_record.Count; ++i) {
                    sp.Write(m_reward_record[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_premium_reward_record.Count);
                for (int i = 0; i != m_premium_reward_record.Count; ++i) {
                    sp.Write(m_premium_reward_record[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task.Count);
                for (int i = 0; i != m_task.Count; ++i) {
                    m_task[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_box_score);}
            if (sp.TryWrite(8)) {sp.Write(m_box_reward);}
            if (sp.TryWrite(9)) {sp.Write(m_exp_ratio);}
            if (sp.TryWrite(10)) {sp.Write(m_extra_rwd);}
            sp.EnEnd();
        }
        public void CopyFrom(BattlePassportInfo source) {
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
        }
    }
    
    [Serializable]
    public partial class AtkCityGuideCampaignInfo : NetworkMessage {
        public static int[] Id = { 1100,5 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseTaskGroupCampaignInfo> m_task_info = new List<BaseTaskGroupCampaignInfo>();
        public Int32 m_unlock_map_quest;

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
                    BaseTaskGroupCampaignInfo tmp = new BaseTaskGroupCampaignInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_unlock_map_quest = sp.ReadInt32();}
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
            if (sp.TryWrite(2)) {sp.Write(m_unlock_map_quest);}
            sp.EnEnd();
        }
        public void CopyFrom(AtkCityGuideCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
            m_unlock_map_quest = source.m_unlock_map_quest;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeUserTaskStatus : NetworkMessage {
        public static int[] Id = { 1106,5 };
        public static Ctrl VC;
        public Int16 m_available_flush;
        public Int16 m_available_task_num;
        public Int16 m_finish_task_num;
        public Int32 m_finish_task_score;
        public List<AllianceMobilizeTaskBaseInfo> m_select_task_list = new List<AllianceMobilizeTaskBaseInfo>();
        public List<AllianceMobilizeTaskBaseInfo> m_cur_task_list = new List<AllianceMobilizeTaskBaseInfo>();
        public Int64 m_add_task_num_cost;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_available_flush = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_available_task_num = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_finish_task_num = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_finish_task_score = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_select_task_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMobilizeTaskBaseInfo tmp = new AllianceMobilizeTaskBaseInfo();
                    tmp.Decode(sp);
                    m_select_task_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cur_task_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMobilizeTaskBaseInfo tmp = new AllianceMobilizeTaskBaseInfo();
                    tmp.Decode(sp);
                    m_cur_task_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_add_task_num_cost = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_available_flush);}
            if (sp.TryWrite(1)) {sp.Write(m_available_task_num);}
            if (sp.TryWrite(2)) {sp.Write(m_finish_task_num);}
            if (sp.TryWrite(3)) {sp.Write(m_finish_task_score);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_select_task_list.Count);
                for (int i = 0; i != m_select_task_list.Count; ++i) {
                    m_select_task_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cur_task_list.Count);
                for (int i = 0; i != m_cur_task_list.Count; ++i) {
                    m_cur_task_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_add_task_num_cost);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeUserTaskStatus source) {
            m_available_flush = source.m_available_flush;
            m_available_task_num = source.m_available_task_num;
            m_finish_task_num = source.m_finish_task_num;
            m_finish_task_score = source.m_finish_task_score;
            m_select_task_list = source.m_select_task_list;
            m_cur_task_list = source.m_cur_task_list;
            m_add_task_num_cost = source.m_add_task_num_cost;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeAddAvailableTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1112,5 };
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
        public void CopyFrom(AllianceMobilizeAddAvailableTaskReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskSelectAckInfo : NetworkMessage {
        public static int[] Id = { 1118,5 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public AllianceMobilizeTaskBaseInfo m_select_task;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_select_task = new AllianceMobilizeTaskBaseInfo();
                m_select_task.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_select_task.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeTaskSelectAckInfo source) {
            m_act_id = source.m_act_id;
            m_select_task = source.m_select_task;
        }
    }
    
    [Serializable]
    public partial class ArenaFightIdInfo : NetworkMessage {
        public static int[] Id = { 1124,6 };
        public static Ctrl VC;
        public UInt32 m_season;
        public UInt32 m_id;
        public Int64 m_user_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_season = sp.ReadUInt32();}
            if (sp.TryRead(1)) {m_id = sp.ReadUInt32();}
            if (sp.TryRead(2)) {m_user_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_season);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaFightIdInfo source) {
            m_season = source.m_season;
            m_id = source.m_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class CastMonumentSkillAckInfo : NetworkMessage {
        public static int[] Id = { 1131,7 };
        public static Ctrl VC;
        public Int16 m_code;
        public Int32 m_skill_id;
        public Int64 m_monument_id;
        public Int64 m_last_skill_time;
        public List<TilePos> m_lands = new List<TilePos>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_monument_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_last_skill_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_lands.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TilePos tmp = new TilePos();
                    tmp.Decode(sp);
                    m_lands.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(2)) {sp.Write(m_monument_id);}
            if (sp.TryWrite(3)) {sp.Write(m_last_skill_time);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_lands.Count);
                for (int i = 0; i != m_lands.Count; ++i) {
                    m_lands[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CastMonumentSkillAckInfo source) {
            m_code = source.m_code;
            m_skill_id = source.m_skill_id;
            m_monument_id = source.m_monument_id;
            m_last_skill_time = source.m_last_skill_time;
            m_lands = source.m_lands;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerCheckoutAck : NetworkMessage {
        public static int[] Id = { 1137,8 };
        public static Ctrl VC;
        public Boolean m_success;
        public List<Int32> m_error_codes = new List<Int32>();
        public Int16 m_trans_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_success = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_error_codes.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_error_codes.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_trans_type = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_success);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_error_codes.Count);
                for (int i = 0; i != m_error_codes.Count; ++i) {
                    sp.Write(m_error_codes[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_trans_type);}
            sp.EnEnd();
        }
        public void CopyFrom(B2TransferServerCheckoutAck source) {
            m_success = source.m_success;
            m_error_codes = source.m_error_codes;
            m_trans_type = source.m_trans_type;
        }
    }
    
    [Serializable]
    public partial class OutbattleEffectNtfInfo : NetworkMessage {
        public static int[] Id = { 1143,8 };
        public static Ctrl VC;
        public MapUnitId m_unit_id;
        public Int64 m_value;
        public Int16 m_server_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_unit_id = new MapUnitId();
                m_unit_id.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_value = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_server_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_unit_id.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            if (sp.TryWrite(2)) {sp.Write(m_server_id);}
            sp.EnEnd();
        }
        public void CopyFrom(OutbattleEffectNtfInfo source) {
            m_unit_id = source.m_unit_id;
            m_value = source.m_value;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class KillzombieNtfInfo : NetworkMessage {
        public static int[] Id = { 1149,11 };
        public static Ctrl VC;
        public Int32 m_total_reward_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total_reward_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total_reward_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(KillzombieNtfInfo source) {
            m_total_reward_cnt = source.m_total_reward_cnt;
        }
    }
    
    [Serializable]
    public partial class GvgJoinReqInfo : NetworkMessage {
        public static int[] Id = { 1155,12 };
        public static Ctrl VC;
        public Int64 m_battlefield_id;
        public Int64 m_user_id;
        public Int64 m_map_guid;
        public Int32 m_alliance_id;
        public String m_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_battlefield_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_battlefield_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(3)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(4)) {sp.Write(m_name);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgJoinReqInfo source) {
            m_battlefield_id = source.m_battlefield_id;
            m_user_id = source.m_user_id;
            m_map_guid = source.m_map_guid;
            m_alliance_id = source.m_alliance_id;
            m_name = source.m_name;
        }
    }
    
    [Serializable]
    public partial class GvgNtfInfo : NetworkMessage {
        public static int[] Id = { 1161,12 };
        public static Ctrl VC;
        public SByte m_rights;
        public Int64 m_apply_open_time;
        public Int64 m_apply_end_time;
        public Int64 m_battle_open_time;
        public Int64 m_battle_end_time;
        public Int64 m_season_end_time;
        public List<Int64> m_available_battle_time = new List<Int64>();
        public GvgMatchGuildInfo m_blue;
        public GvgMatchGuildInfo m_red;
        public Int64 m_battlefield_id;
        public Int16 m_battlefield_server;
        public Boolean m_match_nil;
        public Int16 m_max_member;
        public Int64 m_match_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rights = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_apply_open_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_apply_end_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_battle_open_time = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_battle_end_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_season_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_available_battle_time.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_available_battle_time.Add(tmp);
                }
            }
            if (sp.TryRead(7)) {
                m_blue = new GvgMatchGuildInfo();
                m_blue.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                m_red = new GvgMatchGuildInfo();
                m_red.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_battlefield_id = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_battlefield_server = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_match_nil = sp.ReadBoolean();}
            if (sp.TryRead(12)) {m_max_member = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_match_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rights);}
            if (sp.TryWrite(1)) {sp.Write(m_apply_open_time);}
            if (sp.TryWrite(2)) {sp.Write(m_apply_end_time);}
            if (sp.TryWrite(3)) {sp.Write(m_battle_open_time);}
            if (sp.TryWrite(4)) {sp.Write(m_battle_end_time);}
            if (sp.TryWrite(5)) {sp.Write(m_season_end_time);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_available_battle_time.Count);
                for (int i = 0; i != m_available_battle_time.Count; ++i) {
                    sp.Write(m_available_battle_time[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_blue.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_red.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {sp.Write(m_battlefield_id);}
            if (sp.TryWrite(10)) {sp.Write(m_battlefield_server);}
            if (sp.TryWrite(11)) {sp.Write(m_match_nil);}
            if (sp.TryWrite(12)) {sp.Write(m_max_member);}
            if (sp.TryWrite(13)) {sp.Write(m_match_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgNtfInfo source) {
            m_rights = source.m_rights;
            m_apply_open_time = source.m_apply_open_time;
            m_apply_end_time = source.m_apply_end_time;
            m_battle_open_time = source.m_battle_open_time;
            m_battle_end_time = source.m_battle_end_time;
            m_season_end_time = source.m_season_end_time;
            m_available_battle_time = source.m_available_battle_time;
            m_blue = source.m_blue;
            m_red = source.m_red;
            m_battlefield_id = source.m_battlefield_id;
            m_battlefield_server = source.m_battlefield_server;
            m_match_nil = source.m_match_nil;
            m_max_member = source.m_max_member;
            m_match_end_time = source.m_match_end_time;
        }
    }
    
    [Serializable]
    public partial class GvgApplyMemberStatusChangeInfo : NetworkMessage {
        public static int[] Id = { 1167,12 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public SByte m_old_status;
        public SByte m_new_status;
        public Int16 m_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_old_status = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_new_status = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_old_status);}
            if (sp.TryWrite(2)) {sp.Write(m_new_status);}
            if (sp.TryWrite(3)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyMemberStatusChangeInfo source) {
            m_user_id = source.m_user_id;
            m_old_status = source.m_old_status;
            m_new_status = source.m_new_status;
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldAllianceMemberInfo : NetworkMessage {
        public static int[] Id = { 1173,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int32 m_score;
        public Int16 m_title;
        public Int16 m_icon;
        public String m_avatar = "";
        public List<GvgStatistics> m_statistic_list = new List<GvgStatistics>();
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_title = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_statistic_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgStatistics tmp = new GvgStatistics();
                    tmp.Decode(sp);
                    m_statistic_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_score);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_avatar);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_statistic_list.Count);
                for (int i = 0; i != m_statistic_list.Count; ++i) {
                    m_statistic_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldAllianceMemberInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_score = source.m_score;
            m_title = source.m_title;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_statistic_list = source.m_statistic_list;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldReqInfo : NetworkMessage {
        public static int[] Id = { 1179,12 };
        public static Ctrl VC;
        public List<Int64> m_battle_id_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_battle_id_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_battle_id_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_battle_id_list.Count);
                for (int i = 0; i != m_battle_id_list.Count; ++i) {
                    sp.Write(m_battle_id_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldReqInfo source) {
            m_battle_id_list = source.m_battle_id_list;
        }
    }
    
    [Serializable]
    public partial class GvgNtfReqInfo : NetworkMessage {
        public static int[] Id = { 1185,12 };
        public static Ctrl VC;
        public Boolean m_auto_apply;
        public Int64 m_camp_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_auto_apply = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_camp_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_auto_apply);}
            if (sp.TryWrite(1)) {sp.Write(m_camp_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgNtfReqInfo source) {
            m_auto_apply = source.m_auto_apply;
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class DayNightInfo : NetworkMessage {
        public static int[] Id = { 1207,12 };
        public static Ctrl VC;
        public Int16 m_status;
        public Int64 m_shift_time;
        public Int64 m_next_shift_time;
        public Int64 m_day_duration;
        public Int64 m_night_duration;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_shift_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_next_shift_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_day_duration = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_night_duration = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_shift_time);}
            if (sp.TryWrite(2)) {sp.Write(m_next_shift_time);}
            if (sp.TryWrite(3)) {sp.Write(m_day_duration);}
            if (sp.TryWrite(4)) {sp.Write(m_night_duration);}
            sp.EnEnd();
        }
        public void CopyFrom(DayNightInfo source) {
            m_status = source.m_status;
            m_shift_time = source.m_shift_time;
            m_next_shift_time = source.m_next_shift_time;
            m_day_duration = source.m_day_duration;
            m_night_duration = source.m_night_duration;
        }
    }
    
    [Serializable]
    public partial class RouletteCell : NetworkMessage {
        public static int[] Id = { 1215,14 };
        public static Ctrl VC;
        public SByte m_cell_id;
        public SByte m_cell_type;
        public ItemInfo m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cell_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_cell_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                m_reward = new ItemInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cell_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cell_type);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteCell source) {
            m_cell_id = source.m_cell_id;
            m_cell_type = source.m_cell_type;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class RouletteCirclePtStatus : NetworkMessage {
        public static int[] Id = { 1221,14 };
        public static Ctrl VC;
        public Int32 m_circle_id;
        public SByte m_circle_order;
        public SByte m_available_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_circle_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_circle_order = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_available_pt = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_circle_id);}
            if (sp.TryWrite(1)) {sp.Write(m_circle_order);}
            if (sp.TryWrite(2)) {sp.Write(m_available_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(RouletteCirclePtStatus source) {
            m_circle_id = source.m_circle_id;
            m_circle_order = source.m_circle_order;
            m_available_pt = source.m_available_pt;
        }
    }
    
    [Serializable]
    public partial class UserChatBubbleInfo : NetworkMessage {
        public static int[] Id = { 1227,18 };
        public static Ctrl VC;
        public List<Int16> m_list = new List<Int16>();
        public Int16 m_current_one;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_list.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_current_one = sp.ReadInt16();}
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
            if (sp.TryWrite(1)) {sp.Write(m_current_one);}
            sp.EnEnd();
        }
        public void CopyFrom(UserChatBubbleInfo source) {
            m_list = source.m_list;
            m_current_one = source.m_current_one;
        }
    }
    
    [Serializable]
    public partial class UserEmoticonItem : NetworkMessage {
        public static int[] Id = { 1233,18 };
        public static Ctrl VC;
        public Int16 m_series_id;
        public List<Int16> m_emoticon_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_series_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_emoticon_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_emoticon_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_series_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_emoticon_list.Count);
                for (int i = 0; i != m_emoticon_list.Count; ++i) {
                    sp.Write(m_emoticon_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserEmoticonItem source) {
            m_series_id = source.m_series_id;
            m_emoticon_list = source.m_emoticon_list;
        }
    }
    
    [Serializable]
    public partial class CrossArenaBuyCntReqInfo : NetworkMessage {
        public static int[] Id = { 1239,19 };
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
        public void CopyFrom(CrossArenaBuyCntReqInfo source) {
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class UserGetVerifCodeReqInfo : NetworkMessage {
        public static int[] Id = { 1245,19 };
        public static Ctrl VC;
        public Boolean m_is_force;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_force = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_force);}
            sp.EnEnd();
        }
        public void CopyFrom(UserGetVerifCodeReqInfo source) {
            m_is_force = source.m_is_force;
        }
    }
    
    [Serializable]
    public partial class MailConfirmQueryAckInfo : NetworkMessage {
        public static int[] Id = { 1251,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;
        public List<MailConfirmUserInfo> m_list = new List<MailConfirmUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MailConfirmUserInfo tmp = new MailConfirmUserInfo();
                    tmp.Decode(sp);
                    m_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
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
        public void CopyFrom(MailConfirmQueryAckInfo source) {
            m_confirm_id = source.m_confirm_id;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class MailConfirmSimpleStatus : NetworkMessage {
        public static int[] Id = { 1257,19 };
        public static Ctrl VC;
        public Int64 m_confirm_id;
        public Int32 m_do_choice_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_confirm_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_do_choice_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_confirm_id);}
            if (sp.TryWrite(1)) {sp.Write(m_do_choice_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmSimpleStatus source) {
            m_confirm_id = source.m_confirm_id;
            m_do_choice_cnt = source.m_do_choice_cnt;
        }
    }
    
    [Serializable]
    public partial class BossCampaignBossInfo : NetworkMessage {
        public static int[] Id = { 1263,19 };
        public static Ctrl VC;
        public Int16 m_Level;
        public Int64 m_MaxHp;
        public List<ItemInfo> m_KillReward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_Level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_MaxHp = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_KillReward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_KillReward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_Level);}
            if (sp.TryWrite(1)) {sp.Write(m_MaxHp);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_KillReward.Count);
                for (int i = 0; i != m_KillReward.Count; ++i) {
                    m_KillReward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignBossInfo source) {
            m_Level = source.m_Level;
            m_MaxHp = source.m_MaxHp;
            m_KillReward = source.m_KillReward;
        }
    }
    
    [Serializable]
    public partial class BossCampaignSetSlotArmyReqInfo : NetworkMessage {
        public static int[] Id = { 1269,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_slot;
        public List<Int16> m_agent = new List<Int16>();
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_slot = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_agent.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_slot);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    sp.Write(m_agent[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(5)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(6)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(7)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignSetSlotArmyReqInfo source) {
            m_act_id = source.m_act_id;
            m_slot = source.m_slot;
            m_agent = source.m_agent;
            m_troops = source.m_troops;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class BossCampaignBossFlushNtfInfo : NetworkMessage {
        public static int[] Id = { 1275,19 };
        public static Ctrl VC;
        public Int16 m_cur_boss_level;
        public Int64 m_cur_boss_hp;
        public Int64 m_cur_boss_march_id;
        public TilePos m_cur_boss_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_boss_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_boss_hp = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cur_boss_march_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                m_cur_boss_pos = new TilePos();
                m_cur_boss_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_boss_level);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_boss_hp);}
            if (sp.TryWrite(2)) {sp.Write(m_cur_boss_march_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_cur_boss_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignBossFlushNtfInfo source) {
            m_cur_boss_level = source.m_cur_boss_level;
            m_cur_boss_hp = source.m_cur_boss_hp;
            m_cur_boss_march_id = source.m_cur_boss_march_id;
            m_cur_boss_pos = source.m_cur_boss_pos;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRecordInfo : NetworkMessage {
        public static int[] Id = { 1281,19 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_user_name = "";
        public Int64 m_damage;
        public SByte m_score_level;
        public Int64 m_time;
        public String m_as_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_score_level = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_as_abbr = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_damage);}
            if (sp.TryWrite(3)) {sp.Write(m_score_level);}
            if (sp.TryWrite(4)) {sp.Write(m_time);}
            if (sp.TryWrite(5)) {sp.Write(m_as_abbr);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignRecordInfo source) {
            m_id = source.m_id;
            m_user_name = source.m_user_name;
            m_damage = source.m_damage;
            m_score_level = source.m_score_level;
            m_time = source.m_time;
            m_as_abbr = source.m_as_abbr;
        }
    }
    
    [Serializable]
    public partial class MapIdReqInfo : NetworkMessage {
        public static int[] Id = { 1287,19 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_campaign_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_campaign_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_campaign_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MapIdReqInfo source) {
            m_server_id = source.m_server_id;
            m_campaign_id = source.m_campaign_id;
        }
    }
    
    [Serializable]
    public partial class KvkQuestFinishNtfInfo : NetworkMessage {
        public static int[] Id = { 1293,19 };
        public static Ctrl VC;
        public List<Int32> m_quest_list = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_quest_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_quest_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_quest_list.Count);
                for (int i = 0; i != m_quest_list.Count; ++i) {
                    sp.Write(m_quest_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkQuestFinishNtfInfo source) {
            m_quest_list = source.m_quest_list;
        }
    }
    
    [Serializable]
    public partial class ErrorCodeInfo : NetworkMessage {
        public static int[] Id = { 1299,19 };
        public static Ctrl VC;
        public Int16 m_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(ErrorCodeInfo source) {
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortDonateReqInfo : NetworkMessage {
        public static int[] Id = { 1305,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_donate_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_donate_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_donate_id);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortDonateReqInfo source) {
            m_act_id = source.m_act_id;
            m_donate_id = source.m_donate_id;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortServerRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1311,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_step = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_step);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortServerRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_step = source.m_step;
        }
    }
    
    [Serializable]
    public partial class MergeServerNtfInfo : NetworkMessage {
        public static int[] Id = { 1317,21 };
        public static Ctrl VC;
        public Int16 m_to_server_id;
        public List<Int16> m_from_server_list = new List<Int16>();
        public Int64 m_merge_time;
        public Int64 m_merge_notice_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_to_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_from_server_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_from_server_list.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {m_merge_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_merge_notice_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_to_server_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_from_server_list.Count);
                for (int i = 0; i != m_from_server_list.Count; ++i) {
                    sp.Write(m_from_server_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {sp.Write(m_merge_time);}
            if (sp.TryWrite(3)) {sp.Write(m_merge_notice_time);}
            sp.EnEnd();
        }
        public void CopyFrom(MergeServerNtfInfo source) {
            m_to_server_id = source.m_to_server_id;
            m_from_server_list = source.m_from_server_list;
            m_merge_time = source.m_merge_time;
            m_merge_notice_time = source.m_merge_notice_time;
        }
    }
    
    [Serializable]
    public partial class SlotMachineBigRewardRule : NetworkMessage {
        public static int[] Id = { 1337,22 };
        public static Ctrl VC;
        public List<Int32> m_cell_id = new List<Int32>();
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cell_id.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_cell_id.Add(tmp);
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
                sp.Write((UInt16)m_cell_id.Count);
                for (int i = 0; i != m_cell_id.Count; ++i) {
                    sp.Write(m_cell_id[i]);
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
        public void CopyFrom(SlotMachineBigRewardRule source) {
            m_cell_id = source.m_cell_id;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class NewSevenDayLoginRewardsNtfInfo : NetworkMessage {
        public static int[] Id = { 1343,22 };
        public static Ctrl VC;
        public Boolean m_is_active;
        public Int16 m_login_day;
        public List<Int16> m_reward_claimed_list = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_active = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_login_day = sp.ReadInt16();}
            if (sp.TryRead(2)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_is_active);}
            if (sp.TryWrite(1)) {sp.Write(m_login_day);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_claimed_list.Count);
                for (int i = 0; i != m_reward_claimed_list.Count; ++i) {
                    sp.Write(m_reward_claimed_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NewSevenDayLoginRewardsNtfInfo source) {
            m_is_active = source.m_is_active;
            m_login_day = source.m_login_day;
            m_reward_claimed_list = source.m_reward_claimed_list;
        }
    }
    
    [Serializable]
    public partial class SpottingItemNtfInfo : NetworkMessage {
        public static int[] Id = { 1349,23 };
        public static Ctrl VC;
        public String m_name = "";
        public String m_abbr = "";
        public String m_avatar = "";
        public Int64 m_id;
        public Int64 m_power;
        public Int16 m_server_id;
        public Int16 m_icon;
        public Int16 m_hqlevel;
        public Int16 m_x;
        public Int16 m_y;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_abbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(3)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_hqlevel = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_y = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            if (sp.TryWrite(1)) {sp.Write(m_abbr);}
            if (sp.TryWrite(2)) {sp.Write(m_avatar);}
            if (sp.TryWrite(3)) {sp.Write(m_id);}
            if (sp.TryWrite(4)) {sp.Write(m_power);}
            if (sp.TryWrite(5)) {sp.Write(m_server_id);}
            if (sp.TryWrite(6)) {sp.Write(m_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_hqlevel);}
            if (sp.TryWrite(8)) {sp.Write(m_x);}
            if (sp.TryWrite(9)) {sp.Write(m_y);}
            sp.EnEnd();
        }
        public void CopyFrom(SpottingItemNtfInfo source) {
            m_name = source.m_name;
            m_abbr = source.m_abbr;
            m_avatar = source.m_avatar;
            m_id = source.m_id;
            m_power = source.m_power;
            m_server_id = source.m_server_id;
            m_icon = source.m_icon;
            m_hqlevel = source.m_hqlevel;
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class SelfAllianceRankAckInfo : NetworkMessage {
        public static int[] Id = { 1355,23 };
        public static Ctrl VC;
        public SByte m_scope;
        public Int16 m_rank_type;
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_scope = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_rank_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_scope);}
            if (sp.TryWrite(1)) {sp.Write(m_rank_type);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(SelfAllianceRankAckInfo source) {
            m_scope = source.m_scope;
            m_rank_type = source.m_rank_type;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRunningStatusAckInfo : NetworkMessage {
        public static int[] Id = { 1361,23 };
        public static Ctrl VC;
        public CampaignIdInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_info = new CampaignIdInfo();
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
        public void CopyFrom(BossCampaignRunningStatusAckInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class UserWarshipUpgradeSkillInfo : NetworkMessage {
        public static int[] Id = { 1367,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_warship_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipUpgradeSkillInfo source) {
            m_warship_id = source.m_warship_id;
        }
    }
    
    [Serializable]
    public partial class UserWarshipBattleEnergyInfo : NetworkMessage {
        public static int[] Id = { 1373,23 };
        public static Ctrl VC;
        public RoundFighterBriefInfo m_p1_info;
        public RoundFighterBriefInfo m_p2_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_p1_info = new RoundFighterBriefInfo();
                m_p1_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_p2_info = new RoundFighterBriefInfo();
                m_p2_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_p1_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_p2_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(UserWarshipBattleEnergyInfo source) {
            m_p1_info = source.m_p1_info;
            m_p2_info = source.m_p2_info;
        }
    }
    
    [Serializable]
    public partial class KvkPreStepConvertNtfInfo : NetworkMessage {
        public static int[] Id = { 1379,23 };
        public static Ctrl VC;
        public SByte m_new_step;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_step = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_step);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreStepConvertNtfInfo source) {
            m_new_step = source.m_new_step;
        }
    }
    
    [Serializable]
    public partial class ExchangeCampAutoUseNtfInfo : NetworkMessage {
        public static int[] Id = { 1385,23 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Int32 m_exchange_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
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
            if (sp.TryRead(2)) {m_exchange_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_exchange_id);}
            sp.EnEnd();
        }
        public void CopyFrom(ExchangeCampAutoUseNtfInfo source) {
            m_act_id = source.m_act_id;
            m_reward = source.m_reward;
            m_exchange_id = source.m_exchange_id;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardLevelStatus : NetworkMessage {
        public static int[] Id = { 1391,23 };
        public static Ctrl VC;
        public Int16 m_cur_level;
        public Int32 m_cur_point;
        public Int32 m_need_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_point = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_need_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_level);}
            if (sp.TryWrite(1)) {sp.Write(m_cur_point);}
            if (sp.TryWrite(2)) {sp.Write(m_need_point);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardLevelStatus source) {
            m_cur_level = source.m_cur_level;
            m_cur_point = source.m_cur_point;
            m_need_point = source.m_need_point;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardAckInfo : NetworkMessage {
        public static int[] Id = { 1397,23 };
        public static Ctrl VC;
        public List<AllianceBoardSlotInfo> m_task_board = new List<AllianceBoardSlotInfo>();
        public AllianceBoardUserStatusInfo m_self_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_board.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardSlotInfo tmp = new AllianceBoardSlotInfo();
                    tmp.Decode(sp);
                    m_task_board.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_self_status = new AllianceBoardUserStatusInfo();
                m_self_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_board.Count);
                for (int i = 0; i != m_task_board.Count; ++i) {
                    m_task_board[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardAckInfo source) {
            m_task_board = source.m_task_board;
            m_self_status = source.m_self_status;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardSlotFlushNtfInfo : NetworkMessage {
        public static int[] Id = { 1403,23 };
        public static Ctrl VC;
        public List<AllianceBoardSlotInfo> m_list = new List<AllianceBoardSlotInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardSlotInfo tmp = new AllianceBoardSlotInfo();
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
        public void CopyFrom(CampAllianceBoardSlotFlushNtfInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardLevelRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1409,23 };
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
        public void CopyFrom(CampAllianceBoardLevelRewardReqInfo source) {
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class KvkRanklistAckInfo : NetworkMessage {
        public static int[] Id = { 1415,23 };
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
        public void CopyFrom(KvkRanklistAckInfo source) {
            m_ranks = source.m_ranks;
        }
    }
    
    [Serializable]
    public partial class BatchGetRtfMailAckInfo : NetworkMessage {
        public static int[] Id = { 1421,23 };
        public static Ctrl VC;
        public List<RtfMailInfo> m_mail_list = new List<RtfMailInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_mail_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RtfMailInfo tmp = new RtfMailInfo();
                    tmp.Decode(sp);
                    m_mail_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_mail_list.Count);
                for (int i = 0; i != m_mail_list.Count; ++i) {
                    m_mail_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BatchGetRtfMailAckInfo source) {
            m_mail_list = source.m_mail_list;
        }
    }
    
    [Serializable]
    public partial class InstantFinishAsTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1427,23 };
        public static Ctrl VC;
        public Int16 m_class;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_class = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_class);}
            sp.EnEnd();
        }
        public void CopyFrom(InstantFinishAsTaskReqInfo source) {
            m_class = source.m_class;
        }
    }
    
    [Serializable]
    public partial class AsTaskScoreRankInfoReq : NetworkMessage {
        public static int[] Id = { 1433,23 };
        public static Ctrl VC;
        public Int32 m_begin;
        public Int32 m_end;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_begin = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_begin);}
            if (sp.TryWrite(1)) {sp.Write(m_end);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskScoreRankInfoReq source) {
            m_begin = source.m_begin;
            m_end = source.m_end;
        }
    }
    
    [Serializable]
    public partial class TroopTrainingCapInfo : NetworkMessage {
        public static int[] Id = { 1439,24 };
        public static Ctrl VC;
        public Int32 m_bonus_times;
        public Int32 m_last_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_bonus_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_last_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_bonus_times);}
            if (sp.TryWrite(1)) {sp.Write(m_last_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopTrainingCapInfo source) {
            m_bonus_times = source.m_bonus_times;
            m_last_item_id = source.m_last_item_id;
        }
    }
    
    [Serializable]
    public partial class UserShameSimpleNtfInfo : NetworkMessage {
        public static int[] Id = { 1445,25 };
        public static Ctrl VC;
        public List<UserShameSimpleInfo> m_shame_target = new List<UserShameSimpleInfo>();
        public UserShameSimpleInfo m_self_shame;
        public List<UserShamePtInfo> m_shame_point_detail = new List<UserShamePtInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_shame_target.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserShameSimpleInfo tmp = new UserShameSimpleInfo();
                    tmp.Decode(sp);
                    m_shame_target.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_self_shame = new UserShameSimpleInfo();
                m_self_shame.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_shame_point_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserShamePtInfo tmp = new UserShamePtInfo();
                    tmp.Decode(sp);
                    m_shame_point_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_shame_target.Count);
                for (int i = 0; i != m_shame_target.Count; ++i) {
                    m_shame_target[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_shame.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_shame_point_detail.Count);
                for (int i = 0; i != m_shame_point_detail.Count; ++i) {
                    m_shame_point_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserShameSimpleNtfInfo source) {
            m_shame_target = source.m_shame_target;
            m_self_shame = source.m_self_shame;
            m_shame_point_detail = source.m_shame_point_detail;
        }
    }
    
    [Serializable]
    public partial class WeaponNtf : NetworkMessage {
        public static int[] Id = { 1451,25 };
        public static Ctrl VC;
        public Int16 m_action_type;
        public Int64 m_player_id;
        public WeaponInfo m_weapon;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                m_weapon = new WeaponInfo();
                m_weapon.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action_type);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_weapon.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponNtf source) {
            m_action_type = source.m_action_type;
            m_player_id = source.m_player_id;
            m_weapon = source.m_weapon;
        }
    }
    
    [Serializable]
    public partial class WeaponUnequipReqInfo : NetworkMessage {
        public static int[] Id = { 1457,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int64 m_replace;
        public SByte m_cost_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_replace = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cost_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_replace);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_type);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponUnequipReqInfo source) {
            m_id = source.m_id;
            m_replace = source.m_replace;
            m_cost_type = source.m_cost_type;
        }
    }
    
    [Serializable]
    public partial class TroopPowerDetail : NetworkMessage {
        public static int[] Id = { 1463,25 };
        public static Ctrl VC;
        public Int16 m_troop_id;
        public Int64 m_e_dps;
        public Int64 m_e_hp;
        public Int64 m_e_power;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_troop_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_e_dps = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_e_hp = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_e_power = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_troop_id);}
            if (sp.TryWrite(1)) {sp.Write(m_e_dps);}
            if (sp.TryWrite(2)) {sp.Write(m_e_hp);}
            if (sp.TryWrite(3)) {sp.Write(m_e_power);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopPowerDetail source) {
            m_troop_id = source.m_troop_id;
            m_e_dps = source.m_e_dps;
            m_e_hp = source.m_e_hp;
            m_e_power = source.m_e_power;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomUnlockFurnitureInfo : NetworkMessage {
        public static int[] Id = { 1469,25 };
        public static Ctrl VC;
        public List<Int32> m_unlocked_furniture = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_unlocked_furniture.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_unlocked_furniture.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_unlocked_furniture.Count);
                for (int i = 0; i != m_unlocked_furniture.Count; ++i) {
                    sp.Write(m_unlocked_furniture[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomUnlockFurnitureInfo source) {
            m_unlocked_furniture = source.m_unlocked_furniture;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomFurnitureInfo : NetworkMessage {
        public static int[] Id = { 1475,25 };
        public static Ctrl VC;
        public Int32 m_r_id;
        public List<CaptainRoomFurniture> m_furnitures = new List<CaptainRoomFurniture>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_r_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
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
            if (sp.TryWrite(1)) {
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
        public void CopyFrom(CaptainRoomFurnitureInfo source) {
            m_r_id = source.m_r_id;
            m_furnitures = source.m_furnitures;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomStoryInfo : NetworkMessage {
        public static int[] Id = { 1481,25 };
        public static Ctrl VC;
        public Int32 m_c_id;
        public List<CaptainRoomStoryLineInfo> m_s_lines = new List<CaptainRoomStoryLineInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_c_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_s_lines.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptainRoomStoryLineInfo tmp = new CaptainRoomStoryLineInfo();
                    tmp.Decode(sp);
                    m_s_lines.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_c_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_s_lines.Count);
                for (int i = 0; i != m_s_lines.Count; ++i) {
                    m_s_lines[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomStoryInfo source) {
            m_c_id = source.m_c_id;
            m_s_lines = source.m_s_lines;
        }
    }
    
    [Serializable]
    public partial class GlobalRanklistInfo : NetworkMessage {
        public static int[] Id = { 1487,27 };
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
        public void CopyFrom(GlobalRanklistInfo source) {
            m_ranks = source.m_ranks;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardSetTaskFilterReqInfo : NetworkMessage {
        public static int[] Id = { 1493,27 };
        public static Ctrl VC;
        public Int32 m_task_id_1;
        public Int32 m_task_id_2;
        public Int32 m_task_id_3;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id_1 = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_task_id_2 = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_task_id_3 = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id_1);}
            if (sp.TryWrite(1)) {sp.Write(m_task_id_2);}
            if (sp.TryWrite(2)) {sp.Write(m_task_id_3);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardSetTaskFilterReqInfo source) {
            m_task_id_1 = source.m_task_id_1;
            m_task_id_2 = source.m_task_id_2;
            m_task_id_3 = source.m_task_id_3;
        }
    }
    
    [Serializable]
    public partial class ModifyGenderReqInfo : NetworkMessage {
        public static int[] Id = { 1499,28 };
        public static Ctrl VC;
        public SByte m_new_gender;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_new_gender = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_new_gender);}
            sp.EnEnd();
        }
        public void CopyFrom(ModifyGenderReqInfo source) {
            m_new_gender = source.m_new_gender;
        }
    }
    
    [Serializable]
    public partial class UserArmyBannerUpgradeInfo : NetworkMessage {
        public static int[] Id = { 1513,29 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(UserArmyBannerUpgradeInfo source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class SendGiftReqInfo : NetworkMessage {
        public static int[] Id = { 1536,32 };
        public static Ctrl VC;
        public Int64 m_target_user_id;
        public Int32 m_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_target_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_target_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            sp.EnEnd();
        }
        public void CopyFrom(SendGiftReqInfo source) {
            m_target_user_id = source.m_target_user_id;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class AgentWgtFirstGetTalentReqInfo : NetworkMessage {
        public static int[] Id = { 1594,33 };
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
        public void CopyFrom(AgentWgtFirstGetTalentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_box_id = source.m_box_id;
        }
    }
    
    [Serializable]
    public partial class AgentWgtSaveTalentReqInfo : NetworkMessage {
        public static int[] Id = { 1600,33 };
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
        public void CopyFrom(AgentWgtSaveTalentReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_box_id = source.m_box_id;
        }
    }
    
    [Serializable]
    public partial class NbpDrawLevelRewardsReqInfo : NetworkMessage {
        public static int[] Id = { 1638,34 };
        public static Ctrl VC;
        public Int32 m_level;
        public Boolean m_is_premium;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_premium = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_is_premium);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpDrawLevelRewardsReqInfo source) {
            m_level = source.m_level;
            m_is_premium = source.m_is_premium;
        }
    }
    
    [Serializable]
    public partial class MonopolyRewardCfg : NetworkMessage {
        public static int[] Id = { 1645,35 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_type;
        public Int32 m_reward_item;
        public String m_bg = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_reward_item = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_bg = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_type);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_item);}
            if (sp.TryWrite(3)) {sp.Write(m_bg);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyRewardCfg source) {
            m_id = source.m_id;
            m_type = source.m_type;
            m_reward_item = source.m_reward_item;
            m_bg = source.m_bg;
        }
    }
    
    [Serializable]
    public partial class MonopolyPlayerInfo : NetworkMessage {
        public static int[] Id = { 1652,35 };
        public static Ctrl VC;
        public Int32 m_grid_id;
        public Int32 m_score;
        public Int32 m_event_type;
        public Int32 m_event_data;
        public List<Int32> m_drew_rewards_score = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_grid_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_event_type = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_event_data = sp.ReadInt32();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_rewards_score.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_rewards_score.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_grid_id);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_event_type);}
            if (sp.TryWrite(3)) {sp.Write(m_event_data);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_rewards_score.Count);
                for (int i = 0; i != m_drew_rewards_score.Count; ++i) {
                    sp.Write(m_drew_rewards_score[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyPlayerInfo source) {
            m_grid_id = source.m_grid_id;
            m_score = source.m_score;
            m_event_type = source.m_event_type;
            m_event_data = source.m_event_data;
            m_drew_rewards_score = source.m_drew_rewards_score;
        }
    }
    
    [Serializable]
    public partial class KvkShopItemInfo : NetworkMessage {
        public static int[] Id = { 1668,36 };
        public static Ctrl VC;
        public Int32 m_id;
        public Boolean m_is_bought;
        public Int32 m_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_is_bought = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_bought);}
            if (sp.TryWrite(2)) {sp.Write(m_index);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkShopItemInfo source) {
            m_id = source.m_id;
            m_is_bought = source.m_is_bought;
            m_index = source.m_index;
        }
    }
    
    [Serializable]
    public partial class DeleteCharacterReqInfo : NetworkMessage {
        public static int[] Id = { 1674,38 };
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
        public void CopyFrom(DeleteCharacterReqInfo source) {
            m_character_id = source.m_character_id;
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class GetPrivateCustomRewardAckInfo : NetworkMessage {
        public static int[] Id = { 1685,38 };
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
        public void CopyFrom(GetPrivateCustomRewardAckInfo source) {
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class EquipChooseExclusiveTalentReqInfo : NetworkMessage {
        public static int[] Id = { 1699,40 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_exclusive_talent_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_exclusive_talent_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_exclusive_talent_type);}
            sp.EnEnd();
        }
        public void CopyFrom(EquipChooseExclusiveTalentReqInfo source) {
            m_id = source.m_id;
            m_exclusive_talent_type = source.m_exclusive_talent_type;
        }
    }
    
    [Serializable]
    public partial class UnlockCitySkinReqInfo : NetworkMessage {
        public static int[] Id = { 1705,40 };
        public static Ctrl VC;
        public Int16 m_city_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_city_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_city_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(UnlockCitySkinReqInfo source) {
            m_city_skin_id = source.m_city_skin_id;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeItemExchangeReqInfo : NetworkMessage {
        public static int[] Id = { 1714,41 };
        public static Ctrl VC;
        public Int32 m_order;
        public Int32 m_iap_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_iap_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_iap_type);}
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeItemExchangeReqInfo source) {
            m_order = source.m_order;
            m_iap_type = source.m_iap_type;
        }
    }
    
    [Serializable]
    public partial class EndAwardsCfg : NetworkMessage {
        public static int[] Id = { 1724,41 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_amount;
        public Boolean m_is_available;
        public Int32 m_set_times;
        public Int32 m_max_set_times;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_is_available = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_set_times = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_max_set_times = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            if (sp.TryWrite(2)) {sp.Write(m_is_available);}
            if (sp.TryWrite(3)) {sp.Write(m_set_times);}
            if (sp.TryWrite(4)) {sp.Write(m_max_set_times);}
            sp.EnEnd();
        }
        public void CopyFrom(EndAwardsCfg source) {
            m_id = source.m_id;
            m_amount = source.m_amount;
            m_is_available = source.m_is_available;
            m_set_times = source.m_set_times;
            m_max_set_times = source.m_max_set_times;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalBuyCostItemReqInfo : NetworkMessage {
        public static int[] Id = { 1730,41 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_buy_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_buy_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_buy_num);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalBuyCostItemReqInfo source) {
            m_item_id = source.m_item_id;
            m_buy_num = source.m_buy_num;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeSetCoreRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1737,42 };
        public static Ctrl VC;
        public Int32 m_core_reward_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_core_reward_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_core_reward_index);}
            sp.EnEnd();
        }
        public void CopyFrom(StrangeCubeSetCoreRewardReqInfo source) {
            m_core_reward_index = source.m_core_reward_index;
        }
    }
    
    [Serializable]
    public partial class WarMarketExchangeItemCfg : NetworkMessage {
        public static int[] Id = { 1743,42 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_reward_id;
        public Int32 m_reward_num;
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int32 m_discount;
        public Int32 m_return_ratio;
        public Int32 m_tab_id;
        public Int32 m_sort_id;
        public Int16 m_show_repeat;
        public Boolean m_is_luck_discount;
        public Boolean m_is_luck_discount_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_reward_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_reward_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_discount = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_return_ratio = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_tab_id = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_sort_id = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_show_repeat = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_is_luck_discount = sp.ReadBoolean();}
            if (sp.TryRead(11)) {m_is_luck_discount_item = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_id);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_num);}
            if (sp.TryWrite(3)) {sp.Write(m_item_id);}
            if (sp.TryWrite(4)) {sp.Write(m_item_num);}
            if (sp.TryWrite(5)) {sp.Write(m_discount);}
            if (sp.TryWrite(6)) {sp.Write(m_return_ratio);}
            if (sp.TryWrite(7)) {sp.Write(m_tab_id);}
            if (sp.TryWrite(8)) {sp.Write(m_sort_id);}
            if (sp.TryWrite(9)) {sp.Write(m_show_repeat);}
            if (sp.TryWrite(10)) {sp.Write(m_is_luck_discount);}
            if (sp.TryWrite(11)) {sp.Write(m_is_luck_discount_item);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketExchangeItemCfg source) {
            m_id = source.m_id;
            m_reward_id = source.m_reward_id;
            m_reward_num = source.m_reward_num;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_discount = source.m_discount;
            m_return_ratio = source.m_return_ratio;
            m_tab_id = source.m_tab_id;
            m_sort_id = source.m_sort_id;
            m_show_repeat = source.m_show_repeat;
            m_is_luck_discount = source.m_is_luck_discount;
            m_is_luck_discount_item = source.m_is_luck_discount_item;
        }
    }
    
    [Serializable]
    public partial class WarMarketBuyBoxReqInfo : NetworkMessage {
        public static int[] Id = { 1749,42 };
        public static Ctrl VC;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketBuyBoxReqInfo source) {
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignPlayerInfo : NetworkMessage {
        public static int[] Id = { 1755,44 };
        public static Ctrl VC;
        public Int32 m_score;
        public List<Int32> m_drew_reward_scores = new List<Int32>();
        public List<BaseTaskCampaignInfo> m_tasks = new List<BaseTaskCampaignInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_reward_scores.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_reward_scores.Add(tmp);
                }
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tasks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_tasks.Add(tmp);
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
                sp.Write((UInt16)m_drew_reward_scores.Count);
                for (int i = 0; i != m_drew_reward_scores.Count; ++i) {
                    sp.Write(m_drew_reward_scores[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(LineTaskCampaignPlayerInfo source) {
            m_score = source.m_score;
            m_drew_reward_scores = source.m_drew_reward_scores;
            m_tasks = source.m_tasks;
        }
    }
    
    [Serializable]
    public partial class LegendOptionalAwardItemCfg : NetworkMessage {
        public static int[] Id = { 1770,44 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_item_id;
        public Int32 m_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendOptionalAwardItemCfg source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 1777,44 };
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
        public void CopyFrom(LegendRecruitShopBuyReqInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class VoteCampaignInfo : NetworkMessage {
        public static int[] Id = { 1807,44 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public VoteCampaignCfg m_cfg;
        public List<VoteCampaignItem> m_vote_items = new List<VoteCampaignItem>();
        public Int16 m_add_score;
        public String m_suggestion_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new VoteCampaignCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_vote_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VoteCampaignItem tmp = new VoteCampaignItem();
                    tmp.Decode(sp);
                    m_vote_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_add_score = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_suggestion_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_vote_items.Count);
                for (int i = 0; i != m_vote_items.Count; ++i) {
                    m_vote_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_add_score);}
            if (sp.TryWrite(4)) {sp.Write(m_suggestion_content);}
            sp.EnEnd();
        }
        public void CopyFrom(VoteCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
            m_vote_items = source.m_vote_items;
            m_add_score = source.m_add_score;
            m_suggestion_content = source.m_suggestion_content;
        }
    }
    
    [Serializable]
    public partial class NbpCampaignTaskInfo : NetworkMessage {
        public static int[] Id = { 1813,45 };
        public static Ctrl VC;
        public Int32 m_order;
        public List<BaseTaskCampaignInfo> m_tasks = new List<BaseTaskCampaignInfo>();
        public String m_icon = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_tasks.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTaskCampaignInfo tmp = new BaseTaskCampaignInfo();
                    tmp.Decode(sp);
                    m_tasks.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_tasks.Count);
                for (int i = 0; i != m_tasks.Count; ++i) {
                    m_tasks[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpCampaignTaskInfo source) {
            m_order = source.m_order;
            m_tasks = source.m_tasks;
            m_icon = source.m_icon;
        }
    }
    
    [Serializable]
    public partial class CityDecorationInfo : NetworkMessage {
        public static int[] Id = { 1887,46 };
        public static Ctrl VC;
        public SByte m_type;
        public Int16 m_id;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_id);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(CityDecorationInfo source) {
            m_type = source.m_type;
            m_id = source.m_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class RecycleCampaignCfg : NetworkMessage {
        public static int[] Id = { 1893,46 };
        public static Ctrl VC;
        public List<RecycleCampaignRecycleCfg> m_recycle_cfgs = new List<RecycleCampaignRecycleCfg>();
        public List<RecycleCampaignExchangeCfg> m_exchange_cfgs = new List<RecycleCampaignExchangeCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_recycle_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RecycleCampaignRecycleCfg tmp = new RecycleCampaignRecycleCfg();
                    tmp.Decode(sp);
                    m_recycle_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RecycleCampaignExchangeCfg tmp = new RecycleCampaignExchangeCfg();
                    tmp.Decode(sp);
                    m_exchange_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_recycle_cfgs.Count);
                for (int i = 0; i != m_recycle_cfgs.Count; ++i) {
                    m_recycle_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_cfgs.Count);
                for (int i = 0; i != m_exchange_cfgs.Count; ++i) {
                    m_exchange_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RecycleCampaignCfg source) {
            m_recycle_cfgs = source.m_recycle_cfgs;
            m_exchange_cfgs = source.m_exchange_cfgs;
        }
    }
    
    [Serializable]
    public partial class AgentTalentSchemeApplyReqInfo : NetworkMessage {
        public static int[] Id = { 1899,46 };
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
        public void CopyFrom(AgentTalentSchemeApplyReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignAsCfg : NetworkMessage {
        public static int[] Id = { 1905,46 };
        public static Ctrl VC;
        public SByte m_id;
        public Int32 m_as_score;
        public Int32 m_player_score;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_as_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_player_score = sp.ReadInt32();}
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
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_as_score);}
            if (sp.TryWrite(2)) {sp.Write(m_player_score);}
            if (sp.TryWrite(3)) {
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
        public void CopyFrom(AllianceTreasureCampaignAsCfg source) {
            m_id = source.m_id;
            m_as_score = source.m_as_score;
            m_player_score = source.m_player_score;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class WarMarketGetOutputAckInfo : NetworkMessage {
        public static int[] Id = { 1911,47 };
        public static Ctrl VC;
        public Int32 m_advanced_reward_weight;
        public List<OutItemInfo> m_advanced_out_items = new List<OutItemInfo>();
        public Int32 m_normal_reward_weight;
        public List<OutItemInfo> m_normal_out_items = new List<OutItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_advanced_reward_weight = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_advanced_out_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OutItemInfo tmp = new OutItemInfo();
                    tmp.Decode(sp);
                    m_advanced_out_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_normal_reward_weight = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_out_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OutItemInfo tmp = new OutItemInfo();
                    tmp.Decode(sp);
                    m_normal_out_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_advanced_reward_weight);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_advanced_out_items.Count);
                for (int i = 0; i != m_advanced_out_items.Count; ++i) {
                    m_advanced_out_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_normal_reward_weight);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_out_items.Count);
                for (int i = 0; i != m_normal_out_items.Count; ++i) {
                    m_normal_out_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketGetOutputAckInfo source) {
            m_advanced_reward_weight = source.m_advanced_reward_weight;
            m_advanced_out_items = source.m_advanced_out_items;
            m_normal_reward_weight = source.m_normal_reward_weight;
            m_normal_out_items = source.m_normal_out_items;
        }
    }
    
    [Serializable]
    public partial class PlayerReturnEventTaskRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1920,47 };
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
        public void CopyFrom(PlayerReturnEventTaskRewardReqInfo source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerCampaignInfo : NetworkMessage {
        public static int[] Id = { 1985,49 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<QuestionAnswerStepCfg> m_step_cfgs = new List<QuestionAnswerStepCfg>();
        public List<QuestionAnswerStepInfo> m_steps = new List<QuestionAnswerStepInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_step_cfgs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestionAnswerStepCfg tmp = new QuestionAnswerStepCfg();
                    tmp.Decode(sp);
                    m_step_cfgs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_steps.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestionAnswerStepInfo tmp = new QuestionAnswerStepInfo();
                    tmp.Decode(sp);
                    m_steps.Add(tmp);
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
                sp.Write((UInt16)m_step_cfgs.Count);
                for (int i = 0; i != m_step_cfgs.Count; ++i) {
                    m_step_cfgs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_steps.Count);
                for (int i = 0; i != m_steps.Count; ++i) {
                    m_steps[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_step_cfgs = source.m_step_cfgs;
            m_steps = source.m_steps;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStartAckInfo : NetworkMessage {
        public static int[] Id = { 1991,49 };
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
        public void CopyFrom(QuestionAnswerStartAckInfo source) {
            m_step_info = source.m_step_info;
        }
    }
    
    [Serializable]
    public partial class FlipCardConfig : NetworkMessage {
        public static int[] Id = { 1997,49 };
        public static Ctrl VC;
        public FlipCardLayerConfig m_layer_config;
        public List<FlipCardExtraRewardConfig> m_extra_reward_configs = new List<FlipCardExtraRewardConfig>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_layer_config = new FlipCardLayerConfig();
                m_layer_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward_configs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlipCardExtraRewardConfig tmp = new FlipCardExtraRewardConfig();
                    tmp.Decode(sp);
                    m_extra_reward_configs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_layer_config.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward_configs.Count);
                for (int i = 0; i != m_extra_reward_configs.Count; ++i) {
                    m_extra_reward_configs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardConfig source) {
            m_layer_config = source.m_layer_config;
            m_extra_reward_configs = source.m_extra_reward_configs;
        }
    }
    
    [Serializable]
    public partial class FlipCardCellInfo : NetworkMessage {
        public static int[] Id = { 2003,49 };
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
        public void CopyFrom(FlipCardCellInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class FlipCardGetExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2009,49 };
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
        public void CopyFrom(FlipCardGetExtraRewardReqInfo source) {
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponAttrInfo : NetworkMessage {
        public static int[] Id = { 2041,50 };
        public static Ctrl VC;
        public Int32 m_effect_id;
        public Int32 m_value;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_effect_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_value = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_effect_id);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponAttrInfo source) {
            m_effect_id = source.m_effect_id;
            m_value = source.m_value;
        }
    }
    
    [Serializable]
    public partial class SubmarineExploreReqInfo : NetworkMessage {
        public static int[] Id = { 2047,50 };
        public static Ctrl VC;
        public Int16 m_officer_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_officer_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_officer_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SubmarineExploreReqInfo source) {
            m_officer_id = source.m_officer_id;
        }
    }
    
    [Serializable]
    public partial class SetBattleBannerReqInfo : NetworkMessage {
        public static int[] Id = { 2057,53 };
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
        public void CopyFrom(SetBattleBannerReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class RaidTrialOfficerConfig : NetworkMessage {
        public static int[] Id = { 2115,54 };
        public static Ctrl VC;
        public Int16 m_officer_id;
        public Int32 m_unlock_level;
        public Int32 m_skin_id;
        public Int16 m_level;
        public Int16 m_star;
        public Int16 m_rank;
        public Int16 m_study_level;
        public List<Int32> m_talent_id_list1 = new List<Int32>();
        public List<Int32> m_talent_id_list2 = new List<Int32>();
        public List<Int32> m_talent_id_list3 = new List<Int32>();
        public List<Int16> m_skill_levels = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_officer_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_unlock_level = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_skin_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_star = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_study_level = sp.ReadInt16();}
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_talent_id_list1.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_talent_id_list1.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_talent_id_list2.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_talent_id_list2.Add(tmp);
                }
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_talent_id_list3.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_talent_id_list3.Add(tmp);
                }
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_skill_levels.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_skill_levels.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_officer_id);}
            if (sp.TryWrite(1)) {sp.Write(m_unlock_level);}
            if (sp.TryWrite(2)) {sp.Write(m_skin_id);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_star);}
            if (sp.TryWrite(5)) {sp.Write(m_rank);}
            if (sp.TryWrite(6)) {sp.Write(m_study_level);}
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_talent_id_list1.Count);
                for (int i = 0; i != m_talent_id_list1.Count; ++i) {
                    sp.Write(m_talent_id_list1[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_talent_id_list2.Count);
                for (int i = 0; i != m_talent_id_list2.Count; ++i) {
                    sp.Write(m_talent_id_list2[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_talent_id_list3.Count);
                for (int i = 0; i != m_talent_id_list3.Count; ++i) {
                    sp.Write(m_talent_id_list3[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_skill_levels.Count);
                for (int i = 0; i != m_skill_levels.Count; ++i) {
                    sp.Write(m_skill_levels[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RaidTrialOfficerConfig source) {
            m_officer_id = source.m_officer_id;
            m_unlock_level = source.m_unlock_level;
            m_skin_id = source.m_skin_id;
            m_level = source.m_level;
            m_star = source.m_star;
            m_rank = source.m_rank;
            m_study_level = source.m_study_level;
            m_talent_id_list1 = source.m_talent_id_list1;
            m_talent_id_list2 = source.m_talent_id_list2;
            m_talent_id_list3 = source.m_talent_id_list3;
            m_skill_levels = source.m_skill_levels;
        }
    }
    
    [Serializable]
    public partial class RaidGroupAgentInfo : NetworkMessage {
        public static int[] Id = { 2121,54 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Boolean m_is_trial;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_trial = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_trial);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidGroupAgentInfo source) {
            m_agent_id = source.m_agent_id;
            m_is_trial = source.m_is_trial;
        }
    }
    
    [Serializable]
    public partial class RaidHistoryEntryInfo : NetworkMessage {
        public static int[] Id = { 2127,54 };
        public static Ctrl VC;
        public Int32 m_level;
        public Int32 m_level_id;
        public Int64 m_time;
        public RaidChallengePlayerStatInfo m_attacker;
        public RaidChallengePlayerStatInfo m_defender;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_level_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                m_attacker = new RaidChallengePlayerStatInfo();
                m_attacker.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_defender = new RaidChallengePlayerStatInfo();
                m_defender.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_level_id);}
            if (sp.TryWrite(2)) {sp.Write(m_time);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_attacker.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_defender.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidHistoryEntryInfo source) {
            m_level = source.m_level;
            m_level_id = source.m_level_id;
            m_time = source.m_time;
            m_attacker = source.m_attacker;
            m_defender = source.m_defender;
        }
    }
    
    [Serializable]
    public partial class AgentBreakthroughLevelUpReqInfo : NetworkMessage {
        public static int[] Id = { 2135,55 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_item_id;
        public Int32 m_item_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_num);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentBreakthroughLevelUpReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
        }
    }
    
    [Serializable]
    public partial class MuseumInfo : NetworkMessage {
        public static int[] Id = { 2150,56 };
        public static Ctrl VC;
        public List<Int32> m_booths = new List<Int32>();
        public MuseumArtifactMarketInfo m_market;
        public MuseumRewardInfo m_daily_reward_info;
        public List<MuseumArtifactInfo> m_artifacts = new List<MuseumArtifactInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_booths.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_booths.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                m_market = new MuseumArtifactMarketInfo();
                m_market.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_daily_reward_info = new MuseumRewardInfo();
                m_daily_reward_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_artifacts.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MuseumArtifactInfo tmp = new MuseumArtifactInfo();
                    tmp.Decode(sp);
                    m_artifacts.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_booths.Count);
                for (int i = 0; i != m_booths.Count; ++i) {
                    sp.Write(m_booths[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_market.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_daily_reward_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_artifacts.Count);
                for (int i = 0; i != m_artifacts.Count; ++i) {
                    m_artifacts[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(MuseumInfo source) {
            m_booths = source.m_booths;
            m_market = source.m_market;
            m_daily_reward_info = source.m_daily_reward_info;
            m_artifacts = source.m_artifacts;
        }
    }
    
    [Serializable]
    public partial class OverturnCampaignInfo : NetworkMessage {
        public static int[] Id = { 2156,57 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public OverturnBaseInfo m_base_info;
        public OverturnBattlePassportInfo m_battle_passport_info;
        public OverturnShopInfo m_shop_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_base_info = new OverturnBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_battle_passport_info = new OverturnBattlePassportInfo();
                m_battle_passport_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_shop_info = new OverturnShopInfo();
                m_shop_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_battle_passport_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_shop_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(OverturnCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_base_info = source.m_base_info;
            m_battle_passport_info = source.m_battle_passport_info;
            m_shop_info = source.m_shop_info;
        }
    }
    
    [Serializable]
    public partial class OverturnFlipReqInfo : NetworkMessage {
        public static int[] Id = { 2164,57 };
        public static Ctrl VC;
        public List<SByte> m_x = new List<SByte>();
        public List<SByte> m_y = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_x.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_x.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_y.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_y.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_x.Count);
                for (int i = 0; i != m_x.Count; ++i) {
                    sp.Write(m_x[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_y.Count);
                for (int i = 0; i != m_y.Count; ++i) {
                    sp.Write(m_y[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OverturnFlipReqInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class WantedInfoNtf : NetworkMessage {
        public static int[] Id = { 2171,58 };
        public static Ctrl VC;
        public List<WantedUserInfo> m_users = new List<WantedUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_users.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    WantedUserInfo tmp = new WantedUserInfo();
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
        public void CopyFrom(WantedInfoNtf source) {
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class ItemUpgradeNtfInfo : NetworkMessage {
        public static int[] Id = { 2177,59 };
        public static Ctrl VC;
        public List<ItemUpgradeRecord> m_records = new List<ItemUpgradeRecord>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_records.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemUpgradeRecord tmp = new ItemUpgradeRecord();
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
        public void CopyFrom(ItemUpgradeNtfInfo source) {
            m_records = source.m_records;
        }
    }
    
    [Serializable]
    public partial class SetSelectedCitySkinReqInfo : NetworkMessage {
        public static int[] Id = { 2189,59 };
        public static Ctrl VC;
        public List<Int16> m_ids = new List<Int16>();
        public List<SByte> m_stats = new List<SByte>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_ids.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_stats.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SByte tmp = sp.ReadSByte();
                    m_stats.Add(tmp);
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
                sp.Write((UInt16)m_stats.Count);
                for (int i = 0; i != m_stats.Count; ++i) {
                    sp.Write(m_stats[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SetSelectedCitySkinReqInfo source) {
            m_ids = source.m_ids;
            m_stats = source.m_stats;
        }
    }
    
    [Serializable]
    public partial class ChainGiftsCampaignInfo : NetworkMessage {
        public static int[] Id = { 2251,63 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public String m_score_pic = "";
        public Int32 m_total_score;
        public List<ChainGiftsCampaignNormalRewardInfo> m_reward_info_list = new List<ChainGiftsCampaignNormalRewardInfo>();
        public List<ChainGiftsCampaignRewardAdditionalInfo> m_reward_additional_info_list = new List<ChainGiftsCampaignRewardAdditionalInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_score_pic = sp.ReadString();}
            if (sp.TryRead(2)) {m_total_score = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ChainGiftsCampaignNormalRewardInfo tmp = new ChainGiftsCampaignNormalRewardInfo();
                    tmp.Decode(sp);
                    m_reward_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_additional_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ChainGiftsCampaignRewardAdditionalInfo tmp = new ChainGiftsCampaignRewardAdditionalInfo();
                    tmp.Decode(sp);
                    m_reward_additional_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_score_pic);}
            if (sp.TryWrite(2)) {sp.Write(m_total_score);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_info_list.Count);
                for (int i = 0; i != m_reward_info_list.Count; ++i) {
                    m_reward_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_additional_info_list.Count);
                for (int i = 0; i != m_reward_additional_info_list.Count; ++i) {
                    m_reward_additional_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ChainGiftsCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_score_pic = source.m_score_pic;
            m_total_score = source.m_total_score;
            m_reward_info_list = source.m_reward_info_list;
            m_reward_additional_info_list = source.m_reward_additional_info_list;
        }
    }
    
    [Serializable]
    public partial class FriendApplyInfo : NetworkMessage {
        public static int[] Id = { 2257,63 };
        public static Ctrl VC;
        public FriendUserInfo m_user_info;
        public SByte m_state;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_user_info = new FriendUserInfo();
                m_user_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_state = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_user_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_state);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendApplyInfo source) {
            m_user_info = source.m_user_info;
            m_state = source.m_state;
        }
    }
    
    [Serializable]
    public partial class FriendChangeNtfInfo : NetworkMessage {
        public static int[] Id = { 2263,63 };
        public static Ctrl VC;
        public SByte m_change_type;
        public List<FriendUserInfo> m_friend_list = new List<FriendUserInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_change_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_friend_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendUserInfo tmp = new FriendUserInfo();
                    tmp.Decode(sp);
                    m_friend_list.Add(tmp);
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
                sp.Write((UInt16)m_friend_list.Count);
                for (int i = 0; i != m_friend_list.Count; ++i) {
                    m_friend_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FriendChangeNtfInfo source) {
            m_change_type = source.m_change_type;
            m_friend_list = source.m_friend_list;
        }
    }
    
    [Serializable]
    public partial class FriendShopInfo : NetworkMessage {
        public static int[] Id = { 2269,63 };
        public static Ctrl VC;
        public List<FriendShopGoodsInfo> m_goods_list = new List<FriendShopGoodsInfo>();
        public Int64 m_next_refresh_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_goods_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendShopGoodsInfo tmp = new FriendShopGoodsInfo();
                    tmp.Decode(sp);
                    m_goods_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_next_refresh_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_goods_list.Count);
                for (int i = 0; i != m_goods_list.Count; ++i) {
                    m_goods_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_next_refresh_time);}
            sp.EnEnd();
        }
        public void CopyFrom(FriendShopInfo source) {
            m_goods_list = source.m_goods_list;
            m_next_refresh_time = source.m_next_refresh_time;
        }
    }
    
    [Serializable]
    public partial class PuzzleDrawReqInfo : NetworkMessage {
        public static int[] Id = { 2275,63 };
        public static Ctrl VC;
        public SByte m_draw_type;
        public SByte m_draw_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_draw_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_draw_count = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_draw_type);}
            if (sp.TryWrite(1)) {sp.Write(m_draw_count);}
            sp.EnEnd();
        }
        public void CopyFrom(PuzzleDrawReqInfo source) {
            m_draw_type = source.m_draw_type;
            m_draw_count = source.m_draw_count;
        }
    }
    
    [Serializable]
    public partial class AgentEquipResetEnhanceAckInfo : NetworkMessage {
        public static int[] Id = { 2287,64 };
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
        public void CopyFrom(AgentEquipResetEnhanceAckInfo source) {
            m_equip_info = source.m_equip_info;
        }
    }
    
    [Serializable]
    public partial class SetHomeEffectReqInfo : NetworkMessage {
        public static int[] Id = { 2293,64 };
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
        public void CopyFrom(SetHomeEffectReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AssetConvertToItemNtfInfo : NetworkMessage {
        public static int[] Id = { 2310,65 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_count;
        public List<ItemInfo> m_new_item_list = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_count = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_new_item_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_new_item_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_count);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_new_item_list.Count);
                for (int i = 0; i != m_new_item_list.Count; ++i) {
                    m_new_item_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AssetConvertToItemNtfInfo source) {
            m_item_id = source.m_item_id;
            m_item_count = source.m_item_count;
            m_new_item_list = source.m_new_item_list;
        }
    }
    
    [Serializable]
    public partial class SignInCampaignRewardConfig : NetworkMessage {
        public static int[] Id = { 2316,65 };
        public static Ctrl VC;
        public Int32 m_day;
        public List<ItemInfo> m_normal_reward_items = new List<ItemInfo>();
        public List<ItemInfo> m_advance_reward_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_day = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_normal_reward_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_normal_reward_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_advance_reward_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_advance_reward_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_day);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_normal_reward_items.Count);
                for (int i = 0; i != m_normal_reward_items.Count; ++i) {
                    m_normal_reward_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_advance_reward_items.Count);
                for (int i = 0; i != m_advance_reward_items.Count; ++i) {
                    m_advance_reward_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SignInCampaignRewardConfig source) {
            m_day = source.m_day;
            m_normal_reward_items = source.m_normal_reward_items;
            m_advance_reward_items = source.m_advance_reward_items;
        }
    }
    
    [Serializable]
    public partial class VideoRewardClaimHistory : NetworkMessage {
        public static int[] Id = { 2322,66 };
        public static Ctrl VC;
        public Int64 m_reward;
        public Int64 m_accumulated_reward;
        public Int64 m_create_time_sec;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_accumulated_reward = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_create_time_sec = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward);}
            if (sp.TryWrite(1)) {sp.Write(m_accumulated_reward);}
            if (sp.TryWrite(2)) {sp.Write(m_create_time_sec);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoRewardClaimHistory source) {
            m_reward = source.m_reward;
            m_accumulated_reward = source.m_accumulated_reward;
            m_create_time_sec = source.m_create_time_sec;
        }
    }
    
    [Serializable]
    public partial class VideoChannelRefreshVideoAccessStatusReqInfo : NetworkMessage {
        public static int[] Id = { 2328,66 };
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
        public void CopyFrom(VideoChannelRefreshVideoAccessStatusReqInfo source) {
            m_video_id = source.m_video_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoCommentListAckInfo : NetworkMessage {
        public static int[] Id = { 2334,66 };
        public static Ctrl VC;
        public List<VideoCommentInfo> m_comment_list = new List<VideoCommentInfo>();
        public Int32 m_total_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_comment_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoCommentInfo tmp = new VideoCommentInfo();
                    tmp.Decode(sp);
                    m_comment_list.Add(tmp);
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
                sp.Write((UInt16)m_comment_list.Count);
                for (int i = 0; i != m_comment_list.Count; ++i) {
                    m_comment_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_total_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoCommentListAckInfo source) {
            m_comment_list = source.m_comment_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDeleteVideoCommentAckInfo : NetworkMessage {
        public static int[] Id = { 2340,66 };
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
        public void CopyFrom(VideoChannelDeleteVideoCommentAckInfo source) {
            m_comment = source.m_comment;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetRewardClaimHistoryAckInfo : NetworkMessage {
        public static int[] Id = { 2346,66 };
        public static Ctrl VC;
        public List<VideoRewardClaimHistory> m_history_list = new List<VideoRewardClaimHistory>();
        public Int32 m_total_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_history_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoRewardClaimHistory tmp = new VideoRewardClaimHistory();
                    tmp.Decode(sp);
                    m_history_list.Add(tmp);
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
                sp.Write((UInt16)m_history_list.Count);
                for (int i = 0; i != m_history_list.Count; ++i) {
                    m_history_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_total_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetRewardClaimHistoryAckInfo source) {
            m_history_list = source.m_history_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetNewVideoListReqInfo : NetworkMessage {
        public static int[] Id = { 2352,66 };
        public static Ctrl VC;
        public Int32 m_start_rank;
        public Int32 m_end_rank;
        public SByte m_subchannel_type;
        public Int64 m_subchannel_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_subchannel_type = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_subchannel_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_end_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_subchannel_type);}
            if (sp.TryWrite(3)) {sp.Write(m_subchannel_id);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetNewVideoListReqInfo source) {
            m_start_rank = source.m_start_rank;
            m_end_rank = source.m_end_rank;
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetUserVideoListReqInfo : NetworkMessage {
        public static int[] Id = { 2358,66 };
        public static Ctrl VC;
        public String m_sort_type = "";
        public Int32 m_start_index;
        public Int32 m_end_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sort_type = sp.ReadString();}
            if (sp.TryRead(1)) {m_start_index = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sort_type);}
            if (sp.TryWrite(1)) {sp.Write(m_start_index);}
            if (sp.TryWrite(2)) {sp.Write(m_end_index);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetUserVideoListReqInfo source) {
            m_sort_type = source.m_sort_type;
            m_start_index = source.m_start_index;
            m_end_index = source.m_end_index;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetShopBuyLogAckInfo : NetworkMessage {
        public static int[] Id = { 2364,66 };
        public static Ctrl VC;
        public List<VideoChannelGetShopBuyLog> m_log_list = new List<VideoChannelGetShopBuyLog>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_log_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoChannelGetShopBuyLog tmp = new VideoChannelGetShopBuyLog();
                    tmp.Decode(sp);
                    m_log_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_log_list.Count);
                for (int i = 0; i != m_log_list.Count; ++i) {
                    m_log_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetShopBuyLogAckInfo source) {
            m_log_list = source.m_log_list;
        }
    }
    
    [Serializable]
    public partial class VideoChannelCommitVideoAckInfo : NetworkMessage {
        public static int[] Id = { 2370,66 };
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
        public void CopyFrom(VideoChannelCommitVideoAckInfo source) {
            m_video = source.m_video;
        }
    }
    
    [Serializable]
    public partial class UserMedalQuestList : NetworkMessage {
        public static int[] Id = { 2395,68 };
        public static Ctrl VC;
        public List<UserMedalQuestInfo> m_quest_list = new List<UserMedalQuestInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_quest_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserMedalQuestInfo tmp = new UserMedalQuestInfo();
                    tmp.Decode(sp);
                    m_quest_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_quest_list.Count);
                for (int i = 0; i != m_quest_list.Count; ++i) {
                    m_quest_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserMedalQuestList source) {
            m_quest_list = source.m_quest_list;
        }
    }
    
    [Serializable]
    public partial class KvkStrategyInfo : NetworkMessage {
        public static int[] Id = { 2401,69 };
        public static Ctrl VC;
        public List<KvkStrategyGroupInfo> m_strategy_group_list = new List<KvkStrategyGroupInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_strategy_group_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkStrategyGroupInfo tmp = new KvkStrategyGroupInfo();
                    tmp.Decode(sp);
                    m_strategy_group_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_strategy_group_list.Count);
                for (int i = 0; i != m_strategy_group_list.Count; ++i) {
                    m_strategy_group_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(KvkStrategyInfo source) {
            m_strategy_group_list = source.m_strategy_group_list;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventChangeResearchInfo : NetworkMessage {
        public static int[] Id = { 2437,72 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_old_level;
        public Int16 m_new_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_old_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_new_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_old_level);}
            if (sp.TryWrite(2)) {sp.Write(m_new_level);}
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventChangeResearchInfo source) {
            m_type = source.m_type;
            m_old_level = source.m_old_level;
            m_new_level = source.m_new_level;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetPackageDataAckInfo : NetworkMessage {
        public static int[] Id = { 2443,72 };
        public static Ctrl VC;
        public List<NewReturnEventPackageInfo> m_package_list = new List<NewReturnEventPackageInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_package_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NewReturnEventPackageInfo tmp = new NewReturnEventPackageInfo();
                    tmp.Decode(sp);
                    m_package_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_package_list.Count);
                for (int i = 0; i != m_package_list.Count; ++i) {
                    m_package_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(NewReturnEventGetPackageDataAckInfo source) {
            m_package_list = source.m_package_list;
        }
    }
    
}
