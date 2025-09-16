using System;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public class BuildingRuntimeSpawner: IBuildingSpawner
    {
        private IFactory<BuildingDataComponent, BuildingParams> _factory;

        public BuildingRuntimeSpawner([Key(BuildingFactoryKey.Runtime)] IFactory<BuildingDataComponent, BuildingParams> factory)
        {
            _factory = factory;
        }
        
        /// <summary>
        /// Spawns a new building of the specified type at the default runtime position.
        /// </summary>
        /// <param name="buildingType">The type of building to spawn.</param>
        /// <returns>The instantiated <see cref="BuildingDataComponent"/>.</returns>
        public BuildingDataComponent Spawn(BuildingType buildingType)
        {
            return _factory.Create(new BuildingParams(
                Guid.NewGuid(),
                Vector3Int.zero,
                0,
                -Vector3Int.one,
                buildingType));
        }
    }

    /// <summary>
    /// Defines a contract for spawning building instances.
    /// </summary>
    public interface IBuildingSpawner
    {
        /// <summary>
        /// Spawns a new building of the specified type.
        /// </summary>
        /// <param name="buildingType">The type of building to spawn.</param>
        /// <returns>The instantiated <see cref="BuildingDataComponent"/>.</returns>
        BuildingDataComponent Spawn(BuildingType buildingType);
    }
}