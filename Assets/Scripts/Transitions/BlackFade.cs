using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    public float fadeDuration = Constants.fadeDuration;
    public Image image;

    public void StartFade(bool fadeIn)
    {
      StartCoroutine(Fade(fadeIn));
    }

    IEnumerator Fade(bool fadeIn)
    {
      if (!fadeIn) {
        yield return new WaitForSeconds(1f);
      }

      float elapsed = 0f;
      Color startColor = fadeIn ? new Color(0f, 0f, 0f, 0f) : new Color(0f, 0f, 0f, 1f);
      Color targetColor = fadeIn ? new Color(0f, 0f, 0f, 1f) : new Color(0f, 0f, 0f, 0f);

      while (elapsed < fadeDuration)
      {
      elapsed += Time.deltaTime;
      float normalizedTime = elapsed / fadeDuration;
      image.color = Color.Lerp(startColor, targetColor, normalizedTime);

      yield return null;
      }

      if (fadeIn) {
        yield return new WaitForSeconds(1f);
      }
    }
}

