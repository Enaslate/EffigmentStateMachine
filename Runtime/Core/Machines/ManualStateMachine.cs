namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with manual change states
    /// </summary>
    public class ManualStateMachine : StateMachineBase
    {
        public ManualStateMachine(IState initialState = null) : base(initialState)
        {
        }

        /// <summary>
        /// Change state if state is not current
        /// </summary>
        /// <param name="state">Target state</param>
        public void ChangeState(IState state, bool force = false)
        {
            ChangeStateTo(state, force);
        }
    }
}