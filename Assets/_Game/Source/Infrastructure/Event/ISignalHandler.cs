namespace _Game.Source.Infrastructure.Event
{
    public interface ISignalHandler<in T> where T : ISignal
    {
        void HandleSignal(T signal);
    }
}