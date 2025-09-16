using System.Collections.Generic;
using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.Data.StaticData;
using _Game.Scripts.DI;
using _Game.Scripts.Presentation.Building.BuildingToolsPresenter;
using _Game.Scripts.Presentation.Building.UpgradeButton;
using _Game.Scripts.Presentation.PlacementSystem;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Presentation.Building
{
    public class BuildingPresenterInstaller: IInstallerMono
    {
        [SerializeField] private float _rayCastDistance;
        [SerializeField] private LayerMask _buildingLayerMask;
        [SerializeField] private ToolPanelView _view;
        [SerializeField] private List<ButtonView<BuildingToolCallback>> _toolButtons;
        [SerializeField] private ButtonView<BuildingToolCallback> _upgradeButton;
        [SerializeField] private BuildingUpgradeCostData_SO _buildingUpgradeCostDataSo;
        public override void Install(IContainerBuilder builder)
        {
            builder
                .Register<MouseRaycaster>(Lifetime.Singleton)
                .WithParameter(_rayCastDistance)
                .WithParameter(_buildingLayerMask)
                .WithParameter(Camera.main);
            builder
                .Register<BuildingPointerClickedInvoker>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            _view.Construct(_toolButtons);
            builder.RegisterInstance<ToolPanelView>(_view).AsImplementedInterfaces();
            builder
                .Register<BuildingTooPanelPresenter>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder
                .RegisterInstance<ButtonView<BuildingToolCallback>>(_upgradeButton)
                .As<IView<ButtonViewData>>()
                .As<IViewInteractable<BuildingToolCallback>>();
            
            builder
                .Register<UpgradeButtonPresenter>(Lifetime.Singleton)
                .AsImplementedInterfaces().WithParameter(_buildingUpgradeCostDataSo.GetUpgradeCostData());
        }
    }
}