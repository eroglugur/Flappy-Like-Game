using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI Buttons
    public Button startButton;
    public Button restartButton;

    // Score text and value
    public Text scoreText;
    public int score;

    // Player (the bird)
    public GameObject player;

    // Boolean value of whether the game is running or not
    public bool isGameActive = false;

    private void Start()
    {
        startButton.gameObject.SetActive(true);

    }

    // Ends the game, turns on the restart button
    public void EndGame()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    // Adds a score to the scoreboard
    public void EarnScore()
    {
        score++;
        scoreText.text = "" + score;
    }

    // Starts the game, turns of the start button
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;

        scoreText.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }
    // Restarts the game, turns off the restart button
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
    }
}
