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
    private string _createScript = "NewScript";
    private string scriptPath = "Assets/01.Scripts/Tests";

    [MenuItem("Custom/CreateScene")]

    private static void Init()
    {
        WindowCustomEditor editor = (WindowCustomEditor)GetWindow(typeof(WindowCustomEditor));
        editor.Show();
    }

    private void OnGUI()
    {
        _string = EditorGUILayout.TextField("씬 이름 : ", _string);
        folderPath = EditorGUILayout.TextField("폴더 경로 : ", folderPath);


        if (GUILayout.Button("CreateNewScene"))
        {
            CreateScene();
        }

        _createScript = EditorGUILayout.TextField("스크립트 이름 : ", _createScript);
        scriptPath = EditorGUILayout.TextField("폴더 경로 : ", scriptPath);

        if (GUILayout.Button("CreateNewScript"))
        {
            CreateScript();
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

        Debug.Log("씬 생성");
    }

    public void CreateScript()
    {
        string path = scriptPath;
        if (File.Exists(path))
        {
            Debug.LogError("이미 존재하는 스크립트입니다.");
            return;
        }

        string scriptContent = 
$@"using UnitySystem; 
    
    public class {_createScript} : MonoBehaviour
{{
void Start()
{{

}}
}}";

        File.WriteAllText(path, scriptContent);
        AssetDatabase.Refresh();
        Debug.Log($"스크립트 {_createScript} 생성 완료!");
    }

}

#endif
