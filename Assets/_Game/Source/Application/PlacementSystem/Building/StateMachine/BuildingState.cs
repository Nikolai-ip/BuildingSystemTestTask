namespace _Game.Source.Application.PlacementSystem.Building.StateMachine
{
    /// <summary>
    /// Represents the current state of a building within the grid system.
    /// </summary>
    public enum BuildingState
    {
        /// <summary>
        /// No state is assigned to the building.
        /// </summary>
        None,

        /// <summary>
        /// The building is placed on the grid and remains idle.
        /// </summary>
        Idle,

        /// <summary>
        /// The building is in edit mode and can be modified (e.g., moved or adjusted).
        /// </summary>
        Edit,

        /// <summary>
        /// The building is marked for removal from the grid.
        /// </summary>
        Remove
    }
}