using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Application.PlacementSystem.Factories;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Infrastructure;
using VContainer;
using VContainer.Unity;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    /// <summary>
    /// Restores saved building instances from persistent storage during initialization.
    /// Uses a dedicated restoration factory to recreate each building from saved parameters.
    /// </summary>
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
            foreach (var savedBuildingsParam in _dataStorage.CopyData())
            {
                _buildingFactory.Create(savedBuildingsParam);
            }
        }
    }
}