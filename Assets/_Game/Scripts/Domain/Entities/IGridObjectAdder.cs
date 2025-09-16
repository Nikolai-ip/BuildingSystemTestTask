using System;
using UnityEngine;

namespace _Game.Scripts.Domain.Entities
{
    public interface IGridObjectAdder
    {
        void AddObjectAt(Vector3Int gridPosition, Vector3Int objectSize, Guid id);
    }
}