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
    public GameObject lvlupText;
    public List<GameObject> enemies;
    public GameObject LvlUpPopUp;
    int i=0;
    Player playerScript;
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
    public void IncreaseDamage()
    {
        playerScript.IncreaseDMG();
        EndLevelUp();
    }
 
    public void IncreaseHP()
    {
        playerScript.IncreaseHP();
        EndLevelUp();
    }
    public void IncreaseAtkSpeed()
    {
        playerScript.AtkSpeed();
        EndLevelUp();
    }
    void EndLevelUp()
    {
        LvlUpPopUp.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerScript.looking.enabled = true;
    }
    Player CreatePlayer()
    {
        Player instance = Instantiate(player, spawnPoint).GetComponent<Player>();
        GetPlayerScript();
        menuCamera.SetActive(false);
        buttons.SetActive(false);
        sensitivity.SetActive(false);
        return instance;        
    }
    void GetPlayerScript()
    {
        playerScript = player.GetComponent<Player>();
    }
}
