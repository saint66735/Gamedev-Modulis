using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_Controller : MonoBehaviour
{
    //rotation
    public float mouseSens = 40;
    public Transform playerBody;
    float xRotation = 0f;
    float mouseY;
    float mouseX;

    public bool canLook;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canLook = true;
    }

    void Update()
    {
        if (!canLook)
        {
            return;
        }
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSens * 4 * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens * 4 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
