using _Game.Source.Domain.Entities.Building;

namespace _Game.Source.Presentation.PlacementBuildingsUI.View
{
    public struct BuildingPurchasedCallback
    {
        public BuildingType BuildingType { get; private set; }

        public BuildingPurchasedCallback(BuildingType buildingType)
        {
            BuildingType = buildingType;
        }
    }
}