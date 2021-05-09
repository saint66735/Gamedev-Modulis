using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public Slider sensSlider;
    Text sensCount;
    // Start is called before the first frame update
    void Start()
    {
        sensCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sensCount.text = "Sensitivity: " + sensSlider.value.ToString();
    }

}
