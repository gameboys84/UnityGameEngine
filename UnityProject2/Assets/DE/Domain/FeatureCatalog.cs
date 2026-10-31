namespace DE.Domain
{
    public enum FeatureCoverage { MockPrototype, NotMigrated, ExternalDependency, DisabledLegacy }
    public sealed class FeatureDefinition
    {
        public string Id { get; } public string Name { get; } public FeatureCoverage Coverage { get; } public string Description { get; }
        public FeatureDefinition(string id, string name, FeatureCoverage coverage, string description)
        { Id = id; Name = name; Coverage = coverage; Description = description; }
    }
    public static class FeatureCatalog
    {
        private static readonly FeatureDefinition[] entries = {
            new FeatureDefinition("city", "City & construction", FeatureCoverage.MockPrototype, "Upgrade prerequisites, shared construction queue, cancellation and resource previews. Mock fixtures; original 3D city and all building functions pending."),
            new FeatureDefinition("research", "Research", FeatureCoverage.MockPrototype, "Two fixture technologies with prerequisites and a shared research queue; production technology tree pending."),
            new FeatureDefinition("training", "Troop training", FeatureCoverage.MockPrototype, "Jeep/tank fixture training, costs and queue completion; repair/promotion/production troop tables pending."),
            new FeatureDefinition("queues", "Queues & acceleration", FeatureCoverage.MockPrototype, "Mock authority completion, half refund on cancellation, diamond/item acceleration; alliance help and production formulas pending."),
            new FeatureDefinition("inventory", "Inventory", FeatureCoverage.MockPrototype, "Food crates and speedup fixture items with atomic application; production item effects, synthesis and recycling pending."),
            new FeatureDefinition("mail", "Mail", FeatureCoverage.MockPrototype, "Read and reward claim with request idempotency; production categories, attachments and battle reports pending."),
            new FeatureDefinition("chat", "Chat", FeatureCoverage.MockPrototype, "Local Mock channels and validation only; networking, moderation, translation, voice and social SDK pending."),
            new FeatureDefinition("world", "World & marching", FeatureCoverage.MockPrototype, "Six fixture nodes, troop reservation, recall and authority-driven return/reward; real map visibility, gathering, PvP and 3D assets pending."),
            new FeatureDefinition("account", "Account & session", FeatureCoverage.MockPrototype, "Account/generation isolation and stale response rejection; authentication, binding, character selection and migration pending."),
            new FeatureDefinition("agents", "Officers", FeatureCoverage.NotMigrated, "Agent progression, star/rank/skill/talent, equipment and 3D room not migrated."),
            new FeatureDefinition("quests", "Quests", FeatureCoverage.NotMigrated, "Main, chapter, daily quests and milestones not migrated."),
            new FeatureDefinition("alliance", "Alliance", FeatureCoverage.NotMigrated, "Membership, permissions, help, technology, gifts, territory and rally not migrated."),
            new FeatureDefinition("combat", "Combat & FPS", FeatureCoverage.NotMigrated, "Battle round playback, reports, FPS activities and survival scenes not migrated."),
            new FeatureDefinition("battlefields", "GVG / KVK / Arena / Expedition / Raid", FeatureCoverage.NotMigrated, "Battlefield node routing, map isolation, formations and mode-specific settlement not migrated."),
            new FeatureDefinition("warships", "Warships & submarine", FeatureCoverage.NotMigrated, "Ships, submarine, ship weapons, workshop, flags and train station not migrated."),
            new FeatureDefinition("equipment", "Officer weapons & gear", FeatureCoverage.NotMigrated, "Weapon, gear, materials and crafting not migrated."),
            new FeatureDefinition("collection", "Commander & collections", FeatureCoverage.NotMigrated, "Commander, dispatch, museum, medal wall and archive not migrated."),
            new FeatureDefinition("government", "Government & defence", FeatureCoverage.NotMigrated, "Mayor, headquarters institution, defence, radar, city skins and warning not migrated."),
            new FeatureDefinition("social", "Rankings & social", FeatureCoverage.NotMigrated, "Rankings, friends, blacklist and server social features not migrated."),
            new FeatureDefinition("stores", "Recruitment / stores / passes", FeatureCoverage.NotMigrated, "Recruitment, integration/KVK stores, three pass families and exchange not migrated."),
            new FeatureDefinition("activities", "Activities", FeatureCoverage.NotMigrated, "Individual ActivityData families, lifecycle, gates, rewards, skins and IAP coupling require per-activity migration."),
            new FeatureDefinition("tutorial", "Tutorial & HUD gates", FeatureCoverage.NotMigrated, "Persistent tutorial progress, forced interaction, popup arbitration and red dots not migrated."),
            new FeatureDefinition("iap", "IAP & SDK", FeatureCoverage.ExternalDependency, "No real purchases, receipts, acknowledgement, billing SDK or reconciliation implemented."),
            new FeatureDefinition("settings", "Settings / localization / audio", FeatureCoverage.NotMigrated, "Production language tables/font fallback, music/SFX rules and persistent settings not migrated."),
            new FeatureDefinition("operations", "Notifications / support / analytics", FeatureCoverage.ExternalDependency, "No third-party notification, customer support or analytics service connected."),
            new FeatureDefinition("network", "Legacy server protocol", FeatureCoverage.ExternalDependency, "No old-server authentication, protocol schema, Pike/LZ4 transport or service compatibility claimed."),
            new FeatureDefinition("updates", "Resources / code updates / platforms", FeatureCoverage.NotMigrated, "Foundation startup retained; DE update channels, production asset bundles, AOT/hotupdate and devices unverified."),
            new FeatureDefinition("video", "VideoChannel", FeatureCoverage.DisabledLegacy, "Legacy entry mostly disabled; not migrated and not silently treated as removed.")
        };
        public static FeatureDefinition[] All => (FeatureDefinition[])entries.Clone();
    }
}
