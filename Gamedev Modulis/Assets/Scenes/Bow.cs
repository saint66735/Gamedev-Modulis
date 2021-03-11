using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public GameObject arrow;
    float chargeTime = 2;
    float currentCharge = 0;
    IEnumerator charge;
    float cameraFOV;
    public override void Attack()
    {
        charge = ChargeAttack();
        StartCoroutine(charge);
        if (currentCharge > 0.3f)
        {
            GameObject instance;
            instance = Instantiate(arrow, transform.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(transform.up);
            instance.GetComponent<BaseProjectile>().Setup(damage * currentCharge, transform.parent.tag, 100);
            instance.GetComponent<Rigidbody>().AddForce(transform.transform.forward * 500 * currentCharge);
        }

        attacked = true;
        Debug.Log("charging " + currentCharge);
        currentCharge = 0;
        Camera.main.fieldOfView = cameraFOV;
    }
    IEnumerator ChargeAttack()
    {
        while (Input.GetKey(KeyCode.Mouse0))
        {
            if (currentCharge < chargeTime)
            {
                currentCharge += Time.deltaTime;
                Camera.main.fieldOfView -= Time.deltaTime * 3;
            }
            yield return currentCharge;

        }
        

    }

    public override void Setup()
    {
        base.Setup();
        cameraFOV = Camera.main.fieldOfView;
    }


}
