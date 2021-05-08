using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    NavMeshAgent agent;

    PlayerManager manager;


    bool playerLocated = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = PlayerManager.FindObjectOfType<PlayerManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(manager.player.transform.position);
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        
    }
}
