using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class TransformSaver : SaveableBehaviour
{
    
    public object SavedObject => this;
    struct IsActive
    {
        public int active;
        public IsActive(int val)
        {
            active = val;
        }
    }

    public override JsonData savedData
    {
        get
        {
            var result = new JsonData();
            result[LOCAL_POSITION_KEY] = SerializeValue(transform.localPosition);
            result[LOCAL_ROTATION_KEY] = SerializeValue(transform.localRotation);
            result[LOCAL_SCALE_KEY] = SerializeValue(transform.localScale);
            result[LOCAL_ACTIVE_KEY] = SerializeValue(new IsActive(this.gameObject.activeSelf ? 1 : 0));
            return result;
        }
    }

    private JsonData SerializeValue(object obj) 
    { 
        return JsonMapper.ToObject(JsonUtility.ToJson(obj)); 
    }

    private T DeserializeValue<T>(JsonData jsonData) 
    {
        JsonReader reader = new JsonReader(jsonData.ToJson());
        return JsonMapper.ToObject<T>(reader);
    }

    private const string LOCAL_POSITION_KEY = "localPosition";
    private const string LOCAL_ROTATION_KEY = "localRotation";
    private const string LOCAL_SCALE_KEY = "localScale";
    private const string LOCAL_ACTIVE_KEY = "isActive";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_saveID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TO DO: Deserialize values
    public override void LoadFromData(JsonData saveJson)
    {
        if (saveJson.ContainsKey(LOCAL_POSITION_KEY)) 
        { 
            transform.localPosition = DeserializeValue<Vector3>(saveJson[LOCAL_POSITION_KEY]); 
        }
        if (saveJson.ContainsKey(LOCAL_ROTATION_KEY)) 
        { 
            transform.localRotation = DeserializeValue<Quaternion>(saveJson[LOCAL_ROTATION_KEY]); 
        }
        if (saveJson.ContainsKey(LOCAL_SCALE_KEY)) 
        { 
            transform.localScale = DeserializeValue<Vector3>(saveJson[LOCAL_SCALE_KEY]); 
        }
        if (saveJson.ContainsKey(LOCAL_ACTIVE_KEY))
        {
            gameObject.SetActive(DeserializeValue<IsActive>(saveJson[LOCAL_ACTIVE_KEY]).active==1? true:false);
        }
    }
}
