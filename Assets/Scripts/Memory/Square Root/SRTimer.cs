using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class SRTimer : MonoBehaviour
{
    public int time;
    public static bool timeout = false;

    void Start()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1); // set time bar to full when start
    }

    void Update()
    {

        if (transform.localScale == new Vector3(1, 1, 1))
        {
            AnimateBar();
        }
        else if (transform.localScale == new Vector3(0, 1, 1))
        {
            timeout = true;
        }

    }

    public void AnimateBar()
    {
        LeanTween.scaleX(gameObject, 0, time);
    }
}
