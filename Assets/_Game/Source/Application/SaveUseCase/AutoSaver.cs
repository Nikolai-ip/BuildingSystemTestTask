using System;
using _Game.Source.Application.Services.SaveLoadService;
using UniRx;
using VContainer.Unity;

namespace _Game.Source.Application.SaveUseCase
{
    public class AutoSaver: IInitializable, IDisposable
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly float _intervalSeconds;
        private IDisposable _subscription;

        public AutoSaver(ISaveLoadService saveLoadService, float intervalSeconds)
        {
            _saveLoadService = saveLoadService;
            _intervalSeconds = intervalSeconds;
        }

        public void Initialize()
        {
            _subscription = Observable.Interval(TimeSpan.FromSeconds(_intervalSeconds))
                .Subscribe(_ => _saveLoadService.SaveGame());
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}