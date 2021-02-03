using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Valdymas1 : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rb;
    public float Sensitivity = 100;
    public GameObject Body;
    float xRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = Body.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        //
        float xAJud = Input.GetAxis("Horizontal"); // Ajud - Ašies judėjimas
        float zAJud = Input.GetAxis("Vertical");

        // Velocity duoda pastumima (jega) ir nustatau palei kurias asis valdysiu. Time.deltaTime 
        //rb.velocity = new Vector3(xAJud * speed, rb.velocity.y, zAJud * speed);
        Body.GetComponent<Rigidbody>().velocity = Body.transform.right * xAJud * speed + Body.transform.forward * zAJud * speed;
        //

        Body.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //
    }
}
