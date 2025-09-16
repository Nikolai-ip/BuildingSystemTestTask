using System;
using _Game.Scripts.Application.Utilities;
using _Game.Scripts.Domain.Entities.Building;
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
                if (_incomeBuildingsParams.TryGetIncome(_buildingContainer[i].BuildingType, out int income))
                    _currencyHolder.AddCoins(income);
            }    
        }


    }
}