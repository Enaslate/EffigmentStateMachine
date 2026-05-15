namespace Effigment.StateMachine.Core
{
	public class StateMachineBase
	{
		public IState Current { get; protected set; }

        protected void Change(IState state)
		{
			if (Current != state)
				Current?.Exit();

			Current = state;
			Current?.Enter();
		}
    }
}
