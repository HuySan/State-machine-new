using System.Collections;
using UnityEngine;
using DG.Tweening;

public class SimilarState : State
{
    private GameObject _changeObject;
    private Quaternion _defaultRotation;

    private Tweener _myTween;
    public SimilarState(GameObject changeObject)
    {
        _myTween = null;
        _changeObject = changeObject;
        _defaultRotation = changeObject.transform.rotation;
    }

    public override void Enter()
    {
        base.Enter();
        _myTween = _changeObject.transform.DOShakeRotation(5, 50, 5).OnComplete(TweenComplete);
    }

    private void TweenComplete()
    {
        EventBus.onAnimationCompleted?.Invoke();
    }

    public override void Exit()
    {
        base.Exit();
        _changeObject.transform.DOTogglePause();
        _changeObject.transform.rotation = _defaultRotation;
    }

}
