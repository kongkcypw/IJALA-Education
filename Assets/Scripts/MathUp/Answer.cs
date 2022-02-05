using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public Transform Q_Place;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public bool locked;

    MuScore score;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<MuScore>();
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - Q_Place.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - Q_Place.position.y) <= 0.5f)
        {
            transform.position = new Vector2(Q_Place.position.x, Q_Place.position.y - 0.05f);
            locked = true;
            score.AddScore();
            DestroyColider(); // this line for fix bug(add score repeat)
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    private void DestroyColider()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }
}
