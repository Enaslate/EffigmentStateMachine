using Effigment.StateMachine.Conditions;
using Effigment.StateMachine.Core;
using Effigment.StateMachine.Core.Machines;
using Effigment.StateMachine.Tests.Runtime.Stubs;
using Effigment.StateMachine.Transitions;
using NUnit.Framework;
using System;

namespace Effigment.StateMachine.Tests.Runtime
{
    [TestFixture]
    public class TickableStateMachineTests
    {
        private const float _dt = 0.1f;

        private TickableStateMachine _machine;
        private TestState _firstState;
        private TestState _secondState;

        private Transition _toSecondState;

        private float _testValue;

        [SetUp]
        public void SetUp()
        {
            _testValue = 1;

            _machine = new TickableStateMachine();

            _firstState = new TestState();
            _secondState = new TestState();

            _toSecondState = new ConditionTransition(_firstState, _secondState, new FuncCondition(() => _testValue <= 0));

            _machine.AddTransition(_toSecondState);
        }

        [Test]
        public void Tick_WhenTransition_Successes()
        {
            _machine.ChangeState(_firstState);

            while (_testValue > 0)
            {
                _testValue -= _dt;
                _machine.Tick(_dt);
            }

            Assert.That(_machine.Current, Is.EqualTo(_secondState));
        }

        [Test]
        public void Tick_WhenStateIsNull_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() => _machine.Tick(_dt));
        }
    }
}