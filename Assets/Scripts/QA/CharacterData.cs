/*
 * Scriptable Object Class for Character Data
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
[CreateAssetMenu(fileName = "New Character Data",menuName = "Character Data")]
public class CharacterData : ScriptableObject
{

    public float speedMultiplier = 1f;
    public Object file;
}