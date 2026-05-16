using Effigment.StateMachine.Conditions;
using Effigment.StateMachine.Core.Machines;
using Effigment.StateMachine.Transitions;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Tickable
{
    public class TickableStateMachineExample : MonoBehaviour
    {
        [SerializeField] private float _health = 1f;
        private TickableStateMachine _fsm;

        private void Awake()
        {
            var idle = new IdleState();
            var death = new DeathState();

            _fsm = new TickableStateMachine(initialeState: idle);

            var boolCondition = new BoolCondition(true);
            var noHealthCondition = new FuncCondition(() => _health <= 0);

            var andCondition = new NotCondition(noHealthCondition);

            _fsm.AddTransition(new ConditionTransition(idle, death, andCondition));

            _fsm.ChangeState(idle);
        }

        private void Update()
        {
            _fsm.Tick(Time.deltaTime);
        }
    }
}