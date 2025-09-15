using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem.Factories
{
    public class SavedBuildingFactory: BuildingFactoryBase
    {
        public SavedBuildingFactory(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase, IObjectResolver resolver) : base(buildingPrefabsDataBase, resolver)
        {
        }

        protected override BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab)
        {
            var buildingInstance = Object.Instantiate(prefab);
            buildingInstance.Init(@params, BuildingState.Idle);
            _resolver.Inject(buildingInstance);
            return buildingInstance;
        }
    }
}