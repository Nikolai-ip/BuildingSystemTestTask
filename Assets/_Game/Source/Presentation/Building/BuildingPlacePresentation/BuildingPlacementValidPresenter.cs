using System;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using UniRx;
using VContainer.Unity;

namespace _Game.Source.Presentation.Building.BuildingPlacePresentation
{
    public class BuildingPlacementValidPresenter: IInitializable, IDisposable
    {
        private readonly IView<BuildingModelTogglerData> _view;
        private readonly IBuildingPlacer _buildingPlacer;
        private IDisposable _placementSubscription;
        
        public BuildingPlacementValidPresenter(IBuildingPlacer buildingPlacer, IView<BuildingModelTogglerData> view)
        {
            _buildingPlacer = buildingPlacer;
            _view = view;
        }

        public void Initialize()
        {
            _placementSubscription = _buildingPlacer.CanBePlaced.Subscribe(SetView);
            SetView(true);
        }

        private void SetView(bool isValid)
        {
            _view.SetData(new BuildingModelTogglerData(isValid));
        }

        public void Dispose()
        {
            _placementSubscription.Dispose();
                
        }
    }
}