using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWeapon : BaseWeapon
{
    public GameObject spell;
    public Animator ani;
    public Transform attackPoint;

    public Camera cam;

    public override void Attack()
    {       
        attacking = true;
        ani.SetTrigger("Basic_Attack");
        StartCoroutine(Timer());
    }
    private void AttackLogic()
    {        
        GameObject instance;
        instance = Instantiate(spell, attackPoint.position, /* Quaternion.identity */ cam.transform.rotation);
        instance.GetComponent<BaseProjectile>().Setup(damage, attacker, 4);
        instance.transform.rotation = Quaternion.LookRotation(transform.up);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
        attacked = true;
        attacking = false;
    }


    public override void Setup()
    {
        ani = GetComponentInChildren<Animator>();
        cam = FindObjectOfType<Camera>();
        base.Setup();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.60f);
        AttackLogic();
    }

}
