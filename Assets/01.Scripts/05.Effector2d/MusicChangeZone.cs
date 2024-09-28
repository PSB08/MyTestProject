using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeZone : MonoBehaviour
{
    [SerializeField] private Vector2 gizmoSize;

    public AudioClip newMusic; // 변경할 음악 클립
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeMusic(newMusic));
        }
    }

    private IEnumerator ChangeMusic(AudioClip newClip)
    {
        // 현재 음악을 페이드 아웃
        yield return StartCoroutine(FadeOut(audioSource, 1f)); // 1초 동안 페이드 아웃

        // 음악 클립 변경 및 재생
        audioSource.clip = newClip;
        audioSource.Play();

        // 새로운 음악을 페이드 인
        yield return StartCoroutine(FadeIn(audioSource, 1f)); // 1초 동안 페이드 인
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0; // 완전히 소리 끄기
        audioSource.Stop(); // 음악 멈추기
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }

        audioSource.volume = 1; // 완전히 소리 키우기
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, gizmoSize);
        Gizmos.color = Color.white;
    }

}
