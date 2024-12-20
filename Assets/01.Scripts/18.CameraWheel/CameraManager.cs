using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera; // ���� ī�޶�
    public Slider sizeSlider; // �����̵��
    public float scrollSpeed = 1f; // ��ũ�� �ӵ�

    void Start()
    {
        // �����̵���� �� ���� �̺�Ʈ�� �޼��� �߰�
        sizeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        // �ʱ� �� ����
        sizeSlider.value = mainCamera.orthographicSize;
    }

    void Update()
    {
        // ���콺 �� �Է� �ޱ�
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // ī�޶� ũ�� ����
        if (scrollInput != 0)
        {
            float newSize = mainCamera.orthographicSize - scrollInput * scrollSpeed;
            newSize = Mathf.Clamp(newSize, 1f, 20f); // ī�޶� ũ�� ����
            mainCamera.orthographicSize = newSize;
            sizeSlider.value = newSize; // �����̵�� ������Ʈ
        }
    }

    void OnSliderValueChanged(float value)
    {
        // ī�޶��� orthographicSize�� �����̵���� ������ ����
        mainCamera.orthographicSize = value;
    }
}
