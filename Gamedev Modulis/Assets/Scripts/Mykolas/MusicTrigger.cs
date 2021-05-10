using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    AudioManager am;
    public AudioClip clip;
    bool found = false;

    void Update()
    {
        if (!found && FindObjectOfType<AudioManager>() != null)
        {
            found = true;
            am = FindObjectOfType<AudioManager>();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            am.ChangeMusic(clip);
    }
}
