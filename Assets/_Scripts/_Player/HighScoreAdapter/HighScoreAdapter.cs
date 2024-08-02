using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreAdapter : IHighScore
{
    private readonly OldPlayerData _oldPlayerData;

    public HighScoreAdapter(OldPlayerData oldPlayerData)
    {
        _oldPlayerData = oldPlayerData;
    }

    public string PlayerName => _oldPlayerData.playerName;
    public int Score => _oldPlayerData.playerScore;

    public void DisplayScore()
    {
        _oldPlayerData.PrintPlayerData();
    }
}
