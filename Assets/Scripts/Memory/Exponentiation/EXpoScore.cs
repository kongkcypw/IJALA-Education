using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXpoScore : MonoBehaviour
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
        if (Score != maxScore && EXpoTimer.timeout == false)
        {
            Countdown -= Time.deltaTime;
        }
        else if (Score != maxScore && EXpoTimer.timeout == true)
        {
            ScoreBar.EXpoMemRemainingTime = 0;
            ScoreBar.ExpoMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && EXpoTimer.timeout == false)
        {
            ScoreBar.EXpoMemRemainingTime = Countdown;
            ScoreBar.ExpoMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }

        else if (Score == maxScore && EXpoTimer.timeout == true)
        {
            ScoreBar.EXpoMemRemainingTime = 0;
            ScoreBar.ExpoMemScore = Score;
            Card.SetActive(false);
            EndScreen.SetActive(true);
        }
    }
}
