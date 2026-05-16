namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition
    /// </summary>
    public class Transition
    {
        public IState From { get; private set; }
        public IState To { get; private set; }
        public ICondition Condition { get; private set; }

        public Transition(IState from, IState to, ICondition condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}