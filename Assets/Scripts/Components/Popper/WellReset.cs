using System.Collections;
using UnityEngine;

public class WellReset : MonoBehaviour
{
  public GameObject well;
  public GameObject tiltManager;

  void OnTriggerEnter()
  {
    well.GetComponent<Collider>().enabled = true;
    Physics.gravity = new Vector3(0, Constants.gravityY, Constants.gravityZ);

    tiltManager.GetComponent<Tilt>().enabled = true;

    StartCoroutine(WellCleanup());
  }

  private IEnumerator WellCleanup()
  {
    yield return new WaitForSeconds(.5f);

    GameObject ball = GameObject.FindGameObjectWithTag("Ball");
    ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    ball.transform.position = new Vector3(ball.transform.position.x, .5f, ball.transform.position.z);
    GetComponent<Collider>().enabled = false;
  }
}
