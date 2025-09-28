using _Game.Source.Application.Services.Economy;
using _Game.Source.DI;
using VContainer;

namespace _Game.Source.Installers.EconomyInstallers
{
    public class CurrencyHolderInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CurrencyHolder>(Lifetime.Singleton).AsSelf().WithParameter(new Currency(){Coins = 400});
        }
    }
}