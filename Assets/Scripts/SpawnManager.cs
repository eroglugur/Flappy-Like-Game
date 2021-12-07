using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects that spawn after game starts
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject scoreTrigger;

    // Spawn positions of the objects
    private Vector2 spawnPosObstacle1;
    private Vector2 spawnPosObstacle2;
    private Vector2 spawnPosScoreTrigger;

    // Common spawn position in x axis of all objects
    private float spawnPosX = 9;

    // Spawn delay after game starts and repeat time of the spawnings
    private float startDelay = 0f;
    private float spawnInterval = 1.2f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, spawnInterval);
        gameManager = FindObjectOfType<GameManager>();

    }

    // Spawn obstacles and score trigger every 2 seconds at fixed positions on the x-axis but at random positions on the y-axis
    void SpawnObstacles()
    {
        if (gameManager.isGameActive)
        {
            spawnPosObstacle1 = new Vector2(spawnPosX, Random.Range(4, 11));
            spawnPosObstacle2 = new Vector2(spawnPosX, spawnPosObstacle1.y - 13);
            spawnPosScoreTrigger = spawnPosObstacle1;

            Instantiate(obstacle1, spawnPosObstacle1, obstacle1.transform.rotation);
            Instantiate(obstacle2, spawnPosObstacle2, obstacle2.transform.rotation);
            Instantiate(scoreTrigger, spawnPosScoreTrigger, scoreTrigger.transform.rotation);
        }
    }
}
