using UnityEngine;

public class RegisterTargetHit : MonoBehaviour
{
  public bool hit = false;
  public GameObject gameManager;
  public new Light light;

  void Start()
  {
    if (hit) light.color = Color.blue;
  }
  
  // Tombstone
  void OnCollisionEnter()
  {
    if (!hit)
    {
      CryptUnlock cryptUnlockScript = gameManager.GetComponent<CryptUnlock>();
      cryptUnlockScript.Unlock();

      light.color = Color.blue;

      hit = true;
    }
  }

  // Rollover
  void OnTriggerEnter()
  {
    if (!hit)
    {
      hit = true;
      light.color = Color.blue;

      gameManager.GetComponent<CatapultEnable>().Enable();
    }
  } 
}
