using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.PlacementSystem.Building.Messages
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