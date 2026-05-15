using System.Collections.Generic;

namespace Effigment.StateMachine.Core
{
    public class TickableStateMachine : StateMachineBase
    {
        private List<Transition> _transitions;

        public TickableStateMachine(IState initialeState, List<Transition> transitions = null)
        {
            Current = initialeState;
            Current?.Enter();
            _transitions = transitions ?? new();
        }

        public void Tick(float deltaTime)
        {
            UpdateTransitions();

            Current.Update(deltaTime);
        }

        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        private void UpdateTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (transition.From == Current && transition.Condition.Evaluate())
                {
                    Change(transition.To);
                    break;
                }
            }
        }
    }
}