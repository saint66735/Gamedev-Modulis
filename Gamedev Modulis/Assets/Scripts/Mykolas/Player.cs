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
    MenuScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindObjectOfType<MenuScript>();
        sliderObj = script.rechargeSlider;
        slider = sliderObj.GetComponent<Slider>();
        health = 100;
        GetWeapon();
        
    }
    void Update()
    {
        if (weapon.attacked)
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
        if (Input.GetKey(KeyCode.Mouse0) && !weapon.attacked)
        {
            weapon.Attack();
            weapon.attacked = true;
            RechargeSlider();
        }
        if (xp >= xpReq)
            LevelUp();
    }

    void GetWeapon()
    {
        weapon = attackPoint.GetChild(0).GetComponent<BaseWeapon>();
    }
    void LevelUp()
    {
        xpReq += xpReq * 2;
        level++;
        Debug.Log("lEVEL UP. New xp req is " + xpReq);
    }
    public void IncreaseXp(int xpValue)
    {
        xp += xpValue;
    }
    void RechargeSlider()
    {
        sliderObj.SetActive(true);
        slider.maxValue = weapon.attackDelay;
        slider.minValue = 0;
    }
}
