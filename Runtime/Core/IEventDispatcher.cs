namespace Effigment.StateMachine.Core
{
    public interface IEventDispatcher
    {
        void Send(IKey id);
    }
}
