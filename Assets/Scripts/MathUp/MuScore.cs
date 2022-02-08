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

    public float Countdown;

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
        if (Score != maxScore && MUTimer.timeout == false )
        {
            Countdown -= Time.deltaTime;
        }

        else if (Score != maxScore && MUTimer.timeout == true)
        {
            ScoreBar.MuRemainingTime = 0;
            ScoreBar.MuScore = Score;
            StartScreen.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && MUTimer.timeout == false)
        {
            ScoreBar.MuRemainingTime = Countdown;
            ScoreBar.MuScore = Score;
            StartScreen.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore || MUTimer.timeout == true)
        {
            ScoreBar.MuRemainingTime = 0;
            ScoreBar.MuScore = Score;
            StartScreen.SetActive(false);
            EndScreen.SetActive(true);
        }
    }

}
