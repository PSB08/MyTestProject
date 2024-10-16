using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FackGizmos : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private CircleCollider2D circleCollider;
    public float detectionRange = 5f;
    private Transform player;
    private int rotateValue = 180;

    void Start()
    {
        player = GameObject.FindWithTag("PlayerCollider").transform;
        arrow = GameObject.FindWithTag("Gim");
        circleCollider = circleCollider.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            arrow.transform.Rotate(arrow.transform.rotation.x, arrow.transform.rotation.y, rotateValue);
            circleCollider.enabled = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
