using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEditor.SceneManagement;
using System.IO;



#if UNITY_EDITOR
using UnityEditor;


public class WindowCustomEditor : EditorWindow
{
    private string _string = "NewScene";
    private string folderPath = "Assets/00.Scenes/Tests";
    private string prefabName;
    string prefabPath = "Assets/Prefabs/" + "name" + ".prefab";

    [MenuItem("Custom/CreateScene")]

    private static void Init()
    {
        WindowCustomEditor editor = (WindowCustomEditor)GetWindow(typeof(WindowCustomEditor));
        editor.Show();
    }

    private void OnGUI()
    {
        _string = EditorGUILayout.TextField("�� �̸� : ", _string);
        folderPath = EditorGUILayout.TextField("���� ��� : ", folderPath);

        if (GUILayout.Button("CreateNewScene"))
        {
            CreateScene();
        }

        prefabName = EditorGUILayout.TextField("Prefab �̸� : ", prefabName);
        prefabPath = EditorGUILayout.TextField("Prefab ��� : ", prefabPath);

        if (GUILayout.Button("CreatePrefab"))
        {
            CreatePrefab(prefabName);
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

    }

    public void CreatePrefab(string name)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab != null)
        {
            PrefabUtility.InstantiatePrefab(prefab);
            Debug.Log($"{name} �������� ���� �߰��Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogError($"{name} �������� ã�� �� �����ϴ�.");
        }
    }

}

#endif
