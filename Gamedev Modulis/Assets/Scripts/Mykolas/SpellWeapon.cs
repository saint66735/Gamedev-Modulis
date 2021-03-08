using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWeapon : BaseWeapon
{
    public GameObject spell;

    public override void Attack()
    {
        GameObject instance;
        instance = Instantiate(spell, transform.position, Quaternion.identity);
        instance.GetComponent<BaseProjectile>().Setup(damage, transform.tag, 4);
        instance.transform.rotation = Quaternion.LookRotation(transform.up);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);        
        attacked = true;
    }

    public override void Setup()
    {
        base.Setup();
    }
}
