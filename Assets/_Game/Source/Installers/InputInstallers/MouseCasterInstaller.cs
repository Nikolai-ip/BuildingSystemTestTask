using _Game.Source.Application.Utilities.Input;
using _Game.Source.DI;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.InputInstallers
{
    public class MouseCasterInstaller: IInstallerMono
    {
        [SerializeField] private LayerMask _planeLayerMask;
        [SerializeField] private float _maxDistance;
        public override void Install(IContainerBuilder builder)
        {
            builder
                .Register<MousePosOnPlaneCaster>(Lifetime.Transient)
                .WithParameter<Camera>(Camera.main)
                .WithParameter<LayerMask>(_planeLayerMask)
                .WithParameter<float>(_maxDistance)
                .AsSelf();
        }
        
    }
    
}