using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 100f;
    bool belowZero = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100)
            Destroy(gameObject);
    }
    private void TakeDamage(float dmg)
    {
        health -= dmg;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            TakeDamage(collision.collider.GetComponent<ArrowKill>().damage);
            collision.collider.gameObject.transform.parent = gameObject.transform;
            if(health<=0&&!belowZero)
            {
                Debug.Log("I'm dead");
                //Destroy(gameObject, 3);
                ScoreCounter.scoreValue++;
                belowZero = true;
            }            
        }
    }
}
