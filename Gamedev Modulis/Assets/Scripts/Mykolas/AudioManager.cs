using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audio;

    public void ChangeMusic(AudioClip music)
    {
        if (audio.clip == music)
            return;
        StartCoroutine(StartFade(audio, 2, 0));
        StartCoroutine(Wait2S(music));

    }
    IEnumerator Wait2S(AudioClip music)
    {
        yield return new WaitForSeconds(2);
        audio.clip = music;
        audio.Play();
        StartCoroutine(StartFade(audio, 1, 1));
    }
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
