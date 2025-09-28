using System;
using System.Collections.Generic;

namespace _Game.Source.Domain.Entities.Building
{
    /// <summary>
    /// Represents a container that manages building instances.
    /// Provides methods for adding, removing, and accessing buildings,
    /// as well as notifying subscribers when the container state changes.
    /// </summary>
    public interface IBuildingContainer
    {
        /// <summary>
        /// Attempts to add a building to the container.
        /// </summary>
        /// <param name="buildingParams">The parameters of the building to add.</param>
        /// <returns>
        /// <c>true</c> if the building was successfully added; otherwise, <c>false</c>.
        /// </returns>
        bool TryAddBuilding(BuildingParams buildingParams);
        
        /// <summary>
        /// Attempts to remove a building from the container by its unique identifier.
        /// </summary>
        /// <param name="buildingId">The unique identifier of the building to remove.</param>
        /// <returns>
        /// <c>true</c> if the building was successfully removed; otherwise, <c>false</c>.
        /// </returns>
        bool TryRemoveBuilding(Guid buildingId);
        /// <summary>
        /// Gets the number of buildings currently stored in the container.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the building parameters at the specified index.
        /// </summary>
        /// <param name="i">The index of the building to retrieve.</param>
        /// <returns>The <see cref="BuildingParams"/> at the specified index.</returns>
        BuildingParams this[int i] { get; }

        /// <summary>
        /// Occurs when the contents of the container have changed.
        /// </summary>
        event Action<List<BuildingParams>> OnContainerChanged;
    }
}