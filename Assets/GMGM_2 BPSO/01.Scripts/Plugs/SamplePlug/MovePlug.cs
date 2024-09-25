using UnityEngine;

[CreateAssetMenu(menuName = "Plug/MovePlug")]
public class MovePlug : PlugBase
{
    public float moveSpeed = 5f;

    public override void UpdatePlug(GameObject owner)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        owner.transform.Translate(direction);
    }
}
