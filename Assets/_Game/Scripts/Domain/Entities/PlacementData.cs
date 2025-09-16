using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Domain.Entities
{
    internal class PlacementData
    {
        public List<Vector3Int> OccupiedPositions { get; }
        public Guid ID { get; private set; }

        public PlacementData(List<Vector3Int> occupiedPositions, Guid id)
        {
            ID = id;
            OccupiedPositions = occupiedPositions;
        }
    }
}