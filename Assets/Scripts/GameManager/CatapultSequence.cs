using System.Collections;
using UnityEngine;

public class CatapultSequence : MonoBehaviour
{
  public GameObject[] catapults;
  public GameObject[] projectiles;
  public GameObject rampExit;
  public new GameObject camera;

  private int currentNum;

  public void InitiateCatapultSequence()
  {
    foreach (GameObject catapult in catapults)
    {
      if (catapult.GetComponent<Catapult>().rotated)
      {
        camera.GetComponent<CameraFollow>().CatapultFollow();
        break;
      }
    }
    
    EnableNextCatapult();
  }

  public void EnableNextCatapult()
  {
    if (currentNum >= catapults.Length)
    {
      InitiateReset();
      return;
    }

    Catapult catapultScript = catapults[currentNum].GetComponent<Catapult>();

    if (!catapultScript.rotated)
    {
      InitiateReset();
      return;
    }

    if (currentNum > 0)
    {
      projectiles[currentNum - 1].SetActive(false);
      catapults[currentNum - 1].GetComponentInParent<Plunger>().enabled = false; // TODO: Shift this to be on ball release rather than here
    } 

    catapults[currentNum].GetComponentInParent<Plunger>().enabled = true;
    catapultScript.ready = true;
    currentNum++;
  }

  private void InitiateReset()
  {
    currentNum = 0;

    foreach (GameObject projectile in projectiles)
    {
      projectile.GetComponent<Projectile>().Reset();
    }

    foreach (GameObject catapult in catapults)
    {
      catapult.GetComponentInParent<Plunger>().enabled = false;
    }

    StartCoroutine(WaitToReset());
  }

  IEnumerator WaitToReset()
  {
    yield return new WaitForSeconds(2f);

    camera.GetComponent<CameraFollow>().ResetCamera();

    yield return new WaitForSeconds(2f);

    rampExit.GetComponent<RampExit>().ExitRamp();
  }
  
  public void RegisterHit()
  {
    Debug.Log("Hit!");
    EnableNextCatapult();
  }
}
