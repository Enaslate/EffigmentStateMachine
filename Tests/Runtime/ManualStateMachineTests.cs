using Effigment.StateMachine.Core;
using Effigment.StateMachine.Core.Machines;
using Effigment.StateMachine.Tests.Runtime.Helpers;
using Effigment.StateMachine.Tests.Runtime.Stubs;
using NUnit.Framework;
using System;

namespace Effigment.StateMachine.Tests.Runtime
{
    [TestFixture]
    public class ManualStateMachineTests
    {
        private ManualStateMachine _machine;
        private IState _firstState;
        private IState _secondState;

        [SetUp]
        public void SetUp()
        {
            _firstState = new TestState();
            _secondState = new TestState();
            _machine = new ManualStateMachine();
        }

        [Test]
        public void ChangeState_ToAnother_Successes()
        {
            _machine.ChangeState(_firstState);
            _machine.ChangeState(_secondState);

            Assert.That(_machine.Current, Is.EqualTo(_secondState));
            ((TestState)_firstState).AssertCounts(1, 1, 0);
            ((TestState)_secondState).AssertCounts(1, 0, 0);
        }

        [Test]
        public void ChangeState_ToSelfForce_Successes()
        {
            _machine.ChangeState(_firstState);
            _machine.ChangeState(_firstState, force: true);

            Assert.That(_machine.Current, Is.EqualTo(_firstState));
            ((TestState)_firstState).AssertCounts(2, 1, 0);
        }

        [Test]
        public void ChangeState_ToSelfNotForce_Successes()
        {
            _machine.ChangeState(_firstState);
            _machine.ChangeState(_firstState);

            Assert.That(_machine.Current, Is.EqualTo(_firstState));
            ((TestState)_firstState).AssertCounts(1, 0, 0);
        }

        [Test]
        public void Reset_Successes()
        {
            _machine.SetInitialState(_firstState);

            _machine.ChangeState(_secondState);

            _machine.Reset();

            var first = (TestState)_firstState;
            var second = (TestState)_secondState;

            Assert.That(_machine.Current, Is.EqualTo(_firstState));
            first.AssertCounts(1, 0, 0);
            second.AssertCounts(1, 1, 0);
        }

        [Test]
        public void Reset_WhenInitialStateIsNull_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() => _machine.Reset());
        }
    }
}
