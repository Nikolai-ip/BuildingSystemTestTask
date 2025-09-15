using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts.DI
{
    public class Context: LifetimeScope
    {
        [SerializeField] private List<IInstallerMono> _installers;
        [SerializeField] private ContextType _contextType;
        public ContextType ContextType => _contextType;
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }
        }

        protected override LifetimeScope FindParent()
        {
            return FindParentContext();
        }

        private LifetimeScope FindParentContext()
        {
            var parentContexts = FindObjectsByType<Context>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Where(context => context.ContextType < _contextType).ToList();
            if (parentContexts.Count > 1)
            {
                Debug.LogWarning($"There is more than one parent context in the scene for {_contextType} context in {gameObject.name}");
            }

            return parentContexts.FirstOrDefault();
        }
    }

    public enum ContextType
    {
        Project,
        Scene,
        Object,
    }
}