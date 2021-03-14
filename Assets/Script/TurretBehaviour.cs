using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        InvokeRepeating("TurretFire", spawnTime, spawnDelay);
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
