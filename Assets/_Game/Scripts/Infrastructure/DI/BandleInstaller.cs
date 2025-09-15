using VContainer;

namespace _Game.Scripts.Infrastructure.DI
{
    public class BandleInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            foreach (var installer in GetComponentsInChildren<IInstallerMono>())
                installer.Install(builder);
            
        }
    }
}