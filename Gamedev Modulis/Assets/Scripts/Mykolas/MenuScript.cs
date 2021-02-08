using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public Camera menuCamera;
    public GameObject buttons;
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
        GameObject instance = Instantiate(player, spawnPoint);
        instance.GetComponent<Attacking>().isArcher = true;
        instance.GetComponent<Attacking>().isFighter = false;
        instance.GetComponent<Attacking>().isMage = false;
        Debug.Log("I chose A");
        menuCamera.enabled = false;
        buttons.SetActive(false);
    }
    public void SelectFighter()
    {
        GameObject instance = Instantiate(player, spawnPoint);
        instance.GetComponent<Attacking>().isArcher = false;
        instance.GetComponent<Attacking>().isFighter = true;
        instance.GetComponent<Attacking>().isMage = false;
        menuCamera.enabled = false;
        buttons.SetActive(false);
        Debug.Log("I chose F");
    }
    public void SelectMage()
    {
        GameObject instance = Instantiate(player, spawnPoint);
        instance.GetComponent<Attacking>().isArcher = false;
        instance.GetComponent<Attacking>().isFighter = false;
        instance.GetComponent<Attacking>().isMage = true;
        menuCamera.enabled = false;
        buttons.SetActive(false);
        Debug.Log("I chose M");
    }
}
