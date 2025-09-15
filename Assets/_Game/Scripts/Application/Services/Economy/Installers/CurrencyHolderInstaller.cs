using _Game.Scripts.DI;
using VContainer;

namespace _Game.Scripts.Application.Services.Economy.Installers
{
    public class CurrencyHolderInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CurrencyHolder>(Lifetime.Singleton).AsSelf().WithParameter(new Currency(){Coins = 400});
        }
    }
}