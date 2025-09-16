using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Domain.Entities
{
    public class GridData : IGridObjectAdder, IGridObjectValidator
    {
        private readonly Dictionary<Vector3Int, PlacementData> _placementObjects = new();

        public void AddObjectAt(Vector3Int gridPosition, Vector3Int objectSize, Guid id)
        {
            List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
            PlacementData data = new PlacementData(positionToOccupy, id);
            foreach (var pos in positionToOccupy)
            {
                if (_placementObjects.ContainsKey(pos))
                {
                    throw new Exception($"Dictionary already contains the cell pos {pos}");
                }
                _placementObjects[pos] = data;
            }
        }

        private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector3Int objectSize)
        {
            var result = new List<Vector3Int>();
            for (int x = 0; x < objectSize.x; x++)
            {
                for (int y = 0; y < objectSize.y; y++)
                {
                    result.Add(gridPosition + new Vector3Int(x, 0, y));
                }
            }

            return result;
        }

        public bool CanPlaceObjectAt(Vector3Int objectPos, Vector3Int objectSize)
        {
            List<Vector3Int> positionToOccupy = CalculatePositions(objectPos, objectSize);
            foreach (var pos in positionToOccupy)
            {
                if (_placementObjects.ContainsKey(pos))
                    return false;
            }

            return true;
        }
    }
}