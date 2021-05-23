using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnTriggerDestroy : MonoBehaviour
{
    public GameObject hitExplosion;
    Vector3 pos;
    public GameObject infobox;
    public string message;
    Text text;

    public Animator InfoSignAnimator;

    void Start()
    {
        pos = gameObject.transform.position;
        text = infobox.GetComponentInChildren<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            infobox.SetActive(true);
            text.text = message;
            InfoSignAnimator.SetTrigger("IsOpen");
            GameObject instance = Instantiate(hitExplosion, pos, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }
}
