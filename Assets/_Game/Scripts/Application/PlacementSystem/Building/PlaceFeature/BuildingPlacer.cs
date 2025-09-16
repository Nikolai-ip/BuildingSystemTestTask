using System;
using System.Threading;
using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.Domain.Entities;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure.Input;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Building.PlaceFeature
{
    public class BuildingPlacer: IDisposable, IBuildingPlacer, IBuildingRemover
    {
        private readonly Transform _buildingTr;
        private readonly BuildingDataComponent _buildingDataComponent;
        private readonly GridPointerPosition _pointerPosition;
        private readonly IInputService _inputService;
        private readonly IGridObjectAdder _gridObjectAdder;
        private readonly IGridObjectValidator _gridObjectValidator;
        private readonly IGridObjectRemover _gridObjectRemover;

        private readonly Vector3 _offset;
        private CancellationTokenSource _cts;
        public event Action<Vector3Int> OnBuildingPlaced;
        public Vector3Int BuildingPos { get; private set; }
        public ReactiveProperty<bool> CanBePlaced { get; }
        private BuildingParams _buildingParams;

        public BuildingPlacer(Transform buildingTr, BuildingDataComponent buildingDataComponent, GridPointerPosition pointerPosition, IInputService inputService, Vector3 offset, IGridObjectAdder gridObjectAdder, IGridObjectValidator gridObjectValidator, IGridObjectRemover gridObjectRemover)
        {
            _buildingTr = buildingTr;
            _pointerPosition = pointerPosition;
            _inputService = inputService;
            _offset = offset;
            _gridObjectAdder = gridObjectAdder;
            _gridObjectValidator = gridObjectValidator;
            _gridObjectRemover = gridObjectRemover;
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

        public void PlaceObject()
        {
            var buildingParams = _buildingDataComponent.BuildingParams;
            BuildingPos = buildingParams.Position;
            _gridObjectAdder.AddObjectAt(BuildingPos, buildingParams.Size, buildingParams.Id);
            _buildingTr.position  = _pointerPosition.CellToWorld(BuildingPos) + _offset;
        }

        private async UniTask MoveBuilding()
        {
            try
            {
                while(_cts != null && !_cts.Token.IsCancellationRequested)
                {
                    Vector3 position = _pointerPosition.GetPosition();
                    _buildingTr.position = position + _offset;
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

        public void RemoveObject()
        {
            var buildingParams = _buildingDataComponent.BuildingParams;
            _gridObjectRemover.RemoveObjectAt(BuildingPos, buildingParams.Size);
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