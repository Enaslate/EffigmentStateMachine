using System.Collections.Generic;

namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// State machine with transitions by event
    /// </summary>
    public class EventStateMachine : StateMachineBase
    {
        private Dictionary<string, List<EventTransition>> _events = new();

        public EventStateMachine(IState initialeState)
        {
            ChangeStateTo(initialeState);
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

        public void AddTransition(EventTransition transition)
        {
            var id = transition.Id;
            
            if (!_events.ContainsKey(id))
                _events[id] = new List<EventTransition>();
            
            _events[id].Add(transition);
        }

        public void RemoveTransition(EventTransition transition)
        {
            var id = transition.Id;
            
            if (!_events.ContainsKey(id)) return;

            _events[id].Remove(transition);

            if (_events[id].Count == 0)
                _events.Remove(id);
        }

        protected bool TryTransition(EventTransition transition)
        {
            if (Current == transition.From && transition.CanTransition())
            {
                ChangeStateTo(transition.To);
                return true;
            }

            return false;
        }
    }
}