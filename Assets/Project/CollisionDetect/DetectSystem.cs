using System.Collections;
using UnityEngine;


public class DetectSystem
{
    private DetectType _tempType;
    public DetectSystem()
    {
        _tempType = new DetectType();
        _tempType = DetectType.Breaking;
    }

    public void Breaking() => SetType(DetectType.Breaking);

    public void Exception() => SetType(DetectType.Exception);

    public void Wait() => SetType(DetectType.Wait);


    private void SetType(DetectType value) => _tempType = value;


    public void SendType(CollisionSystem collisionSystem, GameObject detectableObject) => collisionSystem.Collision(_tempType);

}
