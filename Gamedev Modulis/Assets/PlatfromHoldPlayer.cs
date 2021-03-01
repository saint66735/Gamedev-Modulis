using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromHoldPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!="Ground")
            other.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Ground")
            other.transform.parent = null;
    }
}
