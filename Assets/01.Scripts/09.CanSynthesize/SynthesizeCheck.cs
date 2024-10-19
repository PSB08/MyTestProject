using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SynthesizeCheck : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int total;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI totalTxt;
    [SerializeField] private TextMeshProUGUI synthesizeTxt;
    [SerializeField] private TextMeshProUGUI remainedTxt;

    private void Start()
    {
        Synthesize();
    }

    private void Synthesize()
    {
        int synthesizedValue = total / 3;
        int remainedValue = total % 3;

        string totalString = total.ToString();
        string synthesizeString = synthesizedValue.ToString();
        string remainString = remainedValue.ToString();

        if (synthesizedValue >= 0)
        {
            Debug.Log(synthesizedValue);
            Debug.Log(remainedValue);
            synthesizeTxt.text = synthesizeString;
            remainedTxt.text = remainString;
            totalTxt.text = totalString;
        }
        else
        {
            Debug.Log("합성이 불가능 합니다.");
            synthesizeTxt.text = "합성이 불가능 합니다.";
        }
        
    }

}
