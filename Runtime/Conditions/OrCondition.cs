using Effigment.StateMachine.Core;
using System.Linq;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Checks if any condition is true
    /// </summary>
    public class OrCondition : CompositeCondition
    {
        public OrCondition(params ICondition[] conditions) : base(conditions) { }

        public override bool Evaluate() => _conditions.Any(c => c.Evaluate());
    }
}