using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EditorList))]
public class DataListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorList dataList = (EditorList)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Add Data"))
        {
            EditorSO newData = ScriptableObject.CreateInstance<EditorSO>();
            dataList.dataList.Add(newData);
            AssetDatabase.AddObjectToAsset(newData, dataList);
            AssetDatabase.SaveAssets();
        }

        for (int i = 0; i < dataList.dataList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ObjectField(dataList.dataList[i], typeof(EditorSO), false);
            if (GUILayout.Button("Remove"))
            {
                dataList.dataList.RemoveAt(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
