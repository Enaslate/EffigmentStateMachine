using Effigment.StateMachine.Core;
using System;

namespace Effigment.StateMachine.Conditions
{
    /// <summary>
    /// Contains the evaluatable predicate
    /// </summary>
    public class FuncCondition : ICondition
    {
        private Func<bool> _predicate;

        public FuncCondition(Func<bool> predicate)
        {
            _predicate = predicate;
        }

        /// <summary>
        /// Check the predicate
        /// </summary>
        /// <returns>Result of predicate</returns>
        public bool Evaluate() => _predicate.Invoke();
    }
}