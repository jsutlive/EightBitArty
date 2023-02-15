using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.SceneManagement.SceneManager;
using static UnityEngine.SceneManagement.LoadSceneMode;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<LevelSO> levels;
    [SerializeField] SaveDataSerializer dataSaver;
    public static Action OnLoadLevel;
    private static Action<int> OnLoadLevelAtIndex;
    public static Action OnReload;
    private static Action<LevelSO> OnLoadLevelOfObject;

    private int currentLevelIndex = 0;

    public void RecordScore(int score)
    {
        levels[currentLevelIndex].RecordScore(score);
    }

    private void OnEnable()
    {
        OnLoadLevel += LoadLevel;
        OnLoadLevelAtIndex += LoadLevelIndex;
        OnLoadLevelOfObject += LoadLevelObject;
        OnReload += ReloadLevel;
    }

    private void OnDisable()
    {
        OnLoadLevel -= LoadLevel;
        OnLoadLevelAtIndex -= LoadLevelIndex;
        OnLoadLevelOfObject -= LoadLevelObject;
        OnReload -= ReloadLevel;
    }

    public static void LoadNextLevel()
    {
        OnLoadLevel?.Invoke();
    }

    public static void LoadLevelOfObject(LevelSO level)
    {
        OnLoadLevelOfObject?.Invoke(level);
    }

    private void LoadLevelObject(LevelSO level)
    {
        if (GetSceneByName("MainMenuUI").isLoaded)
        {
            UnloadSceneAsync(GetSceneByName("MainMenuUI"));
        }
        LoadSceneAsync(level.SceneName, Additive);
    }

    public static void LoadLevelAtIndex(int index = 0)
    {
        OnLoadLevelAtIndex?.Invoke(index);
    }

    public static void ReloadCurrentLevel()
    {
        OnReload?.Invoke();
    }

    private void LoadLevelIndex(int idx)
    {
        if (GetSceneByName("MainMenuUI").isLoaded)
        {
            UnloadSceneAsync(GetSceneByName("MainMenuUI"));
        }
        if(idx == 0)
        {
            levels[idx].Unlock();
        }
        LoadSceneAsync(levels[idx].SceneName, Additive);
    }

    private void LoadLevel()
    {
        StartCoroutine(LoadLevelOnTimer());
    }

    private void ReloadLevel()
    {
        Debug.Log("HERE");
        StartCoroutine(ReloadLevelOnTimer());
    }

    IEnumerator ReloadLevelOnTimer()
    {
        float time = 0;
        while (time < 2.75f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        LoadSceneAsync(levels[currentLevelIndex].SceneName, Additive);
        UnloadSceneAsync(GetSceneByName(levels[currentLevelIndex].SceneName));
    }

    IEnumerator LoadLevelOnTimer()
    {
        float time = 0;
        while (time < 2.75f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        //dataSaver.Save(levels[currentLevelIndex]);
        levels[currentLevelIndex+1].Unlock();
        LoadSceneAsync(levels[currentLevelIndex+1].SceneName, Additive);
        UnloadSceneAsync(GetSceneByName(levels[currentLevelIndex].SceneName));
        currentLevelIndex++;
    }
}
