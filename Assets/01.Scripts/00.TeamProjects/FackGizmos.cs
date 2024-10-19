using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FackGizmos : MonoBehaviour
{

    [Header("FallBlock")]
    [SerializeField] private GameObject fallBlock;
    [SerializeField] private Rigidbody2D rigidbody2;  

    [Header("Variable")]
    public float detectionRange = 5f;
    private Transform player;
    

    void Start()
    {
        player = GameObject.FindWithTag("PlayerCollider").transform;
        fallBlock = GameObject.FindWithTag("Gim");
        rigidbody2 = rigidbody2.GetComponent<Rigidbody2D>();
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider" && fallBlock != null && rigidbody2 != null)
        {
            rigidbody2.gravityScale = 1f;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
