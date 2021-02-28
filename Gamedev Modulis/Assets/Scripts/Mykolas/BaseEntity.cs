using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public float health;
    public bool alive = true;

    virtual public void TakeDamage(float damage)
    {
        health -= damage;
    }
    virtual public void Attack()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile" && !CompareTag(collision.collider.GetComponent<ArrowKill>().shooter))
        {
            TakeDamage(collision.collider.GetComponent<ArrowKill>().damage);
            collision.collider.gameObject.transform.parent = gameObject.transform;
            if (health <= 0 && alive)
            {
                Debug.Log("I'm dead");
                ScoreCounter.scoreValue++;
                alive = false;
            }
        }
        else if (collision.collider.tag == "Weapon" && !CompareTag(collision.collider.GetComponent<ArrowKill>().shooter))
        {
            TakeDamage(collision.collider.GetComponent<ArrowKill>().damage);
            if (health <= 0 && alive)
            {
                Debug.Log("I'm dead");
                ScoreCounter.scoreValue++;
                alive = false;
            }
        }
    }
}
