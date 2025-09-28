using _Game.Source.Data.GameData;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Tools;
using UnityEngine;

namespace _Game.Source.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/BuildingsShopCatalog", fileName = "BuildingsShopCatalog")]

    public class BuildingsShopCatalog_SO: ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, int> _buildingsCatalog;
            
        public BuildingsShopCatalog GetCatalogue()
        {
            return new BuildingsShopCatalog(_buildingsCatalog.GetDictionary());
        }
    }
}