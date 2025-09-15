using _Game.Scripts.Application.Utilities.Input;
using UnityEngine;

namespace _Game.Scripts.Application.PlacementSystem
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
    }
}