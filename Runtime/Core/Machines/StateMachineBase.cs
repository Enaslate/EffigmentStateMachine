using System;

namespace Effigment.StateMachine.Core.Machines
{
	/// <summary>
	/// Provides base mathods for state machine
	/// </summary>
	public class StateMachineBase
	{
		protected IState _initialState;
		public IState Current { get; protected set; }

		public StateMachineBase(IState initialState = null)
		{
			if (initialState != null)
			{
				SetInitialState(initialState);
				Reset();
			}
		}

		/// <summary>
		/// Reset state machine to default state/>
		/// </summary>
		/// <exception cref="ArgumentNullException">If <see cref="_initialState"/> is null</exception>
		public virtual void Reset()
		{
			if (_initialState == null)
				throw new ArgumentNullException(nameof(_initialState));

			ChangeStateTo(_initialState);
		}

		/// <summary>
		/// Set the initial state
		/// </summary>
		public void SetInitialState(IState state)
		{
            _initialState = state;
        }

        protected void ChangeStateTo(IState state, bool force = false)
		{
			if (state == null) throw new ArgumentNullException(nameof(state));

			if (!force && Current == state) return;

			Current?.Exit();
			Current = state;
			Current?.Enter();
		}
    }
}
