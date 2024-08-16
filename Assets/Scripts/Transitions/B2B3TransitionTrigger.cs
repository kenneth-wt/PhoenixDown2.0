using System.Collections;
using UnityEngine;

public class B2B3TransitionTrigger : MonoBehaviour
{
  public GameObject gameManager;
  void OnTriggerEnter()
  {
    StartCoroutine(StartTransitionAfterDelay());
  }

  IEnumerator StartTransitionAfterDelay()
  {
    yield return new WaitForSeconds(2f);
    gameManager.GetComponent<B3B2LossTransition>().StartTransition();
  }
}
