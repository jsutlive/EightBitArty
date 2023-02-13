using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public bool Unlocked { get; private set; }
    public int Score { get; private set; }

    public LevelData(bool isUnlocked = false, int score = 0)
    {
        Unlocked = isUnlocked;
        Score = score;
    }
}
