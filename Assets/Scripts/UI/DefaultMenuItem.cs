using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefaultMenuItem : MonoBehaviour {

    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject defaultSelectedGO;
 
    private void OnDisable()
    {
        eventSystem.SetSelectedGameObject(null);
    }

    private void OnEnable()
    {
        StartCoroutine(SelectButton());
    }

    IEnumerator SelectButton() {
        // There is some kind of synchronisation issue with button select, 
        // Delay produces the result that is expected without one.
        yield return new WaitForSecondsRealtime(0.0001f);
        eventSystem.SetSelectedGameObject(defaultSelectedGO);

    }
}
