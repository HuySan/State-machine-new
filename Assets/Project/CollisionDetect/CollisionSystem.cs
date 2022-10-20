using System.Collections;
using UnityEngine;


public class CollisionSystem
{
    private DetectType _type;

    public CollisionSystem()
    {
        _type = new DetectType();
    }

    public void Collision(DetectType type)
    {
        _type = type;
        switch (type)
        {
            case DetectType.Breaking:
                Debug.Log("Breaking");
                BreakingAction();
                break;
            case DetectType.Exception:
                Debug.Log("Exception");
                ExceptionAction();
                break;
            case DetectType.Wait:
                break;
        }

    }

    public void AnimationIsComplete()
    {
        if (_type != DetectType.Wait) 
            return;
        EventBus.onNextState?.Invoke();
    }

    private void BreakingAction()
    {
        EventBus.onNextState?.Invoke();
    }

    private void ExceptionAction()
    {
        Debug.LogError("State error");
    }
}
