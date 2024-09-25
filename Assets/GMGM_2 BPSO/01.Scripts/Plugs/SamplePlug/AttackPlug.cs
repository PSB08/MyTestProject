using UnityEngine;

[CreateAssetMenu(menuName = "Plug/AttackPlug")]
public class AttackPlug : PlugBase
{
    public override void UpdatePlug(GameObject owner)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack!");
            // 공격 로직
        }
    }
}
