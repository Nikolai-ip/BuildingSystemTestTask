using System.Collections.Generic;
using _Game.Scripts.Application.Services.Economy;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Economy/IncomeBuildingsParams", fileName = "IncomeBuildingsParams")]
    public class IncomeBuildingsParams_SO : ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, BuildingLevelIncomeDataInspector> _buildingIncomeInspectorMap; 

        public IncomeBuildingsParams GetIncomeBuildingsParams()
        {
            var incomeData = new Dictionary<BuildingType, BuildingLevelIncomeData>();
            var serializeableData = _buildingIncomeInspectorMap.GetDictionary();
            foreach (var kvp in serializeableData)
            {
                incomeData.Add(kvp.Key, kvp.Value.GeIncomeData());
            }
            return new IncomeBuildingsParams(incomeData);
        }
    }

    [System.Serializable]
    public class BuildingLevelIncomeDataInspector
    {
        [SerializeField] private List<int> _levelIncomeData;
        public BuildingLevelIncomeData GeIncomeData() => new(_levelIncomeData);
    }
}