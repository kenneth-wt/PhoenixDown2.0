using UnityEngine;

public class CatapultEnable : MonoBehaviour
{
  public GameObject[] catapults;
  private int currentNum;
  public void Enable()
  {
    catapults[currentNum].GetComponent<CatapultRotate>().shouldRotate = true;
    currentNum++;
  }
}
