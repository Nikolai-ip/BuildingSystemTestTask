using System;
using _Game.Source.Application.Services.Economy;
using _Game.Source.Data.StaticData;
using _Game.Source.DI;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.EconomyInstallers
{
    public class BuildingEconomyServiceInstaller: IInstallerMono
    {
        [SerializeField] private IncomeBuildingsParams_SO _incomeBuildingsParams;
        [SerializeField] private float _calculateIncomeInterval;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BuildingEconomyService>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .WithParameter(_incomeBuildingsParams.GetIncomeBuildingsParams())
                .WithParameter(TimeSpan.FromSeconds(_calculateIncomeInterval));
        }
    }
}