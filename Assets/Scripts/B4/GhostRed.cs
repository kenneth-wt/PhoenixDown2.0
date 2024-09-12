using UnityEngine;

public class GhostRed : MonoBehaviour
{
    private GameManagerB4 gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManagerB4>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the event is the ball
        if (other.CompareTag("Ball"))
        {
            // Activate the Red Ghost Buff in the GameManager
            if (gameManager != null)
            {
                gameManager.ApplyRedGhostBuff();
                Debug.Log("Red Ghost Buff applied!");

                // Optionally, deactivate or destroy the GhostRed after triggering
                gameObject.SetActive(false); // Deactivates the object instead of destroying it
            }
        }
    }
}
