using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    BaseJob job;
    string charName;
    float level;
    public Transform attackPoint;
    private BaseWeapon weapon;
    float currentDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        GetWeapon();
    }
    void Update()
    {
        if (weapon.attacked)
        {
            currentDelay += Time.deltaTime;
            if (currentDelay >= weapon.attackDelay)
            {
                currentDelay = 0;
                weapon.attacked = false;
            }
        }
        if (Input.GetMouseButtonDown(0) && !weapon.attacked)
        {
            weapon.Attack();
            weapon.attacked = true;
        }
    }

    void GetWeapon()
    {
        weapon = attackPoint.GetChild(0).GetComponent<BaseWeapon>();
    }
}
