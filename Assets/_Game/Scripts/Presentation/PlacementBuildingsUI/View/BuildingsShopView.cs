using System;
using System.Collections.Generic;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;

namespace _Game.Scripts.Presentation.PlacementBuildingsUI.View
{
    public class BuildingsShopView: MonoBehaviour, IView<BuildingsShopViewData>, IViewInteractable<BuildingPurchasedCallback>
    {
        private List<BuyBuildingButton> _buyBuildingButtons;
        public event Action<BuildingPurchasedCallback> callback;

        public void Init(List<BuyBuildingButton> buyBuildingButtons)
        {
            _buyBuildingButtons = buyBuildingButtons;
            _buyBuildingButtons.ForEach(button => button.callback += OnBuildingBuyButtonClicked);
        }
        private void OnDisable() => _buyBuildingButtons.ForEach(button=>button.callback -= OnBuildingBuyButtonClicked);

        private void OnBuildingBuyButtonClicked(BuildingPurchasedCallback callbackData)
        {
            callback?.Invoke(callbackData);
        }

        public void SetData(BuildingsShopViewData data)
        {
            foreach (var buildingButton in _buyBuildingButtons)
            {
                if (data.AvailableBuildings.TryGetValue(buildingButton.BuildingType, out bool buildingPurchaseIsAvailable))
                    buildingButton.SetData(new ButtonViewData(buildingPurchaseIsAvailable));
                
            }
        }
    }

    public struct BuildingsShopViewData
    {
        public Dictionary<BuildingType, bool> AvailableBuildings { get; }


        public BuildingsShopViewData(Dictionary<BuildingType, bool> availableBuildings)
        {
            AvailableBuildings = availableBuildings;
        }
    }
}