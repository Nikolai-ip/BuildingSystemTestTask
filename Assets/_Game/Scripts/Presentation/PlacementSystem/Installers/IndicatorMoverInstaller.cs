using _Game.Scripts.DI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Presentation.PlacementSystem.Installers
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