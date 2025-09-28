using System;

namespace _Game.Source.Application.PlacementSystem.Building.UpgradeFeature
{
    /// <summary>
    /// Defines a contract for upgrading a building.
    /// Implementations handle the logic for increasing the building's level.
    /// </summary>
    public interface IBuildingUpgrader
    {
        /// <summary>
        /// Upgrades the building, increasing its level or improving its attributes.
        /// </summary>
        void Upgrade();

        /// <summary>
        /// Occurs when the building has been successfully upgraded.
        /// </summary>
        event Action OnUpgraded;
    }
}