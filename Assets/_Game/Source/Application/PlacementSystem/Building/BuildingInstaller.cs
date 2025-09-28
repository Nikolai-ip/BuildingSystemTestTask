using _Game.Source.Application.PlacementSystem.Building.Messages;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Application.PlacementSystem.Building.UpgradeFeature;
using _Game.Source.DI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Source.Application.PlacementSystem.Building
{
    public class BuildingInstaller: IInstallerMono
    {
        [SerializeField] private Vector3 _buildingMoveOffset;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<Transform>(transform);
            builder.Register<BuildingPlacer>(Lifetime.Singleton).WithParameter(_buildingMoveOffset).AsImplementedInterfaces();
            builder.Register<BuildingFSM>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent<BuildingDataComponent>(GetComponent<BuildingDataComponent>());
            builder.Register<BuildingActivePublisher>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BuildingUpgrader>(Lifetime.Singleton).As<IBuildingUpgrader>();
            builder.Register<BuildingActionsProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BuildingObjectRemover>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(gameObject);
        }
        
    }
}