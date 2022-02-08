﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyManager : MonoBehaviour
{

    public GameObject[] Levels;
    public GameObject End;
    int currentLevel=0;

    public bool EndCheck=false;

    McEasyScore score;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<McEasyScore>();
    }


    public void CheckLevel()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            EndCheck = true;
            End.SetActive(true);
            Levels[currentLevel].SetActive(false);
        }
    }

    public void wrongAnswer()
    {
        CheckLevel();
    }

    [System.Obsolete]
    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void correctAnswer()
    {
        score.AddScore();
        CheckLevel();
    }




}
