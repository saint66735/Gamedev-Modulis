using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject player;

    public PlayerMovement01 movement;
    public bool found = false;

    private void Start() 
    {

    }

    private void Update() 
    {
        if(!found && GameObject.FindGameObjectWithTag("Player") != null)
        {
            movement = FindObjectOfType<PlayerMovement01>();
            player = GameObject.FindGameObjectWithTag("Player");
            found = true;

        }          
    }
}
