namespace Effigment.StateMachine.Core.Machines
{
    public abstract class TransitionStateMachine : ManualStateMachine
    {
        protected TransitionStateMachine(IState initialState = null)
            : base(initialState)
        {
        }

        public abstract void AddTransition(Transition transition);

        public abstract void RemoveTransition(Transition transition);

        protected virtual bool TryTransition(Transition transition)
        {
            if ((transition.From == null || transition.From == Current) && transition.CanTransition())
            {
                ChangeStateTo(transition.To);
                return true;
            }

            return false;
        }
    }
}