using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Scripts.Application.PlacementSystem.Building.StateMachine;
using _Game.Scripts.Domain.Entities;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    /// <summary>
    /// Base factory class responsible for creating building instances.
    /// This factory ensures that each created building:
    /// - Is instantiated with the correct prefab for its type.
    /// - Has its lifetime scope built and resolved via the DI container.
    /// - Is initialized with the specified starting <see cref="BuildingState"/>.
    /// </summary>
    public class BuildingFactoryBase : IFactory<BuildingDataComponent, BuildingParams>
    {
        private Dictionary<BuildingType, BuildingDataComponent> _buildingPrefabsDataBase;
        private readonly BuildingState _initialState;
        private readonly IObjectResolver _objectResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingFactoryBase"/> class.
        /// </summary>
        /// <param name="buildingPrefabsDataBase">A dictionary mapping building types to their prefab data components.</param>
        /// <param name="initialState">The initial state that all created buildings will start in.</param>
        /// <param name="objectResolver">The object resolver used to instantiate buildings and their dependencies.</param>
        public BuildingFactoryBase(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase, BuildingState initialState, IObjectResolver objectResolver)
        {
            _buildingPrefabsDataBase = buildingPrefabsDataBase;
            _initialState = initialState;
            _objectResolver = objectResolver;
        }
        
        /// <summary>
        /// Creates a new building instance based on the specified parameters.
        /// </summary>
        /// <param name="@params">The parameters describing the building to create.</param>
        /// <returns>The instantiated and initialized <see cref="BuildingDataComponent"/>.</returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if a prefab for the specified building type is not found in the prefab database.
        /// </exception>
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
            instance.Construct(scope.Container.Resolve<BuildingFSM>(), scope.Container.Resolve<IBuildingPlacer>());
            instance.Init(@params, _initialState);
            return instance;
        }
        
    }
}