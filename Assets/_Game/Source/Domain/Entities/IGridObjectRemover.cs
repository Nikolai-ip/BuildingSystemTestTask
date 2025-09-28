using UnityEngine;

namespace _Game.Source.Domain.Entities
{
    /// <summary>
    /// Defines a contract for removing objects from a grid.
    /// </summary>
    public interface IGridObjectRemover
    {
        /// <summary>
        /// Removes an object of the specified size starting at the given grid position.
        /// </summary>
        /// <param name="gridPosition">The starting grid position of the object to remove.</param>
        /// <param name="objectSize">The size of the object in grid cells.</param>
        void RemoveObjectAt(Vector3Int gridPosition, Vector3Int objectSize);
    }
}