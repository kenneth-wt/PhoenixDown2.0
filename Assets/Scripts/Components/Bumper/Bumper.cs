using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force = 1000f;
    public int scorePoints = 50; // Points to be awarded when the ball hits the bumper

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Apply explosion force to the ball
            Rigidbody otherRB = collision.rigidbody;
            otherRB.AddExplosionForce(force, collision.contacts[0].point, 5);

            // Add score when the ball hits the bumper
            if (ScoreManager.instance != null) // Check if ScoreManager is available
            {
                ScoreManager.instance.AddScore(scorePoints);
            }
        }
    }
}

