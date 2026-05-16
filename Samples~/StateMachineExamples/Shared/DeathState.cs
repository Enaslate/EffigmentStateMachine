using Effigment.StateMachine.Core;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Shared
{
    public class DeathState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter death");
        }

        public void Exit()
        {
            Debug.Log("Exit death");
        }

        public void Update(float deltaTime)
        {
            Debug.Log("Update death");
        }
    }
}