using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {

    [Serializable]
    public partial class MapTitleInfo : NetworkMessage {
        public static int[] Id = { 5,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int32 m_title_id;
        public Int16 m_title_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_title_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_title_rank = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_title_id);}
            if (sp.TryWrite(2)) {sp.Write(m_title_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(MapTitleInfo source) {
            m_server_id = source.m_server_id;
            m_title_id = source.m_title_id;
            m_title_rank = source.m_title_rank;
        }
    }
    
    [Serializable]
    public partial class EchoInfo : NetworkMessage {
        public static int[] Id = { 11,1 };
        public static Ctrl VC;
        public String m_s = "";
        public SByte m_i8;
        public Int16 m_i16;
        public Int32 m_i32;
        public Int64 m_i64;
        public Byte m_u8;
        public UInt32 m_u32;
        public Boolean m_f;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_s = sp.ReadString();}
            if (sp.TryRead(1)) {m_i8 = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_i16 = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_i32 = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_i64 = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_u8 = sp.ReadByte();}
            if (sp.TryRead(6)) {m_u32 = sp.ReadUInt32();}
            if (sp.TryRead(7)) {m_f = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_s);}
            if (sp.TryWrite(1)) {sp.Write(m_i8);}
            if (sp.TryWrite(2)) {sp.Write(m_i16);}
            if (sp.TryWrite(3)) {sp.Write(m_i32);}
            if (sp.TryWrite(4)) {sp.Write(m_i64);}
            if (sp.TryWrite(5)) {sp.Write(m_u8);}
            if (sp.TryWrite(6)) {sp.Write(m_u32);}
            if (sp.TryWrite(7)) {sp.Write(m_f);}
            sp.EnEnd();
        }
        public void CopyFrom(EchoInfo source) {
            m_s = source.m_s;
            m_i8 = source.m_i8;
            m_i16 = source.m_i16;
            m_i32 = source.m_i32;
            m_i64 = source.m_i64;
            m_u8 = source.m_u8;
            m_u32 = source.m_u32;
            m_f = source.m_f;
        }
    }
    
    [Serializable]
    public partial class ResInfo : NetworkMessage {
        public static int[] Id = { 17,1 };
        public static Ctrl VC;
        public Int64 m_sync_time;
        public Int64 m_cash;
        public Int64 m_diamond;
        public Int64 m_energy;
        public Int64 m_food;
        public Int64 m_oil;
        public Int64 m_steel;
        public Int64 m_cash_speed;
        public Int64 m_energy_speed;
        public Int64 m_food_speed;
        public Int64 m_oil_speed;
        public Int64 m_steel_speed;
        public Int64 m_cash_limit;
        public Int64 m_energy_limit;
        public Int64 m_food_limit;
        public Int64 m_oil_limit;
        public Int64 m_steel_limit;
        public Int64 m_food_load;
        public Int64 m_domino;
        public Int64 m_d2o;
        public Int64 m_promote_point;
        public Int64 m_expedition_coin;
        public Int64 m_inner_point;
        public Int64 m_debt;
        public Int64 m_captain_room_cash;
        public Int64 m_kvk_kill_point;
        public Int64 m_kvk_valor_point;
        public Int64 m_rare_earth;
        public Int64 m_rare_earth_limit;
        public Int64 m_video_channel_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sync_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cash = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_diamond = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_energy = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_food = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_oil = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_steel = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_cash_speed = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_energy_speed = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_food_speed = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_oil_speed = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_steel_speed = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_cash_limit = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_energy_limit = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_food_limit = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_oil_limit = sp.ReadInt64();}
            if (sp.TryRead(16)) {m_steel_limit = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_food_load = sp.ReadInt64();}
            if (sp.TryRead(18)) {m_domino = sp.ReadInt64();}
            if (sp.TryRead(19)) {m_d2o = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_promote_point = sp.ReadInt64();}
            if (sp.TryRead(21)) {m_expedition_coin = sp.ReadInt64();}
            if (sp.TryRead(22)) {m_inner_point = sp.ReadInt64();}
            if (sp.TryRead(23)) {m_debt = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_captain_room_cash = sp.ReadInt64();}
            if (sp.TryRead(25)) {m_kvk_kill_point = sp.ReadInt64();}
            if (sp.TryRead(26)) {m_kvk_valor_point = sp.ReadInt64();}
            if (sp.TryRead(27)) {m_rare_earth = sp.ReadInt64();}
            if (sp.TryRead(28)) {m_rare_earth_limit = sp.ReadInt64();}
            if (sp.TryRead(29)) {m_video_channel_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sync_time);}
            if (sp.TryWrite(1)) {sp.Write(m_cash);}
            if (sp.TryWrite(2)) {sp.Write(m_diamond);}
            if (sp.TryWrite(3)) {sp.Write(m_energy);}
            if (sp.TryWrite(4)) {sp.Write(m_food);}
            if (sp.TryWrite(5)) {sp.Write(m_oil);}
            if (sp.TryWrite(6)) {sp.Write(m_steel);}
            if (sp.TryWrite(7)) {sp.Write(m_cash_speed);}
            if (sp.TryWrite(8)) {sp.Write(m_energy_speed);}
            if (sp.TryWrite(9)) {sp.Write(m_food_speed);}
            if (sp.TryWrite(10)) {sp.Write(m_oil_speed);}
            if (sp.TryWrite(11)) {sp.Write(m_steel_speed);}
            if (sp.TryWrite(12)) {sp.Write(m_cash_limit);}
            if (sp.TryWrite(13)) {sp.Write(m_energy_limit);}
            if (sp.TryWrite(14)) {sp.Write(m_food_limit);}
            if (sp.TryWrite(15)) {sp.Write(m_oil_limit);}
            if (sp.TryWrite(16)) {sp.Write(m_steel_limit);}
            if (sp.TryWrite(17)) {sp.Write(m_food_load);}
            if (sp.TryWrite(18)) {sp.Write(m_domino);}
            if (sp.TryWrite(19)) {sp.Write(m_d2o);}
            if (sp.TryWrite(20)) {sp.Write(m_promote_point);}
            if (sp.TryWrite(21)) {sp.Write(m_expedition_coin);}
            if (sp.TryWrite(22)) {sp.Write(m_inner_point);}
            if (sp.TryWrite(23)) {sp.Write(m_debt);}
            if (sp.TryWrite(24)) {sp.Write(m_captain_room_cash);}
            if (sp.TryWrite(25)) {sp.Write(m_kvk_kill_point);}
            if (sp.TryWrite(26)) {sp.Write(m_kvk_valor_point);}
            if (sp.TryWrite(27)) {sp.Write(m_rare_earth);}
            if (sp.TryWrite(28)) {sp.Write(m_rare_earth_limit);}
            if (sp.TryWrite(29)) {sp.Write(m_video_channel_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ResInfo source) {
            m_sync_time = source.m_sync_time;
            m_cash = source.m_cash;
            m_diamond = source.m_diamond;
            m_energy = source.m_energy;
            m_food = source.m_food;
            m_oil = source.m_oil;
            m_steel = source.m_steel;
            m_cash_speed = source.m_cash_speed;
            m_energy_speed = source.m_energy_speed;
            m_food_speed = source.m_food_speed;
            m_oil_speed = source.m_oil_speed;
            m_steel_speed = source.m_steel_speed;
            m_cash_limit = source.m_cash_limit;
            m_energy_limit = source.m_energy_limit;
            m_food_limit = source.m_food_limit;
            m_oil_limit = source.m_oil_limit;
            m_steel_limit = source.m_steel_limit;
            m_food_load = source.m_food_load;
            m_domino = source.m_domino;
            m_d2o = source.m_d2o;
            m_promote_point = source.m_promote_point;
            m_expedition_coin = source.m_expedition_coin;
            m_inner_point = source.m_inner_point;
            m_debt = source.m_debt;
            m_captain_room_cash = source.m_captain_room_cash;
            m_kvk_kill_point = source.m_kvk_kill_point;
            m_kvk_valor_point = source.m_kvk_valor_point;
            m_rare_earth = source.m_rare_earth;
            m_rare_earth_limit = source.m_rare_earth_limit;
            m_video_channel_score = source.m_video_channel_score;
        }
    }
    
    [Serializable]
    public partial class TroopTrainInfo : NetworkMessage {
        public static int[] Id = { 23,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public Boolean m_instant;

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
            sp.EnEnd();
        }
        public void CopyFrom(TroopTrainInfo source) {
            m_troops = source.m_troops;
            m_instant = source.m_instant;
        }
    }
    
    [Serializable]
    public partial class DismissTroopInfo : NetworkMessage {
        public static int[] Id = { 29,1 };
        public static Ctrl VC;
        public ArmyInfo m_troop;
        public Int16 m_dismiss_type;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_troop = new ArmyInfo();
                m_troop.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_dismiss_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_troop.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_dismiss_type);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(DismissTroopInfo source) {
            m_troop = source.m_troop;
            m_dismiss_type = source.m_dismiss_type;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class MilitaryGoods : NetworkMessage {
        public static int[] Id = { 35,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_amount;
        public Boolean m_get;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_get = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            if (sp.TryWrite(2)) {sp.Write(m_get);}
            sp.EnEnd();
        }
        public void CopyFrom(MilitaryGoods source) {
            m_id = source.m_id;
            m_amount = source.m_amount;
            m_get = source.m_get;
        }
    }
    
    [Serializable]
    public partial class TroopStatistic : NetworkMessage {
        public static int[] Id = { 41,1 };
        public static Ctrl VC;
        public Boolean m_is_p1;
        public Int16 m_group_wave;
        public List<ArmyInfo> m_army_list = new List<ArmyInfo>();
        public List<BuffNtfInfo> m_buff_list = new List<BuffNtfInfo>();
        public LoseInfoGve m_lost_info;
        public List<FightArmyJoin> m_join_list = new List<FightArmyJoin>();
        public List<FightArmyLost> m_lose_list = new List<FightArmyLost>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_group_wave = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_army_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_army_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buff_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_buff_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                m_lost_info = new LoseInfoGve();
                m_lost_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_join_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightArmyJoin tmp = new FightArmyJoin();
                    tmp.Decode(sp);
                    m_join_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(1)) {sp.Write(m_group_wave);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_army_list.Count);
                for (int i = 0; i != m_army_list.Count; ++i) {
                    m_army_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buff_list.Count);
                for (int i = 0; i != m_buff_list.Count; ++i) {
                    m_buff_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_lost_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_join_list.Count);
                for (int i = 0; i != m_join_list.Count; ++i) {
                    m_join_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
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
        public void CopyFrom(TroopStatistic source) {
            m_is_p1 = source.m_is_p1;
            m_group_wave = source.m_group_wave;
            m_army_list = source.m_army_list;
            m_buff_list = source.m_buff_list;
            m_lost_info = source.m_lost_info;
            m_join_list = source.m_join_list;
            m_lose_list = source.m_lose_list;
        }
    }
    
    [Serializable]
    public partial class AtkAction : NetworkMessage {
        public static int[] Id = { 47,1 };
        public static Ctrl VC;
        public Int16 m_action_id;
        public Boolean m_is_p1;
        public Int64 m_damage;
        public Int16 m_atk_type;
        public Int16 m_def_type;
        public Int16 m_model;
        public Int16 m_effect;
        public Int32 m_delay;
        public Int16 m_param;
        public Int32 m_ability;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_p1 = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_damage = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_atk_type = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_def_type = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_model = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_effect = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_delay = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_param = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_ability = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action_id);}
            if (sp.TryWrite(1)) {sp.Write(m_is_p1);}
            if (sp.TryWrite(2)) {sp.Write(m_damage);}
            if (sp.TryWrite(3)) {sp.Write(m_atk_type);}
            if (sp.TryWrite(4)) {sp.Write(m_def_type);}
            if (sp.TryWrite(5)) {sp.Write(m_model);}
            if (sp.TryWrite(6)) {sp.Write(m_effect);}
            if (sp.TryWrite(7)) {sp.Write(m_delay);}
            if (sp.TryWrite(8)) {sp.Write(m_param);}
            if (sp.TryWrite(9)) {sp.Write(m_ability);}
            sp.EnEnd();
        }
        public void CopyFrom(AtkAction source) {
            m_action_id = source.m_action_id;
            m_is_p1 = source.m_is_p1;
            m_damage = source.m_damage;
            m_atk_type = source.m_atk_type;
            m_def_type = source.m_def_type;
            m_model = source.m_model;
            m_effect = source.m_effect;
            m_delay = source.m_delay;
            m_param = source.m_param;
            m_ability = source.m_ability;
        }
    }
    
    [Serializable]
    public partial class FortTile : NetworkMessage {
        public static int[] Id = { 53,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_owner;
        public String m_name = "";
        public UserAllianceBrief m_alliance;
        public FieldCaptivesInfo m_captives;
        public SByte m_base_type;
        public Int64 m_fighting;
        public Int64 m_land_time;
        public Int64 m_end_time;

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
            if (sp.TryRead(6)) {
                m_captives = new FieldCaptivesInfo();
                m_captives.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_base_type = sp.ReadSByte();}
            if (sp.TryRead(8)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_land_time = sp.ReadInt64();}
            if (sp.TryRead(10)) {m_end_time = sp.ReadInt64();}
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
            if (sp.TryWrite(6)) {int pos = sp.GetPos();sp.Skip(2); m_captives.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(7)) {sp.Write(m_base_type);}
            if (sp.TryWrite(8)) {sp.Write(m_fighting);}
            if (sp.TryWrite(9)) {sp.Write(m_land_time);}
            if (sp.TryWrite(10)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(FortTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_owner = source.m_owner;
            m_name = source.m_name;
            m_alliance = source.m_alliance;
            m_captives = source.m_captives;
            m_base_type = source.m_base_type;
            m_fighting = source.m_fighting;
            m_land_time = source.m_land_time;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class FightRecord : NetworkMessage {
        public static int[] Id = { 59,1 };
        public static Ctrl VC;
        public TilePos m_pos;
        public Int64 m_battle_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_battle_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_battle_id);}
            sp.EnEnd();
        }
        public void CopyFrom(FightRecord source) {
            m_pos = source.m_pos;
            m_battle_id = source.m_battle_id;
        }
    }
    
    [Serializable]
    public partial class TileUpdateInfo : NetworkMessage {
        public static int[] Id = { 65,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public MapBuildingInfo m_building;
        public TerritoryInfo m_territory;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_building = new MapBuildingInfo();
                m_building.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_territory = new TerritoryInfo();
                m_territory.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_building.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_territory.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(TileUpdateInfo source) {
            m_server_id = source.m_server_id;
            m_building = source.m_building;
            m_territory = source.m_territory;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class TaxLandCnt : NetworkMessage {
        public static int[] Id = { 71,1 };
        public static Ctrl VC;
        public SByte m_level;
        public Int32 m_amount;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_amount = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_amount);}
            sp.EnEnd();
        }
        public void CopyFrom(TaxLandCnt source) {
            m_level = source.m_level;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class UserMapGroup : NetworkMessage {
        public static int[] Id = { 77,1 };
        public static Ctrl VC;
        public Int32 m_group_type;
        public TileDetailInfo m_tile;
        public TroopGroup m_group;
        public Int16 m_state;
        public MapBuildingInfo m_target_building;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_tile = new TileDetailInfo();
                m_tile.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_group = new TroopGroup();
                m_group.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_state = sp.ReadInt16();}
            if (sp.TryRead(4)) {
                m_target_building = new MapBuildingInfo();
                m_target_building.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_type);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_tile.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_group.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_state);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_target_building.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(UserMapGroup source) {
            m_group_type = source.m_group_type;
            m_tile = source.m_tile;
            m_group = source.m_group;
            m_state = source.m_state;
            m_target_building = source.m_target_building;
        }
    }
    
    [Serializable]
    public partial class PresMailBaseInfo : NetworkMessage {
        public static int[] Id = { 83,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public ContactInfo m_sender;
        public Receivers m_receiver;
        public String m_title = "";
        public String m_content = "";
        public List<String> m_attachment = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_sender = new ContactInfo();
                m_sender.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_receiver = new Receivers();
                m_receiver.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_content = sp.ReadString();}
            if (sp.TryRead(5)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_sender.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_receiver.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_content);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_attachment.Count);
                for (int i = 0; i != m_attachment.Count; ++i) {
                    sp.Write(m_attachment[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(PresMailBaseInfo source) {
            m_server_id = source.m_server_id;
            m_sender = source.m_sender;
            m_receiver = source.m_receiver;
            m_title = source.m_title;
            m_content = source.m_content;
            m_attachment = source.m_attachment;
        }
    }
    
    [Serializable]
    public partial class HeroFreeReportBaseInfo : NetworkMessage {
        public static int[] Id = { 89,1 };
        public static Ctrl VC;
        public SByte m_type;
        public ServerTilePos m_pos;
        public Int64 m_liberator_id;
        public Int16 m_liberator_icon;
        public String m_liberator_name = "";
        public UserAllianceBrief m_liberator_as;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_pos = new ServerTilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_liberator_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_liberator_icon = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_liberator_name = sp.ReadString();}
            if (sp.TryRead(5)) {
                m_liberator_as = new UserAllianceBrief();
                m_liberator_as.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_liberator_id);}
            if (sp.TryWrite(3)) {sp.Write(m_liberator_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_liberator_name);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_liberator_as.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(HeroFreeReportBaseInfo source) {
            m_type = source.m_type;
            m_pos = source.m_pos;
            m_liberator_id = source.m_liberator_id;
            m_liberator_icon = source.m_liberator_icon;
            m_liberator_name = source.m_liberator_name;
            m_liberator_as = source.m_liberator_as;
        }
    }
    
    [Serializable]
    public partial class EventReportBaseInfo : NetworkMessage {
        public static int[] Id = { 95,1 };
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
        public void CopyFrom(EventReportBaseInfo source) {
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class EventMultiRewardReportDetailInfo : NetworkMessage {
        public static int[] Id = { 101,1 };
        public static Ctrl VC;
        public EventRewardReportBaseInfo m_base_info;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new EventRewardReportBaseInfo();
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
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
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
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(EventMultiRewardReportDetailInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryReportBaseInfo : NetworkMessage {
        public static int[] Id = { 107,1 };
        public static Ctrl VC;
        public Int64 m_amount;
        public Int64 m_time;
        public String m_as_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_as_abbr = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_amount);}
            if (sp.TryWrite(1)) {sp.Write(m_time);}
            if (sp.TryWrite(2)) {sp.Write(m_as_abbr);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSalaryReportBaseInfo source) {
            m_amount = source.m_amount;
            m_time = source.m_time;
            m_as_abbr = source.m_as_abbr;
        }
    }
    
    [Serializable]
    public partial class ScoutReportDetailInfo : NetworkMessage {
        public static int[] Id = { 113,1 };
        public static Ctrl VC;
        public Int16 m_rally_send;
        public Int16 m_reinforces_send;
        public ScoutReportBaseInfo m_base_info;
        public List<FightResInfo> m_res_info = new List<FightResInfo>();
        public List<ScoutTroopGroup> m_troops = new List<ScoutTroopGroup>();
        public List<TroopGroup> m_reinforces = new List<TroopGroup>();
        public List<TroopGroup> m_rally_list = new List<TroopGroup>();
        public List<BuildingInfo> m_buildings = new List<BuildingInfo>();
        public List<ArmyInfo> m_garrison_troops = new List<ArmyInfo>();
        public List<BuffNtfInfo> m_item_buff = new List<BuffNtfInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rally_send = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_reinforces_send = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                m_base_info = new ScoutReportBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightResInfo tmp = new FightResInfo();
                    tmp.Decode(sp);
                    m_res_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ScoutTroopGroup tmp = new ScoutTroopGroup();
                    tmp.Decode(sp);
                    m_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reinforces.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_reinforces.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rally_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_rally_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buildings.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuildingInfo tmp = new BuildingInfo();
                    tmp.Decode(sp);
                    m_buildings.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_garrison_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_garrison_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_buff.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_item_buff.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rally_send);}
            if (sp.TryWrite(1)) {sp.Write(m_reinforces_send);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_info.Count);
                for (int i = 0; i != m_res_info.Count; ++i) {
                    m_res_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
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
                sp.Write((UInt16)m_reinforces.Count);
                for (int i = 0; i != m_reinforces.Count; ++i) {
                    m_reinforces[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rally_list.Count);
                for (int i = 0; i != m_rally_list.Count; ++i) {
                    m_rally_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buildings.Count);
                for (int i = 0; i != m_buildings.Count; ++i) {
                    m_buildings[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_garrison_troops.Count);
                for (int i = 0; i != m_garrison_troops.Count; ++i) {
                    m_garrison_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_buff.Count);
                for (int i = 0; i != m_item_buff.Count; ++i) {
                    m_item_buff[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ScoutReportDetailInfo source) {
            m_rally_send = source.m_rally_send;
            m_reinforces_send = source.m_reinforces_send;
            m_base_info = source.m_base_info;
            m_res_info = source.m_res_info;
            m_troops = source.m_troops;
            m_reinforces = source.m_reinforces;
            m_rally_list = source.m_rally_list;
            m_buildings = source.m_buildings;
            m_garrison_troops = source.m_garrison_troops;
            m_item_buff = source.m_item_buff;
        }
    }
    
    [Serializable]
    public partial class HeroExecutedReportDetailInfo : NetworkMessage {
        public static int[] Id = { 119,1 };
        public static Ctrl VC;
        public HeroExecutedReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new HeroExecutedReportBaseInfo();
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
        public void CopyFrom(HeroExecutedReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class LostItemReportDetailInfo : NetworkMessage {
        public static int[] Id = { 125,1 };
        public static Ctrl VC;
        public LostItemReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new LostItemReportBaseInfo();
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
        public void CopyFrom(LostItemReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class ResearchBaseInfo : NetworkMessage {
        public static int[] Id = { 131,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_curr_level;
        public Int16 m_max_level;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_curr_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_max_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_curr_level);}
            if (sp.TryWrite(2)) {sp.Write(m_max_level);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(ResearchBaseInfo source) {
            m_type = source.m_type;
            m_curr_level = source.m_curr_level;
            m_max_level = source.m_max_level;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class UpgradeResearchReqInfo : NetworkMessage {
        public static int[] Id = { 137,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Boolean m_instant;
        public Boolean m_use_instant_item;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_instant = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_use_instant_item = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_instant);}
            if (sp.TryWrite(2)) {sp.Write(m_use_instant_item);}
            sp.EnEnd();
        }
        public void CopyFrom(UpgradeResearchReqInfo source) {
            m_type = source.m_type;
            m_instant = source.m_instant;
            m_use_instant_item = source.m_use_instant_item;
        }
    }
    
    [Serializable]
    public partial class BuffListNtfInfo : NetworkMessage {
        public static int[] Id = { 143,1 };
        public static Ctrl VC;
        public List<BuffNtfInfo> m_list_info = new List<BuffNtfInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuffNtfInfo tmp = new BuffNtfInfo();
                    tmp.Decode(sp);
                    m_list_info.Add(tmp);
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
                sp.Write((UInt16)m_list_info.Count);
                for (int i = 0; i != m_list_info.Count; ++i) {
                    m_list_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(BuffListNtfInfo source) {
            m_list_info = source.m_list_info;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class GetDailyQuestRewardReqInfo : NetworkMessage {
        public static int[] Id = { 149,1 };
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
        public void CopyFrom(GetDailyQuestRewardReqInfo source) {
            m_id = source.m_id;
            m_daily_or_alliance = source.m_daily_or_alliance;
        }
    }
    
    [Serializable]
    public partial class QuestCompleteNtfInfo : NetworkMessage {
        public static int[] Id = { 155,1 };
        public static Ctrl VC;
        public QuestBasicInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_info = new QuestBasicInfo();
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
        public void CopyFrom(QuestCompleteNtfInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class TroopGroup : NetworkMessage {
        public static int[] Id = { 161,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public List<GroupHeroInfo> m_hero = new List<GroupHeroInfo>();
        public Int64 m_owner;
        public Int16 m_icon;
        public String m_owner_name = "";
        public UserAllianceBrief m_alliance;
        public List<ArmyInfo> m_troops = new List<ArmyInfo>();
        public StyleInfo m_style;
        public String m_avatar = "";
        public List<GroupAgentInfo> m_agents = new List<GroupAgentInfo>();
        public Int16 m_avatar_frame;
        public Int16 m_warship_id;
        public Int16 m_warship_skill_level;
        public Int32 m_warship_level;
        public Int16 m_army_banner_id;
        public List<Int32> m_aura_ids = new List<Int32>();
        public Int16 m_troop_skin_id;
        public Int16 m_troop_tail_skin_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_hero.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GroupHeroInfo tmp = new GroupHeroInfo();
                    tmp.Decode(sp);
                    m_hero.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_owner_name = sp.ReadString();}
            if (sp.TryRead(5)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
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
            if (sp.TryRead(7)) {
                m_style = new StyleInfo();
                m_style.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(8)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(9)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GroupAgentInfo tmp = new GroupAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_warship_skill_level = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_warship_level = sp.ReadInt32();}
            if (sp.TryRead(14)) {m_army_banner_id = sp.ReadInt16();}
            if (sp.TryRead(15)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_aura_ids.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_aura_ids.Add(tmp);
                }
            }
            if (sp.TryRead(16)) {m_troop_skin_id = sp.ReadInt16();}
            if (sp.TryRead(17)) {m_troop_tail_skin_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_hero.Count);
                for (int i = 0; i != m_hero.Count; ++i) {
                    m_hero[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_owner);}
            if (sp.TryWrite(3)) {sp.Write(m_icon);}
            if (sp.TryWrite(4)) {sp.Write(m_owner_name);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_troops.Count);
                for (int i = 0; i != m_troops.Count; ++i) {
                    m_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_style.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(8)) {sp.Write(m_avatar);}
            if (sp.TryWrite(9)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agents.Count);
                for (int i = 0; i != m_agents.Count; ++i) {
                    m_agents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(10)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(11)) {sp.Write(m_warship_id);}
            if (sp.TryWrite(12)) {sp.Write(m_warship_skill_level);}
            if (sp.TryWrite(13)) {sp.Write(m_warship_level);}
            if (sp.TryWrite(14)) {sp.Write(m_army_banner_id);}
            if (sp.TryWrite(15)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_aura_ids.Count);
                for (int i = 0; i != m_aura_ids.Count; ++i) {
                    sp.Write(m_aura_ids[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(16)) {sp.Write(m_troop_skin_id);}
            if (sp.TryWrite(17)) {sp.Write(m_troop_tail_skin_id);}
            sp.EnEnd();
        }
        public void CopyFrom(TroopGroup source) {
            m_id = source.m_id;
            m_hero = source.m_hero;
            m_owner = source.m_owner;
            m_icon = source.m_icon;
            m_owner_name = source.m_owner_name;
            m_alliance = source.m_alliance;
            m_troops = source.m_troops;
            m_style = source.m_style;
            m_avatar = source.m_avatar;
            m_agents = source.m_agents;
            m_avatar_frame = source.m_avatar_frame;
            m_warship_id = source.m_warship_id;
            m_warship_skill_level = source.m_warship_skill_level;
            m_warship_level = source.m_warship_level;
            m_army_banner_id = source.m_army_banner_id;
            m_aura_ids = source.m_aura_ids;
            m_troop_skin_id = source.m_troop_skin_id;
            m_troop_tail_skin_id = source.m_troop_tail_skin_id;
        }
    }
    
    [Serializable]
    public partial class DefenceInfo : NetworkMessage {
        public static int[] Id = { 167,1 };
        public static Ctrl VC;
        public Int64 m_atk_user;
        public Int16 m_atk_icon;
        public String m_atk_name = "";
        public TilePos m_atk_pos;
        public Int16 m_atk_server_id;
        public UserAllianceBrief m_atk_alliance;
        public Int64 m_def_user;
        public String m_def_name = "";
        public Int16 m_def_icon;
        public String m_def_avatar = "";
        public TilePos m_def_pos;
        public Int16 m_def_server_id;
        public UserAllianceBrief m_def_alliance;
        public Int16 m_stat;
        public Int64 m_prog_start;
        public Int64 m_prog_end;
        public Int64 m_max_cnt;
        public Int64 m_cur_cnt;
        public MapUnitId m_def_target;
        public Int32 m_building_type;
        public List<MarchInfo> m_rally_march = new List<MarchInfo>();
        public Int16 m_sub_type;
        public String m_atk_avatar = "";
        public Int64 m_map_guid;
        public String m_unique_id = "";
        public Int16 m_def_avatar_frame;
        public Int16 m_atk_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_atk_user = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_atk_icon = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_atk_name = sp.ReadString();}
            if (sp.TryRead(3)) {
                m_atk_pos = new TilePos();
                m_atk_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_atk_server_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {
                m_atk_alliance = new UserAllianceBrief();
                m_atk_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_def_user = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_def_name = sp.ReadString();}
            if (sp.TryRead(8)) {m_def_icon = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_def_avatar = sp.ReadString();}
            if (sp.TryRead(10)) {
                m_def_pos = new TilePos();
                m_def_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_def_server_id = sp.ReadInt16();}
            if (sp.TryRead(12)) {
                m_def_alliance = new UserAllianceBrief();
                m_def_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_stat = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_prog_start = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_prog_end = sp.ReadInt64();}
            if (sp.TryRead(16)) {m_max_cnt = sp.ReadInt64();}
            if (sp.TryRead(17)) {m_cur_cnt = sp.ReadInt64();}
            if (sp.TryRead(18)) {
                m_def_target = new MapUnitId();
                m_def_target.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {m_building_type = sp.ReadInt32();}
            if (sp.TryRead(20)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rally_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_rally_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(21)) {m_sub_type = sp.ReadInt16();}
            if (sp.TryRead(22)) {m_atk_avatar = sp.ReadString();}
            if (sp.TryRead(23)) {m_map_guid = sp.ReadInt64();}
            if (sp.TryRead(24)) {m_unique_id = sp.ReadString();}
            if (sp.TryRead(25)) {m_def_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(26)) {m_atk_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_atk_user);}
            if (sp.TryWrite(1)) {sp.Write(m_atk_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_atk_name);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_atk_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_atk_server_id);}
            if (sp.TryWrite(5)) {int pos = sp.GetPos();sp.Skip(2); m_atk_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(6)) {sp.Write(m_def_user);}
            if (sp.TryWrite(7)) {sp.Write(m_def_name);}
            if (sp.TryWrite(8)) {sp.Write(m_def_icon);}
            if (sp.TryWrite(9)) {sp.Write(m_def_avatar);}
            if (sp.TryWrite(10)) {int pos = sp.GetPos();sp.Skip(2); m_def_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(11)) {sp.Write(m_def_server_id);}
            if (sp.TryWrite(12)) {int pos = sp.GetPos();sp.Skip(2); m_def_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(13)) {sp.Write(m_stat);}
            if (sp.TryWrite(14)) {sp.Write(m_prog_start);}
            if (sp.TryWrite(15)) {sp.Write(m_prog_end);}
            if (sp.TryWrite(16)) {sp.Write(m_max_cnt);}
            if (sp.TryWrite(17)) {sp.Write(m_cur_cnt);}
            if (sp.TryWrite(18)) {int pos = sp.GetPos();sp.Skip(2); m_def_target.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(19)) {sp.Write(m_building_type);}
            if (sp.TryWrite(20)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rally_march.Count);
                for (int i = 0; i != m_rally_march.Count; ++i) {
                    m_rally_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(21)) {sp.Write(m_sub_type);}
            if (sp.TryWrite(22)) {sp.Write(m_atk_avatar);}
            if (sp.TryWrite(23)) {sp.Write(m_map_guid);}
            if (sp.TryWrite(24)) {sp.Write(m_unique_id);}
            if (sp.TryWrite(25)) {sp.Write(m_def_avatar_frame);}
            if (sp.TryWrite(26)) {sp.Write(m_atk_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(DefenceInfo source) {
            m_atk_user = source.m_atk_user;
            m_atk_icon = source.m_atk_icon;
            m_atk_name = source.m_atk_name;
            m_atk_pos = source.m_atk_pos;
            m_atk_server_id = source.m_atk_server_id;
            m_atk_alliance = source.m_atk_alliance;
            m_def_user = source.m_def_user;
            m_def_name = source.m_def_name;
            m_def_icon = source.m_def_icon;
            m_def_avatar = source.m_def_avatar;
            m_def_pos = source.m_def_pos;
            m_def_server_id = source.m_def_server_id;
            m_def_alliance = source.m_def_alliance;
            m_stat = source.m_stat;
            m_prog_start = source.m_prog_start;
            m_prog_end = source.m_prog_end;
            m_max_cnt = source.m_max_cnt;
            m_cur_cnt = source.m_cur_cnt;
            m_def_target = source.m_def_target;
            m_building_type = source.m_building_type;
            m_rally_march = source.m_rally_march;
            m_sub_type = source.m_sub_type;
            m_atk_avatar = source.m_atk_avatar;
            m_map_guid = source.m_map_guid;
            m_unique_id = source.m_unique_id;
            m_def_avatar_frame = source.m_def_avatar_frame;
            m_atk_avatar_frame = source.m_atk_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class UseItemInfo : NetworkMessage {
        public static int[] Id = { 173,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int16 m_optype;
        public Int32 m_item_cnt;
        public UseItemParam m_param_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_optype = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(3)) {
                m_param_info = new UseItemParam();
                m_param_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_optype);}
            if (sp.TryWrite(2)) {sp.Write(m_item_cnt);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_param_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(UseItemInfo source) {
            m_item_id = source.m_item_id;
            m_optype = source.m_optype;
            m_item_cnt = source.m_item_cnt;
            m_param_info = source.m_param_info;
        }
    }
    
    [Serializable]
    public partial class PowerRanklistAck : NetworkMessage {
        public static int[] Id = { 179,1 };
        public static Ctrl VC;
        public List<Rankinfo> m_ranklist = new List<Rankinfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(PowerRanklistAck source) {
            m_ranklist = source.m_ranklist;
        }
    }
    
    [Serializable]
    public partial class AllianceOfferHelpNtf : NetworkMessage {
        public static int[] Id = { 185,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_help_id;
        public Int16 m_times;
        public Int32 m_repair_help_count;
        public Int32 m_max_repair_help_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_help_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_times = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_repair_help_count = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_max_repair_help_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_help_id);}
            if (sp.TryWrite(2)) {sp.Write(m_times);}
            if (sp.TryWrite(3)) {sp.Write(m_repair_help_count);}
            if (sp.TryWrite(4)) {sp.Write(m_max_repair_help_count);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceOfferHelpNtf source) {
            m_user_id = source.m_user_id;
            m_help_id = source.m_help_id;
            m_times = source.m_times;
            m_repair_help_count = source.m_repair_help_count;
            m_max_repair_help_count = source.m_max_repair_help_count;
        }
    }
    
    [Serializable]
    public partial class UserRanklistInfo : NetworkMessage {
        public static int[] Id = { 191,1 };
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
        public void CopyFrom(UserRanklistInfo source) {
            m_ranks = source.m_ranks;
        }
    }
    
    [Serializable]
    public partial class RepairReqInfo : NetworkMessage {
        public static int[] Id = { 197,1 };
        public static Ctrl VC;
        public List<ArmyInfo> m_repair_list = new List<ArmyInfo>();
        public Boolean m_instant;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_repair_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_repair_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_instant = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_repair_list.Count);
                for (int i = 0; i != m_repair_list.Count; ++i) {
                    m_repair_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_instant);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(RepairReqInfo source) {
            m_repair_list = source.m_repair_list;
            m_instant = source.m_instant;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class BuildingFreeInfoNtf : NetworkMessage {
        public static int[] Id = { 203,1 };
        public static Ctrl VC;
        public Int64 m_max_free_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_max_free_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_max_free_time);}
            sp.EnEnd();
        }
        public void CopyFrom(BuildingFreeInfoNtf source) {
            m_max_free_time = source.m_max_free_time;
        }
    }
    
    [Serializable]
    public partial class BeAtkListInfo : NetworkMessage {
        public static int[] Id = { 209,1 };
        public static Ctrl VC;
        public List<BeAtkInfo> m_infos = new List<BeAtkInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BeAtkInfo tmp = new BeAtkInfo();
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
        public void CopyFrom(BeAtkListInfo source) {
            m_infos = source.m_infos;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ChatToken : NetworkMessage {
        public static int[] Id = { 215,1 };
        public static Ctrl VC;
        public String m_host = "";
        public String m_port = "";
        public String m_jid = "";
        public String m_token = "";
        public String m_nick = "";
        public String m_node_room_jid = "";
        public String m_guild_room_jid = "";
        public String m_lang_room_jid = "";
        public String m_push_service_host = "";
        public String m_push_service_port = "";
        public Boolean m_use_chat2;
        public String m_kvk_room_jid = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_host = sp.ReadString();}
            if (sp.TryRead(1)) {m_port = sp.ReadString();}
            if (sp.TryRead(2)) {m_jid = sp.ReadString();}
            if (sp.TryRead(3)) {m_token = sp.ReadString();}
            if (sp.TryRead(4)) {m_nick = sp.ReadString();}
            if (sp.TryRead(5)) {m_node_room_jid = sp.ReadString();}
            if (sp.TryRead(6)) {m_guild_room_jid = sp.ReadString();}
            if (sp.TryRead(7)) {m_lang_room_jid = sp.ReadString();}
            if (sp.TryRead(8)) {m_push_service_host = sp.ReadString();}
            if (sp.TryRead(9)) {m_push_service_port = sp.ReadString();}
            if (sp.TryRead(10)) {m_use_chat2 = sp.ReadBoolean();}
            if (sp.TryRead(11)) {m_kvk_room_jid = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_host);}
            if (sp.TryWrite(1)) {sp.Write(m_port);}
            if (sp.TryWrite(2)) {sp.Write(m_jid);}
            if (sp.TryWrite(3)) {sp.Write(m_token);}
            if (sp.TryWrite(4)) {sp.Write(m_nick);}
            if (sp.TryWrite(5)) {sp.Write(m_node_room_jid);}
            if (sp.TryWrite(6)) {sp.Write(m_guild_room_jid);}
            if (sp.TryWrite(7)) {sp.Write(m_lang_room_jid);}
            if (sp.TryWrite(8)) {sp.Write(m_push_service_host);}
            if (sp.TryWrite(9)) {sp.Write(m_push_service_port);}
            if (sp.TryWrite(10)) {sp.Write(m_use_chat2);}
            if (sp.TryWrite(11)) {sp.Write(m_kvk_room_jid);}
            sp.EnEnd();
        }
        public void CopyFrom(ChatToken source) {
            m_host = source.m_host;
            m_port = source.m_port;
            m_jid = source.m_jid;
            m_token = source.m_token;
            m_nick = source.m_nick;
            m_node_room_jid = source.m_node_room_jid;
            m_guild_room_jid = source.m_guild_room_jid;
            m_lang_room_jid = source.m_lang_room_jid;
            m_push_service_host = source.m_push_service_host;
            m_push_service_port = source.m_push_service_port;
            m_use_chat2 = source.m_use_chat2;
            m_kvk_room_jid = source.m_kvk_room_jid;
        }
    }
    
    [Serializable]
    public partial class AllianceModRankNtf : NetworkMessage {
        public static int[] Id = { 221,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_new_rank;
        public List<Int16> m_permissions = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_new_rank = sp.ReadInt16();}
            if (sp.TryRead(2)) {
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
            if (sp.TryWrite(1)) {sp.Write(m_new_rank);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_permissions.Count);
                for (int i = 0; i != m_permissions.Count; ++i) {
                    sp.Write(m_permissions[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceModRankNtf source) {
            m_user_id = source.m_user_id;
            m_new_rank = source.m_new_rank;
            m_permissions = source.m_permissions;
        }
    }
    
    [Serializable]
    public partial class AllianceInviteNtfInfo : NetworkMessage {
        public static int[] Id = { 227,1 };
        public static Ctrl VC;
        public AllianceBriefInfo m_info;
        public Int64 m_invite_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_info = new AllianceBriefInfo();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_invite_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_invite_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceInviteNtfInfo source) {
            m_info = source.m_info;
            m_invite_time = source.m_invite_time;
        }
    }
    
    [Serializable]
    public partial class ResTypeInfo : NetworkMessage {
        public static int[] Id = { 233,1 };
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
        public void CopyFrom(ResTypeInfo source) {
            m_type = source.m_type;
            m_amount = source.m_amount;
        }
    }
    
    [Serializable]
    public partial class AllianceResApplyInfo : NetworkMessage {
        public static int[] Id = { 239,1 };
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
        public void CopyFrom(AllianceResApplyInfo source) {
            m_user_id = source.m_user_id;
            m_res = source.m_res;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class ListAllianceDominionReqInfo : NetworkMessage {
        public static int[] Id = { 245,1 };
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
        public void CopyFrom(ListAllianceDominionReqInfo source) {
            m_alliance_id = source.m_alliance_id;
        }
    }
    
    [Serializable]
    public partial class ConstInfo : NetworkMessage {
        public static int[] Id = { 251,1 };
        public static Ctrl VC;
        public String m_keyword = "";
        public Int32 m_val;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_keyword = sp.ReadString();}
            if (sp.TryRead(1)) {m_val = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_keyword);}
            if (sp.TryWrite(1)) {sp.Write(m_val);}
            sp.EnEnd();
        }
        public void CopyFrom(ConstInfo source) {
            m_keyword = source.m_keyword;
            m_val = source.m_val;
        }
    }
    
    [Serializable]
    public partial class SearchNameInfo : NetworkMessage {
        public static int[] Id = { 257,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public List<SearchNode> m_list = new List<SearchNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SearchNode tmp = new SearchNode();
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
        public void CopyFrom(SearchNameInfo source) {
            m_type = source.m_type;
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class SimpleUserInfo : NetworkMessage {
        public static int[] Id = { 263,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int16 m_server_id;
        public Int16 m_guest_server;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_guest_server = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_server_id);}
            if (sp.TryWrite(3)) {sp.Write(m_guest_server);}
            sp.EnEnd();
        }
        public void CopyFrom(SimpleUserInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_server_id = source.m_server_id;
            m_guest_server = source.m_guest_server;
        }
    }
    
    [Serializable]
    public partial class PostAllianceCommentInfo : NetworkMessage {
        public static int[] Id = { 269,1 };
        public static Ctrl VC;
        public Int32 m_alliance_id;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(1)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(PostAllianceCommentInfo source) {
            m_alliance_id = source.m_alliance_id;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class AllianceAuthorityInfo : NetworkMessage {
        public static int[] Id = { 275,1 };
        public static Ctrl VC;
        public Int16 m_rank;
        public List<AuthorityInfo> m_infos = new List<AuthorityInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AuthorityInfo tmp = new AuthorityInfo();
                    tmp.Decode(sp);
                    m_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
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
        public void CopyFrom(AllianceAuthorityInfo source) {
            m_rank = source.m_rank;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class UserBriefInfo : NetworkMessage {
        public static int[] Id = { 281,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int64 m_power;
        public Int64 m_killcnt;
        public Int32 m_alliance_id;
        public String m_alliance_name = "";
        public String m_alliance_abbr = "";
        public Int16 m_server_id;
        public Int16 m_hq_level;
        public String m_avatar = "";
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_killcnt = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_alliance_name = sp.ReadString();}
            if (sp.TryRead(7)) {m_alliance_abbr = sp.ReadString();}
            if (sp.TryRead(8)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_hq_level = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(11)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_killcnt);}
            if (sp.TryWrite(5)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(6)) {sp.Write(m_alliance_name);}
            if (sp.TryWrite(7)) {sp.Write(m_alliance_abbr);}
            if (sp.TryWrite(8)) {sp.Write(m_server_id);}
            if (sp.TryWrite(9)) {sp.Write(m_hq_level);}
            if (sp.TryWrite(10)) {sp.Write(m_avatar);}
            if (sp.TryWrite(11)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(UserBriefInfo source) {
            m_id = source.m_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_power = source.m_power;
            m_killcnt = source.m_killcnt;
            m_alliance_id = source.m_alliance_id;
            m_alliance_name = source.m_alliance_name;
            m_alliance_abbr = source.m_alliance_abbr;
            m_server_id = source.m_server_id;
            m_hq_level = source.m_hq_level;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ListAllianceGiftReqInfo : NetworkMessage {
        public static int[] Id = { 287,1 };
        public static Ctrl VC;
        public Boolean m_drop_expired;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_drop_expired = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_drop_expired);}
            sp.EnEnd();
        }
        public void CopyFrom(ListAllianceGiftReqInfo source) {
            m_drop_expired = source.m_drop_expired;
        }
    }
    
    [Serializable]
    public partial class IapListReq : NetworkMessage {
        public static int[] Id = { 293,1 };
        public static Ctrl VC;
        public Int16 m_locale;
        public Int32 m_iap_type;
        public String m_iap_sub_type = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_locale = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_iap_type = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_iap_sub_type = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_locale);}
            if (sp.TryWrite(1)) {sp.Write(m_iap_type);}
            if (sp.TryWrite(2)) {sp.Write(m_iap_sub_type);}
            sp.EnEnd();
        }
        public void CopyFrom(IapListReq source) {
            m_locale = source.m_locale;
            m_iap_type = source.m_iap_type;
            m_iap_sub_type = source.m_iap_sub_type;
        }
    }
    
    [Serializable]
    public partial class IapPrepareRsp : NetworkMessage {
        public static int[] Id = { 299,1 };
        public static Ctrl VC;
        public Int16 m_code;
        public String m_url = "";
        public String m_ext_data = "";
        public String m_order_id = "";
        public String m_order_uuid = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_url = sp.ReadString();}
            if (sp.TryRead(2)) {m_ext_data = sp.ReadString();}
            if (sp.TryRead(3)) {m_order_id = sp.ReadString();}
            if (sp.TryRead(4)) {m_order_uuid = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_code);}
            if (sp.TryWrite(1)) {sp.Write(m_url);}
            if (sp.TryWrite(2)) {sp.Write(m_ext_data);}
            if (sp.TryWrite(3)) {sp.Write(m_order_id);}
            if (sp.TryWrite(4)) {sp.Write(m_order_uuid);}
            sp.EnEnd();
        }
        public void CopyFrom(IapPrepareRsp source) {
            m_code = source.m_code;
            m_url = source.m_url;
            m_ext_data = source.m_ext_data;
            m_order_id = source.m_order_id;
            m_order_uuid = source.m_order_uuid;
        }
    }
    
    [Serializable]
    public partial class UpdatePushInfo : NetworkMessage {
        public static int[] Id = { 305,1 };
        public static Ctrl VC;
        public String m_access_token = "";
        public SByte m_push_type;
        public String m_token = "";
        public String m_baidu_appid = "";
        public String m_baidu_user = "";
        public String m_baidu_channel = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_access_token = sp.ReadString();}
            if (sp.TryRead(1)) {m_push_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_token = sp.ReadString();}
            if (sp.TryRead(3)) {m_baidu_appid = sp.ReadString();}
            if (sp.TryRead(4)) {m_baidu_user = sp.ReadString();}
            if (sp.TryRead(5)) {m_baidu_channel = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_access_token);}
            if (sp.TryWrite(1)) {sp.Write(m_push_type);}
            if (sp.TryWrite(2)) {sp.Write(m_token);}
            if (sp.TryWrite(3)) {sp.Write(m_baidu_appid);}
            if (sp.TryWrite(4)) {sp.Write(m_baidu_user);}
            if (sp.TryWrite(5)) {sp.Write(m_baidu_channel);}
            sp.EnEnd();
        }
        public void CopyFrom(UpdatePushInfo source) {
            m_access_token = source.m_access_token;
            m_push_type = source.m_push_type;
            m_token = source.m_token;
            m_baidu_appid = source.m_baidu_appid;
            m_baidu_user = source.m_baidu_user;
            m_baidu_channel = source.m_baidu_channel;
        }
    }
    
    [Serializable]
    public partial class UserStatisticsAckInfo : NetworkMessage {
        public static int[] Id = { 311,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public List<UserStatisticsInfo> m_infos = new List<UserStatisticsInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserStatisticsInfo tmp = new UserStatisticsInfo();
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
        public void CopyFrom(UserStatisticsAckInfo source) {
            m_user_id = source.m_user_id;
            m_infos = source.m_infos;
        }
    }
    
    [Serializable]
    public partial class SilentInfo : NetworkMessage {
        public static int[] Id = { 317,1 };
        public static Ctrl VC;
        public SByte m_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_flag = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(SilentInfo source) {
            m_flag = source.m_flag;
        }
    }
    
    [Serializable]
    public partial class ChangeMonumentNoteInfo : NetworkMessage {
        public static int[] Id = { 323,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public String m_note = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_note = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_note);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeMonumentNoteInfo source) {
            m_server_id = source.m_server_id;
            m_note = source.m_note;
        }
    }
    
    [Serializable]
    public partial class DailyEventReward : NetworkMessage {
        public static int[] Id = { 329,1 };
        public static Ctrl VC;
        public Int16 m_score;
        public SByte m_got;
        public Int32 m_food;
        public Int32 m_steel;
        public Int32 m_oil;
        public Int32 m_energy;
        public Int32 m_diamond;
        public List<ItemInfo> m_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_got = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_food = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_steel = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_oil = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_energy = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_diamond = sp.ReadInt32();}
            if (sp.TryRead(7)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {sp.Write(m_got);}
            if (sp.TryWrite(2)) {sp.Write(m_food);}
            if (sp.TryWrite(3)) {sp.Write(m_steel);}
            if (sp.TryWrite(4)) {sp.Write(m_oil);}
            if (sp.TryWrite(5)) {sp.Write(m_energy);}
            if (sp.TryWrite(6)) {sp.Write(m_diamond);}
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
        public void CopyFrom(DailyEventReward source) {
            m_score = source.m_score;
            m_got = source.m_got;
            m_food = source.m_food;
            m_steel = source.m_steel;
            m_oil = source.m_oil;
            m_energy = source.m_energy;
            m_diamond = source.m_diamond;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class GetDailyEventRewardReq : NetworkMessage {
        public static int[] Id = { 335,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(GetDailyEventRewardReq source) {
            m_type = source.m_type;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class InvitationRewardInfo : NetworkMessage {
        public static int[] Id = { 341,1 };
        public static Ctrl VC;
        public Int16 m_rank;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt16();}
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
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
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
        public void CopyFrom(InvitationRewardInfo source) {
            m_rank = source.m_rank;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class TitleAward : NetworkMessage {
        public static int[] Id = { 347,1 };
        public static Ctrl VC;
        public Int16 m_title_id;
        public Int16 m_tax_percent;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_tax_percent = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {sp.Write(m_tax_percent);}
            sp.EnEnd();
        }
        public void CopyFrom(TitleAward source) {
            m_title_id = source.m_title_id;
            m_tax_percent = source.m_tax_percent;
        }
    }
    
    [Serializable]
    public partial class TitleResDetailInfo : NetworkMessage {
        public static int[] Id = { 353,1 };
        public static Ctrl VC;
        public TitleResBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new TitleResBaseInfo();
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
        public void CopyFrom(TitleResDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class MentorListInfo : NetworkMessage {
        public static int[] Id = { 359,1 };
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
        public void CopyFrom(MentorListInfo source) {
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class DonateDiamondAckNode : NetworkMessage {
        public static int[] Id = { 365,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int16 m_code;
        public Int64 m_next_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_code = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_next_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_code);}
            if (sp.TryWrite(2)) {sp.Write(m_next_time);}
            sp.EnEnd();
        }
        public void CopyFrom(DonateDiamondAckNode source) {
            m_user_id = source.m_user_id;
            m_code = source.m_code;
            m_next_time = source.m_next_time;
        }
    }
    
    [Serializable]
    public partial class BundleUserReqInfo : NetworkMessage {
        public static int[] Id = { 371,1 };
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
        public void CopyFrom(BundleUserReqInfo source) {
            m_users = source.m_users;
        }
    }
    
    [Serializable]
    public partial class ZoneBriefInfo : NetworkMessage {
        public static int[] Id = { 377,1 };
        public static Ctrl VC;
        public Int64 m_curr_power;
        public Int64 m_prev_power;
        public List<ResTileInfo> m_res_tiles = new List<ResTileInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_curr_power = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_prev_power = sp.ReadInt64();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_res_tiles.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTileInfo tmp = new ResTileInfo();
                    tmp.Decode(sp);
                    m_res_tiles.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_curr_power);}
            if (sp.TryWrite(1)) {sp.Write(m_prev_power);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_res_tiles.Count);
                for (int i = 0; i != m_res_tiles.Count; ++i) {
                    m_res_tiles[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ZoneBriefInfo source) {
            m_curr_power = source.m_curr_power;
            m_prev_power = source.m_prev_power;
            m_res_tiles = source.m_res_tiles;
        }
    }
    
    [Serializable]
    public partial class AllianceSalaryHistory : NetworkMessage {
        public static int[] Id = { 383,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public Int16 m_title;
        public Int16 m_rank;
        public String m_name = "";
        public Int64 m_amount;
        public Int64 m_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_title = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_name = sp.ReadString();}
            if (sp.TryRead(4)) {m_amount = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_title);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_name);}
            if (sp.TryWrite(4)) {sp.Write(m_amount);}
            if (sp.TryWrite(5)) {sp.Write(m_time);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceSalaryHistory source) {
            m_type = source.m_type;
            m_title = source.m_title;
            m_rank = source.m_rank;
            m_name = source.m_name;
            m_amount = source.m_amount;
            m_time = source.m_time;
        }
    }
    
    [Serializable]
    public partial class RegionInfo : NetworkMessage {
        public static int[] Id = { 389,1 };
        public static Ctrl VC;
        public String m_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_name);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionInfo source) {
            m_name = source.m_name;
        }
    }
    
    [Serializable]
    public partial class IapPriceAckInfo : NetworkMessage {
        public static int[] Id = { 395,1 };
        public static Ctrl VC;
        public List<IapPriceNode> m_list = new List<IapPriceNode>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapPriceNode tmp = new IapPriceNode();
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
        public void CopyFrom(IapPriceAckInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class OfficerInfo : NetworkMessage {
        public static int[] Id = { 401,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int16 m_count;
        public Int16 m_equiped;
        public Int16 m_statu;
        public Int64 m_start_time;
        public Int64 m_end_time;
        public List<EmbeditemsInfo> m_embeditems = new List<EmbeditemsInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_count = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_equiped = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_statu = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_embeditems.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    EmbeditemsInfo tmp = new EmbeditemsInfo();
                    tmp.Decode(sp);
                    m_embeditems.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_count);}
            if (sp.TryWrite(2)) {sp.Write(m_equiped);}
            if (sp.TryWrite(3)) {sp.Write(m_statu);}
            if (sp.TryWrite(4)) {sp.Write(m_start_time);}
            if (sp.TryWrite(5)) {sp.Write(m_end_time);}
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_embeditems.Count);
                for (int i = 0; i != m_embeditems.Count; ++i) {
                    m_embeditems[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OfficerInfo source) {
            m_id = source.m_id;
            m_count = source.m_count;
            m_equiped = source.m_equiped;
            m_statu = source.m_statu;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_embeditems = source.m_embeditems;
        }
    }
    
    [Serializable]
    public partial class ActivityBaseInfo : NetworkMessage {
        public static int[] Id = { 407,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_index;
        public Int16 m_tag_id;
        public SByte m_type;
        public Int16 m_subtype;
        public String m_banner = "";
        public String m_desc = "";
        public String m_preview_desc = "";
        public String m_icon = "";
        public String m_title = "";
        public String m_sub_title = "";
        public Int64 m_preview_time;
        public Int64 m_begin_time;
        public Int64 m_end_time;
        public Int64 m_close_time;
        public String m_tag = "";
        public SByte m_class;
        public String m_title_bg = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_index = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_tag_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_subtype = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_banner = sp.ReadString();}
            if (sp.TryRead(6)) {m_desc = sp.ReadString();}
            if (sp.TryRead(7)) {m_preview_desc = sp.ReadString();}
            if (sp.TryRead(8)) {m_icon = sp.ReadString();}
            if (sp.TryRead(9)) {m_title = sp.ReadString();}
            if (sp.TryRead(10)) {m_sub_title = sp.ReadString();}
            if (sp.TryRead(11)) {m_preview_time = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_begin_time = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(14)) {m_close_time = sp.ReadInt64();}
            if (sp.TryRead(15)) {m_tag = sp.ReadString();}
            if (sp.TryRead(16)) {m_class = sp.ReadSByte();}
            if (sp.TryRead(17)) {m_title_bg = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_index);}
            if (sp.TryWrite(2)) {sp.Write(m_tag_id);}
            if (sp.TryWrite(3)) {sp.Write(m_type);}
            if (sp.TryWrite(4)) {sp.Write(m_subtype);}
            if (sp.TryWrite(5)) {sp.Write(m_banner);}
            if (sp.TryWrite(6)) {sp.Write(m_desc);}
            if (sp.TryWrite(7)) {sp.Write(m_preview_desc);}
            if (sp.TryWrite(8)) {sp.Write(m_icon);}
            if (sp.TryWrite(9)) {sp.Write(m_title);}
            if (sp.TryWrite(10)) {sp.Write(m_sub_title);}
            if (sp.TryWrite(11)) {sp.Write(m_preview_time);}
            if (sp.TryWrite(12)) {sp.Write(m_begin_time);}
            if (sp.TryWrite(13)) {sp.Write(m_end_time);}
            if (sp.TryWrite(14)) {sp.Write(m_close_time);}
            if (sp.TryWrite(15)) {sp.Write(m_tag);}
            if (sp.TryWrite(16)) {sp.Write(m_class);}
            if (sp.TryWrite(17)) {sp.Write(m_title_bg);}
            sp.EnEnd();
        }
        public void CopyFrom(ActivityBaseInfo source) {
            m_id = source.m_id;
            m_index = source.m_index;
            m_tag_id = source.m_tag_id;
            m_type = source.m_type;
            m_subtype = source.m_subtype;
            m_banner = source.m_banner;
            m_desc = source.m_desc;
            m_preview_desc = source.m_preview_desc;
            m_icon = source.m_icon;
            m_title = source.m_title;
            m_sub_title = source.m_sub_title;
            m_preview_time = source.m_preview_time;
            m_begin_time = source.m_begin_time;
            m_end_time = source.m_end_time;
            m_close_time = source.m_close_time;
            m_tag = source.m_tag;
            m_class = source.m_class;
            m_title_bg = source.m_title_bg;
        }
    }
    
    [Serializable]
    public partial class RankInfo : NetworkMessage {
        public static int[] Id = { 413,1 };
        public static Ctrl VC;
        public Int32 m_rank_founds;
        public Int16 m_region_rank;
        public Int16 m_server_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank_founds = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_region_rank = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_server_rank = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank_founds);}
            if (sp.TryWrite(1)) {sp.Write(m_region_rank);}
            if (sp.TryWrite(2)) {sp.Write(m_server_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(RankInfo source) {
            m_rank_founds = source.m_rank_founds;
            m_region_rank = source.m_region_rank;
            m_server_rank = source.m_server_rank;
        }
    }
    
    [Serializable]
    public partial class RegionMsgInfo : NetworkMessage {
        public static int[] Id = { 419,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_icon;
        public Int64 m_power;
        public SByte m_lang;
        public Int16 m_server_id;
        public String m_content = "";
        public Int64 m_create_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_lang = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_content = sp.ReadString();}
            if (sp.TryRead(7)) {m_create_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_lang);}
            if (sp.TryWrite(5)) {sp.Write(m_server_id);}
            if (sp.TryWrite(6)) {sp.Write(m_content);}
            if (sp.TryWrite(7)) {sp.Write(m_create_time);}
            sp.EnEnd();
        }
        public void CopyFrom(RegionMsgInfo source) {
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_power = source.m_power;
            m_lang = source.m_lang;
            m_server_id = source.m_server_id;
            m_content = source.m_content;
            m_create_time = source.m_create_time;
        }
    }
    
    [Serializable]
    public partial class VoicechatModeInfo : NetworkMessage {
        public static int[] Id = { 425,1 };
        public static Ctrl VC;
        public Boolean m_statu;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_statu = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_statu);}
            sp.EnEnd();
        }
        public void CopyFrom(VoicechatModeInfo source) {
            m_statu = source.m_statu;
        }
    }
    
    [Serializable]
    public partial class SetGovernmentFlagInfo : NetworkMessage {
        public static int[] Id = { 431,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public SByte m_flag_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_flag_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_flag_id);}
            sp.EnEnd();
        }
        public void CopyFrom(SetGovernmentFlagInfo source) {
            m_server_id = source.m_server_id;
            m_flag_id = source.m_flag_id;
        }
    }
    
    [Serializable]
    public partial class ZoneBriefReqInfo : NetworkMessage {
        public static int[] Id = { 437,1 };
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
        public void CopyFrom(ZoneBriefReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class PveInfo : NetworkMessage {
        public static int[] Id = { 443,1 };
        public static Ctrl VC;
        public Int32 m_user_ap;
        public Int32 m_atk_ap;
        public Int32 m_rally_ap;
        public Int32 m_ap_max;
        public Int32 m_recover;
        public Int64 m_update_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_ap = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_atk_ap = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_rally_ap = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_ap_max = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_recover = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_update_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_ap);}
            if (sp.TryWrite(1)) {sp.Write(m_atk_ap);}
            if (sp.TryWrite(2)) {sp.Write(m_rally_ap);}
            if (sp.TryWrite(3)) {sp.Write(m_ap_max);}
            if (sp.TryWrite(4)) {sp.Write(m_recover);}
            if (sp.TryWrite(5)) {sp.Write(m_update_time);}
            sp.EnEnd();
        }
        public void CopyFrom(PveInfo source) {
            m_user_ap = source.m_user_ap;
            m_atk_ap = source.m_atk_ap;
            m_rally_ap = source.m_rally_ap;
            m_ap_max = source.m_ap_max;
            m_recover = source.m_recover;
            m_update_time = source.m_update_time;
        }
    }
    
    [Serializable]
    public partial class FightGroupInfo : NetworkMessage {
        public static int[] Id = { 449,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public List<Int16> m_servers = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_servers.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_servers.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_servers.Count);
                for (int i = 0; i != m_servers.Count; ++i) {
                    sp.Write(m_servers[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FightGroupInfo source) {
            m_id = source.m_id;
            m_servers = source.m_servers;
        }
    }
    
    [Serializable]
    public partial class HuodongDetailInfo : NetworkMessage {
        public static int[] Id = { 455,1 };
        public static Ctrl VC;
        public ActivityBaseInfo m_base_info;
        public Int64 m_points;
        public Int32 m_rank;
        public String m_rule_desc = "";
        public Int64 m_rank_score;
        public List<HuodongRankInfo> m_rank_info = new List<HuodongRankInfo>();
        public List<HuodongRankInfo> m_adjacent_rank_info = new List<HuodongRankInfo>();
        public Boolean m_can_fly;
        public List<MemberContribute> m_details = new List<MemberContribute>();
        public SpecialRewardInfo m_special_reward;
        public List<ModuleInfo> m_modules = new List<ModuleInfo>();
        public List<HuodongParamInfo> m_huodong_params = new List<HuodongParamInfo>();
        public List<HuodongRewardInfo> m_rewards = new List<HuodongRewardInfo>();
        public List<HuodongRankRewardInfo> m_rank_rewards = new List<HuodongRankRewardInfo>();
        public List<FightGroupInfo> m_fights = new List<FightGroupInfo>();
        public String m_monster_position = "";
        public String m_option = "";
        public List<Int16> m_istana_servers = new List<Int16>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new ActivityBaseInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_points = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_rule_desc = sp.ReadString();}
            if (sp.TryRead(4)) {m_rank_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongRankInfo tmp = new HuodongRankInfo();
                    tmp.Decode(sp);
                    m_rank_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_adjacent_rank_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongRankInfo tmp = new HuodongRankInfo();
                    tmp.Decode(sp);
                    m_adjacent_rank_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {m_can_fly = sp.ReadBoolean();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_details.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MemberContribute tmp = new MemberContribute();
                    tmp.Decode(sp);
                    m_details.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                m_special_reward = new SpecialRewardInfo();
                m_special_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_modules.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ModuleInfo tmp = new ModuleInfo();
                    tmp.Decode(sp);
                    m_modules.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_huodong_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongParamInfo tmp = new HuodongParamInfo();
                    tmp.Decode(sp);
                    m_huodong_params.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongRewardInfo tmp = new HuodongRewardInfo();
                    tmp.Decode(sp);
                    m_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    HuodongRankRewardInfo tmp = new HuodongRankRewardInfo();
                    tmp.Decode(sp);
                    m_rank_rewards.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(14)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fights.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FightGroupInfo tmp = new FightGroupInfo();
                    tmp.Decode(sp);
                    m_fights.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_monster_position = sp.ReadString();}
            if (sp.TryRead(16)) {m_option = sp.ReadString();}
            if (sp.TryRead(17)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_istana_servers.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_istana_servers.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_points);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_rule_desc);}
            if (sp.TryWrite(4)) {sp.Write(m_rank_score);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info.Count);
                for (int i = 0; i != m_rank_info.Count; ++i) {
                    m_rank_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_adjacent_rank_info.Count);
                for (int i = 0; i != m_adjacent_rank_info.Count; ++i) {
                    m_adjacent_rank_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {sp.Write(m_can_fly);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_details.Count);
                for (int i = 0; i != m_details.Count; ++i) {
                    m_details[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {int pos = sp.GetPos();sp.Skip(2); m_special_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_modules.Count);
                for (int i = 0; i != m_modules.Count; ++i) {
                    m_modules[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_huodong_params.Count);
                for (int i = 0; i != m_huodong_params.Count; ++i) {
                    m_huodong_params[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rewards.Count);
                for (int i = 0; i != m_rewards.Count; ++i) {
                    m_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_rewards.Count);
                for (int i = 0; i != m_rank_rewards.Count; ++i) {
                    m_rank_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(14)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fights.Count);
                for (int i = 0; i != m_fights.Count; ++i) {
                    m_fights[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(15)) {sp.Write(m_monster_position);}
            if (sp.TryWrite(16)) {sp.Write(m_option);}
            if (sp.TryWrite(17)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_istana_servers.Count);
                for (int i = 0; i != m_istana_servers.Count; ++i) {
                    sp.Write(m_istana_servers[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(HuodongDetailInfo source) {
            m_base_info = source.m_base_info;
            m_points = source.m_points;
            m_rank = source.m_rank;
            m_rule_desc = source.m_rule_desc;
            m_rank_score = source.m_rank_score;
            m_rank_info = source.m_rank_info;
            m_adjacent_rank_info = source.m_adjacent_rank_info;
            m_can_fly = source.m_can_fly;
            m_details = source.m_details;
            m_special_reward = source.m_special_reward;
            m_modules = source.m_modules;
            m_huodong_params = source.m_huodong_params;
            m_rewards = source.m_rewards;
            m_rank_rewards = source.m_rank_rewards;
            m_fights = source.m_fights;
            m_monster_position = source.m_monster_position;
            m_option = source.m_option;
            m_istana_servers = source.m_istana_servers;
        }
    }
    
    [Serializable]
    public partial class SelectAvatarInfo : NetworkMessage {
        public static int[] Id = { 461,1 };
        public static Ctrl VC;
        public String m_avatar = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_avatar = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_avatar);}
            sp.EnEnd();
        }
        public void CopyFrom(SelectAvatarInfo source) {
            m_avatar = source.m_avatar;
        }
    }
    
    [Serializable]
    public partial class SpecialQuestRewardInfo : NetworkMessage {
        public static int[] Id = { 467,1 };
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
        public void CopyFrom(SpecialQuestRewardInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class AllianceDonateInfoList : NetworkMessage {
        public static int[] Id = { 473,1 };
        public static Ctrl VC;
        public List<AllianceDonateInfo> m_donate_list = new List<AllianceDonateInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_donate_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceDonateInfo tmp = new AllianceDonateInfo();
                    tmp.Decode(sp);
                    m_donate_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_donate_list.Count);
                for (int i = 0; i != m_donate_list.Count; ++i) {
                    m_donate_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceDonateInfoList source) {
            m_donate_list = source.m_donate_list;
        }
    }
    
    [Serializable]
    public partial class VoteDetail : NetworkMessage {
        public static int[] Id = { 479,1 };
        public static Ctrl VC;
        public Int64 m_vote_id;
        public AllianceSnapInfo m_alliance;
        public VoteFounder m_founder;
        public String m_title = "";
        public String m_desc = "";
        public List<String> m_options = new List<String>();
        public SByte m_expiry;
        public SByte m_choice;
        public Int64 m_created;
        public Int64 m_duration;
        public List<TicketStatus> m_result = new List<TicketStatus>();
        public Boolean m_voted;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_vote_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_alliance = new AllianceSnapInfo();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_founder = new VoteFounder();
                m_founder.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_desc = sp.ReadString();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_options.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_options.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {m_expiry = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_choice = sp.ReadSByte();}
            if (sp.TryRead(8)) {m_created = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_duration = sp.ReadInt64();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TicketStatus tmp = new TicketStatus();
                    tmp.Decode(sp);
                    m_result.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_voted = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_vote_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_founder.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_desc);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_options.Count);
                for (int i = 0; i != m_options.Count; ++i) {
                    sp.Write(m_options[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {sp.Write(m_expiry);}
            if (sp.TryWrite(7)) {sp.Write(m_choice);}
            if (sp.TryWrite(8)) {sp.Write(m_created);}
            if (sp.TryWrite(9)) {sp.Write(m_duration);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_result.Count);
                for (int i = 0; i != m_result.Count; ++i) {
                    m_result[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_voted);}
            sp.EnEnd();
        }
        public void CopyFrom(VoteDetail source) {
            m_vote_id = source.m_vote_id;
            m_alliance = source.m_alliance;
            m_founder = source.m_founder;
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_options = source.m_options;
            m_expiry = source.m_expiry;
            m_choice = source.m_choice;
            m_created = source.m_created;
            m_duration = source.m_duration;
            m_result = source.m_result;
            m_voted = source.m_voted;
        }
    }
    
    [Serializable]
    public partial class ScrollEventRank : NetworkMessage {
        public static int[] Id = { 485,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_user_alliance;
        public AllianceSnapInfo m_alliance_snap;
        public SByte m_event_type;
        public SByte m_event;
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
            if (sp.TryRead(4)) {
                m_alliance_snap = new AllianceSnapInfo();
                m_alliance_snap.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_event_type = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_event = sp.ReadSByte();}
            if (sp.TryRead(7)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_alliance_snap.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_event_type);}
            if (sp.TryWrite(6)) {sp.Write(m_event);}
            if (sp.TryWrite(7)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollEventRank source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_user_alliance = source.m_user_alliance;
            m_alliance_snap = source.m_alliance_snap;
            m_event_type = source.m_event_type;
            m_event = source.m_event;
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class ResOrderInfo : NetworkMessage {
        public static int[] Id = { 491,1 };
        public static Ctrl VC;
        public String m_order_number = "";
        public String m_access_key = "";
        public String m_signature = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order_number = sp.ReadString();}
            if (sp.TryRead(1)) {m_access_key = sp.ReadString();}
            if (sp.TryRead(2)) {m_signature = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order_number);}
            if (sp.TryWrite(1)) {sp.Write(m_access_key);}
            if (sp.TryWrite(2)) {sp.Write(m_signature);}
            sp.EnEnd();
        }
        public void CopyFrom(ResOrderInfo source) {
            m_order_number = source.m_order_number;
            m_access_key = source.m_access_key;
            m_signature = source.m_signature;
        }
    }
    
    [Serializable]
    public partial class GetAllianceResearchListReqInfo : NetworkMessage {
        public static int[] Id = { 497,1 };
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
        public void CopyFrom(GetAllianceResearchListReqInfo source) {
            m_type = source.m_type;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDetailInfo : NetworkMessage {
        public static int[] Id = { 503,1 };
        public static Ctrl VC;
        public AllianceResearchBaseInfo m_base_info;
        public Int16 m_effect_id;
        public Int64 m_effect_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new AllianceResearchBaseInfo();
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
        public void CopyFrom(AllianceResearchDetailInfo source) {
            m_base_info = source.m_base_info;
            m_effect_id = source.m_effect_id;
            m_effect_num = source.m_effect_num;
        }
    }
    
    [Serializable]
    public partial class UserExtraInfo : NetworkMessage {
        public static int[] Id = { 509,1 };
        public static Ctrl VC;
        public Boolean m_santa;
        public List<Int32> m_plat_reward_status = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_santa = sp.ReadBoolean();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_plat_reward_status.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_plat_reward_status.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_santa);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_plat_reward_status.Count);
                for (int i = 0; i != m_plat_reward_status.Count; ++i) {
                    sp.Write(m_plat_reward_status[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserExtraInfo source) {
            m_santa = source.m_santa;
            m_plat_reward_status = source.m_plat_reward_status;
        }
    }
    
    [Serializable]
    public partial class AllianceResearchDonateRankRewardsInfo : NetworkMessage {
        public static int[] Id = { 515,1 };
        public static Ctrl VC;
        public Int32 m_rankD;
        public Int32 m_rankU;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rankD = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_rankU = sp.ReadInt32();}
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
            if (sp.TryWrite(0)) {sp.Write(m_rankD);}
            if (sp.TryWrite(1)) {sp.Write(m_rankU);}
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
        public void CopyFrom(AllianceResearchDonateRankRewardsInfo source) {
            m_rankD = source.m_rankD;
            m_rankU = source.m_rankU;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class RebelAttackRewardDetailInfo : NetworkMessage {
        public static int[] Id = { 521,1 };
        public static Ctrl VC;
        public RebelAttackRewardBaseInfo m_base_info;
        public List<ItemInfo> m_items = new List<ItemInfo>();
        public Int64 m_hp_max;
        public Int64 m_hp_killed;
        public Int64 m_hp_user_killed;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new RebelAttackRewardBaseInfo();
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
            if (sp.TryRead(2)) {m_hp_max = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_hp_killed = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_hp_user_killed = sp.ReadInt64();}
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
            if (sp.TryWrite(4)) {sp.Write(m_hp_user_killed);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelAttackRewardDetailInfo source) {
            m_base_info = source.m_base_info;
            m_items = source.m_items;
            m_hp_max = source.m_hp_max;
            m_hp_killed = source.m_hp_killed;
            m_hp_user_killed = source.m_hp_user_killed;
        }
    }
    
    [Serializable]
    public partial class MailPrereadSwitchInfo : NetworkMessage {
        public static int[] Id = { 527,1 };
        public static Ctrl VC;
        public SByte m_open;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_open = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_open);}
            sp.EnEnd();
        }
        public void CopyFrom(MailPrereadSwitchInfo source) {
            m_open = source.m_open;
        }
    }
    
    [Serializable]
    public partial class RegionUserReqInfo : NetworkMessage {
        public static int[] Id = { 533,1 };
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
        public void CopyFrom(RegionUserReqInfo source) {
            m_region_user_id = source.m_region_user_id;
            m_user_server_id = source.m_user_server_id;
            m_user_id = source.m_user_id;
        }
    }
    
    [Serializable]
    public partial class ComeBackItemInfo : NetworkMessage {
        public static int[] Id = { 539,1 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_item_sub_id;
        public Int32 m_item_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_sub_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_sub_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(ComeBackItemInfo source) {
            m_item_id = source.m_item_id;
            m_item_sub_id = source.m_item_sub_id;
            m_item_cnt = source.m_item_cnt;
        }
    }
    
    [Serializable]
    public partial class DoRewardsDetailInfo : NetworkMessage {
        public static int[] Id = { 545,1 };
        public static Ctrl VC;
        public SByte m_result;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_result = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_result);}
            sp.EnEnd();
        }
        public void CopyFrom(DoRewardsDetailInfo source) {
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class ClientConfigDetail : NetworkMessage {
        public static int[] Id = { 551,1 };
        public static Ctrl VC;
        public String m_key = "";
        public SByte m_value;
        public Int64 m_v;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_key = sp.ReadString();}
            if (sp.TryRead(1)) {m_value = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_v = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_key);}
            if (sp.TryWrite(1)) {sp.Write(m_value);}
            if (sp.TryWrite(2)) {sp.Write(m_v);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientConfigDetail source) {
            m_key = source.m_key;
            m_value = source.m_value;
            m_v = source.m_v;
        }
    }
    
    [Serializable]
    public partial class AsBossSummonBaseInfo : NetworkMessage {
        public static int[] Id = { 557,1 };
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
        public void CopyFrom(AsBossSummonBaseInfo source) {
            m_x = source.m_x;
            m_y = source.m_y;
        }
    }
    
    [Serializable]
    public partial class IstanaDeclareWarReqInfo : NetworkMessage {
        public static int[] Id = { 563,1 };
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
        public void CopyFrom(IstanaDeclareWarReqInfo source) {
            m_server_id = source.m_server_id;
        }
    }
    
    [Serializable]
    public partial class IstanaTitle : NetworkMessage {
        public static int[] Id = { 569,1 };
        public static Ctrl VC;
        public Int16 m_title_id;
        public Int16 m_server_id;
        public Int64 m_cdtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cdtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {sp.Write(m_server_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cdtime);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaTitle source) {
            m_title_id = source.m_title_id;
            m_server_id = source.m_server_id;
            m_cdtime = source.m_cdtime;
        }
    }
    
    [Serializable]
    public partial class FlagsRankInfo : NetworkMessage {
        public static int[] Id = { 575,1 };
        public static Ctrl VC;
        public List<FlagRankInfo> m_rank_info = new List<FlagRankInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FlagRankInfo tmp = new FlagRankInfo();
                    tmp.Decode(sp);
                    m_rank_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank_info.Count);
                for (int i = 0; i != m_rank_info.Count; ++i) {
                    m_rank_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FlagsRankInfo source) {
            m_rank_info = source.m_rank_info;
        }
    }
    
    [Serializable]
    public partial class IstanaSnap : NetworkMessage {
        public static int[] Id = { 581,1 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int32 m_alliance_id;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_alliance_id);}
            if (sp.TryWrite(2)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(IstanaSnap source) {
            m_server_id = source.m_server_id;
            m_alliance_id = source.m_alliance_id;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class GuestIstanaBaseReqInfo : NetworkMessage {
        public static int[] Id = { 587,1 };
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
        public void CopyFrom(GuestIstanaBaseReqInfo source) {
            m_server_id = source.m_server_id;
            m_region_user_id = source.m_region_user_id;
        }
    }
    
    [Serializable]
    public partial class MactingReportDetailInfo : NetworkMessage {
        public static int[] Id = { 593,1 };
        public static Ctrl VC;
        public MactingReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new MactingReportBaseInfo();
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
        public void CopyFrom(MactingReportDetailInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class CommanderSkillResInfo : NetworkMessage {
        public static int[] Id = { 599,1 };
        public static Ctrl VC;
        public List<ResTypeInfo> m_resource = new List<ResTypeInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_resource.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_resource.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_resource.Count);
                for (int i = 0; i != m_resource.Count; ++i) {
                    m_resource[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CommanderSkillResInfo source) {
            m_resource = source.m_resource;
        }
    }
    
    [Serializable]
    public partial class CrowdInvestRewardReportInfo : NetworkMessage {
        public static int[] Id = { 605,1 };
        public static Ctrl VC;
        public CrowdInvestRewardReportBaseInfo m_base_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new CrowdInvestRewardReportBaseInfo();
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
        public void CopyFrom(CrowdInvestRewardReportInfo source) {
            m_base_info = source.m_base_info;
        }
    }
    
    [Serializable]
    public partial class ChargeSignInDatailInfo : NetworkMessage {
        public static int[] Id = { 611,1 };
        public static Ctrl VC;
        public SByte m_tatoal_charge_dst_cnt;
        public SByte m_tatoal_charge_reward_status;
        public SByte m_tatoal_charge_charge_cnt;
        public Int16 m_tatoal_charge_reward_cnt;
        public Int32 m_tatoal_charge_reward_id;
        public List<DaythRewardInfo> m_daily_reward_detail = new List<DaythRewardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_tatoal_charge_dst_cnt = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_tatoal_charge_reward_status = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_tatoal_charge_charge_cnt = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_tatoal_charge_reward_cnt = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_tatoal_charge_reward_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_daily_reward_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    DaythRewardInfo tmp = new DaythRewardInfo();
                    tmp.Decode(sp);
                    m_daily_reward_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_tatoal_charge_dst_cnt);}
            if (sp.TryWrite(1)) {sp.Write(m_tatoal_charge_reward_status);}
            if (sp.TryWrite(2)) {sp.Write(m_tatoal_charge_charge_cnt);}
            if (sp.TryWrite(3)) {sp.Write(m_tatoal_charge_reward_cnt);}
            if (sp.TryWrite(4)) {sp.Write(m_tatoal_charge_reward_id);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_daily_reward_detail.Count);
                for (int i = 0; i != m_daily_reward_detail.Count; ++i) {
                    m_daily_reward_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ChargeSignInDatailInfo source) {
            m_tatoal_charge_dst_cnt = source.m_tatoal_charge_dst_cnt;
            m_tatoal_charge_reward_status = source.m_tatoal_charge_reward_status;
            m_tatoal_charge_charge_cnt = source.m_tatoal_charge_charge_cnt;
            m_tatoal_charge_reward_cnt = source.m_tatoal_charge_reward_cnt;
            m_tatoal_charge_reward_id = source.m_tatoal_charge_reward_id;
            m_daily_reward_detail = source.m_daily_reward_detail;
        }
    }
    
    [Serializable]
    public partial class SevendayTaskId : NetworkMessage {
        public static int[] Id = { 617,1 };
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
        public void CopyFrom(SevendayTaskId source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class FpsEndBattleReqInfo : NetworkMessage {
        public static int[] Id = { 623,1 };
        public static Ctrl VC;
        public Int32 m_hp;
        public Int32 m_score;
        public Int32 m_kill_num;
        public Int32 m_head_kill_num;
        public Int16 m_fps_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_hp = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_kill_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_head_kill_num = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_fps_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_hp);}
            if (sp.TryWrite(1)) {sp.Write(m_score);}
            if (sp.TryWrite(2)) {sp.Write(m_kill_num);}
            if (sp.TryWrite(3)) {sp.Write(m_head_kill_num);}
            if (sp.TryWrite(4)) {sp.Write(m_fps_level);}
            sp.EnEnd();
        }
        public void CopyFrom(FpsEndBattleReqInfo source) {
            m_hp = source.m_hp;
            m_score = source.m_score;
            m_kill_num = source.m_kill_num;
            m_head_kill_num = source.m_head_kill_num;
            m_fps_level = source.m_fps_level;
        }
    }
    
    [Serializable]
    public partial class FpsSweepAckInfo : NetworkMessage {
        public static int[] Id = { 629,1 };
        public static Ctrl VC;
        public Int16 m_sweep_cnt;
        public List<FpsRewardInfo> m_reward_info_list = new List<FpsRewardInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sweep_cnt = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FpsRewardInfo tmp = new FpsRewardInfo();
                    tmp.Decode(sp);
                    m_reward_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sweep_cnt);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_info_list.Count);
                for (int i = 0; i != m_reward_info_list.Count; ++i) {
                    m_reward_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FpsSweepAckInfo source) {
            m_sweep_cnt = source.m_sweep_cnt;
            m_reward_info_list = source.m_reward_info_list;
        }
    }
    
    [Serializable]
    public partial class GloryWallsInfo : NetworkMessage {
        public static int[] Id = { 635,1 };
        public static Ctrl VC;
        public List<GloryWallsDetail> m_list = new List<GloryWallsDetail>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GloryWallsDetail tmp = new GloryWallsDetail();
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
        public void CopyFrom(GloryWallsInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class BestBattleReportBaseInfo : NetworkMessage {
        public static int[] Id = { 641,1 };
        public static Ctrl VC;
        public Int32 m_rank;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            sp.EnEnd();
        }
        public void CopyFrom(BestBattleReportBaseInfo source) {
            m_rank = source.m_rank;
        }
    }
    
    [Serializable]
    public partial class DailyEventIdInfo : NetworkMessage {
        public static int[] Id = { 647,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_weekly_activity_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_weekly_activity_points = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_weekly_activity_points);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyEventIdInfo source) {
            m_id = source.m_id;
            m_weekly_activity_points = source.m_weekly_activity_points;
        }
    }
    
    [Serializable]
    public partial class ZvzUnitedGroupList : NetworkMessage {
        public static int[] Id = { 653,1 };
        public static Ctrl VC;
        public List<ZvzUnitedGroup> m_groups = new List<ZvzUnitedGroup>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ZvzUnitedGroup tmp = new ZvzUnitedGroup();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            sp.EnEnd();
        }
        public void CopyFrom(ZvzUnitedGroupList source) {
            m_groups = source.m_groups;
        }
    }
    
    [Serializable]
    public partial class CaptchaConfigRecord : NetworkMessage {
        public static int[] Id = { 659,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_lower_level;
        public Int16 m_upper_level;
        public Boolean m_status;
        public List<Int32> m_interval = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_lower_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_upper_level = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_status = sp.ReadBoolean();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_interval.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_interval.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_lower_level);}
            if (sp.TryWrite(2)) {sp.Write(m_upper_level);}
            if (sp.TryWrite(3)) {sp.Write(m_status);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_interval.Count);
                for (int i = 0; i != m_interval.Count; ++i) {
                    sp.Write(m_interval[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptchaConfigRecord source) {
            m_id = source.m_id;
            m_lower_level = source.m_lower_level;
            m_upper_level = source.m_upper_level;
            m_status = source.m_status;
            m_interval = source.m_interval;
        }
    }
    
    [Serializable]
    public partial class RewardItemInfo : NetworkMessage {
        public static int[] Id = { 665,1 };
        public static Ctrl VC;
        public Int32 m_type;
        public Int64 m_val;
        public Int64 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_val = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_val);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(RewardItemInfo source) {
            m_type = source.m_type;
            m_val = source.m_val;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class GdcfgAckInfo : NetworkMessage {
        public static int[] Id = { 671,1 };
        public static Ctrl VC;
        public List<String> m_first_line = new List<String>();
        public List<String> m_n_line = new List<String>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_first_line.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_first_line.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_n_line.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    String tmp = sp.ReadString();
                    m_n_line.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_first_line.Count);
                for (int i = 0; i != m_first_line.Count; ++i) {
                    sp.Write(m_first_line[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_n_line.Count);
                for (int i = 0; i != m_n_line.Count; ++i) {
                    sp.Write(m_n_line[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GdcfgAckInfo source) {
            m_first_line = source.m_first_line;
            m_n_line = source.m_n_line;
        }
    }
    
    [Serializable]
    public partial class ScrollMobUser : NetworkMessage {
        public static int[] Id = { 677,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_alliance;
        public Int64 m_score;

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
            if (sp.TryRead(4)) {m_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollMobUser source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_alliance = source.m_alliance;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class ScrollSoloEventRank : NetworkMessage {
        public static int[] Id = { 683,1 };
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
        public void CopyFrom(ScrollSoloEventRank source) {
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
    public partial class ScrollGachaHarvest : NetworkMessage {
        public static int[] Id = { 689,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_home_server_id;
        public UserAllianceBrief m_user_alliance;
        public Int32 m_item_id;
        public Int32 m_item_cnt;

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
            if (sp.TryRead(4)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_item_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_home_server_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_user_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {sp.Write(m_item_id);}
            if (sp.TryWrite(5)) {sp.Write(m_item_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(ScrollGachaHarvest source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_home_server_id = source.m_home_server_id;
            m_user_alliance = source.m_user_alliance;
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
        }
    }
    
    [Serializable]
    public partial class FpsChangeAgentInfo : NetworkMessage {
        public static int[] Id = { 695,1 };
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
        public void CopyFrom(FpsChangeAgentInfo source) {
            m_agent_id = source.m_agent_id;
        }
    }
    
    [Serializable]
    public partial class NewAgentInfo : NetworkMessage {
        public static int[] Id = { 701,1 };
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
        public void CopyFrom(NewAgentInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class UserTaskTracking : NetworkMessage {
        public static int[] Id = { 707,1 };
        public static Ctrl VC;
        public Int64 m_event_id;
        public String m_task_id = "";
        public String m_task_sub_id = "";
        public Int32 m_task_type;
        public Int64 m_task_score;
        public Int32 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_event_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_task_id = sp.ReadString();}
            if (sp.TryRead(2)) {m_task_sub_id = sp.ReadString();}
            if (sp.TryRead(3)) {m_task_type = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_task_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_status = sp.ReadInt32();}
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
            sp.EnEnd();
        }
        public void CopyFrom(UserTaskTracking source) {
            m_event_id = source.m_event_id;
            m_task_id = source.m_task_id;
            m_task_sub_id = source.m_task_sub_id;
            m_task_type = source.m_task_type;
            m_task_score = source.m_task_score;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class FpsSpecialLevelStartReqInfo : NetworkMessage {
        public static int[] Id = { 713,1 };
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
        public void CopyFrom(FpsSpecialLevelStartReqInfo source) {
            m_level_id = source.m_level_id;
        }
    }
    
    [Serializable]
    public partial class CampaignReqInfo : NetworkMessage {
        public static int[] Id = { 719,1 };
        public static Ctrl VC;
        public List<CampaignReqItemInfo> m_items = new List<CampaignReqItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignReqItemInfo tmp = new CampaignReqItemInfo();
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
        public void CopyFrom(CampaignReqInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class RebelCampaignInfo : NetworkMessage {
        public static int[] Id = { 725,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseRebelTaskInfo> m_task_info = new List<BaseRebelTaskInfo>();
        public Int64 m_p_point;
        public Int64 m_g_point;
        public List<ItemInfo> m_review = new List<ItemInfo>();
        public Int64 m_stop_join_dt;

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
                    BaseRebelTaskInfo tmp = new BaseRebelTaskInfo();
                    tmp.Decode(sp);
                    m_task_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_p_point = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_g_point = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_review.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_review.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_stop_join_dt = sp.ReadInt64();}
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
            if (sp.TryWrite(2)) {sp.Write(m_p_point);}
            if (sp.TryWrite(3)) {sp.Write(m_g_point);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_review.Count);
                for (int i = 0; i != m_review.Count; ++i) {
                    m_review[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_stop_join_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(RebelCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_task_info = source.m_task_info;
            m_p_point = source.m_p_point;
            m_g_point = source.m_g_point;
            m_review = source.m_review;
            m_stop_join_dt = source.m_stop_join_dt;
        }
    }
    
    [Serializable]
    public partial class ExchangeCampaignInfo : NetworkMessage {
        public static int[] Id = { 731,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();

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
            sp.EnEnd();
        }
        public void CopyFrom(ExchangeCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
        }
    }
    
    [Serializable]
    public partial class BaseMapExploreCampaignInfo : NetworkMessage {
        public static int[] Id = { 737,1 };
        public static Ctrl VC;
        public Int32 m_daily_fuel_max;
        public Int32 m_fuel_max;
        public Int32 m_initial_fuel_num;
        public Int32 m_fuel_recover_sec;
        public Int32 m_coin_item_id;
        public Int16 m_airdrop_w;
        public Int16 m_airdrop_h;
        public Int16 m_aircraft_w;
        public Int16 m_aircraft_h;
        public Int16 m_mine_w;
        public Int16 m_mine_h;
        public Int16 m_storehouse_w;
        public Int16 m_storehouse_h;
        public Int16 m_mystery_house_w;
        public Int16 m_mystery_house_h;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_daily_fuel_max = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_fuel_max = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_initial_fuel_num = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_fuel_recover_sec = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_coin_item_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_airdrop_w = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_airdrop_h = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_aircraft_w = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_aircraft_h = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_mine_w = sp.ReadInt16();}
            if (sp.TryRead(10)) {m_mine_h = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_storehouse_w = sp.ReadInt16();}
            if (sp.TryRead(12)) {m_storehouse_h = sp.ReadInt16();}
            if (sp.TryRead(13)) {m_mystery_house_w = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_mystery_house_h = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_daily_fuel_max);}
            if (sp.TryWrite(1)) {sp.Write(m_fuel_max);}
            if (sp.TryWrite(2)) {sp.Write(m_initial_fuel_num);}
            if (sp.TryWrite(3)) {sp.Write(m_fuel_recover_sec);}
            if (sp.TryWrite(4)) {sp.Write(m_coin_item_id);}
            if (sp.TryWrite(5)) {sp.Write(m_airdrop_w);}
            if (sp.TryWrite(6)) {sp.Write(m_airdrop_h);}
            if (sp.TryWrite(7)) {sp.Write(m_aircraft_w);}
            if (sp.TryWrite(8)) {sp.Write(m_aircraft_h);}
            if (sp.TryWrite(9)) {sp.Write(m_mine_w);}
            if (sp.TryWrite(10)) {sp.Write(m_mine_h);}
            if (sp.TryWrite(11)) {sp.Write(m_storehouse_w);}
            if (sp.TryWrite(12)) {sp.Write(m_storehouse_h);}
            if (sp.TryWrite(13)) {sp.Write(m_mystery_house_w);}
            if (sp.TryWrite(14)) {sp.Write(m_mystery_house_h);}
            sp.EnEnd();
        }
        public void CopyFrom(BaseMapExploreCampaignInfo source) {
            m_daily_fuel_max = source.m_daily_fuel_max;
            m_fuel_max = source.m_fuel_max;
            m_initial_fuel_num = source.m_initial_fuel_num;
            m_fuel_recover_sec = source.m_fuel_recover_sec;
            m_coin_item_id = source.m_coin_item_id;
            m_airdrop_w = source.m_airdrop_w;
            m_airdrop_h = source.m_airdrop_h;
            m_aircraft_w = source.m_aircraft_w;
            m_aircraft_h = source.m_aircraft_h;
            m_mine_w = source.m_mine_w;
            m_mine_h = source.m_mine_h;
            m_storehouse_w = source.m_storehouse_w;
            m_storehouse_h = source.m_storehouse_h;
            m_mystery_house_w = source.m_mystery_house_w;
            m_mystery_house_h = source.m_mystery_house_h;
        }
    }
    
    [Serializable]
    public partial class ResizeableGridViewReqInfo : NetworkMessage {
        public static int[] Id = { 743,1 };
        public static Ctrl VC;
        public TilePos m_center;
        public Int16 m_width;
        public Int16 m_height;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_center = new TilePos();
                m_center.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_width = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_height = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_center.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_width);}
            if (sp.TryWrite(2)) {sp.Write(m_height);}
            sp.EnEnd();
        }
        public void CopyFrom(ResizeableGridViewReqInfo source) {
            m_center = source.m_center;
            m_width = source.m_width;
            m_height = source.m_height;
        }
    }
    
    [Serializable]
    public partial class SevendayAllInfo : NetworkMessage {
        public static int[] Id = { 749,1 };
        public static Ctrl VC;
        public List<SevendayTaskInfo> m_info = new List<SevendayTaskInfo>();
        public SByte m_current_day;
        public List<SevendayPageInfo> m_page_info = new List<SevendayPageInfo>();
        public List<SevendayFinalRewardItem> m_final_rewards = new List<SevendayFinalRewardItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SevendayTaskInfo tmp = new SevendayTaskInfo();
                    tmp.Decode(sp);
                    m_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_current_day = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_page_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SevendayPageInfo tmp = new SevendayPageInfo();
                    tmp.Decode(sp);
                    m_page_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_final_rewards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SevendayFinalRewardItem tmp = new SevendayFinalRewardItem();
                    tmp.Decode(sp);
                    m_final_rewards.Add(tmp);
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
            if (sp.TryWrite(1)) {sp.Write(m_current_day);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_page_info.Count);
                for (int i = 0; i != m_page_info.Count; ++i) {
                    m_page_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_final_rewards.Count);
                for (int i = 0; i != m_final_rewards.Count; ++i) {
                    m_final_rewards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SevendayAllInfo source) {
            m_info = source.m_info;
            m_current_day = source.m_current_day;
            m_page_info = source.m_page_info;
            m_final_rewards = source.m_final_rewards;
        }
    }
    
    [Serializable]
    public partial class ClientLoadV2ReqInfo : NetworkMessage {
        public static int[] Id = { 755,1 };
        public static Ctrl VC;
        public Int32 m_ver;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ver = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_ver);}
            sp.EnEnd();
        }
        public void CopyFrom(ClientLoadV2ReqInfo source) {
            m_ver = source.m_ver;
        }
    }
    
    [Serializable]
    public partial class DailyFreePackItem : NetworkMessage {
        public static int[] Id = { 761,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_cnt;
        public Int64 m_value;
        public SByte m_show;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_cnt = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_value = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_show = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_value);}
            if (sp.TryWrite(3)) {sp.Write(m_show);}
            sp.EnEnd();
        }
        public void CopyFrom(DailyFreePackItem source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
            m_value = source.m_value;
            m_show = source.m_show;
        }
    }
    
    [Serializable]
    public partial class SecondPurchaseRewardReqInfo : NetworkMessage {
        public static int[] Id = { 767,1 };
        public static Ctrl VC;
        public SByte m_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            sp.EnEnd();
        }
        public void CopyFrom(SecondPurchaseRewardReqInfo source) {
            m_index = source.m_index;
        }
    }
    
    [Serializable]
    public partial class SafeBoxInfo : NetworkMessage {
        public static int[] Id = { 773,1 };
        public static Ctrl VC;
        public SByte m_box_type;
        public SByte m_box_status;
        public Int64 m_diamond_save;
        public Int32 m_pkg;
        public Int32 m_price;
        public Int64 m_time_limit;
        public Int32 m_pkg_ex;
        public Int32 m_price_ex;
        public Int64 m_time_limit_ex;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_box_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_box_status = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_diamond_save = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_pkg = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_price = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_time_limit = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_pkg_ex = sp.ReadInt32();}
            if (sp.TryRead(7)) {m_price_ex = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_time_limit_ex = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_box_type);}
            if (sp.TryWrite(1)) {sp.Write(m_box_status);}
            if (sp.TryWrite(2)) {sp.Write(m_diamond_save);}
            if (sp.TryWrite(3)) {sp.Write(m_pkg);}
            if (sp.TryWrite(4)) {sp.Write(m_price);}
            if (sp.TryWrite(5)) {sp.Write(m_time_limit);}
            if (sp.TryWrite(6)) {sp.Write(m_pkg_ex);}
            if (sp.TryWrite(7)) {sp.Write(m_price_ex);}
            if (sp.TryWrite(8)) {sp.Write(m_time_limit_ex);}
            sp.EnEnd();
        }
        public void CopyFrom(SafeBoxInfo source) {
            m_box_type = source.m_box_type;
            m_box_status = source.m_box_status;
            m_diamond_save = source.m_diamond_save;
            m_pkg = source.m_pkg;
            m_price = source.m_price;
            m_time_limit = source.m_time_limit;
            m_pkg_ex = source.m_pkg_ex;
            m_price_ex = source.m_price_ex;
            m_time_limit_ex = source.m_time_limit_ex;
        }
    }
    
    [Serializable]
    public partial class ChapterMission : NetworkMessage {
        public static int[] Id = { 779,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int16 m_chapter_mission_id;
        public List<Int16> m_mission_id_list = new List<Int16>();
        public String m_title = "";
        public String m_desc = "";
        public String m_pic = "";
        public Int16 m_unlock_hq_lv;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_chapter_mission_id = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_mission_id_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_mission_id_list.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {m_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_desc = sp.ReadString();}
            if (sp.TryRead(5)) {m_pic = sp.ReadString();}
            if (sp.TryRead(6)) {m_unlock_hq_lv = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_chapter_mission_id);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_mission_id_list.Count);
                for (int i = 0; i != m_mission_id_list.Count; ++i) {
                    sp.Write(m_mission_id_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {sp.Write(m_title);}
            if (sp.TryWrite(4)) {sp.Write(m_desc);}
            if (sp.TryWrite(5)) {sp.Write(m_pic);}
            if (sp.TryWrite(6)) {sp.Write(m_unlock_hq_lv);}
            sp.EnEnd();
        }
        public void CopyFrom(ChapterMission source) {
            m_id = source.m_id;
            m_chapter_mission_id = source.m_chapter_mission_id;
            m_mission_id_list = source.m_mission_id_list;
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_pic = source.m_pic;
            m_unlock_hq_lv = source.m_unlock_hq_lv;
        }
    }
    
    [Serializable]
    public partial class LandGuardRect : NetworkMessage {
        public static int[] Id = { 785,1 };
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
        public void CopyFrom(LandGuardRect source) {
            m_x = source.m_x;
            m_y = source.m_y;
            m_w = source.m_w;
            m_h = source.m_h;
        }
    }
    
    [Serializable]
    public partial class GridViewReqInfo : NetworkMessage {
        public static int[] Id = { 791,1 };
        public static Ctrl VC;
        public GridPos m_pos;
        public Boolean m_force;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new GridPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_force = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_force);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(GridViewReqInfo source) {
            m_pos = source.m_pos;
            m_force = source.m_force;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class CultureAgentListInfo : NetworkMessage {
        public static int[] Id = { 797,1 };
        public static Ctrl VC;
        public List<CultureAgentInfo> m_agent_list = new List<CultureAgentInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CultureAgentInfo tmp = new CultureAgentInfo();
                    tmp.Decode(sp);
                    m_agent_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agent_list.Count);
                for (int i = 0; i != m_agent_list.Count; ++i) {
                    m_agent_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentListInfo source) {
            m_agent_list = source.m_agent_list;
        }
    }
    
    [Serializable]
    public partial class AgentSkillUpgradeReqInfo : NetworkMessage {
        public static int[] Id = { 803,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int16 m_skill_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_skill_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_skill_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentSkillUpgradeReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_skill_id = source.m_skill_id;
        }
    }
    
    [Serializable]
    public partial class AgentTalentUpgradeReqInfo : NetworkMessage {
        public static int[] Id = { 809,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public SByte m_index;
        public Int32 m_talent_group_id;
        public SByte m_scheme_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_index = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_talent_group_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_scheme_id = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_index);}
            if (sp.TryWrite(2)) {sp.Write(m_talent_group_id);}
            if (sp.TryWrite(3)) {sp.Write(m_scheme_id);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentTalentUpgradeReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_index = source.m_index;
            m_talent_group_id = source.m_talent_group_id;
            m_scheme_id = source.m_scheme_id;
        }
    }
    
    [Serializable]
    public partial class CultureAgentTalentTable : NetworkMessage {
        public static int[] Id = { 815,1 };
        public static Ctrl VC;
        public Int32 m_heroTalentId;
        public Int32 m_heroTalentTreeId;
        public Int32 m_heroTalentGroupId;
        public SByte m_level;
        public SByte m_maxLevel;
        public List<Int32> m_preTalentIDs = new List<Int32>();
        public List<Int32> m_effects = new List<Int32>();
        public List<Int32> m_effectParams = new List<Int32>();
        public Int32 m_powerAwd;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_heroTalentId = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_heroTalentTreeId = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_heroTalentGroupId = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_maxLevel = sp.ReadSByte();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_preTalentIDs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_preTalentIDs.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_effects.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_effects.Add(tmp);
                }
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_effectParams.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_effectParams.Add(tmp);
                }
            }
            if (sp.TryRead(8)) {m_powerAwd = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_heroTalentId);}
            if (sp.TryWrite(1)) {sp.Write(m_heroTalentTreeId);}
            if (sp.TryWrite(2)) {sp.Write(m_heroTalentGroupId);}
            if (sp.TryWrite(3)) {sp.Write(m_level);}
            if (sp.TryWrite(4)) {sp.Write(m_maxLevel);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_preTalentIDs.Count);
                for (int i = 0; i != m_preTalentIDs.Count; ++i) {
                    sp.Write(m_preTalentIDs[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_effects.Count);
                for (int i = 0; i != m_effects.Count; ++i) {
                    sp.Write(m_effects[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_effectParams.Count);
                for (int i = 0; i != m_effectParams.Count; ++i) {
                    sp.Write(m_effectParams[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(8)) {sp.Write(m_powerAwd);}
            sp.EnEnd();
        }
        public void CopyFrom(CultureAgentTalentTable source) {
            m_heroTalentId = source.m_heroTalentId;
            m_heroTalentTreeId = source.m_heroTalentTreeId;
            m_heroTalentGroupId = source.m_heroTalentGroupId;
            m_level = source.m_level;
            m_maxLevel = source.m_maxLevel;
            m_preTalentIDs = source.m_preTalentIDs;
            m_effects = source.m_effects;
            m_effectParams = source.m_effectParams;
            m_powerAwd = source.m_powerAwd;
        }
    }
    
    [Serializable]
    public partial class MapBuildingDetailInfo : NetworkMessage {
        public static int[] Id = { 821,1 };
        public static Ctrl VC;
        public List<TroopGroup> m_groups = new List<TroopGroup>();
        public List<MarchInfo> m_march = new List<MarchInfo>();
        public TileDetailInfo m_info;
        public Int64 m_reinforce_limit;
        public List<BuildingGroupDetailInfo> m_group_detail = new List<BuildingGroupDetailInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TroopGroup tmp = new TroopGroup();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_march.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MarchInfo tmp = new MarchInfo();
                    tmp.Decode(sp);
                    m_march.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_info = new TileDetailInfo();
                m_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {m_reinforce_limit = sp.ReadInt64();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_group_detail.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BuildingGroupDetailInfo tmp = new BuildingGroupDetailInfo();
                    tmp.Decode(sp);
                    m_group_detail.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_map_guid = sp.ReadInt64();}
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
                sp.Write((UInt16)m_march.Count);
                for (int i = 0; i != m_march.Count; ++i) {
                    m_march[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {sp.Write(m_reinforce_limit);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_group_detail.Count);
                for (int i = 0; i != m_group_detail.Count; ++i) {
                    m_group_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(MapBuildingDetailInfo source) {
            m_groups = source.m_groups;
            m_march = source.m_march;
            m_info = source.m_info;
            m_reinforce_limit = source.m_reinforce_limit;
            m_group_detail = source.m_group_detail;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class KickRallyTroopReqInfo : NetworkMessage {
        public static int[] Id = { 827,1 };
        public static Ctrl VC;
        public Int64 m_group_id;
        public Int64 m_march_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_march_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {sp.Write(m_march_id);}
            if (sp.TryWrite(2)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(KickRallyTroopReqInfo source) {
            m_group_id = source.m_group_id;
            m_march_id = source.m_march_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class AssignMayorReqInfo : NetworkMessage {
        public static int[] Id = { 833,1 };
        public static Ctrl VC;
        public Int64 m_monument_id;
        public Int64 m_player_id;
        public Boolean m_cancel;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_monument_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_player_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_cancel = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_monument_id);}
            if (sp.TryWrite(1)) {sp.Write(m_player_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cancel);}
            sp.EnEnd();
        }
        public void CopyFrom(AssignMayorReqInfo source) {
            m_monument_id = source.m_monument_id;
            m_player_id = source.m_player_id;
            m_cancel = source.m_cancel;
        }
    }
    
    [Serializable]
    public partial class GetRtfMailListReqInfo : NetworkMessage {
        public static int[] Id = { 839,1 };
        public static Ctrl VC;
        public String m_start_id = "";
        public Boolean m_direction;
        public Int16 m_mail_type;
        public Int32 m_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_start_id = sp.ReadString();}
            if (sp.TryRead(1)) {m_direction = sp.ReadBoolean();}
            if (sp.TryRead(2)) {m_mail_type = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_start_id);}
            if (sp.TryWrite(1)) {sp.Write(m_direction);}
            if (sp.TryWrite(2)) {sp.Write(m_mail_type);}
            if (sp.TryWrite(3)) {sp.Write(m_count);}
            sp.EnEnd();
        }
        public void CopyFrom(GetRtfMailListReqInfo source) {
            m_start_id = source.m_start_id;
            m_direction = source.m_direction;
            m_mail_type = source.m_mail_type;
            m_count = source.m_count;
        }
    }
    
    [Serializable]
    public partial class DeleteRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 845,1 };
        public static Ctrl VC;
        public List<String> m_mail_id = new List<String>();
        public Boolean m_bunch_be_scout;

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
            if (sp.TryRead(1)) {m_bunch_be_scout = sp.ReadBoolean();}
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
            if (sp.TryWrite(1)) {sp.Write(m_bunch_be_scout);}
            sp.EnEnd();
        }
        public void CopyFrom(DeleteRtfMailReqInfo source) {
            m_mail_id = source.m_mail_id;
            m_bunch_be_scout = source.m_bunch_be_scout;
        }
    }
    
    [Serializable]
    public partial class GetShareBattleMailReqInfo : NetworkMessage {
        public static int[] Id = { 851,1 };
        public static Ctrl VC;
        public Int64 m_report_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_report_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_report_id);}
            sp.EnEnd();
        }
        public void CopyFrom(GetShareBattleMailReqInfo source) {
            m_report_id = source.m_report_id;
        }
    }
    
    [Serializable]
    public partial class ReadAllRtfMailReqInfo : NetworkMessage {
        public static int[] Id = { 857,1 };
        public static Ctrl VC;
        public Int16 m_category;
        public Boolean m_read_collect;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_category = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_read_collect = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_category);}
            if (sp.TryWrite(1)) {sp.Write(m_read_collect);}
            sp.EnEnd();
        }
        public void CopyFrom(ReadAllRtfMailReqInfo source) {
            m_category = source.m_category;
            m_read_collect = source.m_read_collect;
        }
    }
    
    [Serializable]
    public partial class MapMilestoneInfo : NetworkMessage {
        public static int[] Id = { 863,1 };
        public static Ctrl VC;
        public Int32 m_cur_quest;
        public Int64 m_end_time;
        public Int64 m_prog;
        public List<MapMilestoneQuestRecord> m_record = new List<MapMilestoneQuestRecord>();
        public List<AllianceRankInfo> m_rank = new List<AllianceRankInfo>();
        public List<MapMilestoneCfg> m_cfg = new List<MapMilestoneCfg>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cur_quest = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_prog = sp.ReadInt64();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapMilestoneQuestRecord tmp = new MapMilestoneQuestRecord();
                    tmp.Decode(sp);
                    m_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
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
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cfg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MapMilestoneCfg tmp = new MapMilestoneCfg();
                    tmp.Decode(sp);
                    m_cfg.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cur_quest);}
            if (sp.TryWrite(1)) {sp.Write(m_end_time);}
            if (sp.TryWrite(2)) {sp.Write(m_prog);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_record.Count);
                for (int i = 0; i != m_record.Count; ++i) {
                    m_record[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_rank.Count);
                for (int i = 0; i != m_rank.Count; ++i) {
                    m_rank[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
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
        public void CopyFrom(MapMilestoneInfo source) {
            m_cur_quest = source.m_cur_quest;
            m_end_time = source.m_end_time;
            m_prog = source.m_prog;
            m_record = source.m_record;
            m_rank = source.m_rank;
            m_cfg = source.m_cfg;
        }
    }
    
    [Serializable]
    public partial class MailRewardInfo : NetworkMessage {
        public static int[] Id = { 869,1 };
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
        public void CopyFrom(MailRewardInfo source) {
            m_items = source.m_items;
            m_res = source.m_res;
        }
    }
    
    [Serializable]
    public partial class AllianceWarehouseCostRecord : NetworkMessage {
        public static int[] Id = { 875,1 };
        public static Ctrl VC;
        public String m_member_name = "";
        public Int16 m_member_icon;
        public Int16 m_cost_reason;
        public List<Int64> m_reason_params = new List<Int64>();
        public List<ResTypeInfo> m_cost_res = new List<ResTypeInfo>();
        public Int64 m_cost_funds;
        public Int64 m_datetime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_member_name = sp.ReadString();}
            if (sp.TryRead(1)) {m_member_icon = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_cost_reason = sp.ReadInt16();}
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reason_params.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_reason_params.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cost_res.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ResTypeInfo tmp = new ResTypeInfo();
                    tmp.Decode(sp);
                    m_cost_res.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_cost_funds = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_datetime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_member_name);}
            if (sp.TryWrite(1)) {sp.Write(m_member_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_reason);}
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reason_params.Count);
                for (int i = 0; i != m_reason_params.Count; ++i) {
                    sp.Write(m_reason_params[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cost_res.Count);
                for (int i = 0; i != m_cost_res.Count; ++i) {
                    m_cost_res[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_cost_funds);}
            if (sp.TryWrite(6)) {sp.Write(m_datetime);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceWarehouseCostRecord source) {
            m_member_name = source.m_member_name;
            m_member_icon = source.m_member_icon;
            m_cost_reason = source.m_cost_reason;
            m_reason_params = source.m_reason_params;
            m_cost_res = source.m_cost_res;
            m_cost_funds = source.m_cost_funds;
            m_datetime = source.m_datetime;
        }
    }
    
    [Serializable]
    public partial class UpdateBuildingReinforceNtf : NetworkMessage {
        public static int[] Id = { 881,1 };
        public static Ctrl VC;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            sp.EnEnd();
        }
        public void CopyFrom(UpdateBuildingReinforceNtf source) {
        }
    }
    
    [Serializable]
    public partial class StartExpeditionReqInfo : NetworkMessage {
        public static int[] Id = { 887,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public List<ExpeditionTroop> m_groups = new List<ExpeditionTroop>();
        public Int32 m_client_custom_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_groups.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ExpeditionTroop tmp = new ExpeditionTroop();
                    tmp.Decode(sp);
                    m_groups.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_client_custom_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_groups.Count);
                for (int i = 0; i != m_groups.Count; ++i) {
                    m_groups[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_client_custom_id);}
            sp.EnEnd();
        }
        public void CopyFrom(StartExpeditionReqInfo source) {
            m_id = source.m_id;
            m_groups = source.m_groups;
            m_client_custom_id = source.m_client_custom_id;
        }
    }
    
    [Serializable]
    public partial class ExpeditionCheckpointStateInfo : NetworkMessage {
        public static int[] Id = { 893,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_state;
        public ExpeditionRewardStateInfo m_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_state = sp.ReadSByte();}
            if (sp.TryRead(2)) {
                m_reward = new ExpeditionRewardStateInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_state);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(ExpeditionCheckpointStateInfo source) {
            m_id = source.m_id;
            m_state = source.m_state;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class StepTaskHistoryUserInfo : NetworkMessage {
        public static int[] Id = { 899,1 };
        public static Ctrl VC;
        public Int32 m_rank;
        public String m_asAbbr = "";
        public String m_userName = "";
        public Int64 m_score;
        public Int16 m_icon;
        public String m_avatar = "";
        public Int16 m_avatar_frame;
        public Int16 m_vip_level;
        public Int64 m_user_id;
        public Int16 m_user_server;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_asAbbr = sp.ReadString();}
            if (sp.TryRead(2)) {m_userName = sp.ReadString();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(6)) {m_avatar_frame = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_vip_level = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(9)) {m_user_server = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_rank);}
            if (sp.TryWrite(1)) {sp.Write(m_asAbbr);}
            if (sp.TryWrite(2)) {sp.Write(m_userName);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            if (sp.TryWrite(4)) {sp.Write(m_icon);}
            if (sp.TryWrite(5)) {sp.Write(m_avatar);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar_frame);}
            if (sp.TryWrite(7)) {sp.Write(m_vip_level);}
            if (sp.TryWrite(8)) {sp.Write(m_user_id);}
            if (sp.TryWrite(9)) {sp.Write(m_user_server);}
            sp.EnEnd();
        }
        public void CopyFrom(StepTaskHistoryUserInfo source) {
            m_rank = source.m_rank;
            m_asAbbr = source.m_asAbbr;
            m_userName = source.m_userName;
            m_score = source.m_score;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_avatar_frame = source.m_avatar_frame;
            m_vip_level = source.m_vip_level;
            m_user_id = source.m_user_id;
            m_user_server = source.m_user_server;
        }
    }
    
    [Serializable]
    public partial class OccupyLandNtf : NetworkMessage {
        public static int[] Id = { 905,1 };
        public static Ctrl VC;
        public List<OccupyLandNtfInfo> m_info = new List<OccupyLandNtfInfo>();
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OccupyLandNtfInfo tmp = new OccupyLandNtfInfo();
                    tmp.Decode(sp);
                    m_info.Add(tmp);
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
                sp.Write((UInt16)m_info.Count);
                for (int i = 0; i != m_info.Count; ++i) {
                    m_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(OccupyLandNtf source) {
            m_info = source.m_info;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class MapExploreSecretChoiceReqInfo : NetworkMessage {
        public static int[] Id = { 911,1 };
        public static Ctrl VC;
        public Int32 m_secret_id;
        public SByte m_choice;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_secret_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_choice = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_secret_id);}
            if (sp.TryWrite(1)) {sp.Write(m_choice);}
            sp.EnEnd();
        }
        public void CopyFrom(MapExploreSecretChoiceReqInfo source) {
            m_secret_id = source.m_secret_id;
            m_choice = source.m_choice;
        }
    }
    
    [Serializable]
    public partial class CurrentExpeditionMarch : NetworkMessage {
        public static int[] Id = { 917,1 };
        public static Ctrl VC;
        public List<Int64> m_destroyed = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
                sp.Write((UInt16)m_destroyed.Count);
                for (int i = 0; i != m_destroyed.Count; ++i) {
                    sp.Write(m_destroyed[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CurrentExpeditionMarch source) {
            m_destroyed = source.m_destroyed;
        }
    }
    
    [Serializable]
    public partial class AgentAssignmentInfo : NetworkMessage {
        public static int[] Id = { 923,1 };
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
        public void CopyFrom(AgentAssignmentInfo source) {
            m_agent_id = source.m_agent_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AssignmentCenterExpItemReqInfo : NetworkMessage {
        public static int[] Id = { 929,1 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_item_id;
        public Int32 m_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(AssignmentCenterExpItemReqInfo source) {
            m_agent_id = source.m_agent_id;
            m_item_id = source.m_item_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class AllianceRebelStateInfo : NetworkMessage {
        public static int[] Id = { 935,1 };
        public static Ctrl VC;
        public SByte m_action;
        public Int64 m_dt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_action = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_dt = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_action);}
            if (sp.TryWrite(1)) {sp.Write(m_dt);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceRebelStateInfo source) {
            m_action = source.m_action;
            m_dt = source.m_dt;
        }
    }
    
    [Serializable]
    public partial class RebelBaseDetailInfo : NetworkMessage {
        public static int[] Id = { 941,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int16 m_cfg_id;
        public String m_as_abbr = "";
        public String m_as_name = "";
        public Int64 m_troop_cnt;
        public SByte m_cur_round;
        public SByte m_max_round;
        public List<ItemInfo> m_reward_review = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_stat = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_cfg_id = sp.ReadInt16();}
            if (sp.TryRead(5)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(6)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(7)) {m_troop_cnt = sp.ReadInt64();}
            if (sp.TryRead(8)) {m_cur_round = sp.ReadSByte();}
            if (sp.TryRead(9)) {m_max_round = sp.ReadSByte();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_reward_review.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_reward_review.Add(tmp);
                }
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
            if (sp.TryWrite(5)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(6)) {sp.Write(m_as_name);}
            if (sp.TryWrite(7)) {sp.Write(m_troop_cnt);}
            if (sp.TryWrite(8)) {sp.Write(m_cur_round);}
            if (sp.TryWrite(9)) {sp.Write(m_max_round);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward_review.Count);
                for (int i = 0; i != m_reward_review.Count; ++i) {
                    m_reward_review[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RebelBaseDetailInfo source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
            m_as_abbr = source.m_as_abbr;
            m_as_name = source.m_as_name;
            m_troop_cnt = source.m_troop_cnt;
            m_cur_round = source.m_cur_round;
            m_max_round = source.m_max_round;
            m_reward_review = source.m_reward_review;
        }
    }
    
    [Serializable]
    public partial class RailwayShopItem : NetworkMessage {
        public static int[] Id = { 947,1 };
        public static Ctrl VC;
        public Int32 m_id;
        public SByte m_item_type;
        public Int32 m_item_id;
        public Int16 m_item_num;
        public SByte m_price_type;
        public Int64 m_price;
        public Int16 m_discount;
        public Boolean m_bought;
        public Int16 m_goods_index;
        public Int32 m_price_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_item_type = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_item_num = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_price_type = sp.ReadSByte();}
            if (sp.TryRead(5)) {m_price = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_discount = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_bought = sp.ReadBoolean();}
            if (sp.TryRead(8)) {m_goods_index = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_price_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_type);}
            if (sp.TryWrite(2)) {sp.Write(m_item_id);}
            if (sp.TryWrite(3)) {sp.Write(m_item_num);}
            if (sp.TryWrite(4)) {sp.Write(m_price_type);}
            if (sp.TryWrite(5)) {sp.Write(m_price);}
            if (sp.TryWrite(6)) {sp.Write(m_discount);}
            if (sp.TryWrite(7)) {sp.Write(m_bought);}
            if (sp.TryWrite(8)) {sp.Write(m_goods_index);}
            if (sp.TryWrite(9)) {sp.Write(m_price_id);}
            sp.EnEnd();
        }
        public void CopyFrom(RailwayShopItem source) {
            m_id = source.m_id;
            m_item_type = source.m_item_type;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_price_type = source.m_price_type;
            m_price = source.m_price;
            m_discount = source.m_discount;
            m_bought = source.m_bought;
            m_goods_index = source.m_goods_index;
            m_price_id = source.m_price_id;
        }
    }
    
    [Serializable]
    public partial class B2VipShopInfo : NetworkMessage {
        public static int[] Id = { 953,1 };
        public static Ctrl VC;
        public Int64 m_refresh_time;
        public List<B2VipShopItem> m_items = new List<B2VipShopItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_refresh_time = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    B2VipShopItem tmp = new B2VipShopItem();
                    tmp.Decode(sp);
                    m_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_refresh_time);}
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
        public void CopyFrom(B2VipShopInfo source) {
            m_refresh_time = source.m_refresh_time;
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class GovTitle : NetworkMessage {
        public static int[] Id = { 959,1 };
        public static Ctrl VC;
        public Int32 m_title_id;
        public UserBriefInfo m_player;
        public Int16 m_logo;
        public Int16 m_color;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_title_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                m_player = new UserBriefInfo();
                m_player.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_logo = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_color = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_title_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_player.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_logo);}
            if (sp.TryWrite(3)) {sp.Write(m_color);}
            sp.EnEnd();
        }
        public void CopyFrom(GovTitle source) {
            m_title_id = source.m_title_id;
            m_player = source.m_player;
            m_logo = source.m_logo;
            m_color = source.m_color;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignAdditionReward : NetworkMessage {
        public static int[] Id = { 965,1 };
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
        public void CopyFrom(WheelCampaignAdditionReward source) {
            m_id = source.m_id;
            m_need_score = source.m_need_score;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class GuideRebelTile : NetworkMessage {
        public static int[] Id = { 971,1 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public SByte m_stat;
        public Int16 m_cfg_id;
        public CreepInfo m_creep_data;
        public Int64 m_owner;

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
            if (sp.TryRead(6)) {m_owner = sp.ReadInt64();}
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
            if (sp.TryWrite(6)) {sp.Write(m_owner);}
            sp.EnEnd();
        }
        public void CopyFrom(GuideRebelTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_stat = source.m_stat;
            m_cfg_id = source.m_cfg_id;
            m_creep_data = source.m_creep_data;
            m_owner = source.m_owner;
        }
    }
    
    [Serializable]
    public partial class AppEventStateInfo : NetworkMessage {
        public static int[] Id = { 977,1 };
        public static Ctrl VC;
        public Int16 m_type;
        public String m_js = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_js = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {sp.Write(m_js);}
            sp.EnEnd();
        }
        public void CopyFrom(AppEventStateInfo source) {
            m_type = source.m_type;
            m_js = source.m_js;
        }
    }
    
    [Serializable]
    public partial class UseExchangeCodeAckInfo : NetworkMessage {
        public static int[] Id = { 983,1 };
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
        public void CopyFrom(UseExchangeCodeAckInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class BubbleClickReqInfo : NetworkMessage {
        public static int[] Id = { 989,1 };
        public static Ctrl VC;
        public SByte m_res;
        public Int16 m_troop;
        public Boolean m_repair;
        public Boolean m_research;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_res = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_troop = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_repair = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_research = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_res);}
            if (sp.TryWrite(1)) {sp.Write(m_troop);}
            if (sp.TryWrite(2)) {sp.Write(m_repair);}
            if (sp.TryWrite(3)) {sp.Write(m_research);}
            sp.EnEnd();
        }
        public void CopyFrom(BubbleClickReqInfo source) {
            m_res = source.m_res;
            m_troop = source.m_troop;
            m_repair = source.m_repair;
            m_research = source.m_research;
        }
    }
    
    [Serializable]
    public partial class UserCostCampaignInfo : NetworkMessage {
        public static int[] Id = { 995,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<UserCostCampaignItemRule> m_item_cost_rule = new List<UserCostCampaignItemRule>();
        public List<UserCostCampaignDiamondRule> m_diamond_cost_rule = new List<UserCostCampaignDiamondRule>();
        public List<UserCostCampaignItemExchangeRule> m_item_exchange_rule = new List<UserCostCampaignItemExchangeRule>();
        public List<UserCostCampaignLevelInfo> m_level_info = new List<UserCostCampaignLevelInfo>();
        public Boolean m_alliance_shared;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_cost_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserCostCampaignItemRule tmp = new UserCostCampaignItemRule();
                    tmp.Decode(sp);
                    m_item_cost_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_diamond_cost_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserCostCampaignDiamondRule tmp = new UserCostCampaignDiamondRule();
                    tmp.Decode(sp);
                    m_diamond_cost_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_exchange_rule.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserCostCampaignItemExchangeRule tmp = new UserCostCampaignItemExchangeRule();
                    tmp.Decode(sp);
                    m_item_exchange_rule.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserCostCampaignLevelInfo tmp = new UserCostCampaignLevelInfo();
                    tmp.Decode(sp);
                    m_level_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_alliance_shared = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_cost_rule.Count);
                for (int i = 0; i != m_item_cost_rule.Count; ++i) {
                    m_item_cost_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_diamond_cost_rule.Count);
                for (int i = 0; i != m_diamond_cost_rule.Count; ++i) {
                    m_diamond_cost_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_item_exchange_rule.Count);
                for (int i = 0; i != m_item_exchange_rule.Count; ++i) {
                    m_item_exchange_rule[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_info.Count);
                for (int i = 0; i != m_level_info.Count; ++i) {
                    m_level_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {sp.Write(m_alliance_shared);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCostCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_item_cost_rule = source.m_item_cost_rule;
            m_diamond_cost_rule = source.m_diamond_cost_rule;
            m_item_exchange_rule = source.m_item_exchange_rule;
            m_level_info = source.m_level_info;
            m_alliance_shared = source.m_alliance_shared;
        }
    }
    
    [Serializable]
    public partial class CostActivityCostReqInfo : NetworkMessage {
        public static int[] Id = { 1001,1 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_cost_id;
        public Int32 m_cost_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_cost_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cost_time = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_cost_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cost_time);}
            sp.EnEnd();
        }
        public void CopyFrom(CostActivityCostReqInfo source) {
            m_act_id = source.m_act_id;
            m_cost_id = source.m_cost_id;
            m_cost_time = source.m_cost_time;
        }
    }
    
    [Serializable]
    public partial class BaseTaskGroupCampaignInfo : NetworkMessage {
        public static int[] Id = { 1007,1 };
        public static Ctrl VC;
        public SByte m_group;
        public String m_group_title = "";
        public List<BaseTaskCampaignInfo> m_task_info = new List<BaseTaskCampaignInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_group_title = sp.ReadString();}
            if (sp.TryRead(2)) {
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
            if (sp.TryWrite(0)) {sp.Write(m_group);}
            if (sp.TryWrite(1)) {sp.Write(m_group_title);}
            if (sp.TryWrite(2)) {
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
        public void CopyFrom(BaseTaskGroupCampaignInfo source) {
            m_group = source.m_group;
            m_group_title = source.m_group_title;
            m_task_info = source.m_task_info;
        }
    }
    
    [Serializable]
    public partial class GuideCampaignInfo : NetworkMessage {
        public static int[] Id = { 1013,1 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public List<CampaignJump> m_buttons = new List<CampaignJump>();
        public String m_title = "";
        public String m_sub_title = "";
        public String m_desc = "";
        public String m_banner = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buttons.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CampaignJump tmp = new CampaignJump();
                    tmp.Decode(sp);
                    m_buttons.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_sub_title = sp.ReadString();}
            if (sp.TryRead(4)) {m_desc = sp.ReadString();}
            if (sp.TryRead(5)) {m_banner = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buttons.Count);
                for (int i = 0; i != m_buttons.Count; ++i) {
                    m_buttons[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_title);}
            if (sp.TryWrite(3)) {sp.Write(m_sub_title);}
            if (sp.TryWrite(4)) {sp.Write(m_desc);}
            if (sp.TryWrite(5)) {sp.Write(m_banner);}
            sp.EnEnd();
        }
        public void CopyFrom(GuideCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_buttons = source.m_buttons;
            m_title = source.m_title;
            m_sub_title = source.m_sub_title;
            m_desc = source.m_desc;
            m_banner = source.m_banner;
        }
    }
    
    [Serializable]
    public partial class AllianceShopBuyHistoryEntry : NetworkMessage {
        public static int[] Id = { 1019,1 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public String m_user_name = "";
        public Int16 m_user_icon;
        public String m_user_avatar = "";
        public Int32 m_item_id;
        public Int32 m_item_num;
        public Int64 m_happen_time;
        public Int16 m_user_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_user_icon = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_user_avatar = sp.ReadString();}
            if (sp.TryRead(4)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_item_num = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_happen_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_user_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_name);}
            if (sp.TryWrite(2)) {sp.Write(m_user_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_user_avatar);}
            if (sp.TryWrite(4)) {sp.Write(m_item_id);}
            if (sp.TryWrite(5)) {sp.Write(m_item_num);}
            if (sp.TryWrite(6)) {sp.Write(m_happen_time);}
            if (sp.TryWrite(7)) {sp.Write(m_user_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceShopBuyHistoryEntry source) {
            m_user_id = source.m_user_id;
            m_user_name = source.m_user_name;
            m_user_icon = source.m_user_icon;
            m_user_avatar = source.m_user_avatar;
            m_item_id = source.m_item_id;
            m_item_num = source.m_item_num;
            m_happen_time = source.m_happen_time;
            m_user_avatar_frame = source.m_user_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class CitySkinInfo : NetworkMessage {
        public static int[] Id = { 1025,1 };
        public static Ctrl VC;
        public Int16 m_id;
        public Int64 m_endtime;
        public List<SByte> m_activate_part_ids = new List<SByte>();

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
            sp.EnEnd();
        }
        public void CopyFrom(CitySkinInfo source) {
            m_id = source.m_id;
            m_endtime = source.m_endtime;
            m_activate_part_ids = source.m_activate_part_ids;
        }
    }
    
    [Serializable]
    public partial class QuestCountdownListAck : NetworkMessage {
        public static int[] Id = { 1031,2 };
        public static Ctrl VC;
        public List<QuestCountdownInfo> m_list_info = new List<QuestCountdownInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    QuestCountdownInfo tmp = new QuestCountdownInfo();
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
        public void CopyFrom(QuestCountdownListAck source) {
            m_list_info = source.m_list_info;
        }
    }
    
    [Serializable]
    public partial class GmClientControlNtfInfo : NetworkMessage {
        public static int[] Id = { 1037,2 };
        public static Ctrl VC;
        public String m_control = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_control = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_control);}
            sp.EnEnd();
        }
        public void CopyFrom(GmClientControlNtfInfo source) {
            m_control = source.m_control;
        }
    }
    
    [Serializable]
    public partial class TimelimitTaskEndNtf : NetworkMessage {
        public static int[] Id = { 1043,2 };
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
        public void CopyFrom(TimelimitTaskEndNtf source) {
            m_camp_id = source.m_camp_id;
            m_task_id = source.m_task_id;
            m_points = source.m_points;
        }
    }
    
    [Serializable]
    public partial class LadderDifficultyInfo : NetworkMessage {
        public static int[] Id = { 1049,3 };
        public static Ctrl VC;
        public SByte m_level;
        public String m_name = "";
        public String m_icon = "";
        public String m_desc = "";
        public List<LadderAllianceBossShow> m_boss_desc = new List<LadderAllianceBossShow>();
        public List<ItemInfo> m_pre_reward = new List<ItemInfo>();
        public List<ItemInfo> m_init_reward = new List<ItemInfo>();
        public List<LadderDifficultyUnlockCond> m_cond = new List<LadderDifficultyUnlockCond>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_icon = sp.ReadString();}
            if (sp.TryRead(3)) {m_desc = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_boss_desc.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderAllianceBossShow tmp = new LadderAllianceBossShow();
                    tmp.Decode(sp);
                    m_boss_desc.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pre_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_pre_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_init_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_init_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(7)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cond.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LadderDifficultyUnlockCond tmp = new LadderDifficultyUnlockCond();
                    tmp.Decode(sp);
                    m_cond.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_icon);}
            if (sp.TryWrite(3)) {sp.Write(m_desc);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_boss_desc.Count);
                for (int i = 0; i != m_boss_desc.Count; ++i) {
                    m_boss_desc[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pre_reward.Count);
                for (int i = 0; i != m_pre_reward.Count; ++i) {
                    m_pre_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_init_reward.Count);
                for (int i = 0; i != m_init_reward.Count; ++i) {
                    m_init_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(7)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cond.Count);
                for (int i = 0; i != m_cond.Count; ++i) {
                    m_cond[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderDifficultyInfo source) {
            m_level = source.m_level;
            m_name = source.m_name;
            m_icon = source.m_icon;
            m_desc = source.m_desc;
            m_boss_desc = source.m_boss_desc;
            m_pre_reward = source.m_pre_reward;
            m_init_reward = source.m_init_reward;
            m_cond = source.m_cond;
        }
    }
    
    [Serializable]
    public partial class LadderUserInitAckInfo : NetworkMessage {
        public static int[] Id = { 1055,3 };
        public static Ctrl VC;
        public LadderStatusInfo m_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_info = new LadderStatusInfo();
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
        public void CopyFrom(LadderUserInitAckInfo source) {
            m_info = source.m_info;
        }
    }
    
    [Serializable]
    public partial class LadderCampaignStepReward : NetworkMessage {
        public static int[] Id = { 1061,3 };
        public static Ctrl VC;
        public Int16 m_step;
        public List<ItemInfo> m_fix_reward = new List<ItemInfo>();
        public Int32 m_gacha_id;
        public String m_extra_reward_pic = "";
        public List<ItemInfo> m_extra_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_fix_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_fix_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_gacha_id = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_extra_reward_pic = sp.ReadString();}
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_extra_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_extra_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_fix_reward.Count);
                for (int i = 0; i != m_fix_reward.Count; ++i) {
                    m_fix_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_gacha_id);}
            if (sp.TryWrite(3)) {sp.Write(m_extra_reward_pic);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_extra_reward.Count);
                for (int i = 0; i != m_extra_reward.Count; ++i) {
                    m_extra_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LadderCampaignStepReward source) {
            m_step = source.m_step;
            m_fix_reward = source.m_fix_reward;
            m_gacha_id = source.m_gacha_id;
            m_extra_reward_pic = source.m_extra_reward_pic;
            m_extra_reward = source.m_extra_reward;
        }
    }
    
    [Serializable]
    public partial class LoginCmdReq : NetworkMessage {
        public static int[] Id = { 1067,3 };
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
        public void CopyFrom(LoginCmdReq source) {
            m_cmd = source.m_cmd;
        }
    }
    
    [Serializable]
    public partial class TimelimitQuestList : NetworkMessage {
        public static int[] Id = { 1073,4 };
        public static Ctrl VC;
        public List<TimelimitQuestInfo> m_list = new List<TimelimitQuestInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TimelimitQuestInfo tmp = new TimelimitQuestInfo();
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
        public void CopyFrom(TimelimitQuestList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ArenaPlayerInfo : NetworkMessage {
        public static int[] Id = { 1079,4 };
        public static Ctrl VC;
        public Int64 m_user_id;
        public Int32 m_bot_id;
        public String m_user_name = "";
        public Int64 m_power;
        public Int64 m_score;
        public Int32 m_rank;
        public Int16 m_icon;
        public String m_avatar = "";
        public String m_as_name = "";
        public String m_as_abbr = "";
        public Int16 m_as_logo;
        public Int16 m_as_color;
        public List<ArenaTroopInfo> m_defend_array = new List<ArenaTroopInfo>();
        public Int16 m_server_id;
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_bot_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_user_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(7)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(8)) {m_as_name = sp.ReadString();}
            if (sp.TryRead(9)) {m_as_abbr = sp.ReadString();}
            if (sp.TryRead(10)) {m_as_logo = sp.ReadInt16();}
            if (sp.TryRead(11)) {m_as_color = sp.ReadInt16();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defend_array.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopInfo tmp = new ArenaTroopInfo();
                    tmp.Decode(sp);
                    m_defend_array.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(14)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_id);}
            if (sp.TryWrite(1)) {sp.Write(m_bot_id);}
            if (sp.TryWrite(2)) {sp.Write(m_user_name);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {sp.Write(m_rank);}
            if (sp.TryWrite(6)) {sp.Write(m_icon);}
            if (sp.TryWrite(7)) {sp.Write(m_avatar);}
            if (sp.TryWrite(8)) {sp.Write(m_as_name);}
            if (sp.TryWrite(9)) {sp.Write(m_as_abbr);}
            if (sp.TryWrite(10)) {sp.Write(m_as_logo);}
            if (sp.TryWrite(11)) {sp.Write(m_as_color);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defend_array.Count);
                for (int i = 0; i != m_defend_array.Count; ++i) {
                    m_defend_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {sp.Write(m_server_id);}
            if (sp.TryWrite(14)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(ArenaPlayerInfo source) {
            m_user_id = source.m_user_id;
            m_bot_id = source.m_bot_id;
            m_user_name = source.m_user_name;
            m_power = source.m_power;
            m_score = source.m_score;
            m_rank = source.m_rank;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_as_name = source.m_as_name;
            m_as_abbr = source.m_as_abbr;
            m_as_logo = source.m_as_logo;
            m_as_color = source.m_as_color;
            m_defend_array = source.m_defend_array;
            m_server_id = source.m_server_id;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class ArenaSetDefendReqInfo : NetworkMessage {
        public static int[] Id = { 1085,4 };
        public static Ctrl VC;
        public List<ArenaTroopInfo> m_defend_array = new List<ArenaTroopInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_defend_array.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaTroopInfo tmp = new ArenaTroopInfo();
                    tmp.Decode(sp);
                    m_defend_array.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_defend_array.Count);
                for (int i = 0; i != m_defend_array.Count; ++i) {
                    m_defend_array[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(ArenaSetDefendReqInfo source) {
            m_defend_array = source.m_defend_array;
        }
    }
    
    [Serializable]
    public partial class ArenaRanklistAckInfo : NetworkMessage {
        public static int[] Id = { 1091,4 };
        public static Ctrl VC;
        public Int32 m_user_rank;
        public List<ArenaPlayerInfo> m_ranklist = new List<ArenaPlayerInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_user_rank = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_ranklist.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArenaPlayerInfo tmp = new ArenaPlayerInfo();
                    tmp.Decode(sp);
                    m_ranklist.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_user_rank);}
            if (sp.TryWrite(1)) {
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
        public void CopyFrom(ArenaRanklistAckInfo source) {
            m_user_rank = source.m_user_rank;
            m_ranklist = source.m_ranklist;
        }
    }
    
    [Serializable]
    public partial class BattlePassportTaskId : NetworkMessage {
        public static int[] Id = { 1097,4 };
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
        public void CopyFrom(BattlePassportTaskId source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeCampaign : NetworkMessage {
        public static int[] Id = { 1103,5 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Boolean m_can_join;
        public AllianceMobilizeUserTaskStatus m_status;
        public AllianceMobilizeProgressInfo m_progress;
        public List<AllianceMobilizeLevelReward> m_level_reward = new List<AllianceMobilizeLevelReward>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_can_join = sp.ReadBoolean();}
            if (sp.TryRead(2)) {
                m_status = new AllianceMobilizeUserTaskStatus();
                m_status.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(3)) {
                m_progress = new AllianceMobilizeProgressInfo();
                m_progress.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_level_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceMobilizeLevelReward tmp = new AllianceMobilizeLevelReward();
                    tmp.Decode(sp);
                    m_level_reward.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_can_join);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_status.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_progress.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_level_reward.Count);
                for (int i = 0; i != m_level_reward.Count; ++i) {
                    m_level_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeCampaign source) {
            m_basic_info = source.m_basic_info;
            m_can_join = source.m_can_join;
            m_status = source.m_status;
            m_progress = source.m_progress;
            m_level_reward = source.m_level_reward;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeLevelReward : NetworkMessage {
        public static int[] Id = { 1109,5 };
        public static Ctrl VC;
        public Int16 m_level;
        public Int32 m_need_point;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Boolean m_is_got;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_need_point = sp.ReadInt32();}
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
            if (sp.TryRead(3)) {m_is_got = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_level);}
            if (sp.TryWrite(1)) {sp.Write(m_need_point);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_is_got);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceMobilizeLevelReward source) {
            m_level = source.m_level;
            m_need_point = source.m_need_point;
            m_reward = source.m_reward;
            m_is_got = source.m_is_got;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeTaskFinishReqInfo : NetworkMessage {
        public static int[] Id = { 1115,5 };
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
        public void CopyFrom(AllianceMobilizeTaskFinishReqInfo source) {
            m_act_id = source.m_act_id;
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class AllianceMobilizeRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1121,5 };
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
        public void CopyFrom(AllianceMobilizeRewardReqInfo source) {
            m_act_id = source.m_act_id;
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class MayorInfo : NetworkMessage {
        public static int[] Id = { 1127,7 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int64 m_monument_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_monument_id = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_monument_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MayorInfo source) {
            m_server_id = source.m_server_id;
            m_monument_id = source.m_monument_id;
        }
    }
    
    [Serializable]
    public partial class OfflineOccupyMonumentBannerNtfInfo : NetworkMessage {
        public static int[] Id = { 1134,7 };
        public static Ctrl VC;
        public List<OccupyMonumentBannerNtfInfo> m_banners = new List<OccupyMonumentBannerNtfInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_banners.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OccupyMonumentBannerNtfInfo tmp = new OccupyMonumentBannerNtfInfo();
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
        public void CopyFrom(OfflineOccupyMonumentBannerNtfInfo source) {
            m_banners = source.m_banners;
        }
    }
    
    [Serializable]
    public partial class B2TransferServerSetMaxPowerReq : NetworkMessage {
        public static int[] Id = { 1140,8 };
        public static Ctrl VC;
        public Int64 m_transfer_server_max_power_limit;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_transfer_server_max_power_limit = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_transfer_server_max_power_limit);}
            sp.EnEnd();
        }
        public void CopyFrom(B2TransferServerSetMaxPowerReq source) {
            m_transfer_server_max_power_limit = source.m_transfer_server_max_power_limit;
        }
    }
    
    [Serializable]
    public partial class PlatFollowRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1146,8 };
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
        public void CopyFrom(PlatFollowRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class LoudSpeakerRewardNtfInfo : NetworkMessage {
        public static int[] Id = { 1152,11 };
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
        public void CopyFrom(LoudSpeakerRewardNtfInfo source) {
            m_reward_cnt = source.m_reward_cnt;
            m_total_reward_cnt = source.m_total_reward_cnt;
        }
    }
    
    [Serializable]
    public partial class GvgQuitNtf : NetworkMessage {
        public static int[] Id = { 1158,12 };
        public static Ctrl VC;
        public Int64 m_battlefield_id;
        public Int64 m_user_id;
        public Int16 m_code;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_battlefield_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_code = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_battlefield_id);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_code);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgQuitNtf source) {
            m_battlefield_id = source.m_battlefield_id;
            m_user_id = source.m_user_id;
            m_code = source.m_code;
        }
    }
    
    [Serializable]
    public partial class GvgApplyMemberInfo : NetworkMessage {
        public static int[] Id = { 1164,12 };
        public static Ctrl VC;
        public SByte m_status;
        public Int64 m_user_id;
        public String m_name = "";
        public Int16 m_rank;
        public Int64 m_power;
        public Int16 m_icon;
        public String m_avatar = "";
        public Int64 m_score;
        public List<GvgApplyMemberAgentInfo> m_agents = new List<GvgApplyMemberAgentInfo>();
        public Int16 m_avatar_frame;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_user_id = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_name = sp.ReadString();}
            if (sp.TryRead(3)) {m_rank = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_icon = sp.ReadInt16();}
            if (sp.TryRead(6)) {m_avatar = sp.ReadString();}
            if (sp.TryRead(7)) {m_score = sp.ReadInt64();}
            if (sp.TryRead(8)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agents.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    GvgApplyMemberAgentInfo tmp = new GvgApplyMemberAgentInfo();
                    tmp.Decode(sp);
                    m_agents.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {m_avatar_frame = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_status);}
            if (sp.TryWrite(1)) {sp.Write(m_user_id);}
            if (sp.TryWrite(2)) {sp.Write(m_name);}
            if (sp.TryWrite(3)) {sp.Write(m_rank);}
            if (sp.TryWrite(4)) {sp.Write(m_power);}
            if (sp.TryWrite(5)) {sp.Write(m_icon);}
            if (sp.TryWrite(6)) {sp.Write(m_avatar);}
            if (sp.TryWrite(7)) {sp.Write(m_score);}
            if (sp.TryWrite(8)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_agents.Count);
                for (int i = 0; i != m_agents.Count; ++i) {
                    m_agents[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(9)) {sp.Write(m_avatar_frame);}
            sp.EnEnd();
        }
        public void CopyFrom(GvgApplyMemberInfo source) {
            m_status = source.m_status;
            m_user_id = source.m_user_id;
            m_name = source.m_name;
            m_rank = source.m_rank;
            m_power = source.m_power;
            m_icon = source.m_icon;
            m_avatar = source.m_avatar;
            m_score = source.m_score;
            m_agents = source.m_agents;
            m_avatar_frame = source.m_avatar_frame;
        }
    }
    
    [Serializable]
    public partial class MuseumTile : NetworkMessage {
        public static int[] Id = { 1170,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int16 m_radius;
        public Int64 m_next_spawn;
        public Boolean m_item_in_home;
        public Int16 m_goods_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_radius = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_next_spawn = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_item_in_home = sp.ReadBoolean();}
            if (sp.TryRead(6)) {m_goods_id = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_radius);}
            if (sp.TryWrite(4)) {sp.Write(m_next_spawn);}
            if (sp.TryWrite(5)) {sp.Write(m_item_in_home);}
            if (sp.TryWrite(6)) {sp.Write(m_goods_id);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_radius = source.m_radius;
            m_next_spawn = source.m_next_spawn;
            m_item_in_home = source.m_item_in_home;
            m_goods_id = source.m_goods_id;
        }
    }
    
    [Serializable]
    public partial class DepotTile : NetworkMessage {
        public static int[] Id = { 1176,12 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int16 m_x;
        public Int16 m_y;
        public Int64 m_player_score;
        public Int64 m_alliance_score;
        public SByte m_status;
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
        public Int16 m_level;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_x = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_y = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_player_score = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_alliance_score = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_status = sp.ReadSByte();}
            if (sp.TryRead(6)) {m_owner = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_name = sp.ReadString();}
            if (sp.TryRead(8)) {
                m_alliance = new UserAllianceBrief();
                m_alliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(9)) {
                m_captives = new FieldCaptivesInfo();
                m_captives.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(10)) {m_gather_speed = sp.ReadInt64();}
            if (sp.TryRead(11)) {m_gather_time = sp.ReadInt64();}
            if (sp.TryRead(12)) {m_capacity = sp.ReadInt64();}
            if (sp.TryRead(13)) {m_fighting = sp.ReadInt64();}
            if (sp.TryRead(14)) {
                m_landalliance = new AllianceSnapInfo();
                m_landalliance.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(15)) {m_land_home_server_id = sp.ReadInt16();}
            if (sp.TryRead(16)) {
                m_item_tile = new ItemTileInfo();
                m_item_tile.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(17)) {m_group_id = sp.ReadInt64();}
            if (sp.TryRead(18)) {
                m_lander = new LanderTile();
                m_lander.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(19)) {m_gather_cnt = sp.ReadInt64();}
            if (sp.TryRead(20)) {m_level = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_x);}
            if (sp.TryWrite(2)) {sp.Write(m_y);}
            if (sp.TryWrite(3)) {sp.Write(m_player_score);}
            if (sp.TryWrite(4)) {sp.Write(m_alliance_score);}
            if (sp.TryWrite(5)) {sp.Write(m_status);}
            if (sp.TryWrite(6)) {sp.Write(m_owner);}
            if (sp.TryWrite(7)) {sp.Write(m_name);}
            if (sp.TryWrite(8)) {int pos = sp.GetPos();sp.Skip(2); m_alliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(9)) {int pos = sp.GetPos();sp.Skip(2); m_captives.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(10)) {sp.Write(m_gather_speed);}
            if (sp.TryWrite(11)) {sp.Write(m_gather_time);}
            if (sp.TryWrite(12)) {sp.Write(m_capacity);}
            if (sp.TryWrite(13)) {sp.Write(m_fighting);}
            if (sp.TryWrite(14)) {int pos = sp.GetPos();sp.Skip(2); m_landalliance.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(15)) {sp.Write(m_land_home_server_id);}
            if (sp.TryWrite(16)) {int pos = sp.GetPos();sp.Skip(2); m_item_tile.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(17)) {sp.Write(m_group_id);}
            if (sp.TryWrite(18)) {int pos = sp.GetPos();sp.Skip(2); m_lander.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(19)) {sp.Write(m_gather_cnt);}
            if (sp.TryWrite(20)) {sp.Write(m_level);}
            sp.EnEnd();
        }
        public void CopyFrom(DepotTile source) {
            m_id = source.m_id;
            m_x = source.m_x;
            m_y = source.m_y;
            m_player_score = source.m_player_score;
            m_alliance_score = source.m_alliance_score;
            m_status = source.m_status;
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
            m_level = source.m_level;
        }
    }
    
    [Serializable]
    public partial class GvgBattlefieldListAckInfo : NetworkMessage {
        public static int[] Id = { 1182,12 };
        public static Ctrl VC;
        public Int32 m_index;
        public Int32 m_total;
        public List<Int64> m_battlefield_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_index = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_total = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_battlefield_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int64 tmp = sp.ReadInt64();
                    m_battlefield_list.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_index);}
            if (sp.TryWrite(1)) {sp.Write(m_total);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_battlefield_list.Count);
                for (int i = 0; i != m_battlefield_list.Count; ++i) {
                    sp.Write(m_battlefield_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GvgBattlefieldListAckInfo source) {
            m_index = source.m_index;
            m_total = source.m_total;
            m_battlefield_list = source.m_battlefield_list;
        }
    }
    
    [Serializable]
    public partial class SetVipSwitchInfo : NetworkMessage {
        public static int[] Id = { 1188,12 };
        public static Ctrl VC;
        public Boolean m_switch;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_switch = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_switch);}
            sp.EnEnd();
        }
        public void CopyFrom(SetVipSwitchInfo source) {
            m_switch = source.m_switch;
        }
    }
    
    [Serializable]
    public partial class NightFixedViewInfo : NetworkMessage {
        public static int[] Id = { 1212,13 };
        public static Ctrl VC;
        public RealPos m_pos;
        public SByte m_range;
        public SByte m_shape;
        public SByte m_view_type;
        public Int64 m_end_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_pos = new RealPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_range = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_shape = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_view_type = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_end_time = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_range);}
            if (sp.TryWrite(2)) {sp.Write(m_shape);}
            if (sp.TryWrite(3)) {sp.Write(m_view_type);}
            if (sp.TryWrite(4)) {sp.Write(m_end_time);}
            sp.EnEnd();
        }
        public void CopyFrom(NightFixedViewInfo source) {
            m_pos = source.m_pos;
            m_range = source.m_range;
            m_shape = source.m_shape;
            m_view_type = source.m_view_type;
            m_end_time = source.m_end_time;
        }
    }
    
    [Serializable]
    public partial class RouletteRollAckInfo : NetworkMessage {
        public static int[] Id = { 1218,14 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public Int32 m_circle_id;
        public SByte m_cell_id;
        public ItemInfo m_reward;
        public List<RouletteCirclePtStatus> m_pt_status = new List<RouletteCirclePtStatus>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_circle_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cell_id = sp.ReadSByte();}
            if (sp.TryRead(3)) {
                m_reward = new ItemInfo();
                m_reward.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pt_status.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RouletteCirclePtStatus tmp = new RouletteCirclePtStatus();
                    tmp.Decode(sp);
                    m_pt_status.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_circle_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cell_id);}
            if (sp.TryWrite(3)) {int pos = sp.GetPos();sp.Skip(2); m_reward.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(4)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pt_status.Count);
                for (int i = 0; i != m_pt_status.Count; ++i) {
                    m_pt_status[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RouletteRollAckInfo source) {
            m_act_id = source.m_act_id;
            m_circle_id = source.m_circle_id;
            m_cell_id = source.m_cell_id;
            m_reward = source.m_reward;
            m_pt_status = source.m_pt_status;
        }
    }
    
    [Serializable]
    public partial class UserCityNameplateInfo : NetworkMessage {
        public static int[] Id = { 1224,18 };
        public static Ctrl VC;
        public List<Int16> m_nameplates = new List<Int16>();
        public Int16 m_current_nameplate;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_nameplates.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_nameplates.Add(tmp);
                }
            }
            if (sp.TryRead(1)) {m_current_nameplate = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_nameplates.Count);
                for (int i = 0; i != m_nameplates.Count; ++i) {
                    sp.Write(m_nameplates[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(1)) {sp.Write(m_current_nameplate);}
            sp.EnEnd();
        }
        public void CopyFrom(UserCityNameplateInfo source) {
            m_nameplates = source.m_nameplates;
            m_current_nameplate = source.m_current_nameplate;
        }
    }
    
    [Serializable]
    public partial class DiamondBuyChatBubbleInfo : NetworkMessage {
        public static int[] Id = { 1230,18 };
        public static Ctrl VC;
        public Int32 m_chat_bubble_item_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_chat_bubble_item_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_chat_bubble_item_id);}
            sp.EnEnd();
        }
        public void CopyFrom(DiamondBuyChatBubbleInfo source) {
            m_chat_bubble_item_id = source.m_chat_bubble_item_id;
        }
    }
    
    [Serializable]
    public partial class UserSendEmoticonInfo : NetworkMessage {
        public static int[] Id = { 1236,18 };
        public static Ctrl VC;
        public Int16 m_emoticon_id;
        public Int16 m_sender_type;
        public Int64 m_sender_id;
        public Int64 m_sender_user_id;
        public Int64 m_map_guid;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_emoticon_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_sender_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_sender_id = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_sender_user_id = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_map_guid = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_emoticon_id);}
            if (sp.TryWrite(1)) {sp.Write(m_sender_type);}
            if (sp.TryWrite(2)) {sp.Write(m_sender_id);}
            if (sp.TryWrite(3)) {sp.Write(m_sender_user_id);}
            if (sp.TryWrite(4)) {sp.Write(m_map_guid);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSendEmoticonInfo source) {
            m_emoticon_id = source.m_emoticon_id;
            m_sender_type = source.m_sender_type;
            m_sender_id = source.m_sender_id;
            m_sender_user_id = source.m_sender_user_id;
            m_map_guid = source.m_map_guid;
        }
    }
    
    [Serializable]
    public partial class ArenaShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 1242,19 };
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
        public void CopyFrom(ArenaShopBuyReqInfo source) {
            m_id = source.m_id;
            m_cnt = source.m_cnt;
        }
    }
    
    [Serializable]
    public partial class MailConfirmCreateInfo : NetworkMessage {
        public static int[] Id = { 1248,19 };
        public static Ctrl VC;
        public Boolean m_is_confirm;
        public Int64 m_during_sec;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_confirm = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_during_sec = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_confirm);}
            if (sp.TryWrite(1)) {sp.Write(m_during_sec);}
            sp.EnEnd();
        }
        public void CopyFrom(MailConfirmCreateInfo source) {
            m_is_confirm = source.m_is_confirm;
            m_during_sec = source.m_during_sec;
        }
    }
    
    [Serializable]
    public partial class MailConfirmChoiceStatusAckInfo : NetworkMessage {
        public static int[] Id = { 1254,19 };
        public static Ctrl VC;
        public List<MailConfirmChoiceStatus> m_list = new List<MailConfirmChoiceStatus>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    MailConfirmChoiceStatus tmp = new MailConfirmChoiceStatus();
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
        public void CopyFrom(MailConfirmChoiceStatusAckInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ChangeAllianceDescInfo : NetworkMessage {
        public static int[] Id = { 1260,19 };
        public static Ctrl VC;
        public String m_desc = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_desc = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_desc);}
            sp.EnEnd();
        }
        public void CopyFrom(ChangeAllianceDescInfo source) {
            m_desc = source.m_desc;
        }
    }
    
    [Serializable]
    public partial class BossCampaignArmySlotAckInfo : NetworkMessage {
        public static int[] Id = { 1266,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<BossCampaignSlotInfo> m_slots = new List<BossCampaignSlotInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_slots.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BossCampaignSlotInfo tmp = new BossCampaignSlotInfo();
                    tmp.Decode(sp);
                    m_slots.Add(tmp);
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
                sp.Write((UInt16)m_slots.Count);
                for (int i = 0; i != m_slots.Count; ++i) {
                    m_slots[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignArmySlotAckInfo source) {
            m_act_id = source.m_act_id;
            m_slots = source.m_slots;
        }
    }
    
    [Serializable]
    public partial class BossCampaignResetReqInfo : NetworkMessage {
        public static int[] Id = { 1272,19 };
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
        public void CopyFrom(BossCampaignResetReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class RankCampaignSelfInfo : NetworkMessage {
        public static int[] Id = { 1278,19 };
        public static Ctrl VC;
        public Int32 m_sub_rank_id;
        public Int16 m_rank_type;
        public Int32 m_rank;
        public Int64 m_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sub_rank_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_rank_type = sp.ReadInt16();}
            if (sp.TryRead(2)) {m_rank = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_score = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sub_rank_id);}
            if (sp.TryWrite(1)) {sp.Write(m_rank_type);}
            if (sp.TryWrite(2)) {sp.Write(m_rank);}
            if (sp.TryWrite(3)) {sp.Write(m_score);}
            sp.EnEnd();
        }
        public void CopyFrom(RankCampaignSelfInfo source) {
            m_sub_rank_id = source.m_sub_rank_id;
            m_rank_type = source.m_rank_type;
            m_rank = source.m_rank;
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class BossCampaignRealPosAckInfo : NetworkMessage {
        public static int[] Id = { 1284,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public RealPos m_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                m_pos = new RealPos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(BossCampaignRealPosAckInfo source) {
            m_act_id = source.m_act_id;
            m_pos = source.m_pos;
        }
    }
    
    [Serializable]
    public partial class KvkQuestListAckInfo : NetworkMessage {
        public static int[] Id = { 1290,19 };
        public static Ctrl VC;
        public List<KvkFinishedQuestInfo> m_finished_quest_list = new List<KvkFinishedQuestInfo>();
        public List<KvkQuestInfo> m_running_quest_list = new List<KvkQuestInfo>();
        public Int32 m_period;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_finished_quest_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkFinishedQuestInfo tmp = new KvkFinishedQuestInfo();
                    tmp.Decode(sp);
                    m_finished_quest_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_running_quest_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    KvkQuestInfo tmp = new KvkQuestInfo();
                    tmp.Decode(sp);
                    m_running_quest_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_period = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_finished_quest_list.Count);
                for (int i = 0; i != m_finished_quest_list.Count; ++i) {
                    m_finished_quest_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_running_quest_list.Count);
                for (int i = 0; i != m_running_quest_list.Count; ++i) {
                    m_running_quest_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_period);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkQuestListAckInfo source) {
            m_finished_quest_list = source.m_finished_quest_list;
            m_running_quest_list = source.m_running_quest_list;
            m_period = source.m_period;
        }
    }
    
    [Serializable]
    public partial class KvkLandColorInfo : NetworkMessage {
        public static int[] Id = { 1296,19 };
        public static Ctrl VC;
        public Int16 m_server_id;
        public Int32 m_color;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_server_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_color = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_server_id);}
            if (sp.TryWrite(1)) {sp.Write(m_color);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkLandColorInfo source) {
            m_server_id = source.m_server_id;
            m_color = source.m_color;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortResDonateInfo : NetworkMessage {
        public static int[] Id = { 1302,19 };
        public static Ctrl VC;
        public SByte m_donate_id;
        public ResTypeInfo m_source;
        public List<ItemInfo> m_reward = new List<ItemInfo>();
        public Int32 m_kvk_honour;
        public Int32 m_pt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_donate_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_source = new ResTypeInfo();
                m_source.Decode(sp);
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
            if (sp.TryRead(3)) {m_kvk_honour = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_pt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_donate_id);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_source.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_reward.Count);
                for (int i = 0; i != m_reward.Count; ++i) {
                    m_reward[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(3)) {sp.Write(m_kvk_honour);}
            if (sp.TryWrite(4)) {sp.Write(m_pt);}
            sp.EnEnd();
        }
        public void CopyFrom(CampaignKvkFortResDonateInfo source) {
            m_donate_id = source.m_donate_id;
            m_source = source.m_source;
            m_reward = source.m_reward;
            m_kvk_honour = source.m_kvk_honour;
            m_pt = source.m_pt;
        }
    }
    
    [Serializable]
    public partial class CampaignKvkFortKillRewardAckInfo : NetworkMessage {
        public static int[] Id = { 1308,19 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public SByte m_method;
        public Int32 m_donate_pt;
        public Int64 m_gs_pt;
        public List<ItemInfo> m_reward = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_method = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_donate_pt = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_gs_pt = sp.ReadInt64();}
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
            if (sp.TryWrite(0)) {sp.Write(m_act_id);}
            if (sp.TryWrite(1)) {sp.Write(m_method);}
            if (sp.TryWrite(2)) {sp.Write(m_donate_pt);}
            if (sp.TryWrite(3)) {sp.Write(m_gs_pt);}
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
        public void CopyFrom(CampaignKvkFortKillRewardAckInfo source) {
            m_act_id = source.m_act_id;
            m_method = source.m_method;
            m_donate_pt = source.m_donate_pt;
            m_gs_pt = source.m_gs_pt;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class ScoutCooldownNtfInfo : NetworkMessage {
        public static int[] Id = { 1314,19 };
        public static Ctrl VC;
        public Int64 m_cdtime;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_cdtime = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_cdtime);}
            sp.EnEnd();
        }
        public void CopyFrom(ScoutCooldownNtfInfo source) {
            m_cdtime = source.m_cdtime;
        }
    }
    
    [Serializable]
    public partial class ClaimMergeLoginRewardsAckInfo : NetworkMessage {
        public static int[] Id = { 1320,21 };
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
        public void CopyFrom(ClaimMergeLoginRewardsAckInfo source) {
            m_items = source.m_items;
        }
    }
    
    [Serializable]
    public partial class SlotMachineRollAckInfo : NetworkMessage {
        public static int[] Id = { 1340,22 };
        public static Ctrl VC;
        public Int64 m_act_id;
        public List<SlotMachineRollResult> m_result = new List<SlotMachineRollResult>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_act_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_result.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    SlotMachineRollResult tmp = new SlotMachineRollResult();
                    tmp.Decode(sp);
                    m_result.Add(tmp);
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
                sp.Write((UInt16)m_result.Count);
                for (int i = 0; i != m_result.Count; ++i) {
                    m_result[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(SlotMachineRollAckInfo source) {
            m_act_id = source.m_act_id;
            m_result = source.m_result;
        }
    }
    
    [Serializable]
    public partial class RoundFighterBriefInfo : NetworkMessage {
        public static int[] Id = { 1346,23 };
        public static Ctrl VC;
        public MapUnitId m_id;
        public Int32 m_warship_energy;
        public Int32 m_warship_energy_max;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_id = new MapUnitId();
                m_id.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_warship_energy = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_warship_energy_max = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_id.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_warship_energy);}
            if (sp.TryWrite(2)) {sp.Write(m_warship_energy_max);}
            sp.EnEnd();
        }
        public void CopyFrom(RoundFighterBriefInfo source) {
            m_id = source.m_id;
            m_warship_energy = source.m_warship_energy;
            m_warship_energy_max = source.m_warship_energy_max;
        }
    }
    
    [Serializable]
    public partial class PlayerInfoForbidNtfInfo : NetworkMessage {
        public static int[] Id = { 1352,23 };
        public static Ctrl VC;
        public Int64 m_forbid_flag;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_forbid_flag = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_forbid_flag);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerInfoForbidNtfInfo source) {
            m_forbid_flag = source.m_forbid_flag;
        }
    }
    
    [Serializable]
    public partial class SyncPlayerBlackListReqInfo : NetworkMessage {
        public static int[] Id = { 1358,23 };
        public static Ctrl VC;
        public List<PlayerBlackListItem> m_black_list = new List<PlayerBlackListItem>();

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
            sp.EnEnd();
        }
        public void CopyFrom(SyncPlayerBlackListReqInfo source) {
            m_black_list = source.m_black_list;
        }
    }
    
    [Serializable]
    public partial class UserWarshipInfo : NetworkMessage {
        public static int[] Id = { 1364,23 };
        public static Ctrl VC;
        public Int16 m_warship_id;
        public Int16 m_cur_skill_level;
        public List<Int32> m_cur_research = new List<Int32>();
        public List<UserWarshipResearchStatusInfo> m_research_queue = new List<UserWarshipResearchStatusInfo>();
        public Int64 m_owner_group;
        public List<WarshipWeaponInfo> m_weapons = new List<WarshipWeaponInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_warship_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_cur_skill_level = sp.ReadInt16();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_cur_research.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_cur_research.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_research_queue.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserWarshipResearchStatusInfo tmp = new UserWarshipResearchStatusInfo();
                    tmp.Decode(sp);
                    m_research_queue.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(4)) {m_owner_group = sp.ReadInt64();}
            if (sp.TryRead(5)) {
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
            if (sp.TryWrite(1)) {sp.Write(m_cur_skill_level);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_cur_research.Count);
                for (int i = 0; i != m_cur_research.Count; ++i) {
                    sp.Write(m_cur_research[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_research_queue.Count);
                for (int i = 0; i != m_research_queue.Count; ++i) {
                    m_research_queue[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(4)) {sp.Write(m_owner_group);}
            if (sp.TryWrite(5)) {
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
        public void CopyFrom(UserWarshipInfo source) {
            m_warship_id = source.m_warship_id;
            m_cur_skill_level = source.m_cur_skill_level;
            m_cur_research = source.m_cur_research;
            m_research_queue = source.m_research_queue;
            m_owner_group = source.m_owner_group;
            m_weapons = source.m_weapons;
        }
    }
    
    [Serializable]
    public partial class UserWarshipResearchBubbles : NetworkMessage {
        public static int[] Id = { 1370,23 };
        public static Ctrl VC;
        public List<UserWarshipResearchBubbleInfo> m_warships = new List<UserWarshipResearchBubbleInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_warships.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    UserWarshipResearchBubbleInfo tmp = new UserWarshipResearchBubbleInfo();
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
        public void CopyFrom(UserWarshipResearchBubbles source) {
            m_warships = source.m_warships;
        }
    }
    
    [Serializable]
    public partial class KvkPreCreepExchangeReqInfo : NetworkMessage {
        public static int[] Id = { 1376,23 };
        public static Ctrl VC;
        public SByte m_step;
        public Int32 m_exchange_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_exchange_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step);}
            if (sp.TryWrite(1)) {sp.Write(m_exchange_id);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreCreepExchangeReqInfo source) {
            m_step = source.m_step;
            m_exchange_id = source.m_exchange_id;
        }
    }
    
    [Serializable]
    public partial class SpecialItemPrice : NetworkMessage {
        public static int[] Id = { 1382,23 };
        public static Ctrl VC;
        public Int32 m_item_id;
        public Int32 m_buy_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_buy_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_item_id);}
            if (sp.TryWrite(1)) {sp.Write(m_buy_count);}
            sp.EnEnd();
        }
        public void CopyFrom(SpecialItemPrice source) {
            m_item_id = source.m_item_id;
            m_buy_count = source.m_buy_count;
        }
    }
    
    [Serializable]
    public partial class TimeLimitedCitySkinList : NetworkMessage {
        public static int[] Id = { 1388,23 };
        public static Ctrl VC;
        public List<TimeLimitedCitySkin> m_list = new List<TimeLimitedCitySkin>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    TimeLimitedCitySkin tmp = new TimeLimitedCitySkin();
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
        public void CopyFrom(TimeLimitedCitySkinList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class AllianceBoardUserStatusInfo : NetworkMessage {
        public static int[] Id = { 1394,23 };
        public static Ctrl VC;
        public Int16 m_available_task_num;
        public Int64 m_add_task_num_cost;
        public Int16 m_add_task_num;
        public Int16 m_finish_task_num;
        public Int32 m_finish_task_score;
        public List<Int16> m_got_basic_reward = new List<Int16>();
        public List<Int16> m_got_ex_reward = new List<Int16>();
        public AllianceBoardTaskStatusInfo m_cur_task;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_available_task_num = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_add_task_num_cost = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_add_task_num = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_finish_task_num = sp.ReadInt16();}
            if (sp.TryRead(4)) {m_finish_task_score = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_got_basic_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_got_basic_reward.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_got_ex_reward.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_got_ex_reward.Add(tmp);
                }
            }
            if (sp.TryRead(7)) {
                m_cur_task = new AllianceBoardTaskStatusInfo();
                m_cur_task.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_available_task_num);}
            if (sp.TryWrite(1)) {sp.Write(m_add_task_num_cost);}
            if (sp.TryWrite(2)) {sp.Write(m_add_task_num);}
            if (sp.TryWrite(3)) {sp.Write(m_finish_task_num);}
            if (sp.TryWrite(4)) {sp.Write(m_finish_task_score);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_got_basic_reward.Count);
                for (int i = 0; i != m_got_basic_reward.Count; ++i) {
                    sp.Write(m_got_basic_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_got_ex_reward.Count);
                for (int i = 0; i != m_got_ex_reward.Count; ++i) {
                    sp.Write(m_got_ex_reward[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(7)) {int pos = sp.GetPos();sp.Skip(2); m_cur_task.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceBoardUserStatusInfo source) {
            m_available_task_num = source.m_available_task_num;
            m_add_task_num_cost = source.m_add_task_num_cost;
            m_add_task_num = source.m_add_task_num;
            m_finish_task_num = source.m_finish_task_num;
            m_finish_task_score = source.m_finish_task_score;
            m_got_basic_reward = source.m_got_basic_reward;
            m_got_ex_reward = source.m_got_ex_reward;
            m_cur_task = source.m_cur_task;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardAbandonTaskReqInfo : NetworkMessage {
        public static int[] Id = { 1400,23 };
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
        public void CopyFrom(CampAllianceBoardAbandonTaskReqInfo source) {
            m_task_id = source.m_task_id;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardExitNtfInfo : NetworkMessage {
        public static int[] Id = { 1406,23 };
        public static Ctrl VC;
        public Int64 m_dt;
        public Int32 m_old_alliance_id;
        public String m_odl_alliance_name = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_dt = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_old_alliance_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_odl_alliance_name = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_dt);}
            if (sp.TryWrite(1)) {sp.Write(m_old_alliance_id);}
            if (sp.TryWrite(2)) {sp.Write(m_odl_alliance_name);}
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardExitNtfInfo source) {
            m_dt = source.m_dt;
            m_old_alliance_id = source.m_old_alliance_id;
            m_odl_alliance_name = source.m_odl_alliance_name;
        }
    }
    
    [Serializable]
    public partial class CastAsSkillReqInfo : NetworkMessage {
        public static int[] Id = { 1412,23 };
        public static Ctrl VC;
        public Int16 m_type;
        public TilePos m_pos;
        public TilePos m_land_rect_pos;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                m_pos = new TilePos();
                m_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_land_rect_pos = new TilePos();
                m_land_rect_pos.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_type);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_land_rect_pos.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(CastAsSkillReqInfo source) {
            m_type = source.m_type;
            m_pos = source.m_pos;
            m_land_rect_pos = source.m_land_rect_pos;
        }
    }
    
    [Serializable]
    public partial class KvkPreCreepListReqInfo : NetworkMessage {
        public static int[] Id = { 1418,23 };
        public static Ctrl VC;
        public SByte m_country;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_country = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_country);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkPreCreepListReqInfo source) {
            m_country = source.m_country;
        }
    }
    
    [Serializable]
    public partial class AsTaskPeriodInfo : NetworkMessage {
        public static int[] Id = { 1424,23 };
        public static Ctrl VC;
        public Int16 m_group_id;
        public Int32 m_period_id;
        public Int64 m_cd_starttime;
        public Int64 m_cd_endtime;
        public Boolean m_unlock;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_group_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_period_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_cd_starttime = sp.ReadInt64();}
            if (sp.TryRead(3)) {m_cd_endtime = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_unlock = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_group_id);}
            if (sp.TryWrite(1)) {sp.Write(m_period_id);}
            if (sp.TryWrite(2)) {sp.Write(m_cd_starttime);}
            if (sp.TryWrite(3)) {sp.Write(m_cd_endtime);}
            if (sp.TryWrite(4)) {sp.Write(m_unlock);}
            sp.EnEnd();
        }
        public void CopyFrom(AsTaskPeriodInfo source) {
            m_group_id = source.m_group_id;
            m_period_id = source.m_period_id;
            m_cd_starttime = source.m_cd_starttime;
            m_cd_endtime = source.m_cd_endtime;
            m_unlock = source.m_unlock;
        }
    }
    
    [Serializable]
    public partial class AgentBackgroundInfoList : NetworkMessage {
        public static int[] Id = { 1430,23 };
        public static Ctrl VC;
        public List<AgentBackgroundInfo> m_agent_bg = new List<AgentBackgroundInfo>();
        public List<Int16> m_all_bg = new List<Int16>();

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
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_all_bg.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int16 tmp = sp.ReadInt16();
                    m_all_bg.Add(tmp);
                }
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
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_all_bg.Count);
                for (int i = 0; i != m_all_bg.Count; ++i) {
                    sp.Write(m_all_bg[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(AgentBackgroundInfoList source) {
            m_agent_bg = source.m_agent_bg;
            m_all_bg = source.m_all_bg;
        }
    }
    
    [Serializable]
    public partial class AsTaskScoreInfo : NetworkMessage {
        public static int[] Id = { 1436,23 };
        public static Ctrl VC;
        public List<AsTaskScoreMemberInfo> m_list = new List<AsTaskScoreMemberInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AsTaskScoreMemberInfo tmp = new AsTaskScoreMemberInfo();
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
        public void CopyFrom(AsTaskScoreInfo source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class ShameAgentInfo : NetworkMessage {
        public static int[] Id = { 1442,25 };
        public static Ctrl VC;
        public Int16 m_agent_id;
        public Int32 m_shame_item;
        public Int32 m_shame_lc;
        public Int32 m_agent_skin;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_agent_id = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_shame_item = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_shame_lc = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_agent_skin = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_agent_id);}
            if (sp.TryWrite(1)) {sp.Write(m_shame_item);}
            if (sp.TryWrite(2)) {sp.Write(m_shame_lc);}
            if (sp.TryWrite(3)) {sp.Write(m_agent_skin);}
            sp.EnEnd();
        }
        public void CopyFrom(ShameAgentInfo source) {
            m_agent_id = source.m_agent_id;
            m_shame_item = source.m_shame_item;
            m_shame_lc = source.m_shame_lc;
            m_agent_skin = source.m_agent_skin;
        }
    }
    
    [Serializable]
    public partial class UserShamePointNtfInfo : NetworkMessage {
        public static int[] Id = { 1448,25 };
        public static Ctrl VC;
        public List<UserShamePtInfo> m_shame_point_detail = new List<UserShamePtInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
                sp.Write((UInt16)m_shame_point_detail.Count);
                for (int i = 0; i != m_shame_point_detail.Count; ++i) {
                    m_shame_point_detail[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(UserShamePointNtfInfo source) {
            m_shame_point_detail = source.m_shame_point_detail;
        }
    }
    
    [Serializable]
    public partial class WeaponLevelupReqInfo : NetworkMessage {
        public static int[] Id = { 1454,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public List<ItemInfo> m_item_list = new List<ItemInfo>();
        public List<Int64> m_weapon_list = new List<Int64>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_item_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_item_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
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
                sp.Write((UInt16)m_item_list.Count);
                for (int i = 0; i != m_item_list.Count; ++i) {
                    m_item_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_weapon_list.Count);
                for (int i = 0; i != m_weapon_list.Count; ++i) {
                    sp.Write(m_weapon_list[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(WeaponLevelupReqInfo source) {
            m_id = source.m_id;
            m_item_list = source.m_item_list;
            m_weapon_list = source.m_weapon_list;
        }
    }
    
    [Serializable]
    public partial class WeaponAutoSplitInfo : NetworkMessage {
        public static int[] Id = { 1460,25 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_item_id;
        public Int32 m_item_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_item_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_item_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_item_id);}
            if (sp.TryWrite(2)) {sp.Write(m_item_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(WeaponAutoSplitInfo source) {
            m_id = source.m_id;
            m_item_id = source.m_item_id;
            m_item_cnt = source.m_item_cnt;
        }
    }
    
    [Serializable]
    public partial class UserSocialShareFinishReqInfo : NetworkMessage {
        public static int[] Id = { 1466,25 };
        public static Ctrl VC;
        public Int16 m_share_type;
        public Int64 m_share_param1;
        public Int64 m_share_param2;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_share_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_share_param1 = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_share_param2 = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_share_type);}
            if (sp.TryWrite(1)) {sp.Write(m_share_param1);}
            if (sp.TryWrite(2)) {sp.Write(m_share_param2);}
            sp.EnEnd();
        }
        public void CopyFrom(UserSocialShareFinishReqInfo source) {
            m_share_type = source.m_share_type;
            m_share_param1 = source.m_share_param1;
            m_share_param2 = source.m_share_param2;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomsInfo : NetworkMessage {
        public static int[] Id = { 1472,25 };
        public static Ctrl VC;
        public Int32 m_current_room;
        public List<CaptainRoom> m_room = new List<CaptainRoom>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_current_room = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_room.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptainRoom tmp = new CaptainRoom();
                    tmp.Decode(sp);
                    m_room.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_current_room);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_room.Count);
                for (int i = 0; i != m_room.Count; ++i) {
                    m_room[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CaptainRoomsInfo source) {
            m_current_room = source.m_current_room;
            m_room = source.m_room;
        }
    }
    
    [Serializable]
    public partial class CaptainRoomVisitRecordInfo : NetworkMessage {
        public static int[] Id = { 1478,25 };
        public static Ctrl VC;
        public List<CaptainRoomVisitInfo> m_record = new List<CaptainRoomVisitInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_record.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    CaptainRoomVisitInfo tmp = new CaptainRoomVisitInfo();
                    tmp.Decode(sp);
                    m_record.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(CaptainRoomVisitRecordInfo source) {
            m_record = source.m_record;
        }
    }
    
    [Serializable]
    public partial class RefundTroopInfo : NetworkMessage {
        public static int[] Id = { 1484,25 };
        public static Ctrl VC;
        public Int16 m_ratio;
        public List<ArmyInfo> m_dead_troops = new List<ArmyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ratio = sp.ReadInt16();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_dead_troops.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ArmyInfo tmp = new ArmyInfo();
                    tmp.Decode(sp);
                    m_dead_troops.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_ratio);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_dead_troops.Count);
                for (int i = 0; i != m_dead_troops.Count; ++i) {
                    m_dead_troops[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RefundTroopInfo source) {
            m_ratio = source.m_ratio;
            m_dead_troops = source.m_dead_troops;
        }
    }
    
    [Serializable]
    public partial class CampAllianceBoardTaskHistoryQueryAckInfo : NetworkMessage {
        public static int[] Id = { 1490,27 };
        public static Ctrl VC;
        public List<AllianceBoardApplyTaskRecord> m_apply_task_history = new List<AllianceBoardApplyTaskRecord>();
        public List<AllianceBoardFinishTaskCounter> m_complete_task_cnt = new List<AllianceBoardFinishTaskCounter>();
        public List<Int32> m_task_filter = new List<Int32>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_apply_task_history.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardApplyTaskRecord tmp = new AllianceBoardApplyTaskRecord();
                    tmp.Decode(sp);
                    m_apply_task_history.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_complete_task_cnt.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AllianceBoardFinishTaskCounter tmp = new AllianceBoardFinishTaskCounter();
                    tmp.Decode(sp);
                    m_complete_task_cnt.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_task_filter.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_task_filter.Add(tmp);
                }
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_apply_task_history.Count);
                for (int i = 0; i != m_apply_task_history.Count; ++i) {
                    m_apply_task_history[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_complete_task_cnt.Count);
                for (int i = 0; i != m_complete_task_cnt.Count; ++i) {
                    m_complete_task_cnt[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_task_filter.Count);
                for (int i = 0; i != m_task_filter.Count; ++i) {
                    sp.Write(m_task_filter[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            sp.EnEnd();
        }
        public void CopyFrom(CampAllianceBoardTaskHistoryQueryAckInfo source) {
            m_apply_task_history = source.m_apply_task_history;
            m_complete_task_cnt = source.m_complete_task_cnt;
            m_task_filter = source.m_task_filter;
        }
    }
    
    [Serializable]
    public partial class ClaimCumulativeRechargeCampaignRwdReqInfo : NetworkMessage {
        public static int[] Id = { 1496,27 };
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
        public void CopyFrom(ClaimCumulativeRechargeCampaignRwdReqInfo source) {
            m_id = source.m_id;
            m_camp_id = source.m_camp_id;
        }
    }
    
    [Serializable]
    public partial class AllianceUseResearchAckInfo : NetworkMessage {
        public static int[] Id = { 1503,29 };
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
        public void CopyFrom(AllianceUseResearchAckInfo source) {
            m_research_type = source.m_research_type;
        }
    }
    
    [Serializable]
    public partial class KvkBountyRewardAckInfo : NetworkMessage {
        public static int[] Id = { 1532,32 };
        public static Ctrl VC;
        public Int32 m_reward_total_num;
        public Int32 m_reward_drew_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_reward_total_num = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_reward_drew_num = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_reward_total_num);}
            if (sp.TryWrite(1)) {sp.Write(m_reward_drew_num);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkBountyRewardAckInfo source) {
            m_reward_total_num = source.m_reward_total_num;
            m_reward_drew_num = source.m_reward_drew_num;
        }
    }
    
    [Serializable]
    public partial class WheelCampaignSelectOptionReqInfo : NetworkMessage {
        public static int[] Id = { 1543,33 };
        public static Ctrl VC;
        public CampaignReqItemInfo m_aty_item;
        public Int32 m_selected_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_aty_item = new CampaignReqItemInfo();
                m_aty_item.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_selected_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_aty_item.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_selected_id);}
            sp.EnEnd();
        }
        public void CopyFrom(WheelCampaignSelectOptionReqInfo source) {
            m_aty_item = source.m_aty_item;
            m_selected_id = source.m_selected_id;
        }
    }
    
    [Serializable]
    public partial class AgentWgtBoxGradeUpAckInfo : NetworkMessage {
        public static int[] Id = { 1597,33 };
        public static Ctrl VC;
        public Int32 m_crit;
        public Int32 m_add_exp;
        public Int16 m_new_grade;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_crit = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_add_exp = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_new_grade = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_crit);}
            if (sp.TryWrite(1)) {sp.Write(m_add_exp);}
            if (sp.TryWrite(2)) {sp.Write(m_new_grade);}
            sp.EnEnd();
        }
        public void CopyFrom(AgentWgtBoxGradeUpAckInfo source) {
            m_crit = source.m_crit;
            m_add_exp = source.m_add_exp;
            m_new_grade = source.m_new_grade;
        }
    }
    
    [Serializable]
    public partial class NbpCampaignInfo : NetworkMessage {
        public static int[] Id = { 1635,34 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public NbpCfg m_cfg;
        public List<Int32> m_drew_rewards_levels = new List<Int32>();
        public List<Int32> m_drew_premium_rewards_levels = new List<Int32>();
        public Int32 m_exp;
        public Int32 m_level;
        public Boolean m_is_buy_premium;
        public Int16 m_daily_task_score;
        public Int16 m_drew_exp_daily_task_score;
        public Int32 m_curr_week;
        public List<NbpCampaignWeekTaskInfo> m_week_task_infos = new List<NbpCampaignWeekTaskInfo>();
        public Int16 m_exp_ratio;
        public List<BaseExchangeCampaignInfo> m_exchange_info = new List<BaseExchangeCampaignInfo>();
        public List<ItemInfo> m_current_items = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_cfg = new NbpCfg();
                m_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_rewards_levels.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_rewards_levels.Add(tmp);
                }
            }
            if (sp.TryRead(3)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_premium_rewards_levels.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_premium_rewards_levels.Add(tmp);
                }
            }
            if (sp.TryRead(4)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(5)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_is_buy_premium = sp.ReadBoolean();}
            if (sp.TryRead(7)) {m_daily_task_score = sp.ReadInt16();}
            if (sp.TryRead(8)) {m_drew_exp_daily_task_score = sp.ReadInt16();}
            if (sp.TryRead(9)) {m_curr_week = sp.ReadInt32();}
            if (sp.TryRead(10)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_week_task_infos.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    NbpCampaignWeekTaskInfo tmp = new NbpCampaignWeekTaskInfo();
                    tmp.Decode(sp);
                    m_week_task_infos.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(11)) {m_exp_ratio = sp.ReadInt16();}
            if (sp.TryRead(12)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_exchange_info.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseExchangeCampaignInfo tmp = new BaseExchangeCampaignInfo();
                    tmp.Decode(sp);
                    m_exchange_info.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(13)) {
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
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_rewards_levels.Count);
                for (int i = 0; i != m_drew_rewards_levels.Count; ++i) {
                    sp.Write(m_drew_rewards_levels[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(3)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_premium_rewards_levels.Count);
                for (int i = 0; i != m_drew_premium_rewards_levels.Count; ++i) {
                    sp.Write(m_drew_premium_rewards_levels[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(4)) {sp.Write(m_exp);}
            if (sp.TryWrite(5)) {sp.Write(m_level);}
            if (sp.TryWrite(6)) {sp.Write(m_is_buy_premium);}
            if (sp.TryWrite(7)) {sp.Write(m_daily_task_score);}
            if (sp.TryWrite(8)) {sp.Write(m_drew_exp_daily_task_score);}
            if (sp.TryWrite(9)) {sp.Write(m_curr_week);}
            if (sp.TryWrite(10)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_week_task_infos.Count);
                for (int i = 0; i != m_week_task_infos.Count; ++i) {
                    m_week_task_infos[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(11)) {sp.Write(m_exp_ratio);}
            if (sp.TryWrite(12)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_exchange_info.Count);
                for (int i = 0; i != m_exchange_info.Count; ++i) {
                    m_exchange_info[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(13)) {
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
        public void CopyFrom(NbpCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_cfg = source.m_cfg;
            m_drew_rewards_levels = source.m_drew_rewards_levels;
            m_drew_premium_rewards_levels = source.m_drew_premium_rewards_levels;
            m_exp = source.m_exp;
            m_level = source.m_level;
            m_is_buy_premium = source.m_is_buy_premium;
            m_daily_task_score = source.m_daily_task_score;
            m_drew_exp_daily_task_score = source.m_drew_exp_daily_task_score;
            m_curr_week = source.m_curr_week;
            m_week_task_infos = source.m_week_task_infos;
            m_exp_ratio = source.m_exp_ratio;
            m_exchange_info = source.m_exchange_info;
            m_current_items = source.m_current_items;
        }
    }
    
    [Serializable]
    public partial class NbpCampaignInfoChangeNtf : NetworkMessage {
        public static int[] Id = { 1641,34 };
        public static Ctrl VC;
        public Int64 m_camp_id;
        public Int32 m_level;
        public Int32 m_exp;
        public Int16 m_daily_task_score;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_camp_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_level = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_exp = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_daily_task_score = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_camp_id);}
            if (sp.TryWrite(1)) {sp.Write(m_level);}
            if (sp.TryWrite(2)) {sp.Write(m_exp);}
            if (sp.TryWrite(3)) {sp.Write(m_daily_task_score);}
            sp.EnEnd();
        }
        public void CopyFrom(NbpCampaignInfoChangeNtf source) {
            m_camp_id = source.m_camp_id;
            m_level = source.m_level;
            m_exp = source.m_exp;
            m_daily_task_score = source.m_daily_task_score;
        }
    }
    
    [Serializable]
    public partial class MonopolyRollDiceReqInfo : NetworkMessage {
        public static int[] Id = { 1648,35 };
        public static Ctrl VC;
        public Int32 m_choice_point;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_choice_point = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_choice_point);}
            sp.EnEnd();
        }
        public void CopyFrom(MonopolyRollDiceReqInfo source) {
            m_choice_point = source.m_choice_point;
        }
    }
    
    [Serializable]
    public partial class KvkRecycleTroopInfo : NetworkMessage {
        public static int[] Id = { 1665,36 };
        public static Ctrl VC;
        public Int16 m_troop_type;
        public Int64 m_troop_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_troop_type = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_troop_num = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_troop_type);}
            if (sp.TryWrite(1)) {sp.Write(m_troop_num);}
            sp.EnEnd();
        }
        public void CopyFrom(KvkRecycleTroopInfo source) {
            m_troop_type = source.m_troop_type;
            m_troop_num = source.m_troop_num;
        }
    }
    
    [Serializable]
    public partial class WarshipWarmUpCfg : NetworkMessage {
        public static int[] Id = { 1671,37 };
        public static Ctrl VC;
        public String m_iap_pic = "";
        public String m_iap_desc = "";
        public String m_reward_pic = "";
        public String m_reward_pic_claimed = "";
        public String m_reward_desc = "";
        public String m_reward = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_iap_pic = sp.ReadString();}
            if (sp.TryRead(1)) {m_iap_desc = sp.ReadString();}
            if (sp.TryRead(2)) {m_reward_pic = sp.ReadString();}
            if (sp.TryRead(3)) {m_reward_pic_claimed = sp.ReadString();}
            if (sp.TryRead(4)) {m_reward_desc = sp.ReadString();}
            if (sp.TryRead(5)) {m_reward = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_iap_pic);}
            if (sp.TryWrite(1)) {sp.Write(m_iap_desc);}
            if (sp.TryWrite(2)) {sp.Write(m_reward_pic);}
            if (sp.TryWrite(3)) {sp.Write(m_reward_pic_claimed);}
            if (sp.TryWrite(4)) {sp.Write(m_reward_desc);}
            if (sp.TryWrite(5)) {sp.Write(m_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWarmUpCfg source) {
            m_iap_pic = source.m_iap_pic;
            m_iap_desc = source.m_iap_desc;
            m_reward_pic = source.m_reward_pic;
            m_reward_pic_claimed = source.m_reward_pic_claimed;
            m_reward_desc = source.m_reward_desc;
            m_reward = source.m_reward;
        }
    }
    
    [Serializable]
    public partial class GetPrivateCustomInfoAckInfo : NetworkMessage {
        public static int[] Id = { 1682,38 };
        public static Ctrl VC;
        public List<PrivatecCustomPkgInfo> m_pkg_info_list = new List<PrivatecCustomPkgInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pkg_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PrivatecCustomPkgInfo tmp = new PrivatecCustomPkgInfo();
                    tmp.Decode(sp);
                    m_pkg_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pkg_info_list.Count);
                for (int i = 0; i != m_pkg_info_list.Count; ++i) {
                    m_pkg_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(GetPrivateCustomInfoAckInfo source) {
            m_pkg_info_list = source.m_pkg_info_list;
        }
    }
    
    [Serializable]
    public partial class EquipInfo : NetworkMessage {
        public static int[] Id = { 1696,40 };
        public static Ctrl VC;
        public Int64 m_id;
        public Int32 m_model_id;
        public Int16 m_wear_agent_id;
        public SByte m_wear_agent_part_id;
        public Boolean m_has_exclusive_talent;
        public Int32 m_exclusive_talent_type;
        public Byte m_enhance_level;
        public Int32 m_enhance_extra_odds;
        public Int32 m_skill_id;
        public Int32 m_enhance_cost_item_cnt;
        public Int32 m_purify_cnt;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_model_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_wear_agent_id = sp.ReadInt16();}
            if (sp.TryRead(3)) {m_wear_agent_part_id = sp.ReadSByte();}
            if (sp.TryRead(4)) {m_has_exclusive_talent = sp.ReadBoolean();}
            if (sp.TryRead(5)) {m_exclusive_talent_type = sp.ReadInt32();}
            if (sp.TryRead(6)) {m_enhance_level = sp.ReadByte();}
            if (sp.TryRead(7)) {m_enhance_extra_odds = sp.ReadInt32();}
            if (sp.TryRead(8)) {m_skill_id = sp.ReadInt32();}
            if (sp.TryRead(9)) {m_enhance_cost_item_cnt = sp.ReadInt32();}
            if (sp.TryRead(10)) {m_purify_cnt = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_model_id);}
            if (sp.TryWrite(2)) {sp.Write(m_wear_agent_id);}
            if (sp.TryWrite(3)) {sp.Write(m_wear_agent_part_id);}
            if (sp.TryWrite(4)) {sp.Write(m_has_exclusive_talent);}
            if (sp.TryWrite(5)) {sp.Write(m_exclusive_talent_type);}
            if (sp.TryWrite(6)) {sp.Write(m_enhance_level);}
            if (sp.TryWrite(7)) {sp.Write(m_enhance_extra_odds);}
            if (sp.TryWrite(8)) {sp.Write(m_skill_id);}
            if (sp.TryWrite(9)) {sp.Write(m_enhance_cost_item_cnt);}
            if (sp.TryWrite(10)) {sp.Write(m_purify_cnt);}
            sp.EnEnd();
        }
        public void CopyFrom(EquipInfo source) {
            m_id = source.m_id;
            m_model_id = source.m_model_id;
            m_wear_agent_id = source.m_wear_agent_id;
            m_wear_agent_part_id = source.m_wear_agent_part_id;
            m_has_exclusive_talent = source.m_has_exclusive_talent;
            m_exclusive_talent_type = source.m_exclusive_talent_type;
            m_enhance_level = source.m_enhance_level;
            m_enhance_extra_odds = source.m_enhance_extra_odds;
            m_skill_id = source.m_skill_id;
            m_enhance_cost_item_cnt = source.m_enhance_cost_item_cnt;
            m_purify_cnt = source.m_purify_cnt;
        }
    }
    
    [Serializable]
    public partial class EquipMaterialTransformReqInfo : NetworkMessage {
        public static int[] Id = { 1702,40 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_num;
        public SByte m_transform_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_num = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_transform_type = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_num);}
            if (sp.TryWrite(2)) {sp.Write(m_transform_type);}
            sp.EnEnd();
        }
        public void CopyFrom(EquipMaterialTransformReqInfo source) {
            m_id = source.m_id;
            m_num = source.m_num;
            m_transform_type = source.m_transform_type;
        }
    }
    
    [Serializable]
    public partial class PurchaseRebateSubCfg : NetworkMessage {
        public static int[] Id = { 1711,41 };
        public static Ctrl VC;
        public Int32 m_sub_id;
        public String m_icon = "";
        public String m_title = "";
        public String m_desc = "";
        public String m_jump = "";
        public String m_activity_background = "";
        public String m_activity_button = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_sub_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_title = sp.ReadString();}
            if (sp.TryRead(3)) {m_desc = sp.ReadString();}
            if (sp.TryRead(4)) {m_jump = sp.ReadString();}
            if (sp.TryRead(5)) {m_activity_background = sp.ReadString();}
            if (sp.TryRead(6)) {m_activity_button = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_sub_id);}
            if (sp.TryWrite(1)) {sp.Write(m_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_title);}
            if (sp.TryWrite(3)) {sp.Write(m_desc);}
            if (sp.TryWrite(4)) {sp.Write(m_jump);}
            if (sp.TryWrite(5)) {sp.Write(m_activity_background);}
            if (sp.TryWrite(6)) {sp.Write(m_activity_button);}
            sp.EnEnd();
        }
        public void CopyFrom(PurchaseRebateSubCfg source) {
            m_sub_id = source.m_sub_id;
            m_icon = source.m_icon;
            m_title = source.m_title;
            m_desc = source.m_desc;
            m_jump = source.m_jump;
            m_activity_background = source.m_activity_background;
            m_activity_button = source.m_activity_button;
        }
    }
    
    [Serializable]
    public partial class LimitedExchangeIapListAckInfo : NetworkMessage {
        public static int[] Id = { 1718,41 };
        public static Ctrl VC;
        public List<IapPackageInfo> m_pkg_info_list = new List<IapPackageInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_pkg_info_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    IapPackageInfo tmp = new IapPackageInfo();
                    tmp.Decode(sp);
                    m_pkg_info_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_pkg_info_list.Count);
                for (int i = 0; i != m_pkg_info_list.Count; ++i) {
                    m_pkg_info_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LimitedExchangeIapListAckInfo source) {
            m_pkg_info_list = source.m_pkg_info_list;
        }
    }
    
    [Serializable]
    public partial class AbandonedArsenalOpenGridReqInfo : NetworkMessage {
        public static int[] Id = { 1727,41 };
        public static Ctrl VC;
        public Int32 m_grid_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_grid_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_grid_index);}
            sp.EnEnd();
        }
        public void CopyFrom(AbandonedArsenalOpenGridReqInfo source) {
            m_grid_index = source.m_grid_index;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeCampaignPlayerInfo : NetworkMessage {
        public static int[] Id = { 1734,42 };
        public static Ctrl VC;
        public Int32 m_total_open_times;
        public Int32 m_free_times;
        public Int32 m_once_discount_times;
        public Int32 m_fifth_discount_times;
        public Int32 m_score;
        public List<Int32> m_drew_reward_scores = new List<Int32>();
        public Int32 m_core_reward_index;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_total_open_times = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_free_times = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_once_discount_times = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_fifth_discount_times = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_drew_reward_scores.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    Int32 tmp = sp.ReadInt32();
                    m_drew_reward_scores.Add(tmp);
                }
            }
            if (sp.TryRead(6)) {m_core_reward_index = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_total_open_times);}
            if (sp.TryWrite(1)) {sp.Write(m_free_times);}
            if (sp.TryWrite(2)) {sp.Write(m_once_discount_times);}
            if (sp.TryWrite(3)) {sp.Write(m_fifth_discount_times);}
            if (sp.TryWrite(4)) {sp.Write(m_score);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_drew_reward_scores.Count);
                for (int i = 0; i != m_drew_reward_scores.Count; ++i) {
                    sp.Write(m_drew_reward_scores[i]);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
            }
            if (sp.TryWrite(6)) {sp.Write(m_core_reward_index);}
            sp.EnEnd();
        }
        public void CopyFrom(StrangeCubeCampaignPlayerInfo source) {
            m_total_open_times = source.m_total_open_times;
            m_free_times = source.m_free_times;
            m_once_discount_times = source.m_once_discount_times;
            m_fifth_discount_times = source.m_fifth_discount_times;
            m_score = source.m_score;
            m_drew_reward_scores = source.m_drew_reward_scores;
            m_core_reward_index = source.m_core_reward_index;
        }
    }
    
    [Serializable]
    public partial class StrangeCubeDrawExtraRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1740,42 };
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
        public void CopyFrom(StrangeCubeDrawExtraRewardReqInfo source) {
            m_score = source.m_score;
        }
    }
    
    [Serializable]
    public partial class WarMarketDrawRewardInfo : NetworkMessage {
        public static int[] Id = { 1746,42 };
        public static Ctrl VC;
        public Int32 m_ItemId;
        public Int32 m_ItemNum;
        public Int32 m_NewItemId;
        public Int32 m_NewItemNum;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_ItemId = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_ItemNum = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_NewItemId = sp.ReadInt32();}
            if (sp.TryRead(3)) {m_NewItemNum = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_ItemId);}
            if (sp.TryWrite(1)) {sp.Write(m_ItemNum);}
            if (sp.TryWrite(2)) {sp.Write(m_NewItemId);}
            if (sp.TryWrite(3)) {sp.Write(m_NewItemNum);}
            sp.EnEnd();
        }
        public void CopyFrom(WarMarketDrawRewardInfo source) {
            m_ItemId = source.m_ItemId;
            m_ItemNum = source.m_ItemNum;
            m_NewItemId = source.m_NewItemId;
            m_NewItemNum = source.m_NewItemNum;
        }
    }
    
    [Serializable]
    public partial class LineTaskCampaignExtraAwardCfg : NetworkMessage {
        public static int[] Id = { 1752,44 };
        public static Ctrl VC;
        public Int32 m_score;
        public List<ItemInfo> m_awards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_awards.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    ItemInfo tmp = new ItemInfo();
                    tmp.Decode(sp);
                    m_awards.Add(tmp);
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
                sp.Write((UInt16)m_awards.Count);
                for (int i = 0; i != m_awards.Count; ++i) {
                    m_awards[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LineTaskCampaignExtraAwardCfg source) {
            m_score = source.m_score;
            m_awards = source.m_awards;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitNtfInfo : NetworkMessage {
        public static int[] Id = { 1767,44 };
        public static Ctrl VC;
        public LegendRecruitInfo m_base_info;
        public LegendOptionalAwardCfg m_optional_award_cfg;
        public LegendShopInfo m_shop_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_base_info = new LegendRecruitInfo();
                m_base_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_optional_award_cfg = new LegendOptionalAwardCfg();
                m_optional_award_cfg.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_shop_info = new LegendShopInfo();
                m_shop_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_base_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_optional_award_cfg.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {int pos = sp.GetPos();sp.Skip(2); m_shop_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitNtfInfo source) {
            m_base_info = source.m_base_info;
            m_optional_award_cfg = source.m_optional_award_cfg;
            m_shop_info = source.m_shop_info;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitReqInfo : NetworkMessage {
        public static int[] Id = { 1773,44 };
        public static Ctrl VC;
        public Int32 m_recruit_type;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_recruit_type = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_recruit_type);}
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitReqInfo source) {
            m_recruit_type = source.m_recruit_type;
        }
    }
    
    [Serializable]
    public partial class LegendRecruitGetOutputAckInfo : NetworkMessage {
        public static int[] Id = { 1781,44 };
        public static Ctrl VC;
        public List<LegendRecruitOutItemInfo> m_out_items = new List<LegendRecruitOutItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_out_items.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    LegendRecruitOutItemInfo tmp = new LegendRecruitOutItemInfo();
                    tmp.Decode(sp);
                    m_out_items.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_out_items.Count);
                for (int i = 0; i != m_out_items.Count; ++i) {
                    m_out_items[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(LegendRecruitGetOutputAckInfo source) {
            m_out_items = source.m_out_items;
        }
    }
    
    [Serializable]
    public partial class VoteSubmitReqInfo : NetworkMessage {
        public static int[] Id = { 1810,44 };
        public static Ctrl VC;
        public Int16 m_order;
        public Boolean m_is_vote;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_order = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_is_vote = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_order);}
            if (sp.TryWrite(1)) {sp.Write(m_is_vote);}
            sp.EnEnd();
        }
        public void CopyFrom(VoteSubmitReqInfo source) {
            m_order = source.m_order;
            m_is_vote = source.m_is_vote;
        }
    }
    
    [Serializable]
    public partial class KillTroopInfo : NetworkMessage {
        public static int[] Id = { 1884,46 };
        public static Ctrl VC;
        public Int16 m_troop_level;
        public Int64 m_kill_cnt;
        public Int64 m_kill_points;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_troop_level = sp.ReadInt16();}
            if (sp.TryRead(1)) {m_kill_cnt = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_kill_points = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_troop_level);}
            if (sp.TryWrite(1)) {sp.Write(m_kill_cnt);}
            if (sp.TryWrite(2)) {sp.Write(m_kill_points);}
            sp.EnEnd();
        }
        public void CopyFrom(KillTroopInfo source) {
            m_troop_level = source.m_troop_level;
            m_kill_cnt = source.m_kill_cnt;
            m_kill_points = source.m_kill_points;
        }
    }
    
    [Serializable]
    public partial class BossCampaignClaimAllServerRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1890,46 };
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
        public void CopyFrom(BossCampaignClaimAllServerRewardReqInfo source) {
            m_act_id = source.m_act_id;
        }
    }
    
    [Serializable]
    public partial class RecycleAtyRecycleReqInfo : NetworkMessage {
        public static int[] Id = { 1896,46 };
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
        public void CopyFrom(RecycleAtyRecycleReqInfo source) {
            m_order = source.m_order;
            m_num = source.m_num;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureCampaignAsInfo : NetworkMessage {
        public static int[] Id = { 1902,46 };
        public static Ctrl VC;
        public Int32 m_score;
        public String m_name = "";
        public String m_abbr = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_score = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_name = sp.ReadString();}
            if (sp.TryRead(2)) {m_abbr = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_score);}
            if (sp.TryWrite(1)) {sp.Write(m_name);}
            if (sp.TryWrite(2)) {sp.Write(m_abbr);}
            sp.EnEnd();
        }
        public void CopyFrom(AllianceTreasureCampaignAsInfo source) {
            m_score = source.m_score;
            m_name = source.m_name;
            m_abbr = source.m_abbr;
        }
    }
    
    [Serializable]
    public partial class AllianceTreasureReceivePlayerRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1908,46 };
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
        public void CopyFrom(AllianceTreasureReceivePlayerRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class PlayerReturnEventTaskInfo : NetworkMessage {
        public static int[] Id = { 1917,47 };
        public static Ctrl VC;
        public Int32 m_task_id;
        public Int64 m_point;
        public Int16 m_status;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_task_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_point = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_status = sp.ReadInt16();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_task_id);}
            if (sp.TryWrite(1)) {sp.Write(m_point);}
            if (sp.TryWrite(2)) {sp.Write(m_status);}
            sp.EnEnd();
        }
        public void CopyFrom(PlayerReturnEventTaskInfo source) {
            m_task_id = source.m_task_id;
            m_point = source.m_point;
            m_status = source.m_status;
        }
    }
    
    [Serializable]
    public partial class HeroOptionalPkgGroupItem : NetworkMessage {
        public static int[] Id = { 1927,48 };
        public static Ctrl VC;
        public Int32 m_pkg_id;
        public Int32 m_order_id;
        public Boolean m_is_available;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_pkg_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_order_id = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_is_available = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_pkg_id);}
            if (sp.TryWrite(1)) {sp.Write(m_order_id);}
            if (sp.TryWrite(2)) {sp.Write(m_is_available);}
            sp.EnEnd();
        }
        public void CopyFrom(HeroOptionalPkgGroupItem source) {
            m_pkg_id = source.m_pkg_id;
            m_order_id = source.m_order_id;
            m_is_available = source.m_is_available;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerStepInfo : NetworkMessage {
        public static int[] Id = { 1988,49 };
        public static Ctrl VC;
        public SByte m_step_id;
        public SByte m_answer_num;
        public SByte m_right_num;
        public SByte m_wrong_num;
        public QuestionInfo m_question;
        public Int64 m_start_time;
        public Int64 m_end_time;
        public Boolean m_is_finish;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_answer_num = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_right_num = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_wrong_num = sp.ReadSByte();}
            if (sp.TryRead(4)) {
                m_question = new QuestionInfo();
                m_question.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(5)) {m_start_time = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_end_time = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_is_finish = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step_id);}
            if (sp.TryWrite(1)) {sp.Write(m_answer_num);}
            if (sp.TryWrite(2)) {sp.Write(m_right_num);}
            if (sp.TryWrite(3)) {sp.Write(m_wrong_num);}
            if (sp.TryWrite(4)) {int pos = sp.GetPos();sp.Skip(2); m_question.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(5)) {sp.Write(m_start_time);}
            if (sp.TryWrite(6)) {sp.Write(m_end_time);}
            if (sp.TryWrite(7)) {sp.Write(m_is_finish);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerStepInfo source) {
            m_step_id = source.m_step_id;
            m_answer_num = source.m_answer_num;
            m_right_num = source.m_right_num;
            m_wrong_num = source.m_wrong_num;
            m_question = source.m_question;
            m_start_time = source.m_start_time;
            m_end_time = source.m_end_time;
            m_is_finish = source.m_is_finish;
        }
    }
    
    [Serializable]
    public partial class QuestionAnswerRewardReqInfo : NetworkMessage {
        public static int[] Id = { 1994,49 };
        public static Ctrl VC;
        public SByte m_step_id;
        public SByte m_right_num;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_step_id = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_right_num = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_step_id);}
            if (sp.TryWrite(1)) {sp.Write(m_right_num);}
            sp.EnEnd();
        }
        public void CopyFrom(QuestionAnswerRewardReqInfo source) {
            m_step_id = source.m_step_id;
            m_right_num = source.m_right_num;
        }
    }
    
    [Serializable]
    public partial class FlipCardExtraRewardConfig : NetworkMessage {
        public static int[] Id = { 2000,49 };
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
        public void CopyFrom(FlipCardExtraRewardConfig source) {
            m_score = source.m_score;
            m_rewards = source.m_rewards;
        }
    }
    
    [Serializable]
    public partial class FlipCardAckInfo : NetworkMessage {
        public static int[] Id = { 2006,49 };
        public static Ctrl VC;
        public Boolean m_is_unlock_next_layer;
        public SByte m_unlock_next_layer_cell_x;
        public SByte m_unlock_next_layer_cell_y;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_is_unlock_next_layer = sp.ReadBoolean();}
            if (sp.TryRead(1)) {m_unlock_next_layer_cell_x = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_unlock_next_layer_cell_y = sp.ReadSByte();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_is_unlock_next_layer);}
            if (sp.TryWrite(1)) {sp.Write(m_unlock_next_layer_cell_x);}
            if (sp.TryWrite(2)) {sp.Write(m_unlock_next_layer_cell_y);}
            sp.EnEnd();
        }
        public void CopyFrom(FlipCardAckInfo source) {
            m_is_unlock_next_layer = source.m_is_unlock_next_layer;
            m_unlock_next_layer_cell_x = source.m_unlock_next_layer_cell_x;
            m_unlock_next_layer_cell_y = source.m_unlock_next_layer_cell_y;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponPurifyConfirmReqInfo : NetworkMessage {
        public static int[] Id = { 2038,50 };
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
        public void CopyFrom(WarshipWeaponPurifyConfirmReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class WarshipWeaponShopBuyReqInfo : NetworkMessage {
        public static int[] Id = { 2044,50 };
        public static Ctrl VC;
        public Int32 m_goods_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_goods_id = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_goods_id);}
            sp.EnEnd();
        }
        public void CopyFrom(WarshipWeaponShopBuyReqInfo source) {
            m_goods_id = source.m_goods_id;
        }
    }
    
    [Serializable]
    public partial class ValorShopItemBuyRecord : NetworkMessage {
        public static int[] Id = { 2054,51 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int32 m_bought_cn;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_bought_cn = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_bought_cn);}
            sp.EnEnd();
        }
        public void CopyFrom(ValorShopItemBuyRecord source) {
            m_id = source.m_id;
            m_bought_cn = source.m_bought_cn;
        }
    }
    
    [Serializable]
    public partial class RaidCampaignInfo : NetworkMessage {
        public static int[] Id = { 2112,54 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public RaidConfig m_config;
        public RaidPlayerInfo m_player_info;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_config = new RaidConfig();
                m_config.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {
                m_player_info = new RaidPlayerInfo();
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
        public void CopyFrom(RaidCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_config = source.m_config;
            m_player_info = source.m_player_info;
        }
    }
    
    [Serializable]
    public partial class RaidSetSlotArmyReqInfo : NetworkMessage {
        public static int[] Id = { 2118,54 };
        public static Ctrl VC;
        public SByte m_slot;
        public RaidGroupInfo m_group;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_slot = sp.ReadSByte();}
            if (sp.TryRead(1)) {
                m_group = new RaidGroupInfo();
                m_group.Decode(sp);
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_slot);}
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_group.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            sp.EnEnd();
        }
        public void CopyFrom(RaidSetSlotArmyReqInfo source) {
            m_slot = source.m_slot;
            m_group = source.m_group;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeFightDetailInfo : NetworkMessage {
        public static int[] Id = { 2124,54 };
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
        public void CopyFrom(RaidChallengeFightDetailInfo source) {
            m_cur = source.m_cur;
            m_total = source.m_total;
            m_rounds = source.m_rounds;
            m_is_attacker = source.m_is_attacker;
        }
    }
    
    [Serializable]
    public partial class RaidChallengeGroupInfo : NetworkMessage {
        public static int[] Id = { 2130,54 };
        public static Ctrl VC;
        public Byte m_position;
        public List<RaidChallengeAgentInfo> m_agent = new List<RaidChallengeAgentInfo>();
        public List<ArmyInfo> m_troop = new List<ArmyInfo>();
        public Int16 m_warship_id;
        public Int16 m_army_banner_id;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_position = sp.ReadByte();}
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_agent.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RaidChallengeAgentInfo tmp = new RaidChallengeAgentInfo();
                    tmp.Decode(sp);
                    m_agent.Add(tmp);
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
                sp.Write((UInt16)m_agent.Count);
                for (int i = 0; i != m_agent.Count; ++i) {
                    m_agent[i].Encode(sp);
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
        public void CopyFrom(RaidChallengeGroupInfo source) {
            m_position = source.m_position;
            m_agent = source.m_agent;
            m_troop = source.m_troop;
            m_warship_id = source.m_warship_id;
            m_army_banner_id = source.m_army_banner_id;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactStarUpReqInfo : NetworkMessage {
        public static int[] Id = { 2147,56 };
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
        public void CopyFrom(MuseumArtifactStarUpReqInfo source) {
            m_model_id = source.m_model_id;
        }
    }
    
    [Serializable]
    public partial class MuseumArtifactInfo : NetworkMessage {
        public static int[] Id = { 2153,56 };
        public static Ctrl VC;
        public Int32 m_model_id;
        public SByte m_star;
        public SByte m_state;
        public Int64 m_power;
        public Int32 m_rarity;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_model_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_star = sp.ReadSByte();}
            if (sp.TryRead(2)) {m_state = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_power = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_rarity = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_model_id);}
            if (sp.TryWrite(1)) {sp.Write(m_star);}
            if (sp.TryWrite(2)) {sp.Write(m_state);}
            if (sp.TryWrite(3)) {sp.Write(m_power);}
            if (sp.TryWrite(4)) {sp.Write(m_rarity);}
            sp.EnEnd();
        }
        public void CopyFrom(MuseumArtifactInfo source) {
            m_model_id = source.m_model_id;
            m_star = source.m_star;
            m_state = source.m_state;
            m_power = source.m_power;
            m_rarity = source.m_rarity;
        }
    }
    
    [Serializable]
    public partial class OverturnShopInfo : NetworkMessage {
        public static int[] Id = { 2161,57 };
        public static Ctrl VC;
        public List<OverturnShopInfoItem> m_goods = new List<OverturnShopInfoItem>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_goods.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    OverturnShopInfoItem tmp = new OverturnShopInfoItem();
                    tmp.Decode(sp);
                    m_goods.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_goods.Count);
                for (int i = 0; i != m_goods.Count; ++i) {
                    m_goods[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(OverturnShopInfo source) {
            m_goods = source.m_goods;
        }
    }
    
    [Serializable]
    public partial class OverturnBattlePassportDrawRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2168,57 };
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
        public void CopyFrom(OverturnBattlePassportDrawRewardReqInfo source) {
            m_times = source.m_times;
        }
    }
    
    [Serializable]
    public partial class RebuildingCampaignInfo : NetworkMessage {
        public static int[] Id = { 2174,58 };
        public static Ctrl VC;
        public BaseCampaignInfo m_basic_info;
        public Int32 m_server_rank;
        public List<RebuildingCampaignBuffInfo> m_buffs = new List<RebuildingCampaignBuffInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_basic_info = new BaseCampaignInfo();
                m_basic_info.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {m_server_rank = sp.ReadInt32();}
            if (sp.TryRead(2)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_buffs.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    RebuildingCampaignBuffInfo tmp = new RebuildingCampaignBuffInfo();
                    tmp.Decode(sp);
                    m_buffs.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_basic_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {sp.Write(m_server_rank);}
            if (sp.TryWrite(2)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_buffs.Count);
                for (int i = 0; i != m_buffs.Count; ++i) {
                    m_buffs[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(RebuildingCampaignInfo source) {
            m_basic_info = source.m_basic_info;
            m_server_rank = source.m_server_rank;
            m_buffs = source.m_buffs;
        }
    }
    
    [Serializable]
    public partial class SetTroopSkinReqInfo : NetworkMessage {
        public static int[] Id = { 2186,59 };
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
        public void CopyFrom(SetTroopSkinReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class AgentShopInfo : NetworkMessage {
        public static int[] Id = { 2192,61 };
        public static Ctrl VC;
        public List<AgentShopGoodsInfo> m_goods_list = new List<AgentShopGoodsInfo>();
        public Int64 m_next_refresh_time;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_goods_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    AgentShopGoodsInfo tmp = new AgentShopGoodsInfo();
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
        public void CopyFrom(AgentShopInfo source) {
            m_goods_list = source.m_goods_list;
            m_next_refresh_time = source.m_next_refresh_time;
        }
    }
    
    [Serializable]
    public partial class ChainGiftsReceiveNormalRewardReqInfo : NetworkMessage {
        public static int[] Id = { 2254,63 };
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
        public void CopyFrom(ChainGiftsReceiveNormalRewardReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class FriendApplyInfoAckInfo : NetworkMessage {
        public static int[] Id = { 2260,63 };
        public static Ctrl VC;
        public List<FriendApplyInfo> m_self_apply_list = new List<FriendApplyInfo>();
        public List<FriendApplyInfo> m_apply_list = new List<FriendApplyInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_self_apply_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendApplyInfo tmp = new FriendApplyInfo();
                    tmp.Decode(sp);
                    m_self_apply_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_apply_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    FriendApplyInfo tmp = new FriendApplyInfo();
                    tmp.Decode(sp);
                    m_apply_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_self_apply_list.Count);
                for (int i = 0; i != m_self_apply_list.Count; ++i) {
                    m_self_apply_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_apply_list.Count);
                for (int i = 0; i != m_apply_list.Count; ++i) {
                    m_apply_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            sp.EnEnd();
        }
        public void CopyFrom(FriendApplyInfoAckInfo source) {
            m_self_apply_list = source.m_self_apply_list;
            m_apply_list = source.m_apply_list;
        }
    }
    
    [Serializable]
    public partial class FriendSearchUserReqInfo : NetworkMessage {
        public static int[] Id = { 2266,63 };
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
        public void CopyFrom(FriendSearchUserReqInfo source) {
            m_key = source.m_key;
        }
    }
    
    [Serializable]
    public partial class PuzzleCampaignPuzzleInfo : NetworkMessage {
        public static int[] Id = { 2272,63 };
        public static Ctrl VC;
        public Int32 m_id;
        public String m_puzzle_icon = "";
        public SByte m_puzzle_num;
        public Int32 m_reward_item_id;
        public String m_puzzle_name = "";
        public List<PuzzleCampaignPuzzlePieceInfo> m_piece_list = new List<PuzzleCampaignPuzzlePieceInfo>();
        public Boolean m_is_send_finish_reward;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_puzzle_icon = sp.ReadString();}
            if (sp.TryRead(2)) {m_puzzle_num = sp.ReadSByte();}
            if (sp.TryRead(3)) {m_reward_item_id = sp.ReadInt32();}
            if (sp.TryRead(4)) {m_puzzle_name = sp.ReadString();}
            if (sp.TryRead(5)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_piece_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    PuzzleCampaignPuzzlePieceInfo tmp = new PuzzleCampaignPuzzlePieceInfo();
                    tmp.Decode(sp);
                    m_piece_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(6)) {m_is_send_finish_reward = sp.ReadBoolean();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_puzzle_icon);}
            if (sp.TryWrite(2)) {sp.Write(m_puzzle_num);}
            if (sp.TryWrite(3)) {sp.Write(m_reward_item_id);}
            if (sp.TryWrite(4)) {sp.Write(m_puzzle_name);}
            if (sp.TryWrite(5)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_piece_list.Count);
                for (int i = 0; i != m_piece_list.Count; ++i) {
                    m_piece_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(6)) {sp.Write(m_is_send_finish_reward);}
            sp.EnEnd();
        }
        public void CopyFrom(PuzzleCampaignPuzzleInfo source) {
            m_id = source.m_id;
            m_puzzle_icon = source.m_puzzle_icon;
            m_puzzle_num = source.m_puzzle_num;
            m_reward_item_id = source.m_reward_item_id;
            m_puzzle_name = source.m_puzzle_name;
            m_piece_list = source.m_piece_list;
            m_is_send_finish_reward = source.m_is_send_finish_reward;
        }
    }
    
    [Serializable]
    public partial class AgentEquipEnhanceReqInfo : NetworkMessage {
        public static int[] Id = { 2284,64 };
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
        public void CopyFrom(AgentEquipEnhanceReqInfo source) {
            m_equip_id = source.m_equip_id;
        }
    }
    
    [Serializable]
    public partial class SetHomeBackgroundReqInfo : NetworkMessage {
        public static int[] Id = { 2290,64 };
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
        public void CopyFrom(SetHomeBackgroundReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class SetTroopTailSkinReqInfo : NetworkMessage {
        public static int[] Id = { 2296,64 };
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
        public void CopyFrom(SetTroopTailSkinReqInfo source) {
            m_id = source.m_id;
        }
    }
    
    [Serializable]
    public partial class BaseTeleportEffectList : NetworkMessage {
        public static int[] Id = { 2313,65 };
        public static Ctrl VC;
        public List<BaseTeleportEffectInfo> m_list = new List<BaseTeleportEffectInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    BaseTeleportEffectInfo tmp = new BaseTeleportEffectInfo();
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
        public void CopyFrom(BaseTeleportEffectList source) {
            m_list = source.m_list;
        }
    }
    
    [Serializable]
    public partial class VideoChannelCampaignInfo : NetworkMessage {
        public static int[] Id = { 2319,66 };
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
        public void CopyFrom(VideoChannelCampaignInfo source) {
            m_basic_info = source.m_basic_info;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoDetailsAckInfo : NetworkMessage {
        public static int[] Id = { 2325,66 };
        public static Ctrl VC;
        public VideoInfo m_video;
        public List<VideoInfo> m_related_video_list = new List<VideoInfo>();
        public Int32 m_related_video_total_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_video = new VideoInfo();
                m_video.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_related_video_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoInfo tmp = new VideoInfo();
                    tmp.Decode(sp);
                    m_related_video_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_related_video_total_count = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_video.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(1)) {
                int pos = sp.GetPos();sp.Skip(2);
                sp.Write((UInt16)m_related_video_list.Count);
                for (int i = 0; i != m_related_video_list.Count; ++i) {
                    m_related_video_list[i].Encode(sp);
                }
                sp.WriteSize(pos,sp.GetPos()-pos);
                sp.BindCtrl(VC);
            }
            if (sp.TryWrite(2)) {sp.Write(m_related_video_total_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoDetailsAckInfo source) {
            m_video = source.m_video;
            m_related_video_list = source.m_related_video_list;
            m_related_video_total_count = source.m_related_video_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelViewVideoReqInfo : NetworkMessage {
        public static int[] Id = { 2331,66 };
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
        public void CopyFrom(VideoChannelViewVideoReqInfo source) {
            m_video_id = source.m_video_id;
        }
    }
    
    [Serializable]
    public partial class VideoChannelReplyVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2337,66 };
        public static Ctrl VC;
        public Int64 m_id;
        public String m_content = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt64();}
            if (sp.TryRead(1)) {m_content = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_content);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelReplyVideoCommentReqInfo source) {
            m_id = source.m_id;
            m_content = source.m_content;
        }
    }
    
    [Serializable]
    public partial class VideoChannelDislikeVideoCommentReqInfo : NetworkMessage {
        public static int[] Id = { 2343,66 };
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
        public void CopyFrom(VideoChannelDislikeVideoCommentReqInfo source) {
            m_id = source.m_id;
            m_positive = source.m_positive;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoCreatorRankAckInfo : NetworkMessage {
        public static int[] Id = { 2349,66 };
        public static Ctrl VC;
        public List<VideoCreatorRankItem> m_rank_list = new List<VideoCreatorRankItem>();
        public VideoCreatorRankItem m_self_rank;
        public Int32 m_total_count;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                UInt16 arraySize = sp.ReadUInt16();
                m_rank_list.Clear();
                for (UInt16 i = 0; i != arraySize; ++i) {
                    VideoCreatorRankItem tmp = new VideoCreatorRankItem();
                    tmp.Decode(sp);
                    m_rank_list.Add(tmp);
                }
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(1)) {
                m_self_rank = new VideoCreatorRankItem();
                m_self_rank.Decode(sp);
                sp.BindCtrl(VC);
            }
            if (sp.TryRead(2)) {m_total_count = sp.ReadInt32();}
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
            if (sp.TryWrite(1)) {int pos = sp.GetPos();sp.Skip(2); m_self_rank.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
            if (sp.TryWrite(2)) {sp.Write(m_total_count);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoCreatorRankAckInfo source) {
            m_rank_list = source.m_rank_list;
            m_self_rank = source.m_self_rank;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetTagVideoListAckInfo : NetworkMessage {
        public static int[] Id = { 2355,66 };
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
        public void CopyFrom(VideoChannelGetTagVideoListAckInfo source) {
            m_video_list = source.m_video_list;
            m_total_count = source.m_total_count;
        }
    }
    
    [Serializable]
    public partial class VideoChannelShopBuyRecord : NetworkMessage {
        public static int[] Id = { 2361,66 };
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
        public void CopyFrom(VideoChannelShopBuyRecord source) {
            m_goods_id = source.m_goods_id;
            m_bought_num = source.m_bought_num;
        }
    }
    
    [Serializable]
    public partial class VideoChannelGetVideoDemandAckInfo : NetworkMessage {
        public static int[] Id = { 2367,66 };
        public static Ctrl VC;
        public String m_verify_string = "";
        public Int32 m_video_minimum_length;
        public Int32 m_video_maximum_age;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_verify_string = sp.ReadString();}
            if (sp.TryRead(1)) {m_video_minimum_length = sp.ReadInt32();}
            if (sp.TryRead(2)) {m_video_maximum_age = sp.ReadInt32();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_verify_string);}
            if (sp.TryWrite(1)) {sp.Write(m_video_minimum_length);}
            if (sp.TryWrite(2)) {sp.Write(m_video_maximum_age);}
            sp.EnEnd();
        }
        public void CopyFrom(VideoChannelGetVideoDemandAckInfo source) {
            m_verify_string = source.m_verify_string;
            m_video_minimum_length = source.m_video_minimum_length;
            m_video_maximum_age = source.m_video_maximum_age;
        }
    }
    
    [Serializable]
    public partial class UserMedalQuestInfo : NetworkMessage {
        public static int[] Id = { 2392,68 };
        public static Ctrl VC;
        public Int32 m_id;
        public Int64 m_param1;
        public Boolean m_is_finish;
        public Int64 m_param2;
        public Int64 m_param3;
        public Int64 m_param4;
        public Int64 m_param5;
        public Int64 m_param6;

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_id = sp.ReadInt32();}
            if (sp.TryRead(1)) {m_param1 = sp.ReadInt64();}
            if (sp.TryRead(2)) {m_is_finish = sp.ReadBoolean();}
            if (sp.TryRead(3)) {m_param2 = sp.ReadInt64();}
            if (sp.TryRead(4)) {m_param3 = sp.ReadInt64();}
            if (sp.TryRead(5)) {m_param4 = sp.ReadInt64();}
            if (sp.TryRead(6)) {m_param5 = sp.ReadInt64();}
            if (sp.TryRead(7)) {m_param6 = sp.ReadInt64();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_id);}
            if (sp.TryWrite(1)) {sp.Write(m_param1);}
            if (sp.TryWrite(2)) {sp.Write(m_is_finish);}
            if (sp.TryWrite(3)) {sp.Write(m_param2);}
            if (sp.TryWrite(4)) {sp.Write(m_param3);}
            if (sp.TryWrite(5)) {sp.Write(m_param4);}
            if (sp.TryWrite(6)) {sp.Write(m_param5);}
            if (sp.TryWrite(7)) {sp.Write(m_param6);}
            sp.EnEnd();
        }
        public void CopyFrom(UserMedalQuestInfo source) {
            m_id = source.m_id;
            m_param1 = source.m_param1;
            m_is_finish = source.m_is_finish;
            m_param2 = source.m_param2;
            m_param3 = source.m_param3;
            m_param4 = source.m_param4;
            m_param5 = source.m_param5;
            m_param6 = source.m_param6;
        }
    }
    
    [Serializable]
    public partial class VideoChannelAddVideoToSubchannelReqInfo : NetworkMessage {
        public static int[] Id = { 2398,68 };
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
        public void CopyFrom(VideoChannelAddVideoToSubchannelReqInfo source) {
            m_subchannel_type = source.m_subchannel_type;
            m_subchannel_id = source.m_subchannel_id;
            m_video_id = source.m_video_id;
        }
    }
    
    [Serializable]
    public partial class TrackingChatReqInfo : NetworkMessage {
        public static int[] Id = { 2404,71 };
        public static Ctrl VC;
        public SByte m_chat_type;
        public String m_chat_receiver_id = "";
        public String m_chat_message = "";

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {m_chat_type = sp.ReadSByte();}
            if (sp.TryRead(1)) {m_chat_receiver_id = sp.ReadString();}
            if (sp.TryRead(2)) {m_chat_message = sp.ReadString();}
            sp.DeEnd();
        }
        public override void Encode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryWrite(0)) {sp.Write(m_chat_type);}
            if (sp.TryWrite(1)) {sp.Write(m_chat_receiver_id);}
            if (sp.TryWrite(2)) {sp.Write(m_chat_message);}
            sp.EnEnd();
        }
        public void CopyFrom(TrackingChatReqInfo source) {
            m_chat_type = source.m_chat_type;
            m_chat_receiver_id = source.m_chat_receiver_id;
            m_chat_message = source.m_chat_message;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetDropDataAckInfo : NetworkMessage {
        public static int[] Id = { 2440,72 };
        public static Ctrl VC;
        public List<DropCampaignRuleInfo> m_drop_rule = new List<DropCampaignRuleInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
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
            if (sp.TryWrite(0)) {
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
        public void CopyFrom(NewReturnEventGetDropDataAckInfo source) {
            m_drop_rule = source.m_drop_rule;
        }
    }
    
    [Serializable]
    public partial class NewReturnEventGetPackageFreeRewardAckInfo : NetworkMessage {
        public static int[] Id = { 2446,72 };
        public static Ctrl VC;
        public NewReturnEventPackageInfo m_package_info;
        public List<ItemInfo> m_rewards = new List<ItemInfo>();

        public override void Decode(SPack sp) {
            sp.BindCtrl(VC);
            if (sp.TryRead(0)) {
                m_package_info = new NewReturnEventPackageInfo();
                m_package_info.Decode(sp);
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
            if (sp.TryWrite(0)) {int pos = sp.GetPos();sp.Skip(2); m_package_info.Encode(sp); sp.WriteSize(pos,sp.GetPos()-pos); sp.BindCtrl(VC);}
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
        public void CopyFrom(NewReturnEventGetPackageFreeRewardAckInfo source) {
            m_package_info = source.m_package_info;
            m_rewards = source.m_rewards;
        }
    }
    
}
