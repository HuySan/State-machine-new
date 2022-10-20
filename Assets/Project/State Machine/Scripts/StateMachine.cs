using UnityEditor;
using UnityEngine;

public class StateMachine 
{
    public State _currentState;

    public void Initialize(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
