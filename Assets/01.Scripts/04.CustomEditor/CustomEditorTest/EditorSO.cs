using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnityEditorSO", menuName = "ScriptableObjects/Data")]
public class EditorSO : ScriptableObject
{
    public string itemName;
    public int itemValue;
}
