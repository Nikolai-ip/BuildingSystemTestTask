using System;
using UniRx;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public interface IBuildingPlacer
    {
        event Action<Vector3Int> OnBuildingPlaced;
        Vector3Int BuildingPos { get; }
        ReactiveProperty<bool> CanBePlaced { get; }
        void StartPlace();
    }
}