using _Game.Scripts.Infrastructure.Input;
using UnityEngine;

namespace _Game.Scripts.Application.Utilities.Input
{
    public class MousePosOnPlaneCaster
    {
        private readonly IInputService _inputService;
        private readonly LayerMask _planeLayerMask;
        private Vector3 _lastPos;
        private readonly Camera _camera;
        private readonly float _maxDistanceCast;

        public MousePosOnPlaneCaster(IInputService inputService, Camera camera, float maxDistanceCast, LayerMask planeLayerMask)
        {
            _inputService = inputService;
            _camera = camera;
            _maxDistanceCast = maxDistanceCast;
            _planeLayerMask = planeLayerMask;
        }

        public Vector3 GetMousePositionOnPlane()
        {
            Vector3 mousePos = _inputService.MousePosition;
            mousePos.z = _camera.nearClipPlane;
            Ray ray = _camera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _maxDistanceCast, _planeLayerMask))
                _lastPos =  hit.point;
            
            return _lastPos;
        }
    }
}