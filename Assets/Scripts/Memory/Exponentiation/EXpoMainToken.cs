using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXpoMainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    EXpoScore score;


    public void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<EXpoScore>();
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (spriteRenderer.sprite == back)
            {
                if (gameControl.GetComponent<EXpoGameControl>().TwoCardsUp() == false)
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    gameControl.GetComponent<EXpoGameControl>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<EXpoGameControl>().CheckMatch();
                    if (matched == true)
                    {
                        score.AddScore();
                    }
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                gameControl.GetComponent<EXpoGameControl>().RemoveVisibleFace(faceIndex);
            }
        }
    }


    private void DestroyColider()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }
}
