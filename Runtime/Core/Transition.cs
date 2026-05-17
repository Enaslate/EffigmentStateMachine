namespace Effigment.StateMachine.Core
{
    /// <summary>
    /// Contains data for transition
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Transition key
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The state from which the transition occurs
        /// Leave null for transition from any state
        /// </summary>
        public IState From { get; private set; }

        /// <summary>
        /// Transition target state 
        /// </summary>
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