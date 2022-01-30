using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class McScore : MonoBehaviour
{
    public GameObject LastScoreObj;
    public Text LastScoreText;

    public GameObject ScoreObj;
    public Text scoreText;
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
            LastScoreText.text = "Score " + Score.ToString();
            ScoreObj.SetActive(false);
            LastScoreObj.SetActive(true);
        }
    }

    public void AddScore()
    {
        Score += 1;
        scoreText.text = "Score " + Score.ToString();
    }
}
