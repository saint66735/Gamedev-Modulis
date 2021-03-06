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
    public AudioSource audio;

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

        if (isGrounded && controller.velocity.magnitude > 0.5f && audio.isPlaying == false)
        {
            if (controller.velocity.magnitude > 12f)
            {
                audio.volume = UnityEngine.Random.Range(0.8f, 1);
                audio.pitch = UnityEngine.Random.Range(1f, 1.5f);
            }
            else if (controller.velocity.magnitude < 7f)
            {
                audio.volume = UnityEngine.Random.Range(0.3f, 0.3f);
                audio.pitch = UnityEngine.Random.Range(0.8f, 0.6f);
            }
            else
            {
                audio.volume = UnityEngine.Random.Range(0.8f, 1);
                audio.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
            }
            audio.Play();
        }

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
            else if(Input.GetKey(KeyCode.Q))
            {
                speed = 50f;
            }
            else if (Input.GetKey(KeyCode.LeftControl)) //Sneky
            {
                speed = 5f;
            }
            else
            {
                speed = 10f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }
}
