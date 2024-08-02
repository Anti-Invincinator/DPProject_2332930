using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    private List<IHighScore> highScores = new List<IHighScore>();
    private const string FilePath = "/highscores.dat";

    // Add a new high score
    public void AddHighScore(IHighScore highScore)
    {
        highScores.Add(highScore);
    }

    // Display all high scores
    public void DisplayHighScores()
    {
        highScores.Sort((a, b) => b.Score.CompareTo(a.Score)); // Sort by score descending
        foreach (var highScore in highScores)
        {
            highScore.DisplayScore();
        }
    }

    // Save high scores to a file
    public void SaveHighScores()
    {
        List<HighScoreData> dataList = new List<HighScoreData>();
        foreach (var highScore in highScores)
        {
            dataList.Add(new HighScoreData { playerName = highScore.PlayerName, playerScore = highScore.Score });
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + FilePath);
        bf.Serialize(file, dataList);
        file.Close();
    }

    // Load high scores from a file
    public void LoadHighScores()
    {
        if (File.Exists(Application.persistentDataPath + FilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FilePath, FileMode.Open);
            List<HighScoreData> dataList = (List<HighScoreData>)bf.Deserialize(file);
            file.Close();

            highScores.Clear();
            foreach (var data in dataList)
            {
                OldPlayerData oldData = new OldPlayerData { playerName = data.playerName, playerScore = data.playerScore };
                IHighScore highScore = new HighScoreAdapter(oldData);
                highScores.Add(highScore);
            }

            EnhancedLogger.Log("High score file path found: " + Application.persistentDataPath + FilePath, EnhancedLogger.LogLevel.Info);
        }
    }

    void PrintHighScores()
    {
        if (File.Exists(Application.persistentDataPath + FilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FilePath, FileMode.Open);
            List<HighScoreData> dataList = (List<HighScoreData>)bf.Deserialize(file);
            file.Close();

            foreach (var data in dataList)
            {
                Debug.Log("HighScoreData :: Player: " + data.playerName + ", Score: " + data.playerScore);
            }
        }
        else
        {
            Debug.Log("High score file not found.");
        }
    }

    // Example usage
    void Start()
    {
        // Load existing high scores
        LoadHighScores();

        // Display high scores
        DisplayHighScores();

        LoadHighScores();
        DisplayHighScores();
        PrintHighScores();
    }
}
