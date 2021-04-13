using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limb : MonoBehaviour
{
    [SerializeField]
    public GameObject bone;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.parent = null;
        bone.transform.parent = null;
        rb.isKinematic = false;
    }
}
