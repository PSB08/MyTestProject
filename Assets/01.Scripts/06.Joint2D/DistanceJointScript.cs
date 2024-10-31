using System;
using UnityEngine;

public class DistanceJointScript : MonoBehaviour
{
    [SerializeField] private GameObject objectA;
    [SerializeField] private GameObject objectB; 
    [SerializeField] private GameObject player; 

    private DistanceJoint2D distanceJoint;

    void Start()
    {
        distanceJoint = gameObject.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = objectA.GetComponent<Rigidbody2D>();
        distanceJoint.distance = Vector2.Distance(objectA.transform.position, objectB.transform.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider"))
        {
            ActionPlayer();
        }
    }

    private bool IsPlayerBetweenObjects()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 aPosition = objectA.transform.position;
        Vector2 bPosition = objectB.transform.position;
        Debug.Log(2);
        return playerPosition.x > Mathf.Min(aPosition.x, bPosition.x) &&
               playerPosition.x < Mathf.Max(aPosition.x, bPosition.x) &&
               playerPosition.y > Mathf.Min(aPosition.y, bPosition.y) &&
               playerPosition.y < Mathf.Max(aPosition.y, bPosition.y);

    }

    private void ActionPlayer()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
    }
}
