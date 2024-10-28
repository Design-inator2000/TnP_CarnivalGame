using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableBehaviour : MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    // This class does implement the SaveID property    

    public virtual JsonData savedData => throw new System.NotImplementedException();

    public string SaveID
    {
        get { return _saveID; }
        // set { _saveID = value; }
    }
    [SerializeReference]
    protected string _saveID;

    public abstract void LoadFromData(JsonData saveJson);    

    public virtual void OnBeforeSerialize()
    {
        if (SaveID == null)
        {
            _saveID = System.Guid.NewGuid().ToString();
            Debug.Log("Current Save ID:" + SaveID);
            Debug.Log(this);
        }
    }

    public void OnAfterDeserialize()
    {
        //throw new System.NotImplementedException();
    }

}
