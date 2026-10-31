using System;

namespace DE.Domain
{
    // Fixture rules for the explicitly labelled Mock environment, not DE production balance data.
    public static class DeRules
    {
        public static OperationPreview Preview(DeSnapshot state, DeCommand command)
        {
            if (state == null || command == null) return Fail("invalid_command", "A state and command are required.");
            if (string.IsNullOrWhiteSpace(command.RequestId)) return Fail("invalid_request", "Request id is required.");
            if (command.Quantity < 1 || command.Quantity > 10000) return Fail("invalid_quantity", "Quantity must be between 1 and 10000.");
            var costs = new ResourceCost[0]; long duration = 0; string group = "";
            if (command.Kind == DeCommandKind.StartBuildingUpgrade)
            {
                BuildingSnapshot building = Array.Find(state.Buildings, v => v.Id == command.TargetId);
                if (building == null) return Fail("unknown_building", "Unknown building.");
                if (command.Quantity != 1) return Fail("invalid_quantity", "Upgrade one building at a time.");
                if (building.Level >= building.MaximumLevel) return Fail("maximum_level", "Maximum building level reached.");
                int next = building.Level + 1;
                if (building.Id != "hq" && state.GetBuildingLevel("hq") < next + 1)
                    return Fail("prerequisite_missing", "Requires Headquarters level " + (next + 1) + ".");
                if (building.Id == "hq" && next > 2 && state.GetBuildingLevel("lab") < next - 2)
                    return Fail("prerequisite_missing", "Requires Laboratory level " + (next - 2) + ".");
                costs = new[] { new ResourceCost("food", 120L * next), new ResourceCost("energy", 80L * next) };
                duration = 10000L * next; group = "Building";
            }
            else if (command.Kind == DeCommandKind.StartResearch)
            {
                ResearchSnapshot research = Array.Find(state.Research, v => v.Id == command.TargetId);
                if (research == null) return Fail("unknown_research", "Unknown research.");
                if (command.Quantity != 1) return Fail("invalid_quantity", "Research one level at a time.");
                if (research.Level >= research.MaximumLevel) return Fail("maximum_level", "Maximum research level reached.");
                int next = research.Level + 1;
                if (state.GetBuildingLevel("lab") < next) return Fail("prerequisite_missing", "Requires Laboratory level " + next + ".");
                costs = new[] { new ResourceCost("food", 150L * next), new ResourceCost("energy", 100L * next), new ResourceCost("oil", 40L * next) };
                duration = 12000L * next; group = "Research";
            }
            else if (command.Kind == DeCommandKind.TrainTroops)
            {
                TroopSnapshot troop = Array.Find(state.Troops, v => v.Id == command.TargetId);
                if (troop == null) return Fail("unknown_troop", "Unknown troop type.");
                if (state.GetBuildingLevel("barracks") < 1) return Fail("prerequisite_missing", "Requires Barracks level 1.");
                if (troop.Id == "tank" && state.GetResearchLevel("leadership") < 1) return Fail("prerequisite_missing", "Requires Leadership research level 1.");
                costs = new[] { new ResourceCost("food", 25L * command.Quantity), new ResourceCost("steel", 10L * command.Quantity) };
                duration = 3000L * command.Quantity; group = "Training";
            }
            else return new OperationPreview(true, "preview_unavailable", "Authority validates this command.");
            foreach (var queue in state.Queues) if (queue.Kind == group) return new OperationPreview(false, "queue_full", group + " queue is occupied.", duration, costs);
            foreach (var cost in costs) if (state.GetResource(cost.Key) < cost.Amount) return new OperationPreview(false, "insufficient_resources", "Insufficient " + cost.Key + ".", duration, costs);
            return new OperationPreview(true, "ready", "Ready. Values are Mock fixtures.", duration, costs);
        }
        private static OperationPreview Fail(string code, string message) { return new OperationPreview(false, code, message); }
    }
}
