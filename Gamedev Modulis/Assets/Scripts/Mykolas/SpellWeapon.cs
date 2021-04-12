using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWeapon : BaseWeapon
{
    public GameObject spell;
    Animator ani;

    public override void Attack()
    {
        StartCoroutine("Timer");
        ani.SetTrigger("Basic_Attack");
        
    }
    private void AttackLogic() 
    {
        attacking = true;
        GameObject instance;
        instance = Instantiate(spell, transform.position, Quaternion.identity);
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
