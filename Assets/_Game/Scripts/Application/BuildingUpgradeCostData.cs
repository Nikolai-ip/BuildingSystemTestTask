using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;

namespace _Game.Scripts.Application
{
    public class BuildingUpgradeCostData
    {
        private readonly Dictionary<BuildingType, List<int>> _buildingLevelCosts;

        public BuildingUpgradeCostData(Dictionary<BuildingType, List<int>> buildingLevelCosts)
        {
            _buildingLevelCosts = buildingLevelCosts;
        }

        public bool TryGetLevelCost(BuildingType buildingType, int currentLevel, out int cost)
        {
            cost = int.MaxValue;
            if (_buildingLevelCosts.TryGetValue(buildingType, out List<int> levelCosts))
            {
                if (currentLevel >= levelCosts.Count)
                {
                    return false;
                }
                cost = levelCosts[currentLevel];
                return true;
            }
            return false;
        }
    }
}