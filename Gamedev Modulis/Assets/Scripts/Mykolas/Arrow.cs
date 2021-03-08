using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : BaseProjectile
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.forward =
            Vector3.Slerp(gameObject.transform.forward, gameObject.GetComponent<Rigidbody>().velocity, Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shooter) || collision.gameObject.CompareTag("Projectile"))
        {
            return;
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rb.isKinematic = true;        
        gameObject.GetComponent<Collider>().enabled = false;
        //Destroy(gameObject, lifetime);
        Debug.Log("Im an arrow");
    }
}
