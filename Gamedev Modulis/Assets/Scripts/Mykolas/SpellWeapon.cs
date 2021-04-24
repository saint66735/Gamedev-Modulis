using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWeapon : BaseWeapon
{
    public GameObject spell;
    Animator ani;
    public Transform attackPoint;

    public override void Attack()
    {
        attacking = true;
        ani.SetTrigger("Basic_Attack");
        StartCoroutine("Timer");
    }
    private void AttackLogic()
    {        
        GameObject instance;
        instance = Instantiate(spell, attackPoint.position, /*Quaternion.identity*/Quaternion.Euler(Vector3.up + Vector3.forward));
        instance.GetComponent<BaseProjectile>().Setup(damage, transform.tag, 4);
        instance.transform.rotation = Quaternion.LookRotation(transform.up);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
        attacked = true;
        attacking = false;
    }


    public override void Setup()
    {
        ani = GetComponent<Animator>();

        base.Setup();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.52f);
        AttackLogic();
    }

}
