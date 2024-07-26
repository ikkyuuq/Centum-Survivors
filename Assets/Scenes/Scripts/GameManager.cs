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
        EnemyManager();
        //so on... jai dee laew na krub :)
    }
    void PlayerMovement() {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerMoveSpeed);
    }
    void EnemyManager() {
        enemySpawnTime += Time.deltaTime;
        if (enemySpawnTime >= 1f) {
            enemies.Add(Instantiate(enemyPrefab, player.transform.position + (Vector3)Random.insideUnitCircle.normalized * 10f, Quaternion.identity));
            enemySpawnTime = 0;
        }
        foreach (var en in enemies) {
            if (en != null) {
                // TODO: Enemy move speed on each type
                en.GetComponent<Rigidbody2D>().MovePosition(en.transform.position + (Vector3)(player.transform.position - en.transform.position).normalized * Time.deltaTime * 2f);
            }
        }
    }
}
