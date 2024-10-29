using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputFieldTest : MonoBehaviour
{
    public TMP_InputField inputField; 
    public Button checkButton; 
    public string targetText = "Hello";

    void Start()
    {
        checkButton.onClick.AddListener(CheckInput);
    }

    void CheckInput()
    {
        string userInput = inputField.text;

        if (userInput == targetText)
        {
            NextScene();
        }
        else
        {
            Debug.Log("False");
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(0);
    }


}
