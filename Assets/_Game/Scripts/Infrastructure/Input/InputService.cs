using System;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.Infrastructure.Input
{
    public class InputService: IInputService, ITickable
    {
        public Vector3 MousePosition { get; private set; }
        public event Action OnLeftMouseButtonClicked;

        public void Tick()
        {
            MousePosition = UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetMouseButton(0))
            {
                OnLeftMouseButtonClicked?.Invoke();
            }
        }
    }
}