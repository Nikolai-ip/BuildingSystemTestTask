namespace _Game.Scripts.Infrastructure.Event
{
    public interface ISignalHandler<in T> where T : ISignal
    {
        void HandleSignal(T signal);
    }
}