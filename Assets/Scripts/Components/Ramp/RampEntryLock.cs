using UnityEngine;

public class RampEntryLock : MonoBehaviour
{
  private new Collider collider;

  void Start()
  {
    collider = GameObject.FindGameObjectWithTag("RampEntryLock").GetComponent<Collider>();
  }
  void OnTriggerEnter()
  {
    collider.enabled = true;
  }
}
