using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public GameObject arrow;
    float chargeTime = 1;
    float charge = 0;
    public override void Attack()
    {
        if (charge < chargeTime)
            charge += Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && charge >= chargeTime / 2)
        {
            GameObject instance;
            instance = Instantiate(arrow, transform.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(transform.up);
            instance.GetComponent<BaseProjectile>().Setup(damage, transform.parent.tag, 100);
            instance.GetComponent<Rigidbody>().AddForce(transform.transform.forward * 500);
            attacked = true;
        }

    }

    public override void Setup()
    {
        base.Setup();
    }


}
