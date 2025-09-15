using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using _Game.Scripts.Infrastructure.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public class BuildingFactoryBase : IFactory<BuildingDataComponent, BuildingParams>
    {
        private Dictionary<BuildingType, BuildingDataComponent> _buildingPrefabsDataBase;
        private readonly BuildingState _initialState;
        private readonly IObjectResolver _objectResolver;

        public BuildingFactoryBase(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase, BuildingState initialState, IObjectResolver objectResolver)
        {
            _buildingPrefabsDataBase = buildingPrefabsDataBase;
            _initialState = initialState;
            _objectResolver = objectResolver;
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

        private BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab)
        {
            var instance = _objectResolver.Instantiate(prefab);
            var scope = instance.GetComponent<LifetimeScope>();
            scope.Build();
            instance.Construct(scope.Container.Resolve<BuildingFSM>(), scope.Container.Resolve<BuildingPlacer>());
            instance.Init(@params, _initialState);
            return instance;
        }
        
    }
}