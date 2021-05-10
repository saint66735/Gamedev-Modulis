using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fovText : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "Field of View " + slider.value;
    }
}
