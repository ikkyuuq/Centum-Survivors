using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour{
    public GameObject playerPrefab, enemyPrefab;
    public float playerMoveSpeed = 5f;
    private GameObject player;
    private List<GameObject> enemies, projectiles = new List<GameObject>();
    void Start(){
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update(){
        PlayerMovement();
        //so on... jai dee laew na krub :)
    }
    void PlayerMovement() {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerMoveSpeed);
    }
}
