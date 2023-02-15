using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;

public class SaveDataSerializer : MonoBehaviour
{
    XmlSerializer serializer;
    string DATAPATH;

    private void Start()
    {
        DATAPATH = Application.persistentDataPath;
    }
    public void Save(LevelSO so)
    {      
        var stream = new FileStream(DATAPATH + "/" + so.name + ".level", FileMode.Create);
        serializer.Serialize(stream, so.levelSaveData);
        stream.Close();
    }

    public bool Load(LevelSO so)
    {
        if (File.Exists((DATAPATH + "/" + so.name + ".level")))
        {
            var stream = new FileStream(DATAPATH + "/" + so.name + ".level", FileMode.Open);
            LevelData data = serializer.Deserialize(stream) as LevelData;
            so.levelSaveData = data;
            stream.Close();
            return true;
        }
        return false;
    }
   
}
