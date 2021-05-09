using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : BaseProjectile
{
    public GameObject hitExplosion;


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shooter) || collision.gameObject.CompareTag("Projectile"))
        {
            return;
        }

        ContactPoint explosionLocation = collision.GetContact(0);
        Vector3 pos = explosionLocation.point;
        GameObject instance = Instantiate(hitExplosion, pos, Quaternion.Euler(0, 0, 0));
        Destroy(instance, lifetime);
        Destroy(gameObject);
    }
}
