using System;
using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using VContainer.Unity;

namespace _Game.Scripts.Application.SavedData.BuildingSaveSystem
{
    public class BuildingsSaver: IInitializable, IDisposable
    {
        private readonly IBuildingContainer _buildingContainer;
        private readonly BuildingSaveLoadDataStorage _dataStorage;

        public BuildingsSaver(IBuildingContainer buildingContainer, BuildingSaveLoadDataStorage dataStorage)
        {
            _buildingContainer = buildingContainer;
            _dataStorage = dataStorage;
        }

        public void Initialize()
        {
            _buildingContainer.OnContainerChanged += ChangeDataStorage;
        }

        private void ChangeDataStorage(List<BuildingParams> buildings)
        {
            _dataStorage.UpdateData(buildings);
        }

        public void Dispose()
        {
            _buildingContainer.OnContainerChanged -= ChangeDataStorage;
        }
    }
}