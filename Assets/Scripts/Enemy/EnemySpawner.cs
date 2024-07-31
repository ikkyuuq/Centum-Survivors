// 50 lines
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<Enemy> enemies;
        public int waveLimit,
            spawnedCounter;
        public float spawnInterval;
    }

    [System.Serializable]
    public class Enemy
    {
        public string name;
        public int amount,
            spawnedCounter;
        public GameObject prefab;
    }

    Transform player;
    public List<Wave> waves;
    public int currentWave;
    float spawnTimer;
    public int alive,
        amax;
    public bool max;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        SpawnEnemies();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWave].spawnInterval)
        {
            SpawnEnemies();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemies()
    {
        if (waves[currentWave].spawnedCounter < waves[currentWave].waveLimit)
        {
            foreach (var enemy in waves[currentWave].enemies)
            {
                if (enemy.spawnedCounter < enemy.amount)
                {
                    if (alive >= amax)
                    {
                        max = true;
                        return;
                    }
                    Vector2 spawnPos = new Vector2(
                        player.transform.position.x + Random.Range(-10f, 10f),
                        player.transform.position.y + Random.Range(-10f, 10f)
                    );
                    Instantiate(enemy.prefab, spawnPos, Quaternion.identity);
                    enemy.spawnedCounter++;
                    waves[currentWave].spawnedCounter++;
                    alive++;
                }
            }
        }
        if (alive < amax)
            max = false;
    }

    public void OnKilled() => alive--;
}
