using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour
{
    public float lifetime = 2f;
    public bool isMagic = false;
    public GameObject hitExplosion;
    string shooter;
    float damage;
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
            //GameObject instance = Instantiate(hitExplosion,collision.);
            //Destroy(instance, lifetime);
            Destroy(gameObject);
        }            
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            Destroy(gameObject, lifetime);
        }            
    }
}
