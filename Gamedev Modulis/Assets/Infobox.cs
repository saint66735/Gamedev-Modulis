using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infobox : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(TurnOff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
