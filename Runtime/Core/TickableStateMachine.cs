using System.Collections.Generic;

namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// State machine with transitions checked while tick
    /// </summary>
    public class TickableStateMachine : StateMachineBase
    {
        protected List<Transition> _transitions;

        public TickableStateMachine(IState initialeState, List<Transition> transitions = null)
        {
            Current = initialeState;
            Current?.Enter();
            _transitions = transitions ?? new();
        }

        /// <summary>
        /// Check transitions and update current state
        /// </summary>
        public void Tick(float deltaTime)
        {
            UpdateTransitions();

            Current.Update(deltaTime);
        }

        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        protected void UpdateTransitions()
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