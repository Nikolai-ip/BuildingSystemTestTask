namespace _Game.Source.Infrastructure
{
    public interface IFactory<out T, in TParams>
    {
        T Create(TParams @params);
    }
    public interface IFactory<out T>
    {
        T Create();
    }
}