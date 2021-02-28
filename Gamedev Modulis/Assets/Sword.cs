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
        /*Vector3 swordSpawnPoint = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z + 0.5f);
        GameObject instance = Instantiate(sword, swordSpawnPoint, Quaternion.Euler(0, 0, 0), transform);*/
        gameObject.GetComponent<ArrowKill>().Setup(damage, transform.parent.tag);
        swordAnim = GetComponent<Animator>();
    }

}
