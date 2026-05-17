using Effigment.StateMachine.Core;
using Effigment.StateMachine.Core.Machines;
using Effigment.StateMachine.Tests.Runtime.Stubs;
using Effigment.StateMachine.Transitions;
using NUnit.Framework;
using System;

namespace Effigment.StateMachine.Tests.Runtime
{
    [TestFixture]
    public class EventStateMachineTests
    {
        private EventStateMachine _machine;
        private TestState _firstState;
        private TestState _secondState;

        private EventTransition _toFirstState;
        private EventTransition _toSecondState;

        [SetUp]
        public void SetUp()
        {
            _machine = new EventStateMachine();
            _firstState = new TestState();
            _secondState = new TestState();
            _toFirstState = new EventTransition(null, _firstState, "toFirst");
            _toSecondState = new EventTransition(_firstState, _secondState, "toSecond");
            _machine.AddTransition(_toFirstState);
            _machine.AddTransition(_toSecondState);
        }

        [Test]
        public void Send_FromAnyState_Succusses()
        {
            _machine.Send(_toFirstState.Id);

            Assert.That(_machine.Current, Is.EqualTo(_toFirstState.To));
        }

        [Test]
        public void Send_FromCurrent_Successes()
        {
            _machine.Send(_toFirstState.Id);
            _machine.Send(_toSecondState.Id);

            Assert.That(_machine.Current, Is.EqualTo(_toSecondState.To));
        }

        [Test]
        public void Send_WhenCurrentIsNotFrom_Successes()
        {
            var thirdState = new TestState();
            var toThird = new EventTransition(_secondState, thirdState, "toThird");

            _machine.Send(_toFirstState.Id);
            _machine.Send(toThird.Id);

            Assert.That(_machine.Current, Is.EqualTo(_firstState));
        }

        [Test]
        public void AddTransition_WhenIdIsNull_ThrowsArgumentNullExeption()
        {
            var transition = new Transition(_firstState, _secondState);
            
            Assert.Catch<ArgumentNullException>(() => _machine.AddTransition(transition));
        }
    }
}