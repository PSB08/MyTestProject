using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEditor.SceneManagement;



#if UNITY_EDITOR
using UnityEditor;


public class WindowCustomEditor : EditorWindow
{
    private string _string = "NewScene";
    private string folderPath = "Assets/00.Scenes/Tests";

    [MenuItem("Custom/CreateScene")]

    private static void Init()
    {
        WindowCustomEditor editor = (WindowCustomEditor)GetWindow(typeof(WindowCustomEditor));
        editor.Show();
    }

    private void OnGUI()
    {
        _string = EditorGUILayout.TextField("¾À ÀÌ¸§ ddd: ", _string);
        folderPath = EditorGUILayout.TextField("Æú´õ °æ·Î : ", folderPath);


        if (GUILayout.Button("CreateNewScene"))
        {
            CreateScene();
        }

    }

    public void CreateScene()
    {
        string path = System.IO.Path.Combine(folderPath, _string + ".unity");

        if (!AssetDatabase.IsValidFolder(folderPath))
            AssetDatabase.CreateFolder("Assets", "Scenes");

        EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), path);
        AssetDatabase.Refresh();

        Debug.Log("¾À »ý¼º");
    }

}

#endif
