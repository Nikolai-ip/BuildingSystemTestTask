using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Source.Domain.Entities.Building
{
    public class BuildingContainer: IBuildingContainer
    {
        private readonly List<BuildingParams> _buildings = new();
        public event Action<List<BuildingParams>> OnContainerChanged;

        public bool TryAddBuilding(BuildingParams buildingParams)
        {
            var existingBuilding = _buildings.FirstOrDefault(b=>b.Id == buildingParams.Id);
            if (existingBuilding != null)
                return false;
            
            _buildings.Add(buildingParams);
            Debug.Log($"[BuildingContainer.TryAddBuilding] Success add building {buildingParams.BuildingType}");
            OnContainerChanged?.Invoke(_buildings);
            return true;
        }

        public bool TryRemoveBuilding(Guid buildingId)
        {
            var existingBuilding = _buildings.FirstOrDefault(b=> b.Id == buildingId);
            if (existingBuilding == null)
                return false;
            
            _buildings.Remove(existingBuilding);
            Debug.Log($"[BuildingContainer.TryAddBuilding] Success remove building {existingBuilding.BuildingType}");
            OnContainerChanged?.Invoke(_buildings);
            return true;
        }

        public int Count => _buildings.Count;

        public BuildingParams this[int i] => _buildings[i];

    }
}