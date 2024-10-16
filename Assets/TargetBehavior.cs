using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public float speed;

    public float pointVal;

    public float size;

    private Rigidbody2D rb;

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
