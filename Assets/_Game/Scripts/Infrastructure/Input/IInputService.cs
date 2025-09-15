using System;
using UnityEngine;

namespace _Game.Scripts.Infrastructure.Input
{
    public interface IInputService
    {
        public Vector3 MousePosition { get; }
        event Action OnLeftMouseButtonClicked;
    }
}