using System;
using System.Collections.Generic;
using _Game.Source.Application.PlacementSystem.Factories;
using _Game.Source.Application.Services.Economy;
using _Game.Source.Data.GameData;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Presentation.PlacementBuildingsUI.View;
using UniRx;
using VContainer.Unity;

namespace _Game.Source.Presentation.PlacementBuildingsUI
{
    public class BuildingsShopPresenter: IInitializable, IDisposable
    {
        private readonly IView<BuildingsShopViewData> _view;
        private IViewInteractable<BuildingPurchasedCallback> _viewCallbackInvoker;
        private readonly CurrencyHolder _currencyHolder;
        private readonly BuildingsShopCatalog _shopCatalog;
        private IDisposable _currencyChangedSubscription;
        private IBuildingSpawner _buildingSpawner; 
        public BuildingsShopPresenter(IView<BuildingsShopViewData> view, IViewInteractable<BuildingPurchasedCallback> viewCallbackInvoker,
            CurrencyHolder currencyHolder, BuildingsShopCatalog shopCatalog, IBuildingSpawner buildingSpawner)
        {
            _view = view;
            _viewCallbackInvoker = viewCallbackInvoker;
            _currencyHolder = currencyHolder;
            _shopCatalog = shopCatalog;
            _buildingSpawner = buildingSpawner;
        }

        public void Initialize()
        {
            _currencyChangedSubscription = _currencyHolder.CurrencyProperty.Subscribe(OnCurrencyChanged);
            _viewCallbackInvoker.callback += HandleViewCallback;
            UpdateView();
        }

        private void HandleViewCallback(BuildingPurchasedCallback purchasedCallback)
        {
            if (_shopCatalog.BuildingCosts.TryGetValue(purchasedCallback.BuildingType, out int cost))
            {
                _buildingSpawner.Spawn(purchasedCallback.BuildingType);
                _currencyHolder.SubCoins(cost);
            }
        }


        private void OnCurrencyChanged(Currency currency) => UpdateView();

        private void UpdateView()
        {
            Dictionary<BuildingType, bool> availableBuildings = new();
            foreach (var kvp in _shopCatalog.BuildingCosts)
            {
                availableBuildings.Add(kvp.Key, _currencyHolder.CurrencyProperty.Value.Coins > kvp.Value);
            }
            _view.SetData(new BuildingsShopViewData(availableBuildings));
        }

        public void Dispose()
        {
            _viewCallbackInvoker.callback -= HandleViewCallback;
            _currencyChangedSubscription.Dispose();
        }
    }
    
}