using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    public static event Action OnScoreUpdated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            OnScoreUpdated?.Invoke();
        }
    }

}