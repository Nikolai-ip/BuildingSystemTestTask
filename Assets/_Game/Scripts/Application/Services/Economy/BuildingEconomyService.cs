using System;
using _Game.Scripts.Application.Utilities;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;
using VContainer.Unity;

namespace _Game.Scripts.Application.Services.Economy
{
    public class BuildingEconomyService: IInitializable
    {
        private readonly IBuildingContainer _buildingContainer;
        private readonly IncomeBuildingsParams _incomeBuildingsParams;
        private readonly TimeSpan _interval;
        private readonly CurrencyHolder _currencyHolder;
        private readonly Stopwatch _stopwatch;

        public BuildingEconomyService(IBuildingContainer buildingContainer, IncomeBuildingsParams incomeBuildingsParams, CurrencyHolder currencyHolder, TimeSpan interval)
        {
            _buildingContainer = buildingContainer;
            _incomeBuildingsParams = incomeBuildingsParams;
            _currencyHolder = currencyHolder;
            _interval = interval;
            _stopwatch = new Stopwatch(_interval);
        }
        public void Initialize()
        {
            _stopwatch.OnTick += CalculateIncome;
            _stopwatch.Start();
        }

        private void CalculateIncome()
        {
            for (int i = 0; i < _buildingContainer.Count; i++)
            {
                var buildingParams = _buildingContainer[i];
                if (_incomeBuildingsParams.TryGetIncome(buildingParams.BuildingType, buildingParams.Level, out int income))
                {
                    Debug.Log($"[BuildingEconomyService.CalculateIncome] add income {income} coins from {buildingParams.BuildingType} with level {buildingParams.Level}");
                    _currencyHolder.AddCoins(income);
                }
            }    
        }


    }
}