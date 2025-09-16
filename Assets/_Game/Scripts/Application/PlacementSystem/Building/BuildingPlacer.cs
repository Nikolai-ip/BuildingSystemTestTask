using System;
using System.Threading;
using _Game.Scripts.Domain.Entities;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure.Input;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingPlacer: IDisposable, IBuildingPlacer
    {
        private readonly Transform _buildingTr;
        private readonly BuildingDataComponent _buildingDataComponent;
        private readonly GridPointerPosition _pointerPosition;
        private readonly IInputService _inputService;
        private readonly IGridObjectAdder _gridObjectAdder;
        private readonly IGridObjectValidator _gridObjectValidator;
        private readonly Vector3 _offset;
        private CancellationTokenSource _cts;
        public event Action<Vector3Int> OnBuildingPlaced;
        public Vector3Int BuildingPos { get; private set; }
        public ReactiveProperty<bool> CanBePlaced { get; }
        private BuildingParams _buildingParams;

        public BuildingPlacer(Transform buildingTr, BuildingDataComponent buildingDataComponent, GridPointerPosition pointerPosition, IInputService inputService, Vector3 offset, IGridObjectAdder gridObjectAdder, IGridObjectValidator gridObjectValidator)
        {
            _buildingTr = buildingTr;
            _pointerPosition = pointerPosition;
            _inputService = inputService;
            _offset = offset;
            _gridObjectAdder = gridObjectAdder;
            _gridObjectValidator = gridObjectValidator;
            _buildingDataComponent = buildingDataComponent;
            CanBePlaced = new();
        }

        public void StartPlace()
        {
            _inputService.OnLeftMouseButtonClicked += TryStopPlace;
            _cts = new();
            _buildingParams = _buildingDataComponent.BuildingParams;
            MoveBuilding().Forget();
        }

        private async UniTask MoveBuilding()
        {
            try
            {
                while(_cts != null && !_cts.Token.IsCancellationRequested)
                {
                    Vector3 position = _pointerPosition.GetPosition() + _offset;
                    _buildingTr.position = position;
                    BuildingPos = _pointerPosition.PointerPosToCell();
                    CanBePlaced.Value = _gridObjectValidator.CanPlaceObjectAt(BuildingPos, _buildingParams.Size);
                    await UniTask.Yield();
                }
            }
            catch (OperationCanceledException)
            { }

        }
        
        private void TryStopPlace()
        {
            if (_inputService.IsPointerOverUI()) return;
            if (!CanBePlaced.Value) return;
            StopPlace();
        }

        private void StopPlace()
        {
            _gridObjectAdder.AddObjectAt(BuildingPos, _buildingParams.Size, _buildingParams.Id);
            _inputService.OnLeftMouseButtonClicked -= TryStopPlace;
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