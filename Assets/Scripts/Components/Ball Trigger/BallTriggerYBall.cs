using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerYBall : MonoBehaviour
{
    public float targetYPosition = 0.35f; // The Y value to set

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the ball
        if (other.gameObject.name == "Ball")
        {
            Debug.Log("Ball has passed through the trigger!");

            // Change the ball's Y position to 0.35
            Vector3 newPosition = other.transform.position;
            newPosition.y = targetYPosition;
            other.transform.position = newPosition;

            Debug.Log("Ball Y position changed to " + targetYPosition);
        }
    }
}


