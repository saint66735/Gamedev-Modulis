using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
    }
}
