using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtMainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    FtScore score;


    public void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<FtScore>();
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (spriteRenderer.sprite == back)
            {
                if (gameControl.GetComponent<FtGameControl>().TwoCardsUp() == false)
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    gameControl.GetComponent<FtGameControl>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<FtGameControl>().CheckMatch();
                    if (matched == true)
                    {
                        score.AddScore();
                    }
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                gameControl.GetComponent<FtGameControl>().RemoveVisibleFace(faceIndex);
            }
        }
    }


    private void DestroyColider()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }
}
