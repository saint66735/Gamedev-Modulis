using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : BaseEntity
{
    BaseJob job;
    public string charName;
    public float level = 1;
    [SerializeField]
    int xp = 0;
    public float xpReq = 10;
    public Transform attackPoint;
    public BaseWeapon weapon;
    float currentDelay = 0;
    Slider slider;
    GameObject sliderObj;
    GameObject lvlupOBJ;
    GameObject lvlUpMenu;
    MenuScript menuScript;
    public Text lvlup;
    bool canLevelUp = false;
    public D_Controller looking;
    public PlayerMovement01 playerMovementScript;
    public bool doingLVLUP = false;

    // public int maximumHealth = 100;
    // public int currentHealth;
    public HealthBar healthBar;




    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        health = maxHealth;
       
        playerMovementScript.onGroundHit.AddListener(yVelocity =>
        {
            Debug.Log($"Velocity {yVelocity}");
            if(yVelocity>-20)
            { return; }
            TakeDamage(Mathf.Abs(yVelocity * 2));
            if (health <= 0 && alive)
            {
                Die();
            }
        });

        rb = gameObject.GetComponent<Rigidbody>();
        doingLVLUP = false;
        menuScript = FindObjectOfType<MenuScript>();
        sliderObj = menuScript.rechargeSlider;
        lvlupOBJ = menuScript.lvlupText;
        lvlUpMenu = menuScript.LvlUpPopUp;
        slider = sliderObj.GetComponent<Slider>();
        
        // maxHealth = 100;
        // health = maxHealth;
    }
    void Update()
    {
        healthBar.slider.maxValue = maxHealth;
        healthBar.slider.value = health;
        
        if (doingLVLUP)
        {
            return;
        }

        if (weapon.attacked && !weapon.attacking)
        {
            currentDelay += Time.deltaTime;
            slider.value = currentDelay;
            if (currentDelay >= weapon.attackDelay)
            {
                currentDelay = 0;
                weapon.attacked = false;
                sliderObj.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && !weapon.attacked /*&& !weapon.attacking*/)
        {
            //weapon.attacking = true;
            weapon.Attack();
            weapon.attacked = true;
            if (!weapon.attacking)
                RechargeSlider();
        }
        if (xp >= xpReq)
        {
            xpReq += xpReq * 2;
            canLevelUp = true;
            lvlupOBJ.SetActive(true);
        }
        if (canLevelUp && Input.GetKeyDown(KeyCode.I))
        {
            menuScript.LevelUp();
        }
    }

    public void IncreaseXp(int xpValue)
    {
        xp += xpValue;
    }
    public void IncreaseDMG()
    {
        weapon.IncreaseDamage(level * 10 + 10);
    }

    public void IncreaseHP()
    {
        maxHealth += 20;
        health = maxHealth;
    }

    public void AtkSpeed()
    {
        weapon.DecreaseAttackDelay();
    }

    void RechargeSlider()
    {
        sliderObj.SetActive(true);
        slider.maxValue = weapon.attackDelay;
        slider.minValue = 0;
    }
    public override void Die()
    {
        Debug.Log("i has dieded");
    }
}
