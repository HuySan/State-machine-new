using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DetectBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingList;
    [SerializeField]
    private Button _settingButton;
    [SerializeField]
    private Button _doneSetConfiguration;

    [SerializeField]
    private Button _breakingButton;
    [SerializeField]
    private Button _exceptionButton;
    [SerializeField]
    private Button _waitButton;

    private ButtonSystem _buttonSystem;
    private DetectSystem _detectSystem;

    private CollisionSystem _collisionSystem;
    void Start()
    {
        _detectSystem = new DetectSystem();
        _buttonSystem = new ButtonSystem();
        _collisionSystem = new CollisionSystem();
    }
    private void OnEnable()
    {
        _settingButton?.onClick.AddListener(ActivateSettingList);
        _doneSetConfiguration?.onClick.AddListener(DeactivateSettingList);

        _breakingButton?.onClick.AddListener(BreakingListener);
        _exceptionButton?.onClick.AddListener(ExceptionListener);
        _waitButton?.onClick.AddListener(WaitListener);

        EventBus.onDetectValue += DetectValue;
        EventBus.onAnimationCompleted += AnimationIsComplete;
    }

    private void OnDisable()
    {
        _settingButton?.onClick.RemoveListener(ActivateSettingList);
        _doneSetConfiguration?.onClick.RemoveListener(DeactivateSettingList);

        _breakingButton?.onClick.RemoveListener(BreakingListener);
        _exceptionButton?.onClick.RemoveListener(ExceptionListener);
        _waitButton?.onClick.RemoveListener(WaitListener);

        EventBus.onDetectValue -= DetectValue;
        EventBus.onAnimationCompleted -= AnimationIsComplete;
    }

    private void ActivateSettingList()
    {
        _buttonSystem.EnableObjectsList(_settingList, _doneSetConfiguration.gameObject);
    }

    private void DeactivateSettingList()
    {
        _buttonSystem.DisableObjectsList(_settingList, _doneSetConfiguration.gameObject, false);
    }

    private void BreakingListener()
    {
        _detectSystem.Breaking();
        Debug.Log("Chosen breaking");
    }

    private void ExceptionListener()
    {
        _detectSystem.Exception();
        Debug.Log("Chosen Exception");
    }

    private void WaitListener()
    {
        _detectSystem.Wait();
        Debug.Log("Chosen Wait");
    }

    private void DetectValue(GameObject detectableObject)
    {
        _detectSystem.SendType(_collisionSystem, detectableObject);
    }

    private void AnimationIsComplete()
    {
        _collisionSystem.AnimationIsComplete();
    }
}

