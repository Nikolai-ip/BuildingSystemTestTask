using System;
using UniRx;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem.Building.PlaceFeature
{
    /// <summary>
    /// Defines a contract for placing buildings on a grid.
    /// Provides functionality for starting the placement process, 
    /// confirming placement, and notifying when a building has been placed.
    /// </summary>
    public interface IBuildingPlacer
    {
        /// <summary>
        /// Occurs when a building has been successfully placed on the grid.
        /// </summary>
        event Action<Vector3Int> OnBuildingPlaced;

        /// <summary>
        /// Gets the current grid position of the building being placed.
        /// </summary>
        Vector3Int BuildingPos { get; }

        /// <summary>
        /// Gets a reactive property that indicates whether the building 
        /// can currently be placed at the specified position.
        /// </summary>
        ReactiveProperty<bool> CanBePlaced { get; }

        /// <summary>
        /// Starts the building placement process, preparing it for positioning on the grid.
        /// </summary>
        void StartPlace();

        /// <summary>
        /// Confirms and places the building at the current grid position.
        /// </summary>
        void PlaceObject();
    }
}