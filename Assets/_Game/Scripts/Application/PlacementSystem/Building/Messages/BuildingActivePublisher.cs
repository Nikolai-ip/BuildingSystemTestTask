using System;
using _Game.Scripts.Application.PlacementSystem.Building.StateMachine;
using MessagePipe;
using UniRx;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Building.Messages
{
    public class BuildingActivePublisher: IInitializable, IDisposable
    {
        private readonly IPublisher<BuildingPlacedMessage> _buildingPlacedPublisher;
        private readonly IPublisher<BuildingRemovedMessage> _buildingRemovedPublisher;
        private readonly BuildingFSM _fsm;
        private readonly BuildingDataComponent _dataComponent;
        private IDisposable _subscribe;

        public BuildingActivePublisher(IPublisher<BuildingPlacedMessage> buildingPlacedPublisher, IPublisher<BuildingRemovedMessage> buildingRemovedPublisher, BuildingFSM fsm, BuildingDataComponent dataComponent)
        {
            _buildingPlacedPublisher = buildingPlacedPublisher;
            _buildingRemovedPublisher = buildingRemovedPublisher;
            _fsm = fsm;
            _dataComponent = dataComponent;
        }

        public void Initialize()
        {
            _subscribe = _fsm.State.Subscribe(OnStateChanged);
        }

        private void OnStateChanged(BuildingState state)
        {
            switch (state)
            {
                case BuildingState.Idle:
                    _buildingPlacedPublisher.Publish(new BuildingPlacedMessage(_dataComponent.BuildingParams));
                    break;
                case BuildingState.Edit:
                    _buildingRemovedPublisher.Publish(new BuildingRemovedMessage(_dataComponent.BuildingParams));
                    break;
                case BuildingState.Remove:
                    _buildingRemovedPublisher.Publish(new BuildingRemovedMessage(_dataComponent.BuildingParams));
                    break;
            }
            
        }

        public void Dispose()
        {
            _subscribe.Dispose();
        }
    }
}