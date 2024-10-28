using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private ObjectPool<Bullet> bulletPool;
    public GameObject bulletPrefab;

    //object separate from ScoreTracking that saves score value/might be better to connect it directly
    public ScoreTracking binarySaveObject;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool<Bullet>(25, bulletPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = bulletPool.Spawn(this.transform.position);
            bullet.Launch(Vector2.up * 5);
        }

        //Save Buttons
        if (Input.GetKeyDown(KeyCode.Return))
        {
            BinarySavingService.Save(binarySaveObject);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            BinarySavingService.Load(binarySaveObject); 
        }
    }
}
