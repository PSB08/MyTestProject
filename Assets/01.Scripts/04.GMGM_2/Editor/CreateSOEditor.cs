using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
public class CreateSOEditor : EditorWindow
{
    
    private string _plugName = "NewPlug";
    private string[] existingPlugList;
    private string[] existingSOList;

    [MenuItem("Custom/CreateSO")]
    public static void ShowWindow()
    {
        GetWindow<CreateSOEditor>("CreateSO");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create new Plug", EditorStyles.boldLabel);
        _plugName = EditorGUILayout.TextField("Plug Name:", _plugName);

        if (GUILayout.Button("Create Plugs"))
        {
            CreatePlug();
        }

        if (GUILayout.Button("Create SO Last Plug"))
        {
            CreateSOFromLastPlug();
        }

        if (GUILayout.Button("Refresh Lists"))
        {
            RefreshLists();
        }

        DisplayPlugAndSOLists();
    }

    private void CreatePlug()
    {
        // Create Plug script
        string scriptPath = $"Assets/01.Scripts/04.GMGM_2/Plugs/{_plugName}Plug.cs";

        // Create the script file
        string scriptContent = $@"
using UnityEngine;

[CreateAssetMenu(menuName = ""Plug/{_plugName}"")]
public class {_plugName}Plug : PlugBase
{{
    public override void Execute(GameObject owner)
    {{
        Debug.Log($""Execute {_plugName} Plug on {{owner.name}}"");
    }}

    public override void UpdatePlug(GameObject owner)
    {{
        Debug.Log($""Updating {_plugName} Plug on {{owner.name}}"");
    }}
    
    public override void Exit(GameObject owner)
    {{
        Debug.Log($""Exit {_plugName} Plug On {{owner.name}}"");
    }}
}}";
        File.WriteAllText(scriptPath, scriptContent);
        AssetDatabase.Refresh();

        Debug.Log($"{_plugName}Plug created.");
    }

    private void CreateSOFromLastPlug()
    {
        string soPath = $"Assets/06.SO/Tests/{_plugName}PlugSO.asset";

        // Create the ScriptableObject
        var soInstance = ScriptableObject.CreateInstance($"{_plugName}Plug"); // Create instance of the generated Plug
        AssetDatabase.CreateAsset(soInstance, soPath);
        AssetDatabase.SaveAssets();

        Debug.Log($"{_plugName}PlugSO created.");
    }

    private void RefreshLists()
    {
        RefreshPlugList();
        RefreshSOList();
    }

    private void RefreshPlugList()
    {
        string[] guids = AssetDatabase.FindAssets("t:MonoScript", new[] { "Assets/01.Scripts//04.GMGM_2/Plugs" });
        existingPlugList = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            existingPlugList[i] = Path.GetFileNameWithoutExtension(path);
        }
    }

    private void RefreshSOList()
    {
        string[] guids = AssetDatabase.FindAssets($"{_plugName}PlugSO" , new[] {"Assets/06.SO/Tests"});
        existingSOList = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            existingSOList[i] = path;
        }
    }

    private void DisplayPlugAndSOLists()
    {
        if (existingPlugList != null)
        {
            GUILayout.Label("Existing Plugs:", EditorStyles.boldLabel);
            foreach (var plug in existingPlugList)
            {
                EditorGUILayout.LabelField(plug);
            }
        }

        if (existingSOList != null)
        {
            GUILayout.Label("Existing SOs:", EditorStyles.boldLabel);
            foreach (var so in existingSOList)
            {
                EditorGUILayout.LabelField(so);
            }
        }
    }

    private void OnSelectionChange()
    {
        if (Selection.activeObject is MonoScript)
        {
            var selectedScript = Selection.activeObject as MonoScript;
            string scriptName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(selectedScript));
            string soPath = $"Assets/01.Scripts/04.GMGM_2/Tests/{scriptName}PlugSO.asset";

            if (File.Exists(soPath))
            {
                AssetDatabase.DeleteAsset(soPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"{scriptName}PlugSO deleted.");
            }
        }
    }
}
#endif