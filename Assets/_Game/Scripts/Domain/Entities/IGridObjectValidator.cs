using UnityEngine;

namespace _Game.Scripts.Domain.Entities
{
    public interface IGridObjectValidator
    {
        bool CanPlaceObjectAt(Vector3Int objectPos, Vector3Int objectSize);
    }
}