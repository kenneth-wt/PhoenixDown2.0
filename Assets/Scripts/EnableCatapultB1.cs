using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCatapultB1 : MonoBehaviour
{
    // Reference to the second trigger (the new GameObject that you want to activate)
    public GameObject newTrigger;

    // Reference to the catapult GameObject that you want to activate
    public GameObject catapult;

    public GameObject fence;
    // This method is called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the ball (based on the tag)
        if (other.CompareTag("Ball"))
        {
            // Activate the new trigger
            if (newTrigger != null)
            {
                newTrigger.SetActive(true); // This will activate the new trigger
                Debug.Log("Ball passed through the first trigger! New trigger activated.");
            }

            // Activate the catapult
            if (catapult != null)
            {
                catapult.SetActive(true); // This will activate the catapult
                Debug.Log("Catapult activated.");
            }

            if (fence != null)
            {
                fence.SetActive(false); // This will activate the catapult
                Debug.Log("fenceoff");
            }
        }
    }
}

