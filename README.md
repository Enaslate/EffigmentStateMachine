Finite state machine library for unity from Effigment

# Features

- ManualStateMachine - direct state switching with optional force restart.
- EventStateMachine - event‑driven transitions with optional guard conditions.
- TickableStateMachine - condition‑based transitions checked every frame (requires Update call).
- Composable conditions - AndCondition, OrCondition, NotCondition, FuncCondition.
- Full test coverage - reliable and production‑ready.

# Installation
Via Git URL (Unity Package Manager)
Add the following line to Packages/manifest.json:

~~~json
"com.effigment.statemachine": "https://github.com/Enaslate/EffigmentStateMachine.git"
~~~

Or open Package Manager -> Add package from git URL -> paste the same URL.

# Quick Start
1. Create your states

Implement the IState interface:

~~~csharp
public class IdleState : IState
{
    public void OnEnter() => Debug.Log("Enter Idle");
    public void OnUpdate(float deltaTime) { }
    public void OnExit() => Debug.Log("Exit Idle");
}
~~~

2. Choose a state machine


- ManualStateMachine – full control
~~~csharp
var fsm = new ManualStateMachine();
fsm.ChangeState(new IdleState());           // simple switch
fsm.ChangeState(fsm.Current, force: true); // restart current state
~~~

- EventStateMachine – react to events
~~~csharp
var fsm = new EventStateMachine();
fsm.AddTransition(new EventCondition(idle, walk, "StartWalk"));
fsm.AddTransition(new EventCondition(walk, idle, "StopWalk"));

// somewhere in your code:
fsm.Send("StartWalk");
~~~

Optional guard condition:
~~~csharp
var condition = new EventCondition(idle, attack, "Attack", new FuncCondition(() => hasAmmo));
~~~

- TickableStateMachine – automatic checks every tick
~~~csharp
var fsm = new TickableStateMachine();
fsm.AddTransition(new ConditionTransition(idle, run, new FuncCondition(() => speed > 0)));
fsm.ChangeState(idle);

// in your Update loop:
fsm.Tick(Time.deltaTime);
~~~

3. Use composite conditions
~~~csharp
var lowHealth = new FuncCondition(() => health < 20);
var nearEnemy = new FuncCondition(() => Vector3.Distance(pos, enemyPos) < 5f);
var fleeCondition = new AndCondition(lowHealth, nearEnemy);
fsm.AddTransition(new Transition(combat, flee, fleeCondition));
~~~

Available: AndCondition, OrCondition, NotCondition, FuncCondition, etc.
