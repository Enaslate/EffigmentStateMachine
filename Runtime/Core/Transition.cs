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
        public IKey Key { get; private set; }

        /// <summary>
        /// The state from which the transition occurs
        /// Leave null for transition from any state
        /// </summary>
        public IState From { get; private set; }

        /// <summary>
        /// Transition target state 
        /// </summary>
        public IState To { get; private set; }

        public Transition(IState from, IState to, IKey key = null)
        {
            From = from;
            To = to;
            Key = key;
        }

        public virtual bool CanTransition() => true;
    }
}