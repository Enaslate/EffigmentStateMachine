namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition with condition
    /// </summary>
    public class ConditionTransition : Transition
    {
        private ICondition _condition;

        public ConditionTransition(IState from, IState to, ICondition condition)
            : base(from, to)
        {
            _condition = condition;
        }

        public override bool CanTransition() => _condition.Evaluate();
    }
}