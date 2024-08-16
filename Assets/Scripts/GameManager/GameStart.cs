using System.Collections;
using UnityEngine;

public class GameStart : MonoBehaviour
{
  public BlackFade blackFadeScript;
  public GameObject cryptDoor;
  public GameObject[] tombstones;
  public GameObject wellPopper;
  public GameObject ball;
  public GameObject tiltManager;

  public GameObject[] rollovers;
  private Collider cryptDoorCollider;
  
  void Awake()
  {
    switch (SceneArguments.previousSceneCondition)
    {
      case "B3B2Loss":
        Physics.gravity = new Vector3(0, Constants.gravityY, Constants.gravityZ);
        foreach (GameObject tombstone in tombstones)
        {
          tombstone.GetComponent<RegisterTargetHit>().hit = true;
        }

        ball.GetComponent<Rigidbody>().isKinematic = true;

        cryptDoorCollider = cryptDoor.GetComponent<Collider>();
        cryptDoorCollider.enabled = false;

        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.transform.position = cryptDoorCollider.bounds.center;
        StartCoroutine(WaitToKick());
        break;
      case "B3B2Win":
        Physics.gravity = new Vector3(0, Constants.gravityY, Constants.gravityZ);
        foreach (GameObject tombstone in tombstones)
        {
          tombstone.GetComponent<RegisterTargetHit>().hit = true;
        }
        
        ball.GetComponent<Rigidbody>().isKinematic = true;

        ball.transform.position = wellPopper.GetComponent<Collider>().bounds.center;

        foreach (GameObject rollover in rollovers)
        {
          rollover.SetActive(true);
        }

        tiltManager.GetComponent<Tilt>().enabled = false;

        StartCoroutine(WaitToPop());
        break;
      default:
        break;
    }

    blackFadeScript.StartFade(false);
  }

  IEnumerator WaitToKick()
  {
    yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);
    ball.GetComponent<Rigidbody>().isKinematic = false;

    CryptDoor cryptDoorScript = cryptDoor.GetComponent<CryptDoor>();
    cryptDoor.GetComponent<Collider>().enabled = true;


    yield return new WaitForSeconds(cryptDoorScript.cooldownTime);
    cryptDoorScript.unlocked = true;
  }

  IEnumerator WaitToPop()
  {
    yield return new WaitForSeconds(Constants.fadeDuration + Constants.fadeBuffer);
  
    wellPopper.GetComponent<WellPopper>().BallToFountains();
  }
}
