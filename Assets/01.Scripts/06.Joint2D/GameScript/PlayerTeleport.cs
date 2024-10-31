using UnityEngine;

namespace _01.Scripts._06.Joint2D.GameScript
{
    public class PlayerTeleport : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerCollider"))
            {
                ActionPlayer();
            }
        }
        private void ActionPlayer()
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5,
                player.transform.position.z);
        }
    }
}
