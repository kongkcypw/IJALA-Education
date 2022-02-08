using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class McHardScore : MonoBehaviour
{
    public GameObject ScoreObj;
    public TextMeshProUGUI scoreText;
    private int Score = 0;

    HardManager manage;

    public bool SendScore=false;

    void Start()
    {
        manage = GameObject.FindGameObjectWithTag("GameController").GetComponent<HardManager>();
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
            ScoreBar.McHard_CurrentScore = Score;
            SendScore = true;
        }
    }
}
