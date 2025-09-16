using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.SavedData.BuildingSaveSystem
{
    public class BuildingSaveLoadData: Application.Services.SaveLoadService.SaveLoadObjects.SaveLoadData
    {
        public BuildingSaveLoadData(List<BuildingParams> buildingParams) : base(new object[]{buildingParams}, nameof(BuildingSaveLoadData))
        {
        }
    }
}