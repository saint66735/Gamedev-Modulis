using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_valdymas1_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public float Sensitivity = 100;
    public GameObject Body;
    Rigidbody rb;
    float xRot = 0;

    // Jumping
    public float jumpForce = 100;
    bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    bool isjumping;
    // taisymas rb.veloc
    private Vector3 jumping;
    public float dragCoficientas = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = Body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        float moveFw = Input.GetAxis("Vertical");
        float moveSide = Input.GetAxis("Horizontal");

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (rb.velocity.magnitude < 5)
            {
                rb.velocity += Body.transform.right * moveSide * speed + Body.transform.forward * moveFw * speed;
            }
        }

        if(!Input.GetButton("Horizontal")  || !Input.GetButton("Vertical"))
        {
            if (rb.velocity.magnitude >= 0.5 && isGrounded == true)
            {
                rb.velocity -= (Body.transform.right * moveSide * speed + Body.transform.forward * moveFw * speed) * 0.01f;
            }
        }



        Body.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        if (Input.GetButton("Jump") && isGrounded)
        {
            jump();
            isjumping = true;
        }
        else { 
            
            isjumping = false;


        }

        if (!isGrounded)
        {
            jumping = new Vector3(0, -5, 0);
        }



        //Vector3 curVel = rb.velocity;
        //Vector3 xzVel = new Vector3(curVel.x, 0, curVel.z);
        //rb.velocity -= xzVel * dragCoficientas;

    }

    private void jump()
    {
        isGrounded = false;
        rb.AddForce(Vector3.up * jumpForce);
    }

    void FixedUpdate()
    {


    }

    
}
