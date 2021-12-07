using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 5;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            Move();

    }

    // Move to the left
    public void Move()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
