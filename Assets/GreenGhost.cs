using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGhost : MonoBehaviour
{
    // Public list of GameObjects to assign multiple targets to destroy or deactivate
    public List<GameObject> targetObjects; 

    // OnTriggerEnter is called when another Collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the ball (assuming the ball has the "Ball" tag)
        if (other.CompareTag("Ball"))
        {
            // Loop through the list of targetObjects and deactivate or destroy them
            foreach (GameObject target in targetObjects)
            {
                if (target != null)
                {
                    // Deactivate the target object
                    target.SetActive(false);

                    // If you want to destroy it instead of deactivating, use:
                    // Destroy(target);

                    Debug.Log(target.name + " has been deactivated!");
                }
            }

            // Optionally, deactivate or destroy the GreenGhost itself after collision
            // gameObject.SetActive(false); // Deactivate the GreenGhost
            // Destroy(gameObject); // Destroy the GreenGhost object
        }
    }
}


