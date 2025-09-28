using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace _Game.Source.Infrastructure.StateMachine
{
    public class StateMachineBase: IInitializable
    {
        private Dictionary<Type, IExitableState> _states;
        protected IExitableState _currentState;

        public StateMachineBase(Dictionary<Type, IExitableState> states)
        {
            _states = states;
        }
        public void Initialize()
        {
            foreach (var state in _states.Values)
                state.SetStateMachine(this);
        }

        public virtual void Enter<TState>() where TState: class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public virtual void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState: class, IPayLoadedState<TPayLoad>
        {
            var state = ChangeState<TState>();
            state.Enter(payLoad);
        }
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            var state = GetState<TState>();
            _currentState = state;
            return state;
        }
        private TState GetState<TState>() where TState: class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
        
    }
}