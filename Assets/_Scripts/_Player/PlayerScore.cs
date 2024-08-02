using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText; // UI Text element to display the score
    private float elapsedTime; // Tracks the time elapsed
    private int playerScore; // Tracks the player's score

    private HighScoreSystem highScoreSystem;

    void Start()
    {
        elapsedTime = 0f;
        playerScore = 0;
        UpdateScoreText();

        // Find the HighScoreSystem in the scene
        highScoreSystem = FindObjectOfType<HighScoreSystem>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Increment elapsed time by the time passed since the last frame

        if (elapsedTime >= 1f)
        {
            playerScore += Mathf.FloorToInt(elapsedTime); // Add the number of whole seconds elapsed to the score
            elapsedTime -= Mathf.Floor(elapsedTime); // Reset elapsedTime to count the fraction of the next second
            UpdateScoreText(); // Update the displayed score
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }

    public void SaveHighScore()
    {
        OldPlayerData oldPlayerData = new OldPlayerData { playerName = "Player1", playerScore = playerScore };
        IHighScore highScore = new HighScoreAdapter(oldPlayerData);
        highScoreSystem.AddHighScore(highScore);
        highScoreSystem.SaveHighScores();
    }
}
