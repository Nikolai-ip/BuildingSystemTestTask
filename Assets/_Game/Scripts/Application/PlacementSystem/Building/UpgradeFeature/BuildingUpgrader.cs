namespace _Game.Scripts.Application.PlacementSystem.Building.UpgradeFeature
{
    public class BuildingUpgrader : IBuildingUpgrader
    {
        private readonly BuildingDataComponent _buildingDataComponent;

        public BuildingUpgrader(BuildingDataComponent buildingDataComponent)
        {
            _buildingDataComponent = buildingDataComponent;
        }

        public void Upgrade()
        {
            _buildingDataComponent.BuildingParams.Level++;
        }
    }
}