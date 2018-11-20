using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/* 
 * Save & Load Methods from Unity 2014 
 * https://www.youtube.com/watch?v=J6FfcJpbPXE
 * 
 */
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DictatedInputCharacter : MonoBehaviour
{

    [SerializeField] private CharacterData character;
    private FrameData readData;
    private int frameCounter = 0;
    Vector3 movement;

    // Use this for initialization
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

        // UP, DOWN, LEFT, RIGHT
        if (frameCounter < readData.MyDirection.Length)
        {
            switch (readData.MyDirection[frameCounter])
            {
                case Directions.NULL:
                    movement = Vector3.zero;
                    break;
                case Directions.UP:
                    movement = Vector3.up;
                    break;
                case Directions.LEFT:
                    movement = Vector3.left;
                    break;
                case Directions.RIGHT:
                    movement = Vector3.right;
                    break;
                case Directions.DOWN:
                    movement = Vector3.down;
                    break;
            }
            this.transform.position += movement * character.speedMultiplier*  Time.deltaTime;

            frameCounter++;
        }
        else {
            Debug.Log("Recording over.");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    

    public void LoadData() {
        // Checking for exception
        // if (File.Exists(Application.dataPath + "/" + character.fileName)) {

        /* 
         * Application.dataPath provides an absolute path to project's Assets
         * folder. AssetDatabase.GetAssetPath provides relative path from 
         * project's root folder. 
         * 
         * --> Substring used to get absolute path to file.
        */
        string prefix = "Assets";
        string absoluteFilePath = Application.dataPath +
        AssetDatabase.GetAssetPath(character.file).Substring(prefix.Length);


        if (File.Exists(absoluteFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(absoluteFilePath, FileMode.Open);

            // Force interpret as relevant data
            readData = (FrameData) bf.Deserialize(file);
            file.Close();
        }
        else {
            Debug.Log("File does not exist!");
        }
    }
}


