using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity
{
    [SerializeField]
    int xpValue = 10;
    Player player;
    [SerializeField]
    bool playerLocated = false;
    public List<Rigidbody> rigidbodies;
    void Start()
    {
        //Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerLocated && (Player)FindObjectOfType(typeof(Player)) != null)
            Setup();
        if (transform.position.y < -100)
            Destroy(gameObject);
    }
    void Setup()
    {
        player = (Player)FindObjectOfType(typeof(Player));
        maxHealth = 100 * player.level * 0.7f;
        health = maxHealth;
        rb = gameObject.GetComponent<Rigidbody>();
        xpValue = (int)player.level * 10;        
        playerLocated = true;
    }

    public override void Die()
    {
        rb.isKinematic = false;
        Debug.Log("I'm dead");
        ScoreCounter.scoreValue++;
        player.IncreaseXp(xpValue);
        alive = false;
        foreach (Rigidbody rbi in rigidbodies)
            rbi.isKinematic = false;
    }
}
