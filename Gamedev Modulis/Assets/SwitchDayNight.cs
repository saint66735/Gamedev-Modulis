using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchDayNight : MonoBehaviour
{
    public Material day;
    public Material night;
    bool canInteract;
    public Text text;
    public Light sun;
    float sunIntensity;
    float nightIntensity = 0.34f;
    public GameObject sleepyobject;
    public Animator Sleepy;
    void Start()
    {
        sunIntensity = sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("SwitchSky");
                //SwitchSky();
            }
        }
    }

    IEnumerator SwitchSky()
    {
        sleepyobject.SetActive(true);
        Sleepy.SetTrigger("Start");
        if (RenderSettings.skybox == day)
        {
            yield return new WaitForSeconds(2);
            RenderSettings.skybox = night;
            //Mathf.Lerp(sun.intensity, nightIntensity, 1*Time.deltaTime);
            sun.intensity = nightIntensity;
        }
        else
        {
            yield return new WaitForSeconds(2);
            RenderSettings.skybox = day;
            sun.intensity = sunIntensity;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = false;
            canInteract = false;
        }
            
    }
}
