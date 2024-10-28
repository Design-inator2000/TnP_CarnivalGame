using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySavingService
{
    public static string directory = "SaveData";
    public static string fileName = "MySave.txt";

    //BinarySaveObject is an serialized intermediary object that will hold the Player's score. This object will have to be accessed by the Score tracking class.
    public static void Save(ScoreTracking saveObject)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        Debug.Log(file.ToString());
        Debug.Log(saveObject.score);
        binaryFormatter.Serialize(file, saveObject.score);
        file.Close();
    }

    public static void Load(ScoreTracking binarySaveObject)
    {
        if (SaveExists())
        {
            try
            {
                //if (!Directory.Exists(directory)) {Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);}

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                binarySaveObject.LoadScore((int)binaryFormatter.Deserialize(file));
                file.Close();

                //return binarySaveObject;
            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
                //return null;
            }
        }
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
