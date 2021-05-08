using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogClass dialogas;

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogManager>().StarDialogue(dialogas);

    }
}
