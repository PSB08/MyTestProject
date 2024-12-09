using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Csharp1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public int a = 10;
    public int b = 25;

    private void Start()
    {
        text.text = Plus(a,b).ToString();
    }

    private int Plus(int a, int b)
    {
        return a + b;
    }

    
}
