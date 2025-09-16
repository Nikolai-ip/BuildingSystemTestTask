using System.Collections.Generic;
using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.DI;
using _Game.Scripts.Presentation.Building.BuildingToolsPresenter;
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
        }
    }
}