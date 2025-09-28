using System.Collections.Generic;
using _Game.Source.Domain.Entities.Building;

namespace _Game.Source.Data.GameData
{
    public class BuildingsShopCatalog
    {
        public Dictionary<BuildingType, int> BuildingCosts { get; private set; }

        public BuildingsShopCatalog(Dictionary<BuildingType, int> buildingCosts)
        {
            BuildingCosts = buildingCosts;
        }
        
    }
}