using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCatapultB1 : MonoBehaviour
{
    // Reference to the second trigger (the new GameObject that you want to activate)
    public GameObject newTrigger;

    // This method is called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the ball (based on the tag)
        if (other.CompareTag("Ball"))
        {
            // Activate the new trigger (you can customize this part to do something specific with the new trigger)
            if (newTrigger != null)
            {
                newTrigger.SetActive(true); // This will activate the new trigger
                Debug.Log("Ball passed through the first trigger! New trigger activated.");
            }
        }
    }
}
