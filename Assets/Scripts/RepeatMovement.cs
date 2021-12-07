using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMovement : MonoBehaviour
{
    private float repeatWidth;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        ResetPosition();
    }

    // Reset position after it goes off the screen

    private void ResetPosition()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
