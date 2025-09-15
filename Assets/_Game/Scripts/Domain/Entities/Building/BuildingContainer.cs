using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _Game.Scripts.Domain.Entities.Building
{
    public class BuildingContainer: IBuildingContainer
    {
        private List<BuildingParams> _buildings;
        public IEnumerator<BuildingParams> GetEnumerator()
        {
            return _buildings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool TryAddBuilding(BuildingParams buildingParams)
        {
            var existingBuilding = _buildings.FirstOrDefault(b=>b.Id == buildingParams.Id);
            if (existingBuilding != null)
                return false;
            
            _buildings.Add(buildingParams);
            return true;
        }

        public bool TryRemoveBuilding(Guid buildingId)
        {
            var existingBuilding = _buildings.FirstOrDefault(b=> b.Id == buildingId);
            if (existingBuilding == null)
                return false;
            
            _buildings.Remove(existingBuilding);
            return true;
        }

        public int Count => _buildings.Count;

        public BuildingParams this[int i] => _buildings[i];
    }
}