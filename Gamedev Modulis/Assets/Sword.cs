using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    Animator swordAnim;

    public override void Attack()
    {
        attacked = true;
        swordAnim.SetTrigger("Base_Attack");
    }

    public override void Setup()
    {
        gameObject.GetComponent<ArrowKill>().Setup(damage, transform.parent.tag);
        swordAnim = GetComponent<Animator>();
    }

}
