using System;

namespace Effigment.StateMachine.Core
{
    public interface IKey : IEquatable<IKey>
    {
        string Key { get; }
    }
}