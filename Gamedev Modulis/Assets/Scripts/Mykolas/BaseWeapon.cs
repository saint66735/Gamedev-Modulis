using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public float damage;
    public bool attacked = false;
    public float attackDelay = 1;

    virtual public void Setup()
    {

    }
    private void Start()
    {
        Setup();
    }
    virtual public void Upgrade()
    {

    }

    virtual public void Attack()
    {
        throw new NotImplementedException();
    }
}
