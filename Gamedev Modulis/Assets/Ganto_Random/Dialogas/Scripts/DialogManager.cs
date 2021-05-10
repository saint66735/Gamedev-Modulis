using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogScreen;
    public Text nameText;
    public Text DialogText;

    private Queue<string> sentences;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StarDialogue(DialogClass Dialogas)
    {

        //Debug.Log("Pradedam kalbeti su " + Dialogas.name);
        nameText.text = Dialogas.name;

        sentences.Clear();

        foreach (string sakinys in Dialogas.sentences)
        {
            sentences.Enqueue(sakinys);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {

            EndDialogue();
            return;

        }

        string sentence = sentences.Dequeue();

        //Debug.Log(sentence);
        DialogText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSystem(sentence));

        //Radziu rodymas po viena;
        IEnumerator TypeSystem(string sentence)
        {
            DialogText.text = "";
            foreach (var raide in sentence.ToCharArray())
            {
                DialogText.text += raide;
                yield return null;
            }
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of convo");
        dialogScreen.SetActive(false);
    }
}
