namespace Effigment.StateMachine.Core.Machines
{
    /// <summary>
    /// State machine with manual change states
    /// </summary>
    public class ManualStateMachine : StateMachineBase
    {
        /// <summary>
        /// Change state if state is not current
        /// </summary>
        /// <param name="state">Target state</param>
        public void ChangeState(IState state)
        {
            ChangeStateTo(state);
        }
    }
}