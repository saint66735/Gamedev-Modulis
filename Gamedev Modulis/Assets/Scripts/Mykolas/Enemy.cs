using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity
{
    Rigidbody rb;
    void Start()
    {
        health = 100;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100)
            Destroy(gameObject);      
        
    }

    public override void Die()
    {
        rb.isKinematic = false;
        Debug.Log("I'm dead");
        ScoreCounter.scoreValue++;
        alive = false;
    }
}
