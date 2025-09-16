using _Game.Scripts.Application.SavedData.BuildingSaveSystem;
using _Game.Scripts.DI;
using VContainer;

namespace _Game.Scripts.Installers.SaveLoadInstallers
{
    public class BuildingSaveLoadInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BuildingsSaver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SavedBuildingsRestorer>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}