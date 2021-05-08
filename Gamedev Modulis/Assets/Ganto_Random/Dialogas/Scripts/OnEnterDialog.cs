using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterDialog : MonoBehaviour
{
    
    bool JeiViduj;
    public DialogTrigger trigger;
    GameObject DialogueBox;

    void Start()
    {
        JeiViduj = false;
        DialogueBox = GameObject.Find("DialogBox");
        DialogueBox.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.TriggerDialogue();
            DialogueBox.SetActive(true);
        }


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueBox.SetActive(false);
        }
    }


}
