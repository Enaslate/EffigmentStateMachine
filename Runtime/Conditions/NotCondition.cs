using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Checks the condition is not true
    /// </summary>
    public class NotCondition : ICondition
    {
        private ICondition _condition;

        public NotCondition(ICondition condition)
        {
            _condition = condition;
        }

        public bool Evaluate() => !_condition.Evaluate();
    }
}