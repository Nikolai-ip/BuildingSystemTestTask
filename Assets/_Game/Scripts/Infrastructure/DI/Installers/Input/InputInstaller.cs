using _Game.Scripts.Infrastructure.Input;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Infrastructure.DI.Installers.Input
{
    public class InputInstaller: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<InputService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}