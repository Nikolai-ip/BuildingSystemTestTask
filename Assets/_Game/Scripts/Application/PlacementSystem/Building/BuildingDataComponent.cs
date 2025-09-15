using System;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UniRx;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingDataComponent: MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private BuildingType _type;
        private BuildingParams _buildingParams;
        private BuildingFSM _buildingFsm;
        private BuildingPlacer _buildingPlacer;
        
        public void Construct(BuildingFSM buildingFsm, BuildingPlacer buildingPlacer)
        {
            _buildingFsm = buildingFsm;
            _buildingPlacer = buildingPlacer;
        }
        public void Init(BuildingParams @params, BuildingState state)
        {
            _buildingParams = new(@params.Id, Vector2Int.zero, @params.Level, _size, _type);
            _buildingFsm.State.Subscribe(OnStateChanged).AddTo(this);
            _buildingFsm.Enable(state);
        }
        
        private void OnStateChanged(BuildingState state)
        {
            if (state == BuildingState.Idle)
                _buildingParams.Position = _buildingPlacer.BuildingPos;
        }
        
    }
}