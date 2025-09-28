using System.Collections.Generic;
using _Game.Source.Domain.Entities.Building;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    public class BuildingSaveLoadData: Application.Services.SaveLoadService.SaveLoadObjects.SaveLoadData
    {
        public BuildingSaveLoadData(List<BuildingParams> buildingParams) : base(new object[]{buildingParams}, nameof(BuildingSaveLoadData))
        {
        }
    }
}