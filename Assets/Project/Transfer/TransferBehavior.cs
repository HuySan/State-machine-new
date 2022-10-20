using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransferBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private TransferSystem _transferSystem;
    private List<GameObject> _newObjects;
    void Awake()
    {
        _transferSystem = new TransferSystem(this.transform);
        _newObjects = new List<GameObject>();
    }

    private void Update()
    {
        _transferSystem.Move();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _transferSystem.Capture();   
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _transferSystem.LetGo();
    }

    private void OnEnable()
    {
        EventBus.onSpawnObject += GiveMovement;
        EventBus.objectCreateCompletion += StopMovement;
    }

    private void OnDisable()
    {
        EventBus.onSpawnObject -= GiveMovement;
        EventBus.objectCreateCompletion -= StopMovement;
    }

    private void GiveMovement(GameObject newObject)
    {
        _transferSystem.MovementCapability(true);
        _newObjects.Add(newObject);
        _transferSystem.ActivateArrow(newObject, true);
    }

    private void StopMovement()
    {
        _transferSystem.MovementCapability(false);
        foreach(GameObject gameObject in _newObjects)
        {
            _transferSystem.ActivateArrow(gameObject, false);
        }

        _newObjects.Clear();
    }
}
