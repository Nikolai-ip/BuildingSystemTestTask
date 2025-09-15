using System;
using _Game.Scripts.Application.Utilities;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.Services.Economy
{
    public class BuildingEconomyService
    {
        private readonly IBuildingContainer _buildingContainer;
        private readonly IncomeBuildingsParams _incomeBuildingsParams;
        private TimeSpan _interval;
        private readonly CurrencyHolder _currencyHolder;
        private readonly Stopwatch _stopwatch;

        public BuildingEconomyService(IBuildingContainer buildingContainer, IncomeBuildingsParams incomeBuildingsParams, CurrencyHolder currencyHolder)
        {
            _buildingContainer = buildingContainer;
            _incomeBuildingsParams = incomeBuildingsParams;
            _currencyHolder = currencyHolder;
            _stopwatch = new Stopwatch(_interval);
        }
        
        private void Start()
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