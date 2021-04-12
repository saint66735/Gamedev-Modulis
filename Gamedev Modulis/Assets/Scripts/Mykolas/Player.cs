using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : BaseEntity
{
    BaseJob job;
    public static string charName;
    public float level = 1;
    [SerializeField]
    int xp = 0;
    float xpReq = 10;
    public Transform attackPoint;
    private BaseWeapon weapon;
    float currentDelay = 0;
    Slider slider;
    GameObject sliderObj;
    GameObject lvlupOBJ;
    MenuScript script;
    public Text lvlup;
    bool canLevelUp=false;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindObjectOfType<MenuScript>();
        sliderObj = script.rechargeSlider;
        lvlupOBJ = script.lvlupText;
        slider = sliderObj.GetComponent<Slider>();
        maxHealth = 100;
        GetWeapon();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
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
        if (Input.GetKey(KeyCode.Mouse0) && !weapon.attacked && !weapon.attacking)
        {
            weapon.attacking = true;
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
        if(canLevelUp&&Input.GetKeyDown(KeyCode.I))
            LevelUp();
    }

    void GetWeapon()
    {
        weapon = attackPoint.GetChild(0).GetComponent<BaseWeapon>();
    }
    void LevelUp()
    {
        level++;
        lvlupOBJ.SetActive(false);
        Debug.Log("lEVEL UP. New xp req is " + xpReq);
    }
    public void IncreaseXp(int xpValue)
    {
        xp += xpValue;
    }
    void IncreaseStats(int op)
    {
        switch (op)
        {
            case 1:
                maxHealth += 20;
                break;
            case 2:
                Debug.Log("STR");
                break;
            case 3:
                Debug.Log("STA");
                break;
        }
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
