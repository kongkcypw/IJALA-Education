using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DentedPixel;
public class Timer : MonoBehaviour
{
    public int time;
    public bool timeout =false;
    public GameObject Manager;

    void Start()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1); // set time bar to full when start
    } 

    void Update()
    {

        if(transform.localScale == new Vector3(1, 1, 1))
        {
            AnimateBar();
        }
        else if (transform.localScale == new Vector3(0, 1, 1))
        {
            timeout = true;
        }

        if(timeout == true)
        {
            Manager.GetComponent<Manager>().wrongAnswer();
        }
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(gameObject, 0, time);
    }

}
