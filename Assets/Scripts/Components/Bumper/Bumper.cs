using UnityEngine;

public class Bumper : MonoBehaviour
{
  public float force = 1000f;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      Rigidbody otherRB = collision.rigidbody;
      otherRB.AddExplosionForce(force, collision.contacts[0].point, 5);
    }
  }
}
