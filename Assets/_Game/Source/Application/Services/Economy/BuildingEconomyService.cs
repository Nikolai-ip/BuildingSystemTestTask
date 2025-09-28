using System;
using _Game.Source.Application.Utilities;
using _Game.Source.Domain.Entities.Building;
using VContainer.Unity;

namespace _Game.Source.Application.Services.Economy
{
    /// <summary>
    /// Service responsible for calculating income from buildings at regular intervals.
    /// Periodically iterates over all buildings in the container and adds their income to the player's currency holder.
    /// </summary>
    public class BuildingEconomyService: IInitializable
    {
        private readonly IBuildingContainer _buildingContainer;
        private readonly IncomeBuildingsParams _incomeBuildingsParams;
        private readonly TimeSpan _interval;
        private readonly CurrencyHolder _currencyHolder;
        private readonly Stopwatch _stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingEconomyService"/> class.
        /// </summary>
        /// <param name="buildingContainer">The container holding all current buildings.</param>
        /// <param name="incomeBuildingsParams">The parameters defining income for each building type and level.</param>
        /// <param name="currencyHolder">The currency holder where income is added.</param>
        /// <param name="interval">The interval at which income is calculated.</param>
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

        
        /// <summary>
        /// Calculates income for each building based on its type and level,
        /// and adds it to the currency holder.
        /// </summary>
        private void CalculateIncome()
        {
            for (int i = 0; i < _buildingContainer.Count; i++)
            {
                var buildingParams = _buildingContainer[i];
                if (_incomeBuildingsParams.TryGetIncome(buildingParams.BuildingType, buildingParams.Level, out int income))
                    _currencyHolder.AddCoins(income);
                
            }    
        }
    }
}