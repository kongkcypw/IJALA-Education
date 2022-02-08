using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    public float TimeStart;
    public TextMeshProUGUI timeText;

    
    void Update()
    {
        if(MUTimer.timeout == false)
        {
            TimeStart -= Time.deltaTime;
            timeText.text = TimeStart.ToString("F1");
        }
    }
}
