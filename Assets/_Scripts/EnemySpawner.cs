using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public Sprite[] enemySprites;  // Array of enemy sprites

    private List<GameObject> enemyPool;
    private int poolSize = 10;

    void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPool.Add(obj);
        }

        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        if (enemy != null)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            enemy.transform.position = spawnPoint.position;
            enemy.GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
            enemy.SetActive(true);
        }
    }

    GameObject GetPooledEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        return null;
    }
}
