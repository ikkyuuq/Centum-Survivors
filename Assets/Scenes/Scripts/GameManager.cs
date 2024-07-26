using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab;
    public float playerMoveSpeed = 5f, enemySpawnTime = 0f ,  enemySpawnInterval = 1f , enemyMoveSpeed = 3f , progressionInterval = 5f , spawnRateIncrease = 0.1f , speedIncrease = 0.5f , progressionTimer = 0f;
    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>(), projectiles = new List<GameObject>();
    void Start()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update() {
        PlayerMovement();
        EnemyManager();
        HandleProgression();
    }
    void PlayerMovement()
    {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerMoveSpeed);
    }
    void EnemyManager() {
        enemySpawnTime += Time.deltaTime;
        if (enemySpawnTime >= enemySpawnInterval) {
            enemies.Add(Instantiate(enemyPrefab, player.transform.position + (Vector3)Random.insideUnitCircle.normalized * 10f, Quaternion.identity));
            enemySpawnTime = 0;
        }

        foreach (var enemy in enemies) {
            if (enemy != null) {
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                Vector2 direction = (player.transform.position - enemy.transform.position).normalized;
                rb.MovePosition(rb.position + direction * Time.deltaTime * enemyMoveSpeed);
            }
        }
    }
    void HandleProgression() {
        progressionTimer += Time.deltaTime;
        if (progressionTimer >= progressionInterval) {
            enemySpawnInterval = Mathf.Max(0.5f, enemySpawnInterval - spawnRateIncrease); 
            enemyMoveSpeed += speedIncrease;
            progressionTimer = 0;
        }
    }
}
