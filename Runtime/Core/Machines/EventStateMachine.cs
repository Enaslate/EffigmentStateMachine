using System;
using System.Collections.Generic;

namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with transitions by event
    /// </summary>
    public class EventStateMachine : TransitionStateMachine
    {
        private Dictionary<string, List<Transition>> _events = new();

        public EventStateMachine(IState initialeState = null)
            : base(initialeState)
        {
        }

        public void Send(string id)
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
            var id = transition.Id;
            
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (!_events.ContainsKey(id))
                _events[id] = new List<Transition>();
            
            _events[id].Add(transition);
        }

        public override void RemoveTransition(Transition transition)
        {
            var id = transition.Id;
            
            if (!_events.ContainsKey(id)) return;

            _events[id].Remove(transition);

            if (_events[id].Count == 0)
                _events.Remove(id);
        }
    }
}