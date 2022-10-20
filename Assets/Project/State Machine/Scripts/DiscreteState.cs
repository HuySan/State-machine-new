using System.Collections;
using UnityEngine;


public class DiscreteState : State
{
    private GameObject _changeObject;
    private Vector3 _standartObjectScale;

    public DiscreteState(GameObject changeObject)
    {
        _changeObject = changeObject;
        _standartObjectScale = changeObject.transform.localScale;
    }

    public override void Enter()
    {
        base.Enter();
        _changeObject.transform.localScale = _standartObjectScale * 2;
    }

    public override void Exit()
    {
        base.Exit();
        _changeObject.transform.localScale = _standartObjectScale;
    }

}
