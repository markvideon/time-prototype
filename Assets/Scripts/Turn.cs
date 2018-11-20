using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* Determine order for encounters, must provide info to accompanying UI class
    UI will require:

    ENCOUNTER TRIGGERED ON INTERACTION

    ENCOUNTER INITIATION (SCREEN) IS PUSHED DATA ABOUT ENCOUNTER FROM THE CHAR THAT TRIGGERED
    NPC CHARACTER CONTAINS REFERENCE TO IT OWN BATTLE SPRITE, ANIMATION, MOVESET. NPC METHOD
    USED TO FILL THE BATTLE SCREEN GAPS WITH SPECIFIC DATA 

-> avatar, health, etc. 

INTRO TEXT... SEMI-GENERIC

choose move panel, each selection enables/disables different panels

*/
public class TurnManager : MonoBehaviour {
    Queue<GameObject> TurnQueue;

    // Use this for initialization
    void Start () {
        TurnQueue = new Queue<GameObject>();

    }

    // Update is called once per frame
    void Update () {

	}


    // For all in encounter, add to queue
    void InitialiseQueue() {

    }

    void Subtract(GameObject last) {
        TurnQueue.Dequeue();
    }
}
