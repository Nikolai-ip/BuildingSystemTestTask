using System;
using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Domain.Entities.Building;
using MessagePipe;
using VContainer.Unity;

namespace _Game.Scripts.Application
{
    public class BuildingContainerEditor: IInitializable, IDisposable
    {
        private readonly ISubscriber<BuildingPlacedMessage> _buildingPlacedSubscriber;
        private readonly ISubscriber<BuildingRemovedMessage> _buildingRemovedSubscriber;
        private readonly IBuildingContainer _buildingContainer;
        private readonly List<IDisposable> _subscriptions;

        public BuildingContainerEditor(ISubscriber<BuildingPlacedMessage> buildingPlacedSubscriber, ISubscriber<BuildingRemovedMessage> buildingRemovedSubscriber, IBuildingContainer buildingContainer)
        {
            _buildingPlacedSubscriber = buildingPlacedSubscriber;
            _buildingRemovedSubscriber = buildingRemovedSubscriber;
            _buildingContainer = buildingContainer;
            _subscriptions = new List<IDisposable>();
        }

        public void Initialize()
        {
            _subscriptions.Add(_buildingPlacedSubscriber.Subscribe(AddBuildingToContainer));
            _subscriptions.Add(_buildingRemovedSubscriber.Subscribe(RemoveBuildingFromContainer));
        }

        private void AddBuildingToContainer(BuildingPlacedMessage message)
        {
            _buildingContainer.TryAddBuilding(message.PlacedBuilding);
        }

        private void RemoveBuildingFromContainer(BuildingRemovedMessage message)
        {
            _buildingContainer.TryRemoveBuilding(message.RemovedBuilding.Id);
        }

        public void Dispose()
        {
            foreach (var subscription in _subscriptions)
                subscription.Dispose();
            
        }
    }
}