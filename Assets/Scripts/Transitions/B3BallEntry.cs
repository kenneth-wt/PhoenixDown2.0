using System.Collections;
using UnityEngine;

public class B3BallEntry : MonoBehaviour
{
  public GameObject ball;
  public float entryForce;

  void Start()
  {
    StartCoroutine(InitiateBallEntry());
  }

  IEnumerator InitiateBallEntry()
  {
    yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);

    Rigidbody rb = ball.GetComponent<Rigidbody>();
    rb.isKinematic = false;
    rb.AddForce(Vector3.forward * entryForce, ForceMode.Impulse);
  }
}
