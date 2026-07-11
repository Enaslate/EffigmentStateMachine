using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Transitions
{
    /// <summary>
    /// Contains data for transition with condition
    /// </summary>
    public class ConditionTransition : Transition
    {
        private ICondition _condition;

        public ConditionTransition(IState from, IState to, ICondition condition, IKey key = null)
            : base(from, to, key)
        {
            _condition = condition;
        }

        public override bool CanTransition() => _condition.Evaluate();
    }
}