using UnityEngine;

public class CryptUnlock : MonoBehaviour
{
  public GameObject[] tombstones;
  public GameObject cryptDoor;

  private int numToUnlock;
  private int currentNum = 0;

  void Start()
  {
    numToUnlock = tombstones.Length - 1;
  }

  public void Unlock()
  {
    if (currentNum < numToUnlock)
    {
      currentNum++;
    } else {
      CryptDoor cryptDoorScript = cryptDoor.GetComponent<CryptDoor>();
      cryptDoorScript.Unlock();
    }
  }
}
