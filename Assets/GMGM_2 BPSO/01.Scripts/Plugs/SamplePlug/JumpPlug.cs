using UnityEngine;

[CreateAssetMenu(menuName = "Plug/JumpPlug")]
public class JumpPlug : PlugBase
{
    public float jumpForce = 7f;
    private Rigidbody rb;

    public override void Execute(GameObject owner)
    {
        rb = owner.GetComponent<Rigidbody>();
    }

    public override void UpdatePlug(GameObject owner)
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
