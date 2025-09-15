using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public abstract class BuildingFactoryBase : IFactory<BuildingDataComponent, BuildingParams>
    {
        private Dictionary<BuildingType, BuildingDataComponent> _buildingPrefabsDataBase;
        protected readonly IObjectResolver _resolver;
        public BuildingFactoryBase(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase, IObjectResolver resolver)
        {
            _buildingPrefabsDataBase = buildingPrefabsDataBase;
            _resolver = resolver;
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