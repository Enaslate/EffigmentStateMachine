using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Contains the evaluatable bool 
    /// </summary>
    public class BoolCondition : ICondition
    {
        private bool _value;

        public BoolCondition(bool value)
        {
            _value = value;
        }

        public bool Evaluate() => _value;
    }
}