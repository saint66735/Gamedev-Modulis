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
    public bool found = false;

    private void Update() 
    {
        if(!found && GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            found = true;            
        }          
    }
}
