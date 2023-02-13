using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class SaveDataSerializer : MonoBehaviour
{
    public List<LevelData> data;
    private int currentIndexLocation;

    private void OnEnable()
    {
        GameManager.OnLoadLevel += SaveAtCurrentIndex;
        GameManager.OnLoadLevelAtIndex += ChangeToIndex;
    }

    private void OnDisable()
    {
        GameManager.OnLoadLevel -= SaveAtCurrentIndex;
        GameManager.OnLoadLevelAtIndex -= ChangeToIndex;
    }

    private void SaveAtCurrentIndex()
    {
        Save();
        currentIndexLocation++;
    }
    private void ChangeToIndex(int idx) => currentIndexLocation = idx;


    public void Save()
    {

    }
}
