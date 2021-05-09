using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixer mixer;
    Resolution[] resolutions;
    public Dropdown res;
    private void Start()
    {
        resolutions = Screen.resolutions;
        res.ClearOptions();
        List<string> ops = new List<string>();
        int curResIndex=0;
        for(int i=0; i<resolutions.Length;i++)
        {
            string text = resolutions[i].width + "x" + resolutions[i].height;
            ops.Add(text);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }
        res.AddOptions(ops);
        res.value = curResIndex;
        res.RefreshShownValue();
    }
    public void OnBack()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVol", volume);
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFX_Vol", volume);
    }
    public void SetMasterVol(float volume)
    {
        mixer.SetFloat("MasterVol", volume);
    }
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SelectResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
