using System;
using UnityEngine;

namespace _Game.Scripts.Domain.Entities.Building
{
    public class BuildingParams
    {
        public Guid Id { get; set; }
        public Vector2Int Position { get; set; }
        public int Level { get; set; }
        public Vector2Int Size { get; set; }
        public BuildingType BuildingType { get; set; }

        public BuildingParams(Guid id, Vector2Int position, int level, Vector2Int size, BuildingType buildingType)
        {
            Id = id;
            Position = position;
            Level = level;
            Size = size;
            BuildingType = buildingType;
        }
    }
    
}