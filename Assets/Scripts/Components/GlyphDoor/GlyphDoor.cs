using UnityEngine;

public class GlyphDoor : MonoBehaviour
{
  public GameObject[] glyphs;
  public GameObject[] coffins;
  public GameObject orbit;
  public new Camera camera;
  public Material disabled; // TODO: Remove this

  private int unlockCount = 0;
  private int requiredCount = 3;

  public void Start()
  {
    ResetGlyphs();
  }

  public void Unlock()
  {
    unlockCount++;
    if (unlockCount == requiredCount)
    {
      camera.GetComponent<CameraFollow>().followZThreshold = -3.5f;
      GetComponent<Collider>().enabled = false;
      GetComponent<Renderer>().material = disabled; // TODO: Remove this
      foreach (GameObject glyph in glyphs)
      {
        glyph.SetActive(false);
      }

      foreach (GameObject coffin in coffins)
      {
        coffin.SetActive(false);
      }

      orbit.SetActive(false);
    }
  }

  public void ResetGlyphs()
  {
    unlockCount = 0;
    int falseIndex = Random.Range(0, glyphs.Length);
    for (int i = 0; i < glyphs.Length; i++)
    {
      glyphs[i].GetComponent<Glyph>().ResetGlyph((i == falseIndex) ? false : true);
    }
  }
}
