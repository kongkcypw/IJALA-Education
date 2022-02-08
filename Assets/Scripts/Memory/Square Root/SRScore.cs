using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SRScore : MonoBehaviour
{
    public GameObject Card;
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
        if (Score != maxScore && SRTimer.timeout == false)
        {
            Countdown -= Time.deltaTime;
        }
        else if (Score != maxScore && SRTimer.timeout == true)
        {
            ScoreBar.SRMemRemainingTime = 0;
            ScoreBar.SRMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && SRTimer.timeout == false)
        {
            ScoreBar.SRMemRemainingTime = Countdown;
            ScoreBar.SRMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && SRTimer.timeout == true)
        {
            ScoreBar.SRMemRemainingTime = 0;
            ScoreBar.SRMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }
    }
}
