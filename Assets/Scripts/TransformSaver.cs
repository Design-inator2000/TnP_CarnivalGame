using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class TransformSaver : SaveableBehaviour
{
    string _saveID;
    public string saveID { get{ return _saveID; } set { _saveID = value; } }

    public object SavedObject => this;

    // TO DO: Convert localRotation to Vector3
    public JsonData savedData
    {
        get
        {
            var result = new JsonData();
            result[LOCAL_POSITION_KEY] = SerializeValue(transform.localPosition);
            //result[LOCAL_ROTATION_KEY] = SerializeValue(transform.localRotation);
            result[LOCAL_SCALE_KEY] = SerializeValue(transform.localScale);
            return result;
        }
    }

    private JsonData SerializeValue(Vector3 localPosition)
    {
        throw new NotImplementedException();
    }

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

    // TO DO: Deserialize values
    public void LoadFromData(JsonData saveJson)
    {
        if (saveJson.ContainsKey(LOCAL_POSITION_KEY)) 
        { 
            // transform.localPosition = DeserializeValue<Vector3>(saveJson[LOCAL_POSITION_KEY]); 
        }
        if (saveJson.ContainsKey(LOCAL_ROTATION_KEY)) 
        { 
            // transform.localRotation = DeserializeValue<Quaternion>(saveJson[LOCAL_ROTATION_KEY]); 
        }
        if (saveJson.ContainsKey(LOCAL_SCALE_KEY)) 
        { 
            // transform.localScale = DeserializeValue<Vector3>(saveJson[LOCAL_SCALE_KEY]); 
        }
    }
}
