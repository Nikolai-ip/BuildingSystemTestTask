using UnityEngine;

namespace _Game.Scripts.Presentation.Building.BuildingPlacePresentation
{
    public class BuildingModelToggler: MonoBehaviour, IView<BuildingModelTogglerData>
    {
        [SerializeField] private GameObject _notValidPlacementModel;
        [SerializeField] private GameObject _validPlacementModel;
        public void SetData(BuildingModelTogglerData data)
        {
            _validPlacementModel.SetActive(data.PlacementIsValid);
            _notValidPlacementModel.SetActive(!data.PlacementIsValid);
        }
    }

    public struct BuildingModelTogglerData
    {
        public bool PlacementIsValid { get; }

        public BuildingModelTogglerData(bool placementIsValid)
        {
            PlacementIsValid = placementIsValid;
        }
    }
}