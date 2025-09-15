namespace _Game.Scripts.Infrastructure.StateMachine
{
    public interface IState: IExitableState
    {
        void Enter();
    }
    public interface IPayLoadedState<TPayload>:IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
        void SetStateMachine(StateMachineBase sm);
    }
}