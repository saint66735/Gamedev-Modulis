using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterHeal : MonoBehaviour
{

    Player player;
    bool found = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!found && FindObjectOfType<Player>() != null)
        {
            player = FindObjectOfType<Player>();
            if (player != null)
            {
                found = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player) 
        {
            if (player.health == player.maxHealth)
            {
                Debug.Log("FullHp");
            }
            else
            {
                StartCoroutine("Heal");
                Debug.Log("Healina");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
                StopCoroutine("Heal");
                Debug.Log("Nebe Healina");          
        }
    }

    IEnumerator Heal() 
    {
        for(float currentHealth =  player.health; currentHealth<= 100; currentHealth += 0.05f)
        {
            player.health = currentHealth;
            yield return new WaitForSeconds(Time.deltaTime);     
        }

        player.health = 100f;
    
    
    
    }




}
