using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMusic(AudioClip music)
    {
        StartCoroutine(StartFade(audio, 2, 0));
        //audio.clip = music;
        //audio.Play();
        //StartCoroutine(StartFade(audio, 0, 1));
        StartCoroutine(Wait2S(music));

    }
    IEnumerator Wait2S(AudioClip music)
    {
        yield return new WaitForSeconds(2);
        audio.clip = music;
        audio.Play();
        StartCoroutine(StartFade(audio, 1, 1));
        //audio.volume = 1;
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
