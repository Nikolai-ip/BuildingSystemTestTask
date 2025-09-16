using System;
using System.Collections.Generic;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Building.Messages;
using _Game.Scripts.Domain.Entities.Building;
using MessagePipe;
using VContainer.Unity;

namespace _Game.Scripts.Application
{

    /// <summary>
    /// Subscribes to building placement and removal events and keeps 
    /// the <see cref="IBuildingContainer"/> in sync with these events.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IInitializable"/> and <see cref="IDisposable"/>:
    /// <list type="bullet">
    /// <item>
    /// <description>In <see cref="Initialize"/>, it subscribes to <see cref="BuildingPlacedMessage"/> and <see cref="BuildingRemovedMessage"/> events.</description>
    /// </item>
    /// <item>
    /// <description>In <see cref="Dispose"/>, it disposes of all active subscriptions to prevent memory leaks.</description>
    /// </item>
    /// </list>
    /// Use this class to ensure the building container remains up-to-date when buildings are added or removed elsewhere in the system.
    /// </remarks>
    public class BuildingContainerUpdater: IInitializable, IDisposable
    {
        private readonly ISubscriber<BuildingPlacedMessage> _buildingPlacedSubscriber;
        private readonly ISubscriber<BuildingRemovedMessage> _buildingRemovedSubscriber;
        private readonly IBuildingContainer _buildingContainer;
        private readonly List<IDisposable> _subscriptions;

        public BuildingContainerUpdater(ISubscriber<BuildingPlacedMessage> buildingPlacedSubscriber, ISubscriber<BuildingRemovedMessage> buildingRemovedSubscriber, IBuildingContainer buildingContainer)
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