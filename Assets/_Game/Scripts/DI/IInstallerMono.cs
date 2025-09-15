using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.DI
{
    public abstract class IInstallerMono: MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}