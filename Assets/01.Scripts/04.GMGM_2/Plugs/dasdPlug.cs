
using UnityEngine;

[CreateAssetMenu(menuName = "Plug/dasd")]
public class dasdPlug : PlugBase
{
    public override void Execute(GameObject owner)
    {
        Debug.Log($"Execute dasd Plug on {owner.name}");
    }

    public override void UpdatePlug(GameObject owner)
    {
        Debug.Log($"Updating dasd Plug on {owner.name}");
    }
    
    public override void Exit(GameObject owner)
    {
        Debug.Log($"Exit dasd Plug On {owner.name}");
    }
}