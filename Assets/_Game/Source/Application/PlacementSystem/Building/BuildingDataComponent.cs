using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Domain.Entities.Building;
using UniRx;
using UnityEngine;

namespace _Game.Source.Application.PlacementSystem.Building
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