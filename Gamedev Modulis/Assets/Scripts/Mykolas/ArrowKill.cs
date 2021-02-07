using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour
{
    public float lifetime = 2f;
    public bool isMagic = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagic)
            Destroy(gameObject, lifetime * 3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isMagic)
            Destroy(gameObject);
        else
            Destroy(gameObject, lifetime);
    }
}
