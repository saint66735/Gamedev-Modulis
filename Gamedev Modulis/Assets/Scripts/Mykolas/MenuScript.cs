using System;
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
    public Slider sensitivitySlider;

    public GameObject HealthBar;
    int i=0;
    Player playerScript;
    public GameObject rechargeSlider;
    public Text playerName;
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
        Player instance = CreatePlayer();
        BaseWeapon wep = Instantiate(bow, instance.attackPoint).GetComponent<BaseWeapon>();
        instance.weapon = wep;
        Debug.Log("I chose A");
    }
    public void SelectFighter()
    {
        Player instance = CreatePlayer();
        BaseWeapon wep = Instantiate(sword, instance.attackPoint).GetComponent<BaseWeapon>();
        instance.weapon = wep;
        Debug.Log("I chose F");
    }

    public void SelectMage()
    {
        Player instance = CreatePlayer();
        BaseWeapon wep = Instantiate(spell, instance.attackPoint).GetComponent<BaseWeapon>();
        instance.weapon = wep;
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

    Player CreatePlayer()
    {
        Player tempPlayer;
        GameObject instance = Instantiate(player, spawnPoint);
        tempPlayer = instance.GetComponent<Player>();
        playerScript = instance.GetComponent<Player>();
        tempPlayer.charName = playerName.text;
        instance.GetComponentInChildren<D_Controller>().mouseSens = sensitivitySlider.value;
        menuCamera.SetActive(false);
        buttons.SetActive(false);
        sensitivity.SetActive(false);
        HealthBar.SetActive(true); 
        return tempPlayer;        
    }

    internal void LevelUp()
    {
        playerScript.doingLVLUP = true;
        playerScript.level++;
        lvlupText.SetActive(false);
        LvlUpPopUp.SetActive(true);

        playerScript.looking.canLook = false;
        playerScript.playerMovementScript.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("lEVEL UP. New xp req is " + playerScript.xpReq);
    }

    void EndLevelUp()
    {
        LvlUpPopUp.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerScript.looking.canLook = true;
        playerScript.playerMovementScript.canMove = true;
        playerScript.doingLVLUP = false;
    }
}