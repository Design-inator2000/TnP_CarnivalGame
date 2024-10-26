using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]


public class ScoreTracking : MonoBehaviour
{    
    public TextMeshProUGUI scoreTracker; // This is the TMP element that tracks the player's score.

    public int score; // This is the current score the player has.

    // This OnEnable function subscribes the IncrementScore method to the OnScoreUpdated event.
    private void OnEnable()
    {
        TargetBehavior.OnScoreUpdated += IncrementScore;
    }

    // This OnDisable function unsubscribes the IncrementScore method from the OnScoreUpdated event.
    private void OnDisable()
    {
        TargetBehavior.OnScoreUpdated -= IncrementScore;
    }

    // This method will update the score text without hard references to other scripts (besides the event handler).
    public void IncrementScore(int points)
    {
        score += points;
        scoreTracker.text = $"Score: {score}";
    }

}