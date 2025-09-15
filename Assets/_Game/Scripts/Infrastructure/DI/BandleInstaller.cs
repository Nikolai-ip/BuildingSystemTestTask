using System.Linq;
using VContainer;

namespace _Game.Scripts.Infrastructure.DI
{
    public class BandleInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            var installers = GetComponentsInChildren<IInstallerMono>().ToList();
            installers.RemoveAt(0);
            foreach (var installer in installers)
            {
                installer.Install(builder);
            }
        }
    }
}