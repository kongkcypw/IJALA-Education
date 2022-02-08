using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject MatchUp;
    public GameObject MultipleChoices;
    public GameObject Memory;

    public void Start()
    {
        MatchUp.SetActive(false);
        MultipleChoices.SetActive(false);
        Memory.SetActive(false);
    }

    public void ShowMatchUp()
    {
        MatchUp.SetActive(true);
        MultipleChoices.SetActive(false);
        Memory.SetActive(false);
    }

    public void ShowMultipleChoices()
    {
        MatchUp.SetActive(false);
        MultipleChoices.SetActive(true);
        Memory.SetActive(false);
    }

    public void ShowMemory()
    {
        MatchUp.SetActive(false);
        MultipleChoices.SetActive(false);
        Memory.SetActive(true);
    }
}
