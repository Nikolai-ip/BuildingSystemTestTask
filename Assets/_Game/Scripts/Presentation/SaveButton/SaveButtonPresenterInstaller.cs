using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Presentation.SaveButton
{
    public class SaveButtonPresenterInstaller: IInstallerMono
    {
        [SerializeField] private ButtonView<SaveLoadButton> _buttonView;
        public override void Install(IContainerBuilder builder)
        {
            builder
                .RegisterInstance(_buttonView)
                .As<IViewInteractable<SaveLoadButton>>();
            
            builder
                .Register<SaveButtonPresenter>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}