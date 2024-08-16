using System.Collections;
using UnityEngine;

public class AltarGravitate : MonoBehaviour
{
  public float gravityMagnitude = 1f;
  public float gravityIncreaseRate = 0.1f;
  public GameObject ball;

  private void OnTriggerEnter(Collider other)
  {
    Physics.gravity = Vector3.zero;
    Rigidbody rb = other.GetComponent<Rigidbody>();
    if (rb != null)
    {
      StartCoroutine(GravitateTowardsCenter(rb));
    }
  }

  private IEnumerator GravitateTowardsCenter(Rigidbody rb)
  {
    Vector3 center = transform.position;
    float currentMagnitude = 0f;

    while (true)
    {
      Vector3 direction = center - rb.position;
      rb.AddForce(direction.normalized * currentMagnitude, ForceMode.Acceleration);

      currentMagnitude += gravityIncreaseRate;

      if (Vector3.Distance(rb.position, center) < 0.5f)
      {
        rb.isKinematic = true;
        ball.transform.position = center;
        yield break;
      }

      yield return null;
    }
  }
}
