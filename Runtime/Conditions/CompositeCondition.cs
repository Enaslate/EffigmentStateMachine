using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Contains composite conditions
    /// </summary>
    public abstract class CompositeCondition : ICondition
    {
        protected ICondition[] _conditions;

        public CompositeCondition(params ICondition[] conditions)
        {
            _conditions = conditions;
        }

        public abstract bool Evaluate();
    }
}