using UnityEngine;

public class FlipperEnable : MonoBehaviour
{
  public GameObject[] flippers;

  // TODO: Could optimise this and other checks for flippers to be set with global flipper state variable so that they don't mutate on both upward and downward ball movement
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Ball"))
    {
      foreach (GameObject flipper in flippers)
      {
        flipper.GetComponent<Collider>().enabled = true;
      }
    }
  }
}
