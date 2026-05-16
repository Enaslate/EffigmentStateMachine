using Effigment.StateMachine.Core;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Shared
{
    public class TakeHitState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter take hit");
        }

        public void Exit()
        {
            Debug.Log("Exit take hit");
        }

        public void Update(float deltaTime)
        {
            Debug.Log("Update take hit");
        }
    }
}