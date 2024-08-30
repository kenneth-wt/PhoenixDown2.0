using System.Collections;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public Transform projectilePosition; // Assign this in the Inspector
    public Catapult_Static catapult_Static; // Reference to the Catapult_Static script

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball") // Check if the object is the ball
        {
            Debug.Log("Ball entered the trigger!"); // Debugging log
            StartCoroutine(TeleportAndLaunch(other.gameObject));
        }
    }

    private IEnumerator TeleportAndLaunch(GameObject ball)
    {
        // Make the ball kinematic to stop its movement
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.isKinematic = true;
        }

        // Teleport the ball to the projectile position
        Debug.Log("Original Position: " + ball.transform.position); // Debugging log
        ball.transform.position = projectilePosition.position;
        Debug.Log("New Position: " + ball.transform.position); // Debugging log

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Set the ball as the projectile in the catapult and launch it
        if (ballRigidbody != null)
        {
            ballRigidbody.isKinematic = false; // Make the ball non-kinematic before launching
        }

        catapult_Static.ready = true;
        catapult_Static.projectile = ball; // Set the projectile to be the ball
        catapult_Static.LaunchBall(); // Automatically launch the ball
    }
}


