namespace _Game.Source.Application.PlacementSystem.Building
{
    /// <summary>
    /// Provides a set of actions that can be performed on a building.
    /// Acts as a provider to the building logic,
    /// </summary>
    public interface IBuildingActionsProvider
    {
        /// <summary>
        /// Initiates editing of the building (e.g., moving or modifying its properties).
        /// </summary>
        void EditBuilding();

        /// <summary>
        /// Initiates removal of the building from the grid and destroy object.
        /// </summary>
        void DeleteBuilding();

        /// <summary>
        /// Initiates the upgrade process for the building, increasing its level or attributes.
        /// </summary>
        void UpgradeBuilding();
    }
}