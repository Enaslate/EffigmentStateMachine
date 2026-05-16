using System.Collections.Generic;

namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with transitions checked while tick
    /// </summary>
    public class TickableStateMachine : TransitionStateMachine
    {
        protected List<Transition> _transitions;

        public TickableStateMachine(List<Transition> transitions = null, IState initialeState = null)
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

        public override void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        public override void RemoveTransition(Transition transition)
        {
            _transitions.Remove(transition);
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