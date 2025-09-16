using System.Collections.Generic;
using _Game.Scripts.Application;
using _Game.Scripts.Data.StaticData;
using _Game.Scripts.DI;
using _Game.Scripts.Presentation.PlacementSystem.View;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Presentation.PlacementSystem.Installers
{
    public class BuildingShopInstaller: IInstallerMono
    {
        [SerializeField] private BuildingsShopView _view;
        [SerializeField] private List<BuyBuildingButton> _buyButtons;
        [SerializeField] private BuildingsShopCatalog_SO _catalog;
        public override void Install(IContainerBuilder builder)
        {
            _view.Init(_buyButtons);
            builder.RegisterInstance<BuildingsShopView>(_view)
                .As<IView<BuildingsShopViewData>>()
                .As<IViewInteractable<BuildingPurchasedCallback>>();
            
            builder.RegisterInstance<BuildingsShopCatalog>(_catalog.GetCatalogue());
            
            builder.Register<BuildingsShopPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}