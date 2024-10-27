using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableBehaviour : MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    // This class does implement the SaveID property
    public string saveID => throw new System.NotImplementedException();

    public JsonData savedData => throw new System.NotImplementedException();

    public string SaveID
    {
        get { return saveID; }
        // set { saveID = value; }
    }

    public void LoadFromData(JsonData saveJson)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        if (saveID == null)
        {
            // saveID = System.Guid.NewGuid().ToString();
        }
    }

    public void OnAfterDeserialize()
    {
        throw new System.NotImplementedException();
    }

}
