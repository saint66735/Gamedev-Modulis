using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromHoldPlayer : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    float mass=0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()//100=0.1, 60=0.5, 30=1
    {
        if(mass>=100)
        {
            anim.speed = 0.1f;
        }
        else if(mass>=60)
        {
            anim.speed = 0.5f;
        }
        else if (mass>=30)
        {
            anim.speed = 0.75f;
        }
        else 
        {
            anim.speed = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!="Ground")
        {
            other.transform.parent = gameObject.transform;
            rb = other.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                mass += rb.mass;
            }
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Ground")
        {
            other.transform.parent = null;
            mass = 0;
            if (rb != null)
            {
                rb.velocity+=gameObject.GetComponent<Rigidbody>().velocity;
            }
        }
            
    }
}
