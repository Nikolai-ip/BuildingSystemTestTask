using UnityEngine;

namespace _Game.Source.Application.Utilities.Input
{
    public class GridPointerPosition
    {
        private readonly MousePosOnPlaneCaster _mousePosOnPlaneCaster;
        private readonly GridVectorConverter _gridVectorConverter;

        public GridPointerPosition(MousePosOnPlaneCaster mousePosOnPlaneCaster, GridVectorConverter gridVectorConverter)
        {
            _mousePosOnPlaneCaster = mousePosOnPlaneCaster;
            _gridVectorConverter = gridVectorConverter;
        }

        public Vector3 GetPosition()
        {
            return _gridVectorConverter.ConvertWorldToCellInWorld(_mousePosOnPlaneCaster.GetMousePos());
        }   
        public Vector3Int PointerPosToCell() => _gridVectorConverter.ConvertToCell(_mousePosOnPlaneCaster.GetMousePos());

        public Vector3 CellToWorld(Vector3Int cellPos) => _gridVectorConverter.CellToWorld(cellPos);
    }
}