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
        private BuildingDataComponent _buildingData;
        private GridPointerPosition _pointerPosition;
        private readonly IInputService _inputService;
        private CancellationTokenSource _cts;
        public event Action OnBuildingPlaced;

        public BuildingPlacer(Transform buildingTr, BuildingDataComponent buildingData, GridPointerPosition pointerPosition, IInputService inputService)
        {
            _buildingTr = buildingTr;
            _buildingData = buildingData;
            _pointerPosition = pointerPosition;
            _inputService = inputService;
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
                while(!_cts.Token.IsCancellationRequested)
                {
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
            OnBuildingPlaced?.Invoke();
        }

        public void Dispose()
        {
            DisposeCts();
        }

        private void DisposeCts()
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }
}