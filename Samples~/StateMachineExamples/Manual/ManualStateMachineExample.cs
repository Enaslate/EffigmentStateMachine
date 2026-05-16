using Effigment.StateMachine.Core.Machines;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Manual
{
    public class ManualStateMachineExample : MonoBehaviour
    {
        private ManualStateMachine _fsm;

        private void Awake()
        {
            _fsm = new ManualStateMachine();
        }

        private void Start()
        {
            var idle = new IdleState();
            var death = new DeathState();
        
            _fsm.ChangeState(idle);
            _fsm.ChangeState(death);
        }
    }
}