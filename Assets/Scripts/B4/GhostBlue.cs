using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhost : MonoBehaviour
{
    public float buffDuration = 5f; // Duration of the buff effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Get the GameManagerB4 instance and apply the BlueGhost buff
            GameManagerB4 gameManager = FindObjectOfType<GameManagerB4>();
            if (gameManager != null)
            {
                gameManager.ApplyBlueGhostBuff();
            }

            // Optionally, deactivate the BlueGhost after the ball hits it
            gameObject.SetActive(false);
        }
    }
}

