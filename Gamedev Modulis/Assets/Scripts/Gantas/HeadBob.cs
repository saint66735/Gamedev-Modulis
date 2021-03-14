using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour    
{
    

    //Breathing
    private bool isBreath = true;
    public float MinHigh = 0.8f;
    public float MaxHigh = 0.9f;

    //Walking
    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float midpoint = 1f;

    void Start()
    {

    }


    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            breathingBob();
        }

        else
        {
            walkingBob(horizontal, vertical);
        }
    }

    public void breathingBob() 
    {
        //Breathing
        if (isBreath)
        {
            midpoint = Mathf.Lerp(midpoint, MaxHigh, Time.deltaTime * 1f);
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint, transform.localPosition.z);
            if (midpoint >= MaxHigh - 0.01f)
            {
                isBreath = !isBreath;
            }

        }
        else
        {
            midpoint = Mathf.Lerp(midpoint, MinHigh, Time.deltaTime * 1f);
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint, transform.localPosition.z);
            if (midpoint <= MinHigh + 0.01f)
            {
                isBreath = !isBreath;
            }
        }
    }

    public void walkingBob(float horizontal, float vertical) 
    {
        float waveslice = 0.0f;

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }

        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }



}
