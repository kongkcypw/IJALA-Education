using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class McScore : MonoBehaviour
{

    public GameObject ScoreObj;
    public TextMeshProUGUI scoreText;
    private int Score = 0;

    Manager manage;

    void Start()
    {
        manage = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        scoreText.text = "Score " + Score.ToString();
    }

    private void Update()
    {
        if(manage.EndCheck == true)
        {
            // Show total Score
        }
    }

    public void AddScore()
    {
        Score += 1;
        scoreText.text = "Score " + Score.ToString();
    }
}
