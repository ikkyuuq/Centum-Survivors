using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour{
    public GameObject playerPrefab, enemyPrefab;
    private GameObject player;
    private List<GameObject> enemies, projectiles = new List<GameObject>();
    void Start(){
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update(){

    }
}
