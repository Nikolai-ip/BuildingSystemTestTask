using _Game.Source.Application;
using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Application.PlacementSystem.Factories;
using _Game.Source.Application.Utilities.Input;
using _Game.Source.Data.StaticData;
using _Game.Source.DI;
using _Game.Source.Domain.Entities;
using _Game.Source.Domain.Entities.Building;
using _Game.Source.Infrastructure;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers
{
    public class PlacementSystemInstaller: IInstallerMono
    {
        [SerializeField] private BuildingDataBase_SO _buildingDataBase;
        [SerializeField] private Transform _buildingContainer;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<GridData>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GridPointerPosition>(Lifetime.Transient);
            
            builder.RegisterInstance(_buildingDataBase.GetDataBase());
            
            builder.Register<BuildingFactoryBase>(Lifetime.Scoped)
                .As<IFactory<BuildingDataComponent, BuildingParams>>().WithParameter(BuildingState.Edit).WithParameter(_buildingContainer).Keyed(BuildingFactoryKey.Runtime);
            builder.Register<BuildingFactoryBase>(Lifetime.Scoped)
                .As<IFactory<BuildingDataComponent, BuildingParams>>().WithParameter(BuildingState.Idle).WithParameter(_buildingContainer).Keyed(BuildingFactoryKey.Restore);

            builder.Register<BuildingContainer>(Lifetime.Singleton).As<IBuildingContainer>();
            builder.Register<BuildingRuntimeSpawner>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BuildingContainerUpdater>(Lifetime.Singleton).AsImplementedInterfaces();
            
        }
    }
}