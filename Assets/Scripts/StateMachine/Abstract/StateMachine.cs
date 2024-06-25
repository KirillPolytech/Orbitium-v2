using UnityEngine;

public abstract class StateMachine
{
    public State CurrentState { get; private set; }
    
    public void SetState(State state)
    {
        Debug.Log($"STATE: Change state to {state}");

        CurrentState = state;
        CurrentState.EnterState();
    }
}
