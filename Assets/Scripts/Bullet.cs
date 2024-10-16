using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject
{
    public event IPoolableObject.OnDisable OnDestroy;
    private void OnEnable()
    {
        Invoke("SelfDestroy", 5);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelfDestroy()
    {
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        SelfDestroy();
    }
}
