using System;
using UnityEngine;

namespace _Game.Scripts.Domain.Entities.Building
{
    public struct BuildingParams
    {
        public Guid Id { get; set; }
        public Vector2Int Position { get; set; }
        public int Level { get; set; }
        public Vector2Int Size { get; set; }
        public BuildingType BuildingType { get; set; }
    }
}