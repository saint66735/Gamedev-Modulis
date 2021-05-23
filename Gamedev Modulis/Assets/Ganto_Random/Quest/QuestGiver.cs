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
    public GameObject questCompletedWindow;

    public GameObject enemys;

    public Text Pavadinimas;
    public Text Aprasymas;
    public Text ExpRewardas;

    public Text PavadinimasCompelted;
    public Text ExpCompeltedRewardas;

    bool found = false;

    public Animator QuestCompletedAnimator;

    public static int killCount;

    int destroyTime  = 8;


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

        
        if (player.count == quest.reqToKill && (quest.isActive == true)) 
        {

            CompleteQuest();
            CompleteShowQuest();

        }
    }


    public void OpenQuestWindow() 
    {
        questWindow.SetActive(true);

        Pavadinimas.text = quest.Pavadinimas;
        Aprasymas.text = quest.Aprasymas;
        ExpRewardas.text = quest.ExpRewardas.ToString();

        PavadinimasCompelted.text = quest.Pavadinimas;
        ExpCompeltedRewardas.text = quest.ExpRewardas.ToString();
    }

    public void AcceptQuest() 
    {

        CloseQuestWindow();
        quest.isActive = true;
        quest.isCompleted = false;
        player.quest = quest;
        enemys.SetActive(true);
        player.killCountReset();
        //player.count = 0;




    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    public void CompleteQuest()
    {
        quest.isCompleted = true;
        quest.isActive = false;
        player.killCountReset();
        player.count = 0;
        player.IncreaseXp(quest.ExpRewardas);

    }


    public void CompleteShowQuest()
    {


        questCompletedWindow.SetActive(true);
        QuestCompletedAnimator.SetTrigger("IsOpen");

        //StartCoroutine(Coroutine());

    }

    //IEnumerator Coroutine()
    //{
    //    yield return new WaitForSeconds(8);
    //    questCompletedWindow.SetActive(false);
    //}
}
