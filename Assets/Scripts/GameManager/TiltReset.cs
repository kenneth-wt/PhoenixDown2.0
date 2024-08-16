using UnityEngine;

public class TiltReset : MonoBehaviour
{
  private GameObject tiltManager;

  private void Start()
  {
    tiltManager = GameObject.Find("TiltManager");
  }

  private void OnCollisionEnter(Collision other)
  {
    Tilt tiltScript = tiltManager.GetComponent<Tilt>();
    tiltScript.tiltAvailable = true;
  }
}
