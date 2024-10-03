using UnityEngine;

public class RegisterTargetHit : MonoBehaviour
{
    public bool hit = false;
    public GameObject gameManager;
    public new Light light;

    void Start()
    {
        if (hit) 
        {
            light.color = Color.blue;
        }
    }
  
    // Tombstone collision event
    void OnCollisionEnter()
    {
        if (!hit)
        {
            // Call the crypt unlock functionality
            CryptUnlock cryptUnlockScript = gameManager.GetComponent<CryptUnlock>();
            cryptUnlockScript.Unlock();

            // Change light color and set hit to true
            light.color = Color.blue;
            hit = true;

            // Add 150 points to the score
            if (ScoreManager.instance != null) 
            {
                ScoreManager.instance.AddScore(150);
            }
        }
    }

    // Rollover trigger event
    void OnTriggerEnter()
    {
        if (!hit)
        {
            // Set hit to true and change light color
            hit = true;
            light.color = Color.blue;

            // Enable the catapult
            gameManager.GetComponent<CatapultEnable>().Enable();

            // Add 150 points to the score
            if (ScoreManager.instance != null) 
            {
                ScoreManager.instance.AddScore(150);
            }
        }
    } 
}
