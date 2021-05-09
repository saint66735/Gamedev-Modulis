using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject StartGame;
    public GameObject Settings;
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnStartGame()
    {
        StartGame.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnSettings()
    {
        Settings.SetActive(true);
        gameObject.SetActive(false);
    }
}
