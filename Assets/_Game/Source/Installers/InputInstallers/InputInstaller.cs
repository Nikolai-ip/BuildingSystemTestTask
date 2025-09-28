using _Game.Source.DI;
using _Game.Source.Infrastructure.Input;
using VContainer;

namespace _Game.Source.Installers.InputInstallers
{
    public class InputInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder
                .Register<InputService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}