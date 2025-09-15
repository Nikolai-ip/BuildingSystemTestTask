using System;
using System.Collections.Generic;
using _Game.Scripts.Application;
using _Game.Scripts.Application.Services.Economy;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Presentation.PlacementSystem.View;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.PlacementSystem
{
    public class BuildingsShopPresenter: IInitializable, IDisposable
    {
        private IView<BuildingsShopViewData> _view;
        private IViewInteractable<BuildingPurchasedCallback> _viewCallbackInvoker;
        private readonly CurrencyHolder _currencyHolder;
        private readonly BuildingsShopCatalog _shopCatalog;

        public BuildingsShopPresenter(IView<BuildingsShopViewData> view, IViewInteractable<BuildingPurchasedCallback> viewCallbackInvoker,
            CurrencyHolder currencyHolder, BuildingsShopCatalog shopCatalog)
        {
            _view = view;
            _viewCallbackInvoker = viewCallbackInvoker;
            _currencyHolder = currencyHolder;
            _shopCatalog = shopCatalog;
        }

        public void Initialize()
        {
            UpdateView();
        }      


        private void OnCurrencyChanged(Currency currency) => UpdateView();

        private void UpdateView()
        {
            Dictionary<BuildingType, bool> availableBuildings = new();
            foreach (var kvp in _shopCatalog._buildingCosts)
            {
                availableBuildings.Add(kvp.Key, _currencyHolder.CurrencyProperty.Value.Coins > kvp.Value);
            }
            _view.SetData(new BuildingsShopViewData(availableBuildings));
        }

        public void Dispose()
        {
            //:todo
          //  _currencyHolder.CurrencyChanged -= OnCurrencyChanged;
        }
    }
}