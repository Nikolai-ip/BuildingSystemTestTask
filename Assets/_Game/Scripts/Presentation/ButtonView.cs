using System;
using _Game.Scripts.Presentation.PlacementSystem;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation
{
    public class ButtonView<T>:  MonoBehaviour, IView<ButtonViewData>, IViewInteractable<T>
    {
        public event Action<T> callback;
        private Button _button;
        [SerializeField] private float _clickInterval = 0.3f;

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
                    callback?.Invoke(GetInvokeParams());
                }).AddTo(this);  
        }

        public void SetData(ButtonViewData data)
        {
            if (!_button) Init();
            _button.interactable = data.Interactable;
        }

        protected virtual T GetInvokeParams()
        {
            return default(T);
        }

    }
}