using UnityEngine;

public class Projectile : MonoBehaviour
{
  public GameObject gameManager;
  public GameObject launchVector;
  private float minRelease = 325;
  private float maxRelease = 267;
  private float minForce = 10f;
  private float maxForce = 40f;
  public Transform resetPosition;

  private Transform startingParent;

  void Start()
  {
    startingParent = transform.parent;
  }

  public void Launch(float releasePoint)
  {
    GetComponent<Rigidbody>().isKinematic = false;

    float i = releasePoint - minRelease;
    float j = maxRelease - minRelease;
    float t = i/j;
    float force = Mathf.Lerp(minForce, maxForce, t);
    
    GetComponent<Rigidbody>().AddForce(launchVector.transform.forward * force, ForceMode.Impulse);
    transform.parent = null;
  }

  // TODO: Tidy this up a lot
  public void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Target"))
    {
      gameManager.GetComponent<CatapultSequence>().RegisterHit();
    } else {
      gameManager.GetComponent<CatapultSequence>().EnableNextCatapult();
    }
  }

  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Target"))
    {
      gameManager.GetComponent<CatapultSequence>().RegisterHit();
    } else {
      gameManager.GetComponent<CatapultSequence>().EnableNextCatapult();
    }
  }

  public void Reset()
  {
    gameObject.SetActive(true);
    transform.position = resetPosition.position;
    transform.rotation = Quaternion.Euler(0, 0, 0);
    GetComponent<Rigidbody>().isKinematic = true;
    transform.parent = startingParent;
  }
}
