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
    public float updateSpeed = 0.1f; // �׷��� ��ȭ �ӵ� (0.01 ~ 1 ���̷� ����)
    public LineRenderer lineRenderer;

    private AudioClip micClip;
    private float[] samples;
    private float[] smoothSamples; // ���� ���ð� ������ �迭

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, AudioSettings.outputSampleRate);
            samples = new float[sampleSize];
            smoothSamples = new float[sampleSize]; // �ʱ�ȭ
            lineRenderer.positionCount = sampleSize;
        }
        else
        {
            Debug.LogError("����ũ�� ã�� �� �����ϴ�.");
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
            float y = smoothSamples[i] * waveformHeight; // �ε巴�� ������ �� ���
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

}
