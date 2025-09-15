using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application
{
    public class BuildingsShopCatalog
    {
        public Dictionary<BuildingType, int> _buildingCosts;

        public BuildingsShopCatalog(Dictionary<BuildingType, int> buildingCosts)
        {
            _buildingCosts = buildingCosts;
        }
    }
}