namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition
    /// </summary>
    public class Transition
    {
        public IState From { get; private set; }
        public IState To { get; private set; }

        public Transition(IState from, IState to)
        {
            From = from;
            To = to;
        }

        public virtual bool CanTransition() => true;
    }
}