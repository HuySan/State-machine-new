using System.Collections;
using UnityEngine;

public class ButtonSystem
{
    public void EnableObjectsList(GameObject objectsList, GameObject doneButton)
    {
        objectsList.SetActive(true);
        doneButton.SetActive(true);
    }

    public void DisableObjectsList(GameObject objectsList, GameObject doneButton, bool gameObjectCreate)
    {
        objectsList.SetActive(false);
        doneButton.SetActive(false);

        if (!gameObjectCreate)
            return;

        EventBus.objectCreateCompletion?.Invoke();
    }

}
