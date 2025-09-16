using System.Collections.Generic;
using _Game.Scripts.Application;
using _Game.Scripts.Data.GameData;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/BuildingUpgradeCostData", fileName = "BuildingUpgradeCostData")]
    public class BuildingUpgradeCostData_SO : ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, List<int>> _buildingLevelCosts;

        public BuildingUpgradeCostData GetUpgradeCostData() => new(_buildingLevelCosts.GetDictionary());
    }
}