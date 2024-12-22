using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;
    [Space(10)]
    [Header("ScreenSize")]
    [SerializeField] private TMP_Dropdown screenModeDropdown;
    [SerializeField] private TMP_Text modeText;
    [Space(10)]
    [Header("Button")]
    [SerializeField] private Button goTitleBtn;
    [SerializeField] private Button exitBtn;
    [Space(10)]
    [Header("Value")]
    [SerializeField] private string scene;
    private bool isStopped = false;

    private void Start()
    {
        screenModeDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        exitBtn.onClick.AddListener(ExitBtn);
        goTitleBtn.onClick.AddListener(GoTitleBtn);
        UpdateScreenMode(screenModeDropdown.value);
    }

    private void Update()
    {
        if (!isStopped)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (panel.activeSelf)
                {
                    CloseEscPanel();
                }
                else
                {
                    OpenEscPanel();
                }

            }
        }
    }

    #region ScreenSize
    private void OnDropdownValueChanged(int index)
    {
        UpdateScreenMode(index);
    }

    private void UpdateScreenMode(int index)
    {
        switch (index)
        {
            case 0: 
                Screen.fullScreen = false;
                Screen.SetResolution(1920, 1080, false); 
                modeText.text = "창 모드";
                break;
            case 1: 
                Screen.fullScreen = false;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
                modeText.text = "테두리 없는 창 모드";
                break;
            case 2:
                Screen.fullScreen = true;
                modeText.text = "전체화면";
                break;
        }
    }

    #endregion

    #region Esc
    private void OpenEscPanel()
    {
        panel.SetActive(true);
    }

    private void CloseEscPanel()
    {
        panel.SetActive(false);
    }

    public void GoTitleBtn()
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    #endregion



}
