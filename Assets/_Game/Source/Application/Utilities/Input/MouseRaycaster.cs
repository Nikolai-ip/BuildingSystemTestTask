using _Game.Source.Infrastructure.Input;
using UnityEngine;

namespace _Game.Source.Application.Utilities.Input
{
    public class MouseRaycaster
    {
        private readonly IInputService _inputService;
        private readonly LayerMask _planeLayerMask;
        private readonly Camera _camera;
        private readonly float _maxDistanceCast;

        public MouseRaycaster(IInputService inputService, Camera camera, float maxDistanceCast, LayerMask planeLayerMask)
        {
            _inputService = inputService;
            _camera = camera;
            _maxDistanceCast = maxDistanceCast;
            _planeLayerMask = planeLayerMask;
        }

        public bool TryRaycast()
        {
            return Physics.Raycast(GetMouseRay(), out var hit, _maxDistanceCast, _planeLayerMask);
        }

        public bool TryRaycast<T>(out T result)
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit, _maxDistanceCast, _planeLayerMask))
            {
                if (hit.collider.TryGetComponent<T>(out var component))
                {
                    result = component;
                    return true;
                }
            }

            result = default;
            return false;

        }

        private Ray GetMouseRay()
        {
            Vector3 mousePos = _inputService.MousePosition;
            mousePos.z = _camera.nearClipPlane;
            return _camera.ScreenPointToRay(mousePos);
        }
    }
}