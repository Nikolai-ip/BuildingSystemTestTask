using _Game.Scripts.Application;
using _Game.Scripts.Application.PlacementSystem;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.PlacementSystem.Factories;
using _Game.Scripts.Data.StaticData;
using _Game.Scripts.DI;
using _Game.Scripts.Domain.Entities;
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
            builder.Register<GridData>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GridPointerPosition>(Lifetime.Transient);
            
            builder.RegisterInstance(_buildingDataBase.GetDataBase());
            
            builder.Register<BuildingFactoryBase>(Lifetime.Scoped)
                .As<IFactory<BuildingDataComponent, BuildingParams>>().WithParameter(BuildingState.Edit).Keyed(BuildingFactoryKey.Runtime);
            builder.Register<BuildingFactoryBase>(Lifetime.Scoped)
                .As<IFactory<BuildingDataComponent, BuildingParams>>().WithParameter(BuildingState.Idle).Keyed(BuildingFactoryKey.Restore);

            builder.Register<BuildingContainer>(Lifetime.Singleton).As<IBuildingContainer>();
            builder.Register<BuildingRuntimeSpawner>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BuildingContainerEditor>(Lifetime.Singleton).AsImplementedInterfaces();
            
        }
    }
}