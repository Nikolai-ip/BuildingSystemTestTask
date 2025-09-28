using System.Collections.Generic;
using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Tools;
using UnityEngine;

namespace _Game.Source.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/DataBase", fileName = "BuildingDataBase")]
    public class BuildingDataBase_SO: ScriptableObject
    {
        [field: SerializeField] public DictionaryInspector<BuildingType, BuildingDataComponent> BuildingsInspector { get; private set; }

        public Dictionary<BuildingType, BuildingDataComponent> GetDataBase()
        {
            return BuildingsInspector.GetDictionary();
        }
    }
}