using System.Collections;
using UnityEngine;
using System;

public static class EventBus
{
    public static Action<GameObject> onDiscreteClick;
    public static Action<GameObject> onSimilarClick;
    public static Action<GameObject> onSpawnObject;
    public static Action objectCreateCompletion;

    public static Action<GameObject> onDetectValue;

    public static Action onNextState;
    public static Action onAnimationCompleted;
}
