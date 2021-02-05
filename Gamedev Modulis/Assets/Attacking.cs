using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject attackPoint;
    public GameObject projectile;
    public static bool isArcher=false;
    public static bool isMage=false;
    public static bool isFighter=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArcher && !isMage && !isFighter)
            Debug.Log("Choose a class!");
        Vector3 attackPosition = new Vector3(attackPoint.transform.position.x, attackPoint.transform.position.y, attackPoint.transform.position.z);
        //int layerMask = 1 << 8;

        if (Input.GetMouseButtonDown(0)&&isArcher)
        {
            GameObject instance;
            instance = Instantiate(projectile, attackPosition, Quaternion.Euler(attackPoint.transform.right));
            instance.transform.Rotate(attackPoint.transform.forward);
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 300);
        }


        if(Input.GetMouseButtonDown(0)&&isMage)
        {
            GameObject instance;
            instance = Instantiate(projectile, attackPosition, attackPoint.transform.rotation);
            instance.GetComponent<Rigidbody>().useGravity = false;
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 3000);
            instance.GetComponent<ArrowKill>().isMagic = true;
            /*RaycastHit hit;
            if(Physics.Raycast(attackPosition, attackPoint.transform.forward, out hit,Mathf.Infinity,layerMask))
            {
                Debug.DrawRay(attackPosition, transform.forward*hit.distance, Color.red);
                Debug.Log("Gottem");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }*/
        }
    }
}
