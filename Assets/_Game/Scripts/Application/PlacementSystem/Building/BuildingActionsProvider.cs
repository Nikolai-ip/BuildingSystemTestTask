namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingActionsProvider : IBuildingActionsProvider
    {
        private BuildingFSM _fsm;

        public BuildingActionsProvider(BuildingFSM fsm)
        {
            _fsm = fsm;
        }

        public void EditBuilding()
        {
            _fsm.SetState(BuildingState.Edit);
        }

        public void DeleteBuilding()
        {
            _fsm.SetState(BuildingState.Remove);
        }
    }
}