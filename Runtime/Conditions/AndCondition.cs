using Effigment.StateMachine.Core;
using System.Linq;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Checks if all conditions is true
    /// </summary>
    public class AndCondition : CompositeCondition
    {
        public AndCondition(params ICondition[] conditions) : base(conditions) { }

        public override bool Evaluate() => _conditions.All(c => c.Evaluate());
    }
}