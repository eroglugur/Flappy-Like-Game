using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    // Movement and limits
    private float upperLimitY = 7.0f;
    private float jumpForce = 60;

    // Rotation limits
    private float upperRotateLimit = -3f;
    private float upperRotateSpeed = 2;
    private float lowerRotateSpeed = -3;

    // Sound effects
    public AudioSource jumpSound;
    public AudioSource hitSound;
    public AudioSource scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            KeepPlayerInScreen();
            RotateWhenFlying();
        }
    }

    // Make the player jump with mouse click/touch input and play jump sound effect
    public void JumpPlayer()
    {
        if (gameManager.isGameActive)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }

    // Prevent player from going off the screen
    private void KeepPlayerInScreen()
    {
        if (transform.position.y > upperLimitY)
        {
            transform.position = new Vector2(transform.position.x, upperLimitY);
            rb.AddForce(Vector2.down * 3, ForceMode2D.Impulse);
        }
    }

    // Make the bird look up when flying upwards, and look down when falling downwards
    private void RotateWhenFlying()
    {
        if (rb.velocity.y > 0 || transform.position.y > upperRotateLimit)
        {
            transform.Rotate(transform.rotation.x, 0, upperRotateSpeed);

            // Prevent the bird rotate up more than 30 degrees
            if (transform.rotation.eulerAngles.z > 210)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 210);
            }

        }

        else if (rb.velocity.y < 0)
        {
            transform.Rotate(transform.rotation.x, 0, lowerRotateSpeed);

            // Prevent the bird rotate down more than 90 degrees
            if (transform.rotation.eulerAngles.z < 90)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            }
        }

        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    // Earn 1 score when player hits the invisible trigger between obstacles and play score sound effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreTrigger") && gameManager.isGameActive)
        {
            scoreSound.Play();
            gameManager.EarnScore();
        }

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            if (gameManager.isGameActive)
            {
                hitSound.Play();
            }
            gameManager.EndGame();
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
    }
}
