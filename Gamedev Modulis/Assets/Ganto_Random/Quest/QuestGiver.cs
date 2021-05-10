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

    public GameObject enemys;

    public Text Pavadinimas;
    public Text Aprasymas;
    public Text ExpRewardas;

    bool found = false;

    public static int killCount;


    private void Start()
    {
        //player = menuScript.playerScript;
        killCount = 0;
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

        
        if (killCount >= quest.reqToKill && (quest.isCompleted == false)) 
        {

            CompleteQuest();

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
        quest.isCompleted = false;
        player.quest = quest;

        enemys.SetActive(true);


    
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    public void CompleteQuest()
    {
        quest.isCompleted = true;
        quest.isActive = false;
        player.IncreaseXp(quest.ExpRewardas);

    }
}
