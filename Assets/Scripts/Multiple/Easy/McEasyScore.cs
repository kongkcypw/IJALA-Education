using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class McEasyScore : MonoBehaviour
{
    public GameObject ScoreObj;
    public TextMeshProUGUI scoreText;
    private int Score = 0;

    EasyManager manage;

    public bool SendScore=false;

    void Start()
    {
        manage = GameObject.FindGameObjectWithTag("GameController").GetComponent<EasyManager>();
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
            ScoreBar.McEasy_CurrentScore = Score;
            SendScore = true;
        }
    }
}
