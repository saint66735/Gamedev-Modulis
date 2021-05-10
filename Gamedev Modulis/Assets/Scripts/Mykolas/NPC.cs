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
    public GameObject DialogueBox;
    bool JauDisplayDialogas = false;

    public QuestGiver questGiver;
    bool JauDisplayQuest = false;

    bool playerLocated = false;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        //if (DialogueBox == null)
        //{
            //DialogueBox = GameObject.FindGameObjectWithTag("DialogBox");
        //}
        DialogueBox.SetActive(false);
        questGiver.CloseQuestWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Debug.Log("I'm talking!");

            if (JauDisplayDialogas == false)
            {
                trigger.TriggerDialogue();
                DialogueBox.SetActive(true);
            }

            if (JauDisplayDialogas)
            {
                Debug.Log("2nd time!");
                manager.DisplayNextSentence();

            }

            JauDisplayDialogas = true;
        }


        if (Input.GetKeyDown(KeyCode.Q) && canInteract)
        {
            if (JauDisplayQuest == false)
            {
                questGiver.OpenQuestWindow();
                JauDisplayQuest = true;
            }
            else if (JauDisplayQuest == true)
            {
                questGiver.CloseQuestWindow();
                JauDisplayQuest = false;
            }
        }

        if (!playerLocated && (Player)FindObjectOfType(typeof(Player)) != null) {

            if (Input.GetKeyDown(KeyCode.R) && canInteract)
            {
                questGiver.AcceptQuest();
            }

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
            JauDisplayDialogas = false;

            questGiver.CloseQuestWindow();
        }
    }
}
