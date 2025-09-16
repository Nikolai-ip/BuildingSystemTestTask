using System;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.Infrastructure.Input;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.Building
{
    public class BuildingPointerClickedInvoker: IInitializable, IDisposable
    {
        private readonly MouseRaycaster _mouseRaycaster;
        private readonly IInputService _inputService;
        private BuildingDataComponent _buildingDataComponent;
        public event Action PointerClickedOnBuilding;

        public BuildingPointerClickedInvoker(MouseRaycaster mouseRaycaster, IInputService inputService, BuildingDataComponent buildingDataComponent)
        {
            _mouseRaycaster = mouseRaycaster;
            _inputService = inputService;
            _buildingDataComponent = buildingDataComponent;
        }

        public void Initialize()
        {
            _inputService.OnLeftMouseButtonClicked += RayCastToMouse;
        }

        private void RayCastToMouse()
        {
            if (_inputService.IsPointerOverUI()) return;
            if (_mouseRaycaster.TryRaycast(out BuildingDataComponent component))
            {
                if (component == _buildingDataComponent)
                    PointerClickedOnBuilding?.Invoke();
            }
            
        }
        
        public void Dispose()
        {
            _inputService.OnLeftMouseButtonClicked -= RayCastToMouse;
        }
    }
}