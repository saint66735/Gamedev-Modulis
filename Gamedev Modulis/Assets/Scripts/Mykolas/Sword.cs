using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    Animator swordAnim;

    public override void Attack()
    {
        attacking = true;
        attacked = true;
        swordAnim.SetTrigger("Base_Attack");
        attacking = false;
    }

    public override void Setup()
    {
        //gameObject.GetComponent<ArrowKill>().Setup(damage, transform.parent.tag);
        swordAnim = GetComponent<Animator>();
        swordAnim.speed = 3f;
        attacker = transform.parent.tag;
    }

}
