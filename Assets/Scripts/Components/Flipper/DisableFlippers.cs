using UnityEngine;

public class DisableFlippers : MonoBehaviour
{
  public GameObject[] flippers;
  void OnTriggerEnter()
  {
    foreach (GameObject flipper in flippers)
    {
      flipper.GetComponent<Collider>().enabled = false;
    }
  }
}
