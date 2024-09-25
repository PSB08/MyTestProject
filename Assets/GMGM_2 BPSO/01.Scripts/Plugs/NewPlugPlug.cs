
using UnityEngine;

[CreateAssetMenu(menuName = "Plug/NewPlug")]
public class NewPlugPlug : PlugBase
{
    public override void Execute(GameObject owner)
    {
        Debug.Log($"Execute NewPlug Plug on {owner.name}");
    }

    public override void UpdatePlug(GameObject owner)
    {
        Debug.Log($"Updating NewPlug Plug on {owner.name}");
    }
    
    public override void Exit(GameObject owner)
    {
        Debug.Log($"Exit NewPlug Plug On {owner.name}");
    }
}