using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DeviceBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private GameObject _uiWindow;

    [SerializeField]
    private Button _dicreteButton;
    [SerializeField]
    private Button _similarButton;

    private WindowSystem _windowSystem;

    void Awake()
    {
        _windowSystem = new WindowSystem(_uiWindow, this);
        _windowSystem.DisableWindow(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _windowSystem.ActiveWindow();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _windowSystem.DisableWindow(true);
    }

    private void OnEnable()
    {
        _dicreteButton?.onClick.AddListener(OnDiscreteButtonClick);
        _similarButton?.onClick.AddListener(OnSimilarButtonClick);
    }

    private void OnDisable()
    {
        _dicreteButton?.onClick.RemoveListener(OnDiscreteButtonClick);
        _similarButton?.onClick.RemoveListener(OnSimilarButtonClick);
    }

    private void OnDiscreteButtonClick()
    {
        EventBus.onDiscreteClick?.Invoke(this.gameObject);
    }

    private void OnSimilarButtonClick()
    {
        EventBus.onSimilarClick?.Invoke(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        EventBus.onDetectValue?.Invoke(this.gameObject);
    }

}
