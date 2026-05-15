using Effigment.StateMachine.Core;
using System;

namespace Effigment.StateMachine.Conditions
{
    public class FuncCondition : ICondition
    {
        private Func<bool> _predicate;

        public FuncCondition(Func<bool> predicate)
        {
            _predicate = predicate;
        }

        public bool Evaluate() => _predicate.Invoke();
    }
}