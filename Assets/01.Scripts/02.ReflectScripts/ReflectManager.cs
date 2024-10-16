using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectManager : MonoBehaviour
{
    private static Vector2 iVector = new Vector2(1,1);  //입사벡터
    private static Vector2 normalVector = new Vector2(2,2);  //법선 벡터

    private static Vector3 iVec = new Vector3(1, 1, 1);  //입사벡터
    private static Vector3 nVec = new Vector3(2, 2, 2);  //법선벡터

    Vector2 reflectedVector = Vector2.Reflect(iVector, normalVector);  //Reflect 계산
    Vector3 reVec = Vector3.Reflect(iVec, nVec);  //Reflect 계산

    private void Start()
    {
        Debug.Log(reflectedVector);  //출력
        Debug.Log(reVec);  //출력
    }
}
