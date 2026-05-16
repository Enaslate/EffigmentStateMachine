namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition with condition
    /// </summary>
    public class ConditionTransition : Transition
    {
        public ICondition Condition { get; private set; }

        public ConditionTransition(IState from, IState to, ICondition condition)
            : base(from, to)
        {
            Condition = condition;
        }
    }
}