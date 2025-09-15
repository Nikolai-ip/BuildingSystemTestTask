using _Game.Scripts.DI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingInstaller: IInstallerMono
    {
        [SerializeField] private Vector3 _buildingMoveOffset;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<Transform>(transform);
            builder.Register<BuildingPlacer>(Lifetime.Singleton).WithParameter(_buildingMoveOffset).AsSelf().AsImplementedInterfaces();
            builder.Register<BuildingFSM>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent<BuildingDataComponent>(GetComponent<BuildingDataComponent>());
        }
        
    }
}