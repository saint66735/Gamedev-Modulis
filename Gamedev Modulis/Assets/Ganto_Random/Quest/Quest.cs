using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    public bool isActive;
    public bool isCompleted = false;

    public string Pavadinimas;
    public string Aprasymas;
    public int ExpRewardas;
    public int reqToKill;

}
