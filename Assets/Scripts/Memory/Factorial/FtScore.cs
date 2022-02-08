using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FtScore : MonoBehaviour
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
        if (Score != maxScore && FtTimer.timeout == false)
        {
            Countdown -= Time.deltaTime;
        }
        else if (Score != maxScore && FtTimer.timeout == true)
        {
            ScoreBar.FtMemRemainingTime = 0;
            ScoreBar.FtMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && FtTimer.timeout == false)
        {
            ScoreBar.FtMemRemainingTime = Countdown;
            ScoreBar.FtMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && FtTimer.timeout == true)
        {
            ScoreBar.FtMemRemainingTime = 0;
            ScoreBar.FtMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }
    }
}
