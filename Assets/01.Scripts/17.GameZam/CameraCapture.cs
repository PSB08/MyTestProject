using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    public Camera mainCamera; // ī�޶� ��ü
    public RawImage displayImage; // ������ ǥ���� UI ���
    public float captureDelay = 10f; // ���� �Կ� ���� �ð�

    private void Start()
    {
        // 10�� �Ŀ� CapturePhoto �޼��带 ȣ��
        Invoke("CapturePhoto", captureDelay);
    }

    private void CapturePhoto()
    {
        // ī�޶��� ���� ���¸� ������� ���� �Կ�
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // ī�޶�� �Կ�
        mainCamera.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        // RenderTexture ����
        mainCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // ���� ������ RawImage�� ǥ���ϰ� Ȱ��ȭ
        displayImage.texture = screenShot;
        displayImage.gameObject.SetActive(true); // RawImage Ȱ��ȭ
    }
}
