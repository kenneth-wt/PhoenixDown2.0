using System.Collections;
using UnityEngine;

public class GameManagerB4 : MonoBehaviour
{
    public GameObject blueGhost;
    public GameObject purificationCrystal;
    public GameObject ball;
    public Rigidbody ballRb;
    public float normalSpeed = 10f;
    public float blueGhostBuffedSpeed = 25f;
    private bool isBuffed = false;
    private float buffTimeLeft = 0f;
    private bool isPaused = false;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -30, -9.81F);
        if (ballRb == null && ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        // Handle the game pause/resume functionality
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        if (isBuffed)
        {
            buffTimeLeft -= Time.deltaTime;
            if (buffTimeLeft <= 0)
            {
                RemoveBuff();
            }
        }
    }

    private void TogglePauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        // Optionally, show the pause menu or UI here
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        // Optionally, hide the pause menu or UI here
    }

    public void ApplyBlueGhostBuff(float duration)
    {
        isBuffed = true;
        buffTimeLeft = duration;
        ballRb.velocity = ballRb.velocity.normalized * blueGhostBuffedSpeed;
    }

    public void RemoveBuff()
    {
        isBuffed = false;
        ballRb.velocity = ballRb.velocity.normalized * normalSpeed;
    }

    public void ActivateBlueGhost()
    {
        if (blueGhost != null)
        {
            blueGhost.SetActive(true);
        }
    }

    public void DeactivateBlueGhost()
    {
        if (blueGhost != null)
        {
            blueGhost.SetActive(false);
        }
    }

    IEnumerator ManageBuffEffect()
    {
        yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);
        ApplyBlueGhostBuff(5f);
    }
}
