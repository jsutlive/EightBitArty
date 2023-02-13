using UnityEngine;
using static GameManager;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] int levelIndex;
    
    public void ChangeLevel()
    {
        LoadLevelAtIndex(levelIndex);
    }
}
