using UnityEngine;

public class DisableOnContact : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      gameObject.SetActive(false);
    }
  }
}