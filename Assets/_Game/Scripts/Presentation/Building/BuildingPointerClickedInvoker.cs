using System;
using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.Infrastructure.Input;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.Building
{
    public class BuildingPointerClickedInvoker: IInitializable, IDisposable
    {
        private readonly MouseRaycaster _mouseRaycaster;
        private readonly IInputService _inputService;
        public event Action PointerClickedOnBuilding;

        public BuildingPointerClickedInvoker(MouseRaycaster mouseRaycaster, IInputService inputService)
        {
            _mouseRaycaster = mouseRaycaster;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _inputService.OnLeftMouseButtonClicked += RayCastToMouse;
        }

        private void RayCastToMouse()
        {
            if (_inputService.IsPointerOverUI()) return;
            if (_mouseRaycaster.TryRaycast())
                PointerClickedOnBuilding?.Invoke();
            
        }
        
        public void Dispose()
        {
            _inputService.OnLeftMouseButtonClicked -= RayCastToMouse;
        }
    }
}