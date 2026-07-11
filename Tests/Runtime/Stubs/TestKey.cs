using Effigment.StateMachine.Core;

namespace Effigment.StateMachine.Runtime.Stubs
{
    public struct TestKey : IKey
    {
        public string Key => _key;

        private string _key;

        public TestKey(string key)
        {
            _key = key;
        }

        public bool Equals(IKey other) => _key == other.Key;
        public override bool Equals(object obj) => obj is IKey other && Equals(other);
        public override int GetHashCode() => _key.GetHashCode();
    }
}
