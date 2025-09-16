using _Game.Scripts.Application.Services.Economy;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Economy/IncomeBuildingsParams", fileName = "IncomeBuildingsParams")]
    public class IncomeBuildingsParams_SO : ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, int> _buildingIncomeInspectorMap; 

        public IncomeBuildingsParams GetIncomeBuildingsParams()
        {
            return new IncomeBuildingsParams(_buildingIncomeInspectorMap.GetDictionary());
        }
    }
}