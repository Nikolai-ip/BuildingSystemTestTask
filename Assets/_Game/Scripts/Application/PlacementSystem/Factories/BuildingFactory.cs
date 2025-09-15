using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public class BuildingFactory: BuildingFactoryBase
    {
        public BuildingFactory(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase) : base(buildingPrefabsDataBase)
        { }

        protected override BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab)
        {
            var buildingInstance = Object.Instantiate(prefab);
            buildingInstance.Init(@params, BuildingState.Edit);
            return buildingInstance;
        }
    }
}