using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Rotation : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.forward = 
            Vector3.Slerp(gameObject.transform.forward, gameObject.GetComponent<Rigidbody>().velocity, Time.deltaTime);        
    }
}
