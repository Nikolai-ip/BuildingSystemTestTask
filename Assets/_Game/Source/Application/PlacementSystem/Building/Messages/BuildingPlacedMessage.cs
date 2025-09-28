using _Game.Source.Domain.Entities.Building;

namespace _Game.Source.Application.PlacementSystem.Building.Messages
{
    public struct BuildingPlacedMessage
    {
        public BuildingParams PlacedBuilding { get; }

        public BuildingPlacedMessage(BuildingParams placedBuilding)
        {
            PlacedBuilding = placedBuilding;
        }
    }
    public struct BuildingRemovedMessage
    {
        public BuildingParams RemovedBuilding { get; }

        public BuildingRemovedMessage(BuildingParams removedBuilding)
        {
            RemovedBuilding = removedBuilding;
        }
    }
}