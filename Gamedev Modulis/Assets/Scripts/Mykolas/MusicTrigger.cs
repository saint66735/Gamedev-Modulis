using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    AudioManager am;
    public AudioClip clip;
    bool found = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!found && FindObjectOfType<AudioManager>() != null)
            am = FindObjectOfType<AudioManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            am.ChangeMusic(clip);
    }
}
