using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushBLock : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    public float pullForce = 5f;
    public float detectionRange = 5f;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("PlayerCollider").transform;
        rb = GetComponent<Rigidbody2D>();
        arrow = GameObject.FindWithTag("Gim");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < detectionRange)
            {
                //StartCoroutine(FlipGim());
                Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
                rb.AddForce(direction * pullForce);
            }
        }
        else if (player == null)
        {
            Debug.LogWarning("No Player");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            StartCoroutine(StartDelay());
        }
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    private IEnumerator FlipGim()
    {
        arrow.transform.Rotate(0, 0, 180);
        yield return null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
