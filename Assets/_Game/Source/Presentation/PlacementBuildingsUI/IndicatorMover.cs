using _Game.Source.Application.Utilities.Input;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Source.Presentation.PlacementBuildingsUI
{
    public class IndicatorMover: ITickable
    {
        private readonly Transform _indicator;
        private readonly GridPointerPosition _gridPointerPosition;

        public IndicatorMover(Transform indicator, GridPointerPosition gridPointerPosition)
        {
            _indicator = indicator;
            _gridPointerPosition = gridPointerPosition;
        }

        public void Tick()
        {
            Vector3 position = _gridPointerPosition.GetPosition();
            position.y = _indicator.position.y;
            _indicator.position = position;
        }
    }
}