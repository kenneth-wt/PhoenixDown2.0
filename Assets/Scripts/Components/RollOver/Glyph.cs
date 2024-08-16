using UnityEngine;

public class Glyph : MonoBehaviour
{
  public GameObject glyphDoor;
  public bool isCorrectGlyph = false;
  public Material target;
  public Material success;
  public Material penalty;
  public Renderer glyph;

  void OnTriggerEnter(Collider other)
  {
    if (other.transform.position.z < transform.position.z)
    {
      GlyphDoor glyphDoorScript = glyphDoor.GetComponent<GlyphDoor>();

      if (isCorrectGlyph)
      {
        glyphDoorScript.Unlock();

        GetComponent<Collider>().enabled = false;
        glyph.material = success;
        isCorrectGlyph = false;
      } else {
        glyphDoorScript.ResetGlyphs();
      }
    }
  }

  public void ResetGlyph(bool active)
  {
    glyph.material = active ? target : penalty;
    GetComponent<Collider>().enabled = true;
    isCorrectGlyph = active;
  }
}
