using System;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem
{
    public class BuildingSpawner: IBuildingSpawner
    {
        private IFactory<BuildingDataComponent, BuildingParams> _factory;

        public BuildingSpawner(IFactory<BuildingDataComponent, BuildingParams> factory)
        {
            _factory = factory;
        }

        public BuildingDataComponent Spawn(BuildingType buildingType)
        {
            return _factory.Create(new BuildingParams(
                Guid.NewGuid(),
                Vector2Int.zero,
                0,
                -Vector2Int.one,
                buildingType));
        }
    }

    public interface IBuildingSpawner
    {
        BuildingDataComponent Spawn(BuildingType buildingType);
    }
}