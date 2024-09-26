using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;


public class WindowCustomEditor : EditorWindow
{
    [MenuItem("Custom/WindowCustom")]
    private static void Init()
    {
        WindowCustomEditor editor = (WindowCustomEditor)GetWindow(typeof(WindowCustomEditor));
        editor.Show();
    }

    private void OnGUI()
    {
        GUILayout.TextField("Scene");
        GUILayout.TextArea("");
        GUILayout.Button("CreateNewScene");
    }

}

#endif
