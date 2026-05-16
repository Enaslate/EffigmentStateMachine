using Effigment.StateMachine.Conditions;
using Effigment.StateMachine.Core.Machines;
using Effigment.StateMachine.Transitions;
using UnityEngine;

namespace Effigment.StateMachine.Samples.StateMachineExamples.Event
{
    public class EventStateMachineExample : MonoBehaviour
    {
        [SerializeField] private float _health = 1f;
        private EventStateMachine _fsm;

        private bool _hitted = false;
        private float _recoveryTime = 0.5f;
        private float _timer;

        private void Awake()
        {
            var idle = new IdleState();
            var takeHit = new TakeHitState();
            var death = new DeathState();

            _fsm = new EventStateMachine(idle);

            var boolCondition = new BoolCondition(true);
            var noHealthCondition = new FuncCondition(() => _health <= 0);

            var andCondition = new NotCondition(noHealthCondition);

            _fsm.AddTransition(new EventTransition(idle, takeHit, "takeHit", new FuncCondition(() => _health > 0)));
            _fsm.AddTransition(new EventTransition(idle, death, "takeHit", new FuncCondition(() => _health <= 0)));
            _fsm.AddTransition(new EventTransition(takeHit, idle, "recover"));

            _fsm.ChangeState(idle);
        }

        private void Update()
        {
            if (_hitted)
            {
                if (_timer <= _recoveryTime)
                {
                    _timer += Time.deltaTime;
                }
                else
                {
                    _hitted = false;
                    _timer = 0;
                    _fsm.Send("recover");
                }
            }
            else
            {
                if (_health > 0)
                    TakeDamage(0.5f);
            }
        }

        private void TakeDamage(float damage)
        {
            _health -= damage;

            _fsm.Send("takeHit");

            _hitted = true;
        }
    }
}