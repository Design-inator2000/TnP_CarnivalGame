using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using LitJson;

public class TargetBehavior : TransformSaver, IPoolableObject
{
    public float speed;

    public int pointVal;

    public float size;

    [SerializeField]
    public Sprite[] sprites;

    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;

    // ADDED BY DYLAN: This action will update the score UI without extraneous hard references.
    public static event Action<int> OnScoreUpdated;
    public event IPoolableObject.OnDisable OnDestroy;


    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    private void Update()
    {
        //Movement
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        //Size
        this.transform.localScale = new Vector3(size, size, size);
    }

    //Property altering methods
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetPointVal(int newPointVal)
    {
        pointVal = newPointVal;
    }

    public void SetSprite(int spriteIndex)
    {
        mySpriteRenderer.sprite = sprites[spriteIndex];
    }

    public void TakeDamage()
    {
        Debug.Log("Goon Collides with Bullet! Score Updated!");
        OnScoreUpdated?.Invoke(pointVal);
        OnDestroy?.Invoke(this);
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Invoke("Deactivate", 45f);
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }

    public override void LoadFromData(JsonData saveJson)
    {
        base.LoadFromData(saveJson);

    }
}

