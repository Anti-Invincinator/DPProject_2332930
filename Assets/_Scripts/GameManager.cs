using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour, IObserver
{
    public PlayerHealth playerHealth;
    public PlayerScore playerScore;
    public Text gameOverText;
    private ICommand _retryCommand;

    void Start()
    {
        playerHealth.Attach(this);
        gameOverText.gameObject.SetActive(false);
        _retryCommand = new RetryCommand(playerHealth, this);
    }

    public void UpdateObserver()
    {
        if (playerHealth.Health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        EnhancedLogger.Log("GAME OVER !!", EnhancedLogger.LogLevel.Error);
        
        gameOverText.text = "Game Over\nPress 'R' to Retry";
        Time.timeScale = 0; // Pause the game
        
        playerScore.SaveHighScore(); //SaveHighScore!!
        playerScore.ResetScore();

        gameOverText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            _retryCommand.Execute();
        }
    }

    public void ResetGame()
    {
        // Hide the game over text
        gameOverText.gameObject.SetActive(false);

        // Resume the game
        Time.timeScale = 1;

        // Reset other necessary game states here
    }

    void OnDestroy()
    {
        playerHealth.Detach(this);
    }
}
