using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BaseEntity : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool alive = true;
    public Rigidbody rb;
    public AudioSource damageSound;

    virtual public void TakeDamage(float damage)
    {
        health -= damage;
        damageSound.Play();
    }

    virtual public void Attack()
    {

    }

    virtual public void Die()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile" && !CompareTag(collision.collider.GetComponent<BaseProjectile>().shooter))
        {
            TakeDamage(collision.collider.GetComponent<BaseProjectile>().damage);
            collision.collider.gameObject.transform.parent = gameObject.transform;
            if (health <= 0 && alive)
            {
                Die();
            }
        }
        else if (collision.collider.tag == "Weapon" && !CompareTag(collision.collider.GetComponent<BaseWeapon>().attacker))
        {
            TakeDamage(collision.collider.GetComponent<BaseWeapon>().damage);
            Debug.Log("sword oof");
            if (health <= 0 && alive)
            {
                Die();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
