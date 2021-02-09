using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour
{
    public float lifetime = 2f;
    public bool isMagic = false;
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
        if(collision.gameObject.CompareTag(shooter))
        {
            return;
        }
        if (isMagic)
            Destroy(gameObject);
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            Destroy(gameObject, lifetime);
        }            
    }
}
