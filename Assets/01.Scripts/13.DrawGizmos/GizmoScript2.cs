using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoScript2 : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Matrix4x4 tempMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one); 

        Gizmos.DrawSphere(Vector3.zero, 1f); 

        Gizmos.matrix = tempMatrix; 
    }
}
