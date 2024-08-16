using System.Collections;
using UnityEngine;

public class WellPopper : MonoBehaviour
{
  public GameObject target;
  public float force = 10.0f;
  public GameObject ball;

  private Vector3 targetDestination;

  void Start()
  {
    targetDestination = target.transform.position;
  }

  public void BallToFountains()
  {
    Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y * 2, 0f);
    target.GetComponent<Collider>().enabled = true;
    GetComponent<Collider>().enabled = false;

    Rigidbody rb = ball.GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.None;
    rb.isKinematic = false;

    Vector3 targetDirection = targetDestination - transform.position;

    // Calculate the distance to the target
    float distanceToTarget = targetDirection.magnitude;

    // Calculate the initial velocity needed to reach the target at the given angle
    float launchVelocity = distanceToTarget / (Mathf.Sin(2 * 70 * Mathf.Deg2Rad) / force);

    // Calculate the horizontal and vertical components of the velocity
    float xVelocity = Mathf.Sqrt(launchVelocity) * Mathf.Cos(70 * Mathf.Deg2Rad);
    float yVelocity = Mathf.Sqrt(launchVelocity) * Mathf.Sin(70 * Mathf.Deg2Rad);

    // Set the velocity of the ball
    Vector3 velocity = Vector3.right * xVelocity + transform.up * yVelocity + Vector3.back * (xVelocity / 1.5f);
    rb.velocity = velocity;
  }
}
