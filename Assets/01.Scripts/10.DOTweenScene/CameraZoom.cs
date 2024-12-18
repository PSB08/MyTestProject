using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetSize(10, 2);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetSize(5, 2);
        }
    }

    private void SetSize(float size, float duration)
    {
        _camera.orthographicSize = Mathf.Clamp(size, 1f, 10f);
        _camera.DOOrthoSize(size, duration);
    }

}
