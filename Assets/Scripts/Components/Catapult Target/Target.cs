using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Projectile"))
      {
        
      }
    }
}

