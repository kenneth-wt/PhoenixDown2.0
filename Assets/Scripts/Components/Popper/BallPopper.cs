using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPopper : MonoBehaviour
{
    public float holdTime = 1.0f; // Time in seconds to hold the ball
    public float launchVelocity = 10.0f; // Velocity to apply to the ball for a vertical launch
    public float cooldownTime = 5.0f; // Time in seconds the popper is inactive after launch

    private Rigidbody ballRigidbody;
    private Collider popperCollider;

    private void Start()
    {
        // Get the Collider component of the popper itself
        popperCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) // Make sure the collider has the tag "Ball"
        {
            ballRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (ballRigidbody != null && popperCollider != null)
            {
                ballRigidbody.isKinematic = true; // Temporarily make the ball kinematic
                ballRigidbody.position = transform.position; // Center the ball on the popper
                popperCollider.enabled = false; // Disable the popper's collider to prevent further interaction
                Invoke("LaunchBall", holdTime); // Wait for holdTime then launch the ball
            }
        }
    }

    private void LaunchBall()
{
    if (ballRigidbody != null)
    {
        ballRigidbody.isKinematic = false; // Make the ball dynamic again
        // Apply the launch velocity along the Z-axis
        ballRigidbody.velocity = new Vector3(0, 0, launchVelocity); 
        Invoke("ReactivatePopper", cooldownTime); // Reactivate the popper after cooldownTime
    }
}


    private void ReactivatePopper()
    {
        if (popperCollider != null)
        {
            popperCollider.enabled = true; // Re-enable the popper's collider
        }
    }
}
