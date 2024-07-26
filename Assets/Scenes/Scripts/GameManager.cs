using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour{
    public GameObject playerPrefab, enemyPrefab;
    private List<GameObject> players, enemies, projectiles = new List<GameObject>();
    void Start(){
        players = Instantiate(playerPrefab, Vector3.zero)
    }
    void Update(){

    }
}
