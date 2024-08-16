using UnityEngine;

public class BallKicker : MonoBehaviour
{
    public float holdTime = 0.5f; // Time in seconds to hold the ball
    public float kickForce = 15.0f; // Force to apply to the ball for a lateral kick
    public float cooldownTime = .5f; // Time in seconds to disable the collider after kicking
    public GameObject target;
    public bool shouldKick = true;

    private Rigidbody ballRigidbody;
    private Collider kickerCollider;
    private bool isHoldingBall = false; // Flag to check if currently holding the ball

    private void Start()
    {
      // Get the Collider component of the kicker itself
      kickerCollider = GetComponent<Collider>();
    }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Ball") && !isHoldingBall) // Ensure the collider is tagged as "Ball"
    {
      ballRigidbody = other.GetComponent<Rigidbody>();
      isHoldingBall = true; // Set the flag that ball is being held

      if (ballRigidbody != null)
      {
          ballRigidbody.isKinematic = true; // Stop the ball from moving
          ballRigidbody.position = kickerCollider.bounds.center; // Center the ball
          if (shouldKick) Invoke(nameof(KickBall), holdTime); // Schedule the kick after the hold time
      }
    }
  }

  private void KickBall()
  {
      if (ballRigidbody != null)
      {
        ballRigidbody.isKinematic = false; // Allow the ball to move again
        ballRigidbody.velocity = Vector3.zero; // Clear any existing velocity
        ballRigidbody.AddForce((target.transform.position - ballRigidbody.position).normalized * kickForce, ForceMode.Impulse); // Apply a force towards the target for the kick
        isHoldingBall = false; // Reset the flag after kicking the ball
      }
      kickerCollider.enabled = false; // Disable the collider to start cooldown
      Invoke(nameof(ReactivateCollider), cooldownTime); // Schedule to re-enable the collider after cooldown
  }

  private void ReactivateCollider()
  {
    kickerCollider.enabled = true; // Re-enable the kicker's collider
  }
}
