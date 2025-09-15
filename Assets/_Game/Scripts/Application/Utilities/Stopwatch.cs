using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Game.Scripts.Application.Utilities
{
    public class Stopwatch: IDisposable
    {
        private CancellationTokenSource _cts;
        private readonly TimeSpan _interval;
        public event Action OnTick;

        public Stopwatch(TimeSpan interval)
        {
            _interval = interval;
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            Process().Forget();
        }
        private async UniTask Process()
        {
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    await UniTask.Delay(_interval, cancellationToken: _cts.Token);
                    OnTick?.Invoke();
                }
            }
            catch (OperationCanceledException) {}
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}