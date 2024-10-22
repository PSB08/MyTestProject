using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SynthesizeCheck : MonoBehaviour
{
    public int total;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI originTxt;
    [SerializeField] private TMP_InputField totalInputTxt;
    [SerializeField] private UnityEngine.UI.Button btn;
    [SerializeField] private TextMeshProUGUI synthesizeTxt;
    [SerializeField] private TextMeshProUGUI remainedTxt;

    private void Start()
    {
        btn.onClick.AddListener(Synthesize);
    }

    private void Synthesize()
    {
        int.TryParse(totalInputTxt.text, out total);

        int synthesizedValue = total / 3;
        int remainedValue = total % 3;

        string totalString = total.ToString();
        string synthesizeString = synthesizedValue.ToString();
        string remainString = remainedValue.ToString();

        if (synthesizedValue >= 0)
        {
            originTxt.text = "합성 가능 수량";
            synthesizeTxt.text = synthesizeString;
            remainedTxt.text = remainString;
        }
        else
        {
            originTxt.text = "합성이 불가능 합니다.";
            synthesizeTxt.text = "0";
            remainedTxt.text = "0";
        }
        
    }


}
