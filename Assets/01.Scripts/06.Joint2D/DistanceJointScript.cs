using System;
using UnityEngine;

public class DistanceJointScript : MonoBehaviour
{
    [SerializeField] private DistanceJoint2D distanceJoint2D;
    [SerializeField] private LayerMask layerMask;


    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 distance1 = distanceJoint2D.connectedAnchor;
        Vector2 distance2 = distanceJoint2D.transform.position;

        Collider2D[] hits = Physics2D.OverlapAreaAll(distance1, distance2, layerMask);

        if (hits.Length > 0)
        {
            //위치 이동 내용 작성하기
        }
    }
}
