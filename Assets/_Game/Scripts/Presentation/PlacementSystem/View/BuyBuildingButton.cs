using System;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.PlacementSystem.View
{
    public class BuyBuildingButton: MonoBehaviour, IView<ButtonViewData>, IViewInteractable<BuildingPurchasedCallback>
    {
        public event Action<BuildingPurchasedCallback> callback;
        [SerializeField] private BuildingType _buildingType;
        public BuildingType BuildingType => _buildingType;
        private Button _button;

        private void OnEnable()
        {
            _button ??= GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            callback?.Invoke(new BuildingPurchasedCallback(_buildingType));
        }

        public void SetData(ButtonViewData data)
        {
            _button ??= GetComponent<Button>();
            _button.interactable = data.Interactable;
        }
    }
}