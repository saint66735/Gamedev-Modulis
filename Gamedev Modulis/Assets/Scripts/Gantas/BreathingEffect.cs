using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingEffect : MonoBehaviour
{

    Vector3 startPos;
    public float amplitude = 10f;
    public float period = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.localPosition = startPos + Vector3.up * distance;
    }
}
