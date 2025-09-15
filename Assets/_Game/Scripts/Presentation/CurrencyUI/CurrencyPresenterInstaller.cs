using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Presentation.CurrencyUI
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