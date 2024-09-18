using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputFieldTest : MonoBehaviour
{
    public TMP_InputField inputField; // TextMeshPro InputField를 연결합니다.
    public Button checkButton; // Button을 연결합니다.
    public string targetText = "Hello"; // 비교할 텍스트 설정

    void Start()
    {
        // 버튼 클릭 시 CheckInput() 메서드 호출
        checkButton.onClick.AddListener(CheckInput);
    }

    /// <summary>
    /// 텍스트가 같은지 체크하는 메서드
    /// </summary>
    void CheckInput()
    {
        // 입력된 텍스트 가져오기
        string userInput = inputField.text;

        // 입력된 텍스트가 목표 텍스트와 같은지 비교
        if (userInput == targetText)
        {
            //맞으면 씬 넘기기
            NextScene();
        }
        else
        {
            //아니면 Debug
            Debug.Log("False: 입력된 텍스트가 목표 텍스트와 다릅니다.");
        }
    }

    /// <summary>
    /// 씬 넘기기 메서드
    /// </summary>
    private void NextScene()
    {
        SceneManager.LoadScene("00.TestScene");
    }


}
