using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_Controller : MonoBehaviour
{
    //rotation
    public static float mouseSens=40;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens * 3 * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens * 3 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
