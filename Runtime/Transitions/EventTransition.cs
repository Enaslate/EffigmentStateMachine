using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Transitions
{
    /// <summary>
    /// Contains data for transition by event with optional condition guard
    /// </summary>
    public class EventTransition : Transition
    {
        private ICondition _condition;

        public EventTransition(IState from, IState to, string id, ICondition condition = null)
            : base(from, to, id)
        {
            _condition = condition;
        }

        public override bool CanTransition() =>
            _condition?.Evaluate() ?? true;
    }
}