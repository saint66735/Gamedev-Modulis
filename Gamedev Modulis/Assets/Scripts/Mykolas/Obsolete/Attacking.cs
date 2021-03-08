using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject arrow;
    public GameObject spell;
    public GameObject sword;

    GameObject temp;
    public bool isArcher = false;
    public bool isMage = false;
    public bool isFighter = false;

    [SerializeField]
    float magicDamage = 50;
    [SerializeField]
    float arrowDamage = 50;
    [SerializeField]
    float swordDamage = 50;

    bool attacked = false;
    float attackDelay = 0;
    float currentDelay = 0;

    Animator swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        if (isFighter)
        {
            SetupFighter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked)
        {
            currentDelay += Time.deltaTime;
            if (currentDelay >= attackDelay)
            {
                currentDelay = 0;
                attacked = false;
            }
        }

        else if (Input.GetMouseButtonDown(0) && isArcher && !attacked)
        {
            GameObject instance;
            instance = Instantiate(arrow, attackPoint.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(attackPoint.up);
            instance.GetComponent<ArrowKill>().Setup(arrowDamage, transform.tag);
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 500);
            attacked = true;
        }

        else if (Input.GetMouseButtonDown(0) && isFighter && !attacked)
        {
            attacked = true;
            swordAnim.SetTrigger("Base_Attack");
        }

        else if (Input.GetMouseButtonDown(0) && isMage && !attacked)
        {
            GameObject instance;
            instance = Instantiate(spell, attackPoint.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.LookRotation(attackPoint.up);
            instance.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * 3000);
            instance.GetComponent<ArrowKill>().Setup(magicDamage, transform.tag);
            attacked = true;
        }
    }
    void SetupFighter()
    {
        Vector3 swordSpawnPoint = new Vector3(attackPoint.position.x + 0.4f, attackPoint.position.y, attackPoint.position.z + 0.5f);
        temp = Instantiate(sword, swordSpawnPoint, Quaternion.Euler(0, 0, 0), attackPoint);
        temp.GetComponent<ArrowKill>().Setup(swordDamage, transform.tag);
        swordAnim = temp.GetComponent<Animator>();
    }
}

