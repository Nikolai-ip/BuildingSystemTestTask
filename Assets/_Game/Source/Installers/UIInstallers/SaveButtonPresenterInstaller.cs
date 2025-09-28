using _Game.Source.DI;
using _Game.Source.Presentation;
using _Game.Source.Presentation.SaveButton;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.UIInstallers
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