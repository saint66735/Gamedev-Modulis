using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement01 : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity = -9.81f;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        if (controller == null)
            Debug.Log("No character controller");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (controller.isGrounded || isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 15f;
            }
            else
            {
                speed = 10f;
            }
        }

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
