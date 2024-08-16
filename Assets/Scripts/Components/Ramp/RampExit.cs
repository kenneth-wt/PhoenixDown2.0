using System.Collections;
using UnityEngine;

public class RampExit : MonoBehaviour
{
  public GameObject gameManager;
  private new Collider collider;
  private Rigidbody rb;

  private Collider rampEntryLock;
  private Collider rampPlatformLock;

  void Start()
  {
    collider = GameObject.FindGameObjectWithTag("RampExit").GetComponent<Collider>();
    rb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
    rampEntryLock = GameObject.FindGameObjectWithTag("RampEntryLock").GetComponent<Collider>();
    rampPlatformLock = GameObject.FindGameObjectWithTag("RampPlatformLock").GetComponent<Collider>();
  }

  private void OnTriggerEnter(Collider other)
  {
    other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    
    gameManager.GetComponent<CatapultSequence>().InitiateCatapultSequence();
  }

  public void ExitRamp()
  {
    StartCoroutine(RampCleanup());
  }

  private IEnumerator RampCleanup()
  {
    yield return new WaitForSeconds(2f);

    collider.enabled = false;
    Physics.gravity = new Vector3(0, Constants.gravityY, Constants.gravityZ);

    yield return new WaitForSeconds(2f);
    rb.constraints = RigidbodyConstraints.FreezePositionY;
    collider.enabled = true;
    rampEntryLock.enabled = false;
    rampPlatformLock.enabled = true;
  }
}
