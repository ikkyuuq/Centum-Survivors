// 12 lines
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptable enemyData;
    Rigidbody2D rb;
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() =>
        rb.MovePosition(
            rb.transform.position
                + (Vector3)(player.transform.position - rb.transform.position).normalized
                    * Time.deltaTime
                    * enemyData.moveSpeed
        );
}
