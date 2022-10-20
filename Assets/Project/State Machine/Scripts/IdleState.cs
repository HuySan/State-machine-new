using System.Collections;
using UnityEngine;

public class IdleState : State
{

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle state enable");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Idle state disable");
    }
}
