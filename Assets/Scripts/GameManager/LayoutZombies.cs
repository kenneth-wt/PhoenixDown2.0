using UnityEngine;

public class LayoutZombies : MonoBehaviour
{
  public GameObject leftPointBoundary;
  public GameObject rightPointBoundary;
  public float boundaryOffset;
  private Vector3 leftPointMax;
  private Vector3 rightPointMax;
  private GameObject[] zombies;

  void Awake()
  {
    zombies = GameObject.FindGameObjectsWithTag("Zombie");

    foreach (GameObject zombie in zombies)
    {
      leftPointMax = new Vector3(leftPointBoundary.transform.position.x + boundaryOffset, zombie.transform.position.y, zombie.transform.position.z);
      rightPointMax = new Vector3(rightPointBoundary.transform.position.x - boundaryOffset, zombie.transform.position.y, zombie.transform.position.z);
      zombie.transform.position = new Vector3(Random.Range(leftPointMax.x, rightPointMax.x), zombie.transform.position.y, zombie.transform.position.z);
      zombie.GetComponent<LateralMovement>().isMovingRight = Random.value > 0.5f;
    }
  }
}
