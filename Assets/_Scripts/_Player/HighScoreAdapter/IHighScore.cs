// IHighScore.cs
public interface IHighScore
{
    string PlayerName { get; }
    int Score { get; }
    void DisplayScore();
}
