using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B2B3Transition : MonoBehaviour
{
  public BlackFade blackFadeScript;

  public void StartTransition()
  {
    blackFadeScript.StartFade(true);
    StartCoroutine(LoadSceneAfterFade("B3"));
  }

  IEnumerator LoadSceneAfterFade(string sceneName)
  {
    yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);
    SceneArguments.previousSceneCondition = "B2B3";
    SceneManager.LoadScene(sceneName);
  }
}
