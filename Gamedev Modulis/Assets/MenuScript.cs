using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectArcher()
    {
        Attacking.isArcher = true;
        Attacking.isFighter = false;
        Attacking.isMage = false;
        Debug.Log("I chose A");
    }
    public void SelectFighter()
    {
        Attacking.isArcher = false;
        Attacking.isFighter = true;
        Attacking.isMage = false;
        Debug.Log("I chose F");
    }
    public void SelectMage()
    {
        Attacking.isArcher = false;
        Attacking.isFighter = false;
        Attacking.isMage = true;
        Debug.Log("I chose M");
    }
}
