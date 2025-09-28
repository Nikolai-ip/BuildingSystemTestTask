using System;
using UnityEngine;

namespace _Game.Source.Domain.Entities.Building
{
    public class BuildingParams
    {
        public Guid Id { get; set; }
        public Vector3Int Position { get; set; }
        public int Level { get; set; }
        public Vector3Int Size { get; set; }
        public BuildingType BuildingType { get; set; }

        public BuildingParams(Guid id, Vector3Int position, int level, Vector3Int size, BuildingType buildingType)
        {
            Id = id;
            Position = position;
            Level = level;
            Size = size;
            BuildingType = buildingType;
        }
    }
    
}