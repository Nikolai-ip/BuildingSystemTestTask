using _Game.Scripts.Application.PlacementSystem;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Factories;
using _Game.Scripts.Data.StaticData;
using _Game.Scripts.DI;
using _Game.Scripts.Domain.Entities.Building;
using _Game.Scripts.Infrastructure;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Installers
{
    public class PlacementSystemInstaller: IInstallerMono
    {
        [SerializeField] private BuildingDataBase_SO _buildingDataBase;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<GridPointerPosition>(Lifetime.Transient);
            
            builder.RegisterInstance(_buildingDataBase.GetDataBase());
            
            builder.Register<BuildingFactoryBase>(Lifetime.Scoped)
                .As<IFactory<BuildingDataComponent, BuildingParams>>().WithParameter(BuildingState.Edit);
            
            builder.Register<BuildingSpawner>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}