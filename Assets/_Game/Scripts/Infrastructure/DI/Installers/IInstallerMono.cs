using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Infrastructure.DI.Installers
{
    public abstract class IInstallerMono: MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}