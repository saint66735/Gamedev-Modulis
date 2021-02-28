using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity
{
    Rigidbody rb;
    // Start is called before the first frame update
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
        rb.AddForce(0, 0.5f, 0);
    }
    
}
