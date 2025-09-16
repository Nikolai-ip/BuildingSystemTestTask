using System;
using _Game.Scripts.Application;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Building.UpgradeFeature;
using _Game.Scripts.Application.Services.Economy;
using _Game.Scripts.Data.GameData;
using _Game.Scripts.Presentation.Building.ToolPanel.View;
using VContainer.Unity;
using UniRx;

namespace _Game.Scripts.Presentation.Building.UpgradeButton
{
    public class UpgradeButtonPresenter: IInitializable, IDisposable
    {
        private readonly IView<ButtonViewData> _buttonView;
        private readonly IViewInteractable<BuildingToolCallback> _buttonCallbackInvoker;
        private readonly CurrencyHolder _currencyHolder;
        private readonly BuildingUpgradeCostData _buildingUpgradeCostData;
        private readonly BuildingDataComponent _buildingDataComponent;
        private readonly IBuildingUpgrader _buildingUpgrader;
        private IDisposable _currencyChangedSub;

        public UpgradeButtonPresenter(IView<ButtonViewData> buttonView, IViewInteractable<BuildingToolCallback> buttonCallbackInvoker, CurrencyHolder currencyHolder, BuildingUpgradeCostData buildingUpgradeCostData, BuildingDataComponent buildingDataComponent, IBuildingUpgrader buildingUpgrader)
        {
            _buttonView = buttonView;
            _buttonCallbackInvoker = buttonCallbackInvoker;
            _currencyHolder = currencyHolder;
            _buildingUpgradeCostData = buildingUpgradeCostData;
            _buildingDataComponent = buildingDataComponent;
            _buildingUpgrader = buildingUpgrader;
        }

        public void Initialize()
        {
            _currencyChangedSub = _currencyHolder.CurrencyProperty.Subscribe(OnCurrencyChanged);
            _buttonCallbackInvoker.callback += OnUpgradePurchased;
            _buildingUpgrader.OnUpgraded += UpdateView;
        }
        private void OnCurrencyChanged(Currency currency) => UpdateView();
        private void OnUpgradePurchased(BuildingToolCallback callback)
        {
            var buildingParams =  _buildingDataComponent.BuildingParams;
            if (_buildingUpgradeCostData.TryGetLevelCost(buildingParams.BuildingType, buildingParams.Level + 1,
                    out int cost))
            {
                _currencyHolder.SubCoins(cost);
            }
        }


        private void UpdateView()
        {
            var buildingParams =  _buildingDataComponent.BuildingParams;
            if (buildingParams == null) return;
            if (_buildingUpgradeCostData.TryGetLevelCost(buildingParams.BuildingType, buildingParams.Level + 1,
                    out int cost))
            {
                _buttonView.SetData(new ButtonViewData(_currencyHolder.CurrencyProperty.Value.Coins >= cost));    
            }
            else
                _buttonView.SetData(new ButtonViewData(false));
            
        }
        public void Dispose()
        {
            _buttonCallbackInvoker.callback -= OnUpgradePurchased;
            _buildingUpgrader.OnUpgraded -= UpdateView;
            _currencyChangedSub.Dispose();
        }
    }
}