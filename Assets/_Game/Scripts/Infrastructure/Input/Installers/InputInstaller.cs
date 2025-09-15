using _Game.Scripts.Infrastructure.DI;
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