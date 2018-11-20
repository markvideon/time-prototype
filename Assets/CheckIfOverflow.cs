using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckIfOverflow : MonoBehaviour {

    TextMeshProUGUI textMesh;

    // Use this for initialization
    void Start () {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.maxVisibleWords = 1;
        textMesh.
        Debug.Log(textMesh.isTextOverflowing);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(textMesh.isTextOverflowing);
    }
}
