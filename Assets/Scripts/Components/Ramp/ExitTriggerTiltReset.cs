using UnityEngine;

public class ExitTriggerTiltReset : MonoBehaviour
{
  public GameObject tiltManager;
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Ball")) {
      tiltManager.GetComponent<Tilt>().enabled = true;
    }
  }
}
