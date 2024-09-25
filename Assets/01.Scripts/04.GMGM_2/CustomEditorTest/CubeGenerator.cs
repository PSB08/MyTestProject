using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float distance;
    [SerializeField] private int cubeCount;
    public string str;

    public void GenerateCube()
    {
        if (transform.childCount != 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < cubeCount; i++)
        {
            var newCube = Instantiate(_cube);
            newCube.transform.SetParent(gameObject.transform);
            newCube.transform.localPosition = new Vector3(i * distance, 0f, 0f);
            newCube.transform.localRotation = Quaternion.identity;
        }

    }

    public void DeleteCube()
    {
        if (transform.childCount != 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }


}
