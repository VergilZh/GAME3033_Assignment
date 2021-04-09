using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TurretFire", spawnTime, spawnDelay);
        //target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
    }

    void TurretFire()
    { 
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
