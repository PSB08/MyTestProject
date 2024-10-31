using TMPro;
using UnityEngine;

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
        
        string synthesizeString = synthesizedValue.ToString();
        string remainString = remainedValue.ToString();

        if (synthesizedValue >= 3)
        {
            originTxt.text = "합성 가능 수량";
            synthesizeTxt.text = synthesizeString;
            remainedTxt.text = remainString;
        }
        else if (synthesizedValue <= 0)
        {
            originTxt.text = "재료가 없습니다";
            synthesizeTxt.text = "0";
            remainedTxt.text = "0";
        }
        
    }

    public void TxtChange()
    {
        originTxt.text = "쳇 들켰다";
    }

}
