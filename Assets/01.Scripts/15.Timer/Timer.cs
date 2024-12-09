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
        if (totalRemainingTime > 0) //total 남은 타임이 0 이상
        {
            totalRemainingTime -= Time.deltaTime;  //total 남은 타임 - 현재 타임

            if (isActionActive && !isPaused)  //실행중이고, 멈추지 않았다면
            {
                actionRemainingTime -= Time.deltaTime;  //action남은 타임 - 현재 타임

                if (actionRemainingTime <= 0)  //action 남은 시간 0 이하면
                {
                    NextAction();  //다음 액션 수행
                }
            }

            if (totalRemainingTime < 0)  //total 남은 타임 0 미만이면
            {
                totalRemainingTime = 0;  //total 남은 타임 0 설정
                EndTimer();  //끝내기
            }

            UpdateTimerDisplay();  //UI 업뎃 메서드
        }

        if (Input.GetKeyDown(KeyCode.P)) // 행동을 멈추는 조건
        {
            totalRemainingTime += actionRemainingTime;
            isPaused = true; // 행동 멈춤
        }
        if (Input.GetKeyDown(KeyCode.C)) // 행동을 진행하는 조건
        {
            actionRemainingTime = actionDuration;
            isPaused = false; // 행동 진행
        }
    }

    private void StartAction()
    {
        isActionActive = true;  //액션 true
        actionRemainingTime = actionDuration;  //액션 남은 시간 = 액션길이만큼
    }

    private void NextAction()
    {
        if (totalRemainingTime > 0)  //total 남은 시간 0 초과 시
        {
            actionRemainingTime = actionDuration;  //액션 남은 시간을 액션 길이만큼
            UpdateTimerDisplay();  //UI 업뎃
        }
    }

    private void EndTimer()
    {
        Debug.Log("타이머 종료! 모든 행동을 수행하였습니다.");  //타이머 끝 알림
    }

    private void UpdateTimerDisplay()
    {
        totalTimeText.text = "총 남은 시간: " + FormatTime(totalRemainingTime);  //UI 업뎃
        actionTimeText.text = "행동 남은 시간: " + FormatTime(actionRemainingTime);  //UI 업뎃
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

}
