using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && !weapon.attacked)
        {
            weapon.Attack();
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
        Debug.Log("lEVLE UP. New xp req is " + xpReq);
    }
    public void IncreaseXp(int xpValue)
    {
        xp += xpValue;
    }
}
