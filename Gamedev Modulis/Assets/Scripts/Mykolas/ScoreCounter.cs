using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Player player;
    Text score;
    bool found=false;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!found&& (Player)FindObjectOfType(typeof(Player)) != null)
        {
            player = FindObjectOfType<Player>();
        }
        score.text = "xp " + player.xp + "/" + player.xpReq;
    }
}
