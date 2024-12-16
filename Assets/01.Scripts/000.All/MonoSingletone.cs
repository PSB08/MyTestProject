using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = FindObjectOfType<T>();

        DontDestroyOnLoad(this);
    }
}
