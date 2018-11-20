using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

[CustomEditor(typeof(CharacterData))]
public class CharacterDataEditor : Editor
{

    /*private void OnEnable()
    {
        serializedObject.FindProperty("speedMultiplier");
        serializedObject.FindProperty("fileName");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("speedMultiplier"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("fileName"), true);
        serializedObject.ApplyModifiedProperties();

    }*/

    // Required: On change of file field, path should change

}