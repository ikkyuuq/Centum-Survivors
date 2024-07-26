using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour{
    public GameObject playerPrefab, enemyPrefab;
    public float playerMoveSpeed = 5f, enemySpawnTime = 0f;
    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>(), projectiles = new List<GameObject>();
    void Start(){
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update(){
        PlayerMovement();
        EnemySpawner();
        //so on... jai dee laew na krub :)
    }
    void PlayerMovement() {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerMoveSpeed);
    }
    void EnemySpawner() {
        enemySpawnTime += Time.deltaTime;
        if (enemySpawnTime >= 1f) {
            Vector3 spawnPosition = player.transform.position + (Vector3)Random.insideUnitCircle.normalized * 10f;
            enemies.Add(Instantiate(enemyPrefab, spawnPosition, Quaternion.identity));
            enemySpawnTime = 0;
        }
    }
}
