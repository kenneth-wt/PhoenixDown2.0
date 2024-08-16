using UnityEngine;

public class ResetFlippers : MonoBehaviour
{
  public GameObject[] flippers;

  // Update is called once per frame
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Ball"))
    {
      foreach (GameObject flipper in flippers)
      {
        flipper.GetComponent<Collider>().enabled = true;
      }
    }
  }
}
