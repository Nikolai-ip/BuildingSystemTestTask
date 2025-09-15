using System;
using System.Collections.Generic;

namespace _Game.Scripts.Infrastructure.Event
{
    public class EventBusLocal
    {
        private readonly Dictionary<Type, List<ISignalHandler<ISignal>>> _listeners = new();
        public void Subscribe<T>(ISignalHandler<T> handler) where T : ISignal
        {
            List<ISignalHandler<ISignal>> handlers;
            if (!_listeners.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<ISignalHandler<ISignal>>();
                _listeners[typeof(T)] = handlers;
            }
            handlers.Add(handler as ISignalHandler<ISignal>);
        }

        public void Remove<T>(ISignalHandler<T> handler) where T : ISignal
        {
            if (_listeners.TryGetValue(typeof(T), out var handlers))
            {
                handlers.Remove(handler as ISignalHandler<ISignal>);
            }
        }
        public void RiseEvent<T>(T signal) where T : ISignal
        {
            if (_listeners.TryGetValue(typeof(T), out var handlers))
            {
                for (var i = 0; i < handlers.Count; i++)
                {
                    var signalHandler = handlers[i];
                    signalHandler.HandleSignal(signal);
                }
            }
        }
    }
}