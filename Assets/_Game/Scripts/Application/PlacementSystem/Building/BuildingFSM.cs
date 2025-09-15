using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingFSM: IInitializable, IDisposable
    {
        private BuildingState _currentState;
        public ReactiveProperty<BuildingState> State { get; private set; }

        private readonly BuildingPlacer _buildingPlacer;
        private IDisposable _subscriber;

        public BuildingFSM(BuildingPlacer buildingPlacer)
        {
            State = new ReactiveProperty<BuildingState>(BuildingState.None);
            _buildingPlacer = buildingPlacer;
        }

        public void Enable(BuildingState state) => State.Value = state;

        private void HandleStateTransition(BuildingState state)
        {
            if (state == BuildingState.Edit)
            {
                _buildingPlacer.StartPlace();
            }
        }

        public void Initialize()
        {
            _buildingPlacer.OnBuildingPlaced += SwitchToIdleState;
            _subscriber = State.Subscribe(HandleStateTransition);
        }

        private void SwitchToIdleState(Vector2Int pos) => State.Value = BuildingState.Idle;

        public void Dispose()
        {
            _buildingPlacer.OnBuildingPlaced -= SwitchToIdleState;
            _subscriber.Dispose();
        }
    }
}