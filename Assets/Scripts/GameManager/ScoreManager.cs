using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public int score = 0; // Holds the player's score
    public TMP_Text scoreText; // Reference to the TMP_Text element for displaying the score

    private void Awake()
    {
        // Ensure that there is only one instance of ScoreManager (Singleton Pattern)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading a new scene
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to add points to the score
    public void AddScore(int points)
    {
        score += points; // Increment the score
        UpdateScoreText(); // Update the score UI
    }

    // Update the score text UI
    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the TMP text component
        }
    }

    // Optionally, a method to reset the score, useful when restarting a game
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}