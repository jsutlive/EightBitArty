using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] LevelSO level;
    [SerializeField] Text score;
    [SerializeField] Text levelName;
    [SerializeField] Image img;
    [SerializeField] Button availableLevel;

    private void Start()
    {
        if (level.IsUnlocked())
        {
            score.text = level.GetScore().ToString();
            levelName.text = level.GetName();
            img.sprite = level.scenePreview;
        }
        else
        {
            score.text = "?";
            levelName.text = "?";
            availableLevel.interactable = false;

        }
    }

    public void ChangeLevel()
    {
        LoadLevelOfObject(level);
    }
}
