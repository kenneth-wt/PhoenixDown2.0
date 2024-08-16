using UnityEngine;

public class Tilt : MonoBehaviour
{
  public Material disabled;
  private Material startingMaterial;

  // Components
  public GameObject ball;
  public GameObject plunger;
  private Rigidbody rb;
  public GameObject[] flippers;
  private Plunger plungerScript;
  private Pull pullScript;

  // Inputs
  public string leftTiltInputButtonName;
  public string rightTiltInputButtonName;
  public string upTiltInputButtonName;
  public string downTiltInputButtonName;
  public string leftFlipperInputButtonName;
  public string rightFlipperInputButtonName;

  // Tilt configuration
  public bool tiltAvailable = true; // Whether the player can tilt
  public float tiltForce; // The force applied to the ball
  public float tiltCost = 2f; // How much a tilt costs the player to use
  public float tiltThreshold = 3f; // The limit at which the player will be penalised
  public float successiveTiltCooldownDuration = 1f; // The time between successive tilt inputs
  public float tiltPenaltyDuration = 5f; // Tilt penalty
  public float verticalModifier = 1.5f; // Multiplier for vertical tilts
  private float tiltTimer;
  private float successiveTiltTimer;
  private float tiltPenaltyTimer;
  private bool tiltPenalty = false; // Whether the player is currently penalised


  void Start()
  {
    rb = ball.GetComponent<Rigidbody>();

    if (plunger != null && plunger.GetComponentInChildren<Pull>() != null)
    {
      pullScript = plunger.GetComponentInChildren<Pull>();
    }

    startingMaterial = ball.GetComponent<Renderer>().material; // TODO: Possible bug here if player presses button before material is set. Remove when we don't need this
  }

  void Update()
  {
    // Handle tilt threshold
    if (tiltTimer > 0)
    {
      tiltTimer -= Time.deltaTime;

      // If player tilts too often, penalise them
      if (tiltTimer >= tiltThreshold)
      {
        tiltAvailable = false;
        tiltPenalty = true;

        // Reset timers
        tiltTimer = 0;
        successiveTiltTimer = 0;
        tiltPenaltyTimer = tiltPenaltyDuration;

        // Disable flippers
        foreach (GameObject flipper in flippers)
        {
          Flipper flipperScript = flipper.GetComponent<Flipper>();
          flipperScript.enabled = false;
        }

        ball.GetComponent<Renderer>().material = disabled; // TODO: Remove this once we have assets. Just used for testing purposes currently
        
        if (plungerScript != null)
        {
          plungerScript.enabled = false;
        }

        if (pullScript != null)
        {
          pullScript.enabled = false; // TODO: Visually disable the pull/plunger
        }
      }
    } else if (tiltTimer < 0) {
      tiltTimer = 0;
    }

    // Handle successive tilt cooldown
    if (successiveTiltTimer > 0)
    {
      successiveTiltTimer -= Time.deltaTime;
    } else if (successiveTiltTimer < 0) {
      successiveTiltTimer = 0;
    }

    // Tick down penalty
    if (tiltPenaltyTimer > 0) {
      tiltPenaltyTimer  -= Time.deltaTime;
    } else if (tiltPenalty) {
      tiltAvailable = true;
      tiltPenalty = false;

      // Enable flippers
      foreach (GameObject flipper in flippers)
      {
        Flipper flipperScript = flipper.GetComponent<Flipper>();
        flipperScript.enabled = true;

        ball.GetComponent<Renderer>().material = startingMaterial; // TODO: Remove this once we have assets. Just used for testing purposes currently

        if (plungerScript != null)
        {
          plungerScript.enabled = true;
        }

        if (pullScript != null)
        {
          pullScript.enabled = true; // TODO: Visually enable the pull/plunger
        }
      }

      tiltPenaltyTimer = 0;
    }

    // Disallow inputs if penalty is applied
    if (!tiltPenalty)
    {
      // Handle inputs
      if (Input.GetButton(leftTiltInputButtonName) && tiltAvailable && successiveTiltTimer <= 0)
      {
        rb.AddExplosionForce(tiltForce, ball.transform.position + Vector3.right, 5);
        tiltAvailable = false;
        successiveTiltTimer = successiveTiltCooldownDuration;
        tiltTimer += tiltCost;
      }

      if (Input.GetButton(rightTiltInputButtonName) && tiltAvailable && successiveTiltTimer <= 0)
      {
        rb.AddExplosionForce(tiltForce, ball.transform.position + Vector3.left, 5);
        tiltAvailable = false;
        successiveTiltTimer = successiveTiltCooldownDuration;
        tiltTimer += tiltCost;
      }

      if (Input.GetButton(upTiltInputButtonName) && tiltAvailable && successiveTiltTimer <= 0)
      {
        rb.AddExplosionForce(tiltForce * verticalModifier, ball.transform.position + Vector3.back, 5);
        tiltAvailable = false;
        successiveTiltTimer = successiveTiltCooldownDuration;
        tiltTimer += tiltCost;
      }

      if (Input.GetButton(downTiltInputButtonName) && tiltAvailable && successiveTiltTimer <= 0)
      {
        rb.AddExplosionForce(tiltForce * verticalModifier, ball.transform.position + Vector3.forward, 5);
        tiltAvailable = false;
        successiveTiltTimer = successiveTiltCooldownDuration;
        tiltTimer += tiltCost;
      }
    }
  }
}
