using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectManager : MonoBehaviour
{
    private static Vector2 iVector = new Vector3(1,1);  //입사벡터
    private static Vector2 normalVector = new Vector3(2,2);  //법선 벡터

    Vector2 reflectedVector = Vector2.Reflect(iVector, normalVector);  //Reflect 계산

    private void Start()
    {
        Debug.Log(reflectedVector);  //출력
    }
}
