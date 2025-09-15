using System;

namespace _Game.Scripts.Presentation
{
    public interface IView<in TViewData>
    {
        void SetData(TViewData data);
    }

    public interface IViewInteractable<out TViewCallback>
    {
        event Action<TViewCallback> callback;
    }

}