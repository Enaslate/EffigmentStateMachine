using Effigment.StateMachine.Core;
using System.Linq;

namespace Effigment.StateMachine.Conditions
{
    public class AndCondition : ICondition
    {
        private ICondition[] _conditions;

        public AndCondition(params ICondition[] conditions)
        {
            _conditions = conditions;
        }

        public bool Evaluate() => _conditions.All(c => c.Evaluate());
    }
}