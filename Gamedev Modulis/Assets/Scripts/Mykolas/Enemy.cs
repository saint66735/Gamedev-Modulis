using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity
{
    Rigidbody rb;
    [SerializeField]
    int xpValue = 10;
    Player player;
    [SerializeField]
    bool playerLocated = false;
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
        health = 100 * player.level * 0.7f;
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
    }
}
