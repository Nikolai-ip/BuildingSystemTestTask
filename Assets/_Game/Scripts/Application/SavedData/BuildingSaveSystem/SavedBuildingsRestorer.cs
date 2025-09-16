using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Factories;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.SavedData.BuildingSaveSystem
{
    public class SavedBuildingsRestorer: IInitializable
    {
        private readonly BuildingSaveLoadDataStorage _dataStorage;
        private readonly IFactory<BuildingDataComponent, BuildingParams> _buildingFactory;

        public SavedBuildingsRestorer(BuildingSaveLoadDataStorage dataStorage, [Key(BuildingFactoryKey.Restore)] IFactory<BuildingDataComponent, BuildingParams> buildingFactory)
        {
            _dataStorage = dataStorage;
            _buildingFactory = buildingFactory;
        }

        public void Initialize()
        {
            foreach (var savedBuildingsParam in _dataStorage.GetSavedBuildingsParams)
            {
                _buildingFactory.Create(savedBuildingsParam);
            }
        }
    }
}