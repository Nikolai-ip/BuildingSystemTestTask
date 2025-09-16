using System;
using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using VContainer.Unity;

namespace _Game.Scripts.Application.SavedData.BuildingSaveSystem
{
    /// <summary>
    /// Observes changes in the building container and updates the building save/load storage accordingly.
    /// Does not handle full game saving, only synchronizes the current list of buildings with the data storage.
    /// </summary>
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