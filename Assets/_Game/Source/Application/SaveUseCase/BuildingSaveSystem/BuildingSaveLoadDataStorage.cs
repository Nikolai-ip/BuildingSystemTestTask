using System.Collections.Generic;
using _Game.Source.Application.Services.SaveLoadService;
using _Game.Source.Domain.Entities.Building;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    public class BuildingSaveLoadDataStorage: SaveLoadDataStorage
    {
        public List<BuildingParams> GetSavedBuildingsParams => GetSavedData<List<BuildingParams>>();
        
        public BuildingSaveLoadDataStorage(Application.Services.SaveLoadService.SaveLoadObjects.SaveLoadData saveLoadData) : base(saveLoadData)
        {
        }
        public override void RestoreValues(Application.Services.SaveLoadService.SaveLoadObjects.SaveLoadData saveLoadData)
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