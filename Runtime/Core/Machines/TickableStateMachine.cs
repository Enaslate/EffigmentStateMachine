using Effigment.StateMachine.Transitions;
using System.Collections.Generic;

namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with transitions checked while tick
    /// </summary>
    public class TickableStateMachine : StateMachineBase
    {
        protected List<ConditionTransition> _transitions;

        public TickableStateMachine(List<ConditionTransition> transitions = null, IState initialeState = null)
            : base(initialeState)
        {
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

        public void AddTransition(ConditionTransition transition)
        {
            _transitions.Add(transition);
        }

        protected void UpdateTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (transition.From == Current && transition.CanTransition())
                {
                    ChangeStateTo(transition.To);
                    break;
                }
            }
        }
    }
}