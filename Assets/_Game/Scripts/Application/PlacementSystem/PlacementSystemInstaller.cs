using _Game.Scripts.DI;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem
{
    public class PlacementSystemInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<GridPointerPosition>(Lifetime.Singleton);
        }
    }
}