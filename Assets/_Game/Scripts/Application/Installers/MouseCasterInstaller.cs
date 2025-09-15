using _Game.Scripts.Application.Utilities.Input;
using _Game.Scripts.Infrastructure.DI.Installers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.Installers
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

            builder.Register<Test>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }

    class Test: ITickable
    {
        MousePosOnPlaneCaster _mousePosOnPlaneCaster;

        public Test(MousePosOnPlaneCaster mousePosOnPlaneCaster)
        {
            _mousePosOnPlaneCaster = mousePosOnPlaneCaster;
        }

        public void Tick()
        {
            Debug.Log(_mousePosOnPlaneCaster.GetMousePositionOnPlane());
        }
    }
    
}