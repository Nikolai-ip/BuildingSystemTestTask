using System;
using System.Collections.Generic;

namespace _Game.Scripts.Domain.Entities.Building
{
    public interface IBuildingContainer
    {
        bool TryAddBuilding(BuildingParams buildingParams);
        bool TryRemoveBuilding(Guid buildingId);
        int Count { get; }
        BuildingParams this[int i] { get; }
        event Action<List<BuildingParams>> OnContainerChanged;
    }
}