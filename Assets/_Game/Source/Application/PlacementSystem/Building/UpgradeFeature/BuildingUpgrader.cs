using System;

namespace _Game.Source.Application.PlacementSystem.Building.UpgradeFeature
{
    public class BuildingUpgrader : IBuildingUpgrader
    {
        private readonly BuildingDataComponent _buildingDataComponent;
        public event Action OnUpgraded;
        public BuildingUpgrader(BuildingDataComponent buildingDataComponent)
        {
            _buildingDataComponent = buildingDataComponent;
        }

        public void Upgrade()
        {
            _buildingDataComponent.BuildingParams.Level++;
            OnUpgraded?.Invoke();
        }


    }
}