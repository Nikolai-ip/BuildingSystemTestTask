using _Game.Scripts.Application.SavedData;
using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Installers.SaveLoadInstallers
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