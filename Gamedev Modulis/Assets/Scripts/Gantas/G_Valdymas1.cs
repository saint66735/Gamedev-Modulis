using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Valdymas1 : MonoBehaviour
{
    public float speed = 3000f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAJud = Input.GetAxis("Horizontal"); // Ajud - Ašies judėjimas
        float zAJud = Input.GetAxis("Vertical");

        // Velocity duoda pastumima (jega) ir nustatau palei kurias asis valdysiu. Time.deltaTime 
        rb.velocity = new Vector3(xAJud * speed, rb.velocity.y, zAJud * speed) * Time.deltaTime;
    }
}
