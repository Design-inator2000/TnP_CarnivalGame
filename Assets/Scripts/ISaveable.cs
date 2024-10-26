using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;


public interface ISaveable
{
    string saveID { get; }
    object SavedObject { get; }
    public string SaveData()
    {
        return JsonUtility.ToJson(SavedObject);
    }
    void LoadFromData(string saveJson);
}

public static class SavingService 
{
    private const string ACTIVE_SCENE_KEY = "activeScene";
    private const string SCENES_KEY = "scenes";
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";

    public static void SaveGame(string fileName)
    {
        var allSaveableObjects = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>();
        string result=null;
        if (allSaveableObjects.Count() > 0)
        {
            string savedOBj;
            foreach (var saveableObject in allSaveableObjects)
            {
                savedOBj = saveableObject.SaveData();


            }
        }
    }

    public static void LoadGame(string fileName)
    {

    }
}




