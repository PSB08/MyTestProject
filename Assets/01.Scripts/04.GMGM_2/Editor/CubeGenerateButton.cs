using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CubeGenerator))]
public class CubeGenerateButton : Editor
{
    CubeGenerator _instance;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("CubeBtn");

        CubeGenerator generator = (CubeGenerator)target;
        if (GUILayout.Button("Generate Cube"))
        {
            generator.GenerateCube();
        }

        if (GUILayout.Button("Delete Cube"))
        {
            generator.DeleteCube();
        }

        EditorGUILayout.Space();

        //_instance.str = EditorGUILayout.TextField("cube");
    }
}
