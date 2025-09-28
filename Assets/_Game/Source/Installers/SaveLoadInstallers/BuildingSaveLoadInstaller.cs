using _Game.Source.Application.SaveUseCase.BuildingSaveSystem;
using _Game.Source.DI;
using VContainer;

namespace _Game.Source.Installers.SaveLoadInstallers
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