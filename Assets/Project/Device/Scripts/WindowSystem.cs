using System.Collections;
using UnityEngine;


public class WindowSystem 
{
    private GameObject _uiWindow;
    private MonoBehaviour _mono;
    private bool _timeChanger;

    public WindowSystem(GameObject uiWindow, MonoBehaviour mono)
    {
        _uiWindow = uiWindow;
        _mono = mono;
        _timeChanger = false;
    }


    public void ActiveWindow()
    {

        _uiWindow.SetActive(true);
    }

    public void DisableWindow(bool withTime)
    {
        if (_timeChanger)
            return;

        if (!withTime)
            _uiWindow.SetActive(false);
        else
            _mono.StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        _timeChanger = true;
        yield return new WaitForSeconds(3);
        _uiWindow.SetActive(false);
        _timeChanger = false;
    }
}
