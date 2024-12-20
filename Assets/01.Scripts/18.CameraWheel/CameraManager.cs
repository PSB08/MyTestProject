using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera; // 메인 카메라
    public Slider sizeSlider; // 슬라이드바
    public float scrollSpeed = 1f; // 스크롤 속도

    void Start()
    {
        // 슬라이드바의 값 변경 이벤트에 메서드 추가
        sizeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        // 초기 값 설정
        sizeSlider.value = mainCamera.orthographicSize;
    }

    void Update()
    {
        // 마우스 휠 입력 받기
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // 카메라 크기 조정
        if (scrollInput != 0)
        {
            float newSize = mainCamera.orthographicSize - scrollInput * scrollSpeed;
            newSize = Mathf.Clamp(newSize, 1f, 20f); // 카메라 크기 제한
            mainCamera.orthographicSize = newSize;
            sizeSlider.value = newSize; // 슬라이드바 업데이트
        }
    }

    void OnSliderValueChanged(float value)
    {
        // 카메라의 orthographicSize를 슬라이드바의 값으로 설정
        mainCamera.orthographicSize = value;
    }
}
