using System.Collections;
using UnityEngine;

public class AltarAttract : MonoBehaviour
{
  public GameObject ball;
  public float force;
  private Vector3 center;
  
  void OnTriggerEnter(Collider other)
  {
    center = other.bounds.center;
    Rigidbody rb = other.GetComponent<Rigidbody>();
    rb.isKinematic = true;
    StartCoroutine(GravitateTowardsCenter());
    GetComponent<Collider>().enabled = false;
  }

  IEnumerator GravitateTowardsCenter() 
  {
    yield return new WaitForSeconds(2f);
    Rigidbody rb = ball.GetComponent<Rigidbody>();

    rb.isKinematic = false;
    Vector3 forceDirection = center - ball.transform.position;
    rb.AddForce(forceDirection.normalized * force);
  }
}
