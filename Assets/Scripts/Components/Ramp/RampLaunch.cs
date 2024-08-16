using UnityEngine;

public class RampLaunch : MonoBehaviour
{
  public GameObject target;
  public float force = 10f;

  void OnTriggerEnter(Collider other)
  {
    other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    Rigidbody otherRb = other.GetComponent<Rigidbody>();

    Vector3 forceDirection = target.transform.position;
    otherRb.AddForce(forceDirection.normalized * force, ForceMode.Impulse);
  }
}
