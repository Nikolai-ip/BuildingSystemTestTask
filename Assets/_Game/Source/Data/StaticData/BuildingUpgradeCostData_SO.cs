using System.Collections.Generic;
using _Game.Source.Data.GameData;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Tools;
using UnityEngine;

namespace _Game.Source.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/BuildingUpgradeCostData", fileName = "BuildingUpgradeCostData")]
    public class BuildingUpgradeCostData_SO : ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, List<int>> _buildingLevelCosts;

        public BuildingUpgradeCostData GetUpgradeCostData() => new(_buildingLevelCosts.GetDictionary());
    }
}