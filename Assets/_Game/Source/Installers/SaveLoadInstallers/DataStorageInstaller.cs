using _Game.Source.Application.SaveUseCase;
using _Game.Source.Application.Services.SaveLoadService;
using _Game.Source.DI;
using VContainer;

namespace _Game.Source.Installers.SaveLoadInstallers
{
    public class DataStorageInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            var saveLoadSystem = new SaveLoadSystem();
            builder
                .RegisterInstance<ISaveLoadService>(saveLoadSystem);
            
            BindGameDataStorage(saveLoadSystem, builder);
            saveLoadSystem.LoadGame();
            saveLoadSystem.SaveGame();
        }
        private void BindGameDataStorage(ISaveLoadService saveLoadSystem, IContainerBuilder builder)
        {
            var dataStorages = new GameStorageFactory().GetDataStorages();
            foreach (var dataStorage in dataStorages)
            {
                builder
                    .RegisterInstance(dataStorage.Value, dataStorage.Key);
            }
            var gameDataStorage = new GameDataStorage(saveLoadSystem, dataStorages);
        }
    }
}