using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.SceneManagement.SceneManager;
using static UnityEngine.SceneManagement.LoadSceneMode;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<string> levels;
    public static Action OnLoadLevel;
    public static Action<int> OnLoadLevelAtIndex;
    public static Action OnReload;

    private int currentLevelIndex = 0;


    private void OnEnable()
    {
        OnLoadLevel += LoadLevel;
        OnLoadLevelAtIndex += LoadLevelIndex;
        OnReload += ReloadLevel;
    }

    private void OnDisable()
    {
        OnLoadLevel -= LoadLevel;
        OnLoadLevelAtIndex -= LoadLevelIndex;
        OnReload -= ReloadLevel;
    }

    public static void LoadNextLevel()
    {
        OnLoadLevel?.Invoke();
    }

    public static void LoadLevelAtIndex(int index)
    {
        OnLoadLevelAtIndex?.Invoke(0);
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
        LoadSceneAsync(levels[idx], Additive);
    }

    private void LoadLevel()
    {
        StartCoroutine(LoadLevelOnTimer());
    }

    private void ReloadLevel()
    {
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
        LoadSceneAsync(levels[currentLevelIndex], Additive);
        UnloadSceneAsync(GetSceneByName(levels[currentLevelIndex]));
    }

    IEnumerator LoadLevelOnTimer()
    {
        float time = 0;
        while (time < 2.75f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        LoadSceneAsync(levels[currentLevelIndex+1], Additive);
        UnloadSceneAsync(GetSceneByName(levels[currentLevelIndex]));
        currentLevelIndex++;
    }
}
