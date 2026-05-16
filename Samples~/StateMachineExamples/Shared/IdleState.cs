using Effigment.StateMachine.Core;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Shared
{
    public class IdleState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter idle");
        }

        public void Exit()
        {
            Debug.Log("Exit idle");
        }

        public void Update(float deltaTime)
        {
            Debug.Log("Update idle");
        }
    }
}