using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Application.PlacementSystem.Building.UpgradeFeature;

namespace _Game.Source.Application.PlacementSystem.Building
{
    public class BuildingActionsProvider : IBuildingActionsProvider
    {
        private readonly BuildingFSM _fsm;
        private readonly IBuildingUpgrader _buildingUpgrader;

        public BuildingActionsProvider(BuildingFSM fsm, IBuildingUpgrader buildingUpgrader)
        {
            _fsm = fsm;
            _buildingUpgrader = buildingUpgrader;
        }

        public void EditBuilding()
        {
            _fsm.SetState(BuildingState.Edit);
        }

        public void DeleteBuilding()
        {
            _fsm.SetState(BuildingState.Remove);
        }

        public void UpgradeBuilding()
        {
            _buildingUpgrader.Upgrade();
        }
    }
}