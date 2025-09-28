namespace _Game.Source.Application.PlacementSystem.Building.PlaceFeature
{
    /// <summary>
    /// Defines a contract for removing a building from the grid.
    /// Implementations are responsible for updating the grid state,
    /// but not for destroying the actual building GameObject.
    /// </summary>
    public interface IBuildingRemover
    {
        /// <summary>
        /// Removes the building from the grid at its current position.
        /// </summary>
        void RemoveObject();
    }
}