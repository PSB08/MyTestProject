using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectManager : MonoBehaviour
{
    private static Vector2 iVector = new Vector2(1,1);  //�Ի纤��
    private static Vector2 normalVector = new Vector2(2,2);  //���� ����

    private static Vector3 iVec = new Vector3(1, 1, 1);  //�Ի纤��
    private static Vector3 nVec = new Vector3(2, 2, 2);  //��������

    Vector2 reflectedVector = Vector2.Reflect(iVector, normalVector);  //Reflect ���
    Vector3 reVec = Vector3.Reflect(iVec, nVec);  //Reflect ���

    private void Start()
    {
        Debug.Log(reflectedVector);  //���
        Debug.Log(reVec);  //���
    }
}
