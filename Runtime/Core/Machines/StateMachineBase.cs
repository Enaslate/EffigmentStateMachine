namespace Effigment.StateMachine.Core.Machines
{
	public class StateMachineBase
	{
		public IState Current { get; protected set; }

        protected void ChangeStateTo(IState state)
		{
			if (Current != state)
				Current?.Exit();

			Current = state;
			Current?.Enter();
		}
    }
}
