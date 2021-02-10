using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public float health;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
