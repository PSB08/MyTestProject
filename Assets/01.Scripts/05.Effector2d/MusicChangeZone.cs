using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeZone : MonoBehaviour
{
    [SerializeField] private Vector2 gizmoSize;

    public AudioClip newMusic;
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
        yield return StartCoroutine(FadeOut(audioSource, 1f)); 

        audioSource.clip = newClip;
        audioSource.Play();

        yield return StartCoroutine(FadeIn(audioSource, 1f)); 
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0; 
        audioSource.Stop();
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

        audioSource.volume = 1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, gizmoSize);
        Gizmos.color = Color.white;
    }

}
