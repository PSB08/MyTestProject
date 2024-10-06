using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectManager : MonoBehaviour
{
    private static Vector2 iVector = new Vector3(1,1);  //�Ի纤��
    private static Vector2 normalVector = new Vector3(2,2);  //���� ����

    Vector2 reflectedVector = Vector2.Reflect(iVector, normalVector);  //Reflect ���

    private void Start()
    {
        Debug.Log(reflectedVector);  //���
    }
}
