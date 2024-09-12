using UnityEngine;

public class DestructibleObject : MonoBehaviour
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
            // Check if the Red Ghost Buff is active in the GameManager
            if (gameManager != null && gameManager.IsRedBuffActive())
            {
                // Destroy this game object
                Debug.Log("Destructible Object hit by ball with Red Ghost Buff: " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}

