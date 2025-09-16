using System;
using _Game.Scripts.Application.PlacementSystem.Building;
using _Game.Scripts.Presentation.Building.ToolPanel.View;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.Building.ToolPanel
{
    public class BuildingTooPanelPresenter: IInitializable, IDisposable
    {
        private readonly IViewEnableable<ToolPanelViewData> _toolPanelView; 
        private readonly IViewInteractable<ToolPanelViewCallBack> _toolPanelViewCallBack;
        private readonly BuildingPointerClickedInvoker _pointerClickInvoker;
        private readonly IBuildingActionsProvider _buildingActionsProvider;

        public BuildingTooPanelPresenter(IViewEnableable<ToolPanelViewData> toolPanelView, IViewInteractable<ToolPanelViewCallBack> toolPanelViewCallBack, BuildingPointerClickedInvoker pointerClickInvoker, IBuildingActionsProvider buildingActionsProvider)
        {
            _toolPanelView = toolPanelView;
            _toolPanelViewCallBack = toolPanelViewCallBack;
            _pointerClickInvoker = pointerClickInvoker;
            _buildingActionsProvider = buildingActionsProvider;
        }

        public void Initialize()
        {
            _toolPanelView.Hide();
            _pointerClickInvoker.PointerClickedOnBuilding += ShowUI;
            _toolPanelViewCallBack.callback += HandleViewCallback;
        }

        private void HandleViewCallback(ToolPanelViewCallBack callback)
        {
            if (callback.Action == ToolPanelViewCallBack.ActionType.Close)
            {
                _toolPanelView.Hide();
            }
            else if (callback.Action == ToolPanelViewCallBack.ActionType.SelectTool)
            {
                switch (callback.SelectedTool.Action)
                {
                    case BuildingToolCallback.ToolAction.Edit:
                        _buildingActionsProvider.EditBuilding();
                        break;
                    case BuildingToolCallback.ToolAction.Remove:
                        _buildingActionsProvider.DeleteBuilding();
                        break;
                    case BuildingToolCallback.ToolAction.LevelUp:
                        _buildingActionsProvider.UpgradeBuilding();
                        break;
                }
            }
        }

        private void ShowUI()
        {
            _toolPanelView.Show();
        }

        public void Dispose()
        {
            _pointerClickInvoker.PointerClickedOnBuilding -= ShowUI;
            _toolPanelViewCallBack.callback -= HandleViewCallback;
        }


    }
}