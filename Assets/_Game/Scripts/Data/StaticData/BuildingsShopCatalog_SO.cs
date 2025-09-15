using _Game.Scripts.Application;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Data.StaticData
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