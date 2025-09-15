using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public abstract class BuildingFactoryBase : IFactory<BuildingDataComponent, BuildingParams>
    {
        private Dictionary<BuildingType, BuildingDataComponent> _buildingPrefabsDataBase;

        public BuildingFactoryBase(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase)
        {
            _buildingPrefabsDataBase = buildingPrefabsDataBase;
        }

        public BuildingDataComponent Create(BuildingParams @params)
        {
            if (_buildingPrefabsDataBase.TryGetValue(@params.BuildingType, out var prefab))
            {
                var buildingInstance = InstantiatePrefab(@params, prefab);
                return buildingInstance;
            }
            throw new KeyNotFoundException($"Failed to build building prefab with type {@params.BuildingType}");
        }

        protected abstract BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab);
    }
}