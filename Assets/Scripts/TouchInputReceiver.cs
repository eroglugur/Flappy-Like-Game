using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputReceiver : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);

                if (finger.phase == TouchPhase.Began)
                {
                    FindObjectOfType<PlayerController>().JumpPlayer();
                }
            }
        }
    }
}
