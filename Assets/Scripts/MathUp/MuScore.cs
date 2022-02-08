using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuScore : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject EndScreen;
    public TextMeshProUGUI scoreText;
    public int Score = 0;
    public int maxScore;

    public void AddScore()
    {
        Score += 1;
        scoreText.text = "Score " + Score.ToString();
    }

    void Start()
    {
        scoreText.text = "Score " + Score.ToString();
    }

    public void Update()
    {
        if(Score == maxScore || MUTimer.timeout == true)
        {
            StartScreen.SetActive(false);
            EndScreen.SetActive(true);
        }
    }

}
