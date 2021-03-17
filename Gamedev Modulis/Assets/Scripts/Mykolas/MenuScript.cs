using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public GameObject menuCamera;
    public GameObject sensitivity;
    public GameObject buttons;
    public GameObject sword;
    public GameObject bow;
    public GameObject spell;
    public List<GameObject> enemies;
    int i=0;

    public GameObject rechargeSlider;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemies[i].SetActive(true);
            i++;
        }
    }

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
        menuCamera.SetActive(false);
        buttons.SetActive(false);
        sensitivity.SetActive(false);
        return instance;        
    }
}
