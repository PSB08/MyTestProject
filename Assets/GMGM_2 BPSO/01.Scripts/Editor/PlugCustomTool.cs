using UnityEngine;
using UnityEditor;
using System.IO;

public class PlugCustomTool : EditorWindow
{
    private string plugName = "NewPlug";
    private string[] existingPlugList;
    private string[] existingSOList;

    [MenuItem("Tools/Plug Custom Tool")]
    public static void ShowWindow()
    {
        GetWindow<PlugCustomTool>("Plug Custom Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create a new Plug", EditorStyles.boldLabel);
        plugName = EditorGUILayout.TextField("Plug Name:", plugName);

        if (GUILayout.Button("Create Plug"))
        {
            CreatePlug();
        }

        if (GUILayout.Button("Create SO from Last Plug"))
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
        string scriptPath = $"Assets/BPSO/01.Scripts/Plugs/{plugName}Plug.cs";

        // Create the script file
        string scriptContent = $@"
using UnityEngine;

[CreateAssetMenu(menuName = ""Plug/{plugName}"")]
public class {plugName}Plug : PlugBase
{{
    public override void Execute(GameObject owner)
    {{
        Debug.Log($""Execute {plugName} Plug on {{owner.name}}"");
    }}

    public override void UpdatePlug(GameObject owner)
    {{
        Debug.Log($""Updating {plugName} Plug on {{owner.name}}"");
    }}
    
    public override void Exit(GameObject owner)
    {{
        Debug.Log($""Exit {plugName} Plug On {{owner.name}}"");
    }}
}}";
        File.WriteAllText(scriptPath, scriptContent);
        AssetDatabase.Refresh();

        Debug.Log($"{plugName}Plug created.");
    }

    private void CreateSOFromLastPlug()
    {
        string soPath = $"Assets/BPSO/08.SO/{plugName}PlugSO.asset";

        // Create the ScriptableObject
        var soInstance = ScriptableObject.CreateInstance($"{plugName}Plug"); // Create instance of the generated Plug
        AssetDatabase.CreateAsset(soInstance, soPath);
        AssetDatabase.SaveAssets();

        Debug.Log($"{plugName}PlugSO created.");
    }

    private void RefreshLists()
    {
        RefreshPlugList();
        RefreshSOList();
    }

    private void RefreshPlugList()
    {
        string[] guids = AssetDatabase.FindAssets("t:MonoScript", new[] { "Assets/BPSO/01.Scripts/Plugs" });
        existingPlugList = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            existingPlugList[i] = Path.GetFileNameWithoutExtension(path);
        }
    }

    private void RefreshSOList()
    {
        string[] guids = AssetDatabase.FindAssets($"{plugName}PlugSO" , new[] {"Assets/BPSO/08.SO"});
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
            string soPath = $"Assets/BPSO/01.Scripts/Plugs/{scriptName}PlugSO.asset";

            if (File.Exists(soPath))
            {
                AssetDatabase.DeleteAsset(soPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"{scriptName}PlugSO deleted.");
            }
        }
    }
}
