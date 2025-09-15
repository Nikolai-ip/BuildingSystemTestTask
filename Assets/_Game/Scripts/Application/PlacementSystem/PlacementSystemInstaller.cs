using _Game.Scripts.Infrastructure.DI;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem
{
    public class PlacementSystemInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PlanePointerPosition>(Lifetime.Singleton);
        }
    }
}