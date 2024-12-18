using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    public Camera mainCamera; // 카메라 객체
    public RawImage displayImage; // 사진을 표시할 UI 요소
    public float captureDelay = 10f; // 사진 촬영 지연 시간

    private void Start()
    {
        // 10초 후에 CapturePhoto 메서드를 호출
        Invoke("CapturePhoto", captureDelay);
    }

    private void CapturePhoto()
    {
        // 카메라의 현재 상태를 기반으로 사진 촬영
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // 카메라로 촬영
        mainCamera.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        // RenderTexture 해제
        mainCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // 찍은 사진을 RawImage에 표시하고 활성화
        displayImage.texture = screenShot;
        displayImage.gameObject.SetActive(true); // RawImage 활성화
    }
}
