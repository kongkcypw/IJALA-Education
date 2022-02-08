using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class McNormalScore : MonoBehaviour
{
    public GameObject ScoreObj;
    public TextMeshProUGUI scoreText;
    private int Score = 0;

    NormalManager manage;

    public bool SendScore=false;

    void Start()
    {
        manage = GameObject.FindGameObjectWithTag("GameController").GetComponent<NormalManager>();
        scoreText.text = "Score " + Score.ToString();
    }

    public void AddScore()
    {
        Score += 1;
        scoreText.text = "Score " + Score.ToString();
    }

    private void Update()
    {
        if(manage.EndCheck == true && SendScore == false)
        {
            ScoreBar.McNormal_CurrentScore = Score;
            SendScore = true;
        }
    }
}
