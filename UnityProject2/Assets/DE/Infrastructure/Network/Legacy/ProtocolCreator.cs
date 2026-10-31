using System;
using System.Collections.Generic;
using Scpp;

public partial class Protocol {
    public static NetworkMessage CreateMessage(MsgType type)
    {
        NetworkMessage msg = null;
        switch (type) {
        case MsgType.LOGIN_REQ:
            msg = new LoginInfo();
            break;
        case MsgType.LOGIN_ACK:
            msg = new UserInfo();
            break;
        case MsgType.CLEAR_GRID_VIEW_REQ:
            msg = new GridPos();
            break;
        case MsgType.BUILDING_UPGRADE_REQ:
            msg = new BuildingUpgradeInfo();
            break;
        case MsgType.BUILDING_UPGRADE_ACK:
            msg = new BuildingInfo();
            break;
        case MsgType.BUILD_REQ:
            msg = new BuildReqInfo();
            break;
        case MsgType.BUILD_ACK:
            msg = new BuildingInfo();
            break;
        case MsgType.RES_NTF:
            msg = new ResInfo();
            break;
        case MsgType.BUILD_COMPLETE_NTF:
            msg = new BuildingInfo();
            break;
        case MsgType.BUILDING_NTF:
            msg = new BuildingNtfInfo();
            break;
        case MsgType.GM_INFO_NTF:
            msg = new GmInfo();
            break;
        case MsgType.BUILD_PROG_NTF:
            msg = new BuildProgNtfInfo();
            break;
        case MsgType.BUILDING_CANCEL_REQ:
            msg = new BuildingCancelInfo();
            break;
        case MsgType.BUILDING_CANCEL_ACK:
            msg = new BuildingInfo();
            break;
        case MsgType.TROOP_TRAIN_REQ:
            msg = new TroopTrainInfo();
            break;
        case MsgType.TROOP_TRAIN_ACK:
            msg = new TroopProgInfo();
            break;
        case MsgType.TROOP_NTF:
            msg = new TroopInfo();
            break;
        case MsgType.GRID_INFO_NTF:
            msg = new GridInfo();
            break;
        case MsgType.GRID_VIEW_REQ:
            msg = new GridViewReqInfo();
            break;
        case MsgType.MARCH_REQ:
            msg = new MarchReqInfo();
            break;
        case MsgType.MARCH_NTF:
            msg = new MarchInfo();
            break;
        case MsgType.MARCH_COMPLETE_NTF:
            msg = new MarchInfo();
            break;
        case MsgType.TILE_UPDATE_NTF:
            msg = new TileUpdateInfo();
            break;
        case MsgType.TILE_INFO_REQ:
            msg = new TilePos();
            break;
        case MsgType.TILE_INFO_ACK:
            msg = new TileDetailInfo();
            break;
        case MsgType.RELOCATE_CITY_REQ:
            msg = new TilePos();
            break;
        case MsgType.USER_MAP_NTF:
            msg = new UserMapInfo();
            break;
        case MsgType.ALLIANCE_LIST_ACK:
            msg = new AllianceListInfo();
            break;
        case MsgType.JOIN_ALLIANCE_REQ:
            msg = new ApplyJoinAllianceReqInfo();
            break;
        case MsgType.JOIN_ALLIANCE_NTF:
            msg = new UserAllianceNtfInfo();
            break;
        case MsgType.CREATE_ALLIANCE_REQ:
            msg = new CreateAllianceInfo();
            break;
        case MsgType.CREATE_ALLIANCE_ACK:
            msg = new AllianceBriefInfo();
            break;
        case MsgType.ALLIANCE_MEMBER_REQ:
            msg = new AllianceReqInfo();
            break;
        case MsgType.ALLIANCE_MEMBER_ACK:
            msg = new AllianceMemberAckInfo();
            break;
        case MsgType.USER_INFO_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.USER_INFO_ACK:
            msg = new UserInfo();
            break;
        case MsgType.QUIT_ALLIANCE_NTF:
            msg = new UserAllianceNtfInfo();
            break;
        case MsgType.GET_RESEARCH_LIST_REQ:
            msg = new GetResearchListReqInfo();
            break;
        case MsgType.GET_RESEARCH_LIST_ACK:
            msg = new GetResearchListAckInfo();
            break;
        case MsgType.GET_RESEARCH_REQ:
            msg = new GetResearchReqInfo();
            break;
        case MsgType.GET_RESEARCH_ACK:
            msg = new GetResearchAckInfo();
            break;
        case MsgType.UPGRADE_RESEARCH_REQ:
            msg = new UpgradeResearchReqInfo();
            break;
        case MsgType.UPGRADE_RESEARCH_ACK:
            msg = new UpgradeResearchAckInfo();
            break;
        case MsgType.UPGRADE_RESEARCH_NTF:
            msg = new UpgradeResearchNtfInfo();
            break;
        case MsgType.RESEARCH_COMPLETE_NTF:
            msg = new ResearchBaseInfo();
            break;
        case MsgType.RESEARCH_CANCEL_REQ:
            msg = new ResearchCancelInfo();
            break;
        case MsgType.RALLY_REQ:
            msg = new RallyReqInfo();
            break;
        case MsgType.RALLY_LIST_ACK:
            msg = new RallyListInfo();
            break;
        case MsgType.DISMISS_TROOP_REQ:
            msg = new DismissTroopInfo();
            break;
        case MsgType.RALLY_COMPLETE_NTF:
            msg = new RallyCompleteInfo();
            break;
        case MsgType.RENAME_REQ:
            msg = new RenameReqInfo();
            break;
        case MsgType.USER_ITEMS_NTF:
            msg = new UserItems();
            break;
        case MsgType.BUY_ITEM_REQ:
            msg = new BuyItemInfo();
            break;
        case MsgType.USE_ITEM_REQ:
            msg = new UseItemInfo();
            break;
        case MsgType.SPEEDUP_REQ:
            msg = new SpeedupInfo();
            break;
        case MsgType.TROOP_TRAIN_CANCEL_REQ:
            msg = new TroopTrainCancelInfo();
            break;
        case MsgType.MARCH_RECALL_REQ:
            msg = new MarchRecallInfo();
            break;
        case MsgType.USE_FLARE_REQ:
            msg = new TilePos();
            break;
        case MsgType.BUFF_LIST_NTF:
            msg = new BuffListNtfInfo();
            break;
        case MsgType.BUFF_NTF:
            msg = new BuffNtfInfo();
            break;
        case MsgType.GET_DAILY_QUEST_LIST_REQ:
            msg = new GetDailyQuestListReqInfo();
            break;
        case MsgType.GET_DAILY_QUEST_LIST_ACK:
            msg = new GetDailyQuestListAckInfo();
            break;
        case MsgType.BEGIN_DAILY_QUEST_REQ:
            msg = new BeginDailyQuestReqInfo();
            break;
        case MsgType.BEGIN_DAILY_QUEST_ACK:
            msg = new BeginDailyQuestAckInfo();
            break;
        case MsgType.GET_DAILY_QUEST_REWARD_REQ:
            msg = new GetDailyQuestRewardReqInfo();
            break;
        case MsgType.GET_DAILY_QUEST_REWARD_ACK:
            msg = new GetDailyQuestRewardAckInfo();
            break;
        case MsgType.QUEST_LIST_REQ:
            msg = new QuestListReqInfo();
            break;
        case MsgType.QUEST_LIST_ACK:
            msg = new QuestListAckInfo();
            break;
        case MsgType.QUEST_COMPLETE_NTF:
            msg = new QuestCompleteNtfInfo();
            break;
        case MsgType.QUEST_GET_REWARD_REQ:
            msg = new QuestGetRewardReqInfo();
            break;
        case MsgType.QUEST_GET_REWARD_ACK:
            msg = new QuestGetRewardAckInfo();
            break;
        case MsgType.POWER_RANKLIST_REQ:
            msg = new PowerRanklistReq();
            break;
        case MsgType.POWER_RANKLIST_ACK:
            msg = new PowerRanklistAck();
            break;
        case MsgType.POWER_RANKINFO_ACK:
            msg = new PowerRanklistAck();
            break;
        case MsgType.POWER_UPDATE_NTF:
            msg = new PowerUpdateInfo();
            break;
        case MsgType.ALLIANCE_HELP_REQ:
            msg = new AllianceHelpReq();
            break;
        case MsgType.ALLIANCE_HELP_NTF:
            msg = new AllianceHelpInfo();
            break;
        case MsgType.ALLIANCE_OFFER_HELP_REQ:
            msg = new AllianceOfferHelpInfo();
            break;
        case MsgType.ALLIANCE_OFFER_HELP_NTF:
            msg = new AllianceOfferHelpNtf();
            break;
        case MsgType.ALLIANCE_LIST_HELP_ACK:
            msg = new AllianceListHelpInfo();
            break;
        case MsgType.USER_RANKLIST_REQ:
            msg = new UserRanklistReq();
            break;
        case MsgType.USER_RANKLIST_ACK:
            msg = new UserRanklistInfo();
            break;
        case MsgType.ALLIANCE_UPDATE_HELP_NTF:
            msg = new AllianceUpdateHelpNtf();
            break;
        case MsgType.ALLIANCE_DEL_HELP_NTF:
            msg = new AllianceDelHelpNtf();
            break;
        case MsgType.REPAIR_REQ:
            msg = new RepairReqInfo();
            break;
        case MsgType.REPAIR_ACK:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.REPAIR_INFO_ACK:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.REPAIR_NTF:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.CREDIT_UPDATE_NTF:
            msg = new CreditInfo();
            break;
        case MsgType.CREDIT_INFO_ACK:
            msg = new CreditInfo();
            break;
        case MsgType.BUILDING_FREE_CHECK_REQ:
            msg = new BuildingFreeCheckReq();
            break;
        case MsgType.BUILDING_FREE_CHECK_ACK:
            msg = new BuildingFreeCheckAck();
            break;
        case MsgType.BUILDING_FREE_REQ:
            msg = new BuildingFreeReq();
            break;
        case MsgType.BUILDING_FREE_INFO_NTF:
            msg = new BuildingFreeInfoNtf();
            break;
        case MsgType.ALLIANCE_RANKLIST_REQ:
            msg = new AllianceRanklistReq();
            break;
        case MsgType.ALLIANCE_RANKLIST_ACK:
            msg = new AllianceRanklistInfo();
            break;
        case MsgType.DETAIL_RANKLIST_REQ:
            msg = new DetailRanklistReq();
            break;
        case MsgType.DETAIL_RANKLIST_ACK:
            msg = new DetailRanklistInfo();
            break;
        case MsgType.USER_RANKINFO_NTF:
            msg = new UserRankinfoNtf();
            break;
        case MsgType.BUY_RES_REQ:
            msg = new BuyResInfo();
            break;
        case MsgType.BUY_RES_ACK:
            msg = new BuyResInfo();
            break;
        case MsgType.MODIFY_GENDER_REQ:
            msg = new ModifyGenderReqInfo();
            break;
        case MsgType.MODIFY_GENDER_ACK:
            msg = new ModifyGenderAckInfo();
            break;
        case MsgType.BUY_ITEM_ACK:
            msg = new BuyItemInfo();
            break;
        case MsgType.ITEM_UPDATE_NTF:
            msg = new Item();
            break;
        case MsgType.USE_ITEM_ACK:
            msg = new UseItemInfo();
            break;
        case MsgType.RALLY_ALERT_NTF:
            msg = new RallyInfo();
            break;
        case MsgType.RALLY_DEFENCE_ALERT_NTF:
            msg = new DefenceInfo();
            break;
        case MsgType.BE_ATK_NTF:
            msg = new BeAtkListInfo();
            break;
        case MsgType.BE_SCOUT_NTF:
            msg = new BeScoutListInfo();
            break;
        case MsgType.BE_REINFORCE_NTF:
            msg = new BeReinforceListInfo();
            break;
        case MsgType.EMBASSY_INFO_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.EMBASSY_INFO_ACK:
            msg = new EmbassyInfo();
            break;
        case MsgType.KICK_ALLIANCE_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.CHANGE_ALLIANCE_OWNER_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.CLIENT_SAVE_REQ:
            msg = new ClientSaveInfo();
            break;
        case MsgType.CLIENT_LOAD_ACK:
            msg = new ClientSaveInfo();
            break;
        case MsgType.RELOCATE_CITY_NTF:
            msg = new RelocateNtfInfo();
            break;
        case MsgType.GUEST_GRID_VIEW_REQ:
            msg = new ServerGridPos();
            break;
        case MsgType.GUEST_GRID_INFO_NTF:
            msg = new ServerGridInfo();
            break;
        case MsgType.AWESOME_RELOCATE_CITY_REQ:
            msg = new AwesomeRelocateCityInfo();
            break;
        case MsgType.ALLIANCE_MOD_RANK_REQ:
            msg = new AllianceModRankInfo();
            break;
        case MsgType.ALLIANCE_MOD_RANK_NTF:
            msg = new AllianceModRankNtf();
            break;
        case MsgType.UPDATE_ALLIANCE_BRIEF_NTF:
            msg = new UpdateAllianceBriefInfo();
            break;
        case MsgType.CHANGE_ALLIANCE_INFO_REQ:
            msg = new ChangeAllianceInfoReqInfo();
            break;
        case MsgType.ALLIANCE_INVITE_SUGGEST_LIST_ACK:
            msg = new SearchUsersInfo();
            break;
        case MsgType.CHANGE_ALLIANCE_OWNER_NTF:
            msg = new ChangeAllianceOwnerNtfInfo();
            break;
        case MsgType.ALLIANCE_INVITE_REQ:
            msg = new AllianceInviteInfo();
            break;
        case MsgType.ALLIANCE_INVITE_NTF:
            msg = new AllianceInviteNtfInfo();
            break;
        case MsgType.REVOKE_ALLIANCE_INVITE_REQ:
            msg = new RevokeAllianceInviteInfo();
            break;
        case MsgType.LIST_ALLIANCE_INVITE_ACK:
            msg = new ListAllianceInviteInfo();
            break;
        case MsgType.ALLIANCE_INVITE_CONFIRM_REQ:
            msg = new AllianceInviteConfirmInfo();
            break;
        case MsgType.ALLIANCE_RES_LIST_ACK:
            msg = new AllianceResInfo();
            break;
        case MsgType.ALLIANCE_RES_DISPATCH_REQ:
            msg = new AllianceResDispatchInfo();
            break;
        case MsgType.ALLIANCE_RES_UPDATE_NTF:
            msg = new AllianceResInfo();
            break;
        case MsgType.ALLIANCE_RES_HISTORY_ACK:
            msg = new AllianceResHistoryInfo();
            break;
        case MsgType.LIST_INVITE_ACK:
            msg = new ListInviteInfo();
            break;
        case MsgType.ALLIANCE_DROP_DOMINION_REQ:
            msg = new TilePos();
            break;
        case MsgType.ALLIANCE_RES_APPLY_REQ:
            msg = new AllianceResApplyReq();
            break;
        case MsgType.LIST_ALLIANCE_RES_APPLY_ACK:
            msg = new ListAllianceResApplyInfo();
            break;
        case MsgType.MANAGE_ALLIANCE_RES_APPLY_REQ:
            msg = new ManageAllianceResApplyInfo();
            break;
        case MsgType.ALLIANCE_RES_APPLY_RESULT_NTF:
            msg = new AllianceResApplyResultInfo();
            break;
        case MsgType.ALLIANCE_RES_APPLY_NTF:
            msg = new AllianceResApplyInfo();
            break;
        case MsgType.LIST_ALLIANCE_DOMINION_REQ:
            msg = new ListAllianceDominionReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_DOMINION_ACK:
            msg = new ListAllianceDominionInfo();
            break;
        case MsgType.ACCOUNT_BIND_REQ:
            msg = new AccountBindInfo();
            break;
        case MsgType.GET_SERVER_LIST_ACK:
            msg = new ServerListInfo();
            break;
        case MsgType.LIST_DOMINION_MAP_REQ:
            msg = new DominionMapReq();
            break;
        case MsgType.LIST_DOMINION_MAP_NTF:
            msg = new ListDominionMapInfo();
            break;
        case MsgType.CONST_REQ:
            msg = new ConstReq();
            break;
        case MsgType.CONST_ACK:
            msg = new ConstInfo();
            break;
        case MsgType.SEARCH_NAME_REQ:
            msg = new SearchNameReq();
            break;
        case MsgType.SEARCH_NAME_ACK:
            msg = new SearchNameInfo();
            break;
        case MsgType.RANDOM_TELEPORT_NTF:
            msg = new ServerTilePos();
            break;
        case MsgType.LIST_ALLIANCE_COMMENT_REQ:
            msg = new ListAllianceCommentReq();
            break;
        case MsgType.LIST_ALLIANCE_COMMENT_ACK:
            msg = new ListAllianceCommentInfo();
            break;
        case MsgType.POST_ALLIANCE_COMMENT_REQ:
            msg = new PostAllianceCommentInfo();
            break;
        case MsgType.APPLY_JOIN_ALLIANCE_REQ:
            msg = new ApplyJoinAllianceReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_JOIN_APPLY_ACK:
            msg = new ListAllianceJoinApplyInfo();
            break;
        case MsgType.MANAGE_ALLIANCE_JOIN_APPLY_REQ:
            msg = new ManageAllianceJoinApplyInfo();
            break;
        case MsgType.ALLIANCE_JOIN_APPLY_NTF:
            msg = new AllianceJoinApplyInfo();
            break;
        case MsgType.LIST_ALLIANCE_AUTHORITY_REQ:
            msg = new ListAllianceAuthorityReq();
            break;
        case MsgType.LIST_ALLIANCE_AUTHORITY_ACK:
            msg = new ListAllianceAuthorityInfo();
            break;
        case MsgType.UPDATE_ALLIANCE_AUTHORITY_REQ:
            msg = new UpdateAllianceAuthorityInfo();
            break;
        case MsgType.MANAGE_ALLIANCE_RECRUITMENT_REQ:
            msg = new ManageAllianceRecruitmentInfo();
            break;
        case MsgType.UPDATE_ALLIANCE_MEMBER_TITLE_REQ:
            msg = new UpdateAllianceMemberTitleInfo();
            break;
        case MsgType.JOIN_ALLIANCE_ACK:
            msg = new AllianceAckInfo();
            break;
        case MsgType.SEARCH_USERS_REQ:
            msg = new SearchUsersReq();
            break;
        case MsgType.SEARCH_USERS_ACK:
            msg = new SearchUsersInfo();
            break;
        case MsgType.UPDATE_ALLIANCE_AUTHORITY_NTF:
            msg = new UpdateAllianceAuthorityInfo();
            break;
        case MsgType.AWESOME_RELOCATE_ACK:
            msg = new AwesomeRelocateInfo();
            break;
        case MsgType.SEARCH_ALLIANCE_REQ:
            msg = new SearchAllianceReq();
            break;
        case MsgType.SEARCH_ALLIANCE_ACK:
            msg = new SearchAllianceInfo();
            break;
        case MsgType.DISMISS_ALLIANCE_NTF:
            msg = new DismissAllianceInfo();
            break;
        case MsgType.DEL_ALLIANCE_JOIN_APPLY_NTF:
            msg = new DelAllianceJoinApplyInfo();
            break;
        case MsgType.LIST_ALLIANCE_GIFT_REQ:
            msg = new ListAllianceGiftReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_GIFT_ACK:
            msg = new ListAllianceGiftInfo();
            break;
        case MsgType.OPEN_ALLIANCE_GIFT_REQ:
            msg = new OpenAllianceGiftInfo();
            break;
        case MsgType.OPEN_ALLIANCE_GIFT_ACK:
            msg = new OpenAllianceGiftAckInfo();
            break;
        case MsgType.RECEIVE_ALLIANCE_GIFT_NTF:
            msg = new AllianceGiftInfo();
            break;
        case MsgType.IAP_FINISH_REQ:
            msg = new IapFinishInfo();
            break;
        case MsgType.IAP_FINISH_RSP:
            msg = new IapFinishRsp();
            break;
        case MsgType.IAP_PREPARE_REQ:
            msg = new IapPrepareReq();
            break;
        case MsgType.IAP_PREPARE_RSP:
            msg = new IapPrepareRsp();
            break;
        case MsgType.IAP_LIST_REQ:
            msg = new IapListReq();
            break;
        case MsgType.IAP_LIST_RSP:
            msg = new IapListInfo();
            break;
        case MsgType.ALLIANCE_GIFT_LEVEL_NTF:
            msg = new AllianceGiftLevelInfo();
            break;
        case MsgType.RALLY_DEFENCE_ACK:
            msg = new DefenceListInfo();
            break;
        case MsgType.NEW_MAPMARK_REQ:
            msg = new NewMapmarkInfo();
            break;
        case MsgType.DEL_MAPMARK_REQ:
            msg = new MapmarkIdInfo();
            break;
        case MsgType.MAPMARK_LIST_NTF:
            msg = new MapmarkListInfo();
            break;
        case MsgType.UPDATE_PUSH_INFO_REQ:
            msg = new UpdatePushInfo();
            break;
        case MsgType.BIND_REQ:
            msg = new BindInfo();
            break;
        case MsgType.USER_STATISTICS_REQ:
            msg = new UserStatisticsReqInfo();
            break;
        case MsgType.USER_STATISTICS_ACK:
            msg = new UserStatisticsAckInfo();
            break;
        case MsgType.CLIENT_DATA_SAVE_REQ:
            msg = new ClientDataInfo();
            break;
        case MsgType.CLIENT_DATA_LOAD_REQ:
            msg = new ClientDataKey();
            break;
        case MsgType.CLIENT_DATA_LOAD_ACK:
            msg = new ClientDataInfo();
            break;
        case MsgType.SILENT_NTF:
            msg = new SilentInfo();
            break;
        case MsgType.SETTING_REQ:
            msg = new SettingInfo();
            break;
        case MsgType.GET_SETTING_ACK:
            msg = new SettingInfo();
            break;
        case MsgType.USER_INFO_NTF:
            msg = new UserInfo();
            break;
        case MsgType.FTE_REQ:
            msg = new FteInfo();
            break;
        case MsgType.SCREEN_REFRESH_ACK:
            msg = new ScreenRefreshInfo();
            break;
        case MsgType.DEL_ALLIANCE_RES_APPLY_NTF:
            msg = new AllianceResApplyInfo();
            break;
        case MsgType.CHECK_USER_CAN_GIFT_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.NEW_USER_GIFT_NTF:
            msg = new NewUserGiftInfo();
            break;
        case MsgType.MENTOR_LIST_NTF:
            msg = new MentorListInfo();
            break;
        case MsgType.BIDDING_ALLIANCE_RECRUIT_REQ:
            msg = new BiddingAllianceRecruitReqInfo();
            break;
        case MsgType.ALLIANCE_RECRUIT_REQ:
            msg = new AllianceRecruitReqInfo();
            break;
        case MsgType.ALLIANCE_RECRUIT_ACK:
            msg = new AllianceRecruitInfo();
            break;
        case MsgType.ALLIANCE_RECRUIT_NTF:
            msg = new AllianceRecruitInfo();
            break;
        case MsgType.RECRUIT_WALL_REQ:
            msg = new RecruitWallReqInfo();
            break;
        case MsgType.RECRUIT_WALL_ACK:
            msg = new RecruitWallListInfo();
            break;
        case MsgType.REGION_MSG_REQ:
            msg = new RegionMsgReqInfo();
            break;
        case MsgType.REGION_MSG_LIST_REQ:
            msg = new RegionMsgListReqInfo();
            break;
        case MsgType.REGION_MSG_LIST_ACK:
            msg = new RegionMsgListInfo();
            break;
        case MsgType.ALLIANCE_COMMENT_NTF:
            msg = new AllianceCommentInfo();
            break;
        case MsgType.LAST_ALLIANCE_COMMENT_REQ:
            msg = new ListAllianceCommentReq();
            break;
        case MsgType.LAST_ALLIANCE_COMMENT_ACK:
            msg = new LastAllianceCommentInfoList();
            break;
        case MsgType.ALLIANCE_DOMINION_CHARACTER_REQ:
            msg = new AllianceDominionCharacterReqInfo();
            break;
        case MsgType.LIST_USER_DOMINION_REQ:
            msg = new ListUserDominionReqInfo();
            break;
        case MsgType.LIST_USER_DOMINION_ACK:
            msg = new ListUserDominionInfo();
            break;
        case MsgType.MONUMENT_NOTE_REQ:
            msg = new ChangeMonumentNoteInfo();
            break;
        case MsgType.MONUMENT_REQ:
            msg = new MonumentReqInfo();
            break;
        case MsgType.MONUMENT_ACK:
            msg = new MonumentDetailInfo();
            break;
        case MsgType.CANCEL_PUSH_REQ:
            msg = new CancelPushInfo();
            break;
        case MsgType.DAILY_EVENT_ACK:
            msg = new DailyEventInfo();
            break;
        case MsgType.DAILY_EVENT_UPDATE_NTF:
            msg = new DailyEventUpdateNtf();
            break;
        case MsgType.DAILY_EVENT_ACTION_REQ:
            msg = new DailyEventActionReq();
            break;
        case MsgType.GET_INVITATION_ACK:
            msg = new GetInvitationAckInfo();
            break;
        case MsgType.USE_INVITATION_REQ:
            msg = new UseInvitationReqInfo();
            break;
        case MsgType.INVITATION_INFO_NTF:
            msg = new InvitationInfo();
            break;
        case MsgType.INVITATION_MODE_NTF:
            msg = new InvitationModeInfo();
            break;
        case MsgType.INVITATION_REWARD_LIST_NTF:
            msg = new InvitationRewardListInfo();
            break;
        case MsgType.GOVERNMENT_REQ:
            msg = new GovernmentReqInfo();
            break;
        case MsgType.GOVERNMENT_ACK:
            msg = new GovernmentInfo();
            break;
        case MsgType.NEW_PRIZE_NTF:
            msg = new PrizeInfo();
            break;
        case MsgType.GET_PRIZE_LIST_REQ:
            msg = new GetPrizeListReqInfo();
            break;
        case MsgType.GET_PRIZE_LIST_ACK:
            msg = new PrizeListInfo();
            break;
        case MsgType.GET_PRIZE_REQ:
            msg = new GetPrizeInfo();
            break;
        case MsgType.BIND_DIAMOND_MINE_REQ:
            msg = new BindDiamondMineInfo();
            break;
        case MsgType.DIAMOND_MINE_FRIEND_REQ:
            msg = new DiamondMineFriendReq();
            break;
        case MsgType.DIAMOND_MINE_FRIEND_ACK:
            msg = new DiamondMineFriendInfo();
            break;
        case MsgType.DONATE_DIAMOND_REQ:
            msg = new DonateDiamondInfo();
            break;
        case MsgType.DIAMOND_MINE_BIND_INFO_ACK:
            msg = new BindDiamondMineInfo();
            break;
        case MsgType.TRANSLATE_REQ:
            msg = new TranslateInfo();
            break;
        case MsgType.BUNDLE_USER_INFO_REQ:
            msg = new BundleUserReqInfo();
            break;
        case MsgType.BUNDLE_USER_INFO_ACK:
            msg = new BundleUserAckInfo();
            break;
        case MsgType.LIST_ALLIANCE_GIFT_NTF:
            msg = new ListAllianceGiftInfo();
            break;
        case MsgType.USER_SHIELD_NTF:
            msg = new UserShieldInfo();
            break;
        case MsgType.ALLIANCE_HIVE_POS_NTF:
            msg = new AllianceHivePosInfo();
            break;
        case MsgType.ZONE_BRIEF_REQ:
            msg = new ZoneBriefReqInfo();
            break;
        case MsgType.ZONE_BRIEF_ACK:
            msg = new ZoneBriefInfo();
            break;
        case MsgType.LIST_ALLIANCE_BRIEF_REQ:
            msg = new ListAllianceBriefReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_BRIEF_ACK:
            msg = new ListAllianceBriefInfo();
            break;
        case MsgType.ALLIANCE_SALARY_LIST_ACK:
            msg = new AllianceSalaryListInfo();
            break;
        case MsgType.ALLIANCE_SALARY_HISTORY_ACK:
            msg = new AllianceSalaryHistoryInfo();
            break;
        case MsgType.ALLIANCE_SET_SALARY_REQ:
            msg = new AllianceSetSalaryInfo();
            break;
        case MsgType.ALLIANCE_SALARY_LIST_NTF:
            msg = new AllianceSalaryListInfo();
            break;
        case MsgType.DONATE_DIAMOND_ACK:
            msg = new DonateDiamondAckInfo();
            break;
        case MsgType.USE_OUTSOURCE_REQ:
            msg = new UseOutsourceInfo();
            break;
        case MsgType.GET_DAILY_EVENT_REWARD_REQ:
            msg = new GetDailyEventRewardReq();
            break;
        case MsgType.GET_DAILY_EVENT_REWARD_ACK:
            msg = new GetDailyEventRewardAckInfo();
            break;
        case MsgType.REPAIR_TROOP_NTF:
            msg = new RepairTroopInfo();
            break;
        case MsgType.OFFLINE_DATA_NTF:
            msg = new OfflineDataInfo();
            break;
        case MsgType.REGION_INFO_ACK:
            msg = new RegionInfo();
            break;
        case MsgType.ACCOUNT_CREATE_REQ:
            msg = new AccountCreateInfo();
            break;
        case MsgType.ACCOUNT_FIND_PASSWORD_REQ:
            msg = new AccountFindPasswordInfo();
            break;
        case MsgType.ACCOUNT_CREATE_CHECK_REQ:
            msg = new AccountCreateCheckReqInfo();
            break;
        case MsgType.IAP_PRICE_REQ:
            msg = new IapPriceReqInfo();
            break;
        case MsgType.IAP_PRICE_ACK:
            msg = new IapPriceAckInfo();
            break;
        case MsgType.IAP_LIST_BY_TYPE_REQ:
            msg = new IapListByTypeInfo();
            break;
        case MsgType.IAP_UNFINISH_ORDER_LIST_REQ:
            msg = new IapUnfinishOrderListReq();
            break;
        case MsgType.IAP_UNFINISH_ORDER_LIST_ACK:
            msg = new IapUnfinishOrderListInfo();
            break;
        case MsgType.GET_ROLE_LIST_REQ:
            msg = new GetRoleListReqInfo();
            break;
        case MsgType.GET_ROLE_LIST_ACK:
            msg = new GetRoleListInfo();
            break;
        case MsgType.RESOLVE_OFFICER_NTF:
            msg = new ResolveOfficerInfo();
            break;
        case MsgType.OPEN_MATERIALBOX_NTF:
            msg = new OpenMaterialboxInfo();
            break;
        case MsgType.ACTIVE_RECORD_REQ:
            msg = new ActiveRecordInfo();
            break;
        case MsgType.GET_GUEST_ROLE_LIST_REQ:
            msg = new GetGuestRoleListReqInfo();
            break;
        case MsgType.GET_GUEST_ROLE_LIST_ACK:
            msg = new GetRoleListInfo();
            break;
        case MsgType.VOICECHAT_MODE_NTF:
            msg = new VoicechatModeInfo();
            break;
        case MsgType.NEW_ANNOUCE_NTF:
            msg = new AnnouceInfo();
            break;
        case MsgType.USER_ANNOUCE_LIST_NTF:
            msg = new AnnouceListInfo();
            break;
        case MsgType.SET_GOVERNMENT_FLAG_REQ:
            msg = new SetGovernmentFlagInfo();
            break;
        case MsgType.SIGNATURE_REQ:
            msg = new SignatureReqInfo();
            break;
        case MsgType.LIKE_REQ:
            msg = new LikeReqInfo();
            break;
        case MsgType.UNLIKE_REQ:
            msg = new LikeReqInfo();
            break;
        case MsgType.ITEM_LIST_UPDATE_NTF:
            msg = new UserItems();
            break;
        case MsgType.RES_TRANSLATE_STANDARD_FILE:
            msg = new TranslateStandardFileInfo();
            break;
        case MsgType.IS_ALLIANCE_OPEN_REQ:
            msg = new AllianceReqInfo();
            break;
        case MsgType.CONFIG_TO_CLIENT_NTF:
            msg = new ConfigToClientInfo();
            break;
        case MsgType.CREATE_ALLIANCE_RES_ACK:
            msg = new CreateAllianceResInfo();
            break;
        case MsgType.USER_PVE_INFO_ACK:
            msg = new PveInfo();
            break;
        case MsgType.USER_PVE_NTF:
            msg = new PveInfo();
            break;
        case MsgType.ALLIANCE_DONATE_HISTORY_ACK:
            msg = new AllianceDonateInfoList();
            break;
        case MsgType.ALLIANCE_LEVEL_INFO_ACK:
            msg = new AllianceLevelInfo();
            break;
        case MsgType.WAR_LICENSE_NTF:
            msg = new WarLicenseInfo();
            break;
        case MsgType.ITEM_FUSION_NTF:
            msg = new ItemFusionInfo();
            break;
        case MsgType.SELECT_AVATAR_REQ:
            msg = new SelectAvatarInfo();
            break;
        case MsgType.GET_LIKE_LIST_ACK:
            msg = new LikeList();
            break;
        case MsgType.ALLIANCE_DONATE_REQ:
            msg = new AllianceDonate();
            break;
        case MsgType.ALLIANCE_DONATE_ACK:
            msg = new AllianceDonateRewards();
            break;
        case MsgType.CLEAR_GUEST_GRID_VIEW_REQ:
            msg = new ServerGridPos();
            break;
        case MsgType.GET_SPECIAL_QUEST_REWARD_REQ:
            msg = new SpecialQuestRewardReq();
            break;
        case MsgType.GET_SPECIAL_QUEST_REWARD_ACK:
            msg = new SpecialQuestRewardInfo();
            break;
        case MsgType.LANG_LIKE_RANK_REQ:
            msg = new LangLikeRankReq();
            break;
        case MsgType.LANG_LIKE_RANK_ACK:
            msg = new LangLikeRankMemberList();
            break;
        case MsgType.GET_ORDER_FROM_SDK_REQ:
            msg = new GetOrderFromSdkInfo();
            break;
        case MsgType.GET_ORDER_FROM_SDK_ACK:
            msg = new ResOrderInfo();
            break;
        case MsgType.ALLIANCE_EXCHANGE_INFO_ACK:
            msg = new AllianceExchangeInfo();
            break;
        case MsgType.ALLIANCE_EXCHANGE_INFO_NTF:
            msg = new AllianceExchangeInfo();
            break;
        case MsgType.EXCHANGE_RESEARCH_POINT_REQ:
            msg = new ExchangeResearchPointInfo();
            break;
        case MsgType.ALLIANCE_SET_SUGGESTED_REQ:
            msg = new AllianceSetSuggestedReqInfo();
            break;
        case MsgType.GET_ALLIANCE_RESEARCH_LIST_REQ:
            msg = new GetAllianceResearchListReqInfo();
            break;
        case MsgType.GET_ALLIANCE_RESEARCH_LIST_ACK:
            msg = new GetAllianceResearchListAckInfo();
            break;
        case MsgType.GET_ALLIANCE_RESEARCH_REQ:
            msg = new GetAllianceResearchReqInfo();
            break;
        case MsgType.GET_ALLIANCE_RESEARCH_ACK:
            msg = new GetAllianceResearchAckInfo();
            break;
        case MsgType.UPGRADE_ALLIANCE_RESEARCH_REQ:
            msg = new UpgradeAllianceResearchReqInfo();
            break;
        case MsgType.UPGRADE_ALLIANCE_RESEARCH_ACK:
            msg = new UpgradeAllianceResearchAckInfo();
            break;
        case MsgType.UPGRADE_ALLIANCE_RESEARCH_NTF:
            msg = new UpgradeAllianceResearchNtfInfo();
            break;
        case MsgType.ALLIANCE_RESEARCH_COMPLETE_NTF:
            msg = new AllianceResearchBaseInfo();
            break;
        case MsgType.ALLIANCE_RESEARCH_CHANGE_NTF:
            msg = new AllianceResearchBaseInfo();
            break;
        case MsgType.USER_EXTRA_NTF:
            msg = new UserExtraInfo();
            break;
        case MsgType.ALLIANCE_RESEARCH_DONATE_RANK_LIST_REQ:
            msg = new AllianceResearchDonateRankListReqInfo();
            break;
        case MsgType.ALLIANCE_RESEARCH_DONATE_RANK_LIST_ACK:
            msg = new AllianceResearchDonateRankList();
            break;
        case MsgType.FB_SHOW_INVITE_SIGN_NTF:
            msg = new FbShowInviteSignInfo();
            break;
        case MsgType.UNBIND_DIAMOND_MINE_ACK:
            msg = new UnbindDiamondMineAckInfo();
            break;
        case MsgType.VERIFY_FAKE_USER_NTF:
            msg = new VerifyFakeUserInfo();
            break;
        case MsgType.RECORD_VERIFY_FAKE_REQ:
            msg = new RecordVerifyFakeInfo();
            break;
        case MsgType.EXCHANGE_RESEARCH_POINT_ACK:
            msg = new ExchangeResearchPointInfoAckInfo();
            break;
        case MsgType.GET_ALLIANCE_RESEARCH_BUILDING_ACK:
            msg = new AllianceResearchBuilding();
            break;
        case MsgType.COMPRESSED_NTF:
            msg = new CompressedInfo();
            break;
        case MsgType.MAIL_PREREAD_SWITCH_NTF:
            msg = new MailPrereadSwitchInfo();
            break;
        case MsgType.FIRST_PAY_REWARD_NTF:
            msg = new FirstPayRewardInfo();
            break;
        case MsgType.BUILD_UPDATE_NTF:
            msg = new BuildingInfo();
            break;
        case MsgType.KRELOCATING_NTF:
            msg = new KrelocatingNtfInfo();
            break;
        case MsgType.GUEST_REGION_LOGIN_REQ:
            msg = new GuestRegionLoginInfo();
            break;
        case MsgType.GUEST_MONUMENT_REQ:
            msg = new RegionMonumentReqInfo();
            break;
        case MsgType.GUEST_USER_INFO_REQ:
            msg = new RegionUserReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_DOMINION_CNT_REQ:
            msg = new ListAllianceDominionReqInfo();
            break;
        case MsgType.LIST_ALLIANCE_DOMINION_CNT_ACK:
            msg = new ListAllianceDominionCntInfo();
            break;
        case MsgType.ALLIANCE_MOD_TITLE_NTF:
            msg = new AllianceModTitleNtf();
            break;
        case MsgType.NEW_OFFICER_NTF:
            msg = new OfficerInfo();
            break;
        case MsgType.GET_COME_BACK_REWARD_STATUS_ACK:
            msg = new ComeBackRewardStatusInfo();
            break;
        case MsgType.GET_COME_BACK_REWARDS_ACK:
            msg = new ComeBackRewardsInfo();
            break;
        case MsgType.DO_COME_BACK_REWARDS_REQ:
            msg = new DoComeBackRewardsDetail();
            break;
        case MsgType.DO_COME_BACK_REWARDS_ACK:
            msg = new DoRewardsDetailInfo();
            break;
        case MsgType.AWESOME_REGION_RELOCATE_CITY_REQ:
            msg = new AwesomeRelocateCityInfo();
            break;
        case MsgType.USER_ACCOUNT_INFO_ACK:
            msg = new UserAccountInfo();
            break;
        case MsgType.SET_USER_NATIONAL_FLAG_REQ:
            msg = new UserNationalFlagInfo();
            break;
        case MsgType.USER_NATIONAL_FLAG_ACK:
            msg = new UserNationalFlagInfo();
            break;
        case MsgType.ALLIANCE_HIVE_POS_ACK:
            msg = new AllianceHivePosInfo();
            break;
        case MsgType.FB_LOGIN_SHOW_REWARD_ACK:
            msg = new FbLoginShowRewardInfo();
            break;
        case MsgType.FB_LOGIN_REWARD_NTF:
            msg = new FbLoginShowRewardInfo();
            break;
        case MsgType.REGION_USER_STATISTICS_REQ:
            msg = new RegionUserStatisticsReqInfo();
            break;
        case MsgType.REGION_VIEW_HERO_REQ:
            msg = new RegionViewHeroReqInfo();
            break;
        case MsgType.CLIENT_CONFIG_NTF:
            msg = new ClientConfigInfo();
            break;
        case MsgType.ACHIEVEMENT_NTF:
            msg = new AchievementNode();
            break;
        case MsgType.ACHIEVEMENT_INFO_REQ:
            msg = new AchievementReqInfo();
            break;
        case MsgType.ACHIEVEMENT_INFO_ACK:
            msg = new AchievementInfo();
            break;
        case MsgType.GET_ACHIEVEMENT_REWARD_REQ:
            msg = new GetAchievementRewardReqInfo();
            break;
        case MsgType.FLAG_RANK_INFO_ACK:
            msg = new FlagsRankInfo();
            break;
        case MsgType.SHARE_FLAG_RANK_INFO_ACK:
            msg = new ShareFlagRankInfo();
            break;
        case MsgType.YYB_SYNC_USER_BALANCE_REQ:
            msg = new YybSyncUserBalanceInfo();
            break;
        case MsgType.PRIZE_CMD_REQ:
            msg = new CenterCmdReq();
            break;
        case MsgType.SWITCH_NTF:
            msg = new SwitchInfo();
            break;
        case MsgType.ISTANA_DECLARE_WAR_REQ:
            msg = new IstanaDeclareWarReqInfo();
            break;
        case MsgType.ISTANA_DECLARE_WAR_ACK:
            msg = new IstanaDeclareWarAckInfo();
            break;
        case MsgType.ISTANA_DECLARE_NTF:
            msg = new IstanaDeclareWarAckInfo();
            break;
        case MsgType.ISTANA_NATION_ACK:
            msg = new IstanaNationAckInfo();
            break;
        case MsgType.ISTANA_TITLE_CHANGE_REQ:
            msg = new IstanaTitleChangeInfo();
            break;
        case MsgType.ISTANA_TITLE_ACK:
            msg = new IstanaTitleInfo();
            break;
        case MsgType.ISTANA_BASE_ACK:
            msg = new IstanaBaseAckInfo();
            break;
        case MsgType.ISTANA_REGION_OWNER_ACK:
            msg = new IstanaRegionOwnerAckInfo();
            break;
        case MsgType.GET_ISTANA_NATION_REQ:
            msg = new GetIstanaNationReqInfo();
            break;
        case MsgType.GET_ISTANA_NATION_ACK:
            msg = new IstanaServerInfo();
            break;
        case MsgType.GUEST_ISTANA_REGION_OWNER_REQ:
            msg = new GuestIstanaRegionOwnerReqInfo();
            break;
        case MsgType.GUEST_ISTANA_BASE_REQ:
            msg = new GuestIstanaBaseReqInfo();
            break;
        case MsgType.GUEST_ISTANA_NATION_REQ:
            msg = new GuestIstanaNationReqInfo();
            break;
        case MsgType.ALLIANCE_ISTANA_SNAP_NTF:
            msg = new AllianceIstanaSnap();
            break;
        case MsgType.GUEST_GET_ISTANA_NATION_REQ:
            msg = new GuestGetIstanaNationReqInfo();
            break;
        case MsgType.PUSH_OPENAPP_STAT_REQ:
            msg = new PushOpenappStatInfo();
            break;
        case MsgType.MARCH_LIST_NTF:
            msg = new MarchListNtfInfo();
            break;
        case MsgType.MONTHLY_BOOK_STATUS_ACK:
            msg = new MonthlyBookStatus();
            break;
        case MsgType.MONTHLY_BOOK_SUCCESS_NTF:
            msg = new MonthlyBookSuccessStatus();
            break;
        case MsgType.REGION_SERVER_LIST_ACK:
            msg = new RegionServerListInfo();
            break;
        case MsgType.CLIENT_CLICK_RECORD_REQ:
            msg = new ClientClickRecordInfo();
            break;
        case MsgType.COMPRESSED_REQ:
            msg = new CompressedReqInfo();
            break;
        case MsgType.GET_CHARGE_SIGN_IN_DATAIL_ACK:
            msg = new ChargeSignInDatailInfo();
            break;
        case MsgType.GET_CHARGE_SIGN_REWARD_REQ:
            msg = new ChargeSignRewardInfo();
            break;
        case MsgType.GET_CHARGE_SIGN_REWARD_ACK:
            msg = new RewardDetailStatus();
            break;
        case MsgType.GET_SEVENDAY_TASK_INFO_REQ:
            msg = new SevendayTaskId();
            break;
        case MsgType.GET_SEVENDAY_TASK_INFO_ACK:
            msg = new SevendayTaskInfo();
            break;
        case MsgType.GET_SEVENDAY_REWARD_REQ:
            msg = new GetSevendayRewardReqInfo();
            break;
        case MsgType.OFFICER_PROMOTE_REQ:
            msg = new OfficerId();
            break;
        case MsgType.GROW_REBEL_NTF:
            msg = new GrowRebelInfo();
            break;
        case MsgType.GROW_REBEL_REWARD_REQ:
            msg = new GrowRebelReqInfo();
            break;
        case MsgType.FPS_INFO_REQ:
            msg = new FpsLevelInfo();
            break;
        case MsgType.FPS_INFO_ACK:
            msg = new FpsInfo();
            break;
        case MsgType.FPS_START_BATTLE_REQ:
            msg = new FpsLevelInfo();
            break;
        case MsgType.FPS_START_BATTLE_ACK:
            msg = new FpsStartBattleAckInfo();
            break;
        case MsgType.FPS_CHG_BATTLE_STATUS_REQ:
            msg = new FpsStatus();
            break;
        case MsgType.FPS_END_BATTLE_REQ:
            msg = new FpsEndBattleReqInfo();
            break;
        case MsgType.FPS_END_BATTLE_ACK:
            msg = new FpsEndBattleAckInfo();
            break;
        case MsgType.FPS_GET_REWARD_REQ:
            msg = new FpsLevelInfo();
            break;
        case MsgType.GLORY_WALLS_REQ:
            msg = new GloryWallsReqInfo();
            break;
        case MsgType.GLORY_WALLS_ACK:
            msg = new GloryWallsInfo();
            break;
        case MsgType.IDCARD_VERIFY_REQ:
            msg = new IdcardVerifyReqInfo();
            break;
        case MsgType.ANTI_ADICTION_NTF:
            msg = new AntiAdictionInfo();
            break;
        case MsgType.LINK_PHONE_NUMBER_REQ:
            msg = new LinkPhoneNumberReqInfo();
            break;
        case MsgType.VERIFY_PHONE_CODE_REQ:
            msg = new VerifyPhoneCodeReqInfo();
            break;
        case MsgType.LINK_PHONE_ACK:
            msg = new LinkPhoneAckInfo();
            break;
        case MsgType.DIAMOND_MINE_SHARE_REQ:
            msg = new DiamondMineShareReqInfo();
            break;
        case MsgType.DIAMOND_MINE_SHARE_ACK:
            msg = new DiamondMineShareAckInfo();
            break;
        case MsgType.GROW_REBEL_SPECIAL_REWARD_REQ:
            msg = new GrowRebelReqInfo();
            break;
        case MsgType.GROW_REBEL_SPECIAL_REWARD_ACK:
            msg = new SpecialRewardsDetail();
            break;
        case MsgType.GET_DAILY_EVENT_EXP_REQ:
            msg = new DailyEventIdInfo();
            break;
        case MsgType.GET_DAILY_EVENT_EXP_ACK:
            msg = new DailyEventIdInfo();
            break;
        case MsgType.USER_FIRST_CHARGE_REWARD_ACK:
            msg = new FirstChargeRewards();
            break;
        case MsgType.PROMOTING_IAP_LIST_REQ:
            msg = new IapListReq();
            break;
        case MsgType.PROMOTING_IAP_LIST_ACK:
            msg = new IapListInfo();
            break;
        case MsgType.NEWBIE_TRIGGER_NTF:
            msg = new NewbieTriggerInfo();
            break;
        case MsgType.NEWBIE_TRIGGER_ALL_NTF:
            msg = new NewbieTriggerAllInfo();
            break;
        case MsgType.GET_DAILY_EVENT_WEEKLY_REWARD_REQ:
            msg = new WeeklyRewardInfo();
            break;
        case MsgType.GET_DAILY_EVENT_WEEKLY_REWARD_ACK:
            msg = new WeeklyActivityInfo();
            break;
        case MsgType.PVE_LEVEL_REBEL_ACK:
            msg = new PveLevelInfo();
            break;
        case MsgType.SWITCH_CONFIG_NTF:
            msg = new SwitchConfigInfo();
            break;
        case MsgType.CAPTCHA_LEVEL_VERIFY_NTF:
            msg = new CaptchaLevelVerifyInfo();
            break;
        case MsgType.CAPTCHA_REQ:
            msg = new CaptchaReqInfo();
            break;
        case MsgType.CAPTCHA_ACK:
            msg = new CaptchaAckInfo();
            break;
        case MsgType.CAPTCHA_VERIFY_REQ:
            msg = new CaptchaVerifyReqInfo();
            break;
        case MsgType.CAPTCHA_VERIFY_ACK:
            msg = new CaptchaVerifyAckInfo();
            break;
        case MsgType.IAP_POPUP_NTF:
            msg = new IapPopupNtfInfo();
            break;
        case MsgType.ITEM_DURATION_ACK:
            msg = new ItemDurationInfo();
            break;
        case MsgType.GDCFG_REQ:
            msg = new GdcfgReqInfo();
            break;
        case MsgType.GDCFG_ACK:
            msg = new GdcfgAckInfo();
            break;
        case MsgType.PENDDING_QUEST_DETAIL_ACK:
            msg = new PenddingQuestDetailInfo();
            break;
        case MsgType.FILE_UPLOAD_INFO_REQ:
            msg = new FileUploadInfo();
            break;
        case MsgType.FILE_UPLOAD_INFO_ACK:
            msg = new FileUploadAckInfo();
            break;
        case MsgType.EVENT_CALENDAR_REQ:
            msg = new EventCalendarReqInfo();
            break;
        case MsgType.EVENT_CALENDAR_ACK:
            msg = new EventCalendarAckInfo();
            break;
        case MsgType.CHECK_USER_QUESTID_REQ:
            msg = new QuestIdInfo();
            break;
        case MsgType.CHECK_USER_QUESTID_ACK:
            msg = new QuestIdInfo();
            break;
        case MsgType.COME_BACK_ROLE_LIMIT_ACK:
            msg = new ComeBackRoleLimitInfo();
            break;
        case MsgType.USER_LAST_LOGIN_TIME_NTF:
            msg = new LastLoginTime();
            break;
        case MsgType.SPEEDUP_DIAMONDS_REQ:
            msg = new SpeedupDiamondsInfo();
            break;
        case MsgType.FPS_INFO_NTF:
            msg = new FpsInfo();
            break;
        case MsgType.FPS_SWEEP_REQ:
            msg = new FpsSweepInfo();
            break;
        case MsgType.FPS_SWEEP_ACK:
            msg = new FpsSweepAckInfo();
            break;
        case MsgType.FPS_POINT_ACK:
            msg = new FpsPointInfo();
            break;
        case MsgType.FPS_POINT_NTF:
            msg = new FpsPointInfo();
            break;
        case MsgType.FPS_CHANGE_AGENT_REQ:
            msg = new FpsChangeAgentInfo();
            break;
        case MsgType.FPS_EQUIPMENT_ADDON_REQ:
            msg = new FpsEquipmentInfo();
            break;
        case MsgType.FPS_CHANGE_GUN_REQ:
            msg = new FpsChangeGunInfo();
            break;
        case MsgType.FPS_SLOT_NTF:
            msg = new FpsSlotNtfInfo();
            break;
        case MsgType.NEW_AGENT_NTF:
            msg = new NewAgentInfo();
            break;
        case MsgType.FPS_NEW_GUN_NTF:
            msg = new FpsNewGunInfo();
            break;
        case MsgType.SEVENDAY_STATUS_INFO_NTF:
            msg = new SevendayStatusInfo();
            break;
        case MsgType.FPS_EQUIPMENT_ALL_REQ:
            msg = new FpsEquipmentReqInfo();
            break;
        case MsgType.RES_LIST_REQ:
            msg = new ResListReqInfo();
            break;
        case MsgType.RES_LIST_ACK:
            msg = new ResListAckInfo();
            break;
        case MsgType.QUEST_PENDING_UPDATE_NTF:
            msg = new QuestPendingInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_START_REQ:
            msg = new FpsSpecialLevelStartReqInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_START_ACK:
            msg = new FpsSpecialLevelStartAckInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_END_REQ:
            msg = new FpsSpecialLevelEndReqInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_END_ACK:
            msg = new FpsSpecialLevelEndAckInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_DETAIL_REQ:
            msg = new FpsSpecialLevelDetailReqInfo();
            break;
        case MsgType.FPS_SPECIAL_LEVEL_DETAIL_ACK:
            msg = new FpsSpecialLevelDetailAckInfo();
            break;
        case MsgType.CLIENT_LOAD_V2_REQ:
            msg = new ClientLoadV2ReqInfo();
            break;
        case MsgType.FPS_CURRENT_GUN_NTF:
            msg = new FpsCurrentGunNtfInfo();
            break;
        case MsgType.DAILY_SIGN_REWARD_INFO_NTF:
            msg = new DailySignRewardInfo();
            break;
        case MsgType.DEFAULT_AGENT_REQ:
            msg = new DefaultAgentReqInfo();
            break;
        case MsgType.DEFAULT_AGENT_NTF:
            msg = new DefaultAgentNtfInfo();
            break;
        case MsgType.USER_ICON_LIST_NTF:
            msg = new UserIconListNtfInfo();
            break;
        case MsgType.CURRENT_USER_ICON_NTF:
            msg = new CurrentUserIconNtfInfo();
            break;
        case MsgType.CHANGE_USER_ICON_REQ:
            msg = new ChangeUserIconReqInfo();
            break;
        case MsgType.USER_SURVEY_FINISH_REQ:
            msg = new UserSurveyFinishReqInfo();
            break;
        case MsgType.USER_SURVEY_LIST_NTF:
            msg = new UserSurveyListNtfInfo();
            break;
        case MsgType.COMPRESSED4B_NTF:
            msg = new Compressed4b();
            break;
        case MsgType.USER_CLICK_TRACKING_REQ:
            msg = new UserClickTracking();
            break;
        case MsgType.USER_FPS_BATTLE_TRACKING_REQ:
            msg = new UserFpsBattleTracking();
            break;
        case MsgType.USER_TASK_TRACKING_REQ:
            msg = new UserTaskTracking();
            break;
        case MsgType.USER_REPORT_TRACKING_REQ:
            msg = new UserReportTracking();
            break;
        case MsgType.USER_TASK_WCT_TRACKING_REQ:
            msg = new UserTaskWctTracking();
            break;
        case MsgType.FPS_TRACKING_REQ:
            msg = new FpsTracking();
            break;
        case MsgType.FIRST_CHARGE_PACK_NTF:
            msg = new FirstChargePack();
            break;
        case MsgType.CAMPAIGN_INFO_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.CAMPAIGN_INFO_ACK:
            msg = new CampaignInfo();
            break;
        case MsgType.TASK_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.EXCHANGE_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.CAMPAIGN_REDPOINT_NTF:
            msg = new CampaignRedpointInfo();
            break;
        case MsgType.INSTANT_BUY_ACK:
            msg = new InstantBuyInfo();
            break;
        case MsgType.RANK_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.RANK_CAMPAIGN_RANK_REQ:
            msg = new CampaignRankReqInfo();
            break;
        case MsgType.RANK_CAMPAIGN_RANK_ACK:
            msg = new CampaignRankInfo();
            break;
        case MsgType.PVC_NTF:
            msg = new PvcInfo();
            break;
        case MsgType.RESIZEABLE_GRID_VIEW_REQ:
            msg = new ResizeableGridViewReqInfo();
            break;
        case MsgType.RESIZEABLE_GRID_VIEW_NTF:
            msg = new ResizeableGridViewInfo();
            break;
        case MsgType.POP_BANNER_NTF:
            msg = new BannerInfoList();
            break;
        case MsgType.GET_SEVENDAY_ALL_INFO_ACK:
            msg = new SevendayAllInfo();
            break;
        case MsgType.GET_SEVENDAY_FINAL_REWARD_REQ:
            msg = new SevendayFinalRewardId();
            break;
        case MsgType.CLIENT_TEXT_NTF:
            msg = new ClientTextList();
            break;
        case MsgType.POP_EVENT_BANNER_NTF:
            msg = new BannerInfoList();
            break;
        case MsgType.BIG_REBEL_INFO_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.BIG_REBEL_INFO_ACK:
            msg = new BigRebelTile();
            break;
        case MsgType.DAILY_FREE_PACK_NTF:
            msg = new DailyFreePack();
            break;
        case MsgType.SELECT_AVATAR_FRAME_REQ:
            msg = new AvatarFrameId();
            break;
        case MsgType.NEW_AVATAR_FRAME_NTF:
            msg = new AvatarFrameId();
            break;
        case MsgType.SELECT_AVATAR_FRAME_ACK:
            msg = new AvatarFrameId();
            break;
        case MsgType.SECOND_PURCHASE_NTF:
            msg = new SecondPurchaseInfo();
            break;
        case MsgType.SECOND_PURCHASE_REWARD_REQ:
            msg = new SecondPurchaseRewardReqInfo();
            break;
        case MsgType.SET_CITY_AGENT_REQ:
            msg = new SetCityAgent();
            break;
        case MsgType.AGENT_STATE_NTF:
            msg = new AgentStateInfo();
            break;
        case MsgType.SAFE_BOX_NTF:
            msg = new SafeBoxInfo();
            break;
        case MsgType.DYNAMIC_CLIENT_DATA_NTF:
            msg = new DynamicClientData();
            break;
        case MsgType.BIND_NTF:
            msg = new BindNtfData();
            break;
        case MsgType.CREATE_MARCH_REQ:
            msg = new CreateMarchReqInfo();
            break;
        case MsgType.CREATE_MARCH_ACK:
            msg = new MarchInfo();
            break;
        case MsgType.UPDATE_MARCH_REQ:
            msg = new UpdateMarchReqInfo();
            break;
        case MsgType.UPDATE_MARCH_ACK:
            msg = new MarchInfo();
            break;
        case MsgType.STOP_MARCH_REQ:
            msg = new MarchId();
            break;
        case MsgType.CREATE_ALLIANCE_BUILDING_REQ:
            msg = new CreateAllianceBuildingInfo();
            break;
        case MsgType.BATTLE_ROUND_NTF:
            msg = new BattleRoundInfo();
            break;
        case MsgType.CULTURE_AGENT_LIST_ACK:
            msg = new CultureAgentListInfo();
            break;
        case MsgType.AGENT_LEVEL_EXP_ITEM_USE_REQ:
            msg = new AgentLevelExpItemUseReqInfo();
            break;
        case MsgType.AGENT_STAR_POINT_ITEM_USE_REQ:
            msg = new AgentStarPointItemUseReqInfo();
            break;
        case MsgType.AGENT_STAR_POINT_FRAGMENT_USE_REQ:
            msg = new AgentStarPointFragmentUseReqInfo();
            break;
        case MsgType.AGENT_SKILL_UPGRADE_REQ:
            msg = new AgentSkillUpgradeReqInfo();
            break;
        case MsgType.AGENT_FRAGMENT_EXCHANGE_REQ:
            msg = new AgentFragmentExchangeReqInfo();
            break;
        case MsgType.AGENT_TALENT_INFO_REQ:
            msg = new AgentTalentInfoReqInfo();
            break;
        case MsgType.AGENT_TALENT_INFO_ACK:
            msg = new CultureAgentTalentInfo();
            break;
        case MsgType.AGENT_TALENT_UPGRADE_REQ:
            msg = new AgentTalentUpgradeReqInfo();
            break;
        case MsgType.CULTURE_AGENT_LIST_INFO_NTF:
            msg = new CultureAgentListInfo();
            break;
        case MsgType.CULTURE_AGENT_INFO_NTF:
            msg = new CultureAgentInfo();
            break;
        case MsgType.CULTURE_AGENT_TALENT_INFO_NTF:
            msg = new CultureAgentTalentInfo();
            break;
        case MsgType.AGENT_TALENT_TREE_RESET_REQ:
            msg = new AgentTalentTreeResetReqInfo();
            break;
        case MsgType.CULTURE_AGENT_TABLE_NTF:
            msg = new CultureAgentTableList();
            break;
        case MsgType.CULTURE_AGENT_RANK_UPGRADE_REQ:
            msg = new CultureAgentRankUpgradeReqInfo();
            break;
        case MsgType.UNLOCK_AGENT_REQ:
            msg = new UnlockAgentReqInfo();
            break;
        case MsgType.CULTURE_AGENT_TALENT_LIST_NTF:
            msg = new CultureAgentTalentList();
            break;
        case MsgType.LAND_MATERIALS_NTF:
            msg = new LandMaterials();
            break;
        case MsgType.MAP_BUILDING_DETAIL_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.MAP_BUILDING_DETAIL_ACK:
            msg = new MapBuildingDetailInfo();
            break;
        case MsgType.ALLIANCE_BUILDING_STATE_ACK:
            msg = new AllianceBuildingStateList();
            break;
        case MsgType.ALLIANCE_BUILDING_STATE_NTF:
            msg = new AllianceBuildingStateList();
            break;
        case MsgType.PROMOTE_TROOP_REQ:
            msg = new TroopPromotionInfo();
            break;
        case MsgType.PROMOTE_TROOP_ACK:
            msg = new TroopProgInfo();
            break;
        case MsgType.SEARCH_BUILDING_LAND_REQ:
            msg = new MapBuildingType();
            break;
        case MsgType.SEARCH_BUILDING_LAND_ACK:
            msg = new TilePos();
            break;
        case MsgType.CANCEL_LANDER_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.BUILDING_UPDATE_NTF:
            msg = new MapBuildingInfo();
            break;
        case MsgType.KICK_RALLY_TROOP_REQ:
            msg = new KickRallyTroopReqInfo();
            break;
        case MsgType.CMP_LAND_DATA_NTF:
            msg = new CompressedLandInfo();
            break;
        case MsgType.CMP_LAND_DATA_REQ:
            msg = new CmpLandDataReqInfo();
            break;
        case MsgType.PUT_OUT_FIRE_REQ:
            msg = new PutOutFireReqInfo();
            break;
        case MsgType.KICK_REINFORCE_TROOP_REQ:
            msg = new KickReinforceTroopReqInfo();
            break;
        case MsgType.MAP_BUILDING_REQ:
            msg = new MapBuildingReqInfo();
            break;
        case MsgType.ASSIGN_MAYOR_REQ:
            msg = new AssignMayorReqInfo();
            break;
        case MsgType.CMP_LAND_THUMBNAIL_NTF:
            msg = new CmpLandThumbnail();
            break;
        case MsgType.UPDATE_MAPMARK_REQ:
            msg = new UpdateMapmarkInfo();
            break;
        case MsgType.UPDATE_MAPMARK_ACK:
            msg = new MapmarkInfo();
            break;
        case MsgType.ALL_STRONGHOLD_NTF:
            msg = new MapBuildingInfo();
            break;
        case MsgType.UPDATE_ALLIANCE_MEMBER_TITLE_ACK:
            msg = new UpdateAllianceMemberTitleAckInfo();
            break;
        case MsgType.CREATE_RTF_MAIL_REQ:
            msg = new CreateRtfMailReqInfo();
            break;
        case MsgType.NEW_RTF_MAIL_NTF:
            msg = new NewRtfMailNtfInfo();
            break;
        case MsgType.GET_RTF_MAIL_LIST_REQ:
            msg = new GetRtfMailListReqInfo();
            break;
        case MsgType.GET_RTF_MAIL_LIST_ACK:
            msg = new GetRtfMailListAckInfo();
            break;
        case MsgType.UNREAD_RTF_MAIL_COUNT_NTF:
            msg = new UnreadRtfMailCountNtfInfo();
            break;
        case MsgType.GET_RTF_MAIL_REQ:
            msg = new GetRtfMailReqInfo();
            break;
        case MsgType.GET_RTF_MAIL_ACK:
            msg = new GetRtfMailAckInfo();
            break;
        case MsgType.READ_RTF_MAIL_REQ:
            msg = new ReadRtfMailReqInfo();
            break;
        case MsgType.DELETE_RTF_MAIL_REQ:
            msg = new DeleteRtfMailReqInfo();
            break;
        case MsgType.COLLECT_RTF_MAIL_REQ:
            msg = new CollectRtfMailInfo();
            break;
        case MsgType.SHARE_BATTLE_MAIL_REQ:
            msg = new ShareBattleMailReqInfo();
            break;
        case MsgType.SHARE_BATTLE_MAIL_ACK:
            msg = new ReplayInfo();
            break;
        case MsgType.GET_SHARE_BATTLE_MAIL_REQ:
            msg = new GetShareBattleMailReqInfo();
            break;
        case MsgType.GET_SHARE_BATTLE_MAIL_ACK:
            msg = new GetShareBattleMailAckInfo();
            break;
        case MsgType.GET_GATHER_REPORT_LIST_REQ:
            msg = new GetGatherReportListReqInfo();
            break;
        case MsgType.GET_GATHER_REPORT_LIST_ACK:
            msg = new GetGatherReportListAckInfo();
            break;
        case MsgType.GET_RTF_COLLECT_MAIL_LIST_REQ:
            msg = new GetRtfMailListReqInfo();
            break;
        case MsgType.GET_RTF_COLLECT_MAIL_LIST_ACK:
            msg = new GetRtfMailListAckInfo();
            break;
        case MsgType.DELETE_ALL_RTF_MAIL_REQ:
            msg = new DeleteAllRtfMailReqInfo();
            break;
        case MsgType.DELETE_ALL_RTF_MAIL_ACK:
            msg = new DeleteAllRtfMailAckInfo();
            break;
        case MsgType.READ_ALL_RTF_MAIL_REQ:
            msg = new ReadAllRtfMailReqInfo();
            break;
        case MsgType.READ_ALL_RTF_MAIL_ACK:
            msg = new ReadAllRtfMailAckInfo();
            break;
        case MsgType.TAVERN_BOX_NTF:
            msg = new TavernBoxInfo();
            break;
        case MsgType.TAVERN_BOX_OPEN_REQ:
            msg = new TavernBoxOpenReqInfo();
            break;
        case MsgType.TAVERN_BOX_OPEN_ACK:
            msg = new TavernBoxOpenAckInfo();
            break;
        case MsgType.ALLIANCE_MONUMENT_ACK:
            msg = new MapBuildingInfo();
            break;
        case MsgType.ADJUST_INFO_REQ:
            msg = new AdjustInfo();
            break;
        case MsgType.MAP_MILESTONE_ACK:
            msg = new MapMilestoneInfo();
            break;
        case MsgType.MAP_MILESTONE_AWD_REQ:
            msg = new MapMilestoneAwdInfo();
            break;
        case MsgType.MAP_LEVEL_NTF:
            msg = new MapLevelNtfInfo();
            break;
        case MsgType.READ_RTF_MAIL_ACK:
            msg = new MailRewardInfo();
            break;
        case MsgType.CITY_BATTLE_NTF:
            msg = new CityBattleNtfInfo();
            break;
        case MsgType.CHECK_BATTLE_TARGET_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.CUMULATIVE_CHARGE_NTF:
            msg = new CumulativeChargeInfo();
            break;
        case MsgType.ALLIANCE_WAREHOUSE_ACK:
            msg = new AllianceWarehouseAckInfo();
            break;
        case MsgType.TIMER_IAP_NTF:
            msg = new TimerIapNtf();
            break;
        case MsgType.MAP_ITEM_NTF:
            msg = new ResListAckInfo();
            break;
        case MsgType.UPDATE_BUILDING_REINFORCE_NTF:
            msg = new UpdateBuildingReinforceNtf();
            break;
        case MsgType.QUICK_RECONNECT_FINISH_NTF:
            msg = new QuickReconnectFinishNtf();
            break;
        case MsgType.CHECK_LANDER_POS_REQ:
            msg = new TilePos();
            break;
        case MsgType.ALLIANCE_FORTUNE_GIFT_ACK:
            msg = new AllianceFortuneGiftAckInfo();
            break;
        case MsgType.ALLIANCE_FORTUNE_GIFT_OPEN_REQ:
            msg = new AllianceFortuneGiftOpenReqInfo();
            break;
        case MsgType.ALLIANCE_FORTUNE_GIFT_OPEN_ACK:
            msg = new AllianceFortuneGiftOpenAckInfo();
            break;
        case MsgType.ALLIANCE_FORTUNE_GIFT_NTF:
            msg = new AllianceFortuneGiftAckInfo();
            break;
        case MsgType.ALLIANCE_NEW_FORTUNE_GIFT_NTF:
            msg = new AllianceNewFortuneGiftNtfInfo();
            break;
        case MsgType.MAP_MILESTONE_NTF:
            msg = new MapMilestoneInfo();
            break;
        case MsgType.START_EXPEDITION_REQ:
            msg = new StartExpeditionReqInfo();
            break;
        case MsgType.START_EXPEDITION_ACK:
            msg = new StartExpeditionAckInfo();
            break;
        case MsgType.USER_ROOM_NTF:
            msg = new UserRoomInfo();
            break;
        case MsgType.EXPEDITION_STATE_ACK:
            msg = new ExpeditionStateInfo();
            break;
        case MsgType.ALL_MONUMENT_INFO_ACK:
            msg = new AllMonumentInfo();
            break;
        case MsgType.MONUMENT_BATTLE_WIN_NTF:
            msg = new MapBuildingId();
            break;
        case MsgType.PROGRESS_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.STEP_TASK_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.STEP_TASK_CAMPAIGN_HISTORY_ACK:
            msg = new StepTaskCampaignHistoryList();
            break;
        case MsgType.EXPEDITION_CHECKPOINT_END_NTF:
            msg = new ExpeditionCheckpointEndNtfInfo();
            break;
        case MsgType.CURRENT_EXPEDITION_STATE_ACK:
            msg = new CurrentExpeditionStateInfo();
            break;
        case MsgType.EXPEDITION_STAR_REWARD_REQ:
            msg = new ExpeditionStarRewardReqInfo();
            break;
        case MsgType.OCCUPY_LAND_NTF:
            msg = new OccupyLandNtf();
            break;
        case MsgType.B2_SCROLL_MESSAGE_NTF:
            msg = new B2ScrollMessage();
            break;
        case MsgType.MAP_EXPLORE_STATUS_ACK:
            msg = new MapExploreStatusInfo();
            break;
        case MsgType.MAP_EXPLORE_SEARCH_REQ:
            msg = new MapExploreSearchReqInfo();
            break;
        case MsgType.MAP_EXPLORE_SEARCH_ACK:
            msg = new MapExploreStatusInfo();
            break;
        case MsgType.MAP_EXPLORE_GOT_REWARD_REQ:
            msg = new MapExploreGotRewardReqInfo();
            break;
        case MsgType.MAP_EXPLORE_SECRET_CHOICE_REQ:
            msg = new MapExploreSecretChoiceReqInfo();
            break;
        case MsgType.MAP_EXPLORE_REACH_NTF:
            msg = new MapExploreReachNtfInfo();
            break;
        case MsgType.MAP_EXPLORE_STATUS_NTF:
            msg = new MapExploreStatusInfo();
            break;
        case MsgType.MAP_EXPLORE_RELOCATE_POINT_REQ:
            msg = new MapExploreRelocatePointReqInfo();
            break;
        case MsgType.MAP_EXPLORE_RELOCATE_POINT_ACK:
            msg = new MapExploreVirtualPoint();
            break;
        case MsgType.MAP_EXPLORE_POINT_STATUS_UPDATE_NTF:
            msg = new MapExploreVirtualPoint();
            break;
        case MsgType.FPS_ATY_BEGIN_REQ:
            msg = new CampaignReqItemInfo();
            break;
        case MsgType.FPS_ATY_END_REQ:
            msg = new FpsAtyEndReqInfo();
            break;
        case MsgType.FPS_ATY_END_ACK:
            msg = new FpsAtyEndAckInfo();
            break;
        case MsgType.TECH_ITEM_NTF:
            msg = new TechItemNtfInfo();
            break;
        case MsgType.CURRENT_EXPEDITION_MARCH_ACK:
            msg = new CurrentExpeditionMarch();
            break;
        case MsgType.HELP_REWARD_NTF:
            msg = new HelpRewardNtfInfo();
            break;
        case MsgType.EXPEDITION_STORE_INFO_ACK:
            msg = new ExpeditionStoreInfo();
            break;
        case MsgType.EXPEDITION_STORE_BUY_REQ:
            msg = new ExpeditionStoreBuyReqInfo();
            break;
        case MsgType.ASSIGNMENT_CENTER_INFO_NTF:
            msg = new AssignmentCenterInfo();
            break;
        case MsgType.ASSIGNMENT_CENTER_INFO_ACK:
            msg = new AssignmentCenterInfo();
            break;
        case MsgType.ASSIGN_AGENT_REQ:
            msg = new AssignAgentReqInfo();
            break;
        case MsgType.ASSIGNMENT_CENTER_MINI_GAME_REQ:
            msg = new AssignmentCenterMiniGameReqInfo();
            break;
        case MsgType.ASSIGNMENT_CENTER_MINI_GAME_ACK:
            msg = new AssignmentCenterMiniGameAckInfo();
            break;
        case MsgType.SET_AGENT_SKIN_REQ:
            msg = new SetAgentSkinReqInfo();
            break;
        case MsgType.ASSIGNMENT_CENTER_EXP_ITEM_REQ:
            msg = new AssignmentCenterExpItemReqInfo();
            break;
        case MsgType.UNFINISHED_LAND_RECT_NTF:
            msg = new UnfinishedLandRectList();
            break;
        case MsgType.CAMPAIGN_ALL_ID_ACK:
            msg = new CampaignAllIdAckInfo();
            break;
        case MsgType.ALLIANCE_REBEL_BEGIN_REQ:
            msg = new AllianceRebelBeginReqInfo();
            break;
        case MsgType.ALLIANCE_REBEL_BEGIN_UPDATE_REQ:
            msg = new AllianceRebelBeginReqInfo();
            break;
        case MsgType.ALLIANCE_REBEL_STATE_NTF:
            msg = new AllianceRebelStateInfo();
            break;
        case MsgType.ALLIANCE_REBEL_INFO_ACK:
            msg = new AllianceRebelInfo();
            break;
        case MsgType.ALLIANCE_REBEL_CAMPAIGN_HISTORY_ACK:
            msg = new AllianceRebelCampaignHistoryList();
            break;
        case MsgType.REBEL_BASE_INFO_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.REBEL_BASE_INFO_ACK:
            msg = new RebelBaseDetailInfo();
            break;
        case MsgType.AS_REBEL_MARCH_INFO_REQ:
            msg = new AsRebelMarchInfoReqInfo();
            break;
        case MsgType.AS_REBEL_MARCH_INFO_ACK:
            msg = new AsRebelMarchInfoAckInfo();
            break;
        case MsgType.TAP_AGENT_REQ:
            msg = new AgentId();
            break;
        case MsgType.TAP_AGENT_ACK:
            msg = new TapAgentAckInfo();
            break;
        case MsgType.UPGRADE_AGENT_ASSIGNMENT_LEVEL_REQ:
            msg = new AgentId();
            break;
        case MsgType.REMOVE_ALLIANCE_BUILDING_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.DEFENCE_CENTER_INFO_ACK:
            msg = new DefenceCenterInfo();
            break;
        case MsgType.DEFENCE_CENTER_INFO_NTF:
            msg = new DefenceCenterInfo();
            break;
        case MsgType.RAILWAY_SHOP_INFO_NTF:
            msg = new RailwayShopInfo();
            break;
        case MsgType.RAILWAY_SHOP_BUY_REQ:
            msg = new RailwayShopBuyReqInfo();
            break;
        case MsgType.DEFENCE_CENTER_TELEPORT_NTF:
            msg = new TilePos();
            break;
        case MsgType.B2_VIP_NTF:
            msg = new B2VipNtfInfo();
            break;
        case MsgType.B2_VIP_LEVELUP_NTF:
            msg = new B2VipLevelupNtfInfo();
            break;
        case MsgType.B2_VIP_SHOP_NTF:
            msg = new B2VipShopInfo();
            break;
        case MsgType.B2_VIP_SHOP_BUY_REQ:
            msg = new B2VipShopBuyInfo();
            break;
        case MsgType.B2_ITEM_EXCHANGE_NTF:
            msg = new ItemExchangeInfo();
            break;
        case MsgType.GOV_INFO_ACK:
            msg = new GovInfo();
            break;
        case MsgType.SET_GOV_TITLE_REQ:
            msg = new SetGovTitleReqInfo();
            break;
        case MsgType.ACTIVATE_GOV_BUFF_REQ:
            msg = new ActivateGovBuffReqInfo();
            break;
        case MsgType.SEND_GOV_LOOT_REQ:
            msg = new SendGovLootReqInfo();
            break;
        case MsgType.WHEEL_CAMPAIGN_ROLL_REQ:
            msg = new WheelCampaignRollReqInfo();
            break;
        case MsgType.WHEEL_CAMPAIGN_ROLL_ACK:
            msg = new WheelCampaignRollAckInfo();
            break;
        case MsgType.WHEEL_CAMPAIGN_EXTRA_REWARD_REQ:
            msg = new WheelCampaignExtraRewardReqInfo();
            break;
        case MsgType.GUIDE_REBEL_INFO_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.GUIDE_REBEL_INFO_ACK:
            msg = new GuideRebelTile();
            break;
        case MsgType.SUMMON_GUIDE_REBEL_ACK:
            msg = new TilePos();
            break;
        case MsgType.CLAIM_DAILY_SUBSCRIPTION_REQ:
            msg = new ClaimDailySubscriptionReqInfo();
            break;
        case MsgType.DAILY_SUBSCRIPTION_NTF:
            msg = new DailySubscriptionInfoList();
            break;
        case MsgType.GOV_TITLE_NTF:
            msg = new MapTitleInfo();
            break;
        case MsgType.ALLIANCE_REBEL_DEFENCE_LIST_ACK:
            msg = new AllianceRebelDefenceListInfo();
            break;
        case MsgType.ALLIANCE_REBEL_DEFENCE_LIST_NTF:
            msg = new AllianceRebelDefenceListInfo();
            break;
        case MsgType.APP_EVENT_STATE_REQ:
            msg = new AppEventStateInfo();
            break;
        case MsgType.APP_EVENT_STATE_ACK:
            msg = new AppEventStateInfo();
            break;
        case MsgType.ALLIANCE_REBEL_CURRENT_SCORE_NTF:
            msg = new AllianceRebelCurrentScoreNtfInfo();
            break;
        case MsgType.REBATE_PACKAGE_NTF:
            msg = new RebatePackageInfo();
            break;
        case MsgType.CLAIM_REBATE_PACKAGE_REQ:
            msg = new ClaimRebatePackageReqInfo();
            break;
        case MsgType.DAILY_SUBSCRIPTION_REWARD_NTF:
            msg = new DailySubscriptionReward();
            break;
        case MsgType.USE_EXCHANGE_CODE_REQ:
            msg = new UseExchangeCodeReqInfo();
            break;
        case MsgType.USE_EXCHANGE_CODE_ACK:
            msg = new UseExchangeCodeAckInfo();
            break;
        case MsgType.CLAIM_RECHARGE_CAMPAIGN_RWD_REQ:
            msg = new ClaimRechargeCampaignRwdReqInfo();
            break;
        case MsgType.ALLIANCE_REBEL_USER_LOSE_NTF:
            msg = new AllianceRebelUserLoseNtfInfo();
            break;
        case MsgType.BUBBLE_CLICK_REQ:
            msg = new BubbleClickReqInfo();
            break;
        case MsgType.BUBBLE_NTF:
            msg = new BubbleInfo();
            break;
        case MsgType.CAMPAIGN_POPUP_NTF:
            msg = new CampaignPopupNtfInfo();
            break;
        case MsgType.RECHARGE_REDPOINT_NTF:
            msg = new RechargeRedpointInfo();
            break;
        case MsgType.SET_SIGN_REQ:
            msg = new SetSignReqInfo();
            break;
        case MsgType.SET_AGENT_POSE_REQ:
            msg = new SetAgentPoseReqInfo();
            break;
        case MsgType.PROGRESSIVE_TASK_REWARD_REQ:
            msg = new ProgressiveTaskRewardReqInfo();
            break;
        case MsgType.PROGRESSIVE_TASK_FINAL_REWARD_REQ:
            msg = new ProgressiveTaskFinalRewardReqInfo();
            break;
        case MsgType.COST_ACTIVITY_STATUS_REQ:
            msg = new CampaignId();
            break;
        case MsgType.COST_ACTIVITY_STATUS_ACK:
            msg = new CostActivityStatus();
            break;
        case MsgType.COST_ACTIVITY_COST_REQ:
            msg = new CostActivityCostReqInfo();
            break;
        case MsgType.COST_ACTIVITY_COST_ACK:
            msg = new CostActivityCostAckInfo();
            break;
        case MsgType.COST_ACTIVITY_LEVEL_REWARD_REQ:
            msg = new CostActivityLevelRewardReqInfo();
            break;
        case MsgType.COST_ACTIVITY_UNLOCK_REQ:
            msg = new CampaignId();
            break;
        case MsgType.NONSTOP_KILLING_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.TROOP_COMPLETE_NTF:
            msg = new TroopCompleteNtfInfo();
            break;
        case MsgType.CHANGE_FACTION_REQ:
            msg = new ChangeFactionReqInfo();
            break;
        case MsgType.CAMPAIGN_BEGIN_NTF:
            msg = new CampaignRedpointInfo();
            break;
        case MsgType.ALLIANCE_SHOP_INFO_NTF:
            msg = new AllianceShopInfo();
            break;
        case MsgType.ALLIANCE_SHOP_BUY_REQ:
            msg = new AllianceShopBuyReqInfo();
            break;
        case MsgType.ALLIANCE_SHOP_BUY_HISTORY_ACK:
            msg = new AllianceShopBuyHistoryInfo();
            break;
        case MsgType.ALLIANCE_SHOP_RESTOCK_REQ:
            msg = new AllianceShopRestockReqInfo();
            break;
        case MsgType.ALLIANCE_SHOP_RESTOCK_HISTORY_ACK:
            msg = new AllianceShopRestockHistoryInfo();
            break;
        case MsgType.CITY_SKIN_LIST_ACK:
            msg = new CitySkinListInfo();
            break;
        case MsgType.SET_CITY_SKIN_REQ:
            msg = new SetCitySkinReqInfo();
            break;
        case MsgType.QUEST_COUNTDOWN_REQ:
            msg = new QuestCountdownReq();
            break;
        case MsgType.QUEST_COUNTDOWN_LIST_REQ:
            msg = new QuestCountdownListReq();
            break;
        case MsgType.QUEST_COUNTDOWN_LIST_ACK:
            msg = new QuestCountdownListAck();
            break;
        case MsgType.CITY_SKIN_NTF:
            msg = new CitySkinInfo();
            break;
        case MsgType.FOG_DATA_NTF:
            msg = new FogData();
            break;
        case MsgType.EXT_FOG_DATA_NTF:
            msg = new FogDataExt();
            break;
        case MsgType.GM_CLIENT_CONTROL_NTF:
            msg = new GmClientControlNtfInfo();
            break;
        case MsgType.OPEN_FOG_NTF:
            msg = new OpenFogNtfInfo();
            break;
        case MsgType.MONUMENT_EXPLORE_INFO_NTF:
            msg = new MonumentExploreInfo();
            break;
        case MsgType.FAKE_FOG_OPEN_INFO_NTF:
            msg = new FakeFogOpenInfo();
            break;
        case MsgType.TIMELIMIT_TASK_START_NTF:
            msg = new TimelimitTaskStartNtf();
            break;
        case MsgType.TIMELIMIT_TASK_END_NTF:
            msg = new TimelimitTaskEndNtf();
            break;
        case MsgType.FIREWORKS_NTF:
            msg = new FireworksInfo();
            break;
        case MsgType.LADDER_STATUS_ACK:
            msg = new LadderStatusInfo();
            break;
        case MsgType.LADDER_INFO_ACK:
            msg = new LadderInfoAckInfo();
            break;
        case MsgType.LADDER_USER_INIT_REQ:
            msg = new LadderUserInitReqInfo();
            break;
        case MsgType.LADDER_USER_INIT_ACK:
            msg = new LadderStatusInfo();
            break;
        case MsgType.LADDER_USER_REBEL_SUMMON_ACK:
            msg = new LadderStatusInfo();
            break;
        case MsgType.LADDER_ALLIANCE_BOARD_ACK:
            msg = new LadderAllianceBoardAckInfo();
            break;
        case MsgType.LADDER_ALLIANCE_BOARD_FLUSH_NTF:
            msg = new LadderAllianceBoardFlushNtf();
            break;
        case MsgType.LADDER_STEP_REWARD_INFO_ACK:
            msg = new LadderStepRewardInfo();
            break;
        case MsgType.LADDER_ENEMY_MARCH_INFO_REQ:
            msg = new MarchId();
            break;
        case MsgType.LADDER_ENEMY_MARCH_INFO_ACK:
            msg = new LadderEnemyMarchTipInfo();
            break;
        case MsgType.LADDER_STATUS_UPDATE_NTF:
            msg = new LadderStatusInfo();
            break;
        case MsgType.LADDER_ALLIANCE_BOSS_LIST_ACK:
            msg = new LadderAllianceBossListInfo();
            break;
        case MsgType.COUPON_NTF:
            msg = new CouponInfos();
            break;
        case MsgType.REMOTE_LOGIN_REQ:
            msg = new RemoteLoginInfo();
            break;
        case MsgType.AS_GUIDE_CAMPAIGN_REWARD_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.TIMELIMIT_TASK_POINT_NTF:
            msg = new TimelimitTaskPointNtf();
            break;
        case MsgType.TIMELIMIT_QUEST_NTF:
            msg = new TimelimitQuestList();
            break;
        case MsgType.TIMELIMIT_QUEST_AWD_REQ:
            msg = new TimelimitQuestAwdReq();
            break;
        case MsgType.PROGRESSIVE_TASK_CAMPAIGN_FINAL_REWARD_NTF:
            msg = new ProgressiveTaskCampaignFinalRewardStatusInfo();
            break;
        case MsgType.ARENA_PLAYER_NTF:
            msg = new ArenaPlayerInfo();
            break;
        case MsgType.ARENA_NTF:
            msg = new ArenaNtfInfo();
            break;
        case MsgType.ARENA_SET_DEFEND_REQ:
            msg = new ArenaSetDefendReqInfo();
            break;
        case MsgType.ARENA_MATCH_ACK:
            msg = new ArenaMatchAckInfo();
            break;
        case MsgType.ARENA_FIGHT_REQ:
            msg = new ArenaFightReqInfo();
            break;
        case MsgType.ARENA_FIGHT_STAT_NTF:
            msg = new ArenaFightStatInfo();
            break;
        case MsgType.ARENA_HISTORY_ACK:
            msg = new ArenaHistoryAckInfo();
            break;
        case MsgType.ARENA_RANKLIST_REQ:
            msg = new ArenaRanklistReqInfo();
            break;
        case MsgType.ARENA_RANKLIST_ACK:
            msg = new ArenaRanklistAckInfo();
            break;
        case MsgType.ARENA_REWARD_ACK:
            msg = new ArenaRewardAckInfo();
            break;
        case MsgType.BATTLE_PASSPORT_NTF:
            msg = new BattlePassportInfo();
            break;
        case MsgType.BATTLE_PASSPORT_RWD_REQ:
            msg = new BattlePassportRwdReq();
            break;
        case MsgType.BATTLE_PASSPORT_BUY_EXP_REQ:
            msg = new BattlePassportBuyExpReq();
            break;
        case MsgType.BATTLE_PASSPORT_INFO_ACK:
            msg = new BattlePassportInfo();
            break;
        case MsgType.FINISH_BATTLE_PASSPORT_TASK_REQ:
            msg = new BattlePassportTaskId();
            break;
        case MsgType.QUEST_COUNTDOWN_ACK:
            msg = new QuestCountdownAck();
            break;
        case MsgType.GATHER_BUFF_NTF:
            msg = new GatherBuffNtf();
            break;
        case MsgType.CITY_GUIDE_TASK_REWARD_REQ:
            msg = new CityGuideTaskRewardReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_STATUS_REQ:
            msg = new AllianceMobilizeStatusReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_STATUS_ACK:
            msg = new AllianceMobilizeStatus();
            break;
        case MsgType.ALLIANCE_MOBILIZE_FLUSH_TASK_REQ:
            msg = new AllianceMobilizeFlushTaskReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_FLUSH_TASK_ACK:
            msg = new AllianceMobilizeFlushTaskAckInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_ADD_AVAILABLE_TASK_REQ:
            msg = new AllianceMobilizeAddAvailableTaskReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_ABANDON_REQ:
            msg = new AllianceMobilizeTaskAbandonReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_ABANDON_ACK:
            msg = new AllianceMobilizeTaskAbandonAckInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_FINISH_REQ:
            msg = new AllianceMobilizeTaskFinishReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_FINISH_ACK:
            msg = new AllianceMobilizeTaskFinishAckInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_SELECT_REQ:
            msg = new AllianceMobilizeTaskSelectReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_SELECT_ACK:
            msg = new AllianceMobilizeTaskSelectAckInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_ACHIEVE_NTF:
            msg = new AllianceMobilizeTaskAchieveNtfInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_PROGRESS_UPDATE_NTF:
            msg = new AllianceMobilizeProgressUpdateNtfInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_REWARD_REQ:
            msg = new AllianceMobilizeRewardReqInfo();
            break;
        case MsgType.ALLIANCE_MOBILIZE_TASK_OVERDUE_NTF:
            msg = new AllianceMobilizeTaskOverdueNtfInfo();
            break;
        case MsgType.ARENA_FIGHT_STAT_REQ:
            msg = new ArenaFightIdInfo();
            break;
        case MsgType.ARENA_FIGHT_DETAIL_REQ:
            msg = new ArenaFightIdInfo();
            break;
        case MsgType.ARENA_FIGHT_DETAIL_NTF:
            msg = new ArenaFightDetailInfo();
            break;
        case MsgType.PLAYER_MAYOR_NTF:
            msg = new PlayerMayorInfo();
            break;
        case MsgType.CAST_MONUMENT_SKILL_REQ:
            msg = new CastMonumentSkillReqInfo();
            break;
        case MsgType.CAST_MONUMENT_SKILL_ACK:
            msg = new CastMonumentSkillAckInfo();
            break;
        case MsgType.OCCUPY_MONUMENT_BANNER_NTF:
            msg = new OccupyMonumentBannerNtfInfo();
            break;
        case MsgType.OFFLINE_OCCUPY_MONUMENT_BANNER_NTF:
            msg = new OfflineOccupyMonumentBannerNtfInfo();
            break;
        case MsgType.B2_TRANSFER_SERVER_CHECKOUT_REQ:
            msg = new B2TransferServerCheckoutReq();
            break;
        case MsgType.B2_TRANSFER_SERVER_CHECKOUT_ACK:
            msg = new B2TransferServerCheckoutAck();
            break;
        case MsgType.B2_TRANSFER_SERVER_REQ:
            msg = new B2TransferServerReq();
            break;
        case MsgType.B2_TRANSFER_SERVER_ACK:
            msg = new B2TransferServerAck();
            break;
        case MsgType.B2_TRANSFER_SERVER_SET_MAX_POWER_REQ:
            msg = new B2TransferServerSetMaxPowerReq();
            break;
        case MsgType.B2_TRANSFER_SERVER_DIS_INFO_REQ:
            msg = new B2TransferServerDisInfoReq();
            break;
        case MsgType.B2_TRANSFER_SERVER_DIS_INFO_ACK:
            msg = new B2TransferServerDisInfoAck();
            break;
        case MsgType.OUTBATTLE_EFFECT_NTF:
            msg = new OutbattleEffectNtfInfo();
            break;
        case MsgType.BATTLE_SUPPORT_NTF:
            msg = new BattleSupportNtfInfo();
            break;
        case MsgType.PLAT_FOLLOW_REWARD_REQ:
            msg = new PlatFollowRewardReqInfo();
            break;
        case MsgType.LIMITED_BUFF_NTF:
            msg = new LimitedBuffNtfInfo();
            break;
        case MsgType.KILLZOMBIE_ACK:
            msg = new KillzombieAckInfo();
            break;
        case MsgType.KILLZOMBIE_NTF:
            msg = new KillzombieNtfInfo();
            break;
        case MsgType.LOUD_SPEAKER_NTF:
            msg = new LoudSpeakerNtfInfo();
            break;
        case MsgType.LOUD_SPEAKER_ACK:
            msg = new LoudSpeakerAckInfo();
            break;
        case MsgType.LOUD_SPEAKER_REWARD_NTF:
            msg = new LoudSpeakerRewardNtfInfo();
            break;
        case MsgType.DAY_NIGHT_NTF:
            msg = new DayNightInfo();
            break;
        case MsgType.GVG_MAP_BUILDING_DETAIL_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.GVG_RANDOM_TELEPORT_NTF:
            msg = new ServerTilePos();
            break;
        case MsgType.GVG_USER_INFO_REQ:
            msg = new UserReqInfo();
            break;
        case MsgType.GVG_CANCEL_LANDER_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.GVG_BUILDING_UPDATE_NTF:
            msg = new MapBuildingInfo();
            break;
        case MsgType.GVG_KICK_RALLY_TROOP_REQ:
            msg = new KickRallyTroopReqInfo();
            break;
        case MsgType.GVG_OCCUPY_LAND_NTF:
            msg = new OccupyLandNtf();
            break;
        case MsgType.ARTWORK_NTF:
            msg = new ArtworkNtfInfo();
            break;
        case MsgType.GVG_RALLY_LIST_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_DEFENCE_CENTER_PUT_FIRE_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_RALLY_COMPLETE_NTF:
            msg = new RallyCompleteInfo();
            break;
        case MsgType.GVG_NEW_MAPMARK_REQ:
            msg = new NewMapmarkInfo();
            break;
        case MsgType.GVG_REPAIR_NTF:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.GVG_GRID_INFO_NTF:
            msg = new GridInfo();
            break;
        case MsgType.NIGHT_FIXED_VIEW_NTF:
            msg = new NightFixedViewNtfInfo();
            break;
        case MsgType.SET_VIP_SWITCH_REQ:
            msg = new SetVipSwitchInfo();
            break;
        case MsgType.GVG_UPDATE_MARCH_ACK:
            msg = new MarchInfo();
            break;
        case MsgType.GVG_REMOVE_ALLIANCE_BUILDING_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.USER_ARCHIVE_NTF:
            msg = new UserArchiveInfo();
            break;
        case MsgType.NIGHT_FIXED_VIEW_SINGLE_UPDATE_NTF:
            msg = new NightFixedViewSingleUpdateInfo();
            break;
        case MsgType.GVG_STOP_MARCH_REQ:
            msg = new MarchId();
            break;
        case MsgType.GVG_TILE_INFO_REQ:
            msg = new TilePos();
            break;
        case MsgType.GVG_SPEEDUP_DIAMONDS_REQ:
            msg = new SpeedupDiamondsInfo();
            break;
        case MsgType.GVG_JOIN_ACK:
            msg = new GvgJoinAckInfo();
            break;
        case MsgType.GVG_AGENT_STATE_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_REPAIR_INFO_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_CREATE_MARCH_REQ:
            msg = new CreateMarchReqInfo();
            break;
        case MsgType.GVG_CMP_LAND_THUMBNAIL_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_LAND_MATERIALS_NTF:
            msg = new LandMaterials();
            break;
        case MsgType.USER_GVG_INFO_REQ:
            msg = new GvgNtfReqInfo();
            break;
        case MsgType.GVG_MONUMENT_BATTLE_WIN_NTF:
            msg = new MapBuildingId();
            break;
        case MsgType.GVG_MAP_BUILDING_DETAIL_ACK:
            msg = new MapBuildingDetailInfo();
            break;
        case MsgType.GVG_USER_MAP_NTF:
            msg = new UserMapInfo();
            break;
        case MsgType.CAMPAIGN_CALENDAR_ACK:
            msg = new CampaignAllIdAckInfo();
            break;
        case MsgType.GVG_REPAIR_REQ:
            msg = new RepairReqInfo();
            break;
        case MsgType.GVG_BE_SCOUT_NTF:
            msg = new BeScoutListInfo();
            break;
        case MsgType.GVG_APPLY_MEMBER_LIST_NTF:
            msg = new GvgApplyMemberListNtfInfo();
            break;
        case MsgType.GVG_DEFENCE_CENTER_TELEPORT_NTF:
            msg = new TilePos();
            break;
        case MsgType.GVG_RELOCATE_CITY_NTF:
            msg = new RelocateNtfInfo();
            break;
        case MsgType.GVG_DEFENCE_CENTER_INFO_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_BE_ATK_NTF:
            msg = new BeAtkListInfo();
            break;
        case MsgType.GVG_MARCH_COMPLETE_NTF:
            msg = new MarchInfo();
            break;
        case MsgType.CLAIM_ARCHIVE_REWARD_REQ:
            msg = new ClaimArchiveRewardInfo();
            break;
        case MsgType.GVG_TROOP_NTF:
            msg = new TroopInfo();
            break;
        case MsgType.GVG_RALLY_ALERT_NTF:
            msg = new RallyInfo();
            break;
        case MsgType.GVG_B2_SCROLL_MESSAGE_NTF:
            msg = new B2ScrollMessage();
            break;
        case MsgType.ROULETTE_TASK_COMPLETE_REQ:
            msg = new RouletteTaskCompleteReqInfo();
            break;
        case MsgType.GVG_DISMISS_TROOP_REQ:
            msg = new DismissTroopInfo();
            break;
        case MsgType.GVG_GRID_VIEW_REQ:
            msg = new GridViewReqInfo();
            break;
        case MsgType.GVG_APPLY_MANAGE_NTF:
            msg = new GvgApplyManageNtfInfo();
            break;
        case MsgType.GVG_RALLY_REQ:
            msg = new RallyReqInfo();
            break;
        case MsgType.GVG_RALLY_DEFENCE_ACK:
            msg = new DefenceListInfo();
            break;
        case MsgType.GVG_AWARD_LIST_RESP:
            msg = new GvgAwardListRespInfo();
            break;
        case MsgType.GVG_AGENT_STATE_NTF:
            msg = new AgentStateInfo();
            break;
        case MsgType.GVG_UPDATE_MARCH_REQ:
            msg = new UpdateMarchReqInfo();
            break;
        case MsgType.GVG_BATTLE_ROUND_NTF:
            msg = new BattleRoundInfo();
            break;
        case MsgType.ROULETTE_ROLL_REQ:
            msg = new RouletteRollReqInfo();
            break;
        case MsgType.GVG_BATTLEFIELD_NTF:
            msg = new GvgBattlefieldNtfInfo();
            break;
        case MsgType.GVG_RALLY_CANCEL_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_RALLY_LIST_ACK:
            msg = new RallyListInfo();
            break;
        case MsgType.GVG_USER_INFO_ACK:
            msg = new UserInfo();
            break;
        case MsgType.GVG_UPDATE_MAPMARK_REQ:
            msg = new UpdateMapmarkInfo();
            break;
        case MsgType.GVG_RALLY_DEFENCE_ALERT_NTF:
            msg = new DefenceInfo();
            break;
        case MsgType.GVG_SPEEDUP_REQ:
            msg = new SpeedupInfo();
            break;
        case MsgType.GVG_CHECK_BATTLE_TARGET_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.BATTLEFIELD_REQ:
            msg = new GvgBattlefieldReqInfo();
            break;
        case MsgType.ROULETTE_ROLL_ACK:
            msg = new RouletteRollAckInfo();
            break;
        case MsgType.GVG_MAPMARK_LIST_NTF:
            msg = new MapmarkListInfo();
            break;
        case MsgType.GVG_USER_MAP_REQ:
            msg = new MsgMap();
            break;
        case MsgType.ROULETTE_DIAMOND_EXCH_REQ:
            msg = new RouletteDiamondExchReqInfo();
            break;
        case MsgType.GVG_CMP_LAND_DATA_REQ:
            msg = new CmpLandDataReqInfo();
            break;
        case MsgType.BATTLEFIELD_LIST_REQ:
            msg = new GvgBattlefieldListReqInfo();
            break;
        case MsgType.GVG_FIREWORKS_NTF:
            msg = new FireworksInfo();
            break;
        case MsgType.USER_GVG_APPLY_MANAGE_REQ:
            msg = new GvgApplyManageReqInfo();
            break;
        case MsgType.GVG_CLEAR_GRID_VIEW_REQ:
            msg = new GridPos();
            break;
        case MsgType.GVG_MARCH_LIST_NTF:
            msg = new MarchListNtfInfo();
            break;
        case MsgType.GVG_TILE_INFO_ACK:
            msg = new TileDetailInfo();
            break;
        case MsgType.GVG_REPAIR_ACK:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.USER_GVG_APPLY_MEMBER_LIST_REQ:
            msg = new GvgApplyMemberListReqInfo();
            break;
        case MsgType.GVG_SET_CITY_AGENT_REQ:
            msg = new SetCityAgent();
            break;
        case MsgType.BATTLEFIELD_ACK:
            msg = new GvgBattlefieldAckInfo();
            break;
        case MsgType.GVG_ALLIANCE_HELP_REQ:
            msg = new AllianceHelpReq();
            break;
        case MsgType.GVG_USER_SHIELD_NTF:
            msg = new UserShieldInfo();
            break;
        case MsgType.GVG_CMP_LAND_THUMBNAIL_NTF:
            msg = new CmpLandThumbnail();
            break;
        case MsgType.GVG_QUIT_NTF:
            msg = new GvgQuitNtf();
            break;
        case MsgType.GVG_MARCH_NTF:
            msg = new MarchInfo();
            break;
        case MsgType.GVG_RELOCATE_CITY_REQ:
            msg = new TilePos();
            break;
        case MsgType.GVG_HEART_BEAT_ACK:
            msg = new MsgMap();
            break;
        case MsgType.GVG_DEFENCE_CENTER_INFO_NTF:
            msg = new DefenceCenterInfo();
            break;
        case MsgType.GVG_BATTLEFIELD_STATUS_NTF:
            msg = new GvgBattlefieldStatusNtfInfo();
            break;
        case MsgType.GVG_DELETE_GRID_VIEW_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_BUFF_LIST_NTF:
            msg = new BuffListNtfInfo();
            break;
        case MsgType.UPGRADE_AGENT_STUDY_LEVEL_REQ:
            msg = new UpgradeAgentStudyLevelReqInfo();
            break;
        case MsgType.USER_GVG_APPLY_TIME_REQ:
            msg = new GvgApplyTimeReqInfo();
            break;
        case MsgType.GVG_QUIT_REQ:
            msg = new GvgQuitReqInfo();
            break;
        case MsgType.ACTIVE_AGENT_STUDY_EFFECT_REQ:
            msg = new ActiveAgentStudyEffectReqInfo();
            break;
        case MsgType.GVG_SEARCH_BUILDING_LAND_ACK:
            msg = new TilePos();
            break;
        case MsgType.GVG_DEL_MAPMARK_REQ:
            msg = new MapmarkIdInfo();
            break;
        case MsgType.GVG_USER_INFO_NTF:
            msg = new UserInfo();
            break;
        case MsgType.ALL_BURNING_TOWER_NTF:
            msg = new MapBuildingInfo();
            break;
        case MsgType.GVG_JOIN_REQ:
            msg = new GvgJoinReqInfo();
            break;
        case MsgType.GVG_HEART_BEAT_REQ:
            msg = new MsgMap();
            break;
        case MsgType.BATTLEFIELD_LIST_ACK:
            msg = new GvgBattlefieldListAckInfo();
            break;
        case MsgType.GVG_REPAIR_TROOP_NTF:
            msg = new RepairTroopInfo();
            break;
        case MsgType.GVG_PUT_OUT_FIRE_REQ:
            msg = new PutOutFireReqInfo();
            break;
        case MsgType.GVG_TILE_UPDATE_NTF:
            msg = new TileUpdateInfo();
            break;
        case MsgType.GVG_MAP_BUILDING_REQ:
            msg = new MapBuildingReqInfo();
            break;
        case MsgType.GVG_DEFENCE_CENTER_INFO_ACK:
            msg = new DefenceCenterInfo();
            break;
        case MsgType.GVG_MARCH_RECALL_REQ:
            msg = new MarchRecallInfo();
            break;
        case MsgType.GVG_BUFF_LIST_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_TROOP_INFO_REQ:
            msg = new MsgMap();
            break;
        case MsgType.GVG_DEFENCE_CENTER_REPAIR_REQ:
            msg = new MsgMap();
            break;
        case MsgType.USER_UNLOCK_EMOTICON_NTF:
            msg = new UserUnlockEmoticonInfo();
            break;
        case MsgType.GVG_CMP_LAND_DATA_NTF:
            msg = new CompressedLandInfo();
            break;
        case MsgType.GVG_NTF:
            msg = new GvgNtfInfo();
            break;
        case MsgType.GVG_UPDATE_MAPMARK_ACK:
            msg = new MapmarkInfo();
            break;
        case MsgType.GVG_CHECK_LANDER_POS_REQ:
            msg = new TilePos();
            break;
        case MsgType.GVG_REPAIR_INFO_ACK:
            msg = new RepairFactoryInfo();
            break;
        case MsgType.GVG_MARCH_REQ:
            msg = new MarchReqInfo();
            break;
        case MsgType.GVG_KICK_REINFORCE_TROOP_REQ:
            msg = new KickReinforceTroopReqInfo();
            break;
        case MsgType.GVG_CREATE_MARCH_ACK:
            msg = new MarchInfo();
            break;
        case MsgType.GVG_BE_REINFORCE_NTF:
            msg = new BeReinforceListInfo();
            break;
        case MsgType.GVG_RALLY_DEFENCE_REQ:
            msg = new MsgMap();
            break;
        case MsgType.USER_SET_CURRENT_CHAT_BUBBLE_REQ:
            msg = new UserSetCurrentChatBubbleInfo();
            break;
        case MsgType.GET_NEW_CHAT_BUBBLE_NTF:
            msg = new UserGetNewChatBubbleInfo();
            break;
        case MsgType.GET_NEW_CITY_NAMEPLATE_NTF:
            msg = new UserGetNewCityNameplateInfo();
            break;
        case MsgType.USER_CITY_NAMEPLATE_NTF:
            msg = new UserCityNameplateInfo();
            break;
        case MsgType.GVG_USER_SEND_EMOTICON_NTF:
            msg = new UserSendEmoticonInfo();
            break;
        case MsgType.GVG_USER_SEND_EMOTICON_REQ:
            msg = new UserSendEmoticonInfo();
            break;
        case MsgType.USER_EMOTICON_ACK:
            msg = new UserEmoticonInfo();
            break;
        case MsgType.DIAMOND_BUY_CITY_NAMEPLATE_REQ:
            msg = new DiamondBuyCityNameplateInfo();
            break;
        case MsgType.USER_SEND_EMOTICON_NTF:
            msg = new UserSendEmoticonInfo();
            break;
        case MsgType.USER_CITY_NAMEPLATE_ACK:
            msg = new UserCityNameplateInfo();
            break;
        case MsgType.USER_SEND_EMOTICON_REQ:
            msg = new UserSendEmoticonInfo();
            break;
        case MsgType.DIAMOND_BUY_EMOTICON_REQ:
            msg = new DiamondBuyEmoticonInfo();
            break;
        case MsgType.USER_EMOTICON_NTF:
            msg = new UserEmoticonInfo();
            break;
        case MsgType.DIAMOND_BUY_CHAT_BUBBLE_REQ:
            msg = new DiamondBuyChatBubbleInfo();
            break;
        case MsgType.USER_CHAT_BUBBLE_NTF:
            msg = new UserChatBubbleInfo();
            break;
        case MsgType.USER_SET_CURRENT_CITY_NAMEPLATE_ACK:
            msg = new UserSetCurrentCityNameplateAckInfo();
            break;
        case MsgType.USER_CHAT_BUBBLE_ACK:
            msg = new UserChatBubbleInfo();
            break;
        case MsgType.SET_CURRENT_CITY_NAMEPLATE_REQ:
            msg = new UserSetCurrentCityNameplateInfo();
            break;
        case MsgType.CROSS_ARENA_FIGHT_DETAIL_NTF:
            msg = new ArenaFightDetailInfo();
            break;
        case MsgType.CROSS_ARENA_PLAYER_NTF:
            msg = new ArenaPlayerInfo();
            break;
        case MsgType.CROSS_ARENA_SET_DEFEND_REQ:
            msg = new ArenaSetDefendReqInfo();
            break;
        case MsgType.CROSS_ARENA_NTF:
            msg = new ArenaNtfInfo();
            break;
        case MsgType.CROSS_ARENA_BUY_CNT_ACK:
            msg = new CrossArenaBuyCntAckInfo();
            break;
        case MsgType.CROSS_ARENA_HISTORY_ACK:
            msg = new ArenaHistoryAckInfo();
            break;
        case MsgType.CROSS_ARENA_FIGHT_STAT_REQ:
            msg = new ArenaFightIdInfo();
            break;
        case MsgType.CROSS_ARENA_FIGHT_REQ:
            msg = new ArenaFightReqInfo();
            break;
        case MsgType.CROSS_ARENA_SHOP_BUY_REQ:
            msg = new ArenaShopBuyReqInfo();
            break;
        case MsgType.CROSS_ARENA_RANKLIST_REQ:
            msg = new ArenaRanklistReqInfo();
            break;
        case MsgType.CROSS_ARENA_FIGHT_STAT_NTF:
            msg = new ArenaFightStatInfo();
            break;
        case MsgType.CROSS_ARENA_REWARD_ACK:
            msg = new ArenaRewardAckInfo();
            break;
        case MsgType.CROSS_ARENA_FIGHT_DETAIL_REQ:
            msg = new ArenaFightIdInfo();
            break;
        case MsgType.CROSS_ARENA_MATCH_ACK:
            msg = new ArenaMatchAckInfo();
            break;
        case MsgType.CROSS_ARENA_RANKLIST_ACK:
            msg = new ArenaRanklistAckInfo();
            break;
        case MsgType.CROSS_ARENA_SHOP_NTF:
            msg = new ArenaShopInfo();
            break;
        case MsgType.CROSS_ARENA_BUY_CNT_REQ:
            msg = new CrossArenaBuyCntReqInfo();
            break;
        case MsgType.USER_GET_VERIF_CODE_REQ:
            msg = new UserGetVerifCodeReqInfo();
            break;
        case MsgType.MAIL_CONFIRM_QUERY_ACK:
            msg = new MailConfirmQueryAckInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_RESET_REQ:
            msg = new BossCampaignResetReqInfo();
            break;
        case MsgType.MAIL_CONFIRM_CHOICE_STATUS_ACK:
            msg = new MailConfirmChoiceStatusAckInfo();
            break;
        case MsgType.KVK_QUEST_REWARD_CLAIM_REQ:
            msg = new KvkQuestRewardClaimReqInfo();
            break;
        case MsgType.USER_DAILY_GATHER_REWARD_NTF:
            msg = new UserDailyGatherRewardInfo();
            break;
        case MsgType.RANK_CAMPAIGN_SELF_RANK_REQ:
            msg = new RankCampaignSelfRankReqInfo();
            break;
        case MsgType.KVK_ALLIANCE_MONUMENT_ACK:
            msg = new MapBuildingInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_CLAIM_REWARD_REQ:
            msg = new BossCampaignClaimRewardReqInfo();
            break;
        case MsgType.GUEST_MAP_BUILDING_REQ:
            msg = new MapBuildingReqInfo();
            break;
        case MsgType.RELOCATE_SERVER_NTF:
            msg = new RelocateServerInfo();
            break;
        case MsgType.DROP_CAMPAIGN_DROP_NTF:
            msg = new DropCampaignDropNtfInfo();
            break;
        case MsgType.KVK_LAND_INFO_NTF:
            msg = new KvkLandInfo();
            break;
        case MsgType.MAIL_CONFIRM_CHOICE_STATUS_REQ:
            msg = new MailConfirmChoiceStatusReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_FIGHT_SCORE_NTF:
            msg = new BossCampaignFightScoreNtfInfo();
            break;
        case MsgType.KVK_MAP_MILESTONE_NTF:
            msg = new MapMilestoneInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_RECORD_REQ:
            msg = new BossCampaignRecordReqInfo();
            break;
        case MsgType.RANK_CAMPAIGN_SELF_RANK_ACK:
            msg = new RankCampaignSelfRankAckInfo();
            break;
        case MsgType.GUEST_USER_STATISTICS_REQ:
            msg = new UserStatisticsReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_FLUSH_NTF:
            msg = new BossCampaignBossFlushNtfInfo();
            break;
        case MsgType.GUEST_CMP_LAND_DATA_REQ:
            msg = new CmpLandDataReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_REAL_POS_ACK:
            msg = new BossCampaignRealPosAckInfo();
            break;
        case MsgType.MAIL_CONFIRM_DO_CHORCE_REQ:
            msg = new MailConfirmDoChoiceReqInfo();
            break;
        case MsgType.KVK_QUEST_LIST_REQ:
            msg = new KvkQuestListReqInfo();
            break;
        case MsgType.KVK_MAP_MILESTONE_ACK:
            msg = new MapMilestoneInfo();
            break;
        case MsgType.KVK_LIST_ALLIANCE_DOMINION_CNT_REQ:
            msg = new ListAllianceDominionReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_CLAIM_SERVER_REWARD_REQ:
            msg = new BossCampaignClaimServerRewardReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_RECORD_ACK:
            msg = new BossCampaignRecordAckInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_RECORD_NTF:
            msg = new BossCampaignRecordAckInfo();
            break;
        case MsgType.KVK_SET_LAND_COLOR_REQ:
            msg = new KvkSetLandColorReqInfo();
            break;
        case MsgType.USER_VERIF_CODE_NTF:
            msg = new UserVerifCodeInfo();
            break;
        case MsgType.ERROR_CODE_NTF:
            msg = new ErrorCodeInfo();
            break;
        case MsgType.USER_GET_VERIF_CODE_ACK:
            msg = new UserGetVerifCodeAckInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_STRONGEST_ZONE_ACK:
            msg = new BossCampaignStrongestZoneAckInfo();
            break;
        case MsgType.KVK_RALLY_LIST_ACK:
            msg = new RallyListInfo();
            break;
        case MsgType.CHANGE_ALLIANCE_DESC_INFO_REQ:
            msg = new ChangeAllianceDescInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_BE_KILLED_NTF:
            msg = new BossCampaignBeKilledNtfInfo();
            break;
        case MsgType.KVK_MAP_MILESTONE_AWD_REQ:
            msg = new MapMilestoneAwdInfo();
            break;
        case MsgType.USER_INFO_COLLECT_ACK:
            msg = new UserInfoCollectInfo();
            break;
        case MsgType.MAIL_CONFIRM_QUERY_REQ:
            msg = new MailConfirmQueryReqInfo();
            break;
        case MsgType.KVK_QUEST_LIST_ACK:
            msg = new KvkQuestListAckInfo();
            break;
        case MsgType.MAIL_CONFIRM_SIMPLE_STATUS_NTF:
            msg = new MailConfirmSimpleStatus();
            break;
        case MsgType.BOSS_CAMPAIGN_REAL_POS_REQ:
            msg = new BossCampaignRealPosReqInfo();
            break;
        case MsgType.GUEST_BIG_REBEL_INFO_REQ:
            msg = new MapBuildingId();
            break;
        case MsgType.CREATE_GUILD_CONFIRM_MAIL_ACK:
            msg = new CreateGuildConfirmMailAckInfo();
            break;
        case MsgType.KVK_LIST_ALLIANCE_DOMINION_CNT_ACK:
            msg = new ListAllianceDominionCntInfo();
            break;
        case MsgType.GUEST_TILE_INFO_REQ:
            msg = new TilePos();
            break;
        case MsgType.GS_MAP_ID_REQ:
            msg = new MapIdReqInfo();
            break;
        case MsgType.GS_MAP_ID_ACK:
            msg = new MapIdInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_ARMY_SLOT_REQ:
            msg = new BossCampaignArmySlotReqInfo();
            break;
        case MsgType.KVK_QUEST_FINISH_NTF:
            msg = new KvkQuestFinishNtfInfo();
            break;
        case MsgType.USER_DO_VERIF_CODE_REQ:
            msg = new UserDoVerifCodeReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_SET_SLOT_ARMY_REQ:
            msg = new BossCampaignSetSlotArmyReqInfo();
            break;
        case MsgType.BOSS_CAMPAIGN_ARMY_SLOT_ACK:
            msg = new BossCampaignArmySlotAckInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_SERVER_REWARD_REQ:
            msg = new CampaignKvkFortServerRewardReqInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_EXCHANGE_DONATE_REQ:
            msg = new CampaignKvkFortExchangeDonateReqInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_DONATE_REQ:
            msg = new CampaignKvkFortDonateReqInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_KILL_REWARD_ACK:
            msg = new CampaignKvkFortKillRewardAckInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_EXCHANGE_DONATE_ACK:
            msg = new CampaignKvkFortExchangeDonateAckInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_STEP_CHANGE_NTF:
            msg = new CampaignKvkFortStepChangeNtfInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_KILL_REWARD_REQ:
            msg = new CampaignKvkFortKillRewardReqInfo();
            break;
        case MsgType.CAMPAIGN_KVK_FORT_DONATE_ACK:
            msg = new CampaignKvkFortDonateAckInfo();
            break;
        case MsgType.SCOUT_COOLDOWN_NTF:
            msg = new ScoutCooldownNtfInfo();
            break;
        case MsgType.SEVEN_DAILY_LOGIN_NTF:
            msg = new SevenDailyLoginInfo();
            break;
        case MsgType.CLAIM_SEVEN_DAILY_LOGIN_REQ:
            msg = new ClaimSevenDailyLoginInfo();
            break;
        case MsgType.CLAIM_MERGE_LOGIN_REWARDS_ACK:
            msg = new ClaimMergeLoginRewardsAckInfo();
            break;
        case MsgType.MERGE_LOGIN_REWARDS_NTF:
            msg = new MergeLoginRewardsNtfInfo();
            break;
        case MsgType.MERGE_SERVER_NTF:
            msg = new MergeServerNtfInfo();
            break;
        case MsgType.CLAIM_MERGE_LOGIN_REWARDS_REQ:
            msg = new ClaimMergeLoginRewardsReqInfo();
            break;
        case MsgType.SERVER_TYPE_INFO_NTF:
            msg = new ServerTypeInfo();
            break;
        case MsgType.SLOT_MACHINE_EXTRA_REWARD_REQ:
            msg = new SlotMachineExtraRewardReqInfo();
            break;
        case MsgType.SLOT_MACHINE_ROLL_ACK:
            msg = new SlotMachineRollAckInfo();
            break;
        case MsgType.SLOT_MACHINE_ROLL_REQ:
            msg = new SlotMachineRollReqInfo();
            break;
        case MsgType.NEW_SEVEN_DAY_LOGIN_REWARDS_NTF:
            msg = new NewSevenDayLoginRewardsNtfInfo();
            break;
        case MsgType.KVK_LAB_LOOT_OWNER_CHECK_REQ:
            msg = new KvkLabLootOwnerCheckReqInfo();
            break;
        case MsgType.KVK_BATTLE_PASSPORT_INFO_ACK:
            msg = new KvkBattlePassportInfo();
            break;
        case MsgType.SYNC_PLAYER_BLACK_LIST_REQ:
            msg = new SyncPlayerBlackListReqInfo();
            break;
        case MsgType.PLAYER_INFO_FORBID_NTF:
            msg = new PlayerInfoForbidNtfInfo();
            break;
        case MsgType.USER_WARSHIP_UPGRADE_RESEARCH_REQ:
            msg = new UserWarshipUpgradeResearchInfo();
            break;
        case MsgType.KVK_SERVER_COUNTRY_LIST_NTF:
            msg = new KvkServerCountryList();
            break;
        case MsgType.BOSS_CAMPAIGN_RUNNING_STATUS_ACK:
            msg = new BossCampaignRunningStatusAckInfo();
            break;
        case MsgType.GET_BULLET_REPORT_LIST_ACK:
            msg = new GetGatherReportListAckInfo();
            break;
        case MsgType.KVK_PRE_CREEP_EXCHANGE_REQ:
            msg = new KvkPreCreepExchangeReqInfo();
            break;
        case MsgType.USER_WARSHIP_BATTLE_ENERGY_NTF:
            msg = new UserWarshipBattleEnergyInfo();
            break;
        case MsgType.SET_ALLIANCE_JOIN_CONDITION_REQ:
            msg = new SetAllianceJoinConditionInfo();
            break;
        case MsgType.KVK_BATTLE_PASSPORT_BUY_EXP_REQ:
            msg = new BattlePassportBuyExpReq();
            break;
        case MsgType.KVK_GOV_TOWER_INFO_ACK:
            msg = new KvkGovTowerInfo();
            break;
        case MsgType.PLAYER_BLACK_LIST_MODIFY_REQ:
            msg = new PlayerBlackListModifyReqInfo();
            break;
        case MsgType.GATHER_LAB_LOOT_NTF:
            msg = new GatherLabLootNtfInfo();
            break;
        case MsgType.SELF_ALLIANCE_RANK_ACK:
            msg = new SelfAllianceRankAckInfo();
            break;
        case MsgType.KVK_AVAILABLE_AGENT_LIST_ACK:
            msg = new KvkAvailableAgentListInfo();
            break;
        case MsgType.EXCHANGE_CAMP_AUTO_USE_NTF:
            msg = new ExchangeCampAutoUseNtfInfo();
            break;
        case MsgType.USER_WARSHIP_NTF:
            msg = new UserWarshipInfo();
            break;
        case MsgType.GOV_TOWER_FIRE_NTF:
            msg = new GovTowerFireNtfInfo();
            break;
        case MsgType.USER_ALL_WARSHIPS_NTF:
            msg = new UserAllWarshipsInfo();
            break;
        case MsgType.KVK_COUNTER_NTF:
            msg = new KvkCounterNtfInfo();
            break;
        case MsgType.USER_WARSHIP_SKILL_NTF:
            msg = new UserWarshipSkillInfo();
            break;
        case MsgType.SELF_ALLIANCE_RANK_REQ:
            msg = new SelfAllianceRankReqInfo();
            break;
        case MsgType.KVK_PRE_CLAIM_TASK_REWARD_REQ:
            msg = new KvkPreClaimTaskRewardReqInfo();
            break;
        case MsgType.USER_WARSHIP_CANCEL_RESEARCH_REQ:
            msg = new UserWarshipCancelResearchInfo();
            break;
        case MsgType.DEL_MAIL_REWARD_NTF:
            msg = new MailRewardInfo();
            break;
        case MsgType.TIME_LIMITED_CITY_SKIN_NTF:
            msg = new TimeLimitedCitySkinList();
            break;
        case MsgType.KVK_FINISH_BATTLE_PASSPORT_TASK_REQ:
            msg = new BattlePassportTaskId();
            break;
        case MsgType.BUY_SPECIAL_PRICE_ITEM_REQ:
            msg = new BuySpecialPriceItemReqInfo();
            break;
        case MsgType.USER_WARSHIP_UPGRADE_SKILL_REQ:
            msg = new UserWarshipUpgradeSkillInfo();
            break;
        case MsgType.KVK_PRE_STEP_CONVERT_NTF:
            msg = new KvkPreStepConvertNtfInfo();
            break;
        case MsgType.KVK_BATTLE_PASSPORT_NTF:
            msg = new KvkBattlePassportInfo();
            break;
        case MsgType.KVK_BATTLE_PASSPORT_RWD_REQ:
            msg = new BattlePassportRwdReq();
            break;
        case MsgType.SPOTTING_ITEM_NTF:
            msg = new SpottingItemNtfInfo();
            break;
        case MsgType.PLAYER_BLACK_LIST_NTF:
            msg = new PlayerBlackListNtfInfo();
            break;
        case MsgType.USER_WARSHIP_RESEARCH_BUBBLE_REQ:
            msg = new UserWarshipResearchBubbleInfo();
            break;
        case MsgType.KVK_PRE_CREEP_EXCHANGE_ACK:
            msg = new KvkPreCreepExchangeAckInfo();
            break;
        case MsgType.BUY_SPECIAL_PRICE_ITEM_NTF:
            msg = new BuySpecialPriceItemNtfInfo();
            break;
        case MsgType.USER_WARSHIP_RESEARCH_QUEUE_NTF:
            msg = new UserWarshipResearchQueueInfo();
            break;
        case MsgType.USER_WARSHIP_RESEARCH_BUBBLE_NTF:
            msg = new UserWarshipResearchBubbles();
            break;
        case MsgType.GET_BULLET_REPORT_LIST_REQ:
            msg = new GetGatherReportListReqInfo();
            break;
        case MsgType.UNLOCK_AS_TASK_GROUP_REQ:
            msg = new UnlockAsTaskGroupReqInfo();
            break;
        case MsgType.CAST_AS_SKILL_NTF:
            msg = new AsSkillInfo();
            break;
        case MsgType.KVK_PRE_CREEP_LIST_ACK:
            msg = new KvkPreCreepListAckInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_OPEN_NTF:
            msg = new CampAllianceBoardOpenNtfInfo();
            break;
        case MsgType.USE_ALL_RSS_ITEM_REQ:
            msg = new UseAllRssItemReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_CAMPAIGN_BEGIN_REQ:
            msg = new CampAllianceBoardCampaignBeginReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_SLOT_FLUSH_NTF:
            msg = new CampAllianceBoardSlotFlushNtfInfo();
            break;
        case MsgType.CAST_GOV_SKILL_REQ:
            msg = new CastGovSkillReqInfo();
            break;
        case MsgType.BATCH_GET_RTF_MAIL_REQ:
            msg = new BatchGetRtfMailReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_FINISH_TASK_REQ:
            msg = new CampAllianceBoardFinishTaskReqInfo();
            break;
        case MsgType.CAST_AS_AKILL_NTF:
            msg = new CastAsAkillNtfInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_REQ:
            msg = new CampAllianceBoardReqInfo();
            break;
        case MsgType.KVK_PRE_CREEP_LIST_REQ:
            msg = new KvkPreCreepListReqInfo();
            break;
        case MsgType.SET_AS_CHEST_HIDE_NAME_REQ:
            msg = new AsChestHideNameInfo();
            break;
        case MsgType.AS_TASK_REWARD_REQ:
            msg = new AsTaskRewardReqInfo();
            break;
        case MsgType.INSTANT_FINISH_AS_TASK_REQ:
            msg = new InstantFinishAsTaskReqInfo();
            break;
        case MsgType.BATCH_GET_RTF_MAIL_ACK:
            msg = new BatchGetRtfMailAckInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_LEVEL_REWARD_REQ:
            msg = new CampAllianceBoardLevelRewardReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_ABANDON_TASK_REQ:
            msg = new CampAllianceBoardAbandonTaskReqInfo();
            break;
        case MsgType.AGENT_BACKGROUND_NTF:
            msg = new AgentBackgroundInfoList();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_TASK_STATUS_NTF:
            msg = new CampAllianceBoardTaskStatusNtfInfo();
            break;
        case MsgType.KVK_AVAILABLE_MAP_AREA_ACK:
            msg = new KvkAvailableMapAreaAckInfo();
            break;
        case MsgType.AS_TASK_INFO_NTF:
            msg = new AsTaskListInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_ADD_AVAILABLE_TASK_REQ:
            msg = new CampAllianceBoardAddAvailableTaskReqInfo();
            break;
        case MsgType.CAST_AS_SKILL_REQ:
            msg = new CastAsSkillReqInfo();
            break;
        case MsgType.KVK_RANKLIST_ACK:
            msg = new KvkRanklistAckInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_LEVEL_STATUS_UPDATE_NTF:
            msg = new CampAllianceBoardLevelStatusUpdateNtfInfo();
            break;
        case MsgType.AS_CHEST_HIDE_NAME_NTF:
            msg = new AsChestHideNameInfo();
            break;
        case MsgType.GET_SCOUT_REPORT_LIST_ACK:
            msg = new GetGatherReportListAckInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_APPLY_TASK_ACK:
            msg = new CampAllianceBoardApplyTaskAckInfo();
            break;
        case MsgType.GET_SCOUT_REPORT_LIST_REQ:
            msg = new GetGatherReportListReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_FLUSH_TASK_REQ:
            msg = new CampAllianceBoardFlushTaskReqInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_EXIT_NTF:
            msg = new CampAllianceBoardExitNtfInfo();
            break;
        case MsgType.AS_TASK_SCORE_INFO_ACK:
            msg = new AsTaskScoreInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_ACK:
            msg = new CampAllianceBoardAckInfo();
            break;
        case MsgType.KVK_RANKLIST_REQ:
            msg = new KvkRanklistReqInfo();
            break;
        case MsgType.AS_TASK_INFO_ACK:
            msg = new AsTaskListInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_APPLY_TASK_REQ:
            msg = new CampAllianceBoardApplyTaskReqInfo();
            break;
        case MsgType.CLAIM_ALL_RTF_MAIL_REQ:
            msg = new ReadAllRtfMailReqInfo();
            break;
        case MsgType.CLAIM_RTF_MAIL_REWARD_NTF:
            msg = new ClaimRtfMailRewardNtfInfo();
            break;
        case MsgType.AS_TASK_SCORE_RANK_INFO_ACK:
            msg = new AsTaskScoreRankInfo();
            break;
        case MsgType.CLAIM_RTF_MAIL_REQ:
            msg = new ReadRtfMailReqInfo();
            break;
        case MsgType.SET_AGENT_BACKGROUND_REQ:
            msg = new SetAgentBackgroundReqInfo();
            break;
        case MsgType.AS_TASK_SCORE_RANK_INFO_REQ:
            msg = new AsTaskScoreRankInfoReq();
            break;
        case MsgType.TROOP_TRAINING_CAP_INFO_NTF:
            msg = new TroopTrainingCapInfo();
            break;
        case MsgType.SET_CURRENT_CAPTAIN_ROOM_INFO_REQ:
            msg = new CaptainRoomOpInfo();
            break;
        case MsgType.USER_SHAME_QUICK_QUERY_ACK:
            msg = new UserShameQuickQueryAckInfo();
            break;
        case MsgType.CAPTAIN_ROOMS_ALL_NTF:
            msg = new CaptainRoomsInfo();
            break;
        case MsgType.GET_CAPTAIN_ROOM_INFO_ACK:
            msg = new CaptainRoomsInfo();
            break;
        case MsgType.USER_SHAME_POINT_NTF:
            msg = new UserShamePointNtfInfo();
            break;
        case MsgType.CAPTAIN_ROOMS_ALL_ACK:
            msg = new CaptainRoomsInfo();
            break;
        case MsgType.USER_SHAME_SIMPLE_NTF:
            msg = new UserShameSimpleNtfInfo();
            break;
        case MsgType.WEAPON_SPLIT_REQ:
            msg = new WeaponSplitReqInfo();
            break;
        case MsgType.CAPTAIN_ROOM_VISIT_NTF:
            msg = new CaptainRoomVisitRecordInfo();
            break;
        case MsgType.CAPTAIN_ROOM_STORYS_ACK:
            msg = new CaptainRoomStoryInfos();
            break;
        case MsgType.WEAPON_EQUIP_REQ:
            msg = new WeaponEquipReqInfo();
            break;
        case MsgType.WEAPON_SPLIT_ACK:
            msg = new WeaponSplitAckInfo();
            break;
        case MsgType.WEAPON_ADD_STAR_REQ:
            msg = new WeaponAddStarReqInfo();
            break;
        case MsgType.CAPTAIN_ROOM_VISIT_ACK:
            msg = new CaptainRoomVisitRecordInfo();
            break;
        case MsgType.USER_SHAME_DETAIL_REQ:
            msg = new UserShameDetailReqInfo();
            break;
        case MsgType.USER_REFUND_NTF:
            msg = new UserRefundNtfInfo();
            break;
        case MsgType.BUY_CAPTAIN_ROOM_FURNITURE_REQ:
            msg = new CaptainFurnitureOpInfo();
            break;
        case MsgType.GET_CAPTAIN_ROOM_STORY_REQ:
            msg = new CaptainRoomStoryOpInfo();
            break;
        case MsgType.SET_CAPTAIN_ROOM_ACTIVE_FURNITURE_REQ:
            msg = new CaptainFurnitureOpInfo();
            break;
        case MsgType.BUY_CAPTAIN_ROOM_REQ:
            msg = new CaptainRoomOpInfo();
            break;
        case MsgType.REFUND_TROOP_INFO_NTF:
            msg = new RefundTroopInfo();
            break;
        case MsgType.WEAPON_NTF:
            msg = new WeaponNtf();
            break;
        case MsgType.GET_CAPTAIN_ROOM_FURNITURE_REQ:
            msg = new CaptainRoomOpInfo();
            break;
        case MsgType.GET_CAPTAIN_ROOM_INFO_REQ:
            msg = new CaptainRoomOpInfo();
            break;
        case MsgType.CAPTAIN_ROOM_DAILY_GIFT_ACK:
            msg = new CaptainRoomDailyGiftInfo();
            break;
        case MsgType.USER_SHAME_DETAIL_ACK:
            msg = new UserShameDetailAckInfo();
            break;
        case MsgType.WEAPON_LOCK_REQ:
            msg = new WeaponLockReqInfo();
            break;
        case MsgType.CAPTAIN_ROOM_UNLOCK_FURNITURE_NTF:
            msg = new CaptainRoomUnlockFurnitureInfo();
            break;
        case MsgType.GET_CAPTAIN_ROOM_INFO_NTF:
            msg = new CaptainRoomsInfo();
            break;
        case MsgType.USER_SHAME_QUICK_QUERY_REQ:
            msg = new UserShameQuickQueryReqInfo();
            break;
        case MsgType.TROOP_POWER_DETAIL_ACK:
            msg = new TroopPowerDetailAckInfo();
            break;
        case MsgType.UPDATE_CAPTAIN_ROOM_STORY_REQ:
            msg = new CaptainRoomStoryOpInfo();
            break;
        case MsgType.GET_CAPTAIN_ROOM_DAILY_GIFT_REQ:
            msg = new CaptainRoomGiftOpInfo();
            break;
        case MsgType.USER_SHAME_DETAIL_SET_REQ:
            msg = new UserShameDetailSetReqInfo();
            break;
        case MsgType.USER_SOCIAL_SHARE_FINISH_REQ:
            msg = new UserSocialShareFinishReqInfo();
            break;
        case MsgType.WEAPON_LIST_NTF:
            msg = new WeaponListNtfInfo();
            break;
        case MsgType.WEAPON_GACHA_REQ:
            msg = new WeaponGachaReqInfo();
            break;
        case MsgType.CAPTAIN_ROOM_FURNITURE_NTF:
            msg = new CaptainRoomFurnitureInfo();
            break;
        case MsgType.CAPTAIN_ROOM_DAILY_GIFT_NTF:
            msg = new CaptainRoomDailyGiftInfo();
            break;
        case MsgType.CAPTAIN_ROOM_STORYS_NTF:
            msg = new CaptainRoomStoryInfos();
            break;
        case MsgType.GET_CAPTAIN_VISIT_GIFT_REQ:
            msg = new CaptainRoomGiftOpInfo();
            break;
        case MsgType.WEAPON_UNEQUIP_REQ:
            msg = new WeaponUnequipReqInfo();
            break;
        case MsgType.WEAPON_GACHA_ACK:
            msg = new WeaponGachaAckInfo();
            break;
        case MsgType.CAPTAIN_ROOM_FURNITURE_ACK:
            msg = new CaptainRoomFurnitureInfo();
            break;
        case MsgType.WEAPON_LEVELUP_REQ:
            msg = new WeaponLevelupReqInfo();
            break;
        case MsgType.SWAP_REINFORCE_TROOP_REQ:
            msg = new SwapReinforceTroopReqInfo();
            break;
        case MsgType.GVG_SWAP_REINFORCE_TROOP_REQ:
            msg = new SwapReinforceTroopReqInfo();
            break;
        case MsgType.GVG_UPDATE_BUILDING_REINFORCE_NTF:
            msg = new UpdateBuildingReinforceNtf();
            break;
        case MsgType.GLOBAL_RANKLIST_ACK:
            msg = new GlobalRanklistInfo();
            break;
        case MsgType.GLOBAL_RANKLIST_REQ:
            msg = new GlobalRanklistReqInfo();
            break;
        case MsgType.RANKING_REWARD_NTF:
            msg = new RankingRewardInfo();
            break;
        case MsgType.CLAIM_RANKING_REWARD_ACK:
            msg = new ClaimRankingRewardAckInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_TASK_HISTORY_QUERY_ACK:
            msg = new CampAllianceBoardTaskHistoryQueryAckInfo();
            break;
        case MsgType.CAMPAIGN_START_NTF:
            msg = new CampaignIdInfo();
            break;
        case MsgType.CAMP_ALLIANCE_BOARD_SET_TASK_FILTER_REQ:
            msg = new CampAllianceBoardSetTaskFilterReqInfo();
            break;
        case MsgType.CLAIM_CUMULATIVE_RECHARGE_CAMPAIGN_RWD_REQ:
            msg = new ClaimCumulativeRechargeCampaignRwdReqInfo();
            break;
        case MsgType.RANKING_REWARD_CFG_ACK:
            msg = new RankingRewardCfgList();
            break;
        case MsgType.ALLIANCE_USE_RESEARCH_REQ:
            msg = new AllianceUseResearchInfo();
            break;
        case MsgType.ALLIANCE_USE_RESEARCH_ACK:
            msg = new AllianceUseResearchAckInfo();
            break;
        case MsgType.USER_ARMY_BANNER_NTF:
            msg = new UserArmyBannerInfo();
            break;
        case MsgType.USER_ALL_ARMY_BANNERS_NTF:
            msg = new UserAllArmyBannersInfo();
            break;
        case MsgType.USER_ARMY_BANNER_UPGRADE_REQ:
            msg = new UserArmyBannerUpgradeInfo();
            break;
        case MsgType.KVK_BOUNTY_INFO_ACK:
            msg = new KvkBountyInfo();
            break;
        case MsgType.KVK_BOUNTY_REWARD_REQ:
            msg = new KvkBountyRewardReqInfo();
            break;
        case MsgType.KVK_BOUNTY_REWARD_ACK:
            msg = new KvkBountyRewardAckInfo();
            break;
        case MsgType.KVK_BOUNTY_SERVER_RANK_ACK:
            msg = new KvkBountyServerRankAckInfo();
            break;
        case MsgType.SEND_GIFT_REQ:
            msg = new SendGiftReqInfo();
            break;
        case MsgType.SEND_GIFT_RECORD_NTF:
            msg = new SendGiftRecord();
            break;
        case MsgType.READ_GIFT_RECORD_REQ:
            msg = new ReadGiftRecordReqInfo();
            break;
        case MsgType.WHEEL_CAMPAIGN_SELECT_OPTION_REQ:
            msg = new WheelCampaignSelectOptionReqInfo();
            break;
        case MsgType.WHEEL_CAMPAIGN_SELECT_OPTION_ACK:
            msg = new WheelCampaignSelectOptionAckInfo();
            break;
        case MsgType.AGENT_WGT_FIRST_GET_TALENT_REQ:
            msg = new AgentWgtFirstGetTalentReqInfo();
            break;
        case MsgType.AGENT_WGT_UNLOCK_BOX_REQ:
            msg = new AgentWgtUnlockBoxReqInfo();
            break;
        case MsgType.AGENT_WGT_BOX_GRADE_UP_REQ:
            msg = new AgentWgtBoxGradeUpReqInfo();
            break;
        case MsgType.AGENT_WGT_BOX_GRADE_UP_ACK:
            msg = new AgentWgtBoxGradeUpAckInfo();
            break;
        case MsgType.AGENT_WGT_CHANGE_TALENT_REQ:
            msg = new AgentWgtChangeTalentReqInfo();
            break;
        case MsgType.AGENT_WGT_CHANGE_TALENT_ACK:
            msg = new AgentWgtChangeTalentAckInfo();
            break;
        case MsgType.AGENT_WGT_SAVE_TALENT_REQ:
            msg = new AgentWgtSaveTalentReqInfo();
            break;
        case MsgType.NBP_DRAW_LEVEL_REWARDS_REQ:
            msg = new NbpDrawLevelRewardsReqInfo();
            break;
        case MsgType.NBP_BUY_EXP_REQ:
            msg = new NbpBuyExpReqInfo();
            break;
        case MsgType.NBP_DRAW_DAILY_TASK_EXP_ACK:
            msg = new NbpDrawDailyTaskExpAckInfo();
            break;
        case MsgType.NBP_CAMPAIGN_INFO_CHANGE_NTF:
            msg = new NbpCampaignInfoChangeNtf();
            break;
        case MsgType.NBP_DRAW_TASK_REWARDS_REQ:
            msg = new NbpDrawTaskRewardsReqInfo();
            break;
        case MsgType.MONOPOLY_ROLL_DICE_REQ:
            msg = new MonopolyRollDiceReqInfo();
            break;
        case MsgType.MONOPOLY_ROLL_DICE_ACK:
            msg = new MonopolyRollDiceAckInfo();
            break;
        case MsgType.MONOPOLY_GET_EXTRA_REWARD_REQ:
            msg = new MonopolyGetExtraRewardReqInfo();
            break;
        case MsgType.KVK_RECYCLE_CENTER_INFO_ACK:
            msg = new KvkRecycleCenterInfo();
            break;
        case MsgType.KVK_PVP_REWARD_CHANGE_NTF:
            msg = new KvkPvpRewardChangeInfo();
            break;
        case MsgType.GET_KVK_SHOP_ACK:
            msg = new KvkShopInfo();
            break;
        case MsgType.KVK_SHOP_REFRESH_ACK:
            msg = new KvkShopInfo();
            break;
        case MsgType.KVK_SHOP_BUY_REQ:
            msg = new KvkShopBuyReqInfo();
            break;
        case MsgType.DELETE_CHARACTER_CHECK_REQ:
            msg = new DeleteCharacterCheckReqInfo();
            break;
        case MsgType.DELETE_CHARACTER_CHECK_ACK:
            msg = new DeleteCharacterCheckAckInfo();
            break;
        case MsgType.DELETE_CHARACTER_REQ:
            msg = new DeleteCharacterReqInfo();
            break;
        case MsgType.GET_PRIVATE_CUSTOM_INFO_REQ:
            msg = new GetPrivateCustomInfoReqInfo();
            break;
        case MsgType.GET_PRIVATE_CUSTOM_INFO_ACK:
            msg = new GetPrivateCustomInfoAckInfo();
            break;
        case MsgType.SET_PRIVATE_CUSTOM_REWARD_REQ:
            msg = new SetPrivateCustomRewardReqInfo();
            break;
        case MsgType.GET_PRIVATE_CUSTOM_REWARD_REQ:
            msg = new GetPrivateCustomRewardReqInfo();
            break;
        case MsgType.GET_PRIVATE_CUSTOM_REWARD_ACK:
            msg = new GetPrivateCustomRewardAckInfo();
            break;
        case MsgType.USER_REFUND_PUNISH_INFO_NTF:
            msg = new UserRefundPunishInfo();
            break;
        case MsgType.EQUIP_MAKE_REQ:
            msg = new EquipMakeReqInfo();
            break;
        case MsgType.EQUIP_MAKE_ACK:
            msg = new EquipMakeAckInfo();
            break;
        case MsgType.EQUIP_CHOOSE_EXCLUSIVE_TALENT_REQ:
            msg = new EquipChooseExclusiveTalentReqInfo();
            break;
        case MsgType.EQUIP_CHOOSE_EXCLUSIVE_TALENT_ACK:
            msg = new EquipChooseExclusiveTalentAckInfo();
            break;
        case MsgType.EQUIP_DECOMPOSE_REQ:
            msg = new EquipDecomposeReqInfo();
            break;
        case MsgType.EQUIP_MATERIAL_TRANSFORM_REQ:
            msg = new EquipMaterialTransformReqInfo();
            break;
        case MsgType.AGENT_WEAR_EQUIP_REQ:
            msg = new AgentWearEquipReqInfo();
            break;
        case MsgType.EQUIP_NTF:
            msg = new EquipNtfInfo();
            break;
        case MsgType.UNLOCK_CITY_SKIN_REQ:
            msg = new UnlockCitySkinReqInfo();
            break;
        case MsgType.LIMITED_EXCHANGE_ITEM_EXCHANGE_REQ:
            msg = new LimitedExchangeItemExchangeReqInfo();
            break;
        case MsgType.LIMITED_EXCHANGE_ITEM_EXCHANGE_ACK:
            msg = new LimitedExchangeItemExchangeAckInfo();
            break;
        case MsgType.LIMITED_EXCHANGE_IAP_LIST_REQ:
            msg = new LimitedExchangeIapListReqInfo();
            break;
        case MsgType.LIMITED_EXCHANGE_IAP_LIST_ACK:
            msg = new LimitedExchangeIapListAckInfo();
            break;
        case MsgType.ABANDONED_ARSENAL_SET_END_AWARD_REQ:
            msg = new AbandonedArsenalSetEndAwardReqInfo();
            break;
        case MsgType.ABANDONED_ARSENAL_OPEN_GRID_REQ:
            msg = new AbandonedArsenalOpenGridReqInfo();
            break;
        case MsgType.ABANDONED_ARSENAL_OPEN_GRID_ACK:
            msg = new AbandonedArsenalOpenGridAckInfo();
            break;
        case MsgType.ABANDONED_ARSENAL_BUY_COST_ITEM_REQ:
            msg = new AbandonedArsenalBuyCostItemReqInfo();
            break;
        case MsgType.ABANDONED_ARSENAL_BUY_COST_ITEM_ACK:
            msg = new AbandonedArsenalBuyCostItemAckInfo();
            break;
        case MsgType.STRANGE_CUBE_SET_CORE_REWARD_REQ:
            msg = new StrangeCubeSetCoreRewardReqInfo();
            break;
        case MsgType.STRANGE_CUBE_OPEN_CUBE_REQ:
            msg = new StrangeCubeOpenCubeReqInfo();
            break;
        case MsgType.STRANGE_CUBE_OPEN_CUBE_ACK:
            msg = new StrangeCubeOpenCubeAckInfo();
            break;
        case MsgType.STRANGE_CUBE_DRAW_EXTRA_REWARD_REQ:
            msg = new StrangeCubeDrawExtraRewardReqInfo();
            break;
        case MsgType.WAR_MARKET_EXCHANGE_REQ:
            msg = new WarMarketExchangeReqInfo();
            break;
        case MsgType.WAR_MARKET_DRAW_REQ:
            msg = new WarMarketDrawReqInfo();
            break;
        case MsgType.WAR_MARKET_DRAW_ACK:
            msg = new WarMarketDrawAckInfo();
            break;
        case MsgType.WAR_MARKET_BUY_BOX_REQ:
            msg = new WarMarketBuyBoxReqInfo();
            break;
        case MsgType.LINE_TASK_GET_TASK_REWARD_REQ:
            msg = new LineTaskGetTaskRewardReqInfo();
            break;
        case MsgType.LINE_TASK_GET_EXTRA_REWARD_REQ:
            msg = new LineTaskGetExtraRewardReqInfo();
            break;
        case MsgType.LEGEND_RECRUIT_NTF:
            msg = new LegendRecruitNtfInfo();
            break;
        case MsgType.LEGEND_RECRUIT_REQ:
            msg = new LegendRecruitReqInfo();
            break;
        case MsgType.LEGEND_RECRUIT_ACK:
            msg = new LegendRecruitAckInfo();
            break;
        case MsgType.LEGEND_RECRUIT_EXCHANGE_OPTIONAL_AWARD_REQ:
            msg = new LegendRecruitExchangeOptionalAwardReqInfo();
            break;
        case MsgType.LEGEND_RECRUIT_SHOP_BUY_REQ:
            msg = new LegendRecruitShopBuyReqInfo();
            break;
        case MsgType.LEGEND_RECRUIT_SHOP_BUY_ACK:
            msg = new LegendRecruitShopBuyAckInfo();
            break;
        case MsgType.LEGEND_RECRUIT_GET_OUTPUT_ACK:
            msg = new LegendRecruitGetOutputAckInfo();
            break;
        case MsgType.SUBMIT_REPORT_REQ:
            msg = new SubmitReportReqInfo();
            break;
        case MsgType.DAILY_FREE_MINI_PACK_NTF:
            msg = new DailyFreeMiniPack();
            break;
        case MsgType.SET_CITY_DECORATION_REQ:
            msg = new SetCityDecorationReqInfo();
            break;
        case MsgType.CITY_DECORATION_NTF:
            msg = new CityDecorationInfo();
            break;
        case MsgType.VOTE_SUBMIT_REQ:
            msg = new VoteSubmitReqInfo();
            break;
        case MsgType.VOTE_SUBMIT_SUGGESTION_REQ:
            msg = new VoteSubmitSuggestionReqInfo();
            break;
        case MsgType.CITY_DECORATION_LIST_NTF:
            msg = new CityDecorationList();
            break;
        case MsgType.BOSS_CAMPAIGN_CLAIM_ALL_SERVER_REWARD_REQ:
            msg = new BossCampaignClaimAllServerRewardReqInfo();
            break;
        case MsgType.USER_GET_NEW_CITY_DECORATION_NTF:
            msg = new UserGetNewCityDecorationInfo();
            break;
        case MsgType.RECYCLE_ATY_RECYCLE_REQ:
            msg = new RecycleAtyRecycleReqInfo();
            break;
        case MsgType.RECYCLE_ATY_EXCHANGE_REQ:
            msg = new RecycleAtyExchangeReqInfo();
            break;
        case MsgType.AGENT_TALENT_SCHEME_UNLOCK_REQ:
            msg = new AgentTalentSchemeUnlockReqInfo();
            break;
        case MsgType.AGENT_TALENT_SCHEME_APPLY_REQ:
            msg = new AgentTalentSchemeApplyReqInfo();
            break;
        case MsgType.AGENT_TALENT_SCHEME_RENAME_REQ:
            msg = new AgentTalentSchemeRenameReqInfo();
            break;
        case MsgType.ALLIANCE_TREASURE_RECEIVE_AS_REWARD_REQ:
            msg = new AllianceTreasureReceiveAsRewardReqInfo();
            break;
        case MsgType.ALLIANCE_TREASURE_RECEIVE_PLAYER_REWARD_REQ:
            msg = new AllianceTreasureReceivePlayerRewardReqInfo();
            break;
        case MsgType.ALLIANCE_TREASURE_RED_POINT_NTF:
            msg = new AllianceTreasureRedPointInfo();
            break;
        case MsgType.WAR_MARKET_REFRESH_DISCOUNT_ACK:
            msg = new WarMarketRefreshDiscountAckInfo();
            break;
        case MsgType.WAR_MARKET_GET_OUTPUT_ACK:
            msg = new WarMarketGetOutputAckInfo();
            break;
        case MsgType.PLAYER_RETURN_EVENT_NTF:
            msg = new PlayerReturnEventNtfInfo();
            break;
        case MsgType.PLAYER_RETURN_EVENT_TASK_NTF:
            msg = new PlayerReturnEventTaskNtfInfo();
            break;
        case MsgType.PLAYER_RETURN_EVENT_LOGIN_REWARD_REQ:
            msg = new PlayerReturnEventLoginRewardReqInfo();
            break;
        case MsgType.PLAYER_RETURN_EVENT_TASK_REWARD_REQ:
            msg = new PlayerReturnEventTaskRewardReqInfo();
            break;
        case MsgType.HERO_OPTIONAL_PKG_ACK:
            msg = new HeroOptionalPkgAckInfo();
            break;
        case MsgType.HERO_OPTIONAL_PKG_CHANGE_NTF:
            msg = new HeroOptionalPkgChangeNtfInfo();
            break;
        case MsgType.RECYCLE_ITEM_REQ:
            msg = new RecycleItemReqInfo();
            break;
        case MsgType.WARSHIP_WEAPON_MAKE_REQ:
            msg = new WarshipWeaponMakeReqInfo();
            break;
        case MsgType.WARSHIP_WEAPON_SELL_REQ:
            msg = new WarshipWeaponSellReqInfo();
            break;
        case MsgType.WARSHIP_WEAPON_PURIFY_CONFIRM_REQ:
            msg = new WarshipWeaponPurifyConfirmReqInfo();
            break;
        case MsgType.WARSHIP_WEAPON_NTF:
            msg = new WarshipWeaponNtfInfo();
            break;
        case MsgType.WARSHIP_WEAR_WEAPON_REQ:
            msg = new WarshipWearWeaponReqInfo();
            break;
        case MsgType.USER_WARSHIP_WEAPON_NTF:
            msg = new UserWarshipWeaponNtfInfo();
            break;
        case MsgType.WARSHIP_WEAPON_SHOP_BUY_REQ:
            msg = new WarshipWeaponShopBuyReqInfo();
            break;
        case MsgType.QUESTION_ANSWER_START_REQ:
            msg = new QuestionAnswerStartReqInfo();
            break;
        case MsgType.QUESTION_ANSWER_START_ACK:
            msg = new QuestionAnswerStartAckInfo();
            break;
        case MsgType.QUESTION_ANSWER_COMMIT_REQ:
            msg = new QuestionAnswerCommitReqInfo();
            break;
        case MsgType.QUESTION_ANSWER_COMMIT_ACK:
            msg = new QuestionAnswerCommitAckInfo();
            break;
        case MsgType.QUESTION_ANSWER_REWARD_REQ:
            msg = new QuestionAnswerRewardReqInfo();
            break;
        case MsgType.QUESTION_ANSWER_STEP_CHANGE_NTF:
            msg = new QuestionAnswerStepChangeNtfInfo();
            break;
        case MsgType.FLIP_CARD_REQ:
            msg = new FlipCardReqInfo();
            break;
        case MsgType.FLIP_CARD_ACK:
            msg = new FlipCardAckInfo();
            break;
        case MsgType.FLIP_CARD_PICK_REWARD_REQ:
            msg = new FlipCardPickRewardReqInfo();
            break;
        case MsgType.FLIP_CARD_NEXT_LAYER_ACK:
            msg = new FlipCardNextLayerAckInfo();
            break;
        case MsgType.FLIP_CARD_GET_EXTRA_REWARD_REQ:
            msg = new FlipCardGetExtraRewardReqInfo();
            break;
        case MsgType.COLLECT_AGENT_REQ:
            msg = new CollectAgentReqInfo();
            break;
        case MsgType.SUBMARINE_NTF:
            msg = new SubmarineNtfInfo();
            break;
        case MsgType.SUBMARINE_EXPLORE_REQ:
            msg = new SubmarineExploreReqInfo();
            break;
        case MsgType.SUBMARINE_EXPLORE_ACK:
            msg = new SubmarineExploreAckInfo();
            break;
        case MsgType.VALOR_SHOP_NTF:
            msg = new ValorShopNtfInfo();
            break;
        case MsgType.VALOR_SHOP_BUY_REQ:
            msg = new ValorShopBuyReqInfo();
            break;
        case MsgType.SET_BATTLE_BANNER_REQ:
            msg = new SetBattleBannerReqInfo();
            break;
        case MsgType.BATTLE_BANNER_NTF:
            msg = new BattleBannerInfo();
            break;
        case MsgType.USER_GET_NEW_BATTLE_BANNER_NTF:
            msg = new BattleBannerInfo();
            break;
        case MsgType.BATTLE_BANNER_LIST_NTF:
            msg = new BattleBannerList();
            break;
        case MsgType.AGENT_BREAKTHROUGH_LEVEL_UP_REQ:
            msg = new AgentBreakthroughLevelUpReqInfo();
            break;
        case MsgType.AGENT_SKILL_RESET_BREAKTHROUGH_LEVEL_REQ:
            msg = new AgentSkillResetBreakthroughLevelReqInfo();
            break;
        case MsgType.RAID_SET_SLOT_ARMY_REQ:
            msg = new RaidSetSlotArmyReqInfo();
            break;
        case MsgType.RAID_CHALLENGE_REQ:
            msg = new RaidChallengeReqInfo();
            break;
        case MsgType.RAID_CHALLENGE_ACK:
            msg = new RaidChallengeAckInfo();
            break;
        case MsgType.RAID_CHOOSE_EFFECT_REQ:
            msg = new RaidChooseEffectReqInfo();
            break;
        case MsgType.CUMULATIVE_CHARGE_AWD_ACK:
            msg = new CumulativeChargeInfo();
            break;
        case MsgType.TRACKING_FTE_REQ:
            msg = new TrackingFteInfo();
            break;
        case MsgType.RAID_CHALLENGE_FIGHT_DETAIL_NTF:
            msg = new RaidChallengeFightDetailInfo();
            break;
        case MsgType.RAID_CHALLENGE_FIGHT_STAT_NTF:
            msg = new RaidChallengeFightStatInfo();
            break;
        case MsgType.RAID_HISTORY_REQ:
            msg = new RaidHistoryReqInfo();
            break;
        case MsgType.RAID_HISTORY_ACK:
            msg = new RaidHistoryAckInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_UNLOCK_REQ:
            msg = new MuseumArtifactUnlockReqInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_STAR_UP_REQ:
            msg = new MuseumArtifactStarUpReqInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_DISPLAY_REQ:
            msg = new MuseumArtifactDisplayReqInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_LOTTERY_REQ:
            msg = new MuseumArtifactLotteryReqInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_LOTTERY_ACK:
            msg = new MuseumArtifactLotteryAckInfo();
            break;
        case MsgType.MUSEUM_NTF:
            msg = new MuseumInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_NTF:
            msg = new MuseumArtifactInfo();
            break;
        case MsgType.MUSEUM_ARTIFACT_CONVERT_NTF:
            msg = new MuseumArtifactConvertInfo();
            break;
        case MsgType.OVERTURN_START_EXPLORE_ACK:
            msg = new OverturnStartExploreAckInfo();
            break;
        case MsgType.OVERTURN_FLIP_REQ:
            msg = new OverturnFlipReqInfo();
            break;
        case MsgType.OVERTURN_FLIP_ACK:
            msg = new OverturnFlipAckInfo();
            break;
        case MsgType.OVERTURN_BATTLE_PASSPORT_DRAW_REWARD_REQ:
            msg = new OverturnBattlePassportDrawRewardReqInfo();
            break;
        case MsgType.OVERTURN_SHOP_BUY_REQ:
            msg = new OverturnShopBuyReqInfo();
            break;
        case MsgType.ITEM_UPGRADE_REQ:
            msg = new ItemUpgradeReqInfo();
            break;
        case MsgType.ITEM_UPGRADE_NTF:
            msg = new ItemUpgradeNtfInfo();
            break;
        case MsgType.WANTED_INFO_NTF:
            msg = new WantedInfoNtf();
            break;
        case MsgType.UNLOCK_TROOP_SKIN_REQ:
            msg = new UnlockTroopSkinReqInfo();
            break;
        case MsgType.SET_TROOP_SKIN_REQ:
            msg = new SetTroopSkinReqInfo();
            break;
        case MsgType.TROOP_SKIN_NTF:
            msg = new TroopSkinInfo();
            break;
        case MsgType.USER_GET_NEW_TROOP_SKIN_NTF:
            msg = new TroopSkinInfo();
            break;
        case MsgType.TROOP_SKIN_LIST_NTF:
            msg = new TroopSkinList();
            break;
        case MsgType.SET_SELECTED_CITY_SKIN_REQ:
            msg = new SetSelectedCitySkinReqInfo();
            break;
        case MsgType.AGENT_SHOP_BUY_REQ:
            msg = new AgentShopBuyReqInfo();
            break;
        case MsgType.AGENT_SHOP_NTF:
            msg = new AgentShopInfo();
            break;
        case MsgType.FRIEND_INFO_ACK:
            msg = new FriendInfoAckInfo();
            break;
        case MsgType.FRIEND_APPLY_INFO_ACK:
            msg = new FriendApplyInfoAckInfo();
            break;
        case MsgType.FRIEND_APPLY_REQ:
            msg = new FriendApplyReqInfo();
            break;
        case MsgType.FRIEND_APPLY_MANAGE_REQ:
            msg = new FriendApplyManageReqInfo();
            break;
        case MsgType.FRIEND_CHANGE_NTF:
            msg = new FriendChangeNtfInfo();
            break;
        case MsgType.FRIEND_APPLY_CHANGE_NTF:
            msg = new FriendApplyChangeNtfInfo();
            break;
        case MsgType.FRIEND_DELETE_REQ:
            msg = new FriendDeleteReqInfo();
            break;
        case MsgType.FRIEND_SEARCH_USER_REQ:
            msg = new FriendSearchUserReqInfo();
            break;
        case MsgType.FRIEND_SEARCH_USER_ACK:
            msg = new FriendSearchUserAckInfo();
            break;
        case MsgType.FRIEND_SHOP_BUY_REQ:
            msg = new FriendShopBuyReqInfo();
            break;
        case MsgType.FRIEND_SHOP_NTF:
            msg = new FriendShopInfo();
            break;
        case MsgType.CHAIN_GIFTS_RECEIVE_NORMAL_REWARD_REQ:
            msg = new ChainGiftsReceiveNormalRewardReqInfo();
            break;
        case MsgType.CHAIN_GIFTS_RECEIVE_ADDITIONAL_REWARD_REQ:
            msg = new ChainGiftsReceiveAdditionalRewardReqInfo();
            break;
        case MsgType.PUZZLE_CAMPAIGN_PUZZLE_INFO_NTF:
            msg = new PuzzleCampaignPuzzleInfo();
            break;
        case MsgType.PUZZLE_DRAW_REQ:
            msg = new PuzzleDrawReqInfo();
            break;
        case MsgType.PUZZLE_DRAW_ACK:
            msg = new PuzzleDrawAckInfo();
            break;
        case MsgType.AGENT_EQUIP_ENHANCE_REQ:
            msg = new AgentEquipEnhanceReqInfo();
            break;
        case MsgType.AGENT_EQUIP_ENHANCE_ACK:
            msg = new AgentEquipEnhanceAckInfo();
            break;
        case MsgType.AGENT_EQUIP_RESET_ENHANCE_REQ:
            msg = new AgentEquipResetEnhanceReqInfo();
            break;
        case MsgType.AGENT_EQUIP_RESET_ENHANCE_ACK:
            msg = new AgentEquipResetEnhanceAckInfo();
            break;
        case MsgType.AGENT_EQUIP_PURIFY_REQ:
            msg = new AgentEquipPurifyReqInfo();
            break;
        case MsgType.AGENT_EQUIP_PURIFY_ACK:
            msg = new AgentEquipPurifyAckInfo();
            break;
        case MsgType.SET_HOME_BACKGROUND_REQ:
            msg = new SetHomeBackgroundReqInfo();
            break;
        case MsgType.HOME_BACKGROUND_NTF:
            msg = new HomeBackgroundInfo();
            break;
        case MsgType.USER_GET_NEW_HOME_BACKGROUND_NTF:
            msg = new HomeBackgroundInfo();
            break;
        case MsgType.HOME_BACKGROUND_LIST_NTF:
            msg = new HomeBackgroundList();
            break;
        case MsgType.SET_HOME_EFFECT_REQ:
            msg = new SetHomeEffectReqInfo();
            break;
        case MsgType.HOME_EFFECT_NTF:
            msg = new HomeEffectInfo();
            break;
        case MsgType.USER_GET_NEW_HOME_EFFECT_NTF:
            msg = new HomeEffectInfo();
            break;
        case MsgType.HOME_EFFECT_LIST_NTF:
            msg = new HomeEffectList();
            break;
        case MsgType.SET_TROOP_TAIL_SKIN_REQ:
            msg = new SetTroopTailSkinReqInfo();
            break;
        case MsgType.TROOP_TAIL_SKIN_NTF:
            msg = new TroopTailSkinInfo();
            break;
        case MsgType.USER_GET_NEW_TROOP_TAIL_SKIN_NTF:
            msg = new TroopTailSkinInfo();
            break;
        case MsgType.TROOP_TAIL_SKIN_LIST_NTF:
            msg = new TroopTailSkinList();
            break;
        case MsgType.ASSET_CONVERT_TO_ITEM_NTF:
            msg = new AssetConvertToItemNtfInfo();
            break;
        case MsgType.SET_BASE_TELEPORT_EFFECT_REQ:
            msg = new SetBaseTeleportEffectReqInfo();
            break;
        case MsgType.BASE_TELEPORT_EFFECT_NTF:
            msg = new BaseTeleportEffectInfo();
            break;
        case MsgType.USER_GET_NEW_BASE_TELEPORT_EFFECT_NTF:
            msg = new BaseTeleportEffectInfo();
            break;
        case MsgType.BASE_TELEPORT_EFFECT_LIST_NTF:
            msg = new BaseTeleportEffectList();
            break;
        case MsgType.SIGN_IN_CAMPAIGN_SIGN_IN_ACK:
            msg = new SignInCampaignSignInAckInfo();
            break;
        case MsgType.SIGN_IN_CAMPAIGN_RESIGN_IN_ACK:
            msg = new SignInCampaignSignInAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_DETAILS_REQ:
            msg = new VideoChannelGetVideoDetailsReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_DETAILS_ACK:
            msg = new VideoChannelGetVideoDetailsAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_COMMIT_VIDEO_REQ:
            msg = new VideoChannelCommitVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DELETE_VIDEO_REQ:
            msg = new VideoChannelDeleteVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REFRESH_VIDEO_ACCESS_STATUS_REQ:
            msg = new VideoChannelRefreshVideoAccessStatusReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_LIKE_VIDEO_REQ:
            msg = new VideoChannelLikeVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DISLIKE_VIDEO_REQ:
            msg = new VideoChannelDislikeVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_VIEW_VIDEO_REQ:
            msg = new VideoChannelViewVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REPORT_VIDEO_REQ:
            msg = new VideoChannelReportVideoReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_COMMENT_LIST_REQ:
            msg = new VideoChannelGetVideoCommentListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_COMMENT_LIST_ACK:
            msg = new VideoChannelGetVideoCommentListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_COMMIT_VIDEO_COMMENT_REQ:
            msg = new VideoChannelCommitVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_COMMIT_VIDEO_COMMENT_ACK:
            msg = new VideoChannelCommitVideoCommentAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REPLY_VIDEO_COMMENT_REQ:
            msg = new VideoChannelReplyVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REPLY_VIDEO_COMMENT_ACK:
            msg = new VideoChannelReplyVideoCommentAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DELETE_VIDEO_COMMENT_REQ:
            msg = new VideoChannelDeleteVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DELETE_VIDEO_COMMENT_ACK:
            msg = new VideoChannelDeleteVideoCommentAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_LIKE_VIDEO_COMMENT_REQ:
            msg = new VideoChannelLikeVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_LIKE_VIDEO_COMMENT_ACK:
            msg = new VideoChannelLikeVideoCommentAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DISLIKE_VIDEO_COMMENT_REQ:
            msg = new VideoChannelDislikeVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_DISLIKE_VIDEO_COMMENT_ACK:
            msg = new VideoChannelDislikeVideoCommentAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_REWARD_CLAIM_HISTORY_REQ:
            msg = new VideoChannelGetRewardClaimHistoryReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_REWARD_CLAIM_HISTORY_ACK:
            msg = new VideoChannelGetRewardClaimHistoryAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_CLAIM_REWARD_ACK:
            msg = new VideoChannelClaimRewardAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_CREATOR_RANK_REQ:
            msg = new VideoChannelGetVideoCreatorRankReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_CREATOR_RANK_ACK:
            msg = new VideoChannelGetVideoCreatorRankAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_POPULAR_VIDEO_LIST_REQ:
            msg = new VideoChannelGetPopularVideoListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_POPULAR_VIDEO_LIST_ACK:
            msg = new VideoChannelGetPopularVideoListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_NEW_VIDEO_LIST_REQ:
            msg = new VideoChannelGetNewVideoListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_NEW_VIDEO_LIST_ACK:
            msg = new VideoChannelGetNewVideoListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_TAG_VIDEO_LIST_REQ:
            msg = new VideoChannelGetTagVideoListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_TAG_VIDEO_LIST_ACK:
            msg = new VideoChannelGetTagVideoListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_USER_VIDEO_STATS_REQ:
            msg = new VideoChannelGetUserVideoStatsReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_USER_VIDEO_STATS_ACK:
            msg = new VideoChannelGetUserVideoStatsAck();
            break;
        case MsgType.VIDEO_CHANNEL_GET_USER_VIDEO_LIST_REQ:
            msg = new VideoChannelGetUserVideoListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_USER_VIDEO_LIST_ACK:
            msg = new VideoChannelGetUserVideoListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_SHOP_DATA_ACK:
            msg = new VideoChannelGetShopDataAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_BUY_SHOP_GOODS_REQ:
            msg = new VideoChannelBuyShopGoodsReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_SHOP_BUY_LOG_REQ:
            msg = new VideoChannelGetShopBuyLogReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_SHOP_BUY_LOG_ACK:
            msg = new VideoChannelGetShopBuyLogAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_DEMAND_REQ:
            msg = new VideoChannelGetVideoDemandReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_VIDEO_DEMAND_ACK:
            msg = new VideoChannelGetVideoDemandAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REPORT_VIDEO_COMMENT_REQ:
            msg = new VideoChannelReportVideoCommentReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_REFRESH_VIDEO_ACCESS_STATUS_ACK:
            msg = new VideoChannelRefreshVideoAccessStatusAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_COMMIT_VIDEO_ACK:
            msg = new VideoChannelCommitVideoAckInfo();
            break;
        case MsgType.WEAR_MEDAL_REQ:
            msg = new WearMedalReqInfo();
            break;
        case MsgType.USER_GET_NEW_MEDAL_NTF:
            msg = new UserMedalInfo();
            break;
        case MsgType.USER_WEAR_MEDAL_LIST_NTF:
            msg = new UserMedalList();
            break;
        case MsgType.USER_MEDAL_LIST_NTF:
            msg = new UserMedalList();
            break;
        case MsgType.USER_MEDAL_QUEST_LIST_NTF:
            msg = new UserMedalQuestList();
            break;
        case MsgType.USER_MEDAL_CHANGE_QUEST_LIST_NTF:
            msg = new UserMedalQuestList();
            break;
        case MsgType.VIDEO_CHANNEL_GET_SUBCHANNEL_CANDIDATE_VIDEO_LIST_REQ:
            msg = new VideoChannelGetSubchannelCandidateVideoListReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_GET_SUBCHANNEL_CANDIDATE_VIDEO_LIST_ACK:
            msg = new VideoChannelGetSubchannelCandidateVideoListAckInfo();
            break;
        case MsgType.VIDEO_CHANNEL_ADD_VIDEO_TO_SUBCHANNEL_REQ:
            msg = new VideoChannelAddVideoToSubchannelReqInfo();
            break;
        case MsgType.VIDEO_CHANNEL_TAKE_DOWN_VIDEO_FROM_SUBCHANNEL_REQ:
            msg = new VideoChannelTakeDownVideoFromSubchannelReqInfo();
            break;
        case MsgType.GET_KVK_STRATEGY_ACK:
            msg = new KvkStrategyInfo();
            break;
        case MsgType.KVK_STRATEGY_CHANGE_REQ:
            msg = new KvkStrategyChangeReqInfo();
            break;
        case MsgType.KVK_STRATEGY_CHANGE_ACK:
            msg = new KvkStrategyChangeAckInfo();
            break;
        case MsgType.TRACKING_CHAT_REQ:
            msg = new TrackingChatReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_WHEEL_ROLL_REQ:
            msg = new WheelCampaignRollReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_WHEEL_ROLL_ACK:
            msg = new WheelCampaignRollAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_WHEEL_EXTRA_REWARD_REQ:
            msg = new WheelCampaignExtraRewardReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_TASK_REWARD_REQ:
            msg = new ProgressiveTaskRewardReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_INFO_NTF:
            msg = new NewReturnEventBaseInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_TASK_DATA_ACK:
            msg = new NewReturnEventGetTaskDataAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_DROP_DATA_ACK:
            msg = new NewReturnEventGetDropDataAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_WHEEL_DATA_ACK:
            msg = new NewReturnEventGetWheelDataAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_SHOP_DATA_ACK:
            msg = new NewReturnEventGetShopDataAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_PACKAGE_DATA_ACK:
            msg = new NewReturnEventGetPackageDataAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_PACKAGE_FREE_REWARD_REQ:
            msg = new NewReturnEventGetPackageFreeRewardReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_GET_PACKAGE_FREE_REWARD_ACK:
            msg = new NewReturnEventGetPackageFreeRewardAckInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_TASK_INFO_NTF:
            msg = new BaseTaskCampaignInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_REDPOINT_NTF:
            msg = new NewReturnEventRedpointInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_SHOP_EXCHANGE_REQ:
            msg = new CampaignReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_TUTORIAL_STEP_REQ:
            msg = new NewReturnEventTutorialStepReqInfo();
            break;
        case MsgType.NEW_RETURN_EVENT_TASK_FINAL_REWARD_NTF:
            msg = new ProgressiveTaskCampaignFinalRewardStatusInfo();
            break;
        case MsgType.COMMON_ACK:
            msg = new CommonAckInfo();
            break;
        case MsgType.ECHO_REQ:
            msg = new EchoInfo();
            break;
        case MsgType.ECHO_ACK:
            msg = new EchoInfo();
            break;
        case MsgType.SHUT_DOWN_NTF:
            msg = new ShutDownMessage();
            break;
        case MsgType.CHAT_TOKEN_NTF:
            msg = new ChatToken();
            break;
        case MsgType.GM_CMD_REQ:
            msg = new GmCmdReq();
            break;
        case MsgType.GM_CMD_ACK:
            msg = new GmCmdInfo();
            break;
        case MsgType.ONLINE_USERS_REQ:
            msg = new OnlineUsersReq();
            break;
        case MsgType.ONLINE_USERS_ACK:
            msg = new OnlineUsersInfo();
            break;
        case MsgType.SESSION_TOKEN_NTF:
            msg = new SessionTokenInfo();
            break;
        case MsgType.GATE_CMD_REQ:
            msg = new GmCmdReq();
            break;
        case MsgType.CONNECT_KICK_NTF:
            msg = new ConnectKickInfo();
            break;
        case MsgType.CENTER_CMD_REQ:
            msg = new CenterCmdReq();
            break;
        case MsgType.MAIL_CMD_REQ:
            msg = new CenterCmdReq();
            break;
        case MsgType.CS_DY_CONTROL_REQ:
            msg = new CsDyControlInfo();
            break;
        case MsgType.LOGIN_CMD_REQ:
            msg = new LoginCmdReq();
            break;
        case MsgType.ACTIVITY_CMD_REQ:
            msg = new ActivityCmdReq();
            break;
        case MsgType.TIME_NTF:
            msg = new TimeNtfInfo();
            break;
        }

        if (msg != null) {
            msg.SetMessageType(type);
        }
        return msg;
    }
}
