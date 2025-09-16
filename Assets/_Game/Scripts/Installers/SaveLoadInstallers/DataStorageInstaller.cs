using _Game.Scripts.Application.SavedData;
using _Game.Scripts.Application.Services.SaveLoadService;
using _Game.Scripts.DI;
using VContainer;

namespace _Game.Scripts.Installers.SaveLoadInstallers
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