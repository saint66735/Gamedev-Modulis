using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public Camera menuCamera;
    public Slider slider;
    public GameObject buttons;
    public GameObject sword;
    public GameObject bow;
    public GameObject spell;

    public void SelectArcher()
    {
        Instantiate(bow, CreatePlayer().attackPoint);
        Debug.Log("I chose A");
    }
    public void SelectFighter()
    {
        Instantiate(sword, CreatePlayer().attackPoint);
        Debug.Log("I chose F");
    }
    public void SelectMage()
    {
        Instantiate(spell, CreatePlayer().attackPoint);
        Debug.Log("I chose M");
    }
    Player CreatePlayer()
    {
        Player instance = Instantiate(player, spawnPoint).GetComponent<Player>();
        menuCamera.enabled = false;
        menuCamera.GetComponent<AudioListener>().enabled = false;
        buttons.SetActive(false);
        return instance;
        slider.enabled = false;
    }
}
