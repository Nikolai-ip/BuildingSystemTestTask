using _Game.Scripts.DI;
using VContainer;

namespace _Game.Scripts.Infrastructure.Input.Installers
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