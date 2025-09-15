using _Game.Scripts.Application.PlacementSystem;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.PlacementSystem
{
    public class IndicatorMover: ITickable
    {
        private readonly Transform _indicator;
        private readonly PlanePointerPosition _planePointerPosition;

        public IndicatorMover(Transform indicator, PlanePointerPosition planePointerPosition)
        {
            _indicator = indicator;
            _planePointerPosition = planePointerPosition;
        }

        public void Tick()
        {
            Vector3 position = _planePointerPosition.GetPosition();
            position.y = _indicator.position.y;
            _indicator.position = position;
        }
    }
}