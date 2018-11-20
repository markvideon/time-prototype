/* 
 * Uses a binary formatter, filestream to record inputs in each frame in a file.
 *  Mark Videon, 23/10/18
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/* 
 * Save & Load Methods from Unity 2014 
 * https://www.youtube.com/watch?v=J6FfcJpbPXE
 * 
 */
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RecordingInputCharacter : MonoBehaviour {

    // Relative to project assets folder.
    [SerializeField] private String fileDestination;

    // Max number of frames to be recorded. Used to set file size.
    //[SerializeField] private int maxFrames = 120 * 60 * 5;


    FileStream file;
    BinaryFormatter bf;
    FrameData recordedData;


    int frameCounter = 0;
    Vector3 movement;

    // Use this for initialization
    void Start () {
        recordedData = new FrameData();

        InitiateFile();
        PrepareFileUpdate();

    }

    // Update is called once per frame
    void Update () {

        recordedData.MyDirection[frameCounter] = Directions.NULL;
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) {
            recordedData.MyDirection[frameCounter] = Directions.UP;
            movement = Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            recordedData.MyDirection[frameCounter] = Directions.LEFT;
            movement = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            recordedData.MyDirection[frameCounter] = Directions.RIGHT;
            movement = Vector3.right;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            recordedData.MyDirection[frameCounter] = Directions.DOWN;
            movement = Vector3.down;

        }

        this.transform.position += movement * Time.deltaTime;

        frameCounter++;
	}

    public void InitiateFile() {
    
        file = File.Open(Application.dataPath + "/" + fileDestination, FileMode.Create);
        file.Close();

        bf = new BinaryFormatter();
    }

    public void PrepareFileUpdate() {
        file = File.Open(Application.dataPath + "/" + fileDestination, FileMode.Append);
    }

    public void SaveData()
    {

    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");

        bf.Serialize(file, recordedData);
        file.Close();


        //newCharacter = ScriptableObject.CreateInstance<CharacterData>();
        //newCharacter.fileName = "TEST";


        // Path to loaded asset should be relative to the project folder. 
        //newCharacter.file = AssetDatabase.LoadAssetAtPath<DefaultAsset>("Assets/" + fileName);
        //AssetDatabase.CreateAsset(newCharacter, "Assets/TestChar.asset");

    }



    

}

[Serializable]
class FrameData
{
    // Initial Guess 120 FPS * 5 minutes
    public Directions[] MyDirection = new Directions[120 * 60 * 5];

}

enum Directions { NULL, UP, LEFT, DOWN, RIGHT }
