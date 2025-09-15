using System;
using _Game.Scripts.Domain.Entities.Building;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem
{
    public class BuildingDataComponent: MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private BuildingType _type;
        private BuildingParams _buildingParams;

        public void Init(BuildingParams @params, BuildingState state) => _buildingParams = @params;
        public BuildingParams GetBuildingParams()
        {
            _buildingParams ??= new(Guid.Empty, Vector2Int.zero, 0, _size, _type);
            return _buildingParams;
        }
    }
}