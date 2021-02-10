using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject arrow;
    public GameObject spell;
    public bool isArcher=false;
    public bool isMage=false;
    public bool isFighter=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArcher && !isMage && !isFighter)
            Debug.Log("Choose a class!");
        //Vector3 attackPosition = new Vector3(attackPoint.transform.position.x, attackPoint.transform.position.y, attackPoint.transform.position.z);
        //int layerMask = 1 << 8;

        if (Input.GetMouseButtonDown(0)&&isArcher)
        {
            GameObject instance;
            instance = Instantiate(arrow, attackPoint.position,Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(attackPoint.up);
            instance.GetComponent<ArrowKill>().Setup(1, transform.tag);
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 500);
        }


        if(Input.GetMouseButtonDown(0)&&isMage)
        {
            GameObject instance;
            instance = Instantiate(spell, attackPoint.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(attackPoint.up);
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 3000);
            instance.GetComponent<ArrowKill>().Setup(1, transform.tag);
        }
    }
}
