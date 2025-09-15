using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/DataBase", fileName = "BuildingDataBase")]
    public class BuildingDataBase_SO: ScriptableObject
    {
        [field: SerializeField] public DictionaryInspector<BuildingType, BuildingDataComponent> BuildingsInspector { get; private set; }
    }
}