using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SynthesizeCheck : MonoBehaviour
{
    public int total;

    [Header("Btn")]
    [SerializeField] private UnityEngine.UI.Button btn;
    [SerializeField] private UnityEngine.UI.Button originBtn;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI originTxt;
    [SerializeField] private TMP_InputField totalInputTxt;
    [SerializeField] private TextMeshProUGUI synthesizeTxt;
    [SerializeField] private TextMeshProUGUI remainedTxt;

    private void Start()
    {
        btn.onClick.AddListener(Synthesize);
        originBtn.onClick.AddListener(TxtChange);
    }

    private void Synthesize()
    {
        int.TryParse(totalInputTxt.text, out total);

        int synthesizedValue = total / 3;
        int remainedValue = total % 3;

        string totalString = total.ToString();
        string synthesizeString = synthesizedValue.ToString();
        string remainString = remainedValue.ToString();

        if (synthesizedValue >= 3)
        {
            originTxt.text = "�ռ� ���� ����";
            synthesizeTxt.text = synthesizeString;
            remainedTxt.text = remainString;
        }
        else if (synthesizedValue <= 2)
        {
            originTxt.text = "��ᰡ �����ϴ�";
            synthesizeTxt.text = "0";
            remainedTxt.text = "0";
        }
        
    }

    public void TxtChange()
    {
        originTxt.text = "�� ���״�";
    }

}
