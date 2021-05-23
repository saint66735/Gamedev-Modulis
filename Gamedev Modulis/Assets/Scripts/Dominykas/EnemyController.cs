using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 15f;
    public float attackRange = 2f;
    NavMeshAgent agent;
    PlayerManager manager;
    bool playerLocated = false;

    public Enemy enemy;
    Animator anima;

    public float hearRadius = 45f;

    public float minSpeed;
    public bool canHear;

    public GameObject safePoint;

    // Start is called before the first frame update
    void Start()
    {
        
        manager = PlayerManager.FindObjectOfType<PlayerManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5;
        anima = GetComponentInChildren<Animator>();
        
        
        
    }

    // IEnumerator WaitingXD(float distance)
    // {
        
    //     yield return new WaitForSeconds(1);
    //     if(distance <= attackRange)
    //     {
    //         manager.player.GetComponent<Player>().TakeDamage(0.1f);
            
    //     }

    // }

    // Update is called once per frame
    void Update()
    {
        //minSpeed = manager.movement.controller.velocity.magnitude;
        minSpeed = manager.movement.speed;
        if(!enemy.alive)
        {
            agent.enabled = false;
            GetComponent<Collider>().enabled = false;
            anima.Play("Death");
            Destroy(gameObject, 10);
        }
        else if(enemy.health <= enemy.maxHealth/2)
        {
            transform.LookAt(manager.player.transform);
            Vector3 away = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)*-1;
            transform.rotation = Quaternion.Euler(away);            
            Vector3 run = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            if(transform.position.x>manager.player.transform.position.x)
            {
                run += new Vector3(10, 0, 0);
            }
            else if (transform.position.x < manager.player.transform.position.x)
            {
                run += new Vector3(-10, 0, 0);
            }
            else if (transform.position.z < manager.player.transform.position.z)
            {
                run += new Vector3(0, 0, -10);
            }
            else if (transform.position.z > manager.player.transform.position.z)
            {
                run += new Vector3(0, 0, 10);
            }
            anima.SetBool("PlayerDetected", true);
            agent.SetDestination(run);
        }
        else
        {
            float distance = Vector3.Distance(manager.player.transform.position, transform.position);

            if(distance <= hearRadius && minSpeed > 5f)
            {
                anima.SetBool("DetectionRange", true);
                canHear = true;
                agent.speed = 10f;
                agent.SetDestination(manager.player.transform.position);
            }
            else
            {
                anima.SetBool("DetectionRange", false);
            }
        
            if(distance <= lookRadius)
            {
                anima.SetBool("ChaseRange", true);   
                agent.SetDestination(manager.player.transform.position);            
            }
            else
            {
                anima.SetBool("ChaseRange", false);
            }   

            if(distance <= attackRange)
            {
                agent.speed = 0;
                anima.SetBool("AttackRange", true);  
                                 
            }
            else
            {
                agent.speed = 5f;
                anima.SetBool("AttackRange", false);
            }
        }
        

        
                
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hearRadius);
        
    }
}
