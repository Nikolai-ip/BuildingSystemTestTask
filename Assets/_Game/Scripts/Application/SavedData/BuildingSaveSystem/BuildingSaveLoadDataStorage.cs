using System.Collections.Generic;
using _Game.Scripts.Application.Services.SaveLoadService;
using _Game.Scripts.Application.Services.SaveLoadService.SaveLoadObjects;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.SavedData.BuildingSaveSystem
{
    public class BuildingSaveLoadDataStorage: SaveLoadDataStorage
    {
        public List<BuildingParams> GetSavedBuildingsParams => GetSavedData<List<BuildingParams>>();
        
        public BuildingSaveLoadDataStorage(SaveLoadData saveLoadData) : base(saveLoadData)
        {
        }
        public override void RestoreValues(SaveLoadData saveLoadData)
        {
            RestoreValue<List<BuildingParams>>(saveLoadData);
        }

        public void UpdateData(List<BuildingParams> buildings)
        {
            GetSavedBuildingsParams.Clear();
            GetSavedBuildingsParams.AddRange(buildings);
        }

        public List<BuildingParams> CopyData()
        {
            var copiedData = new  List<BuildingParams>();
            foreach (var buildingParam in GetSavedBuildingsParams)
                copiedData.Add(buildingParam);
            

            return copiedData;
        }
    }
}