using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public float spawnTime = 5.0f;
    public float enemyTime = 1.0f;
    public player player;

    void Start()
    {
        
    }


    void Update()
    {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        enemyTime += Time.deltaTime;
        if (enemyTime > spawnTime)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.0f, 7.0f), -4.0f, 0), Quaternion.identity);
            enemyTime = 0.0f;
        }
    }
}
