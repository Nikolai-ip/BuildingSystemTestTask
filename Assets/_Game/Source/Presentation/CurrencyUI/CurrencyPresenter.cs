using System;
using _Game.Source.Application.Services.Economy;
using UniRx;
using VContainer.Unity;

namespace _Game.Source.Presentation.CurrencyUI
{
    public class CurrencyPresenter: IInitializable, IDisposable
    {
        private readonly IView<CurrencyViewData> _view;
        private readonly CurrencyHolder _currencyHolder;
        private IDisposable _currencyChangedSubscription;

        public CurrencyPresenter(IView<CurrencyViewData> view, CurrencyHolder currencyHolder)
        {
            _view = view;
            _currencyHolder = currencyHolder;
        }

        public void Initialize()
        {
            _currencyChangedSubscription = _currencyHolder.CurrencyProperty
                .Subscribe(UpdateView);
            UpdateView(_currencyHolder.CurrencyProperty.Value);
        }

        private void UpdateView(Currency currency)
        {
            _view.SetData(new CurrencyViewData(currency));
        }

        public void Dispose()
        {
            _currencyChangedSubscription.Dispose();
        }
    }
}