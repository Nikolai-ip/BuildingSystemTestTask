using System;
using _Game.Scripts.Application.Services.Economy;
using _Game.Scripts.Data.StaticData;
using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Installers
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