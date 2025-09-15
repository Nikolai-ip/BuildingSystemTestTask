using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.Services.Economy
{
    public class IncomeBuildingsParams
    {
        private readonly Dictionary<BuildingType, int> _incomeBuilding;

        public IncomeBuildingsParams(Dictionary<BuildingType, int> incomeBuilding)
        {
            _incomeBuilding = incomeBuilding;
        }

        public bool TryGetIncome(BuildingType buildingType, out int income)
        {
            return _incomeBuilding.TryGetValue(buildingType, out income);
        }
    }
}