using UnityEngine;

namespace _Game.Scripts.Application.Utilities.Input
{
    public class GridVectorConverter
    {
        private readonly Grid _grid;

        public GridVectorConverter(Grid grid)
        {
            _grid = grid;
        }

        public Vector3 ConvertWorldToCellInWorld(Vector3 worldPos)
        {
            return _grid.CellToWorld(ConvertToCell(worldPos));
        }

        public Vector3 CellToWorld(Vector3Int cellPos) => _grid.CellToWorld(cellPos);

        public Vector3Int ConvertToCell(Vector3 worldPos)
        {
            return _grid.WorldToCell(worldPos);
        }
    }
}