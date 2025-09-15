using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Presentation.PlacementSystem.View
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