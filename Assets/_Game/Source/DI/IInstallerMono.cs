using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Source.DI
{
    public abstract class IInstallerMono: MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}