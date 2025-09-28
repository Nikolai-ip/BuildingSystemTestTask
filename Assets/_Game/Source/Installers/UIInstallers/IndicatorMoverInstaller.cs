using _Game.Source.DI;
using _Game.Source.Presentation.PlacementBuildingsUI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Source.Installers.UIInstallers
{
    public class PlacementSystemInstaller: IInstallerMono
    {
        [SerializeField] private Transform _indicator;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IndicatorMover>(Lifetime.Scoped).As<ITickable>().WithParameter(_indicator);
        }
    }
}