using System;

public class LevelData
{
    public string Name { get; private set; }
    public bool Unlocked { get; private set; }
    public int Score { get; private set; }

    public LevelData(bool isUnlocked = false, int score = 0, string name = "")
    {
        Unlocked = isUnlocked;
        Score = score;
        Name = name;
    }

    public void SetScore(int score) => Score = score;
    public void Lock() => Unlocked = false;
    public void UnLock() => Unlocked = true;
}
