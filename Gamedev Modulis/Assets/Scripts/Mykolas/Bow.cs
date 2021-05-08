using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public GameObject arrow;
    float chargeTime = 2;
    float currentCharge = 0;
    float cameraFOV;
    public AudioSource charge;
    public AudioSource release;
    public override void Attack()
    {
        attacking = true;
        charge.Play();

        StartCoroutine(ChargeAttack(
            () =>
            {
                Debug.Log("No crash?");
                if (currentCharge > 0.3)
                {
                    GameObject instance;
                    instance = Instantiate(arrow, transform.position, transform.rotation /*Quaternion.identity*/);
                    release.Play();
                    //instance.transform.rotation = Quaternion.LookRotation(transform.up);
                    instance.GetComponent<BaseProjectile>().Setup(damage * currentCharge / 2, transform.parent.tag, 100);
                    instance.GetComponent<Rigidbody>().AddForce(transform.transform.forward * 1000 * currentCharge);
                }

                attacked = true;
                Debug.Log("charging " + currentCharge);
                currentCharge = 0;
                Camera.main.fieldOfView = cameraFOV;
                attacking = false;

            }));

    }
    IEnumerator ChargeAttack(System.Action onFinish)
    {
        while (Input.GetKey(KeyCode.Mouse0))
        {
            if (currentCharge < chargeTime)
            {

                currentCharge += Time.deltaTime * 2;
                Camera.main.fieldOfView -= Time.deltaTime * 5;
            }
            yield return null;

            /*if (Input.GetMouseButtonUp(0))
                yield return currentCharge;*/
        }
        onFinish?.Invoke();
    }

    public override void Setup()
    {
        base.Setup();
        cameraFOV = Camera.main.fieldOfView;
    }
}
