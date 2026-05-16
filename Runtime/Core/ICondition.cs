namespace Effigment.StateMachine.Core
{
    public interface ICondition
    {
        /// <summary>
        /// Check the evaluable condition
        /// </summary>
        bool Evaluate();
    }
}