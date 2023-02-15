using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Scriptable Object", menuName = "Scriptable Objects/LevelSO")]
public class LevelSO : ScriptableObject
{
    [field:SerializeField, Tooltip("Scene asset to reference. The level name is the name of this object, not the scene")]
    public string SceneName { get; private set; }
    public Sprite scenePreview;

    public LevelData levelSaveData;

    private void OnEnable()
    {
        levelSaveData = new LevelData(false, 0, name);
    }
    public void Unlock() => levelSaveData.UnLock();
    public bool IsUnlocked() => levelSaveData.Unlocked;
    public string GetName() => levelSaveData.Name;
    public int GetScore() => levelSaveData.Score;
    public void RecordScore(int score) => levelSaveData.SetScore(Mathf.Max(score, levelSaveData.Score));
}
