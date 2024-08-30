using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurificationCrystal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Get the GameManagerB4 instance and remove the ghost buff
            GameManagerB4 gameManager = FindObjectOfType<GameManagerB4>();
            if (gameManager != null)
            {
                gameManager.RemoveBuff();
            }

            // Optionally, deactivate the crystal after use
            gameObject.SetActive(false);
        }
    }
}

