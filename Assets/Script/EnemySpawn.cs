using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    public float spawnDelay;
    public int enemyNum;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnEnemy()
    {
        if (enemyNum <= 10)
        { 
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemyNum++;
        }
    }
}
