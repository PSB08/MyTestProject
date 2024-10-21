using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


[Flags]
public enum TTest
{
    t1 = 1,
    t2 = 2,
    t3 = 4,
    t4 = 8,
    t5 = 16
}

[System.Serializable]
public class A
{
    public int x;
    public int y;
}
[HelpURL("https://psb08.tistory.com/")]
public class AllAttribute : MonoBehaviour
{
    [Header("수")]
    [Range(-1.0f, 5.3f)]
    public int _cnt = 1;
    [Space(50)]
    [Tooltip("그저 그런 수 이다..")]
    [Range(-5.4f, 1.3f)]
    public float _type = 2;

    [SerializeField] private int count = 1;

    [System.NonSerialized]
    public double d1 = 1;
    [HideInInspector]
    public double d2 = 2;

    public A x;
    public TTest t;

    [ColorUsage(true, true)]
    public Color color;

    [Multiline(5)]
    public string _string;
    [TextArea]
    public string _string2;

    [UnityEditor.MenuItem("Test/TestStirng")]
    static void TestMenu()
    {
        Debug.Log("test");
    }


    private void Start()
    {
        Debug.Log(count);
    }

}

