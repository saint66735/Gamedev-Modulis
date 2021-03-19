using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    public GameObject hitExplosion;
    Vector3 pos;

     void Start()
    {
            pos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
            GameObject instance = Instantiate(hitExplosion, pos, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }



}
