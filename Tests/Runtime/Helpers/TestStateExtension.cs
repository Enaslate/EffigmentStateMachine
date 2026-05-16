using Effigment.StateMachine.Tests.Runtime.Stubs;
using NUnit.Framework;

namespace Effigment.StateMachine.Tests.Runtime.Helpers
{
    public static class TestStateExtension
    {
        public static void AssertCounts(this TestState state, int enterCount, int exitCount, int updateCount)
        {
            Assert.That(state.EnterCount, Is.EqualTo(enterCount));
            Assert.That(state.ExitCount, Is.EqualTo(exitCount));
            Assert.That(state.UpdateCount, Is.EqualTo(updateCount));
        }
    }
}