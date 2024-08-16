using System.Collections;
using System.Linq;
using UnityEngine;

public class ResetZombie : MonoBehaviour
{
  public float resetDelay = 3f;
  private bool isResetting = false;

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Ball") && !isResetting)
    {
      GameObject[] disabledZombies = Resources.FindObjectsOfTypeAll<GameObject>()
        .Where(go => go.CompareTag("Zombie") && !go.activeInHierarchy && go.scene.name != null)
        .ToArray();

      StartCoroutine(ResetZombiesCoroutine(disabledZombies));
      isResetting = true;
    }
  }

  IEnumerator ResetZombiesCoroutine(GameObject[] disabledZombies)
  {
    yield return new WaitForSeconds(resetDelay);

    foreach (GameObject zombie in disabledZombies)
    {
      zombie.SetActive(true);
    }

    isResetting = false;
  }
}
