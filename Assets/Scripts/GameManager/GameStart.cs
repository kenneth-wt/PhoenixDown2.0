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
    private bool isPaused = false;

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

    void Update()
    {
        // Handle the game pause/resume functionality
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    private void TogglePauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        // Optionally, show the pause menu or UI here
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        // Optionally, hide the pause menu or UI here
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
