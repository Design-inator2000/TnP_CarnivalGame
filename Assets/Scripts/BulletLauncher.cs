using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    ObjectPool<Bullet> bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool= new ObjectPool<Bullet>(25, bulletPrefab);
        InvokeRepeating("SpawnBullet", 0.5f,2);
    }
    void SpawnBullet()
    {
        bulletPool.Spawn(Vector3.zero);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
