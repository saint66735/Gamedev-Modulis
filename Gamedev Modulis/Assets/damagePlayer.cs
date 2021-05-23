using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{

    public float attackRange = 2f;

    PlayerManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = PlayerManager.FindObjectOfType<PlayerManager>();        
    }


    public void EndAttack()
    {       
        Debug.Log("MegaYikes");
        float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        if(distance < attackRange)
        {
            manager.player.GetComponent<Player>().TakeDamage(10f);
        }
    }
}
