using System;
using _Game.Scripts.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Scripts.Application.PlacementSystem.Building.StateMachine;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UniRx;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingDataComponent: MonoBehaviour
    {
        [SerializeField] private Vector3Int _size;
        [SerializeField] private BuildingType _type;
        private BuildingParams _buildingParams;

        public BuildingParams BuildingParams => _buildingParams;

        private BuildingFSM _buildingFsm;
        private IBuildingPlacer _buildingPlacer;
        
        public void Construct(BuildingFSM buildingFsm, IBuildingPlacer buildingPlacer)
        {
            _buildingFsm = buildingFsm;
            _buildingPlacer = buildingPlacer;
        }
        public void Init(BuildingParams @params, BuildingState state)
        {
            _buildingParams = new BuildingParams(@params.Id, @params.Position, @params.Level, _size, _type);
            _buildingFsm.State.Subscribe(OnStateChanged).AddTo(this);
            if (state == BuildingState.Idle) 
                _buildingPlacer.PlaceObject();
            _buildingFsm.SetState(state);
        }
        
        private void OnStateChanged(BuildingState state)
        {
            if (state == BuildingState.Idle)
                _buildingParams.Position = _buildingPlacer.BuildingPos;
        }
        
    }
}