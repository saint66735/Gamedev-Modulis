using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float Sensitivity = 100;
    public GameObject Body;
    float xRot = 0;
    public float jumpSpeed = 100;
    bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot,-90f, 90f);

        float moveFw = Input.GetAxis("Vertical");
        float moveSide = Input.GetAxis("Horizontal");

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        //Vector3 dir = Body.transform.right * moveSide * speed + Body.transform.forward * moveFw * speed;
        Body.GetComponent<Rigidbody>().velocity = Body.transform.right*moveSide * speed + Body.transform.forward* moveFw*speed;
        //Body.GetComponent<Rigidbody>().AddForce(dir);


        Body.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            Body.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
            //Body.GetComponent<Rigidbody>().velocity += Body.transform.up*jumpSpeed;
        }
        if(!isGrounded)
        {
            Body.GetComponent<Rigidbody>().velocity -= new Vector3(0, 5, 0);
        }

    }
}
