using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseLight : MonoBehaviour
{
    public float rotSpeed = 10;
    void Update()
    {
        
        transform.Rotate(0,rotSpeed*Time.deltaTime,0);   
    }
}
