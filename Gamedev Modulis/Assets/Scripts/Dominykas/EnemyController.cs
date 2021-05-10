using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 15f;
    public float attackRange = 1f;
    NavMeshAgent agent;
    PlayerManager manager;
    bool playerLocated = false;

    public Enemy enemy;
    Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        
        manager = PlayerManager.FindObjectOfType<PlayerManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5;
        anima = GetComponentInChildren<Animator>();
        
    }

    IEnumerator WaitingXD(float distance)
    {
        
        yield return new WaitForSeconds(1);
        if(distance <= attackRange)
        {
            manager.player.GetComponent<Player>().TakeDamage(0.1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(!enemy.alive)
        {
            agent.enabled = false;
            GetComponent<Collider>().enabled = false;
            anima.Play("Death");
            Destroy(gameObject, 10);
        }
        else
        {
            float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        
            if(distance <= lookRadius)
            {
                anima.SetBool("PlayerDetected", true);
                agent.SetDestination(manager.player.transform.position);
            }
            else
            {
                anima.SetBool("PlayerDetected", false);
            }   

            if(distance <= attackRange)
            {
                agent.speed = 0;
                anima.SetBool("PlayerNear", true);  
                StartCoroutine(WaitingXD(distance));                 
            }
            else
            {
                agent.speed = 5f;
                anima.SetBool("PlayerNear", false);
            }
        }
        

        
                
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        
    }
}
