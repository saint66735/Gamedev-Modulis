using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    Player player;

    public MenuScript menuScript;

    public GameObject questWindow;

    public Text Pavadinimas;
    public Text Aprasymas;
    public Text ExpRewardas;

    bool found = false;


    private void Start()
    {
        //player = menuScript.playerScript;
    }

    private void Update()
    {
        if (!found)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                found = true;
            }
        }
    }


    public void OpenQuestWindow() 
    {
        questWindow.SetActive(true);

        Pavadinimas.text = quest.Pavadinimas;
        Aprasymas.text = quest.Aprasymas;
        ExpRewardas.text = quest.ExpRewardas.ToString();
    }

    public void AcceptQuest() 
    {

        CloseQuestWindow();
        quest.isActive = true;
        player.quest = quest;

    
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }
}
