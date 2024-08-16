using UnityEngine;

public class Altar : MonoBehaviour
{
  public GameObject gameManager;
  
  void OnTriggerEnter(Collider other)
  {
    other.GetComponent<Rigidbody>().isKinematic = true;
    GetComponent<Collider>().enabled = false;
    gameManager.GetComponent<B3B2WinTransition>().StartTransition();
  }
}
