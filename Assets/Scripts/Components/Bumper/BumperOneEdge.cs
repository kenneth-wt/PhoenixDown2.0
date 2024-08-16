using UnityEngine;

public class BumperOneEdge : MonoBehaviour
{
  public float force = 1000f;
  public float contactNormalDistance; // Distance within which the contact normal is considered to be the bumper's normal

  private Vector3 contactNormal = new(-0.91f, 0.0f, -0.42f);

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      foreach (ContactPoint contact in collision.contacts)
      {
        // Check the distance between the normal collision points
        float distance = Vector3.Distance(contact.normal, contactNormal);

        // If the collision is approximately equal to the face's normal, apply the explosion force
        if (distance > contactNormalDistance - 0.1f && distance < contactNormalDistance + 0.1f)
        {
          Rigidbody otherRB = collision.rigidbody;
          otherRB.AddExplosionForce(force, contact.point, 5);
          break;
        }
      }
    }
  }
}