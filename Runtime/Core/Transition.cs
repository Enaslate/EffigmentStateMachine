namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition
    /// </summary>
    public class Transition
    {
        public string Id { get; private set; }
        public IState From { get; private set; }
        public IState To { get; private set; }

        public Transition(IState from, IState to, string id = null)
        {
            From = from;
            To = to;
            Id = id;
        }

        public virtual bool CanTransition() => true;
    }
}