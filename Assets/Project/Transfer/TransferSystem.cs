using System.Collections;
using UnityEngine;

public class TransferSystem 
{
    private float _mzCoord;
    private Vector3 _mouseOffset;

    private Transform _transferObject;
    private bool _isCapture;
    private bool _movement;

    public TransferSystem(Transform transferObject)
    {
        _transferObject = transferObject;

        _mzCoord = 0;
        _isCapture = false;
    }

    public void MovementCapability(bool isMove)
    {
        _movement = isMove;
        
    }

    public void ActivateArrow(GameObject newObject, bool activate)
    {
        foreach(Transform child in newObject.transform)
        {
            if (child.GetComponent<ArrowFlag>() != null)
                child.gameObject.SetActive(activate);
        }
    }


    public void Capture()
    {
        _mzCoord = Camera.main.WorldToScreenPoint(_transferObject.position).z;

        _mouseOffset = _transferObject.position - GetMouseWorldPosition();
        _isCapture = true;
    }

    public void LetGo() => _isCapture = false;

    public void Move()
    {
        if (!_movement)
            return;

        if (_isCapture)
            _transferObject.position = new Vector3(GetMouseWorldPosition().x + _mouseOffset.y, 0.5f, GetMouseWorldPosition().z + _mouseOffset.z);       
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mzCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}
