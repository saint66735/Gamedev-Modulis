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
        float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        if (distance < attackRange)
        {
            Player instance = manager.player.GetComponent<Player>();
            instance.TakeDamage(10f * instance.level * 1.5f);
        }
    }
}
