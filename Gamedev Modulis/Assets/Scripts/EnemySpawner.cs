using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemies;
    bool spawned;
    private void OnTriggerEnter(Collider other)
    {
        if(!spawned&&other.CompareTag("Player"))
        {
            enemies.SetActive(true);
            spawned = true;
        }
    }
}
