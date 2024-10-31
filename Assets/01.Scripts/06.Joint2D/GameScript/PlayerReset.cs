using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform originTrans;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = originTrans.position;
        }
    }
}
