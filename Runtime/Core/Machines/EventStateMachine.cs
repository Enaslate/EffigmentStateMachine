using System;
using System.Collections.Generic;

namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with transitions by event
    /// </summary>
    public class EventStateMachine : TransitionStateMachine
    {
        private Dictionary<IKey, List<Transition>> _events = new();

        public EventStateMachine(IState initialeState = null)
            : base(initialeState)
        {
        }

        public void Send(IKey id)
        {
            if (!_events.TryGetValue(id, out var transitions)) return;

            foreach (var transition in transitions)
            {
                if (TryTransition(transition))
                    break;
            }
        }

        public override void AddTransition(Transition transition)
        {
            var key = transition.Key;
            
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (!_events.ContainsKey(key))
                _events[key] = new List<Transition>();
            
            _events[key].Add(transition);
        }

        public override void RemoveTransition(Transition transition)
        {
            var id = transition.Key;
            
            if (!_events.ContainsKey(id)) return;

            _events[id].Remove(transition);

            if (_events[id].Count == 0)
                _events.Remove(id);
        }
    }
}