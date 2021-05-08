using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public float damage;
    public bool attacked = false;
    public bool attacking = false;
    public float attackDelay = 1;
    public string attacker;

    virtual public void Setup()
    {
        attacker = transform.parent.tag;
    }
    private void Start()
    {
        Setup();
    }
    virtual public void Upgrade()
    {
        throw new NotImplementedException();
    }

    virtual public void Attack()
    {
        throw new NotImplementedException();
    }
    virtual public void SecondaryAction()
    {
        throw new NotImplementedException();
    }
    virtual public void IncreaseDamage(float increase)
    {
        damage += increase;
    }
    virtual public void DecreaseAttackDelay()
    {
        attackDelay -= attackDelay / 20;
    }
}
