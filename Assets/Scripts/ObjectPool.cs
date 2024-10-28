using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool<T> where T : IPoolableObject
{

    public HashSet<GameObject> pool { get; private set; } = new HashSet<GameObject>();

    Queue<T> queue=new Queue<T>();
    Dictionary<T, GameObject> pooledObject=new Dictionary<T, GameObject>();
    GameObject prefab;
    public ObjectPool(int initialSize,GameObject objectPrefab)
    {
        prefab = objectPrefab;
        for(int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
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
        if (queue.Count <= 0)
        {
            Debug.Log("adding new objects to pool");
            for (int i = 0; i < 10; i++)
            {
                GameObject obj = GameObject.Instantiate(prefab);
                T poolableObject = obj.GetComponent<T>();
                obj.SetActive(false);
                pool.Add(obj);
                pooledObject[poolableObject] = obj;
                queue.Enqueue(poolableObject);
                poolableObject.OnDestroy += ObjectDisabled;
            }
        }
            T x = queue.Dequeue();
            pooledObject[x].SetActive(true);
        pooledObject[x].transform.position = position;

            return x;

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
