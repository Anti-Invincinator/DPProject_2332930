using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryCommand : ICommand
{
    private PlayerHealth _playerHealth;
    private GameManager _gameManager;
    private PlayerScore _scoreManager;

    public RetryCommand(PlayerHealth playerHealth, GameManager gameManager)
    {
        _playerHealth = playerHealth;
        _gameManager = gameManager;
    }

    public void Execute()
    {
        // Reset player health
        _playerHealth.ResetHealth();

        // Reset the game manager's state
        _gameManager.ResetGame();

        // Reset other necessary game states here
        _scoreManager.ResetScore();
        
    }
}