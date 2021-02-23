using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour
{
    public float lifetime = 2f;
    public bool isMagic = false;
    public GameObject hitExplosion;
    string shooter;
    public float damage;
    // Start is called before the first frame update
    internal void Setup(float damage,string shooter)
    {
        this.damage = damage;
        this.shooter = shooter;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagic)
            Destroy(gameObject, lifetime * 3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(shooter)||collision.gameObject.CompareTag("Projectile"))
        {
            return;
        }
        if (isMagic)
        {
            ContactPoint explosionLocation = collision.GetContact(0);
            Vector3 pos = explosionLocation.point;
            GameObject instance = Instantiate(hitExplosion,pos,Quaternion.Euler(0,0,0));
            Destroy(instance, lifetime);
            Destroy(gameObject);
        }            
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject, lifetime);
        }            
    }
}
