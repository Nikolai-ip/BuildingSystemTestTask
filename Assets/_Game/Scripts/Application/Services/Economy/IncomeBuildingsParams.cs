using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.Services.Economy
{
    public class IncomeBuildingsParams
    {
        private readonly Dictionary<BuildingType, BuildingLevelIncomeData> _incomeBuilding;

        public IncomeBuildingsParams(Dictionary<BuildingType, BuildingLevelIncomeData> incomeBuilding)
        {
            _incomeBuilding = incomeBuilding;
        }

        public bool TryGetIncome(BuildingType buildingType, int level, out int income)
        {
            income = 0;
            _incomeBuilding.TryGetValue(buildingType, out var buildingLevelIncomeData);
            if (buildingLevelIncomeData == null) return false;
            return buildingLevelIncomeData.TrtGetIncomeByLevel(level, out income);
        }
    }

    public class BuildingLevelIncomeData
    {
        private List<int> _levelIncomeData;

        public BuildingLevelIncomeData(List<int> levelIncomeData)
        {
            _levelIncomeData = levelIncomeData;
        }

        public bool TrtGetIncomeByLevel(int level, out int income)
        {
            income = 0;
            if (level > _levelIncomeData.Count) 
                return false;
            income =  _levelIncomeData[level];
            return true;
        }
    }
}