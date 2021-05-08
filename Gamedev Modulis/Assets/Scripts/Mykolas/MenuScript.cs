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
        Player instance = Instantiate(player, spawnPoint).GetComponent<Player>();
        playerScript = instance.GetComponent<Player>();

        menuCamera.SetActive(false);
        buttons.SetActive(false);
        sensitivity.SetActive(false); 
        return instance;        
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
