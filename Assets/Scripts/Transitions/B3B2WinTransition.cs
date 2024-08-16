using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B3B2WinTransition : MonoBehaviour

{
  public BlackFade blackFadeScript;

  public void StartTransition()
  {
    blackFadeScript.StartFade(true);
    StartCoroutine(LoadSceneAfterFade("B1B2"));
  }

  IEnumerator LoadSceneAfterFade(string sceneName)
  {
    yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);
    SceneArguments.previousSceneCondition = "B3B2Win";
    SceneManager.LoadScene(sceneName);
  }
}
