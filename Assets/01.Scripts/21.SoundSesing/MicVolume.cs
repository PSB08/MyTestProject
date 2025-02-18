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
    public float updateSpeed = 0.1f;
    public float updateInterval = 0.5f;
    public LineRenderer lineRenderer;
    public TextMeshProUGUI volumeText;

    private AudioClip micClip;
    private float[] samples;
    private float[] smoothSamples;
    private float smoothedDb = 0f;
    private float lastUpdateTime = 0f;

    private void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, AudioSettings.outputSampleRate);
            samples = new float[sampleSize];
            smoothSamples = new float[sampleSize];
            lineRenderer.positionCount = sampleSize;
        }
        else
        {
            Debug.LogError("마이크를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        if (micClip == null) return;

        int micPosition = Microphone.GetPosition(micDevice) - sampleSize;
        if (micPosition < 0) return;

        float volumeDb = GetMicVolumeDb();
        volumeDb = Mathf.Clamp(volumeDb + 80f, 0f, 120f); // 데시벨 범위 조정

        smoothedDb = Mathf.Lerp(smoothedDb, volumeDb, updateSpeed);

        if (Time.time - lastUpdateTime >= updateInterval)
        {
            volumeText.text = $"소리 크기: <color=red>{smoothedDb:F2}</color> dB";
            lastUpdateTime = Time.time;
        }

        micClip.GetData(samples, micPosition);
        SmoothWaveform();
        DrawWaveform();
    }

    private float GetMicVolumeDb()
    {
        float[] samples = new float[sampleSize];
        int micPosition = Microphone.GetPosition(micDevice) - sampleSize;
        if (micPosition < 0) return 0f;

        micClip.GetData(samples, micPosition);
        float sum = 0f;
        for (int i = 0; i < sampleSize; i++)
        {
            sum += samples[i] * samples[i];
        }

        float rms = Mathf.Sqrt(sum / sampleSize);
        float db = 20 * Mathf.Log10(rms);
        return db;
    }

    private void SmoothWaveform()
    {
        for (int i = 0; i < sampleSize; i++)
        {
            smoothSamples[i] = Mathf.Lerp(smoothSamples[i], samples[i], updateSpeed);
        }
    }

    private void DrawWaveform()
    {
        float scaleX = waveformWidth / sampleSize;

        for (int i = 0; i < sampleSize; i++)
        {
            float x = i * scaleX - (waveformWidth / 2);
            float y = smoothSamples[i] * waveformHeight;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

}
