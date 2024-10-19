using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJointScript : MonoBehaviour
{
    [SerializeField] private DistanceJoint2D distanceJoint2D;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float detection;


    private void Update()
    {
        Vector2 distance1 = distanceJoint2D.connectedAnchor;
        Vector2 distance2 = distanceJoint2D.transform.position;

        Collider2D[] hits = Physics2D.OverlapAreaAll(distance1, distance2, layerMask);

        if (hits.Length > 0)
        {
            Debug.Log("Player가 있습니다.");
        }

    }

}
