using UnityEngine;

namespace _Game.Source.Domain.Entities
{
    /// <summary>
    /// Defines a contract for validating whether an object can be placed at a specific grid position.
    /// </summary>
    public interface IGridObjectValidator
    {
        /// <summary>
        /// Determines whether an object of the specified size can be placed at the given position on the grid.
        /// </summary>
        /// <param name="objectPos">The grid position to check for placement.</param>
        /// <param name="objectSize">The size of the object in grid cells.</param>
        /// <returns>
        /// <c>true</c> if the object can be placed at the specified position; otherwise, <c>false</c>.
        /// </returns>
        bool CanPlaceObjectAt(Vector3Int objectPos, Vector3Int objectSize);
    }
}