using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetBehavior : MonoBehaviour
{
    public float speed;

    public float pointVal;

    public float size;

    private Rigidbody2D rb;

    // ADDED BY DYLAN: This action will update the score UI without extraneous hard references.
    public static event Action OnScoreUpdated;

    // ADDED BY DYLAN: When a target is hit by a bullet's trigger, it will destroy itself and run the OnScoreUpdated event.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Debug.Log("Goon Collides with Bullet! Score Updated!");
            Destroy(this.gameObject);
            OnScoreUpdated?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Movement
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        //Size
        this.transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
