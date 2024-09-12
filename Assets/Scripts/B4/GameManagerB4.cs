using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerB4 : MonoBehaviour
{
    public GameObject blueGhost;
    public GameObject redGhost;
    public GameObject purificationCrystal;
    public GameObject ball;
    public Rigidbody ballRb;
    public float normalSpeed = 10f;
    public float blueGhostBuffedSpeed = 100f;
    public float blueGhostBuffedMass = 0.2f;

    private bool isRedBuffed = false;  // Flag for Red Ghost Buff
    private bool isBlueBuffed = false; // Flag for Blue Ghost Buff
    private bool isPaused = false;

    // Public list of GameObjects to make their colliders trigger upon Red Buff activation
    public List<GameObject> RedtriggerObjects; 
    public List<GameObject> BluetriggerObjects;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
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
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Apply the Blue Ghost buff for a specified duration
    public void ApplyBlueGhostBuff()
    {
        isBlueBuffed = true;
        ballRb.velocity = ballRb.velocity.normalized * blueGhostBuffedSpeed;
        ballRb.mass = blueGhostBuffedMass;
        Debug.Log("Blue Ghost Buff activated!");

        // Set all GameObjects in the triggerObjects list to have isTrigger = true
        foreach (GameObject obj in BluetriggerObjects)
        {
            Collider col = obj.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;  // Set the collider to trigger
                Debug.Log("Set isTrigger = true for: " + obj.name);
            }
            else
            {
                Debug.LogWarning("No Collider found on " + obj.name);
            }
        }
    }

    // Remove the Blue Ghost buff
    public void RemoveBlueGhostBuff()
    {
        isBlueBuffed = false;
        ballRb.mass = 0.6f; // Reset mass to normal value
        Debug.Log("Blue Ghost Buff deactivated!");
    }

    // Apply the Red Ghost buff permanently and set certain GameObjects' colliders to trigger
    public void ApplyRedGhostBuff()
    {
        isRedBuffed = true;
        Debug.Log("Red Ghost Buff activated!");

        // Set all GameObjects in the triggerObjects list to have isTrigger = true
        foreach (GameObject obj in RedtriggerObjects)
        {
            Collider col = obj.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;  // Set the collider to trigger
                Debug.Log("Set isTrigger = true for: " + obj.name);
            }
            else
            {
                Debug.LogWarning("No Collider found on " + obj.name);
            }
        }
    }

    // Remove the Red Ghost buff manually
    public void RemoveRedGhostBuff()
    {
        isRedBuffed = false;
        Debug.Log("Red Ghost Buff deactivated!");

        // Optionally, reset the colliders' isTrigger back to false when the buff is removed
        foreach (GameObject obj in RedtriggerObjects)
        {
            Collider col = obj.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = false;  // Optionally set the collider back to non-trigger
                Debug.Log("Set isTrigger = false for: " + obj.name);
            }
        }
    }

    // Method to check if the Red Ghost Buff is active
    public bool IsRedBuffActive()
    {
        return isRedBuffed;
    }
}
