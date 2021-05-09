using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float damage;
    public string shooter;
    public float lifetime;
    public virtual void Setup(float damage, string shooter, float lifetime)
    {
        this.damage = damage;
        this.shooter = shooter;
        this.lifetime = lifetime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shooter) || collision.gameObject.CompareTag("Projectile"))
        {
            return;
        }
    }
}
