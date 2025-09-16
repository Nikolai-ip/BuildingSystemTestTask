using UnityEngine;

namespace _Game.Scripts.Domain.Entities
{
    public interface IGridObjectRemover
    {
        void RemoveObjectAt(Vector3Int gridPosition, Vector3Int objectSize);
    }
}