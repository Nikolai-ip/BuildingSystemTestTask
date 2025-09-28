using System;
using _Game.Source.Application.Services.SaveLoadService;
using VContainer.Unity;

namespace _Game.Source.Presentation.SaveButton
{
    public class SaveButtonPresenter: IInitializable, IDisposable
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IViewInteractable<SaveLoadButton> _buttonView;

        public SaveButtonPresenter(ISaveLoadService saveLoadService, ButtonView<SaveLoadButton> buttonView)
        {
            _saveLoadService = saveLoadService;
            _buttonView = buttonView;
        }

        public void Initialize()
        {
            _buttonView.callback += SaveGame;
        }

        private void SaveGame(SaveLoadButton signal)
        {
            _saveLoadService.SaveGame();
        }

        public void Dispose()
        {
            _buttonView.callback -= SaveGame;
        }
    }

    public struct SaveLoadButton { }
}