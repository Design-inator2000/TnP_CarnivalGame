using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool<T> where T : IPoolableObject
{

    HashSet<GameObject> pool=new HashSet<GameObject>();

    Queue<T> queue=new Queue<T>();
    Dictionary<T, GameObject> pooledObject=new Dictionary<T, GameObject>();
    public ObjectPool(int initialSize,GameObject objectPrefab)
    {
     
        for(int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(objectPrefab);
            T poolableObject = obj.GetComponent<T>();
            obj.SetActive(false);
            pool.Add(obj);
            pooledObject[poolableObject]=obj;
            queue.Enqueue(poolableObject);
            poolableObject.OnDestroy+=ObjectDisabled;
        }
       
    }

    private void ObjectDisabled(IPoolableObject poolableObject)
    {
        queue.Enqueue((T)poolableObject);
    }

    public T Spawn(Vector3 position)
    {
        T obj = queue.Dequeue();
        pooledObject[obj].SetActive(true);
        return obj;

    }

    public void DestoryAll()
    {
        foreach(var obj in pool)
        {
            GameObject.Destroy(obj);
        }
        pool.Clear();
        queue.Clear();
    }

 
}
