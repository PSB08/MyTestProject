using System;
using Cinemachine;
using UnityEngine;

namespace _01.Scripts._06.Joint2D.GameScript
{
    public class PlayerTeleport : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject target;
        [SerializeField] private CinemachineVirtualCamera cam;
        [SerializeField] private CinemachineConfiner confiner;
        [SerializeField] private PolygonCollider2D originCollider;
        [SerializeField] private PolygonCollider2D nextCollider;

        private void Awake()
        {
            cam = FindAnyObjectByType<CinemachineVirtualCamera>();
            confiner = cam.GetComponent<CinemachineConfiner>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerCollider"))
            {
                ActionPlayer();
                ChangeConfiner();
            }
        }
        private void ActionPlayer()
        {
            player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y,
                target.transform.position.z);
        }

        private void ChangeConfiner()
        {
            confiner.m_BoundingShape2D = nextCollider;
        }



    }
}
