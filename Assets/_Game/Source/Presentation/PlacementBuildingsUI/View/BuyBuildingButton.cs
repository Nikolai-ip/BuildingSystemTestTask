using System;
using _Game.Source.Domain.Entities.Building;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Source.Presentation.PlacementBuildingsUI.View
{
    public class BuyBuildingButton: MonoBehaviour, IView<ButtonViewData>, IViewInteractable<BuildingPurchasedCallback>
    {
        public event Action<BuildingPurchasedCallback> callback;
        [SerializeField] private BuildingType _buildingType;
        public BuildingType BuildingType => _buildingType;
        private Button _button;
        [SerializeField] private float _clickInterval;

        private void OnEnable()
        {
            if (!_button) Init();
        }

        private void Init()
        {
            _button = GetComponent<Button>();
              _button.OnClickAsObservable().Throttle(TimeSpan.FromSeconds(_clickInterval))
                  .Subscribe((unit)=>
            {
                callback?.Invoke(new BuildingPurchasedCallback(_buildingType));
            }).AddTo(this);  
        }

        public void SetData(ButtonViewData data)
        {
            if (!_button) Init();
            _button.interactable = data.Interactable;
        }
    }
}