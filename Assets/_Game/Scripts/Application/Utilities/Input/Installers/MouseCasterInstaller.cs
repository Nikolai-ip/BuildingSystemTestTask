using _Game.Scripts.DI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Application.Utilities.Input.Installers
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
            Debug.Log(_mousePosOnPlaneCaster.GetMousePos());
        }
    }
    
}