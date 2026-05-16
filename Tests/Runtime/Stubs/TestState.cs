using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Tests.Runtime.Stubs
{
    public class TestState : IState
    {
        public int EnterCount { get; private set; }
        public int ExitCount { get; private set; }
        public int UpdateCount { get; private set; }

        public void Enter()
        {
            EnterCount++;
        }

        public void Exit()
        {
            ExitCount++;
        }

        public void Update(float deltaTime)
        {
            UpdateCount++;
        }
    }
}