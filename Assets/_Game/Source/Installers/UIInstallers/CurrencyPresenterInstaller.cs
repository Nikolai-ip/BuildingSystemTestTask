using _Game.Source.DI;
using _Game.Source.Presentation;
using _Game.Source.Presentation.CurrencyUI;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.UIInstallers
{
    public class CurrencyPresenterInstaller: IInstallerMono
    {
        [SerializeField] private CurrencyView _view;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_view).As<IView<CurrencyViewData>>();
            builder.Register<CurrencyPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}