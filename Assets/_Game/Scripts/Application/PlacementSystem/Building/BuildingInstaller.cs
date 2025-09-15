using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingInstaller: IInstallerMono
    {
        [SerializeField] private BuildingDataComponent _buildingDataComponent;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<Transform>(transform);
            builder.RegisterInstance<BuildingDataComponent>(_buildingDataComponent);
            builder.Register<BuildingPlacer>(Lifetime.Singleton);
            builder.Register<BuildingFSM>(Lifetime.Singleton);
        }
    }
}