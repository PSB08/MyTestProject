using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputFieldTest : MonoBehaviour
{
    public TMP_InputField inputField; // TextMeshPro InputField�� �����մϴ�.
    public Button checkButton; // Button�� �����մϴ�.
    public string targetText = "Hello"; // ���� �ؽ�Ʈ ����

    void Start()
    {
        // ��ư Ŭ�� �� CheckInput() �޼��� ȣ��
        checkButton.onClick.AddListener(CheckInput);
    }

    /// <summary>
    /// �ؽ�Ʈ�� ������ üũ�ϴ� �޼���
    /// </summary>
    void CheckInput()
    {
        // �Էµ� �ؽ�Ʈ ��������
        string userInput = inputField.text;

        // �Էµ� �ؽ�Ʈ�� ��ǥ �ؽ�Ʈ�� ������ ��
        if (userInput == targetText)
        {
            //������ �� �ѱ��
            NextScene();
        }
        else
        {
            //�ƴϸ� Debug
            Debug.Log("False: �Էµ� �ؽ�Ʈ�� ��ǥ �ؽ�Ʈ�� �ٸ��ϴ�.");
        }
    }

    /// <summary>
    /// �� �ѱ�� �޼���
    /// </summary>
    private void NextScene()
    {
        SceneManager.LoadScene("00.TestScene");
    }


}
