using System;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Factories;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem
{
    public class BuildingRuntimeSpawner: IBuildingSpawner
    {
        private IFactory<BuildingDataComponent, BuildingParams> _factory;

        public BuildingRuntimeSpawner([Key(BuildingFactoryKey.Runtime)] IFactory<BuildingDataComponent, BuildingParams> factory)
        {
            _factory = factory;
        }

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

    public interface IBuildingSpawner
    {
        BuildingDataComponent Spawn(BuildingType buildingType);
    }
}