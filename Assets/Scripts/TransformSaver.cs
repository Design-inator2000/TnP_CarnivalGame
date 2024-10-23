using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSaver : MonoBehaviour, ISaveable
{
    string _saveID;
    public string saveID {get{ return _saveID; } set { _saveID = value; } }

    public object SavedObject => this;

    private const string LOCAL_POSITION_KEY = "localPosition";
    private const string LOCAL_ROTATION_KEY = "localRotation";
    private const string LOCAL_SCALE_KEY = "localScale";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadFromData(string saveJson)
    {
        throw new System.NotImplementedException();
    }
}
