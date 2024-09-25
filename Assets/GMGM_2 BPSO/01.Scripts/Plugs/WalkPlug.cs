
using UnityEngine;

[CreateAssetMenu(menuName = "Plug/Walk")]
public class WalkPlug : PlugBase
{
    public override void Execute(GameObject owner)
    {
        Debug.Log($"Execute Walk Plug on {owner.name}");
    }

    public override void UpdatePlug(GameObject owner)
    {
        Debug.Log($"Updating Walk Plug on {owner.name}");
    }
    
    public override void Exit(GameObject owner)
    {
        Debug.Log($"Exit Walk Plug On {owner.name}");
    }
}