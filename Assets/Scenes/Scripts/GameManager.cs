using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
    public GameObject playerPrefab, enemyPrefab, projectilePrefab;
    public float enemyAttackDamage = 10f, projectileDamage = 20f, playerHealth = 100f, enemyHealth = 50f, playerMoveSpeed = 5, playerMainClassLevel = 1.0f, projectileSpawnTime = 1f, enemySpawnTime = 0f, enemySpawnInterval = 1f, enemyMoveSpeed = 3f, progressionInterval = 5f, spawnRateIncrease = 0.1f, speedIncrease = 0.5f, progressionTimer = 0f, spiralSpeed = 1.0f, fadeDuration = 2.0f;
    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>(), projectiles = new List<GameObject>();
    void Start() {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update() {
        PlayerManager(); EnemyManager(); HandleProgression();
    }
    void PlayerManager() {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerMoveSpeed);
        projectileSpawnTime += Time.deltaTime;
        if (projectileSpawnTime >= 1f / playerMainClassLevel) {
            GameObject projectile = Instantiate(projectilePrefab, player.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            projectiles.Add(projectile);
            StartCoroutine(SpiralAndFade(projectile));
            projectileSpawnTime = 0;
        }
        if (player.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Enemy"))) {
            playerHealth -= enemyAttackDamage; // Handle player damage (Example : play sound, show effect)
        }
    }
    private IEnumerator SpiralAndFade(GameObject obj) { // Spriral and fade effect for projectiles #1 animation for projectiles
        float angle = 0, startTime = Time.time;
        Renderer objRenderer = obj.GetComponent<Renderer>();
        Color originalColor = objRenderer.material.color;
        while (Time.time - startTime < fadeDuration && obj != null) {
            angle += spiralSpeed * Time.deltaTime;
            obj.transform.position = player.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Mathf.Min(Time.time - startTime, 2.0f);
            objRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, (Time.time - startTime) / fadeDuration));
            yield return null;
        }
        if (obj != null) {
            Destroy(obj);
        }
    }
    void EnemyManager() {
        enemySpawnTime += Time.deltaTime;
        if (enemySpawnTime >= enemySpawnInterval) {
            enemies.Add(Instantiate(enemyPrefab, player.transform.position + (Vector3)Random.insideUnitCircle.normalized * 10f, Quaternion.identity));
            enemySpawnTime = 0;
        }
        List<GameObject> enemiesCopy = new List<GameObject>(enemies);
        foreach (var enemy in enemiesCopy) {
            if (enemy != null){
                enemy.GetComponent<Rigidbody2D>().MovePosition(enemy.GetComponent<Rigidbody2D>().position + (Vector2)(player.transform.position - enemy.transform.position).normalized * Time.deltaTime * enemyMoveSpeed);
                foreach (var projectile in projectiles) {
                    if (projectile != null && projectile.GetComponent<Collider2D>().IsTouching(enemy.GetComponent<Collider2D>())) {
                        enemyHealth -= projectileDamage;
                        Destroy(projectile);
                        if (enemyHealth <= 0) {
                            Destroy(enemy);
                            enemies.Remove(enemy); // Remove from original list after destroying the object
                        }
                        break;
                    }
                }
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