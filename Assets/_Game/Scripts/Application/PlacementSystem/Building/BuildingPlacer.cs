using System;
using System.Threading;
using _Game.Scripts.Infrastructure.Input;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingPlacer: IDisposable
    {
        private Transform _buildingTr;
        private GridPointerPosition _pointerPosition;
        private readonly IInputService _inputService;
        private CancellationTokenSource _cts;
        public event Action<Vector2Int> OnBuildingPlaced;
        public Vector2Int BuildingPos { get; private set; }
        private Vector3 _offset;
        public BuildingPlacer(Transform buildingTr, GridPointerPosition pointerPosition, IInputService inputService, Vector3 offset)
        {
            _buildingTr = buildingTr;
            _pointerPosition = pointerPosition;
            _inputService = inputService;
            _offset = offset;
        }

        public void StartPlace()
        {
            _inputService.OnLeftMouseButtonClicked += StopPlace;
            _cts = new();
            MoveBuilding().Forget();
        }

        private async UniTask MoveBuilding()
        {
            try
            {
                while(_cts != null && !_cts.Token.IsCancellationRequested)
                {
                    Vector3 position = _pointerPosition.GetPosition();
                    position.y = 0;
                    _buildingTr.position = position;
                    await UniTask.Yield();
                }
            }
            catch (OperationCanceledException)
            { }

        }
        private void StopPlace()
        {
            _inputService.OnLeftMouseButtonClicked -= StopPlace;
            DisposeCts();
            OnBuildingPlaced?.Invoke(BuildingPos);
        }

        public void Dispose()
        {
            DisposeCts();
        }

        private void DisposeCts()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}