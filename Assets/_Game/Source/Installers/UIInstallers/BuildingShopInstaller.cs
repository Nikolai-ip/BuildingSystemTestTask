using System.Collections.Generic;
using _Game.Source.Data.GameData;
using _Game.Source.Data.StaticData;
using _Game.Source.DI;
using _Game.Source.Presentation;
using _Game.Source.Presentation.PlacementBuildingsUI;
using _Game.Source.Presentation.PlacementBuildingsUI.View;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.UIInstallers
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