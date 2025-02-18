using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicVolume : MonoBehaviour
{
    public string micDevice;
    public int sampleSize = 1024;
    public float waveformHeight = 5f;
    public float waveformWidth = 10f;
    public float updateSpeed = 0.1f; // 그래프 변화 속도 (0.01 ~ 1 사이로 조절)
    public LineRenderer lineRenderer;

    private AudioClip micClip;
    private float[] samples;
    private float[] smoothSamples; // 이전 샘플과 보간할 배열

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, AudioSettings.outputSampleRate);
            samples = new float[sampleSize];
            smoothSamples = new float[sampleSize]; // 초기화
            lineRenderer.positionCount = sampleSize;
        }
        else
        {
            Debug.LogError("마이크를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (micClip == null) return;

        int micPosition = Microphone.GetPosition(micDevice) - sampleSize;
        if (micPosition < 0) return;

        micClip.GetData(samples, micPosition);
        SmoothWaveform();
        DrawWaveform();
    }

    void SmoothWaveform()
    {
        for (int i = 0; i < sampleSize; i++)
        {
            smoothSamples[i] = Mathf.Lerp(smoothSamples[i], samples[i], updateSpeed);
        }
    }

    void DrawWaveform()
    {
        float scaleX = waveformWidth / sampleSize;

        for (int i = 0; i < sampleSize; i++)
        {
            float x = i * scaleX - (waveformWidth / 2);
            float y = smoothSamples[i] * waveformHeight; // 부드럽게 보간된 값 사용
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

}
