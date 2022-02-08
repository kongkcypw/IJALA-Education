using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRMainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    SRScore score;


    public void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<SRScore>();
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (spriteRenderer.sprite == back)
            {
                if (gameControl.GetComponent<SRGameControl>().TwoCardsUp() == false)
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    gameControl.GetComponent<SRGameControl>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<SRGameControl>().CheckMatch();
                    if (matched == true)
                    {
                        score.AddScore();
                    }
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                gameControl.GetComponent<SRGameControl>().RemoveVisibleFace(faceIndex);
            }
        }
    }


    private void DestroyColider()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }
}
