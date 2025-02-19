using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphMicVolume : MonoBehaviour
{
    public string micDevice;
    public int sampleSize = 1024;
    public float updateSpeed = 0.1f;
    public float updateInterval = 0.5f;
    public TextMeshProUGUI volumeText;
    public RectTransform volumeBar; // 막대 그래프 UI

    private AudioClip micClip;
    private float[] samples;
    private float smoothedDb = 0f;
    private float lastUpdateTime = 0f;

    private void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, AudioSettings.outputSampleRate);
            samples = new float[sampleSize];
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

        if (smoothedDb > 80f)
        {
            Debug.Log($"[경고] 높은 소리 감지: {smoothedDb:F2} dB");
        }

        if (Time.time - lastUpdateTime >= updateInterval)
        {
            volumeText.text = $"소리 크기: <color=red>{smoothedDb:F2}</color> dB";
            lastUpdateTime = Time.time;
        }

        UpdateVolumeBar(smoothedDb);
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

    private void UpdateVolumeBar(float volumeDb)
    {
        if (volumeBar != null)
        {
            float normalizedVolume = volumeDb / 120f; // 0~120dB를 0~1로 정규화
            float newHeight = Mathf.Lerp(volumeBar.sizeDelta.y, normalizedVolume * 200f, updateSpeed); // 최대 200px 높이
            volumeBar.sizeDelta = new Vector2(volumeBar.sizeDelta.x, newHeight);
        }
    }
}
