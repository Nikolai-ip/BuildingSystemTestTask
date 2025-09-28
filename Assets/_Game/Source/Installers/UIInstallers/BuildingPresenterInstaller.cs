using System.Collections.Generic;
using _Game.Source.Application.Utilities.Input;
using _Game.Source.Data.StaticData;
using _Game.Source.DI;
using _Game.Source.Presentation;
using _Game.Source.Presentation.Building;
using _Game.Source.Presentation.Building.BuildingPlacePresentation;
using _Game.Source.Presentation.Building.ToolPanel;
using _Game.Source.Presentation.Building.ToolPanel.View;
using _Game.Source.Presentation.Building.UpgradeButton;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.UIInstallers
{
    public class BuildingPresenterInstaller: IInstallerMono
    {
        [SerializeField] private float _rayCastDistance;
        [SerializeField] private LayerMask _buildingLayerMask;
        [SerializeField] private ToolPanelView _view;
        [SerializeField] private List<ButtonView<BuildingToolCallback>> _toolButtons;
        [SerializeField] private ButtonView<BuildingToolCallback> _upgradeButton;
        [SerializeField] private BuildingUpgradeCostData_SO _buildingUpgradeCostDataSo;
        [SerializeField] private BuildingModelToggler _modelTogglerView;
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

            builder
                .RegisterInstance(_modelTogglerView)
                .As<IView<BuildingModelTogglerData>>();
            builder
                .Register<BuildingPlacementValidPresenter>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}