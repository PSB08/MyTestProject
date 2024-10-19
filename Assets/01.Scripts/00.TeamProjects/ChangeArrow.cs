using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArrow : MonoBehaviour
{
    [Header("Arrow")]
    [SerializeField] private GameObject arrow;
    [Header("Collider")]
    [SerializeField] private CircleCollider2D circleCollider;

    private int rotateValue = 180;

    private void Start()
    {
        arrow = GameObject.FindWithTag("Gim");
        circleCollider = circleCollider.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider" && arrow != null)
        {
            arrow.transform.Rotate(arrow.transform.rotation.x, arrow.transform.rotation.y, rotateValue);
            circleCollider.enabled = false;
        }
    }

}
