using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        DestroyOffScreen();
    }

   // Destroy the object if it goes off the screen
   void DestroyOffScreen()
    {
        if (transform.position.x < -6 && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("ScoreTrigger")))
        {
            Destroy(gameObject);
        }
    }
}
