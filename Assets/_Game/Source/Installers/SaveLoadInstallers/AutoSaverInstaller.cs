using _Game.Source.Application.SaveUseCase;
using _Game.Source.DI;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.SaveLoadInstallers
{
    public class AutoSaverInstaller: IInstallerMono
    {
        [SerializeField] private float _saveIntervalSeconds;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<AutoSaver>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_saveIntervalSeconds);
        }
    }
}