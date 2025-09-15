using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public class SavedBuildingFactory: BuildingFactoryBase
    {
        
        public SavedBuildingFactory(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase) : base(buildingPrefabsDataBase)
        { }

        protected override BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab)
        {
            var buildingInstance = Object.Instantiate(prefab);
            buildingInstance.Init(@params, BuildingState.Idle);
            return buildingInstance;
        }
    }
}