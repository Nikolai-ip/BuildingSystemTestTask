using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.Infrastructure.DI.Installers
{
    public class Context: LifetimeScope
    {
        [SerializeField] private List<IInstallerMono> _installers;
        
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }
        }
    }
}