using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime = 720f;
    private const float actionDuration = 12f;
    private float totalRemainingTime;
    private float actionRemainingTime;
    private bool isActionActive = false;
    private bool isPaused = false;

    [SerializeField] private TextMeshProUGUI totalTimeText;
    [SerializeField] private TextMeshProUGUI actionTimeText;

    void Start()
    {
        totalRemainingTime = totalTime;
        StartAction();
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (totalRemainingTime > 0) //total ���� Ÿ���� 0 �̻�
        {
            totalRemainingTime -= Time.deltaTime;  //total ���� Ÿ�� - ���� Ÿ��

            if (isActionActive && !isPaused)  //�������̰�, ������ �ʾҴٸ�
            {
                actionRemainingTime -= Time.deltaTime;  //action���� Ÿ�� - ���� Ÿ��

                if (actionRemainingTime <= 0)  //action ���� �ð� 0 ���ϸ�
                {
                    NextAction();  //���� �׼� ����
                }
            }

            if (totalRemainingTime < 0)  //total ���� Ÿ�� 0 �̸��̸�
            {
                totalRemainingTime = 0;  //total ���� Ÿ�� 0 ����
                EndTimer();  //������
            }

            UpdateTimerDisplay();  //UI ���� �޼���
        }

        if (Input.GetKeyDown(KeyCode.P)) // �ൿ�� ���ߴ� ����
        {
            totalRemainingTime += actionRemainingTime;
            isPaused = true; // �ൿ ����
        }
        if (Input.GetKeyDown(KeyCode.C)) // �ൿ�� �����ϴ� ����
        {
            actionRemainingTime = actionDuration;
            isPaused = false; // �ൿ ����
        }
    }

    private void StartAction()
    {
        isActionActive = true;  //�׼� true
        actionRemainingTime = actionDuration;  //�׼� ���� �ð� = �׼Ǳ��̸�ŭ
    }

    private void NextAction()
    {
        if (totalRemainingTime > 0)  //total ���� �ð� 0 �ʰ� ��
        {
            actionRemainingTime = actionDuration;  //�׼� ���� �ð��� �׼� ���̸�ŭ
            UpdateTimerDisplay();  //UI ����
        }
    }

    private void EndTimer()
    {
        Debug.Log("Ÿ�̸� ����! ��� �ൿ�� �����Ͽ����ϴ�.");  //Ÿ�̸� �� �˸�
    }

    private void UpdateTimerDisplay()
    {
        totalTimeText.text = "�� ���� �ð�: " + FormatTime(totalRemainingTime);  //UI ����
        actionTimeText.text = "�ൿ ���� �ð�: " + FormatTime(actionRemainingTime);  //UI ����
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

}
