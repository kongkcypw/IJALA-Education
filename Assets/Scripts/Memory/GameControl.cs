using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    private void Awake()
    {
        token = GameObject.Find("Card");
    }

    void Start()
    {

        int originalLength = faceIndexes.Count;
        float yPosition = 125f;
        float xPosition = 0f;

        for (int i = 0; i < 11 ; i++)
        {
            shuffleNum = rnd.Next(0, (faceIndexes.Count));

            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, -20),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            temp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false); // set temp in canva scale

            faceIndexes.Remove(faceIndexes[shuffleNum]);

            if ( i == 1 || i == 4 || i== 7 )
            {
                xPosition = -102f;
                yPosition = yPosition - 115f;
            }
            else
            {
                xPosition = xPosition + 102;
            }

        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
    }


    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if(visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        return success;
    }


}
