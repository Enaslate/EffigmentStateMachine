namespace Effigment.StateMachine.Core
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update(float deltaTime);
    }
}