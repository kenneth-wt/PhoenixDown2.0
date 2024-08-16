using System.Collections;
using UnityEngine;

public class RampPlatformLaunch : MonoBehaviour
{
  public GameObject tiltManager;
  public float force = 10f;

  private Rigidbody rb;

  private void OnTriggerEnter(Collider other)
  {
    rb = other.GetComponent<Rigidbody>();
    rb.velocity = new Vector3(0f, rb.velocity.y, 0);

    Physics.gravity = new Vector3(0, Constants.gravityY, 0);
    tiltManager.GetComponent<Tilt>().enabled = false;
    StartCoroutine(ApplyForceAfterDelay());
  }

  private IEnumerator ApplyForceAfterDelay()
  {
    yield return new WaitForSeconds(2f);

    GameObject.FindGameObjectWithTag("RampPlatformLock").GetComponent<Collider>().enabled = false;
    rb.AddForce(Vector3.right * force, ForceMode.Impulse);
  }
}
