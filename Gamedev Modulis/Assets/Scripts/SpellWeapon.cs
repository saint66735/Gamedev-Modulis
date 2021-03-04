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
        instance.transform.rotation = Quaternion.LookRotation(transform.up);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
        instance.GetComponent<ArrowKill>().Setup(damage, transform.parent.tag);
        attacked = true;
    }

    public override void Setup()
    {
        base.Setup();
    }
}
