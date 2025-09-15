using System;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingFSM: IInitializable, IDisposable
    {
        private BuildingState _currentState;

        private BuildingState CurrentState
        {
            get => _currentState;
            set {
                _currentState = value;
                HandleStateTransition();
            }
        }

        private BuildingPlacer _buildingPlacer;

        private void HandleStateTransition()
        {
            if (CurrentState == BuildingState.Edit)
            {
                _buildingPlacer.StartPlace();
            }
        }

        public BuildingFSM(BuildingPlacer buildingPlacer)
        {
            _buildingPlacer = buildingPlacer;
        }

        public void Enable(BuildingState state) => CurrentState = state;

        public void Initialize()
        {
            _buildingPlacer.OnBuildingPlaced += SwitchToIdleState;
        }

        private void SwitchToIdleState() => CurrentState = BuildingState.Idle;

        public void Dispose()
        {
            _buildingPlacer.OnBuildingPlaced -= SwitchToIdleState;
        }
    }
}