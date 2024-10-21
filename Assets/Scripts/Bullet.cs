using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject
{
    Rigidbody2D rb;

    public event IPoolableObject.OnDisable OnDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 force)
    {
        rb.velocity = force;
    }    
    void SelfDestroy()
    {
        rb.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<TargetBehavior>()?.TakeDamage();
        SelfDestroy();
    }

    private void OnBecameInvisible()
    {
        SelfDestroy();
    }
}
