using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public Text text;
    bool canInteract = false;

    public DialogTrigger trigger;
    DialogManager manager;
    GameObject DialogueBox;
    bool JauDisplay = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        DialogueBox = GameObject.Find("DialogBox");
        DialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Debug.Log("I'm talking!");

            trigger.TriggerDialogue();
            DialogueBox.SetActive(true);
                if (JauDisplay)
                {
                    manager.DisplayNextSentence();
                }
            JauDisplay = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
            canInteract = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = false;
            canInteract = false;

            DialogueBox.SetActive(false);
            JauDisplay = false;

        }
    }
}
