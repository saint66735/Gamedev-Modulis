using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public GameObject mainMenu;

    public void OnBack()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SetMusicVolume(float volume)
    { }
    public void SetSFXVolume(float volume)
    { }
}
