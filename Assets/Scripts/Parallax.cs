using UnityEngine;

public class Parallax : MonoBehaviour
{
  private float length, startpos;
  public new GameObject camera;
  public float parallaxEffect;

  void Start ()
  {
    startpos = transform.position.z;
    length = GetComponent<SpriteRenderer>().bounds.size.z;
  }

  void FixedUpdate()
  {
    float temp = camera.transform.position.z * (1 - parallaxEffect);
    float dist = camera.transform.position.z * parallaxEffect;

    transform.position = new Vector3(transform.position.x, transform.position.y, startpos + dist);

    if (temp > startpos + length) startpos += length;
    else if (temp < startpos - length) startpos -= length;
  }
}
