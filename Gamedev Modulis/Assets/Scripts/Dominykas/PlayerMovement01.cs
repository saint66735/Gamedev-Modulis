using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseMovement : MonoBehaviour
{
    public UnityEvent<float> onGroundHit;

    public CharacterController controller;

    public float speed;
    public float gravity = -9.81f * 2;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    [SerializeField]
    Rigidbody rb;

    protected bool isGrounded;
    protected Vector3 velocity;
    public bool canMove;

    private void CheckIfIsGrounded()
    {
        bool isNewGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (!isGrounded && isNewGrounded)
        {
            onGroundHit.Invoke(velocity.y);
        }
        isGrounded = isNewGrounded;
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        float xAxis, zAxis;
        HandleInput(out xAxis, out zAxis);

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;
        controller.Move(move * speed * Time.deltaTime);

        CheckIfIsGrounded();
        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }

        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        rb.velocity = new Vector3(0, velocity.y, 0);
        controller.Move(velocity * Time.deltaTime);
    }

    public virtual void HandleInput(out float xAxis, out float zAxis)
    {
        throw new NotImplementedException();
    }
}


public class PlayerMovement01 : BaseMovement
{
    public override void HandleInput(out float xAxis, out float zAxis)
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
}
